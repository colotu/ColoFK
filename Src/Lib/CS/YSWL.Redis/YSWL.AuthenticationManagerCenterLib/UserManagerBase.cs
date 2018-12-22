using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.AuthenticationManagerCenterLib.CommonLib;

namespace YSWL.AuthenticationManagerCenterLib
{
    /// <summary>
    /// 用户管理基类
    /// </summary>
    public class UserManagerBase
    {
        /// <summary>
        /// 验证来源和数据的合法性
        /// </summary>
        /// <param name="ticket">凭证</param>
        /// <param name="randAStr">随机码</param>
        /// <param name="userName">登录名</param>
        /// <param name="pwd">密码</param>
        /// <param name="encryptedStr">加密串</param>
        /// <returns></returns>
        protected string CheckFromSource(string ticket, string randStr, string encryptedStr)
        {
            if (ticket.JuadgeIsEmptyAndNull() || randStr.JuadgeIsEmptyAndNull() || encryptedStr.JuadgeIsEmptyAndNull())
            {
                return GlobalStateCode.EMPTY.ToString();
            }
            string tempStr = ticket.Trim() + "&" + randStr.Trim();
            var encryptedStrTemp = DESEncrypt.Encrypt(tempStr);
            if (encryptedStr.Trim().Equals(encryptedStrTemp))
            {
                return GlobalStateCode.OK.ToString();
            }
            return GlobalStateCode.FROMSOURCEEXCEPTION.ToString();
        }
    }
}
