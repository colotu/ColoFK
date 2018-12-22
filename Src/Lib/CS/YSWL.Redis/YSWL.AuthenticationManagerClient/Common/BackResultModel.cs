using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.AuthenticationManagerClient.Common
{
    public class BackResultModel
    {
        /// <summary>
        /// 授权号
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 随机码
        /// </summary>
        public string randStr { get; set; }

        /// <summary>
        /// 加密串
        /// </summary>
        public string encryptStr { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public int stateCode { get; set; }

        /// <summary>
        /// 全局返回结果
        /// </summary>
        public string result { get; set; }
    }
}
