﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Order;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
using YSWL.MALL.MySqlDAL.Shop.Order;
namespace YSWL.MALL.MySqlDAL.Shop.Order
{
	/// <summary>
	/// 数据访问类:Orders
	/// </summary>
	public partial class Orders:IOrders
	{
		public Orders()
		{}
        private OrderService orderService=new OrderService();
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Orders");
            strSql.Append(" where OrderId=?OrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64)
			};
            parameters[0].Value = OrderId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Order.OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_Orders(");
            strSql.Append("OrderCode,ParentOrderId,CreateUserId,CreatedDate,UpdatedDate,BuyerID,BuyerName,BuyerEmail,BuyerCellPhone,RegionId,ShipRegion,ShipAddress,ShipZipCode,ShipName,ShipTelPhone,ShipCellPhone,ShipEmail,ShippingModeId,ShippingModeName,RealShippingModeId,RealShippingModeName,ShipperId,ShipperName,ShipperAddress,ShipperCellPhone,Freight,FreightAdjusted,FreightActual,Weight,ShippingStatus,ShipOrderNumber,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentTypeName,PaymentGateway,PaymentStatus,RefundStatus,PayCurrencyCode,PayCurrencyName,PaymentFee,PaymentFeeAdjusted,GatewayOrderId,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,OrderOtherCost,OrderOptionPrice,DiscountName,DiscountAmount,DiscountAdjusted,DiscountValue,DiscountValueType,CouponCode,CouponName,CouponAmount,CouponValue,CouponValueType,ActivityName,ActivityFreeAmount,ActivityStatus,GroupBuyId,GroupBuyPrice,GroupBuyStatus,Amount,OrderType,OrderStatus,SellerID,SellerName,SellerEmail,SellerCellPhone,CommentStatus,SupplierId,SupplierName,ReferID,ReferURL,ReferType,OrderIP,Remark,ProductTotal,HasChildren,IsReviews)");
            strSql.Append(" values (");
            strSql.Append("?OrderCode,?ParentOrderId,?CreateUserId,?CreatedDate,?UpdatedDate,?BuyerID,?BuyerName,?BuyerEmail,?BuyerCellPhone,?RegionId,?ShipRegion,?ShipAddress,?ShipZipCode,?ShipName,?ShipTelPhone,?ShipCellPhone,?ShipEmail,?ShippingModeId,?ShippingModeName,?RealShippingModeId,?RealShippingModeName,?ShipperId,?ShipperName,?ShipperAddress,?ShipperCellPhone,?Freight,?FreightAdjusted,?FreightActual,?Weight,?ShippingStatus,?ShipOrderNumber,?ExpressCompanyName,?ExpressCompanyAbb,?PaymentTypeId,?PaymentTypeName,?PaymentGateway,?PaymentStatus,?RefundStatus,?PayCurrencyCode,?PayCurrencyName,?PaymentFee,?PaymentFeeAdjusted,?GatewayOrderId,?OrderTotal,?OrderPoint,?OrderCostPrice,?OrderProfit,?OrderOtherCost,?OrderOptionPrice,?DiscountName,?DiscountAmount,?DiscountAdjusted,?DiscountValue,?DiscountValueType,?CouponCode,?CouponName,?CouponAmount,?CouponValue,?CouponValueType,?ActivityName,?ActivityFreeAmount,?ActivityStatus,?GroupBuyId,?GroupBuyPrice,?GroupBuyStatus,?Amount,?OrderType,?OrderStatus,?SellerID,?SellerName,?SellerEmail,?SellerCellPhone,?CommentStatus,?SupplierId,?SupplierName,?ReferID,?ReferURL,?ReferType,?OrderIP,?Remark,?ProductTotal,?HasChildren,?IsReviews)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?ParentOrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?CreateUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?BuyerID", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyerName", MySqlDbType.VarChar,100),
					new MySqlParameter("?BuyerEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?BuyerCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipRegion", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipAddress", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipZipCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?ShipName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipTelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShippingModeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?RealShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RealShippingModeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipperName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperAddress", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipperCellPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Freight", MySqlDbType.Decimal,8),
					new MySqlParameter("?FreightAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?FreightActual", MySqlDbType.Decimal,8),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?ShippingStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?ShipOrderNumber", MySqlDbType.VarChar,50),
					new MySqlParameter("?ExpressCompanyName", MySqlDbType.VarChar,500),
					new MySqlParameter("?ExpressCompanyAbb", MySqlDbType.VarChar,500),
					new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentTypeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?PaymentGateway", MySqlDbType.VarChar,50),
					new MySqlParameter("?PaymentStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?RefundStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?PayCurrencyCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?PayCurrencyName", MySqlDbType.VarChar,20),
					new MySqlParameter("?PaymentFee", MySqlDbType.Decimal,8),
					new MySqlParameter("?PaymentFeeAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?GatewayOrderId", MySqlDbType.VarChar,100),
					new MySqlParameter("?OrderTotal", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderCostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderProfit", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderOtherCost", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderOptionPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountName", MySqlDbType.VarChar,200),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountValue", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountValueType", MySqlDbType.Int16,2),
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CouponAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponValue", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponValueType", MySqlDbType.Int16,2),
					new MySqlParameter("?ActivityName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ActivityFreeAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?ActivityStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4),
					new MySqlParameter("?GroupBuyPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?GroupBuyStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderType", MySqlDbType.Int16,2),
					new MySqlParameter("?OrderStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?SellerID", MySqlDbType.Int32,4),
					new MySqlParameter("?SellerName", MySqlDbType.VarChar,100),
					new MySqlParameter("?SellerEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?SellerCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?CommentStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ReferID", MySqlDbType.VarChar,50),
					new MySqlParameter("?ReferURL", MySqlDbType.VarChar,200),
					new MySqlParameter("?ReferType", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,2000),
					new MySqlParameter("?ProductTotal", MySqlDbType.Decimal,8),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1),
					new MySqlParameter("?IsReviews", MySqlDbType.Bit,1)};
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.ParentOrderId;
            parameters[2].Value = model.CreateUserId;
            parameters[3].Value = model.CreatedDate;
            parameters[4].Value = model.UpdatedDate;
            parameters[5].Value = model.BuyerID;
            parameters[6].Value = model.BuyerName;
            parameters[7].Value = model.BuyerEmail;
            parameters[8].Value = model.BuyerCellPhone;
            parameters[9].Value = model.RegionId;
            parameters[10].Value = model.ShipRegion;
            parameters[11].Value = model.ShipAddress;
            parameters[12].Value = model.ShipZipCode;
            parameters[13].Value = model.ShipName;
            parameters[14].Value = model.ShipTelPhone;
            parameters[15].Value = model.ShipCellPhone;
            parameters[16].Value = model.ShipEmail;
            parameters[17].Value = model.ShippingModeId;
            parameters[18].Value = model.ShippingModeName;
            parameters[19].Value = model.RealShippingModeId;
            parameters[20].Value = model.RealShippingModeName;
            parameters[21].Value = model.ShipperId;
            parameters[22].Value = model.ShipperName;
            parameters[23].Value = model.ShipperAddress;
            parameters[24].Value = model.ShipperCellPhone;
            parameters[25].Value = model.Freight;
            parameters[26].Value = model.FreightAdjusted;
            parameters[27].Value = model.FreightActual;
            parameters[28].Value = model.Weight;
            parameters[29].Value = model.ShippingStatus;
            parameters[30].Value = model.ShipOrderNumber;
            parameters[31].Value = model.ExpressCompanyName;
            parameters[32].Value = model.ExpressCompanyAbb;
            parameters[33].Value = model.PaymentTypeId;
            parameters[34].Value = model.PaymentTypeName;
            parameters[35].Value = model.PaymentGateway;
            parameters[36].Value = model.PaymentStatus;
            parameters[37].Value = model.RefundStatus;
            parameters[38].Value = model.PayCurrencyCode;
            parameters[39].Value = model.PayCurrencyName;
            parameters[40].Value = model.PaymentFee;
            parameters[41].Value = model.PaymentFeeAdjusted;
            parameters[42].Value = model.GatewayOrderId;
            parameters[43].Value = model.OrderTotal;
            parameters[44].Value = model.OrderPoint;
            parameters[45].Value = model.OrderCostPrice;
            parameters[46].Value = model.OrderProfit;
            parameters[47].Value = model.OrderOtherCost;
            parameters[48].Value = model.OrderOptionPrice;
            parameters[49].Value = model.DiscountName;
            parameters[50].Value = model.DiscountAmount;
            parameters[51].Value = model.DiscountAdjusted;
            parameters[52].Value = model.DiscountValue;
            parameters[53].Value = model.DiscountValueType;
            parameters[54].Value = model.CouponCode;
            parameters[55].Value = model.CouponName;
            parameters[56].Value = model.CouponAmount;
            parameters[57].Value = model.CouponValue;
            parameters[58].Value = model.CouponValueType;
            parameters[59].Value = model.ActivityName;
            parameters[60].Value = model.ActivityFreeAmount;
            parameters[61].Value = model.ActivityStatus;
            parameters[62].Value = model.GroupBuyId;
            parameters[63].Value = model.GroupBuyPrice;
            parameters[64].Value = model.GroupBuyStatus;
            parameters[65].Value = model.Amount;
            parameters[66].Value = model.OrderType;
            parameters[67].Value = model.OrderStatus;
            parameters[68].Value = model.SellerID;
            parameters[69].Value = model.SellerName;
            parameters[70].Value = model.SellerEmail;
            parameters[71].Value = model.SellerCellPhone;
            parameters[72].Value = model.CommentStatus;
            parameters[73].Value = model.SupplierId;
            parameters[74].Value = model.SupplierName;
            parameters[75].Value = model.ReferID;
            parameters[76].Value = model.ReferURL;
            parameters[77].Value = model.ReferType;
            parameters[78].Value = model.OrderIP;
            parameters[79].Value = model.Remark;
            parameters[80].Value = model.ProductTotal;
            parameters[81].Value = model.HasChildren;
            parameters[82].Value = model.IsReviews;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.Order.OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Orders set ");
            strSql.Append("OrderCode=?OrderCode,");
            strSql.Append("ParentOrderId=?ParentOrderId,");
            strSql.Append("CreateUserId=?CreateUserId,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("UpdatedDate=?UpdatedDate,");
            strSql.Append("BuyerID=?BuyerID,");
            strSql.Append("BuyerName=?BuyerName,");
            strSql.Append("BuyerEmail=?BuyerEmail,");
            strSql.Append("BuyerCellPhone=?BuyerCellPhone,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("ShipRegion=?ShipRegion,");
            strSql.Append("ShipAddress=?ShipAddress,");
            strSql.Append("ShipZipCode=?ShipZipCode,");
            strSql.Append("ShipName=?ShipName,");
            strSql.Append("ShipTelPhone=?ShipTelPhone,");
            strSql.Append("ShipCellPhone=?ShipCellPhone,");
            strSql.Append("ShipEmail=?ShipEmail,");
            strSql.Append("ShippingModeId=?ShippingModeId,");
            strSql.Append("ShippingModeName=?ShippingModeName,");
            strSql.Append("RealShippingModeId=?RealShippingModeId,");
            strSql.Append("RealShippingModeName=?RealShippingModeName,");
            strSql.Append("ShipperId=?ShipperId,");
            strSql.Append("ShipperName=?ShipperName,");
            strSql.Append("ShipperAddress=?ShipperAddress,");
            strSql.Append("ShipperCellPhone=?ShipperCellPhone,");
            strSql.Append("Freight=?Freight,");
            strSql.Append("FreightAdjusted=?FreightAdjusted,");
            strSql.Append("FreightActual=?FreightActual,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("ShippingStatus=?ShippingStatus,");
            strSql.Append("ShipOrderNumber=?ShipOrderNumber,");
            strSql.Append("ExpressCompanyName=?ExpressCompanyName,");
            strSql.Append("ExpressCompanyAbb=?ExpressCompanyAbb,");
            strSql.Append("PaymentTypeId=?PaymentTypeId,");
            strSql.Append("PaymentTypeName=?PaymentTypeName,");
            strSql.Append("PaymentGateway=?PaymentGateway,");
            strSql.Append("PaymentStatus=?PaymentStatus,");
            strSql.Append("RefundStatus=?RefundStatus,");
            strSql.Append("PayCurrencyCode=?PayCurrencyCode,");
            strSql.Append("PayCurrencyName=?PayCurrencyName,");
            strSql.Append("PaymentFee=?PaymentFee,");
            strSql.Append("PaymentFeeAdjusted=?PaymentFeeAdjusted,");
            strSql.Append("GatewayOrderId=?GatewayOrderId,");
            strSql.Append("OrderTotal=?OrderTotal,");
            strSql.Append("OrderPoint=?OrderPoint,");
            strSql.Append("OrderCostPrice=?OrderCostPrice,");
            strSql.Append("OrderProfit=?OrderProfit,");
            strSql.Append("OrderOtherCost=?OrderOtherCost,");
            strSql.Append("OrderOptionPrice=?OrderOptionPrice,");
            strSql.Append("DiscountName=?DiscountName,");
            strSql.Append("DiscountAmount=?DiscountAmount,");
            strSql.Append("DiscountAdjusted=?DiscountAdjusted,");
            strSql.Append("DiscountValue=?DiscountValue,");
            strSql.Append("DiscountValueType=?DiscountValueType,");
            strSql.Append("CouponCode=?CouponCode,");
            strSql.Append("CouponName=?CouponName,");
            strSql.Append("CouponAmount=?CouponAmount,");
            strSql.Append("CouponValue=?CouponValue,");
            strSql.Append("CouponValueType=?CouponValueType,");
            strSql.Append("ActivityName=?ActivityName,");
            strSql.Append("ActivityFreeAmount=?ActivityFreeAmount,");
            strSql.Append("ActivityStatus=?ActivityStatus,");
            strSql.Append("GroupBuyId=?GroupBuyId,");
            strSql.Append("GroupBuyPrice=?GroupBuyPrice,");
            strSql.Append("GroupBuyStatus=?GroupBuyStatus,");
            strSql.Append("Amount=?Amount,");
            strSql.Append("OrderType=?OrderType,");
            strSql.Append("OrderStatus=?OrderStatus,");
            strSql.Append("SellerID=?SellerID,");
            strSql.Append("SellerName=?SellerName,");
            strSql.Append("SellerEmail=?SellerEmail,");
            strSql.Append("SellerCellPhone=?SellerCellPhone,");
            strSql.Append("CommentStatus=?CommentStatus,");
            strSql.Append("SupplierId=?SupplierId,");
            strSql.Append("SupplierName=?SupplierName,");
            strSql.Append("ReferID=?ReferID,");
            strSql.Append("ReferURL=?ReferURL,");
            strSql.Append("ReferType=?ReferType,");
            strSql.Append("OrderIP=?OrderIP,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("ProductTotal=?ProductTotal,");
            strSql.Append("HasChildren=?HasChildren,");
            strSql.Append("IsReviews=?IsReviews");
            strSql.Append(" where OrderId=?OrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?ParentOrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?CreateUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?BuyerID", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyerName", MySqlDbType.VarChar,100),
					new MySqlParameter("?BuyerEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?BuyerCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipRegion", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipAddress", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipZipCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?ShipName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipTelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShippingModeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?RealShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RealShippingModeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipperName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperAddress", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipperCellPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Freight", MySqlDbType.Decimal,8),
					new MySqlParameter("?FreightAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?FreightActual", MySqlDbType.Decimal,8),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?ShippingStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?ShipOrderNumber", MySqlDbType.VarChar,50),
					new MySqlParameter("?ExpressCompanyName", MySqlDbType.VarChar,500),
					new MySqlParameter("?ExpressCompanyAbb", MySqlDbType.VarChar,500),
					new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentTypeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?PaymentGateway", MySqlDbType.VarChar,50),
					new MySqlParameter("?PaymentStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?RefundStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?PayCurrencyCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?PayCurrencyName", MySqlDbType.VarChar,20),
					new MySqlParameter("?PaymentFee", MySqlDbType.Decimal,8),
					new MySqlParameter("?PaymentFeeAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?GatewayOrderId", MySqlDbType.VarChar,100),
					new MySqlParameter("?OrderTotal", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderCostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderProfit", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderOtherCost", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderOptionPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountName", MySqlDbType.VarChar,200),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountValue", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountValueType", MySqlDbType.Int16,2),
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CouponAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponValue", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponValueType", MySqlDbType.Int16,2),
					new MySqlParameter("?ActivityName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ActivityFreeAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?ActivityStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4),
					new MySqlParameter("?GroupBuyPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?GroupBuyStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderType", MySqlDbType.Int16,2),
					new MySqlParameter("?OrderStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?SellerID", MySqlDbType.Int32,4),
					new MySqlParameter("?SellerName", MySqlDbType.VarChar,100),
					new MySqlParameter("?SellerEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?SellerCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?CommentStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ReferID", MySqlDbType.VarChar,50),
					new MySqlParameter("?ReferURL", MySqlDbType.VarChar,200),
					new MySqlParameter("?ReferType", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,2000),
					new MySqlParameter("?ProductTotal", MySqlDbType.Decimal,8),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1),
					new MySqlParameter("?IsReviews", MySqlDbType.Bit,1),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.ParentOrderId;
            parameters[2].Value = model.CreateUserId;
            parameters[3].Value = model.CreatedDate;
            parameters[4].Value = model.UpdatedDate;
            parameters[5].Value = model.BuyerID;
            parameters[6].Value = model.BuyerName;
            parameters[7].Value = model.BuyerEmail;
            parameters[8].Value = model.BuyerCellPhone;
            parameters[9].Value = model.RegionId;
            parameters[10].Value = model.ShipRegion;
            parameters[11].Value = model.ShipAddress;
            parameters[12].Value = model.ShipZipCode;
            parameters[13].Value = model.ShipName;
            parameters[14].Value = model.ShipTelPhone;
            parameters[15].Value = model.ShipCellPhone;
            parameters[16].Value = model.ShipEmail;
            parameters[17].Value = model.ShippingModeId;
            parameters[18].Value = model.ShippingModeName;
            parameters[19].Value = model.RealShippingModeId;
            parameters[20].Value = model.RealShippingModeName;
            parameters[21].Value = model.ShipperId;
            parameters[22].Value = model.ShipperName;
            parameters[23].Value = model.ShipperAddress;
            parameters[24].Value = model.ShipperCellPhone;
            parameters[25].Value = model.Freight;
            parameters[26].Value = model.FreightAdjusted;
            parameters[27].Value = model.FreightActual;
            parameters[28].Value = model.Weight;
            parameters[29].Value = model.ShippingStatus;
            parameters[30].Value = model.ShipOrderNumber;
            parameters[31].Value = model.ExpressCompanyName;
            parameters[32].Value = model.ExpressCompanyAbb;
            parameters[33].Value = model.PaymentTypeId;
            parameters[34].Value = model.PaymentTypeName;
            parameters[35].Value = model.PaymentGateway;
            parameters[36].Value = model.PaymentStatus;
            parameters[37].Value = model.RefundStatus;
            parameters[38].Value = model.PayCurrencyCode;
            parameters[39].Value = model.PayCurrencyName;
            parameters[40].Value = model.PaymentFee;
            parameters[41].Value = model.PaymentFeeAdjusted;
            parameters[42].Value = model.GatewayOrderId;
            parameters[43].Value = model.OrderTotal;
            parameters[44].Value = model.OrderPoint;
            parameters[45].Value = model.OrderCostPrice;
            parameters[46].Value = model.OrderProfit;
            parameters[47].Value = model.OrderOtherCost;
            parameters[48].Value = model.OrderOptionPrice;
            parameters[49].Value = model.DiscountName;
            parameters[50].Value = model.DiscountAmount;
            parameters[51].Value = model.DiscountAdjusted;
            parameters[52].Value = model.DiscountValue;
            parameters[53].Value = model.DiscountValueType;
            parameters[54].Value = model.CouponCode;
            parameters[55].Value = model.CouponName;
            parameters[56].Value = model.CouponAmount;
            parameters[57].Value = model.CouponValue;
            parameters[58].Value = model.CouponValueType;
            parameters[59].Value = model.ActivityName;
            parameters[60].Value = model.ActivityFreeAmount;
            parameters[61].Value = model.ActivityStatus;
            parameters[62].Value = model.GroupBuyId;
            parameters[63].Value = model.GroupBuyPrice;
            parameters[64].Value = model.GroupBuyStatus;
            parameters[65].Value = model.Amount;
            parameters[66].Value = model.OrderType;
            parameters[67].Value = model.OrderStatus;
            parameters[68].Value = model.SellerID;
            parameters[69].Value = model.SellerName;
            parameters[70].Value = model.SellerEmail;
            parameters[71].Value = model.SellerCellPhone;
            parameters[72].Value = model.CommentStatus;
            parameters[73].Value = model.SupplierId;
            parameters[74].Value = model.SupplierName;
            parameters[75].Value = model.ReferID;
            parameters[76].Value = model.ReferURL;
            parameters[77].Value = model.ReferType;
            parameters[78].Value = model.OrderIP;
            parameters[79].Value = model.Remark;
            parameters[80].Value = model.ProductTotal;
            parameters[81].Value = model.HasChildren;
            parameters[82].Value = model.IsReviews;
            parameters[83].Value = model.OrderId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long OrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Orders ");
            strSql.Append(" where OrderId=?OrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64)
			};
            parameters[0].Value = OrderId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string OrderIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Orders ");
            strSql.Append(" where OrderId in (" + OrderIdlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Order.OrderInfo GetModel(long OrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  OrderId,OrderCode,ParentOrderId,CreateUserId,CreatedDate,UpdatedDate,BuyerID,BuyerName,BuyerEmail,BuyerCellPhone,RegionId,ShipRegion,ShipAddress,ShipZipCode,ShipName,ShipTelPhone,ShipCellPhone,ShipEmail,ShippingModeId,ShippingModeName,RealShippingModeId,RealShippingModeName,ShipperId,ShipperName,ShipperAddress,ShipperCellPhone,Freight,FreightAdjusted,FreightActual,Weight,ShippingStatus,ShipOrderNumber,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentTypeName,PaymentGateway,PaymentStatus,RefundStatus,PayCurrencyCode,PayCurrencyName,PaymentFee,PaymentFeeAdjusted,GatewayOrderId,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,OrderOtherCost,OrderOptionPrice,DiscountName,DiscountAmount,DiscountAdjusted,DiscountValue,DiscountValueType,CouponCode,CouponName,CouponAmount,CouponValue,CouponValueType,ActivityName,ActivityFreeAmount,ActivityStatus,GroupBuyId,GroupBuyPrice,GroupBuyStatus,Amount,OrderType,OrderStatus,SellerID,SellerName,SellerEmail,SellerCellPhone,CommentStatus,SupplierId,SupplierName,ReferID,ReferURL,ReferType,OrderIP,Remark,ProductTotal,HasChildren,IsReviews from Shop_Orders ");
            strSql.Append(" where OrderId=?OrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64)
			};
            parameters[0].Value = OrderId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Order.OrderInfo model = new YSWL.MALL.Model.Shop.Order.OrderInfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Order.OrderInfo DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Order.OrderInfo model = new YSWL.MALL.Model.Shop.Order.OrderInfo();
            if (row != null)
            {
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = long.Parse(row["OrderId"].ToString());
                }
                if (row["OrderCode"] != null)
                {
                    model.OrderCode = row["OrderCode"].ToString();
                }
                if (row["ParentOrderId"] != null && row["ParentOrderId"].ToString() != "")
                {
                    model.ParentOrderId = long.Parse(row["ParentOrderId"].ToString());
                }
                if (row["CreateUserId"] != null && row["CreateUserId"].ToString() != "")
                {
                    model.CreateUserId = int.Parse(row["CreateUserId"].ToString());
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["UpdatedDate"] != null && row["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(row["UpdatedDate"].ToString());
                }
                if (row["BuyerID"] != null && row["BuyerID"].ToString() != "")
                {
                    model.BuyerID = int.Parse(row["BuyerID"].ToString());
                }
                if (row["BuyerName"] != null)
                {
                    model.BuyerName = row["BuyerName"].ToString();
                }
                if (row["BuyerEmail"] != null)
                {
                    model.BuyerEmail = row["BuyerEmail"].ToString();
                }
                if (row["BuyerCellPhone"] != null)
                {
                    model.BuyerCellPhone = row["BuyerCellPhone"].ToString();
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["ShipRegion"] != null)
                {
                    model.ShipRegion = row["ShipRegion"].ToString();
                }
                if (row["ShipAddress"] != null)
                {
                    model.ShipAddress = row["ShipAddress"].ToString();
                }
                if (row["ShipZipCode"] != null)
                {
                    model.ShipZipCode = row["ShipZipCode"].ToString();
                }
                if (row["ShipName"] != null)
                {
                    model.ShipName = row["ShipName"].ToString();
                }
                if (row["ShipTelPhone"] != null)
                {
                    model.ShipTelPhone = row["ShipTelPhone"].ToString();
                }
                if (row["ShipCellPhone"] != null)
                {
                    model.ShipCellPhone = row["ShipCellPhone"].ToString();
                }
                if (row["ShipEmail"] != null)
                {
                    model.ShipEmail = row["ShipEmail"].ToString();
                }
                if (row["ShippingModeId"] != null && row["ShippingModeId"].ToString() != "")
                {
                    model.ShippingModeId = int.Parse(row["ShippingModeId"].ToString());
                }
                if (row["ShippingModeName"] != null)
                {
                    model.ShippingModeName = row["ShippingModeName"].ToString();
                }
                if (row["RealShippingModeId"] != null && row["RealShippingModeId"].ToString() != "")
                {
                    model.RealShippingModeId = int.Parse(row["RealShippingModeId"].ToString());
                }
                if (row["RealShippingModeName"] != null)
                {
                    model.RealShippingModeName = row["RealShippingModeName"].ToString();
                }
                if (row["ShipperId"] != null && row["ShipperId"].ToString() != "")
                {
                    model.ShipperId = int.Parse(row["ShipperId"].ToString());
                }
                if (row["ShipperName"] != null)
                {
                    model.ShipperName = row["ShipperName"].ToString();
                }
                if (row["ShipperAddress"] != null)
                {
                    model.ShipperAddress = row["ShipperAddress"].ToString();
                }
                if (row["ShipperCellPhone"] != null)
                {
                    model.ShipperCellPhone = row["ShipperCellPhone"].ToString();
                }
                if (row["Freight"] != null && row["Freight"].ToString() != "")
                {
                    model.Freight = decimal.Parse(row["Freight"].ToString());
                }
                if (row["FreightAdjusted"] != null && row["FreightAdjusted"].ToString() != "")
                {
                    model.FreightAdjusted = decimal.Parse(row["FreightAdjusted"].ToString());
                }
                if (row["FreightActual"] != null && row["FreightActual"].ToString() != "")
                {
                    model.FreightActual = decimal.Parse(row["FreightActual"].ToString());
                }
                if (row["Weight"] != null && row["Weight"].ToString() != "")
                {
                    model.Weight = int.Parse(row["Weight"].ToString());
                }
                if (row["ShippingStatus"] != null && row["ShippingStatus"].ToString() != "")
                {
                    model.ShippingStatus = int.Parse(row["ShippingStatus"].ToString());
                }
                if (row["ShipOrderNumber"] != null)
                {
                    model.ShipOrderNumber = row["ShipOrderNumber"].ToString();
                }
                if (row["ExpressCompanyName"] != null)
                {
                    model.ExpressCompanyName = row["ExpressCompanyName"].ToString();
                }
                if (row["ExpressCompanyAbb"] != null)
                {
                    model.ExpressCompanyAbb = row["ExpressCompanyAbb"].ToString();
                }
                if (row["PaymentTypeId"] != null && row["PaymentTypeId"].ToString() != "")
                {
                    model.PaymentTypeId = int.Parse(row["PaymentTypeId"].ToString());
                }
                if (row["PaymentTypeName"] != null)
                {
                    model.PaymentTypeName = row["PaymentTypeName"].ToString();
                }
                if (row["PaymentGateway"] != null)
                {
                    model.PaymentGateway = row["PaymentGateway"].ToString();
                }
                if (row["PaymentStatus"] != null && row["PaymentStatus"].ToString() != "")
                {
                    model.PaymentStatus = int.Parse(row["PaymentStatus"].ToString());
                }
                if (row["RefundStatus"] != null && row["RefundStatus"].ToString() != "")
                {
                    model.RefundStatus = int.Parse(row["RefundStatus"].ToString());
                }
                if (row["PayCurrencyCode"] != null)
                {
                    model.PayCurrencyCode = row["PayCurrencyCode"].ToString();
                }
                if (row["PayCurrencyName"] != null)
                {
                    model.PayCurrencyName = row["PayCurrencyName"].ToString();
                }
                if (row["PaymentFee"] != null && row["PaymentFee"].ToString() != "")
                {
                    model.PaymentFee = decimal.Parse(row["PaymentFee"].ToString());
                }
                if (row["PaymentFeeAdjusted"] != null && row["PaymentFeeAdjusted"].ToString() != "")
                {
                    model.PaymentFeeAdjusted = decimal.Parse(row["PaymentFeeAdjusted"].ToString());
                }
                if (row["GatewayOrderId"] != null)
                {
                    model.GatewayOrderId = row["GatewayOrderId"].ToString();
                }
                if (row["OrderTotal"] != null && row["OrderTotal"].ToString() != "")
                {
                    model.OrderTotal = decimal.Parse(row["OrderTotal"].ToString());
                }
                if (row["OrderPoint"] != null && row["OrderPoint"].ToString() != "")
                {
                    model.OrderPoint = int.Parse(row["OrderPoint"].ToString());
                }
                if (row["OrderCostPrice"] != null && row["OrderCostPrice"].ToString() != "")
                {
                    model.OrderCostPrice = decimal.Parse(row["OrderCostPrice"].ToString());
                }
                if (row["OrderProfit"] != null && row["OrderProfit"].ToString() != "")
                {
                    model.OrderProfit = decimal.Parse(row["OrderProfit"].ToString());
                }
                if (row["OrderOtherCost"] != null && row["OrderOtherCost"].ToString() != "")
                {
                    model.OrderOtherCost = decimal.Parse(row["OrderOtherCost"].ToString());
                }
                if (row["OrderOptionPrice"] != null && row["OrderOptionPrice"].ToString() != "")
                {
                    model.OrderOptionPrice = decimal.Parse(row["OrderOptionPrice"].ToString());
                }
                if (row["DiscountName"] != null)
                {
                    model.DiscountName = row["DiscountName"].ToString();
                }
                if (row["DiscountAmount"] != null && row["DiscountAmount"].ToString() != "")
                {
                    model.DiscountAmount = decimal.Parse(row["DiscountAmount"].ToString());
                }
                if (row["DiscountAdjusted"] != null && row["DiscountAdjusted"].ToString() != "")
                {
                    model.DiscountAdjusted = decimal.Parse(row["DiscountAdjusted"].ToString());
                }
                if (row["DiscountValue"] != null && row["DiscountValue"].ToString() != "")
                {
                    model.DiscountValue = decimal.Parse(row["DiscountValue"].ToString());
                }
                if (row["DiscountValueType"] != null && row["DiscountValueType"].ToString() != "")
                {
                    model.DiscountValueType = int.Parse(row["DiscountValueType"].ToString());
                }
                if (row["CouponCode"] != null)
                {
                    model.CouponCode = row["CouponCode"].ToString();
                }
                if (row["CouponName"] != null)
                {
                    model.CouponName = row["CouponName"].ToString();
                }
                if (row["CouponAmount"] != null && row["CouponAmount"].ToString() != "")
                {
                    model.CouponAmount = decimal.Parse(row["CouponAmount"].ToString());
                }
                if (row["CouponValue"] != null && row["CouponValue"].ToString() != "")
                {
                    model.CouponValue = decimal.Parse(row["CouponValue"].ToString());
                }
                if (row["CouponValueType"] != null && row["CouponValueType"].ToString() != "")
                {
                    model.CouponValueType = int.Parse(row["CouponValueType"].ToString());
                }
                if (row["ActivityName"] != null)
                {
                    model.ActivityName = row["ActivityName"].ToString();
                }
                if (row["ActivityFreeAmount"] != null && row["ActivityFreeAmount"].ToString() != "")
                {
                    model.ActivityFreeAmount = decimal.Parse(row["ActivityFreeAmount"].ToString());
                }
                if (row["ActivityStatus"] != null && row["ActivityStatus"].ToString() != "")
                {
                    model.ActivityStatus = int.Parse(row["ActivityStatus"].ToString());
                }
                if (row["GroupBuyId"] != null && row["GroupBuyId"].ToString() != "")
                {
                    model.GroupBuyId = int.Parse(row["GroupBuyId"].ToString());
                }
                if (row["GroupBuyPrice"] != null && row["GroupBuyPrice"].ToString() != "")
                {
                    model.GroupBuyPrice = decimal.Parse(row["GroupBuyPrice"].ToString());
                }
                if (row["GroupBuyStatus"] != null && row["GroupBuyStatus"].ToString() != "")
                {
                    model.GroupBuyStatus = int.Parse(row["GroupBuyStatus"].ToString());
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["OrderType"] != null && row["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(row["OrderType"].ToString());
                }
                if (row["OrderStatus"] != null && row["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = int.Parse(row["OrderStatus"].ToString());
                }
                if (row["SellerID"] != null && row["SellerID"].ToString() != "")
                {
                    model.SellerID = int.Parse(row["SellerID"].ToString());
                }
                if (row["SellerName"] != null)
                {
                    model.SellerName = row["SellerName"].ToString();
                }
                if (row["SellerEmail"] != null)
                {
                    model.SellerEmail = row["SellerEmail"].ToString();
                }
                if (row["SellerCellPhone"] != null)
                {
                    model.SellerCellPhone = row["SellerCellPhone"].ToString();
                }
                if (row["CommentStatus"] != null && row["CommentStatus"].ToString() != "")
                {
                    model.CommentStatus = int.Parse(row["CommentStatus"].ToString());
                }
                if (row["SupplierId"] != null && row["SupplierId"].ToString() != "")
                {
                    model.SupplierId = int.Parse(row["SupplierId"].ToString());
                }
                if (row["SupplierName"] != null)
                {
                    model.SupplierName = row["SupplierName"].ToString();
                }
                if (row["ReferID"] != null)
                {
                    model.ReferID = row["ReferID"].ToString();
                }
                if (row["ReferURL"] != null)
                {
                    model.ReferURL = row["ReferURL"].ToString();
                }
                if (row["ReferType"] != null && row["ReferType"].ToString() != "")
                {
                    model.ReferType = int.Parse(row["ReferType"].ToString());
                }
                if (row["OrderIP"] != null)
                {
                    model.OrderIP = row["OrderIP"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["ProductTotal"] != null && row["ProductTotal"].ToString() != "")
                {
                    model.ProductTotal = decimal.Parse(row["ProductTotal"].ToString());
                }
                if (row["HasChildren"] != null && row["HasChildren"].ToString() != "")
                {
                    if ((row["HasChildren"].ToString() == "1") || (row["HasChildren"].ToString().ToLower() == "true"))
                    {
                        model.HasChildren = true;
                    }
                    else
                    {
                        model.HasChildren = false;
                    }
                }
                if (row["IsReviews"] != null && row["IsReviews"].ToString() != "")
                {
                    if ((row["IsReviews"].ToString() == "1") || (row["IsReviews"].ToString().ToLower() == "true"))
                    {
                        model.IsReviews = true;
                    }
                    else
                    {
                        model.IsReviews = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderId,OrderCode,ParentOrderId,CreateUserId,CreatedDate,UpdatedDate,BuyerID,BuyerName,BuyerEmail,BuyerCellPhone,RegionId,ShipRegion,ShipAddress,ShipZipCode,ShipName,ShipTelPhone,ShipCellPhone,ShipEmail,ShippingModeId,ShippingModeName,RealShippingModeId,RealShippingModeName,ShipperId,ShipperName,ShipperAddress,ShipperCellPhone,Freight,FreightAdjusted,FreightActual,Weight,ShippingStatus,ShipOrderNumber,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentTypeName,PaymentGateway,PaymentStatus,RefundStatus,PayCurrencyCode,PayCurrencyName,PaymentFee,PaymentFeeAdjusted,GatewayOrderId,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,OrderOtherCost,OrderOptionPrice,DiscountName,DiscountAmount,DiscountAdjusted,DiscountValue,DiscountValueType,CouponCode,CouponName,CouponAmount,CouponValue,CouponValueType,ActivityName,ActivityFreeAmount,ActivityStatus,GroupBuyId,GroupBuyPrice,GroupBuyStatus,Amount,OrderType,OrderStatus,SellerID,SellerName,SellerEmail,SellerCellPhone,CommentStatus,SupplierId,SupplierName,ReferID,ReferURL,ReferType,OrderIP,Remark,ProductTotal,HasChildren,IsReviews ");
            strSql.Append(" FROM Shop_Orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(" OrderId,OrderCode,ParentOrderId,CreateUserId,CreatedDate,UpdatedDate,BuyerID,BuyerName,BuyerEmail,BuyerCellPhone,RegionId,ShipRegion,ShipAddress,ShipZipCode,ShipName,ShipTelPhone,ShipCellPhone,ShipEmail,ShippingModeId,ShippingModeName,RealShippingModeId,RealShippingModeName,ShipperId,ShipperName,ShipperAddress,ShipperCellPhone,Freight,FreightAdjusted,FreightActual,Weight,ShippingStatus,ShipOrderNumber,ExpressCompanyName,ExpressCompanyAbb,PaymentTypeId,PaymentTypeName,PaymentGateway,PaymentStatus,RefundStatus,PayCurrencyCode,PayCurrencyName,PaymentFee,PaymentFeeAdjusted,GatewayOrderId,OrderTotal,OrderPoint,OrderCostPrice,OrderProfit,OrderOtherCost,OrderOptionPrice,DiscountName,DiscountAmount,DiscountAdjusted,DiscountValue,DiscountValueType,CouponCode,CouponName,CouponAmount,CouponValue,CouponValueType,ActivityName,ActivityFreeAmount,ActivityStatus,GroupBuyId,GroupBuyPrice,GroupBuyStatus,Amount,OrderType,OrderStatus,SellerID,SellerName,SellerEmail,SellerCellPhone,CommentStatus,SupplierId,SupplierName,ReferID,ReferURL,ReferType,OrderIP,Remark,ProductTotal,HasChildren,IsReviews ");
            strSql.Append(" FROM Shop_Orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Shop_Orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.* from Shop_Orders T ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.OrderId desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?PageSize", MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Shop_Orders";
            parameters[1].Value = "OrderId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

		#region  ExtensionMethod


        //退货操作
	    public bool ReturnStatus(long orderId)
	    {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            //返回库存

            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("delete SNS_Photo ");
            //strSql.Append(" where PhotoId=?PhotoId");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("?PhotoId", MySqlDbType.Int32,4)
            //};
            //parameters[0].Value = PhotoID;
            //CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            //sqllist.Add(cmd);

            //更新订单状态

            //StringBuilder strSql2 = new StringBuilder();
            //strSql2.Append("delete SNS_Comments ");
            //strSql2.Append(" where type=1 and TargetID=?PhotoId");
            //MySqlParameter[] parameters2 = {
            //        new MySqlParameter("?PhotoId", MySqlDbType.Int32,4)
            //};
            //parameters2[0].Value = PhotoID;
            //cmd = new CommandInfo(strSql2.ToString(), parameters2);
            //sqllist.Add(cmd);
     

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
	    }
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
	    public bool UpdateOrderStatus(long orderId, int status)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Orders set ");
            strSql.Append("OrderStatus=?OrderStatus,");
            strSql.Append(" where OrderId=?OrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8)};
            parameters[0].Value = status;
            parameters[1].Value = orderId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
	    }

        public bool UpdateShipped(YSWL.MALL.Model.Shop.Order.OrderInfo model)
	    {

            List<CommandInfo> sqllist = new List<CommandInfo>();
            #region 更新动作

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Orders set ");
            strSql.Append("OrderCode=?OrderCode,");
            strSql.Append("ParentOrderId=?ParentOrderId,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("UpdatedDate=?UpdatedDate,");
            strSql.Append("BuyerID=?BuyerID,");
            strSql.Append("BuyerName=?BuyerName,");
            strSql.Append("BuyerEmail=?BuyerEmail,");
            strSql.Append("BuyerCellPhone=?BuyerCellPhone,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("ShipRegion=?ShipRegion,");
            strSql.Append("ShipAddress=?ShipAddress,");
            strSql.Append("ShipZipCode=?ShipZipCode,");
            strSql.Append("ShipName=?ShipName,");
            strSql.Append("ShipTelPhone=?ShipTelPhone,");
            strSql.Append("ShipCellPhone=?ShipCellPhone,");
            strSql.Append("ShipEmail=?ShipEmail,");
            strSql.Append("ShippingModeId=?ShippingModeId,");
            strSql.Append("ShippingModeName=?ShippingModeName,");
            strSql.Append("RealShippingModeId=?RealShippingModeId,");
            strSql.Append("RealShippingModeName=?RealShippingModeName,");
            strSql.Append("ShipperId=?ShipperId,");
            strSql.Append("ShipperName=?ShipperName,");
            strSql.Append("ShipperAddress=?ShipperAddress,");
            strSql.Append("ShipperCellPhone=?ShipperCellPhone,");
            strSql.Append("Freight=?Freight,");
            strSql.Append("FreightAdjusted=?FreightAdjusted,");
            strSql.Append("FreightActual=?FreightActual,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("ShippingStatus=?ShippingStatus,");
            strSql.Append("ShipOrderNumber=?ShipOrderNumber,");
            strSql.Append("ExpressCompanyName=?ExpressCompanyName,");
            strSql.Append("ExpressCompanyAbb=?ExpressCompanyAbb,");
            strSql.Append("PaymentTypeId=?PaymentTypeId,");
            strSql.Append("PaymentTypeName=?PaymentTypeName,");
            strSql.Append("PaymentGateway=?PaymentGateway,");
            strSql.Append("PaymentStatus=?PaymentStatus,");
            strSql.Append("RefundStatus=?RefundStatus,");
            strSql.Append("PayCurrencyCode=?PayCurrencyCode,");
            strSql.Append("PayCurrencyName=?PayCurrencyName,");
            strSql.Append("PaymentFee=?PaymentFee,");
            strSql.Append("PaymentFeeAdjusted=?PaymentFeeAdjusted,");
            strSql.Append("GatewayOrderId=?GatewayOrderId,");
            strSql.Append("OrderTotal=?OrderTotal,");
            strSql.Append("OrderPoint=?OrderPoint,");
            strSql.Append("OrderCostPrice=?OrderCostPrice,");
            strSql.Append("OrderProfit=?OrderProfit,");
            strSql.Append("OrderOtherCost=?OrderOtherCost,");
            strSql.Append("OrderOptionPrice=?OrderOptionPrice,");
            strSql.Append("DiscountName=?DiscountName,");
            strSql.Append("DiscountAmount=?DiscountAmount,");
            strSql.Append("DiscountAdjusted=?DiscountAdjusted,");
            strSql.Append("DiscountValue=?DiscountValue,");
            strSql.Append("DiscountValueType=?DiscountValueType,");
            strSql.Append("CouponCode=?CouponCode,");
            strSql.Append("CouponName=?CouponName,");
            strSql.Append("CouponAmount=?CouponAmount,");
            strSql.Append("CouponValue=?CouponValue,");
            strSql.Append("CouponValueType=?CouponValueType,");
            strSql.Append("ActivityName=?ActivityName,");
            strSql.Append("ActivityFreeAmount=?ActivityFreeAmount,");
            strSql.Append("ActivityStatus=?ActivityStatus,");
            strSql.Append("GroupBuyId=?GroupBuyId,");
            strSql.Append("GroupBuyPrice=?GroupBuyPrice,");
            strSql.Append("GroupBuyStatus=?GroupBuyStatus,");
            strSql.Append("Amount=?Amount,");
            strSql.Append("OrderType=?OrderType,");
            strSql.Append("OrderStatus=?OrderStatus,");
            strSql.Append("SellerID=?SellerID,");
            strSql.Append("SellerName=?SellerName,");
            strSql.Append("SellerEmail=?SellerEmail,");
            strSql.Append("SellerCellPhone=?SellerCellPhone,");
            strSql.Append("SupplierId=?SupplierId,");
            strSql.Append("SupplierName=?SupplierName,");
            strSql.Append("ReferID=?ReferID,");
            strSql.Append("ReferURL=?ReferURL,");
            strSql.Append("OrderIP=?OrderIP,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("CommentStatus=?CommentStatus");
            strSql.Append(" where OrderId=?OrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?ParentOrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?BuyerID", MySqlDbType.Int32,4),
					new MySqlParameter("?BuyerName", MySqlDbType.VarChar,100),
					new MySqlParameter("?BuyerEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?BuyerCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipRegion", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipAddress", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipZipCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?ShipName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipTelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ShipEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShippingModeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?RealShippingModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RealShippingModeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipperName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperAddress", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipperCellPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Freight", MySqlDbType.Decimal,8),
					new MySqlParameter("?FreightAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?FreightActual", MySqlDbType.Decimal,8),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?ShippingStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?ShipOrderNumber", MySqlDbType.VarChar,50),
					new MySqlParameter("?ExpressCompanyName", MySqlDbType.VarChar,500),
					new MySqlParameter("?ExpressCompanyAbb", MySqlDbType.VarChar,500),
					new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?PaymentTypeName", MySqlDbType.VarChar,100),
					new MySqlParameter("?PaymentGateway", MySqlDbType.VarChar,50),
					new MySqlParameter("?PaymentStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?RefundStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?PayCurrencyCode", MySqlDbType.VarChar,20),
					new MySqlParameter("?PayCurrencyName", MySqlDbType.VarChar,20),
					new MySqlParameter("?PaymentFee", MySqlDbType.Decimal,8),
					new MySqlParameter("?PaymentFeeAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?GatewayOrderId", MySqlDbType.VarChar,100),
					new MySqlParameter("?OrderTotal", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderCostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderProfit", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderOtherCost", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderOptionPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountName", MySqlDbType.VarChar,200),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountAdjusted", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountValue", MySqlDbType.Decimal,8),
					new MySqlParameter("?DiscountValueType", MySqlDbType.Int16,2),
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CouponAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponValue", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponValueType", MySqlDbType.Int16,2),
					new MySqlParameter("?ActivityName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ActivityFreeAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?ActivityStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4),
					new MySqlParameter("?GroupBuyPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?GroupBuyStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
					new MySqlParameter("?OrderType", MySqlDbType.Int16,2),
					new MySqlParameter("?OrderStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?SellerID", MySqlDbType.Int32,4),
					new MySqlParameter("?SellerName", MySqlDbType.VarChar,100),
					new MySqlParameter("?SellerEmail", MySqlDbType.VarChar,100),
					new MySqlParameter("?SellerCellPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ReferID", MySqlDbType.VarChar,50),
					new MySqlParameter("?ReferURL", MySqlDbType.VarChar,200),
					new MySqlParameter("?OrderIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,2000),
                    new MySqlParameter("?CommentStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.OrderCode;
            parameters[1].Value = model.ParentOrderId;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.UpdatedDate;
            parameters[4].Value = model.BuyerID;
            parameters[5].Value = model.BuyerName;
            parameters[6].Value = model.BuyerEmail;
            parameters[7].Value = model.BuyerCellPhone;
            parameters[8].Value = model.RegionId;
            parameters[9].Value = model.ShipRegion;
            parameters[10].Value = model.ShipAddress;
            parameters[11].Value = model.ShipZipCode;
            parameters[12].Value = model.ShipName;
            parameters[13].Value = model.ShipTelPhone;
            parameters[14].Value = model.ShipCellPhone;
            parameters[15].Value = model.ShipEmail;
            parameters[16].Value = model.ShippingModeId;
            parameters[17].Value = model.ShippingModeName;
            parameters[18].Value = model.RealShippingModeId;
            parameters[19].Value = model.RealShippingModeName;
            parameters[20].Value = model.ShipperId;
            parameters[21].Value = model.ShipperName;
            parameters[22].Value = model.ShipperAddress;
            parameters[23].Value = model.ShipperCellPhone;
            parameters[24].Value = model.Freight;
            parameters[25].Value = model.FreightAdjusted;
            parameters[26].Value = model.FreightActual;
            parameters[27].Value = model.Weight;
            parameters[28].Value = model.ShippingStatus;
            parameters[29].Value = model.ShipOrderNumber;
            parameters[30].Value = model.ExpressCompanyName;
            parameters[31].Value = model.ExpressCompanyAbb;
            parameters[32].Value = model.PaymentTypeId;
            parameters[33].Value = model.PaymentTypeName;
            parameters[34].Value = model.PaymentGateway;
            parameters[35].Value = model.PaymentStatus;
            parameters[36].Value = model.RefundStatus;
            parameters[37].Value = model.PayCurrencyCode;
            parameters[38].Value = model.PayCurrencyName;
            parameters[39].Value = model.PaymentFee;
            parameters[40].Value = model.PaymentFeeAdjusted;
            parameters[41].Value = model.GatewayOrderId;
            parameters[42].Value = model.OrderTotal;
            parameters[43].Value = model.OrderPoint;
            parameters[44].Value = model.OrderCostPrice;
            parameters[45].Value = model.OrderProfit;
            parameters[46].Value = model.OrderOtherCost;
            parameters[47].Value = model.OrderOptionPrice;
            parameters[48].Value = model.DiscountName;
            parameters[49].Value = model.DiscountAmount;
            parameters[50].Value = model.DiscountAdjusted;
            parameters[51].Value = model.DiscountValue;
            parameters[52].Value = model.DiscountValueType;
            parameters[53].Value = model.CouponCode;
            parameters[54].Value = model.CouponName;
            parameters[55].Value = model.CouponAmount;
            parameters[56].Value = model.CouponValue;
            parameters[57].Value = model.CouponValueType;
            parameters[58].Value = model.ActivityName;
            parameters[59].Value = model.ActivityFreeAmount;
            parameters[60].Value = model.ActivityStatus;
            parameters[61].Value = model.GroupBuyId;
            parameters[62].Value = model.GroupBuyPrice;
            parameters[63].Value = model.GroupBuyStatus;
            parameters[64].Value = model.Amount;
            parameters[65].Value = model.OrderType;
            parameters[66].Value = model.OrderStatus;
            parameters[67].Value = model.SellerID;
            parameters[68].Value = model.SellerName;
            parameters[69].Value = model.SellerEmail;
            parameters[70].Value = model.SellerCellPhone;
            parameters[71].Value = model.SupplierId;
            parameters[72].Value = model.SupplierName;
            parameters[73].Value = model.ReferID;
            parameters[74].Value = model.ReferURL;
            parameters[75].Value = model.OrderIP;
            parameters[76].Value = model.Remark;
            parameters[77].Value = model.CommentStatus;
            parameters[78].Value = model.OrderId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql6 = new StringBuilder();
            strSql6.Append("UPDATE Shop_OrderItems SET ShipmentQuantity=Quantity WHERE OrderId =?OrderId ");
            MySqlParameter[] parameters6 = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8)};
            parameters6[0].Value = model.OrderId;
            cmd = new CommandInfo(strSql6.ToString(), parameters6);
            sqllist.Add(cmd);

            #endregion 更新动作

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

	    }

        /// <summary>
        /// 根据条件获取对应的订单状态的数量
        /// </summary>
        /// <param name="userid">下单人 ID</param>
        /// <param name="PaymentStatus">支付状态</param>
        /// <param name="OrderStatusCancel">订单的取消状态</param>
        /// <returns></returns>
        public int GetPaymentStatusCounts(int userid, int PaymentStatus, int OrderStatusCancel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT COUNT(*) FROM  Shop_Orders WHERE BuyerID=?BuyerID AND PaymentStatus=?PaymentStatus AND OrderStatus!=?OrderStatus");
            MySqlParameter[] parameters =
                {
                    new  MySqlParameter("?BuyerID",userid),
                    new MySqlParameter("?PaymentStatus",PaymentStatus),
                    new MySqlParameter("?OrderStatus",OrderStatusCancel)
                };
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新订单备注
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateOrderRemark(long orderId, string Remark,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Orders set ");
            strSql.Append("Remark=?Remark ");
            strSql.Append(" where OrderId=?OrderId ");
            if (!String.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(strWhere);
            }
            MySqlParameter[] parameters = {
					new MySqlParameter("?Remark", MySqlDbType.VarChar,2000),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8)};
            parameters[0].Value = Remark;
            parameters[1].Value = orderId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


      public  YSWL.MALL.Model.Shop.Order.OrderInfo GetOrderInfo(string ordercode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Shop_Orders ");
            strSql.Append(" where OrderCode=?OrderCode");
            strSql.Append(" LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,200)
			};
            parameters[0].Value = ordercode;

            YSWL.MALL.Model.Shop.Order.OrderInfo model = new YSWL.MALL.Model.Shop.Order.OrderInfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 统计业务员的销售以及订单数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
      public DataSet GetSalesStatis(string strWhere)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select  ReferID, SUM(OrderTotal)AS OrderTotal,COUNT(1) AS OrderCount  ");
          strSql.Append(" FROM Shop_Orders T ");
          strSql.Append(" where ReferID>0 and PaymentStatus=2");
          if (strWhere.Trim() != "")
          {
              strSql.Append("  and "+  strWhere);
          }
          strSql.Append(" GROUP BY ReferID ORDER BY OrderTotal Desc" );
          return DbHelperMySQL.Query(strSql.ToString());
      }


      public Decimal GetOrderTotal(string strWhere)
      {
             StringBuilder strSql = new StringBuilder();
          strSql.Append("select    SUM(OrderTotal)   ");
          strSql.Append(" FROM Shop_Orders T ");
          strSql.Append(" where ReferID>0 and PaymentStatus=2");
          if (strWhere.Trim() != "")
          {
              strSql.Append("  and "+  strWhere);
          }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Common.Globals.SafeDecimal(obj,0);
            }
         
      }

      public int GetOrderCount(string strWhere)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select   Count(1)   ");
          strSql.Append(" FROM Shop_Orders T ");
          strSql.Append(" where ReferID>0 and PaymentStatus=2");
          if (strWhere.Trim() != "")
          {
              strSql.Append("  and " + strWhere);
          }
          object obj = DbHelperMySQL.GetSingle(strSql.ToString());
          if (obj == null)
          {
              return 0;
          }
          else
          {
              return Common.Globals.SafeInt(obj, 0);
          }
      }


    public  DataSet GetMySalesStatis( string strWhere)
      {
          StringBuilder strSql = new StringBuilder();
          strSql.Append("select CONVERT(varchar(12) , CreatedDate, 111 )  AS Date  , SUM(OrderTotal)AS OrderTotal,COUNT(1) AS OrderCount  ");
          strSql.Append(" FROM Shop_Orders T ");
          strSql.AppendFormat(" where  PaymentStatus=2");
          if (strWhere.Trim() != "")
          {
              strSql.Append("  and " + strWhere);
          }
          strSql.Append(" GROUP BY CONVERT(varchar(12) , CreatedDate, 111 )  ORDER BY Date ");
          return DbHelperMySQL.Query(strSql.ToString());
      }


    public int GetCustomCount(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("SELECT COUNT(1) FROM (  ");
        strSql.Append("select distinct  BuyerID  FROM  Shop_Orders  ");
        strSql.Append(" where   PaymentStatus=2");
        if (strWhere.Trim() != "")
        {
            strSql.Append("  and " + strWhere);
        }
        strSql.Append(" ) Temp");
        object obj = DbHelperMySQL.GetSingle(strSql.ToString());
        if (obj == null)
        {
            return 0;
        }
        else
        {
            return Common.Globals.SafeInt(obj, 0);
        }
    }
/// <summary>
/// 拆单操作
/// </summary>
/// <param name="mainOrder">主单</param>
/// <returns></returns>
    public long PakingMainOrder(YSWL.MALL.Model.Shop.Order.OrderInfo mainOrder)
        {
        
            long result=0;
                       //循环添加
               string updateSql =
               "Update Shop_Orders set OrderType=?OrderType,HasChildren=?HasChildren where OrderId=?OrderId";
                        using (MySqlConnection connection = DbHelperMySQL.GetConnection)
                        {
                            connection.Open();
                            using (MySqlTransaction transaction = connection.BeginTransaction())
                            {
                                object addresult;
                                try
                                {//平台的单不需要再拆 所以返回的Id只有一个 
                                    foreach (var orderInfo in mainOrder.SubOrders)
                                    {
                                        addresult =
                                            DbHelperMySQL.GetSingle4Trans(orderService.GenerateOrderInfo(orderInfo), transaction);
                                        if (!(orderInfo.SupplierId.HasValue && orderInfo.SupplierId.Value >0)) //商家为平台
                                        {
                                            result = Convert.ToInt64(addresult);
                                        }
                                        foreach (var orderItem in orderInfo.OrderItems)
                                        {
                                            #region Add Order Item
                                            StringBuilder stringAddItem = new StringBuilder();
                                            stringAddItem.Append(" insert into Shop_OrderItems(OrderId,OrderCode,ProductId,ProductCode,SKU,Name,ThumbnailsUrl ,Description,Quantity,ShipmentQuantity,CostPrice,SellPrice      ,AdjustedPrice,Attribute,Remark,Weight,Deduct ,Points,ProductLineId,SupplierId,SupplierName ,BrandId,BrandName)");
                                            stringAddItem.Append(" select s.OrderId,s.OrderCode  ,ProductId,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,ShipmentQuantity,CostPrice,SellPrice,AdjustedPrice,Attribute,t.Remark,t.Weight,Deduct,Points,ProductLineId,t.SupplierId,t.SupplierName,BrandId ,BrandName from Shop_Orders s, Shop_OrderItems t");
                                            stringAddItem.AppendFormat(
                                                    " where s.OrderId={0} and s.ParentOrderId=t.OrderId and t.ProductId={1} ",
                                                    addresult, orderItem.ProductId); 
                                            #endregion
                                            DbHelperMySQL.GetSingle4Trans(new CommandInfo(stringAddItem.ToString(), new MySqlParameter[0]), transaction);
                                        }
                                    }
                                    DbHelperMySQL.GetSingle4Trans(
                                        new CommandInfo(updateSql, UpdateOrderParams(mainOrder)), transaction);
                                    transaction.Commit();
                                }
                                catch (ArgumentNullException)
                                {
                                    transaction.Rollback();
                                    return -1;
                                }
                                catch (SqlException)
                                {
                                    transaction.Rollback();
                                    throw;
                                }
                            }
                        }
                        return result;
        }

        public MySqlParameter[] UpdateOrderParams(YSWL.MALL.Model.Shop.Order.OrderInfo model)
        {
           
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("?OrderType", MySqlDbType.Int32),
                    new MySqlParameter("?HasChildren", MySqlDbType.Bit),
                    new MySqlParameter("?OrderId", MySqlDbType.Int32)
                };
            parameters[0].Value = model.OrderType;
            parameters[1].Value = model.HasChildren;
            parameters[2].Value = model.OrderId;
            return parameters;
        }

        public DataSet GetBrandList(int supplierId)
        {
            string strSql = "select * from Shop_SupplierBrands  where  SupplierId=?SupplierId";     
            MySqlParameter[] parameters = { new MySqlParameter("?SupplierId", MySqlDbType.Int32, 4) };
            parameters[0].Value = supplierId;
            return DbHelperMySQL.Query(strSql, parameters);
        }


        public bool IsFirstOrder(int buyerID)
        {
            throw new NotImplementedException();
        }

        public YSWL.MALL.Model.Shop.Order.OrderInfo GetOrderByCoupon(string coupon)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrderTypeSub(long orderId, int orderTypeSub)
        {
            string strSql = string.Format("update Shop_Orders set orderTypeSub={0} where orderId={1}", orderTypeSub, orderId);
            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  ExtensionMethod


        bool IOrders.Exists(long OrderId)
        {
            throw new NotImplementedException();
        }

        long IOrders.Add(Model.Shop.Order.OrderInfo model)
        {
            throw new NotImplementedException();
        }

        bool IOrders.Update(Model.Shop.Order.OrderInfo model)
        {
            throw new NotImplementedException();
        }

        bool IOrders.Delete(long OrderId)
        {
            throw new NotImplementedException();
        }

        bool IOrders.DeleteList(string OrderIdlist)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Order.OrderInfo IOrders.GetModel(long OrderId)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Order.OrderInfo IOrders.DataRowToModel(DataRow row)
        {
            throw new NotImplementedException();
        }

        DataSet IOrders.GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IOrders.GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        int IOrders.GetRecordCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IOrders.GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        bool IOrders.UpdateOrderStatus(long orderId, int status)
        {
            throw new NotImplementedException();
        }

        bool IOrders.ReturnStatus(long orderId)
        {
            throw new NotImplementedException();
        }

        bool IOrders.UpdateShipped(Model.Shop.Order.OrderInfo orderModel)
        {
            throw new NotImplementedException();
        }

        int IOrders.GetPaymentStatusCounts(int userid, int PaymentStatus, int OrderStatusCancel)
        {
            throw new NotImplementedException();
        }

        bool IOrders.UpdateOrderRemark(long orderId, string Remark, string strWhere)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Order.OrderInfo IOrders.GetOrderInfo(string ordercode)
        {
            throw new NotImplementedException();
        }

        DataSet IOrders.GetSalesStatis(string strWhere)
        {
            throw new NotImplementedException();
        }

        decimal IOrders.GetOrderTotal(string strWhere)
        {
            throw new NotImplementedException();
        }

        int IOrders.GetOrderCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IOrders.GetMySalesStatis(string strWhere)
        {
            throw new NotImplementedException();
        }

        int IOrders.GetCustomCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        long IOrders.PakingMainOrder(Model.Shop.Order.OrderInfo mainOrder)
        {
            throw new NotImplementedException();
        }

        DataSet IOrders.GetBrandList(int supplierId)
        {
            throw new NotImplementedException();
        }

        bool IOrders.IsFirstOrder(int buyerID)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Order.OrderInfo IOrders.GetOrderByCoupon(string coupon)
        {
            throw new NotImplementedException();
        }

        bool IOrders.UpdateOrderTypeSub(long orderId, int orderTypeSub)
        {
            throw new NotImplementedException();
        }

        bool IOrders.IsAllowModify(long OrderId, int ShippingStatus, int OrderStatus)
        {
            throw new NotImplementedException();
        }

	    public int GetUnPaidCounts(int userid)
	    {
            throw new NotImplementedException();
	    }

	    public YSWL.MALL.Model.Shop.Order.OrderInfo GetModel(string orderCode)
	    {
            throw new NotImplementedException();
	    }

        public DataSet GetOrderCountAmount(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public DataSet StatOrderAmount(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public DataSet StatBuyerOrderCountAmount(int top, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public decimal GetUnPaidAmount(int userid)
        {
            throw new NotImplementedException();
        }

        public decimal GetPaidAmount(int userid)
        {
            throw new NotImplementedException();
        }
    }
}

