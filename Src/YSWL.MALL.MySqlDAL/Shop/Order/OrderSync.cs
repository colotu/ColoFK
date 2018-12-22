/**
* OrderSync.cs
*
* 功 能： Shop模块-订单同步 跨库操作类
* 类 名： OrderSync
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/04/10 16:25:45  Ben    初版
*
* Copyright (c) 2014 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.Common;
using YSWL.DBUtility;
using YSWL.MALL.Model.Shop.Order;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Shop.Order
{
    /// <summary>
    /// Shop模块-订单同步 跨库操作类
    /// </summary>
    public class OrderSync : IDAL.Shop.Order.IOrderSync
    {
        #region 创建订单

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns>主订单Id</returns>
        public long CreateOrder(OrderInfo orderInfo, bool borrowEnable)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object result;
                    try
                    {
                        //TODO: 1.1.判断CDP系统用户是否存在
                        result = DbHelperMySQL.GetSingle4Trans(GenerateExistsUserInfo(orderInfo), transaction);
                        int userId = Globals.SafeInt(result, -1);
                        if (userId < 1) throw new ArgumentException("CDP用户数据不存在");
                        //将CDP系统用户ID 临时写入订单买家
                        orderInfo.BuyerID = userId;

                        //DONE: 1.2.向CDP系统 新增订单主表数据
                        result = DbHelperMySQL.GetSingle4Trans(GenerateOrderInfo(orderInfo), transaction);

                        //加载订单主键
                        orderInfo.OrderId = Globals.SafeLong(result, -1);

                        //DONE: 1.3.向CDP系统 新增订单快照数据
                        DbHelperMySQL.GetSingle4Trans(GenerateOrderInfo(orderInfo, "saleorderbillcopy"), transaction);

                        //DONE: 2.向CDP系统 新增订单项目数据
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderItems(orderInfo, borrowEnable), transaction);

                        //DONE: 3.新增订单同步记录
                        //DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderAction(orderInfo), transaction);

                        //TODO: 4.减少CDP系统商品SKU库存
                        //DbHelperMySQL.ExecuteSqlTran4Indentity(CutSKUStock(orderInfo), transaction);

                        //TODO: 5.增加Shop用户扩展表的订单数 Count+1

                        //TODO: 6.同步已拆单的子订单数据
                        //if (orderInfo.SubOrders != null &&
                        //    orderInfo.SubOrders.Count > 0)
                        //{
                        //    foreach (OrderInfo subOrder in orderInfo.SubOrders)
                        //    {
                        //        //加载主订单Id
                        //        subOrder.ParentOrderId = orderInfo.OrderId;
                        //        CreateSubOrder(subOrder, transaction);
                        //    }
                        //    //TODO: 7.或增加 主订单日志 拆单记录
                        //}
                        transaction.Commit();
                    }
                    catch (ArgumentNullException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (ArgumentException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (NoNullAllowedException)
                    {
                        transaction.Rollback();
                        //空订单忽略, 正常配货
                        return 1;
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

        #region 预留

        //#region 创建子订单(拆单)
        ///// <summary>
        ///// 创建子订单(拆单)
        ///// </summary>
        ///// <param name="subInfo">子订单信息</param>
        ///// <param name="transaction">主订单事务</param>
        ///// <returns>子订单Id</returns>
        //public long CreateSubOrder(OrderInfo subInfo, MySqlTransaction transaction)
        //{
        //    object result;

        //    //DONE: 1.新增订单
        //    result = DbHelperMySQL.GetSingle4Trans(GenerateOrderInfo(subInfo), transaction);

        //    //加载子订单主键
        //    subInfo.OrderId = Globals.SafeLong(result.ToString(), -1);

        //    //DONE: 2.新增订单项目
        //    DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderItems(subInfo), transaction);

        //    //DONE: 3.新增订单拆单记录
        //    DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateOrderAction(subInfo), transaction);

        //    return subInfo.OrderId;
        //}
        //#endregion

        //#region UpdateProductStock

        //private List<CommandInfo> CutSKUStock(OrderInfo orderInfo)
        //{
        //    List<CommandInfo> listComand = new List<CommandInfo>();
        //    foreach (Model.Shop.Order.OrderItems item in orderInfo.OrderItems)
        //    {
        //        StringBuilder strSql = new StringBuilder();
        //        strSql.Append("update Shop_SKUs  set Stock=Stock-?Stock");
        //        strSql.Append(" where SKU=?SKU");
        //        MySqlParameter[] parameters =
        //                {
        //                    new MySqlParameter("?SKU", MySqlDbType.VarChar, 50),
        //                    new MySqlParameter("?Stock", MySqlDbType.Int, 4)
        //                };
        //        parameters[0].Value = item.SKU;
        //        parameters[1].Value = item.Quantity;
        //        listComand.Add(new CommandInfo(strSql.ToString(), parameters));
        //    }
        //    return listComand;
        //}

        //#endregion

        //#region GenerateOrderAction

        //private List<CommandInfo> GenerateOrderAction(OrderInfo orderInfo)
        //{
        //    System.Text.StringBuilder strSql = new System.Text.StringBuilder();
        //    strSql.Append("insert into Shop_OrderAction(");
        //    strSql.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
        //    strSql.Append(" values (");
        //    strSql.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
        //    MySqlParameter[] parameters =
        //        {
        //            new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
        //            new MySqlParameter("?OrderCode", MySqlDbType.VarChar, 50),
        //            new MySqlParameter("?UserId", MySqlDbType.Int, 4),
        //            new MySqlParameter("?Username", MySqlDbType.VarChar, 200),
        //            new MySqlParameter("?ActionCode", MySqlDbType.VarChar, 100),
        //            new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
        //            new MySqlParameter("?Remark", MySqlDbType.VarChar, 1000)
        //        };
        //    parameters[0].Value = orderInfo.OrderId;
        //    parameters[1].Value = orderInfo.OrderCode;
        //    parameters[4].Value = ((int)YSWL.MALL.Model.Shop.Order.EnumHelper.ActionCode.CustomersCreateOrder); //orderInfo.ActionCode;
        //    parameters[5].Value = DateTime.Now;
        //    //拆单日志处理
        //    //if (orderInfo.ParentOrderId == -1)
        //    //{
        //    parameters[2].Value = orderInfo.BuyerID;
        //    parameters[3].Value = "客户";

        //    parameters[6].Value = "创建订单";
        //    //}
        //    //else
        //    //{
        //    //    parameters[2].Value = -1;
        //    //    parameters[3].Value = "系统";
        //    //    parameters[6].Value = "系统自动拆单";
        //    //}
        //    return new List<CommandInfo>
        //        {
        //            new CommandInfo(strSql.ToString(), parameters,
        //                            EffentNextType.ExcuteEffectRows)
        //        };
        //}

        //#endregion

        #endregion

        #region GenerateOrderItems

        private List<CommandInfo> GenerateOrderItems(OrderInfo orderInfo, bool borrowEnable)
        {
            if (orderInfo.OrderItems == null || orderInfo.OrderItems.Count < 1)
            {
                throw new ArgumentException("订单项不存在");
            }
            List<CommandInfo> listCommand = new List<CommandInfo>();
            //超卖商品集合
            List<Model.Shop.Order.OrderItems> listOversoldItem = new List<Model.Shop.Order.OrderItems>();
            int itemCount = 0;
            foreach (Model.Shop.Order.OrderItems model in orderInfo.OrderItems)
            {
                List<GoodsBatch> listGoodsBatch = new List<GoodsBatch>();

                //是否是赠品
                if (model.ProductType == 2)
                {
                    model.SKU = model.SKU.Replace("_G", "");
                    listGoodsBatch = GetBatchsInfomation(
                        model.Quantity, orderInfo.BuyerID,
                        model.SKU, borrowEnable, true
                        );
                }
                else
                {
                    listGoodsBatch = GetBatchsInfomation(
                        model.Quantity, orderInfo.BuyerID,
                        model.SKU, borrowEnable, false
                        );
                }

                if (null == listGoodsBatch || listGoodsBatch.Count < 1)
                {
                    //DONE: 全部无库存 加入超卖商品集合
                    listOversoldItem.Add(model);
                    continue;
                }
                itemCount++;
                int batchQuantity = 0;
                foreach (GoodsBatch goodsBatch in listGoodsBatch)
                {
                    System.Text.StringBuilder strSql = new System.Text.StringBuilder();
                    strSql.Append(" insert into saleorderbilldetail(");
                    strSql.Append(
                        "`profit`, `batchMoney`, `batchNum`, `batchPrice`, `store_id`, `billCode`, `costMoney`, `costOperateWay`, `costPrice`, `expiryDate`, `money`, `piecePrice`, `pieceQty`, `price`, `qty`, `qtyOfPackage`, `scatteredQty`, `specification`, `tradePrice`, `unit`, `bill_id`, `goods_id`, `saleType`, `blSolutionGroupFirst`, `solutionGroupId`, `solutionMultiple`, `solutionPieceQty`, `solutionQty`, `solutionScatteredQty`, `blBorrow`)");
                    strSql.Append(" select ");
                    if (model.ProductType == 2)
                    {
                        //赠品 计入散数
                        strSql.Append(
                        "?Profit,?BatchMoney,?BatchNum,?BatchPrice,?StoreId,?CdpOrderCode,?BatchMoney, 'wayAVG',?BatchPrice, ?expiryDate, ?AdjustedPrice, ?SellPrice, 0, ?SellPrice/c.qtyOfPackage, ?Quantity, c.qtyOfPackage,?Quantity, c.specification, '0', c.unit, b.id, c.id,  '0', '', '无分组', '1', '0', '0', '0', 0  ");
                    }
                    else
                    {
                        //正常购买商品 计入件数
                        strSql.Append(
                        "?Profit,?BatchMoney,?BatchNum,?BatchPrice,?StoreId,?CdpOrderCode,?BatchMoney, 'wayAVG',?BatchPrice, ?expiryDate, ?AdjustedPrice, ?SellPrice, ?Quantity, ?SellPrice/c.qtyOfPackage, ?Quantity*c.qtyOfPackage, c.qtyOfPackage, 0, c.specification, '0', c.unit, b.id, c.id,  '0', '', '无分组', '1', '0', '0', '0', 0  ");
                    }
                    strSql.Append(
                        "from saleorderbill b,goods c where b.billcode=?CdpOrderCode and c.code=?SKU; ");

                    #region 向ordernooutdetail表中插入数据

                    strSql.Append(" insert into ordernooutdetail(");
                    strSql.Append("`batchNum`,`billCode`,`billId`,`billType`,`goodsId`,`qty`,`storeId`)");
                    strSql.Append(" select ");
                    strSql.Append("?BatchNum,?CdpOrderCode,b.id,'BZH',c.id,?Qty,?StoreId  ");
                    strSql.Append("from saleorderbill b,goods c where b.billcode=?CdpOrderCode and c.code=?SKU;");

                    #endregion

                    #region MySqlParameter

                    MySqlParameter[] parameters =
                    {
                        new MySqlParameter("?BatchNum", MySqlDbType.String),
                        new MySqlParameter("?CdpOrderCode", MySqlDbType.String),
                        new MySqlParameter("?SKU", MySqlDbType.String, 200),
                        new MySqlParameter("?Quantity", MySqlDbType.Int32),
                        new MySqlParameter("?SellPrice", MySqlDbType.Double),
                        new MySqlParameter("?AdjustedPrice", MySqlDbType.Double),
                        new MySqlParameter("?StoreId", MySqlDbType.Int32),
                        new MySqlParameter("?Qty", MySqlDbType.Int32),
                        new MySqlParameter("?BatchMoney", MySqlDbType.Double),
                        new MySqlParameter("?BatchPrice", MySqlDbType.Double),
                        new MySqlParameter("?Profit", MySqlDbType.Double),
                        new MySqlParameter("?expiryDate", MySqlDbType.Date)
                    };
                    long goodsTotalQty = goodsBatch.Quantity * goodsBatch.QtyPackage;
                    parameters[0].Value = goodsBatch.BatchNum; //批次号
                    parameters[1].Value = orderInfo.OrderCode;
                    parameters[2].Value = model.SKU;
                    parameters[3].Value = goodsBatch.Quantity; //订单中的数量
                    parameters[4].Value = model.AdjustedPrice;
                    parameters[5].Value = model.AdjustedPrice * goodsBatch.Quantity;
                    parameters[6].Value = goodsBatch.StoreId;
                    parameters[7].Value = goodsTotalQty; //批次号中购买的数量
                    parameters[8].Value = goodsBatch.BatchPrice * goodsTotalQty;
                    parameters[9].Value = goodsBatch.BatchPrice;
                    parameters[10].Value = ((double)model.AdjustedPrice * goodsBatch.Quantity) -
                                           (goodsBatch.BatchPrice * goodsTotalQty);
                    parameters[11].Value = goodsBatch.ExpiryDate;


                    #endregion

                    batchQuantity += goodsBatch.Quantity;

                    listCommand.Add(new CommandInfo(strSql.ToString(),
                        parameters, EffentNextType.ExcuteEffectRows));
                }
                if (batchQuantity < model.Quantity)
                {
                    model.Quantity -= batchQuantity;
                    //DONE: 部分库存不足 加入超卖商品集合
                    listOversoldItem.Add(model);
                }
            }

            if (listOversoldItem.Count > 0)
            {
                //检测并识别赠品, 如赠品不足, 终止超卖流程
                List<Model.Shop.Order.OrderItems> giftList = listOversoldItem.FindAll(xx => xx.ProductType == 2);
                //启用超卖功能
                if (giftList.Count == 0 && borrowEnable)
                {
                    //DONE: 超卖商品集合转换为借库订单
                    GenerateOversoldOrder(orderInfo, listOversoldItem);
                }
                else
                {
                    string tmp = "";
                    listOversoldItem.ForEach(xx => tmp += "|" + xx.SKU);
                    throw new ArgumentException("商品库存不足:" + tmp);
                }
            }
            //空订单 回滚事务
            if (itemCount < 1)
            {
                throw new NoNullAllowedException("检测到空订单");
            }
            return listCommand;
        }

        /// <summary>
        /// 超卖商品集合生成借库订单
        /// </summary>
        private void GenerateOversoldOrder(OrderInfo orderInfo,
            List<Model.Shop.Order.OrderItems> listOversoldItem)
        {
            if (listOversoldItem == null || listOversoldItem.Count < 1)
            {
                return;
            }
            using (MySqlConnection connection = new MySqlConnection(DbHelperMySQL.connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object result;
                    try
                    {
                        List<CommandInfo> listCommand = new List<CommandInfo>();
                        //根据订单重新构造借库单
                        orderInfo = new OrderInfo(orderInfo);
                        orderInfo.OrderCode = orderInfo.OrderCode + "C";

                        #region Reset 重量/运费/积分/价格/优惠卷

                        orderInfo.Weight = 0;
                        orderInfo.FreightAdjusted =
                            orderInfo.FreightActual =
                            orderInfo.Freight = 0;
                        orderInfo.OrderPoint = 0;

                        orderInfo.ProductTotal = 0;
                        orderInfo.OrderCostPrice = 0;
                        orderInfo.OrderOptionPrice = 0;
                        orderInfo.OrderProfit = 0;
                        orderInfo.Amount = 0;

                        #region 清空限时抢购
                        orderInfo.ActivityName = null;
                        orderInfo.ActivityFreeAmount = null;
                        orderInfo.ActivityStatus = 0;
                        #endregion

                        #region 清空团购数据
                        orderInfo.GroupBuyId = null;
                        orderInfo.GroupBuyPrice = null;
                        orderInfo.GroupBuyStatus = 0;
                        #endregion

                        #region 清空优惠卷数据
                        orderInfo.CouponAmount = null;
                        orderInfo.CouponCode = null;
                        orderInfo.CouponName = null;
                        orderInfo.CouponValue = null;
                        orderInfo.CouponValueType = null;
                        #endregion
                        #endregion

                        #region 重新计算 重量/积分/价格
                        listOversoldItem.ForEach(info =>
                        {
                            info.OrderCode = orderInfo.OrderCode;
                            orderInfo.Weight += info.Weight * info.Quantity;
                            orderInfo.OrderPoint += info.Points * info.Quantity;
                            //订单商品总价(无优惠)
                            orderInfo.ProductTotal += info.SellPrice * info.Quantity;
                            //订单总成本价 = 项目总成本价
                            orderInfo.OrderCostPrice += info.CostPrice * info.Quantity;
                            //订单最终支付金额 = 商品总价
                            orderInfo.Amount += info.AdjustedPrice * info.Quantity;
                        });
                        //借库订单运费为零
                        orderInfo.FreightAdjusted =
                         orderInfo.FreightActual =
                         orderInfo.Freight = 0;
                        //订单总金额(含优惠) 商品总价 + 运费
                        orderInfo.OrderTotal = orderInfo.ProductTotal + orderInfo.Freight.Value;
                        //订单最终支付金额 = 商品总价(含优惠) + 调整后运费
                        orderInfo.Amount += orderInfo.FreightAdjusted.Value;
                        #endregion

                        result = DbHelperMySQL.GetSingle4Trans(GenerateOrderInfo(orderInfo, "saleorderbill", "BJP"), transaction);
                        //加载订单主键
                        orderInfo.OrderId = Globals.SafeLong(result, -1);

                        foreach (Model.Shop.Order.OrderItems item in listOversoldItem)
                        {
                            System.Text.StringBuilder strSql = new System.Text.StringBuilder();
                            //strSql.Append(" insert into saleorderbilldetail(");
                            //strSql.Append(
                            //    " `store_id`,`billCode`, `costOperateWay`, `expiryDate`, `money`, `piecePrice`, `pieceQty`, `price`, `qty`, `qtyOfPackage`, `specification`, `tradePrice`, `unit`, `bill_id`, `goods_id`, `saleType`, `blSolutionGroupFirst`, `solutionGroupId`, `solutionMultiple`, `solutionPieceQty`, `solutionQty`, `solutionScatteredQty`, `blBorrow`)");
                            //strSql.Append(" select ");
                            //strSql.Append(
                            //    "88,?CdpOrderCode, 'wayAVG', b.makedate, ?AdjustedPrice, ?SellPrice, ?Quantity, ?SellPrice/c.qtyOfPackage, ?Quantity*c.qtyOfPackage, c.qtyOfPackage, c.specification, '0', c.unit, b.id, c.id,  '0', '', '无分组', '1', '0', '0', '0', 0  ");
                            //strSql.Append(
                            //    "from saleorderbill b,goods c where b.billcode=?CdpOrderCode and c.code=?SKU; ");

                            //#region MySqlParameter

                            //MySqlParameter[] parameters =
                            //{
                            //    new MySqlParameter("?CdpOrderCode", MySqlDbType.String),
                            //    new MySqlParameter("?SKU", MySqlDbType.String, 200),
                            //    new MySqlParameter("?Quantity", MySqlDbType.Int32),
                            //    new MySqlParameter("?SellPrice", MySqlDbType.Double),
                            //    new MySqlParameter("?AdjustedPrice", MySqlDbType.Double)
                            //};
                            //parameters[0].Value = orderInfo.OrderCode;
                            //parameters[1].Value = item.SKU;
                            //parameters[2].Value = item.Quantity;
                            //parameters[3].Value = item.AdjustedPrice;
                            //parameters[4].Value = item.AdjustedPrice * item.Quantity;
                            //#endregion

                            strSql.Append(" insert into saleorderbilldetail(");
                            strSql.Append(
                                "`store_id`, `billCode`, `costOperateWay`, `money`, `piecePrice`, `pieceQty`, `price`, `qty`, `qtyOfPackage`, `specification`, `tradePrice`, `unit`, `bill_id`, `goods_id`, `saleType`, `blSolutionGroupFirst`, `solutionGroupId`, `solutionMultiple`, `solutionPieceQty`, `solutionQty`, `solutionScatteredQty`, `blBorrow`)");
                            strSql.Append(" select ");
                            strSql.Append(
                                "90,?CdpOrderCode, 'wayAVG', ?AdjustedPrice, ?SellPrice, ?Quantity, ?SellPrice/c.qtyOfPackage, ?Quantity*c.qtyOfPackage, c.qtyOfPackage, c.specification, '0', c.unit, b.id, c.id,  '0', '', '无分组', '1', '0', '0', '0', 0  ");
                            strSql.Append(
                                "from saleorderbill b,goods c where b.billcode=?CdpOrderCode and c.code=?SKU; ");

                            #region MySqlParameter

                            MySqlParameter[] parameters =
                            {
                                new MySqlParameter("?CdpOrderCode", MySqlDbType.String),
                                new MySqlParameter("?SKU", MySqlDbType.String, 200),
                                new MySqlParameter("?Quantity", MySqlDbType.Int32),
                                new MySqlParameter("?SellPrice", MySqlDbType.Double),
                                new MySqlParameter("?AdjustedPrice", MySqlDbType.Double)
                            };
                            parameters[0].Value = orderInfo.OrderCode;
                            parameters[1].Value = item.SKU;
                            parameters[2].Value = item.Quantity;
                            parameters[3].Value = item.AdjustedPrice;
                            parameters[4].Value = item.AdjustedPrice * item.Quantity;

                            #endregion

                            listCommand.Add(new CommandInfo(strSql.ToString(),
                                parameters, EffentNextType.ExcuteEffectRows));
                        }


                        DbHelperMySQL.ExecuteSqlTran4Indentity(listCommand, transaction);
                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion

        #region GenerateOrderInfo

        private CommandInfo GenerateOrderInfo(OrderInfo model, string tableName = "saleorderbill", string billType = "BZH")
        {
            decimal couponAmount = model.CouponAmount.HasValue ? model.CouponAmount.Value : 0;

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}(", tableName);
            strSql.Append("`backFlag`, `billCode`,`orderCode`,`orderId`, `settlementType`,`billMoney`, `billType`, `flowFlag`, `makeDate`,`makeTime`, `operator`, `ent_id`, `sys_dep_id`, `blPrint`, `kokura_id`, `deliverPerCount`, `borrowStatus`, `saleMoney`, `lastPreReceiveBalance`, `remarks`,`couponMoney`)");
            strSql.Append(" select ");
#if false   //DONE: 固定为海淀仓库 BEN Modify 20140529
            strSql.Append("0,?CdpOrderCode,?OrderCode,?OrderId,b.settlementType,?Amount,'BZH',0,?CreatedDate,?ReferID,b.id,2, 0, b.kokura_id, '0', '-1', ?Amount, '0', ?Remarks from enterpriseinfo b where ?BuyerID=b.id ");
#else
            strSql.Append("0,?CdpOrderCode,?OrderCode,?OrderId,b.settlementType,?Amount,?BillType,0,?CreatedDate,?CreatedTime,?ReferID,b.id,2, 0, 51, '0', '" + (billType == "BJP" ? "0" : "-1") + "', ?Amount, '0', ?Remarks, ?CouponMoney from enterpriseinfo b where ?BuyerID=b.id ");
#endif
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?OrderId", MySqlDbType.Int64, 8),
                new MySqlParameter("?CdpOrderCode", MySqlDbType.String),
                new MySqlParameter("?OrderCode", MySqlDbType.String),
                new MySqlParameter("?Amount", MySqlDbType.Double),
                new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                new MySqlParameter("?CreatedTime", MySqlDbType.DateTime),
                new MySqlParameter("?ReferID", MySqlDbType.String),
                new MySqlParameter("?BuyerID", MySqlDbType.Int32),
                new MySqlParameter("?Remarks", MySqlDbType.String),
                new MySqlParameter("?BillType", MySqlDbType.String),
                new MySqlParameter("?CouponMoney", MySqlDbType.Double)
            };
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.OrderCode;
            parameters[3].Value = model.Amount;
            parameters[4].Value = model.CreatedDate;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = "系统";
            parameters[7].Value = model.BuyerID;
            //DONE: 订单优惠价格 加到Remark中 Modify BEN 20140721 停用
            parameters[8].Value = string.Empty; //couponAmount > 0 ? string.Format("优惠券 [{0}]", model.CouponCode) : string.Empty;
            parameters[9].Value = billType;
            parameters[10].Value = couponAmount > 0 ? couponAmount : 0;
            return new CommandInfo(strSql.ToString(), parameters);
        }

        #endregion


        #region GenerateExistsUserInfo

        private CommandInfo GenerateExistsUserInfo(OrderInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from enterpriseinfo where active=1 and fax like ?BuyerID limit 1");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?BuyerID", MySqlDbType.String)
            };
            parameters[0].Value = string.Format("%,{0},%", model.BuyerID);
            return new CommandInfo(strSql.ToString(), parameters);
        }

        #endregion
        #endregion

        #region 获取CDP批次

        /// <summary>
        /// 获取批次信息
        /// </summary>
        /// <param name="buyCount">购买数量</param>
        /// <param name="userId">CDP UserId</param>
        /// <param name="sku">商品编号</param>
        /// <param name="borrowEnabled">启用超卖</param>
        /// <param name="bulkCargoEnabled">启用散数</param>
        /// <returns>批次商品集合</returns>
        public List<GoodsBatch> GetBatchsInfomation(int buyCount, int userId, string sku, bool borrowEnabled, bool bulkCargoEnabled)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (bulkCargoEnabled)
            {
                //散数模式
                stringBuilder.Append(
                    "SELECT b.batchNum,b.batchPrice,b.store_Id,b.expiryDate,qtyOfPackage,(CASE WHEN ISNULL(o.qty) THEN b.batchQty ELSE b.batchQty -sum(o.qty) END ) qty ");
            }
            else
            {
                //整箱模式
                stringBuilder.Append("SELECT b.batchNum,b.batchPrice,b.store_Id,b.expiryDate,qtyOfPackage,floor((CASE WHEN ISNULL(o.qty) THEN b.batchQty ELSE b.batchQty -sum(o.qty) END )/qtyOfPackage ) qty ");
            }
            stringBuilder.Append("from goods g,storegoodsbatch b LEFT JOIN ordernooutdetail o ON b.batchNum=o.batchNum");
            stringBuilder.Append(" where g.id = b.goods_Id and g.`code`=?SKU AND  b.store_Id in( select  s.id from store s ,enterpriseinfo e where s.kokura_id=e.kokura_id and e.id=?UserId  and s.blSell=1) GROUP BY b.batchNum,b.store_Id ORDER BY batchNum asc");
            long totalCount = 0;//已经购买的总数
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("?SKU", MySqlDbType.String),
                    new MySqlParameter("?UserId", MySqlDbType.Int64)
                };
            parameters[0].Value = sku;
            parameters[1].Value = userId;
            DataSet ds = DbHelperMySQL.Query(stringBuilder.ToString(), parameters);
            if (ds.Tables[0].Rows.Count < 1) return null;

            GoodsBatch goodsBatch;
            List<GoodsBatch> list = new List<GoodsBatch>();
            int remainCount = 0;//可销数量
            int countTemp = buyCount;//还需要购买的数量
            string batchNum;//批次号
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                goodsBatch = new GoodsBatch();
                if (dr["batchNum"] == null || dr["batchNum"].ToString() == "")
                {
                    throw new ArgumentNullException("商品批次号为空");
                }
                if (null == dr["qty"] || dr["qty"].ToString() == "")
                {
                    throw new ArgumentNullException("商品批次可销数为空");
                }
                if (null == dr["store_Id"] || dr["store_Id"].ToString() == "")
                {
                    throw new ArgumentNullException("商品批次库房Id为空");
                }
                if (null == dr["qtyOfPackage"] || dr["qtyOfPackage"].ToString() == "")
                {
                    throw new ArgumentNullException("商品批次包装数量为空");
                }
                if (null == dr["expiryDate"] || dr["expiryDate"].ToString() == "")
                {
                    //批次过期时间, 
                    goodsBatch.ExpiryDate = DateTime.MaxValue;
                }
                else
                {
                    goodsBatch.ExpiryDate = Convert.ToDateTime(dr["expiryDate"]);
                }
                batchNum = dr["batchNum"].ToString();//批次号

                remainCount = Globals.SafeInt(dr["qty"], 0);//可销数

                if (totalCount >= buyCount) return list;

                if (remainCount >= countTemp) //可销数量大于等于购买数量
                {
                    goodsBatch.Quantity = countTemp;
                }
                else //可销数量小于购买数量  buyCount
                {
                    if (remainCount < 1) continue; //如果可销数量为0则进入下次循环
                    goodsBatch.Quantity = remainCount;
                    countTemp -= remainCount;
                }
                goodsBatch.BatchNum = batchNum;
                if (null == dr["batchPrice"] || dr["batchPrice"].ToString() == "")
                {
                    goodsBatch.BatchPrice = 0;
                }
                else
                {
                    goodsBatch.BatchPrice = Convert.ToDouble(dr["batchPrice"]);
                }
                goodsBatch.StoreId = Convert.ToInt32(dr["store_Id"]);
                goodsBatch.QtyPackage = Convert.ToInt32(dr["qtyOfPackage"]);
                list.Add(goodsBatch);
                totalCount += remainCount;

                #region 剩余数量大于购买数量  直接买首个批次 暂停使用
                //if (remainCount > buyCount)//剩余数量大于购买数量  直接买首个批次
                //{
                //    resultList = new List<Dictionary<string, int>>();
                //    dictionary = new Dictionary<string, int>();
                //    dictionary.Add(batchNum, buyCount);
                //    resultList.Add(dictionary);
                //}
                //else
                //{
                //    totalCount += remainCount;
                //    resultList = new List<Dictionary<string, int>>();
                //    dictionary = new Dictionary<string, int>();
                //} 
                #endregion
            }
            if (totalCount < buyCount)//可销数量小于购买数量
            {
                //启用超卖借库
                if (borrowEnabled)
                {
                    return list;
                }
                return null;
            }
            return list;



        }
        #endregion
    }

    public class GoodsBatch
    {
        public string BatchNum { get; set; }
        public double BatchPrice { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public int QtyPackage { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}