using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using YSWL.Common;
using YSWL.SAAS.IDAL;

namespace YSWL.SAAS.BLL
{

   public class SAASInfo
   {
       private static readonly ISAASInfo dal = (ISAASInfo)new YSWL.SAAS.SQLServerDAL.SAASInfo();

        public static YSWL.Common.DataCacheCore coreBll = new DataCacheCore(new CacheOption
        {
            CacheType = GetSystemBoolValue("RedisCacheUse")? CacheType.Redis : CacheType.IIS,
            CancelProductKey = true,
            CancelEnterpriseKey = true,
            DefaultDb = 0,
            ReadWriteHosts = SAASInfo.GetSystemValue("RedisCacheReadWriteHosts"),
            ReadOnlyHosts = SAASInfo.GetSystemValue("RedisCacheReadOnlyHosts"),
        });
        #region 获取登录用户信息

        public static DataSet GetSAASUserInfo(string userName, byte[] encPassword, int userType = 1,
            long enterpriseId = 0)
        {
            return dal.GetSAASUserInfo(userName, encPassword, userType, enterpriseId);
        }

        #endregion

        #region   添加SAAS用户

        public static bool CreateSAASUser(string userName, byte[] encPassword, string trueName, string phone,
            long enterpriseId, int userType = 1, string applicationids = "",bool isCover=false)
        {
            return dal.CreateSAASUser(userName, encPassword, trueName, phone, enterpriseId, userType, applicationids, isCover);
        }


        #endregion

        #region  SAAS 用户是否存在

        public static int IsExistsUser(string userName)
        {
            return dal.IsExistsUser(userName);
        }

        public static bool IsExistsUserLink(int userId, int applicationId)
        {
            return dal.IsExistsUserLink(userId, applicationId);
        }

        #endregion

        #region  修改密码同步至SAAS系统

        public static bool SetPassword(string userName, byte[] encPassword)
        {
            return dal.SetPassword(userName, encPassword);
        }

        #endregion

        #region 更新用户信息

        /// <summary>
        /// 更新SAAS用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="trueName"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool UpdateUser(string userName, byte[] encPassword, string trueName, string phone,
            long enterpriseId, bool activity)
        {
            return dal.UpdateUser(userName, encPassword, trueName, phone, enterpriseId, activity);
        }

        #endregion

        #region 应用是否开通

        /// <summary>
        /// APP 是否开通应用
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="enterpeiseId"></param>
        /// <returns></returns>
        public static bool AppIsOpenCache(string tag, int enterpeiseId)
        {
            bool isOpen = false;
            string key = tag + "_" + enterpeiseId;
            string isOpenStr = "";

            try
            {
                isOpenStr = coreBll.GetCache<String>(key);
            }
            catch (Exception ex)
            {
                Log.LogHelper.AddTextLog("获取是否开启ERP失败" + ex.Message, "错误信息：" + ex.StackTrace);
                throw;
            }

            if (String.IsNullOrWhiteSpace(isOpenStr))
            {
                try
                {
                    isOpen = AppIsOpen(tag, enterpeiseId);
                    //写Redis
                    coreBll.SetCache(key, isOpen.ToString(), DateTime.MaxValue, TimeSpan.Zero);
                }
                catch (Exception ex)
                {
                    Log.LogHelper.AddTextLog("获取是否开启ERP失败" + ex.Message, "错误信息：" + ex.StackTrace);
                    throw ex;
                }
            }
            else
            {
                isOpen = Common.Globals.SafeBool(isOpenStr, false);
            }
            return isOpen;
        }

        public static bool AppIsOpen(string tag, int enterpeiseId)
        {
            return dal.AppIsOpen(tag, enterpeiseId);
        }

        #endregion

        #region 获取SaaS参数

        public static string GetSystemValue(string Keyname)
        {
            return dal.GetSystemValue(Keyname);
        }

        public static bool GetSystemBoolValue(string Keyname)
        {
            return Globals.SafeBool(GetSystemValue(Keyname), false);
        }

        #endregion

        #region   获取SAAS企业列表（正常企业）

        public static DataSet GetSAASEnterprises()
        {
            return dal.GetSAASEnterprises();
        }

        public static readonly string[] DOMAIN_SAAS = new string[] { "ys56.com", "yuns56.cn" };
        public static readonly string[] DOMAIN_SAAS_SEC = new string[] { "s.ys56.com", "saas.yuns56.cn", "saasadmin.ys56.com", "localhost" };
        public static int GetSAASEnterpriseIdByDomain(string domain)
        {
            if (string.IsNullOrWhiteSpace(domain) || DOMAIN_SAAS_SEC.Contains(domain))
            {
                return 0;
            }

            string key = "SAAS_" + domain;
            int enterpriseId = -1;
            try
            {
                enterpriseId = Common.Globals.SafeInt(coreBll.GetCache<string>(key), -1);
                if (enterpriseId == -1)
                {
                    enterpriseId = dal.GetSAASEntIdByDomain(domain);
                    if (enterpriseId > 0)
                    {
                        //FileManage.WriteText(new System.Text.StringBuilder("SAASInfo GetSAASEnterpriseIdByDomain enterpriseId:" + enterpriseId));
                        coreBll.SetCache(key, enterpriseId, DateTime.Now.AddHours(5), TimeSpan.Zero);
                    }
                }
            }
            catch (Exception ex)
            {
                YSWL.Log.LogHelper.AddErrorLog(ex.Message, ex.StackTrace);
                return -1;
            }
            return enterpriseId;
        }

