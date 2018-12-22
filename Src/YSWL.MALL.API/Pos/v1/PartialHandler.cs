using System;
using YSWL.Components.Handlers.API;
using YSWL.Json;
using YSWL.Json.RPC;

namespace YSWL.MALL.API.Pos.v1
{
    public partial class PosHandler
    {
       
        #region 用户登录

        [JsonRpcMethod("HomeIndex", Idempotent = false)]
        [JsonRpcHelp("首页")]
        public JsonObject HomeIndex(int userId)
        {       
            //userId 业务员userId
            JsonObject json=new JsonObject ();
            json.Put("todayOrderCount", _orderManage.GetOrderCount(userId, DateTime.Now));//今日订单数  排除取消订单
            json.Put("todayOrderPrices", _orderManage.GetOrderTotal(userId,DateTime.Now));//今日订单金额  排除取消订单
            json.Put("unShipOrder", _orderManage.GetRecordCount(string.Format("  ReferID='{0}' and  OrderStatus!=-1 and OrderType=1  and   ShippingStatus<2   ", userId)));//未发货订单 
            json.Put("custCount", userManage.GetCustCount(userId));//客户数
            json.Put("todayOrderCust", _orderManage.GetCustomCount(userId,DateTime.Now));//今日下单客户数

            DateTime startTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            json.Put("monthCustRegs", userManage.GetCustCount(userId, startTime,DateTime.Now));//本月注册数
            return new Result(ResultStatus.Success, json);
        }

        #endregion


        #region   获取升级信息
        [JsonRpcMethod("GetUpgradeInfo", Idempotent = false)]
        [JsonRpcHelp("获取升级信息")]
        public JsonObject GetUpgradeInfo()
        {
            JsonObject jsonObject = new JsonObject();
            jsonObject.Put("versionNum", YSWL.Common.ConfigHelper.GetConfigString("App_Sales_VersionNum"));//版本号
            jsonObject.Put("versionDesc", YSWL.Common.ConfigHelper.GetConfigString("App_Sales_VersionDesc"));//版本描述
            jsonObject.Put("versionUrl", YSWL.Common.ConfigHelper.GetConfigString("FilePath_Sales"));  //APP 下载地址
            jsonObject.Put("isEnforce", YSWL.Common.ConfigHelper.GetConfigBool("App_Sales_IsEnforce"));//是否强制升级
            return new Result(ResultStatus.Success, jsonObject);
        }
        #endregion 




//        SELECT * FROM (  
//	SELECT ROW_NUMBER() OVER (order by T. UserId desc )AS Row, T.*  from Accounts_Users T  
//WHERE  UserType='UU' and EmployeeID=17  
//	and  exists (  select  BuyerID  FROM  OMS_Orders O  where   OrderStatus <> -1 AND OrderType =1   and   ReferID='17' AND CreatedDate>='2016/8/4 0:00:00' and  T.UserId=O.BuyerID )
//) TT WHERE TT.Row between 0 and 10
    }
}
