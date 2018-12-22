using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using YSWL.Common.DEncrypt;
using YSWL.SAAS.BLL;

namespace YSWL.SAAS
{
   public class PubConstant
    {
        /// <summary>
        /// 是否开启自动连接标识key，通过配置文件获取
        /// </summary>
        protected const string KEY_AUTOCONNECTION = "AutoConnection";
        /// <summary>
        /// 系统标识key，从配置文件中获取系统标识
        /// </summary>
        protected const string KEY_SYSTEM_FLAG = "SystemFlag";
        public const string KEY_CONNECTION = "ConnectionString";
        public const string KEY_ENCRYPT = "ConStringEncrypt";

        /// <summary>
        /// SAAS基础连接字符串
        /// </summary>
        protected const string KEY_BASECONNECTION = "BaseConnectionStr";
        /// <summary>
        /// 获取应用ID
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static int GetApplicationId(string tag)
        {
            if (String.IsNullOrWhiteSpace(tag))
            {
                tag = Common.ConfigHelper.GetConfigString("SystemFlag");
            }
            tag = tag.ToUpper();
            switch (tag)
            {
                case "WMS":
                    return 1;
                case "OMS":
                    return 2;
                case "SCM":
                    return 3;
                case "PMS":
                    return 4;
                case "MALLB":
                    return 5;
                case "ERP":
                    return 6;
                case "BI":
                    return 7;
                case "CRM":
                    return 8;
                case "SALES":
                    return 9;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 是否开启动态连接数据库
        /// </summary>
        public static bool isAutoConn
        {
            get
            {
                return Common.Globals.SafeBool(ConfigurationManager.AppSettings[KEY_AUTOCONNECTION], false);
            }
        }
        /// <summary>
        /// 获取应用Id
        /// </summary>
        /// <returns></returns>
        public static int GetApplicationId()
        {
            if (isAutoConn)
            {
                //获取企业标识
                string businessTag = Common.CallContextHelper.GetAutoTag();
                if (string.IsNullOrEmpty(businessTag))
                {
                    return 0;
                }
                string applicationTag = GetSystemFlag();
                if (SAASInfo.GetBusinnessConStr(applicationTag) == null)
                {
                    return 0;
                }

                return GetApplicationId(applicationTag);
            }
            return 0;
        }

        /// <summary>
        /// 获取系统的标识
        /// </summary>
        /// <returns></returns>
        public static string GetSystemFlag()
        {
            return ConfigurationManager.AppSettings[KEY_SYSTEM_FLAG];
        }

        /// <summary>
        /// 获取数据库链接串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionStr()
        {
            if (isAutoConn)
            {
                //获取企业标识
                string businessTag = Common.CallContextHelper.GetAutoTag();
                if (string.IsNullOrEmpty(businessTag))
                {
                    return null;
                }
                //获取企业数据库配置信息
                return SAASInfo.GetBusinnessConStr(GetSystemFlag());
            }
            //更新缓存
            ConfigurationManager.RefreshSection("appSettings");
            string connectionString = ConfigurationManager.AppSettings[KEY_CONNECTION];
            string conStringEncrypt = ConfigurationManager.AppSettings[KEY_ENCRYPT];
            if (conStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }

        /// <summary>
        /// 企业的数据库配置数据库链接串
        /// </summary>
        public static string BaseConnection
        {
            get
            {
                if (isAutoConn)
                {
                    //更新缓存
                    ConfigurationManager.RefreshSection("appSettings");
                    string connectionString = ConfigurationManager.AppSettings[KEY_BASECONNECTION];
                    return connectionString;
                }
                else
                {
                    ConfigurationManager.RefreshSection("appSettings");
                    string connectionString = ConfigurationManager.AppSettings[KEY_CONNECTION];
                    string conStringEncrypt = ConfigurationManager.AppSettings[KEY_ENCRYPT];
                    if (conStringEncrypt == "true")
                    {
                        connectionString = DESEncrypt.Decrypt(connectionString);
                    }
                    return connectionString;
                }
            }
        }
    }
}
