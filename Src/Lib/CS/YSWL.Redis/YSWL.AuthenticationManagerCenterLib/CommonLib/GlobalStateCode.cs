using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.AuthenticationManagerCenterLib.CommonLib
{
    /// <summary>
    /// 全局状态编码
    /// </summary>
    public enum GlobalStateCode
    {
        OK = 200,         //处理成功
        EMPTY = 201,      //数据为空
        WRONGFUL = 202,   //数据不合法
        FROMSOURCEEXCEPTION = 203,    //来源异常或来源不合法
        NODATA = 204,        //不存在对象
        HANDLEXCEPTION = 205,     //处理发生异常
        LOGOUT = 206,             //退出登录

        NULL = 500,  //服务端空引用异常

    }
}