        public static bool ClearSAASEnterpriseDomain(string domain)
        {
            string key = "SAAS_" + domain;
            try
            {
                return coreBll.DeleteCache(key);
            }
            catch (Exception ex)
            {
                YSWL.Log.LogHelper.AddErrorLog(ex.Message, ex.StackTrace);
                return false;
            }
        }
        #endregion

 
        public static int GetSAASEntIdByMallDomain(string domain)
        {
            if (string.IsNullOrWhiteSpace(domain) || domain.Contains("localhost"))
            {
                //FileManage.WriteText(new System.Text.StringBuilder(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " SAASInfo GetSAASEnterpriseIdByDomain:" + domain));
                return 0;
            }

            string key = "MALL_" + domain;
            int enterpriseId = -1;
            try
            {
                enterpriseId = Globals.SafeInt(YSWL.RedisClient.RedisBase.GetValue(key), -1);
                if (enterpriseId == -1)
                {
                    //域名加载
                    if (DOMAIN_SAAS.Contains(Globals.GetTopLevelDomain(domain)))
                    {
                        string[] mallTag = domain.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                        enterpriseId = Globals.SafeInt(mallTag[0], -1);
                        //未开通商城应用
                        if (!AppIsOpenCache("MALLB", enterpriseId))
                        {
                            return -1;
                        }
                    }
                }
                if (enterpriseId == -1)
                {
                    //DB加载
                    enterpriseId = dal.GetSAASEntIdByDomain(domain);
                }
                if (enterpriseId > 0)
                {
                    //FileManage.WriteText(new System.Text.StringBuilder("SAASInfo GetSAASEnterpriseIdByDomain enterpriseId:" + enterpriseId));
                    RedisClient.RedisBase.SetValue(key, enterpriseId, DateTime.Now.AddDays(3));
                }
            }
            catch (Exception ex)
            {
                YSWL.Log.LogHelper.AddErrorLog(ex.Message, ex.StackTrace);
                return -1;
            }
            return enterpriseId;
        }

        #region  应用限制访问相关方法

        /// <summary>
        /// 是否可以增加客户 
        /// </summary>
        /// <param name="usertype">用户类型 1：客户类型 2：管理员类型  3：业务员类型</param>
        /// <returns></returns>
        public static bool IsCanAddCust(long enterpriseId, string appTag = "")
        {
            int applicationId = PubConstant.GetApplicationId(appTag);
            if (IsBuy(applicationId, enterpriseId)) //是否已经购买了
            {
                return true;
            }
            else
            {
                //获取免费的客户数
                int freeCusts = GetFreeCusts();
                //获取当前的客户数
                int countCust = GetCacheCusts(enterpriseId);
                return freeCusts > countCust;
            }
        }

        public static bool IsCanAddSales(long enterpriseId, string appTag = "")
        {
            int applicationId = PubConstant.GetApplicationId(appTag);
            if (IsBuy(applicationId, enterpriseId)) //是否已经购买了
            {
                return true;
            }
            else
            {
                //获取免费的客户数
                int freeSales = GetFreeSalses();
                //获取当前的客户数
                int countSales = GetCacheSales(enterpriseId);
                return freeSales > countSales;
            }
        }

        /// <summary>
        /// 获取企业客户数 (Redis 缓存)
        /// </summary>
        /// <returns></returns>
        public static int GetCacheCusts(long enterpriseId)
        {

            string CacheKey = "SAAS_EnterpriseCusts_" + enterpriseId;
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetUserCounts(1, enterpriseId);
                    if (objModel != null)
                    {
                        coreBll.SetCache(CacheKey, objModel, DateTime.MaxValue, TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return Common.Globals.SafeInt(objModel, 0);
        }

        /// <summary>
        /// 清除客户缓存数
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public static bool ClearCacheCusts(long enterpriseId)
        {

            string CacheKey = "SAAS_EnterpriseCusts_" + enterpriseId;
            return coreBll.DeleteCache(CacheKey);
        }

        /// <summary>
        /// 获取企业员工数(Redis 缓存)
        /// </summary>
        /// <returns></returns>
        public static int GetCacheSales(long enterpriseId)
        {
            string CacheKey = "SAAS_EnterpriseSales_" + enterpriseId;
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetUserCounts(3, enterpriseId);
                    if (objModel != null)
                    {
                        coreBll.SetCache(CacheKey, objModel, DateTime.MaxValue, TimeSpan.Zero);
                    }
                }
                catch
                {
                }
            }
            return Common.Globals.SafeInt(objModel, 0);
        }

