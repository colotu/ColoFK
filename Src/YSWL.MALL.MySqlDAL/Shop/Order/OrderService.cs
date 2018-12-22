/**
* OrderService.cs
*
* 功 能： Shop模块-订单相关 多表事务操作类
* 类 名： OrderService
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/21 20:11:33  Ben    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using YSWL.Common;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Order;
using YSWL.MALL.Model.Shop.Order;
using System.Data;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Shop.Order
{
    /// <summary>
    /// Shop模块-订单相关 多表事务操作类
    /// </summary>
    public class OrderService : YSWL.MALL.IDAL.Shop.Order.IOrderService    {
        #region 创建订单

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns>主订单Id</returns>
        public long CreateOrder(OrderInfo orderInfo,int depotid=-1, Accounts.Bus.User currentUser = null)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object result;
                    try
                    {
                        //DONE: 1.新增订单
                        result = DbHelperMySQL.GetSingle4Trans(GenerateOrderInfo(orderInfo), transaction);

                        //加载订单主键
                        orderInfo.OrderId = Globals.SafeLong(result, -1);

                        //DONE: 2.新增订单项目
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderItems(orderInfo), transaction);

                        //DONE: 3.新增订单创建记录
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderAction(orderInfo), transaction);

                        //DONE: 4.减少商品SKU库存
                        DbHelperMySQL.ExecuteSqlTran4Indentity(CutSKUStock(orderInfo), transaction);

                        //TODO: 5.增加Shop用户扩展表的订单数 Count+1

                        //DONE: 6.新增已拆单的子订单数据
                        if (orderInfo.SubOrders != null &&
                            orderInfo.SubOrders.Count > 0)
                        {
                            foreach (OrderInfo subOrder in orderInfo.SubOrders)
                            {
                                //加载主订单Id
                                subOrder.ParentOrderId = orderInfo.OrderId;
                                CreateSubOrder(subOrder, transaction);
                            }
                            //TODO: 7.或增加 主订单日志 拆单记录
                        }
                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return orderInfo.OrderId;
        }

        #region 创建子订单(拆单)
        /// <summary>
        /// 创建子订单(拆单)
        /// </summary>
        /// <param name="subInfo">子订单信息</param>
        /// <param name="transaction">主订单事务</param>
        /// <returns>子订单Id</returns>
        public long CreateSubOrder(OrderInfo subInfo, MySqlTransaction transaction)
        {
            object result;

            //DONE: 1.新增订单
            result = DbHelperMySQL.GetSingle4Trans(GenerateOrderInfo(subInfo), transaction);

            //加载子订单主键
            subInfo.OrderId = Globals.SafeLong(result.ToString(), -1);

            //DONE: 2.新增订单项目
            DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderItems(subInfo), transaction);

            //DONE: 3.新增订单拆单记录
            DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderAction(subInfo), transaction);

            return subInfo.OrderId;
        }
        #endregion

        #region UpdateProductStock

        private List<CommandInfo> CutSKUStock(OrderInfo orderInfo)
        {
            List<CommandInfo> listComand = new List<CommandInfo>();
            foreach (Model.Shop.Order.OrderItems item in orderInfo.OrderItems)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Shop_SKUs  set Stock=Stock-?Stock");
                strSql.Append(" where SKU=?SKU");
                MySqlParameter[] parameters =
                        {
                            new MySqlParameter("?SKU", MySqlDbType.VarChar, 50),
                            new MySqlParameter("?Stock", MySqlDbType.Int32, 4)
                        };
                parameters[0].Value = item.SKU;
                parameters[1].Value = item.Quantity;
                listComand.Add(new CommandInfo(strSql.ToString(), parameters));
            }
            return listComand;
        }

        #endregion

        #region GenerateOrderAction

        private List<CommandInfo> GenerateOrderAction(OrderInfo orderInfo)
        {
            System.Text.StringBuilder strSql = new System.Text.StringBuilder();
            strSql.Append("insert into Shop_OrderAction(");
            strSql.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                    new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                    new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                };
            parameters[0].Value = orderInfo.OrderId;
            parameters[1].Value = orderInfo.OrderCode;
            parameters[4].Value = ((int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.Create); //orderInfo.ActionCode;
            parameters[5].Value = DateTime.Now;
            //拆单日志处理
            //if (orderInfo.ParentOrderId == -1)
            //{
            parameters[2].Value = orderInfo.BuyerID;
            parameters[3].Value = "客户";

            parameters[6].Value = "创建订单";
            //}
            //else
            //{
            //    parameters[2].Value = -1;
            //    parameters[3].Value = "系统";
            //    parameters[6].Value = "系统自动拆单";
            //}
            return new List<CommandInfo>
                {
                    new CommandInfo(strSql.ToString(), parameters,
                                    EffentNextType.ExcuteEffectRows)
                };
        }

        #endregion

        #region GenerateOrderItems

        private List<CommandInfo> GenerateOrderItems(OrderInfo orderInfo)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            foreach (Model.Shop.Order.OrderItems model in orderInfo.OrderItems)
            {
                System.Text.StringBuilder strSql = new System.Text.StringBuilder();
                strSql.Append("insert into Shop_OrderItems(");
                strSql.Append(
                    "OrderId,OrderCode,ProductId,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,ShipmentQuantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName,BrandId,BrandName)");
                strSql.Append(" values (");
                strSql.Append(
                    "?OrderId,?OrderCode,?ProductId,?ProductCode,?SKU,?Name,?ThumbnailsUrl,?Description,?Quantity,?ShipmentQuantity,?CostPrice,?SellPrice,?AdjustedPrice,?Attribute,?Remark,?Weight,?Deduct,?Points,?ProductLineId,?SupplierId,?SupplierName,?BrandId,?BrandName)");
                strSql.Append(";select last_insert_id()");

                #region MySqlParameter
                MySqlParameter[] parameters =
                    {
                        new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                        new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                        new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                        new MySqlParameter("?ProductCode", MySqlDbType.VarChar, 50),
                        new MySqlParameter("?SKU", MySqlDbType.VarChar, 200),
                        new MySqlParameter("?Name", MySqlDbType.VarChar, 200),
                        new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarChar, 300),
                        new MySqlParameter("?Description", MySqlDbType.VarChar, 500),
                        new MySqlParameter("?Quantity", MySqlDbType.Int32, 4),
                        new MySqlParameter("?ShipmentQuantity", MySqlDbType.Int32, 4),
                        new MySqlParameter("?CostPrice", MySqlDbType.Decimal, 8),
                        new MySqlParameter("?SellPrice", MySqlDbType.Decimal, 8),
                        new MySqlParameter("?AdjustedPrice", MySqlDbType.Decimal, 8),
                        new MySqlParameter("?Attribute", MySqlDbType.Text),
                        new MySqlParameter("?Remark", MySqlDbType.Text),
                        new MySqlParameter("?Weight", MySqlDbType.Int32, 4),
                        new MySqlParameter("?Deduct", MySqlDbType.Decimal, 8),
                        new MySqlParameter("?Points", MySqlDbType.Int32, 4),
                        new MySqlParameter("?ProductLineId", MySqlDbType.Int32, 4),
                        new MySqlParameter("?SupplierId", MySqlDbType.Int32, 4),
                        new MySqlParameter("?SupplierName", MySqlDbType.VarChar, 100),
                                                new MySqlParameter("?BrandId", MySqlDbType.Int32, 4),
                        new MySqlParameter("?BrandName", MySqlDbType.VarChar, 100)
                    };
                parameters[0].Value = orderInfo.OrderId;
                parameters[1].Value = orderInfo.OrderCode;
                parameters[2].Value = model.ProductId;
                parameters[3].Value = model.ProductCode;
                parameters[4].Value = model.SKU;
                parameters[5].Value = model.Name;
                parameters[6].Value = model.ThumbnailsUrl;
                parameters[7].Value = model.Description;
                parameters[8].Value = model.Quantity;
                parameters[9].Value = model.ShipmentQuantity;
                parameters[10].Value = model.CostPrice;
                parameters[11].Value = model.SellPrice;
                parameters[12].Value = model.AdjustedPrice;
                parameters[13].Value = model.Attribute;
                parameters[14].Value = model.Remark;
                parameters[15].Value = model.Weight;
                parameters[16].Value = model.Deduct;
                parameters[17].Value = model.Points;
                parameters[18].Value = model.ProductLineId;
                parameters[19].Value = model.SupplierId;
                parameters[20].Value = model.SupplierName;
                parameters[21].Value = model.BrandId;
                parameters[22].Value = null;
                #endregion

                list.Add(new CommandInfo(strSql.ToString(),
                                         parameters, EffentNextType.ExcuteEffectRows));
            }
            return list;
        }

        #endregion

        #region GenerateOrderInfo

        public CommandInfo GenerateOrderInfo(OrderInfo model)
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
            return new CommandInfo(strSql.ToString(), parameters);
        }

        #endregion

        #region 自动下架
        public bool AutoSoldOut(OrderInfo orderInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
 UPDATE P
 SET    P.SaleStatus = 0
 FROM   Shop_Products P
 WHERE  P.HasSKU = 0
        AND P.SaleStatus = 1
        AND EXISTS ( SELECT S.ProductId
                     FROM   Shop_SKUs S
                          , Shop_OrderItems O
                     WHERE  O.OrderId = ?OrderId
                            AND S.SKU = O.SKU
                            AND S.ProductId = P.ProductId
                            AND Stock < 1 )
");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?OrderId", MySqlDbType.Int64)
            };
            parameters[0].Value = orderInfo.OrderId;
            return DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters) > 0;
        }
        #endregion

        #endregion

        #region 配货中

        public bool PackingOrder(Model.Shop.Order.OrderInfo orderInfo, Accounts.Bus.User currentUser)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            //更新订单状态
            //DONE: 更新子订单的状态为 已配货
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("UPDATE  Shop_Orders SET ShippingStatus=1, OrderStatus=1, UpdatedDate=?UpdatedDate");
            strSql2.Append(" where OrderId=?OrderId OR ParentOrderId=?OrderId");
            MySqlParameter[] parameters2 =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime)
                };
            parameters2[0].Value = orderInfo.OrderId;
            parameters2[1].Value = DateTime.Now;
            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            //添加操作记录
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into Shop_OrderAction(");
            strSql3.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
            strSql3.Append(" values (");
            strSql3.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
            MySqlParameter[] parameters3 =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                    new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                    new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                };
            parameters3[0].Value = orderInfo.OrderId;
            parameters3[1].Value = orderInfo.OrderCode;
            parameters3[2].Value = currentUser != null ? currentUser.UserID : (orderInfo.SellerID.HasValue ? orderInfo.SellerID.Value : orderInfo.BuyerID);
            parameters3[3].Value = currentUser != null ? currentUser.NickName : (orderInfo.SellerID.HasValue ? orderInfo.SellerName : "系统");
            parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPacking;
            parameters3[5].Value = DateTime.Now;

            //DONE: 要区分 user/admin 取消
            if (currentUser != null)  //TODO: 如果出现另外一种可以操作订单的角色 那么此处就要多加一层判断
            {
                switch (currentUser.UserType)
                {
                    case "AA":
                        parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPacking;
                        break;
                    case "SP":
                        parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SellerPacking;
                        break;
                    case "AG":
                        parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.AgentPacking;
                        break;
                }

            }
            parameters3[6].Value = "配货操作";
            cmd = new CommandInfo(strSql3.ToString(), parameters3, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            return rowsAffected > 0;
        }

        #endregion

        #region 取消订单

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool CancelOrder(OrderInfo orderInfo, Accounts.Bus.User currentUser = null)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            //返回SKU库存
            if (orderInfo.OrderItems != null && orderInfo.OrderItems.Count > 0)
            {
                foreach (Model.Shop.Order.OrderItems item in orderInfo.OrderItems)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update Shop_SKUs  set Stock=Stock+?Stock");
                    strSql.Append(" where SKU=?SKU");
                    MySqlParameter[] parameters =
                        {
                            new MySqlParameter("?SKU", MySqlDbType.VarChar, 50),
                            new MySqlParameter("?Stock", MySqlDbType.Int32, 4)
                        };
                    parameters[0].Value = item.SKU;
                    parameters[1].Value = item.Quantity;
                    sqllist.Add(new CommandInfo(strSql.ToString(), parameters));
                }
            }

            //返回团购库存
            if (orderInfo.GroupBuyId > 0 && orderInfo.GroupBuyStatus == 1)
            {
                foreach (Model.Shop.Order.OrderItems item in orderInfo.OrderItems)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update Shop_GroupBuy set ");
                    strSql.Append("BuyCount=BuyCount-?BuyCount");
                    strSql.Append(" where GroupBuyId =?GroupBuyId ");
                    MySqlParameter[] parameters = {
                    new MySqlParameter("?BuyCount", MySqlDbType.Int32,4),
                        new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4)
                                        };

                    parameters[0].Value = item.Quantity;
                    parameters[1].Value = orderInfo.GroupBuyId;
                    sqllist.Add(new CommandInfo(strSql.ToString(), parameters));
                }
            }
            //返回商品销售数
            //if (orderInfo.OrderStatus == 已支付)
            //{

            //}

            //更新订单状态
            //DONE: 更新子订单的状态为 已取消
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("UPDATE  Shop_Orders SET OrderStatus=-1, UpdatedDate=?UpdatedDate");
            strSql2.Append(" where OrderId=?OrderId OR ParentOrderId=?OrderId");
            MySqlParameter[] parameters2 =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime)
                };
            parameters2[0].Value = orderInfo.OrderId;
            parameters2[1].Value = DateTime.Now;
            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            //添加操作记录
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into Shop_OrderAction(");
            strSql3.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
            strSql3.Append(" values (");
            strSql3.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
            MySqlParameter[] parameters3 =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                    new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                    new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                };
            parameters3[0].Value = orderInfo.OrderId;
            parameters3[1].Value = orderInfo.OrderCode;
            parameters3[2].Value = currentUser != null ? currentUser.UserID : orderInfo.BuyerID;
            parameters3[3].Value = currentUser != null ? currentUser.NickName : orderInfo.BuyerName;
            parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemCancel; //orderInfo.ActionCode;
            parameters3[5].Value = DateTime.Now;

            //DONE: 要区分 user/admin 取消
            if (currentUser != null)  //TODO: 如果出现另外一种可以操作订单的角色 那么此处就要多加一层判断
            {
                switch (currentUser.UserType)
                {
                    case "AA":
                        parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemCancel;
                        break;
                    case "SP":
                        parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SellerCancel;
                        break;
                    case "UU":
                        parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.CustomersCancel;
                        break;
                    case "AG":
                        parameters3[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.AgentCancel;
                        break;
                }

            }
            parameters3[6].Value = "取消订单";
            cmd = new CommandInfo(strSql3.ToString(), parameters3, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            return rowsAffected > 0;
        }

        #endregion

        #region 支付订单

        /// <summary>
        /// 支付订单
        /// </summary>
        public bool PayForOrder(OrderInfo orderInfo, Accounts.Bus.User currentUser = null)
        {
            List<CommandInfo> listCommand = new List<CommandInfo>();
            DateTime updatedDate = DateTime.Now;

            #region 1.更新订单状态为 进行中 - 已支付

            //DONE: 1.更新订单状态为 进行中 - 已支付
            //DONE: 更新子订单的状态为 已支付
            StringBuilder sqlOrders = new StringBuilder();
            sqlOrders.Append("UPDATE  Shop_Orders SET OrderStatus=1, PaymentStatus=2, UpdatedDate=?UpdatedDate");
            sqlOrders.Append(" WHERE OrderId=?OrderId OR ParentOrderId=?OrderId");
            MySqlParameter[] paramOrders =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime)
                };
            paramOrders[0].Value = orderInfo.OrderId;
            paramOrders[1].Value = updatedDate;
            listCommand.Add(new CommandInfo(sqlOrders.ToString(), paramOrders, EffentNextType.ExcuteEffectRows));

            #endregion

            #region 2.新增订单操作记录

            //DONE: 2.新增订单操作记录
            StringBuilder sqlOrderAction = new StringBuilder();
            sqlOrderAction.Append("insert into Shop_OrderAction(");
            sqlOrderAction.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
            sqlOrderAction.Append(" values (");
            sqlOrderAction.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
            MySqlParameter[] paramOrderAction =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                    new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                    new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                };
            paramOrderAction[0].Value = orderInfo.OrderId;
            paramOrderAction[1].Value = orderInfo.OrderCode;
            paramOrderAction[2].Value = currentUser != null ? currentUser.UserID : orderInfo.BuyerID;
            paramOrderAction[3].Value = "系统";
            paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPay;
            //DONE: 要区分 user/admin 支付
            if (currentUser != null)
            {
                switch (currentUser.UserType)
                {
                    case "AA":
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPay;
                        break;
                    case "UU":
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.CustomersPay;
                        break;
                    default:
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPay;
                        break;
                }

            }
            paramOrderAction[5].Value = updatedDate;
            paramOrderAction[6].Value = "支付订单"; //TODO: 需要记录实际操作人
            listCommand.Add(new CommandInfo(sqlOrderAction.ToString(), paramOrderAction, EffentNextType.ExcuteEffectRows));

            #endregion

            //DONE: 3.增加用户扩展表 积分 禁止执行 *)此功能移动到[完成订单]时

            //DONE: 4.新增积分记录 禁止执行 *)此功能移动到[完成订单]时

            #region 5.增加商品销售数
            //DONE: 5.增加商品销售数
            if (orderInfo.OrderItems != null && orderInfo.OrderItems.Count > 0)
            {
                foreach (Model.Shop.Order.OrderItems item in orderInfo.OrderItems)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("update Shop_Products SET SaleCounts=SaleCounts+?Stock");
                    strSql.Append(" where ProductId=?ProductId");
                    MySqlParameter[] parameters =
                        {
                            new MySqlParameter("?ProductId", MySqlDbType.Int64),
                            new MySqlParameter("?Stock", MySqlDbType.Int32, 4)
                        };
                    parameters[0].Value = item.ProductId;
                    parameters[1].Value = item.Quantity;
                    listCommand.Add(new CommandInfo(strSql.ToString(), parameters));
                }
            }
            #endregion

            #region 子单操作
            if (orderInfo.HasChildren && orderInfo.SubOrders.Count > 0)
            {
                foreach (OrderInfo subOrder in orderInfo.SubOrders)
                {
                    #region 子单日志
                    paramOrderAction = new MySqlParameter[]
                    {
                        new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                        new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                        new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                        new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                        new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                        new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                        new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                    };
                    paramOrderAction[0].Value = subOrder.OrderId;
                    paramOrderAction[1].Value = subOrder.OrderCode;
                    paramOrderAction[2].Value = currentUser != null ? currentUser.UserID : orderInfo.BuyerID;
                    paramOrderAction[3].Value = "系统";
                    paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPay;
                    //DONE: 要区分 user/admin 支付
                    if (currentUser != null)
                    {
                        switch (currentUser.UserType)
                        {
                            case "AA":
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPay;
                                break;
                            case "UU":
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.CustomersPay;
                                break;
                            default:
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SystemPay;
                                break;
                        }

                    }
                    paramOrderAction[5].Value = updatedDate;
                    paramOrderAction[6].Value = "支付订单"; //TODO: 需要记录实际操作人
                    listCommand.Add(new CommandInfo(sqlOrderAction.ToString(), paramOrderAction,
                        EffentNextType.ExcuteEffectRows));
                    #endregion

                    #region 子订单卖家操作
                    PayToSupplier(listCommand, updatedDate, subOrder);
                    #endregion
                }
            }
            #endregion
            else
            {
                #region 主订单卖家操作
                PayToSupplier(listCommand, updatedDate, orderInfo);
                #endregion
            }


            return DbHelperMySQL.ExecuteSqlTran(listCommand) > 0;
        }

        #region 卖家操作
        private static void PayToSupplier(List<CommandInfo> listCommand, DateTime updatedDate, OrderInfo orderInfo)
        {
            StringBuilder sqlOrders;
            MySqlParameter[] paramOrders;

            if (orderInfo.SellerID.HasValue &&
                orderInfo.SellerID.Value > 0 &&
                orderInfo.OrderCostPrice.HasValue &&
                orderInfo.OrderCostPrice.Value > 0)
            {
                #region 增加卖家余额

                sqlOrders = new StringBuilder();
                sqlOrders.Append("UPDATE  Accounts_UsersExp SET Balance=Balance+?Balance");
                sqlOrders.Append(" WHERE UserID=?UserID");
                paramOrders = new MySqlParameter[]
                        {
                            new MySqlParameter("?Balance", MySqlDbType.Decimal, 8),
                            new MySqlParameter("?UserID", MySqlDbType.Int32, 4)
                        };
                paramOrders[0].Value = orderInfo.OrderCostPrice.Value;
                paramOrders[1].Value = orderInfo.SellerID.Value;
                listCommand.Add(new CommandInfo(sqlOrders.ToString(), paramOrders,
                    EffentNextType.ExcuteEffectRows));

                #endregion

                #region 增加商家余额 暂未使用

                /**
                         * 商家余额保存到  Accounts_UsersExp 表, 仅商家所有者可以提现.
                         * 不保存到 Shop_Suppliers 表 原因:
                         * 1. 交易记录 UserId 共通模块 无商家Id
                         * 2. 提现流程 UserId 共通模块 无商家Id
                         * 3. Shop v1.9.5 基础上执行最小改动
                         */

                #endregion

                #region 卖家交易(收入)记录

                sqlOrders = new StringBuilder();
                sqlOrders.Append("insert into Pay_BalanceDetails(");
                sqlOrders.Append("UserId,TradeDate,TradeType,Income,Balance,Remark)");
                sqlOrders.Append(" values (");
                //TODO:Sql2005语法兼容性Check BEN ADD 20131202
                sqlOrders.Append(
                    "?UserId,?TradeDate,?TradeType,?Income,(SELECT Balance FROM Accounts_UsersExp WITH (NOLOCK) WHERE UserID = ?UserId),?Remark)");
                paramOrders = new MySqlParameter[]
                        {
                            new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                            new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                            new MySqlParameter("?TradeType", MySqlDbType.Int32, 4),
                            new MySqlParameter("?Income", MySqlDbType.Decimal, 8),
                            new MySqlParameter("?Remark", MySqlDbType.VarChar, 2000)
                        };
                paramOrders[0].Value = orderInfo.SellerID.Value;
                paramOrders[1].Value = updatedDate;
                paramOrders[2].Value = 1;
                paramOrders[3].Value = orderInfo.OrderCostPrice.Value; //收入
                paramOrders[4].Value = string.Format("交易收入 订单号[{0}]", orderInfo.OrderCode); //备注
                listCommand.Add(new CommandInfo(sqlOrders.ToString(), paramOrders,
                    EffentNextType.ExcuteEffectRows));

                #endregion
            }
        }
        #endregion

        #endregion

        #region 完成订单

        public bool CompleteOrder(OrderInfo orderInfo, int userId=-1,string userName="",string userType="AA")
        {

            List<CommandInfo> listCommand = new List<CommandInfo>();
            DateTime updatedDate = DateTime.Now;

            #region 1.更新订单状态为 进行中 - 已支付

            //DONE: 1.更新订单状态为  已完成 - 已支付 - 已确认收货
            //DONE: 更新子订单的状态为 已完成 - 已支付 - 已确认收货
            StringBuilder sqlOrders = new StringBuilder();
            sqlOrders.Append("UPDATE  Shop_Orders SET OrderStatus=2,PaymentStatus=2,ShippingStatus=3, UpdatedDate=?UpdatedDate");
            sqlOrders.Append(" WHERE OrderId=?OrderId OR ParentOrderId=?OrderId");
            MySqlParameter[] paramOrders =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime)
                };
            paramOrders[0].Value = orderInfo.OrderId;
            paramOrders[1].Value = updatedDate;
            listCommand.Add(new CommandInfo(sqlOrders.ToString(), paramOrders, EffentNextType.ExcuteEffectRows));

            #endregion

            #region 2.新增订单操作记录

            //DONE: 2.新增订单操作记录
            StringBuilder sqlOrderAction = new StringBuilder();
            sqlOrderAction.Append("insert into Shop_OrderAction(");
            sqlOrderAction.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
            sqlOrderAction.Append(" values (");
            sqlOrderAction.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
            MySqlParameter[] paramOrderAction =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                    new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                    new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                };
            paramOrderAction[0].Value = orderInfo.OrderId;
            paramOrderAction[1].Value = orderInfo.OrderCode;
            paramOrderAction[2].Value =userId;
            paramOrderAction[3].Value = string.IsNullOrWhiteSpace(userName) ? "System" : userName; ;
            paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SysComplete;
            //DONE: 要区分 user/admin 支付
            if (userId != -1)
            {
                switch (userType)
                {
                    case "AA":
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SysComplete;
                        break;
                    case "AG":
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.AgentComplete;
                        break;
                    case "SP":
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SellerComplete;
                        break;
                    case "UU":
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.Complete;
                        break;
                    default:
                        paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SysComplete;
                        break;
                }
            }
            paramOrderAction[5].Value = updatedDate;
            paramOrderAction[6].Value = "完成订单"; //TODO: 需要记录实际操作人
            listCommand.Add(new CommandInfo(sqlOrderAction.ToString(), paramOrderAction, EffentNextType.ExcuteEffectRows));

            #endregion

            #region 增加积分
            if (orderInfo.OrderPoint > 0)
            {
                #region 3.增加用户扩展表 积分
                //DONE: 3.增加用户扩展表 积分
                //TODO: 如果要[实现购买某件商品获得与商品价格一定比率的积分，比率可以通过配置表配置]功能
                //TODO: 请将[3][4]提取到BLL层执行, 并作积分比率计算
                StringBuilder sqlOrderPoint = new StringBuilder();
                sqlOrderPoint.Append("update Accounts_UsersExp SET ");
                sqlOrderPoint.Append(" Points=Points+?Points ");
                sqlOrderPoint.Append(" WHERE UserID=?UserID ");
                MySqlParameter[] paramOrderPoint =
            {
                new MySqlParameter("?Points", MySqlDbType.Int32, 4),
                new MySqlParameter("?UserID", MySqlDbType.Int32, 4)
            };
                paramOrderPoint[0].Value = orderInfo.OrderPoint;
                paramOrderPoint[1].Value = orderInfo.BuyerID;
                listCommand.Add(new CommandInfo(sqlOrderPoint.ToString(), paramOrderPoint));
                #endregion

                #region 4.新增积分记录
                //DONE: 4.新增积分记录

                StringBuilder sqlPointDetail = new StringBuilder();
                sqlPointDetail.Append("insert into Accounts_PointsDetail(");
                sqlPointDetail.Append("RuleID,UserID,Score,ExtData,CurrentPoints,Description,CreatedDate,Type)");
                sqlPointDetail.Append(" values (");
                sqlPointDetail.Append("?RuleID,?UserID,?Score,?ExtData,0,?Description,?CreatedDate,?Type)");
                MySqlParameter[] paramPointDetail =
            {
                new MySqlParameter("?RuleID", MySqlDbType.Int32, 4),
                new MySqlParameter("?UserID", MySqlDbType.Int32, 4),
                new MySqlParameter("?Score", MySqlDbType.Int32, 4),
                new MySqlParameter("?ExtData", MySqlDbType.VarChar),
                new MySqlParameter("?Description", MySqlDbType.VarChar),
                new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("?Type", MySqlDbType.Int32, 4)
            };
                paramPointDetail[0].Value = (int)YSWL.MALL.Model.Members.Enum.PointRule.Order;
                paramPointDetail[1].Value = orderInfo.BuyerID;
                paramPointDetail[2].Value = orderInfo.OrderPoint;
                paramPointDetail[3].Value = string.Empty;
                paramPointDetail[4].Value = string.Format("[订单完成] 订单号:{0}", orderInfo.OrderCode);
                paramPointDetail[5].Value = updatedDate;
                paramPointDetail[6].Value = 0;
                listCommand.Add(new CommandInfo(sqlPointDetail.ToString(), paramPointDetail));

                #endregion
            }
            #endregion

            #region 5.增加商品销售数 未启用 已在支付流程调用 禁止二次调用
            //DONE: 5.增加商品销售数
            //if (orderInfo.OrderItems != null && orderInfo.OrderItems.Count > 0)
            //{
            //    foreach (Model.Shop.Order.OrderItems item in orderInfo.OrderItems)
            //    {
            //        StringBuilder strSql = new StringBuilder();
            //        strSql.Append("update Shop_Products SET SaleCounts=SaleCounts+?Stock");
            //        strSql.Append(" where ProductId=?ProductId");
            //        MySqlParameter[] parameters =
            //            {
            //                new MySqlParameter("?ProductId", MySqlDbType.Int64),
            //                new MySqlParameter("?Stock", MySqlDbType.Int32, 4)
            //            };
            //        parameters[0].Value = item.ProductId;
            //        parameters[1].Value = item.Quantity;
            //        listCommand.Add(new CommandInfo(strSql.ToString(), parameters));
            //    }
            //}
            #endregion

            #region 子单操作
            if (orderInfo.HasChildren && orderInfo.SubOrders.Count > 0)
            {
                foreach (OrderInfo subOrder in orderInfo.SubOrders)
                {
                    #region 子单日志
                    paramOrderAction = new MySqlParameter[]
                    {
                        new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                        new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                        new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                        new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                        new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                        new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                        new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                    };
                    paramOrderAction[0].Value = subOrder.OrderId;
                    paramOrderAction[1].Value = subOrder.OrderCode;
                    paramOrderAction[2].Value = userId;
                    paramOrderAction[3].Value = string.IsNullOrWhiteSpace(userName) ? "System" : userName; 
                    paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SysComplete;
                    //DONE: 要区分 user/admin 支付
                    if (userId != -1)
                    {
                        switch (userType)
                        {
                            case "AA":
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SysComplete;
                                break;
                            case "AG":
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.AgentComplete;
                                break;
                            case "SP":
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SellerComplete;
                                break;
                            case "UU":
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.Complete;
                                break;
                            default:
                                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.SysComplete;
                                break;
                        }
                    }
                    paramOrderAction[5].Value = updatedDate;
                    paramOrderAction[6].Value = "完成订单"; //TODO: 需要记录实际操作人
                    listCommand.Add(new CommandInfo(sqlOrderAction.ToString(), paramOrderAction,
                        EffentNextType.ExcuteEffectRows));
                    #endregion

                    #region 子订单卖家操作 未启用 已在支付流程调用 禁止二次调用
                    //PayToSupplier(listCommand, updatedDate, subOrder);
                    #endregion
                }
            }
            #endregion
            else
            {
                #region 主订单卖家操作 未启用 已在支付流程调用 禁止二次调用
                //PayToSupplier(listCommand, updatedDate, orderInfo);
                #endregion
            }

            return DbHelperMySQL.ExecuteSqlTran(listCommand) > 0;
        }
        #endregion

        #region 订单统计
        public DataSet Stat4OrderStatus(int orderStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
                @"
SELECT COUNT(*) ToalQuantity
, SUM(O.Amount) ToalPrice
FROM    Shop_Orders O
WHERE   O.OrderStatus = {0} ", orderStatus);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet Stat4OrderStatus(int orderStatus, DateTime startDate, DateTime endDate, int? supplierId = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"select B.ToalPrice,B.ToalQuantity
                                from (select COUNT(*) ToalQuantity,SUM(O.Amount) ToalPrice
                                from Shop_Orders O
                                where O.OrderStatus ={0} and O.CreatedDate BETWEEN '{1}' AND '{2}' 
                                ", orderStatus, startDate, endDate);
            if (supplierId.HasValue && supplierId.Value > 0)
            {
                strSql.AppendFormat("  AND O.SupplierId = {0}", supplierId);
            }
            strSql.AppendFormat(@") B ");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet StatSales(StatisticMode mode, DateTime startDate, DateTime endDate, int? supplierId = null)
        {
            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
            @"
-- 销量/业绩走势图
SELECT  A.GeneratedDate AS GeneratedDate
      , CASE WHEN B.ToalQuantity IS NULL THEN 0
             ELSE B.ToalQuantity
        END AS ToalQuantity
      , CASE WHEN C.ToalPrice IS NULL THEN 0.00
             ELSE C.ToalPrice
        END AS ToalPrice
FROM    ( SELECT    *
          FROM      {0}(@StartDate, ?EndDate)
        ) A
        LEFT JOIN ( SELECT  CONVERT(varchar({1}) , O.CreatedDate, 112 ) GeneratedDate
                          , SUM(I.Quantity) ToalQuantity
                    FROM    Shop_OrderItems I
                          , Shop_Orders O
                    WHERE   I.OrderId = O.OrderId ", method, subLength);
            if (supplierId.HasValue && supplierId.Value > 0)
            {
                strSql.AppendFormat("  AND O.SupplierId = {0}", supplierId);
            }
            strSql.AppendFormat(@" 
                            AND O.PaymentStatus = 2
                            AND O.OrderType = 1
                            AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , O.CreatedDate, 112 )
                  ) B 
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) = B.GeneratedDate
", subLength);
            strSql.AppendFormat(@"LEFT JOIN ( SELECT  CONVERT(varchar({0}) , O.CreatedDate, 112 ) GeneratedDate
                          , SUM(Amount) ToalPrice
                    FROM  Shop_Orders O ", subLength);
            strSql.Append(@" WHERE O.PaymentStatus = 2
                            AND O.OrderType = 1");
            if (supplierId.HasValue && supplierId.Value > 0)
            {
                strSql.AppendFormat("  AND O.SupplierId = {0}", supplierId);
            }
            strSql.AppendFormat(@" AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , O.CreatedDate, 112 )
                  ) C
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) =C.GeneratedDate 
", subLength);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 统计订单数和销售额
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public DataSet StatOrderCountPrice(StatisticMode mode, DateTime startDate, DateTime endDate, int? supplierId = null)
        {
            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
            @"
--订单数和销售额
SELECT  A.GeneratedDate AS GeneratedDate
      , CASE WHEN B.c IS NULL THEN 0
             ELSE B.c
        END AS OrderCount
      , CASE WHEN C.ToalAmount IS NULL THEN 0.00
             ELSE C.ToalAmount
        END AS ToalAmount
FROM    ( SELECT    *
          FROM      {0}(@StartDate, ?EndDate)
        ) A
        LEFT JOIN (  SELECT  CONVERT(varchar({1}) , O.CreatedDate, 112 ) GeneratedDate
                          ,COUNT(1) c
                    FROM  Shop_Orders O
                    WHERE O.PaymentStatus = 2
                            AND O.OrderType = 1 ", method, subLength);
            if (supplierId.HasValue && supplierId.Value > 0)
            {
                strSql.AppendFormat("  AND O.SupplierId = {0}", supplierId);
            }
            strSql.AppendFormat(@" AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , O.CreatedDate, 112 )
                  ) B 
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) = B.GeneratedDate
", subLength);
            strSql.AppendFormat(@"LEFT JOIN ( SELECT  CONVERT(varchar({0}) , O.CreatedDate, 112 ) GeneratedDate
                          , SUM(Amount) ToalAmount
                    FROM  Shop_Orders O ", subLength);
            strSql.Append(@" WHERE O.PaymentStatus = 2
                            AND O.OrderType = 1");
            if (supplierId.HasValue && supplierId.Value > 0)
            {
                strSql.AppendFormat("  AND O.SupplierId = {0}", supplierId);
            }
            strSql.AppendFormat(@" AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , O.CreatedDate, 112 )
                  ) C
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) =C.GeneratedDate 
", subLength);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 订单统计
        /// </summary>
        /// <param name="paymentStatus">支付状态 0 未支付 | 1 等待确认 | 2 已支付 | 3 处理中(预留) | 4 支付异常(预留)</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="referType">来源类型 1：表示PC下单，2：表示微信下单，3：表示业务员待下单</param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public DataSet Stat4OrderStatus(int paymentStatus, DateTime startDate, DateTime endDate, int referType, int? supplierId = null)
        {
            StringBuilder strSql = new StringBuilder();
            string date = "O.CreatedDate";
            //if(paymentStatus==0)
            //{
            //    date = "O.UpdatedDate";
            //}
            strSql.Append("select COUNT(*) ToalQuantity,SUM(O.Amount) ToalPrice  from Shop_Orders O  ");
            strSql.AppendFormat("  where    O.ReferType ={0} and {1} BETWEEN '{2}' AND '{3}'  and  O.OrderType=1 and O.OrderStatus<>-1  ", referType, date, startDate,
                endDate);
            if (paymentStatus >= 0)
            {
                strSql.AppendFormat("  and  O.PaymentStatus ={0}", paymentStatus);
            }
            if (supplierId.HasValue && supplierId.Value > 0)
            {
                strSql.AppendFormat("  AND O.SupplierId = {0}", supplierId);
            }
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 客户活跃统计
        /// </summary>
        /// <param name="paymentStatus">支付状态 0 未支付 | 1 等待确认 | 2 已支付 | 3 处理中(预留) | 4 支付异常(预留)</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="referType">来源类型 1：表示PC下单，2：表示微信下单，3：表示业务员待下单</param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public DataSet ActiveCount(int paymentStatus, DateTime startDate, DateTime endDate, int referType, int? supplierId = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 客户活跃统计--来源类型
        /// </summary>
        /// <param name="paymentStatus">支付状态 -1显示全部| 0 未支付 | 1 等待确认 | 2 已支付 | 3 处理中(预留) | 4 支付异常(预留)</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public DataSet ActiveCountbyType(int paymentStatus, DateTime startDate, DateTime endDate, int? supplierId = null)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region 商品销量
        public DataSet ProductSales(StatisticMode mode, DateTime startDate, DateTime endDate, int supplierId)
        {
            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
            @"
--商品销量
SELECT  A.GeneratedDate AS GeneratedDate
      , CASE WHEN B.ToalQuantity IS NULL THEN 0
             ELSE B.ToalQuantity
        END AS ToalQuantity
FROM    ( SELECT    *
          FROM      {0}(?StartDate, ?EndDate)
        ) A
        LEFT JOIN ( SELECT  CONVERT(varchar({1}) , O.CreatedDate, 112 ) GeneratedDate
                          , SUM(I.Quantity) ToalQuantity
                    FROM    Shop_OrderItems I
                          , Shop_Orders O
                    WHERE   I.OrderId = O.OrderId ", method, subLength);

            if (supplierId > 0)
            {
                strSql.AppendFormat(" and I.SupplierId={0}  ", supplierId);
            }

            strSql.AppendFormat(@" 
                         AND O.OrderType = 1 AND  O.PaymentStatus =2  AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , O.CreatedDate, 112 )
                  ) B 
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) = CONVERT(varchar({0}) , B.GeneratedDate, 112 ) 
", subLength);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        #endregion

        #region 每种商品销量统计
        public DataSet ProductSaleInfo(DateTime startDate, DateTime endDate, int topCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
            @"
--商品销量排行统计列表
SELECT  CASE WHEN B.ProductID IS NULL THEN 0
             ELSE B.ProductID
        END AS Product
      , CASE WHEN B.ToalQuantity IS NULL THEN 0
             ELSE B.ToalQuantity
        END AS ToalQuantity
        ,P.ProductName
FROM    ( SELECT  I.ProductId ProductID
                          , SUM(I.Quantity) ToalQuantity
                    FROM    Shop_OrderItems I
                          , Shop_Orders O
                    WHERE   I.OrderId = O.OrderId ");

            strSql.AppendFormat(@" 
                           AND O.OrderType = 1  AND  O.PaymentStatus =2  AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY I.ProductId
                  ) B 
 INNER JOIN Shop_Products P on P.ProductId = B.ProductID order by ToalQuantity desc
");
            strSql.AppendFormat(" LIMIT {0} ", topCount);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }
        #endregion

        #region 店铺排行统计
        public DataSet ShopSale(StatisticMode mode, DateTime startDate, DateTime endDate)
        {
            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
           @"
--店铺排行走势图
SELECT  A.GeneratedDate AS GeneratedDate
       ,B.SupplierID
       ,CASE WHEN Amount IS NULL THEN 0
             ELSE Amount
        END AS Amount
       ,P.Name
       ,P.ShopName
FROM    ( SELECT    *
          FROM      {0}(?StartDate, ?EndDate)
        ) A
        LEFT JOIN ( SELECT  CONVERT(varchar({1}) , U.CreatedDate, 112 ) GeneratedDate
                          ,sum(SupplierId) SupplierId
                          ,sum(Amount) Amount
                    FROM    Shop_Orders U
                    ", method, subLength);
            strSql.AppendFormat(@" 
                            where U.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                            and SupplierId!=-1
                            GROUP BY CONVERT(varchar({0}) , U.CreatedDate, 112 )
                  ) B 
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) = CONVERT(varchar({0}) , B.GeneratedDate, 112 ) 
left join Shop_Suppliers P on P.SupplierId = B.SupplierId ", subLength);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }
        #endregion

        #region 每种店铺统计
        public DataSet ShopSaleInfo(StatisticMode mode, DateTime startDate, DateTime endDate)
        {
            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
           @"
-- 店铺排行走势图
SELECT B.SupplierID
       ,Amount as Amount
       ,P.Name
       ,P.ShopName 

 FROM  (SELECT  SupplierId ,sum(Amount) Amount
                    FROM    Shop_Orders U
                    ", method, subLength);
            strSql.AppendFormat(@" 
                            where  OrderType = 1 AND  PaymentStatus =2 and  U.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                            and SupplierId!=-1
                            GROUP BY SupplierId
                  ) B 
left join Shop_Suppliers P on P.SupplierId = B.SupplierId order by Amount desc", subLength);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }
        #endregion

        #region 商品销量排行统计

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(StatisticMode mode, DateTime startDate, DateTime endDate, string modes, int startIndex, int endIndex, int supplierId)
        {
            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
            StringBuilder strSql = new StringBuilder();
            //ToDo:优化sql
            strSql.AppendFormat(
            @"
--商品销量排行统计列表
select COUNT(*) from (
select * from (select ROW_NUMBER() over (order by T.ToalQuantity desc,T.GeneratedDate desc) as num,* from (
SELECT  A.GeneratedDate AS GeneratedDate
      , CASE WHEN B.ProductID IS NULL THEN 0
             ELSE B.ProductID
        END AS Product
      , CASE WHEN B.ToalQuantity IS NULL THEN 0
             ELSE B.ToalQuantity
        END AS ToalQuantity
        ,P.ProductName
FROM    ( SELECT    *
          FROM      {0}(?StartDate, ?EndDate)
        ) A
        INNER JOIN ( SELECT  CONVERT(varchar({1}) , O.CreatedDate, 112 ) GeneratedDate
                          , I.ProductId ProductID
                          , SUM(I.Quantity) ToalQuantity
                    FROM    Shop_OrderItems I
                          , Shop_Orders O
                    WHERE   I.OrderId = O.OrderId  ", method, subLength);
            if (supplierId > 0)
            {
                strSql.AppendFormat(" and I.SupplierId={0}  ", supplierId);
            }
            strSql.AppendFormat(@" 
                            AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , O.CreatedDate, 112 ),I.ProductId
                  ) B 
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) = CONVERT(varchar({0}) , B.GeneratedDate, 112 ) 
 INNER JOIN Shop_Products P on P.ProductId = B.ProductID  ) as T )as M)as N 
", subLength);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;
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

        public static YSWL.MALL.ViewModel.Order.OrderInfoExPage DataRowToModel(DataRow row)
        {
            YSWL.MALL.ViewModel.Order.OrderInfoExPage model = new YSWL.MALL.ViewModel.Order.OrderInfoExPage();
            if (row != null)
            {
                if (row["GeneratedDate"] != null && row["GeneratedDate"].ToString() != "")
                {
                    model.GeneratedDate = DateTime.Parse(row["GeneratedDate"].ToString());
                }
                if (row["Product"] != null && row["Product"].ToString() != "")
                {
                    model.Product = int.Parse(row["Product"].ToString());
                }
                if (row["ToalQuantity"] != null && row["ToalQuantity"].ToString() != "")
                {
                    model.ToalQuantity = int.Parse(row["ToalQuantity"].ToString());
                }
                if (row["ProductName"] != null && row["ProductName"].ToString() != "")
                {
                    model.ProductName = row["ProductName"].ToString();
                }
            }
            return model;
        }

        public DataSet GetListByPage(StatisticMode mode, DateTime startDate, DateTime endDate, string modes, int startIndex, int endIndex, int supplierId)
        {
            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
            StringBuilder strSql = new StringBuilder();
            //ToDo:优化sql
            strSql.AppendFormat(
            @"
--商品销量排行统计列表

select * from (select ROW_NUMBER() over (order by T.ToalQuantity desc,T.GeneratedDate desc ) as num,* from (
SELECT  A.GeneratedDate AS GeneratedDate
      , CASE WHEN B.ProductID IS NULL THEN 0
             ELSE B.ProductID
        END AS Product
      , CASE WHEN B.ToalQuantity IS NULL THEN 0
             ELSE B.ToalQuantity
        END AS ToalQuantity
        ,P.ProductName
FROM    ( SELECT    *
          FROM      {0}(?StartDate, ?EndDate)
        ) A
        INNER JOIN ( SELECT  CONVERT(varchar({1}) , O.CreatedDate, 112 ) GeneratedDate
                          , I.ProductId ProductID
                          , SUM(I.Quantity) ToalQuantity
                    FROM    Shop_OrderItems I
                          , Shop_Orders O
                    WHERE   I.OrderId = O.OrderId ", method, subLength);
            if (supplierId > 0)
            {
                strSql.AppendFormat(" and I.SupplierId={0}  ", supplierId);
            }
            strSql.AppendFormat(@" 
                            AND O.CreatedDate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , O.CreatedDate, 112 ),I.ProductId
                  ) B 
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) = CONVERT(varchar({0}) , B.GeneratedDate, 112 ) 
 INNER JOIN Shop_Products P on P.ProductId = B.ProductID  ) as T )as M where M.num between {1} and {2} 
", subLength, startIndex, endIndex);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                new MySqlParameter("?EndDate", MySqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 品牌排行
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="topCount">前几条</param>
        /// <returns></returns>
        public DataSet BrandSaleInfo(DateTime startDate, DateTime endDate, int topCount)
        {
            StringBuilder strSql = new StringBuilder();


            strSql.AppendFormat(
            @"SELECT Br.BrandId,br.BrandName
                   ,CASE WHEN B.AdjustedPrice IS NULL THEN 0
                         ELSE B.AdjustedPrice
                    END AS AdjustedPrice
             FROM  (
             SELECT OI.BrandId ,sum(OI.AdjustedPrice) AdjustedPrice
                            FROM Shop_Orders O,Shop_OrderItems OI
                            where O.OrderId=OI.OrderId and O.OrderType = 1 and O.PaymentStatus=2 and  O.CreatedDate BETWEEN '{0}' AND '{1}' 
                            GROUP BY OI.BrandId
                              ) B 
            inner join dbo.Shop_Brands Br on Br.BrandId=B.BrandId
            order by AdjustedPrice desc  LIMIT {2}", startDate, endDate, topCount);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion

        /// <summary>
        /// 更新订单状态-在途审核
        /// </summary>
        /// <param name="orderInfos"></param>
        /// <param name="shippingStatus"></param>
        /// <param name="orderStatus"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public bool UpdateOrderStatus(List<OrderInfo> orderInfos, YSWL.MALL.Model.Shop.Order.EnumHelper.ShippingStatus shippingStatus,YSWL.MALL.Model.Shop.Order.EnumHelper.OrderStatus orderStatus, Accounts.Bus.User currentUser)
        {
            if (orderInfos.Count <= 0)
            {
                return false;
            }
            List<CommandInfo> listCommand = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            StringBuilder ids = new StringBuilder();
            DateTime updatedDate = DateTime.Now;
            foreach (OrderInfo orderInfo in orderInfos)
            {
                ids.Append(orderInfo.OrderId);
                ids.Append(",");

                #region 新增订单操作记录
                StringBuilder sqlOrderAction = new StringBuilder();
                sqlOrderAction.Append("insert into Shop_OrderAction(");
                sqlOrderAction.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
                sqlOrderAction.Append(" values (");
                sqlOrderAction.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
                MySqlParameter[] paramOrderAction =
                {
                    new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
                    new MySqlParameter("?UserId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
                    new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
                    new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
                };
                paramOrderAction[0].Value = orderInfo.OrderId;
                paramOrderAction[1].Value = orderInfo.OrderCode;
                paramOrderAction[2].Value = currentUser.UserID;
                paramOrderAction[3].Value = currentUser.NickName;
                paramOrderAction[4].Value = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.Shipped;
                paramOrderAction[5].Value = updatedDate;
                paramOrderAction[6].Value = "发货操作";
                listCommand.Add(new CommandInfo(sqlOrderAction.ToString(), paramOrderAction, EffentNextType.ExcuteEffectRows));
                #endregion

            }
            ids.Remove(ids.Length - 1, 1);
            #region 更新订单状态
            strSql.Append("update Shop_Orders set ");
            strSql.Append("OrderStatus=?OrderStatus,");
            strSql.Append("ShippingStatus=?ShippingStatus");
            strSql.AppendFormat(" where OrderId in({0})", ids.ToString());
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?ShippingStatus", MySqlDbType.Int16,2)
                                        };
            parameters[0].Value = (int)shippingStatus;
            parameters[1].Value = (int)orderStatus;
            #endregion
            listCommand.Add(new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows));
            return DBHelper.DefaultDBHelper.ExecuteSqlTran(listCommand) > 0;
        }


        public DataSet ActiveCount(int paymentStatus, DateTime startDate, DateTime endDate, int referType, int? supplierId = null, StatisticMode mode = StatisticMode.Day)
        {
            throw new NotImplementedException();
        }


        public int GetActiveCount(DateTime startDate, DateTime endDate, int referType, int? paymentStatus = null)
        {
            throw new NotImplementedException();
        }


        public DataSet CancleData(string startDate, string endDate, int referType)
        {
            throw new NotImplementedException();
        }

        public DataSet GetNoBindData(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public DataSet GetErrBindData(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public DataSet SalesNewCustoms(DateTime startDay, DateTime endDay)
        {
            throw new NotImplementedException();
        }

        public int GetTotalCustoms(DateTime startDay, DateTime endDay)
        {
            throw new NotImplementedException();
        }

        public DataSet SalesActiveCount(DateTime startDay, DateTime endDay)
        {
            throw new NotImplementedException();
        }

        public DataSet GetSalesCount(int SalesId, string startDay, string endDay)
        {
            throw new NotImplementedException();
        }

        public DataSet GetOrderSales(int SalesId, string startDate, string endDate, int dateType = 0)
        {
            throw new NotImplementedException();
        }

        public DataSet GetShipsCount(int UserId, string startDay, string endDay, int type = 1)
        {
            throw new NotImplementedException();
        }

        public DataSet GetOrderShips(int UserId, string startDate, string endDate, int type = 1)
        {
            throw new NotImplementedException();
        }

        public int GetItemsCount(int UserId, string startDay, string endDay, int type = 1)
        {
            throw new NotImplementedException();
        }

        public DataSet GetItemsList(int UserId, string startDay, string endDay, int type = 1)
        {
            throw new NotImplementedException();
        }

        public DataSet GetPackOrderList(int delayMin, int depotId, bool isOpenMultiDepot)
        {
            throw new NotImplementedException();
        }

        #region OMS 接口操作
        public bool CheckOrder(long orderId, string orderCode, string depotName, int userId, string username)
        {
            throw new NotImplementedException();
        }

        public bool PackingOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        public bool ShipOrder(long orderId, decimal freightAdjusted, decimal freightActual, string shipOrderNumber, string expressCompanyName, string expressCompanyAbb, int depotId, string depotName)
        {
            throw new NotImplementedException();
        }



        public bool CancelOrder(OrderInfo orderInfo, int userId, string userName, int depotId = -1)
        {
            throw new NotImplementedException();
        }


        public bool UpdateRemark(long orderId, string remark)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
