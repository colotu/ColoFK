using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using YSWL.AuthenticationManagerClient.Common;
using YSWL.Json;

namespace YSWL.AuthenticationManagerClient
{
    /// <summary>
    /// 单点登录客户端管理
    /// </summary>
    public class ClientManager
    {
        /// <summary>
        /// 校验用户是否登录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string CheckAndStr(string url = "")
        {
            string ticket = HttpContext.Current.Request.Cookies.Get("ticket_yswl") == null ? "" : HttpContext.Current.Request.Cookies.Get("ticket_yswl").Value;
            if (string.IsNullOrEmpty(ticket))
            {
                return null;
            }
            var backResultModel = SendRequest(ticket, url, "AuthenticationCenterUrl");
            if (backResultModel == null)
            {
                return null;
            }
            if (backResultModel.stateCode == 200 && (backResultModel.encryptStr + "").Equals(DESEncrypt.Encrypt(backResultModel.ticket.Trim() + "&" + backResultModel.randStr.Trim())))
            {
                SetCookieExpires(2, ticket);
                return backResultModel.result;
            }
            return null;
        }

        /// <summary>
        /// 校验是否登录并返回用户对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T CheckAndBackModel<T>(string url = "") where T : class
        {
            var modelJsonStr = CheckAndStr(url);
            if (string.IsNullOrEmpty(modelJsonStr))
            {
                return null;
            }
            
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(modelJsonStr);
        }

        public static string CheckUser(string url = "")
        {
            var modelJsonStr = CheckAndStr(url);
            if (string.IsNullOrEmpty(modelJsonStr))
            {
                return null;
            }
            JsonObject obj = YSWL.Json.Conversion.JsonConvert.Import<JsonObject>(modelJsonStr);
            return obj["UserName"].ToString();
        }

        /// <summary>
        /// 退出当前登录
        /// </summary>
        /// <param name="url">退出登录目标url</param>
        /// <returns></returns>
        public static bool SingCurrentOut(string url = "")
        {
            string ticket = HttpContext.Current.Request.Cookies.Get("ticket_yswl") == null ? "" : HttpContext.Current.Request.Cookies.Get("ticket_yswl").Value;
            if (string.IsNullOrEmpty(ticket))
            {
                return true;
            }
            var backResultModel = SendRequest(ticket, url, "AuthenticationCenterOutUrl");
            if (backResultModel == null)
            {
                return false;
            }
            if (backResultModel.stateCode == 200 && (backResultModel.encryptStr + "").Equals(DESEncrypt.Encrypt(backResultModel.ticket.Trim() + "&" + backResultModel.randStr.Trim())))
            {
                var cookie = HttpContext.Current.Request.Cookies["ticket_yswl"];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Today.AddDays(-1);
                    cookie.Domain = $".{System.Configuration.ConfigurationManager.AppSettings["RootDomain"] ?? "ys56.com"}";
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    HttpContext.Current.Request.Cookies.Remove("ticket_yswl");
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置cookie的过期时间
        /// </summary>
        /// <param name="time"></param>
        /// <param name="ticket"></param>
        private static void SetCookieExpires(int time, string ticket)
        {
            HttpCookie cookie = new HttpCookie("ticket_yswl");
            cookie.Value = ticket;
            cookie.Expires = DateTime.Now.AddHours(time);
            cookie.Domain = $".{System.Configuration.ConfigurationManager.AppSettings["RootDomain"] ?? "ys56.com"}";
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 发生请求公共方法
        /// </summary>
        /// <param name="ticket">凭证号</param>
        /// <param name="url">目标地址</param>
        /// <param name="key">默认配置的目标地址key</param>
        /// <returns></returns>
        private static BackResultModel SendRequest(string ticket, string url, string key)
        {
            if (string.IsNullOrEmpty(ticket))
            {
                return null;
            }
            url = string.IsNullOrEmpty(url) ? (System.Configuration.ConfigurationManager.AppSettings[key] + "") : url;
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }
            string randStr = DESEncrypt.GetMD5FromStr("YSWL_" + new Random().Next(1, int.MaxValue));
            var backResultModel = HttpClientHelper.Crruent.SendRequest(url, new Dictionary<string, string>() {
                { "ticket",ticket },
                { "randStr",randStr},
                { "encryptStr",DESEncrypt.Encrypt(ticket.Trim() + "&" + randStr.Trim())}
            });
            return backResultModel;
        }
    }
}