        /// <summary>
        /// 清除员工缓存数
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public static bool ClearCacheSales(long enterpriseId)
        {
            string CacheKey = "SAAS_EnterpriseSales_" + enterpriseId;
            return coreBll.DeleteCache(CacheKey);
        }

        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <param name="usertype"></param>
        /// <returns></returns>
        private static int GetUserCounts(int usertype, long enterpriseId)
        {
            return dal.GetUserCounts(usertype, enterpriseId);
        }

        /// <summary>
        /// 购买的应用是否过期
        /// </summary>
        /// <param name="appTag"></param>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public static bool IsExpired(int applicationId, long enterpriseId)
        {
            DateTime endTime = GetEndTime(applicationId, enterpriseId);
            return endTime < DateTime.Now;
        }
        /// <summary>
        /// 清空过期缓存
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public static bool DeleteExpiredCache(int applicationId, long enterpriseId)
        {
            string CacheKey = "SAAS_AppEndTime_" + applicationId + "_" + enterpriseId;
            return coreBll.DeleteCache(CacheKey);
        }


        private static DateTime GetEndTime(int applicationId, long enterpriseId)
        {
            string CacheKey = "SAAS_AppEndTime_" + applicationId + "_" + enterpriseId;
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetEndTime(applicationId, enterpriseId);

                    if (objModel != null)
                    {
                        coreBll.SetCache(CacheKey, objModel, DateTime.MaxValue, TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return Common.Globals.SafeDateTime(objModel, DateTime.Now);
        }

        /// <summary>
        /// 应用是否购买
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public static bool IsBuy(int applicationId, long enterpriseId)
        {
            string CacheKey = "SAAS_AppIsBuy_" + applicationId + "_" + enterpriseId;
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.IsBuy(applicationId, enterpriseId);
                    coreBll.SetCache(CacheKey, objModel, DateTime.MaxValue, TimeSpan.Zero);
                }
                catch { }
            }
            return Common.Globals.SafeBool(objModel, false);
        }
        /// <summary>
        /// 设置购买状态缓存
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public static bool SetBuyCache(int applicationId, long enterpriseId)
        {
            string CacheKey = "SAAS_AppIsBuy_" + applicationId + "_" + enterpriseId;
            return coreBll.SetCache(CacheKey, true);
        }

        /// <summary>
        /// 免费的客户数
        /// </summary>
        /// <returns></returns>
        private static int GetFreeCusts()
        {
            string CacheKey = "SAAS_FreeEnterpriseCusts";
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetSysValue(CacheKey);
                    if (objModel != null)
                    {
                        coreBll.SetCache(CacheKey, objModel, DateTime.MaxValue, TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return Common.Globals.SafeInt(objModel, 10);
        }
        /// <summary>
        /// 免费的员工数 （业务员数）
        /// </summary>
        /// <returns></returns>
        private static int GetFreeSalses()
        {
            string CacheKey = "SAAS_FreeEnterpriseSales";
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetSysValue(CacheKey);
                    if (objModel != null)
                    {
                        coreBll.SetCache(CacheKey, objModel, DateTime.MaxValue, TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return Common.Globals.SafeInt(objModel, 5);
        }

        public static string GetSysValue(string key)
        {
            return dal.GetSysValue(key);
        }

        #endregion
        /// <summary>
        /// 获取企业的数据库配置信息
        /// </summary>
        /// <returns></returns>
        public static string GetBusinnessConStr(string applicationTag)
        {
            applicationTag = applicationTag.ToUpper();
            string CacheKey = "SAAS_ConnectionString_" + applicationTag + "_" + Common.CallContextHelper.GetAutoTag();
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null || String.IsNullOrWhiteSpace(objModel.ToString()))
            {
                try
                {
                    objModel = dal.GetBusinnessConStr(applicationTag);
                }
                catch (Exception ex)
                {
                    Log.LogHelper.AddErrorLog("获取连接地址失败：" + ex.Message, "详细错误为：" + ex.StackTrace);
                    throw ex;
                }
            }
            return Common.Globals.SafeString(objModel, "");
        }

        /// <summary>
        /// 获取开通的应用列表
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
       public static List<long> GetOpenApps(long enterpriseId)
       {
            string CacheKey = "YSWL_SAASInfo_OpenApps_"+ enterpriseId;
            List<long> objModel = coreBll.GetCache<List<long>>(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel=new List<long>();
                     DataSet ds= dal.GetOpenApps(enterpriseId);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objModel.Add(Common.Globals.SafeLong(dt.Rows[i]["ApplicationId"].ToString(),0));
                        }
                    }
                }
                catch (Exception exception)
                {
                    return new List<long>();
                }
                if (objModel != null&& objModel.Count>0)
                {
                    coreBll.SetCache(CacheKey, objModel, DateTime.Now.AddHours(72), TimeSpan.Zero);
                }
            }
            return objModel;
        }



       /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool IsDBExists()
        {
            string CacheKey = "YSWL_IsDBExists_ConnectionString";
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.IsDBExists();
                }
                catch (Exception exception)
                {
                    return false;
                }
                if (objModel != null)
                {
                    int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("ModelCache");
                    YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                }
            }
            return Common.Globals.SafeBool(objModel, false);
        }
    }
}
