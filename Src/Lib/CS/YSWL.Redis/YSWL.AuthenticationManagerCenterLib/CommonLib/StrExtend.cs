using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.AuthenticationManagerCenterLib.CommonLib
{
    /// <summary>
    /// string的扩展
    /// </summary>
    public static class StrExtend
    {
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="str">判断字符串</param>
        /// <returns>为空返回true，否则返flase</returns>
        public static bool JuadgeIsEmptyAndNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
