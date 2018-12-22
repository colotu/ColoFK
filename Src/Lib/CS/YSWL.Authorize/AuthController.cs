using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace YSWL.Authorize
{
    public class  AuthController 
    {
        #region 效验授权码

        /// <summary>
        /// 效验授权码
        /// </summary>
        /// <param name="authorizeCode">授权码</param>
        /// <param name="productInfo">产品信息</param>
        public static bool CheckAuthorize(string authorizeCode, string productInfo = "")
        {
            if (string.IsNullOrWhiteSpace(authorizeCode) || authorizeCode.Length < 0xa ||
                string.IsNullOrWhiteSpace(productInfo))
                return false;

            byte[] key = new byte[0x1];
            bool isSubMode = authorizeCode.Contains("&");
            bool isSNS = (productInfo == "YS56 SNS");

            //顶级授权
            if (!isSubMode)
            {
                //兼容社区老授权
                key = isSNS ? EncryptPassword(TopLevelDomain + "_MS") : EncryptPassword(TopLevelDomain + "_MS_" + productInfo);
            }
            //精确授权
            else
            {
                key = EncryptPassword(Domain + "_MS_SUB_" + productInfo);
            }
            string x16Key = BitConverter.ToString(key).Replace("-", "");

            //单域名授权
            if (!authorizeCode.Contains("|"))
            {
                if (!isSNS) authorizeCode = authorizeCode.Substring(0x6);
                return (x16Key == authorizeCode.Split(new[] { '&' })[0x0]);
            }

            //多域名授权
            string[] codes = authorizeCode.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in codes)
            {
                if (string.IsNullOrWhiteSpace(item)) continue;

                if (x16Key == (isSNS
                    ? item.Split(new[] { '&' })[0x0]
                    : item.Substring(0x6).Split(new[] { '&' })[0x0]))
                {
                    return true;
                }
            }
            return false;
        }

        #region 获取顶级域名
        /// <summary>
        /// 域名后缀规则
        /// </summary>
        private const string DOMAIN_RULES =
            "||com.cn|net.cn|org.cn|gov.cn|com.hk|公司|中国|网络|com|net|org|int|edu|gov|mil|arpa|Asia|biz|info|name|pro|coop|aero|museum|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cf|cg|ch|ci|ck|cl|cm|cn|co|cq|cr|cu|cv|cx|cy|cz|de|dj|dk|dm|do|dz|ec|ee|eg|eh|es|et|ev|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gh|gi|gl|gm|gn|gp|gr|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|in|io|iq|ir|is|it|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|ml|mm|mn|mo|mp|mq|mr|ms|mt|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nt|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|pt|pw|py|qa|re|ro|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sk|sl|sm|sn|so|sr|st|su|sy|sz|tc|td|tf|tg|th|tj|tk|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|va|vc|ve|vg|vn|vu|wf|ws|ye|yu|za|zm|zr|zw|";

        /// <summary>
        /// 当前域名
        /// </summary>
        private static string HOST
        {
            get { return HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToLower(); }
        }
        /// <summary>
        /// 获取域名
        /// </summary>
        /// <remarks>如域名是IP此属性值不包括端口号</remarks>
        internal static string Domain
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                return GetDomain(HOST);
            }
        }
        /// <summary>
        /// 解析域名
        /// </summary>
        /// <param name="domain">域名</param>
        /// <returns>如域名是IP此属性值不包括端口号</returns>
        internal static string GetDomain(string domain)
        {
            if (string.IsNullOrWhiteSpace(domain)) return string.Empty;

            if (domain.IndexOf(".") < 1)
            {
                domain = domain.Split(':')[0];
                return domain;
            }

            string[] strArr = domain.Split(':')[0].Split('.');
            if (IsNumeric(strArr[strArr.Length - 1]))
            {
                return domain.Split(':')[0];
            }
            return domain;
        }
        /// <summary>
        /// 获取顶级域名
        /// </summary>
        /// <remarks>如域名是IP此属性值不包括端口号</remarks>
        internal static string TopLevelDomain
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                return GetTopLevelDomain(HOST);
            }
        }
        /// <summary>
        /// 解析顶级域名
        /// </summary>
        /// <param name="domain">域名</param>
        /// <returns>如域名是IP此属性值不包括端口号</returns>
        internal static string GetTopLevelDomain(string domain)
        {
            if (string.IsNullOrWhiteSpace(domain)) return string.Empty;

            if (domain.IndexOf(".") < 1)
            {
                domain = domain.Split(':')[0];
                return domain;
            }

            string[] strArr = domain.Split(':')[0].Split('.');
            if (IsNumeric(strArr[strArr.Length - 1]))
            {
                return domain.Split(':')[0];
            }
            string tempDomain;
            if (strArr.Length >= 4)
            {
                tempDomain = strArr[strArr.Length - 3] + "." + strArr[strArr.Length - 2] + "." +
                             strArr[strArr.Length - 1];
                if (DOMAIN_RULES.IndexOf("|" + tempDomain + "|") > 0)
                {
                    return strArr[strArr.Length - 4] + "." + tempDomain;
                }
            }
            if (strArr.Length >= 3)
            {
                tempDomain = strArr[strArr.Length - 2] + "." + strArr[strArr.Length - 1];
                if (DOMAIN_RULES.IndexOf("|" + tempDomain + "|") > 0)
                {
                    return strArr[strArr.Length - 3] + "." + tempDomain;
                }
            }
            if (strArr.Length >= 2)
            {
                tempDomain = strArr[strArr.Length - 1];
                if (DOMAIN_RULES.IndexOf("|" + tempDomain + "|") > 0)
                {
                    return strArr[strArr.Length - 2] + "." + tempDomain;
                }
            }
            return domain;
        }
        private static bool IsNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            int len = value.Length;
            if ('-' != value[0] && '+' != value[0] && !char.IsNumber(value[0]))
            {
                return false;
            }
            for (int i = 1; i < len; i++)
            {
                if (!char.IsNumber(value[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 密码加密
        /// </summary>
        public static byte[] EncryptPassword(string password)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            if (String.IsNullOrEmpty(password))
            {
                return null;
            }
            byte[] hashBytes = encoding.GetBytes(password);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] cryptPassword = sha1.ComputeHash(hashBytes);
            return cryptPassword;
        }
        #endregion

        #endregion
    }
}
