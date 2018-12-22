using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using YSWL.AuthenticationManagerClient.Common;

namespace YSWL.AuthenticationManagerClient
{
    public class HttpClientHelper
    {
        private string contentType;
        private string method;
        private int timeOut;

        /// <summary>
        /// 获取当前对象
        /// </summary>
        public static HttpClientHelper Crruent
        {
            get { return new HttpClientHelper(); }
        }

        /// <summary>
        /// 请求类型设置
        /// </summary>
        public string ContentType
        {
            get { return string.IsNullOrEmpty(contentType) ? "application/json;charset=utf-8;" : contentType; }
            set { this.contentType = value; }
        }

        /// <summary>
        /// 请求方法类型（GET POST）
        /// </summary>
        public string Method
        {
            get { return string.IsNullOrEmpty(method) ? "POST" : method; }
            set { this.method = value; }
        }

        /// <summary>
        /// 请求过期时间
        /// </summary>
        public int TimeOut
        {
            get { return timeOut > 0 ? timeOut : 60000; }
            set { this.timeOut = value; }
        }

        /// <summary>
        /// 请求头管理
        /// </summary>
        public Dictionary<string, string> Heads
        {
            get;
            set;
        }

        /// <summary>
        /// 添加请求头
        /// </summary>
        /// <param name="request"></param>
        private void AddHead(HttpWebRequest request)
        {
            if (Heads != null && Heads.Any())
            {
                foreach (var item in Heads)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// 发生请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postDataStr">提交json数据</param>
        /// <returns></returns>
        public BackResultModel SendRequest(string url, Dictionary<string, string> postData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = this.Method;
            request.ContentType = "application/json;charset=utf-8;";
            AddHead(request);
            request.Timeout = this.TimeOut;
            byte[] bs = Encoding.UTF8.GetBytes(GetRequestJsonStr(postData));
            request.ContentLength = bs.Length;
            request.GetRequestStream().Write(bs, 0, bs.Length);
            HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
            string responseContent = "";
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                responseContent = streamReader.ReadToEnd();
            }
            request.Abort();
            httpWebResponse.Close();            
            return string.IsNullOrEmpty(responseContent) ? null : Newtonsoft.Json.JsonConvert.DeserializeObject<BackResultModel>(responseContent);
        }

        /// <summary>
        /// 获取json串
        /// </summary>
        /// <param name="jsonObj"></param>
        /// <returns></returns>
        private string GetRequestJsonStr(Dictionary<string, string> jsonObj)
        {
            if (jsonObj == null || !jsonObj.Any())
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (var item in jsonObj)
            {
                sb.Append("\"" + item.Key + "\":\"" + item.Value + "\",");
            }
            var temp = sb.ToString();
            temp = temp.Trim(',');
            return temp + "}";
        }

    }
}
