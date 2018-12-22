using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using YSWL.AuthenticationManagerCenterLib.CommonLib;

namespace YSWL.AuthenticationManagerCenterLib.Synchronization
{
    /// <summary>
    /// 退出登录
    /// </summary>
    public class SingOut : UserManagerBase
    {
        /// <summary>
        /// 获取当前对象
        /// </summary>
        public static SingOut Current
        {
            get { return new SingOut(); }
        }

        /// <summary>
        /// 退出当前登录
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="randStr"></param>
        /// <param name="encryptedStr"></param>
        /// <returns></returns>
        public string SingCurrentOut(string ticket, string randStr, string encryptedStr)
        {
            try
            {
                string result = CheckFromSource(ticket, randStr, encryptedStr);
                if (result != GlobalStateCode.OK.ToString())
                {
                    return GlobalBackResult.GetBackResultJson(ticket, randStr, result);
                }
                var userInfo = CacheHelper.GetObject<ValidateUserInfoObj>(ticket);
                if (userInfo == null)
                {
                    return GlobalBackResult.GetBackResultJson(ticket, randStr, GlobalStateCode.OK.ToString());
                }
                CacheHelper.Remove(ticket);
                CacheHelper.Remove(CommonConst.SAASPASSWORD_.ToString() + userInfo.UserID);
                CacheHelper.Remove(CommonConst.SYSTEMID_.ToString() + userInfo.UserID);
                return GlobalBackResult.GetBackResultJson(ticket, randStr, GlobalStateCode.OK.ToString());

            }
            catch (Exception ex)
            {
                //记录日志
                return GlobalBackResult.GetBackResultJson(ticket, randStr, GlobalStateCode.HANDLEXCEPTION.ToString());
            }
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="jsonStr">请求的json串</param>
        /// <returns></returns>
        public string SingCurrentOut(string jsonStr)
        {
            if (jsonStr.JuadgeIsEmptyAndNull())
            {
                return GlobalBackResult.GetBackResultJson(null, null, GlobalStateCode.EMPTY.ToString());
            }
            RequestValidateModel model = CacheHelper.ConvertJsonToObject<RequestValidateModel>(jsonStr);
            return SingCurrentOut(model.ticket, model.randStr, model.encryptStr);
        }

        /// <summary>
        /// 退出当前登录
        /// </summary>
        /// <returns></returns>
        public string SingCurrentOut()
        {
            string responseContent = "";
            using (StreamReader streamReader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                responseContent = streamReader.ReadToEnd();
            }
            return SingCurrentOut(responseContent);
        }

        /// <summary>
        /// 退出当前登录
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public bool LogOut(string ticket)
        {
            if (string.IsNullOrEmpty(ticket))
            {
                return false;
            }
            var userInfo = CacheHelper.GetObject<ValidateUserInfoObj>(ticket);
            if (userInfo == null)
            {
                return true;
            }
            CacheHelper.Remove(ticket);
            CacheHelper.Remove(CommonConst.SAASPASSWORD_.ToString() + userInfo.UserID);
            CacheHelper.Remove(CommonConst.SYSTEMID_.ToString() + userInfo.UserID);
            return true;
        }
    }
}
