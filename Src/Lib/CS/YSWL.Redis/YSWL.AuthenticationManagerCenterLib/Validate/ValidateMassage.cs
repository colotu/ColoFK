using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using YSWL.AuthenticationManagerCenterLib.CommonLib;

namespace YSWL.AuthenticationManagerCenterLib.Validate
{
    /// <summary>
    /// 验证客户端信息
    /// </summary>
    public class ValidateMassage : UserManagerBase
    {
        private int expirationTime = 60;

        /// <summary>
        /// 设置登录信息过期时间
        /// </summary>
        /// <param name="expirTime">过期时间（以分钟为单位）</param>
        public void SetExpirationTime(int expirTime)
        {
            this.expirationTime = expirTime;
        }

        /// <summary>
        /// 获取当前对象
        /// </summary>
        public static ValidateMassage Current
        {
            get { return new ValidateMassage(); }
        }

        /// <summary>
        /// 具体验证用户是否登录
        /// </summary>
        /// <param name="ticket">凭证号</param>
        /// <param name="encryptedStr">加密串</param>
        /// <returns></returns>
        public string ValidateLogin(string ticket, string randStr, string encryptedStr, bool isBackUser)
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
                    return GlobalBackResult.GetBackResultJson(ticket, randStr, GlobalStateCode.LOGOUT.ToString());
                }
                CacheHelper.SetExpireIn(ticket, new TimeSpan(0, this.expirationTime, 0));//延长1个小时
                CacheHelper.SetExpireIn(CommonConst.SYSTEMID_.ToString() + userInfo.UserID, new TimeSpan(0, this.expirationTime, 0));
                if (isBackUser)
                {
                    return GlobalBackResult.GetBackResultJson(ticket, randStr, GlobalStateCode.OK.ToString(), userInfo);
                }
                else
                {
                    return GlobalBackResult.GetBackResultJson(ticket, randStr, GlobalStateCode.OK.ToString());
                }
            }
            catch (Exception ex)
            {
                //记录日志
                return GlobalBackResult.GetBackResultJson(ticket, randStr, GlobalStateCode.HANDLEXCEPTION.ToString());
            }
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="jsonStr">请求串</param>
        /// <returns></returns>
        public string ValidateLogin(string jsonStr)
        {
            if (jsonStr.JuadgeIsEmptyAndNull())
            {
                return GlobalBackResult.GetBackResultJson(null, null, GlobalStateCode.EMPTY.ToString());
            }
            RequestValidateModel model = CacheHelper.ConvertJsonToObject<RequestValidateModel>(jsonStr);
            return ValidateLogin(model.ticket, model.randStr, model.encryptStr, true);
        }

        /// <summary>
        /// 校验用户登录信息
        /// </summary>
        /// <returns></returns>
        public string ValidateLogin()
        {
            string responseContent = "";
            using (StreamReader streamReader = new StreamReader(HttpContext.Current.Request.InputStream))
            {
                responseContent = streamReader.ReadToEnd();
            }
            return ValidateLogin(responseContent);
        }

        /// <summary>
        /// 检查用户是否登录
        /// </summary>
        /// <param name="ticket">凭证</param>
        /// <returns></returns>
        public ValidateUserInfoObj CheckLogin(string ticket)
        {
            if (ticket.JuadgeIsEmptyAndNull())
            {
                return null;
            }
            var userInfo = CacheHelper.GetObject<ValidateUserInfoObj>(ticket);
            if (userInfo == null || userInfo.FromSource != "saas")
            {
                return null;
            }
            CacheHelper.SetExpireIn(ticket, new TimeSpan(0, this.expirationTime, 0));//延长1个小时
            CacheHelper.SetExpireIn(CommonConst.SYSTEMID_.ToString() + userInfo.UserID, new TimeSpan(0, this.expirationTime, 0));
            return userInfo;
        }

    }
}
