using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.AuthenticationManagerCenterLib.CommonLib
{
    /// <summary>
    /// 全局返回结果
    /// </summary>
    public class GlobalBackResult
    {
        /// <summary>
        /// 返回全局结果
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="randStr"></param>      
        /// <param name="state"></param>
        /// <returns></returns>
        public static string GetBackResultJson(string ticket, string randStr, string stateStr, ValidateUserInfoObj userInfo = null)
        {
            GlobalStateCode globalSstateCode = (GlobalStateCode)Enum.Parse(typeof(GlobalStateCode), stateStr, true);
            string result = GetShowMsg(globalSstateCode);

            return RedisClient.RedisBase.ConvertObjectToJson<BackResultModel>(new BackResultModel() { ticket = ticket, randStr = randStr, encryptStr = DESEncrypt.Encrypt(ticket.Trim() + "&" + randStr.Trim()), stateCode = globalSstateCode.GetHashCode(), result = RedisClient.RedisBase.ConvertObjectToJson<ValidateUserInfoObj>(userInfo) });
        }

        /// <summary>
        /// 返回处理结果描述
        /// </summary>
        /// <param name="globalSstateCode"></param>
        /// <returns></returns>
        public static string GetShowMsg(GlobalStateCode globalSstateCode)
        {
            switch (globalSstateCode)
            {
                case GlobalStateCode.OK:
                    return "验证通过";
                case GlobalStateCode.EMPTY:
                    return "关键数据为空";
                case GlobalStateCode.WRONGFUL:
                    return "数据格式不对或数据不合法";
                case GlobalStateCode.FROMSOURCEEXCEPTION:
                    return "来源异常或者来源路径异常";
                case GlobalStateCode.NODATA:
                    return "没有查找到数据";
                case GlobalStateCode.HANDLEXCEPTION:
                    return "处理异常";
                case GlobalStateCode.NULL:
                    return "空引用异常";
                default:
                    return "未知异常";
            }
        }
    }

    public class BackResultModel
    {
        public string ticket { get; set; }

        public string randStr { get; set; }

        public string encryptStr { get; set; }

        public string result { get; set; }

        public int stateCode { get; set; }
    }
}
