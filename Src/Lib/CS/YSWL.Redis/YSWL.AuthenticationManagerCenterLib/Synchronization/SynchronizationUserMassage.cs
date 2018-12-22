using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.AuthenticationManagerCenterLib.CommonLib;

namespace YSWL.AuthenticationManagerCenterLib.Synchronization
{
    /// <summary>
    /// 同步用户登录信息
    /// </summary>
    public class SynchronizationUserMassage
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
        public static SynchronizationUserMassage Current
        {
            get { return new SynchronizationUserMassage(); }
        }

        /// <summary>
        /// 保存用户登录信息
        /// </summary>
        /// <param name="ticket"></param> 
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool SyschronizationMassage(string ticket, ValidateUserInfoObj userInfo)
        {
            //同步成功后，有效期是1个小时
            return CacheHelper.SetObject<ValidateUserInfoObj>(ticket, userInfo, new TimeSpan(0, this.expirationTime, 0));
        }

        /// <summary>
        /// 同步数据（saas专用）
        /// </summary>
        /// <param name="userInfo">用户对象</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public string SyschronizationMassage(ValidateUserInfoObj userInfo, string fromSource, string systemTag)
        {
          
            userInfo.FromSource = fromSource;
            userInfo.SystemTag = systemTag;
            return SyschronizationMassageAndBackTicket(userInfo);
        }

        /// <summary>
        /// 同步用户登录信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string SyschronizationMassageAndBackTicket(ValidateUserInfoObj userInfo)
        {
            string ticket = DESEncrypt.GetMD5FromStr(userInfo.UserName);
            if (CacheHelper.GetObject<ValidateUserInfoObj>(ticket) != null)
            {
                return ticket;
            }
            return SyschronizationMassage(ticket, userInfo) ? ticket : null;
        }
    }
}
