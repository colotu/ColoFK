using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace YSWL.MALL.BLL.Shop.Service
{
    public class CommonHelper
    {
        /// <summary>
        /// 先临时处理，（后期整体切换Redis缓存）是否开启对接OMS
        /// </summary>
        /// <returns></returns>
        public static bool ConnectionOMS()
        {
            bool isAuto = Common.ConfigHelper.GetConfigBool("AutoConnection");
            string key = "Shop_ConnectionOMS";
            if (isAuto)
            {
                try
                {
                     bool isOpenOMS = YSWL.SAAS.BLL.SAASInfo.AppIsOpenCache("OMS", Common.Globals.SafeInt(Common.CallContextHelper.GetClearTag(), 0));
                     return  YSWL.SAAS.BLL.SAASInfo.AppIsOpenCache("OMS", Common.Globals.SafeInt(Common.CallContextHelper.GetClearTag(), 0));
                }
                catch (Exception)
                {
                    throw;
                }             
            }
            return YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache(key);
        }
        /// <summary>
        /// 开启多分仓
        /// </summary>
        /// <returns></returns>
        public static bool OpenMultiDepot()
        {
            bool isAuto = Common.ConfigHelper.GetConfigBool("AutoConnection");
            string key = "Shop_OpenMultiDepot";
            if (isAuto)
            {
                return ConnectionOMS();
            }
            return YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache(key);
        }


        /// <summary>
        ///是否开启对接WMS
        /// </summary>
        /// <returns></returns>
        public static bool ConnectionWMS()
        {
            bool isAuto = Common.ConfigHelper.GetConfigBool("AutoConnection");
            string key = "OMS_ConnectionWMS";
            if (isAuto)
            {
                if (ConnectionERP())
                {
                    return false;
                }
                return YSWL.SAAS.BLL.SAASInfo.AppIsOpenCache("WMS",
                Common.Globals.SafeInt(Common.CallContextHelper.GetClearTag(), 0));
            }
            return YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache(key);
        }
        /// <summary>
        /// 是否开启连接ERP
        /// </summary>
        /// <returns></returns>
        public static bool ConnectionERP()
        {
            bool isAuto = Common.ConfigHelper.GetConfigBool("AutoConnection");
            string key = "OMS_ConnectionERP";
            if (isAuto)
            {
                string data = YSWL.MALL.BLL.SysManage.ConfigSystem.GetDataConn();
                if (string.IsNullOrWhiteSpace(data) || data.Equals("ERP"))
                {
                    return YSWL.SAAS.BLL.SAASInfo.AppIsOpenCache("ERP",
                   Common.Globals.SafeInt(Common.CallContextHelper.GetClearTag(), 0));
                }
                return false;
            }
            return YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache(key);
        }

    }
}
