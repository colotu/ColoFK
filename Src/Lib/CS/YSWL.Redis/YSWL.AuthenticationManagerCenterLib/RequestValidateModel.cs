using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.AuthenticationManagerCenterLib
{
    /// <summary>
    /// 请求验证实体
    /// </summary>
    public class RequestValidateModel
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

    }
}
