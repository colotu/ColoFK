using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using YSWL.Common;
using YSWL.Components.Handlers.API;
using YSWL.Json;
using YSWL.Json.RPC;
using YSWL.MALL.BLL.Ms;
using YSWL.MALL.BLL.Shop.Order;
using YSWL.MALL.BLL.SysManage;
using YSWL.MALL.Model.Shop.Order;
using YSWL.MALL.Model.Shop.Products;

namespace YSWL.MALL.API.Pos.v1
{
    public partial class PosHandler
    {
        private readonly Orders _orderManage = new Orders();
        private YSWL.MALL.BLL.Ms.Regions regionsBLL = new Regions();
        private YSWL.MALL.BLL.Shop.Shipping.ShippingAddress _addressManage = new YSWL.MALL.BLL.Shop.Shipping.ShippingAddress();
        private YSWL.MALL.BLL.Shop.Coupon.CouponInfo couponBLL = new BLL.Shop.Coupon.CouponInfo();
        private YSWL.MALL.BLL.Shop.Shipping.ShippingType _shippingTypeManage = new YSWL.MALL.BLL.Shop.Shipping.ShippingType();
        private YSWL.MALL.BLL.Shop.Shipping.ShippingRegionGroups _shippingRegionManage = new YSWL.MALL.BLL.Shop.Shipping.ShippingRegionGroups();
        private YSWL.MALL.BLL.Shop.PromoteSales.GroupBuy groupBuyBll = new YSWL.MALL.BLL.Shop.PromoteSales.GroupBuy();
        private YSWL.MALL.BLL.Shop.Order.OrderAction actionBLL = new YSWL.MALL.BLL.Shop.Order.OrderAction();
        private YSWL.MALL.BLL.Shop.Activity.ActivityInfo activInfoBll = new BLL.Shop.Activity.ActivityInfo();
        private readonly YSWL.MALL.BLL.Shop.Order.Orders orderBll = new YSWL.MALL.BLL.Shop.Order.Orders();
        private YSWL.MALL.BLL.MDM.Line lineBll = new YSWL.MALL.BLL.MDM.Line();

        #region  客户订单

        #region 列表
        [JsonRpcMethod("GetCustOrderList", Idempotent = false)]
        [JsonRpcHelp("客户订单")]
        public JsonObject GetCustOrderList(int? custUserId, string startDate, string endDate, string keyWords, int type = 1, string source = "pos", int? page = 1, int pageNum = 30)
        {
            if (pageNum == 0)
            {
                pageNum = 10;
            }
            if (string.IsNullOrEmpty(page.ToString()))
            {
                page = 1;
            }
            //重置页面索引
            page = page.HasValue && page.Value > 1 ? page.Value : 1;
            //计算分页起始索引
            int startIndex = page.Value > 1 ? (page.Value - 1) * pageNum + 1 : 0;
            //计算分页结束索引
            int endIndex = page.Value > 1 ? startIndex + pageNum - 1 : pageNum;
            StringBuilder strWhere = new StringBuilder();

            //主订单
            strWhere.AppendFormat(" OrderType=1 and ReferType{0}6", source == "pos" ? "=" : "<>");

            if (custUserId.HasValue)
            {
                strWhere.AppendFormat(" and BuyerID= {0}", custUserId);
            }

            //获取订单类型
            #region 订单状态
            switch (type)
            {
                //待支付
                case 2:
                    strWhere.Append(" AND PaymentGateway not in ('cod','bank') and PaymentStatus = 0 and OrderStatus=0 and ShippingStatus=0");
                    break;
                //待审核
                case 3:
                    strWhere.Append(@" AND OrderStatus=0 and ((PaymentGateway not in ('cod','bank') and PaymentStatus=2 and ShippingStatus=0) 
                                         or (PaymentGateway = 'cod' and PaymentStatus=0 and ShippingStatus=0))");
                    break;
                //待发货
                case 4:
                    //strWhere.Append(" AND  ShippingStatus<2 AND OrderStatus<>-1  and ( ( PaymentStatus=2 and PaymentGateway<>'cod' ) or ( PaymentStatus=0 and PaymentGateway='cod') ) ");
                    strWhere.Append(@" AND OrderStatus=1 and ShippingStatus<2 and ((PaymentStatus=2 and PaymentGateway not in ('cod','bank')) 
                                        or (PaymentStatus=0 and PaymentGateway='cod'))");
                    break;
                //已发货 
                case 5:
                    strWhere.Append(" AND ShippingStatus=2 and OrderStatus=1 ");
                    break;
                //已完成
                case 6:
                    strWhere.Append(" AND OrderStatus=2 and PaymentStatus=2 and ShippingStatus=3");
                    break;
                //已取消
                case 7:
                    strWhere.Append(" AND OrderStatus=-1 and PaymentStatus=0 and ShippingStatus=0");
                    break;
                case 1:
                default:
                    break;
            }
            #endregion

            #region 时间段
            DateTime? start = Common.Globals.SafeDateTime(startDate, null);
            DateTime? end = Common.Globals.SafeDateTime(endDate, null);
            if (start.HasValue)
            {
                if (strWhere.Length > 1)
                {
                    strWhere.Append(" and  ");
                }
                strWhere.AppendFormat(" CreatedDate >='" + start.Value.Date + "' ");
            }
            if (end.HasValue)
            {
                string endTime = Common.Globals.SafeDateTime(end.Value, DateTime.Now).AddDays(1).ToString("yyyy-MM-dd");
                if (strWhere.Length > 1)
                {
                    strWhere.Append(" and  ");
                }
                strWhere.AppendFormat(" CreatedDate <='" + endTime + "' ");
            }
            #endregion

            //订单号
            if (!String.IsNullOrWhiteSpace(keyWords))
            {
                if (strWhere.Length > 1)
                {
                    strWhere.Append(" and  ");
                }
                strWhere.AppendFormat(" ( OrderCode like '%{0}%'  or  BuyerName  like '%{0}%'  )", Common.InjectionFilter.SqlFilter(keyWords));
            }

            int toalCount = _orderManage.GetRecordCount(strWhere.ToString());
            YSWL.Json.JsonArray jsonArray = new JsonArray();
            JsonObject json;
            List<OrderInfo> orderList = _orderManage.GetListByPageEX(strWhere.ToString(), "", startIndex, endIndex);
            if (orderList == null || orderList.Count <= 0)
            {
                return new Result(ResultStatus.Success, jsonArray);
            }
            //  int prodTotal;
            // JsonArray pList;
            foreach (OrderInfo item in orderList)
            {
                // item.OrderItems = itemBll.GetModelList(" OrderId=" + item.OrderId);
                // prodTotal = 0;
                // pList = new JsonArray();
                json = new JsonObject();
                json.Put("orderId", item.OrderId);
                json.Put("orderCode", item.OrderCode);
                json.Put("mainStatus", _orderManage.GetOrderType(item.PaymentGateway, item.OrderStatus, item.PaymentStatus, item.ShippingStatus));
                //Paying:等待付款,PreHandle:等待处理,Cancel:取消订单,Locking:订单锁定,PreConfirm:等待付款确认,Handling:配货中，Shiped:已发货,Complete:已完成
                //等待付款  可 支付 或 取消 ,  已发货   可 确认收货
                json.Put("mainStatusStr", _orderManage.GetOrderTypeStr(item.PaymentGateway, item.OrderStatus, item.PaymentStatus, item.ShippingStatus));
                json.Put("time", item.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                json.Put("allprice", item.Amount.ToString("F"));
                json.Put("buyerID", item.BuyerID);
                json.Put("buyerName", item.BuyerName);//买家名称即客户名称
                json.Put("sources", _orderManage.GetOrderReferTypeStr(item.ReferType));//来源

                //暂时实时读取创建人名称  后面要加字段，直接从订单表中获取
                if (item.ReferType.HasValue)
                {
                    switch (item.ReferType.Value)
                    {
                        case (int)EnumHelper.ReferType.WeChatB:
                        case (int)EnumHelper.ReferType.WeChat:
                        case (int)EnumHelper.ReferType.PC:
                        case (int)EnumHelper.ReferType.Ding:
                            json.Put("createUser", item.BuyerName);//下单人是客户自己
                            break;
                        default:
                            json.Put("createUser", GetName(userManage.GetModelByCache(item.CreateUserId)));//获取下单人    返回truename如果没有返回username
                            break;
                    }
                }
                else
                {
                    json.Put("createUser", GetName(userManage.GetModelByCache(item.CreateUserId)));//获取下单人    返回truename如果没有返回username
                }
                jsonArray.Add(json);
            }
            return new Result(ResultStatus.Success, jsonArray);
        }
        #endregion
        private string GetName(YSWL.MALL.Model.Members.Users userModel)
        {
            if (userModel == null)
            {
                return "";
            }
            return !String.IsNullOrWhiteSpace(userModel.TrueName) ? userModel.TrueName : userModel.UserName;
        }
        #region 订单详情
        [JsonRpcMethod("GetCustOrderDetail", Idempotent = false)]
        [JsonRpcHelp("客户订单详情")]
        public JsonObject GetCustOrderDetail(long orderId = -1)
        {
            OrderInfo orderModel = _orderManage.GetModelInfo(orderId);
            JsonObject jsonObject = new JsonObject();
            List<JsonObject> jsonList;//=new List<JsonObject>();
            JsonObject jsonItem;
            #region order_follow 部分的信息
            List<YSWL.MALL.Model.Shop.Order.OrderAction> actionList = actionBLL.GetModelList(" OrderId=" + orderId);
            if (null != actionList && actionList.Count > 0)
            {
                jsonList = new List<JsonObject>();
                foreach (var item in actionList)
                {
                    jsonItem = new JsonObject();
                    jsonItem.Put("time", item.ActionDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    jsonItem.Put("operation", YSWL.MALL.BLL.Shop.Order.OrderAction.GetActionCode(item.ActionCode));
                    jsonList.Add(jsonItem);
                }
                jsonObject.Put("order_follows", jsonList);
            }
            #endregion

            #region address_info 部分的信息
            JsonObject addressjson = new JsonObject();
            addressjson.Put("name", orderModel.ShipName);
            addressjson.Put("id", orderModel.RegionId);
            if (orderModel.RegionId > 0)
            {
                string fullName = regionsBLL.GetFullNameById4Cache(orderModel.RegionId);
                addressjson.Put("addressArea", fullName);
            }
            addressjson.Put("areaDetail", orderModel.ShipAddress);
            addressjson.Put("phone", orderModel.ShipCellPhone);
            jsonObject.Put("address_info", addressjson);
            #endregion
            jsonObject.Put("orderCode", orderModel.OrderCode);
            jsonObject.Put("mainStatus", _orderManage.GetOrderType(orderModel.PaymentGateway, orderModel.OrderStatus, orderModel.PaymentStatus, orderModel.ShippingStatus));
            //Paying:等待付款,PreHandle:等待处理,Cancel:取消订单,Locking:订单锁定,PreConfirm:等待付款确认,Handling:配货中，Shiped:已发货,Complete:已完成
            //等待付款  可 支付 或 取消 ,  已发货   可 确认收货
            jsonObject.Put("mainStatusStr", _orderManage.GetOrderTypeStr(orderModel.PaymentGateway, orderModel.OrderStatus, orderModel.PaymentStatus, orderModel.ShippingStatus));
            jsonObject.Put("time", orderModel.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));
            jsonObject.Put("buyerName", orderModel.BuyerName);//买家名称即客户名称
            jsonObject.Put("sources", _orderManage.GetOrderReferTypeStr(orderModel.ReferType));//来源
            jsonObject.Put("paytypename", orderModel.PaymentTypeName);
            jsonObject.Put("paygateway", orderModel.PaymentGateway);
            jsonObject.Put("shippingName", orderModel.RealShippingModeName);
            jsonObject.Put("shiporderNumber", orderModel.ShipOrderNumber);
            #region payment_info 部分的信息
            JsonObject paymentjson = new JsonObject();
            //paymentjson.Put("freightAdjusted", orderModel.FreightAdjusted.HasValue ? orderModel.FreightAdjusted.Value.ToString("F") : "0.00");
            //paymentjson.Put("productprice", orderModel.ProductTotal.ToString("F"));
            //paymentjson.Put("orderprice", orderModel.Amount.ToString("F"));
            //paymentjson.Put("returnprice", (orderModel.OrderTotal - orderModel.Amount).ToString("F"));

            //其他金额
            paymentjson.Put("otherprice", orderModel.OrderOtherCost);
            //折扣金额
            paymentjson.Put("discountprice", orderModel.DiscountAdjusted);
            //优惠价格
            paymentjson.Put("couponprice", orderModel.CouponAmount);

            #endregion

            #region productlist 部分的信息
            if (orderModel.OrderItems.Count > 0)
            {
                jsonList = new List<JsonObject>();

                var productList = orderModel.OrderItems.GroupBy(a => new { a.ProductId, a.Name }).Select(a => new { a.Key.ProductId, a.Key.Name });
                //商品总价格
                decimal proamount = 0M;
                foreach (var pitem in productList)
                {
                    jsonItem = new JsonObject();
                    jsonItem.Put("id", pitem.ProductId);
                    jsonItem.Put("name", pitem.Name);
                    var productSku = orderModel.OrderItems.Where(i => i.ProductId == pitem.ProductId);
                    List<JsonObject> skuList = new List<JsonObject>();
                    JsonObject sku = null;
                    foreach (var itemse in productSku)
                    {
                        sku = new JsonObject();
                        sku.Put("shopCarColorKey", itemse.Attribute);
                        if (YSWL.Components.MvcApplication.IsAutoConn)
                        {
                            jsonItem.Put("pic", string.IsNullOrWhiteSpace(itemse.ThumbnailsUrl) ? itemse.ThumbnailsUrl : itemse.ThumbnailsUrl.Replace("/Upload/", mdmUrl + "/Upload/"));
                        }
                        else
                        {
                            jsonItem.Put("pic", itemse.ThumbnailsUrl);
                        }
                        ProductInfo pro = productManage.GetModelByCache(itemse.ProductId);
                        if (null != pro)
                        {
                            sku.Put("marketprice", pro.MarketPrice.HasValue ? pro.MarketPrice.Value.ToString("F") : "0.00");
                        }
                        else
                        {
                            sku.Put("marketprice", "0.00");
                        }
                        sku.Put("saleprice", itemse.AdjustedPrice.ToString("F"));
                        sku.Put("number", itemse.Quantity);
                        proamount += itemse.Quantity * itemse.AdjustedPrice;
                        skuList.Add(sku);
                    }
                    jsonItem.Put("buyitem", skuList);
                    jsonList.Add(jsonItem);

                    //计算商品总数量
                    jsonObject.Put("productcount", productSku.Sum(i => i.Quantity));
                    //计算商品总价格
                    jsonObject.Put("proamount", proamount);

                    //合计金额
                    decimal? totalprice = proamount + orderModel.OrderOtherCost;
                    paymentjson.Put("totalprice", totalprice?.ToString("0.00"));
                    //整单折扣(%)
                    decimal? orderdiscount = (totalprice - orderModel.DiscountAdjusted) / totalprice;
                    paymentjson.Put("orderdiscount", orderdiscount?.ToString("0.00"));
                    //实付金额
                    decimal? realprice = totalprice - orderModel.DiscountAdjusted - orderModel.CouponAmount;
                    paymentjson.Put("realprice", realprice?.ToString("0.00"));


                }
                jsonObject.Put("payment_info", paymentjson);
                jsonObject.Put("orderId", orderId);
                jsonObject.Put("productlist", jsonList);

                #region 注释代码
                //foreach (var item in orderModel.OrderItems)
                //{
                //    jsonItem = new JsonObject();
                //    jsonItem.Put("id", item.ProductId);
                //    jsonItem.Put("name", item.Name);
                //    jsonItem.Put("shopCarColorKey", item.Attribute);
                //    #region 远程加载数据图片
                //    if (YSWL.Components.MvcApplication.IsAutoConn)
                //    {
                //        jsonItem.Put("pic", String.IsNullOrWhiteSpace(item.ThumbnailsUrl) ? item.ThumbnailsUrl : item.ThumbnailsUrl.Replace("/Upload/", mdmUrl + "/Upload/"));
                //    }
                //    else
                //    {
                //        jsonItem.Put("pic", item.ThumbnailsUrl);
                //    }
                //    #endregion

                //    YSWL.MALL.Model.Shop.Products.ProductInfo pro = productManage.GetModelByCache(item.ProductId);
                //    if (null != pro)
                //    {
                //        jsonItem.Put("marketprice", pro.MarketPrice.HasValue ? pro.MarketPrice.Value.ToString("F") : "0.00");
                //    }
                //    else
                //    {
                //        jsonItem.Put("marketprice", "0.00");
                //    }
                //    jsonItem.Put("saleprice", item.SellPrice.ToString("F"));
                //    jsonItem.Put("number", item.Quantity);
                //    jsonList.Add(jsonItem);
                //}
                //jsonObject.Put("productlist", jsonList);
                #endregion
            }
            #endregion
            return new Result(ResultStatus.Success, jsonObject);
        }

        #endregion

        #endregion

        #region 提交订单

        [JsonRpcMethod("SubmitOrder", Idempotent = false)]
        [JsonRpcHelp("提交订单")]
        public JsonObject SubmitOrder(int salesUserId, int userId, int depotId, int shipTypeId, int paymentId, JsonArray productList, string phone, string remark,
            string invoiceHeader, string invoiceContent, string couponCode,
            DateTime date, decimal extraPrice, decimal discountPrice, decimal couponAmount, decimal realPrice,
            int proSaleId = -1, int groupBuyId = -1, string address = "")
        {
            JsonObject jsonObject = new JsonObject();
            string orderRemark = remark;
            if (!string.IsNullOrWhiteSpace(orderRemark))
            {
                orderRemark = InjectionFilter.Filter(orderRemark);
            }
            #region 发票信息 保存到备注中
            string invoice = "";
            if (!string.IsNullOrWhiteSpace(invoiceHeader))
            {
                invoice += "发票抬头：" + InjectionFilter.Filter(invoiceHeader);
            }
            if (!string.IsNullOrWhiteSpace(invoiceContent))
            {
                invoice += "     发票内容：" + InjectionFilter.Filter(invoiceContent);
            }
            if (!String.IsNullOrWhiteSpace(invoice))
            {
                invoice = string.Format(" （{0}）", invoice);
            }
            orderRemark += invoice;
            #endregion

            ShoppingCartInfo shoppingCartInfo;

            #region 2.购买人的数据
            YSWL.MALL.Model.Members.Users userModel;
            if (salesUserId <= 0)
            {
                return new Result(ResultStatus.Failed, "notlogin");//没有业务员信息
            }
            //if (userId < 1)
            //{
            //    return new Result(ResultStatus.Failed, "nopersonInfo");
            //}
            //else
            //{
            userModel = userManage.GetModelByCache(userId);
            if (null != userModel)
            {
                YSWL.Common.Cookies.setCookie("SubmitOrder_ReferType_" + userModel.UserID,
((int)YSWL.MALL.Model.Shop.Order.EnumHelper.ReferType.Pos).ToString(), 1440);
            }
            //    else
            //    {
            //        return new Result(ResultStatus.Failed, "nopersonInfo");
            //    }
            //}
            #endregion

            #region 4.获取收货人
            YSWL.MALL.Model.Shop.Shipping.ShippingAddress shippingAddress = null;
            //YSWL.MALL.Model.Ms.Regions regionInfo = null;
            //if (userId!=0)
            //{
            //    //if (shipId < 1)
            //    //{
            //    //    return new Result(ResultStatus.Failed, "noShippingAddress");
            //    //}
            //    //shippingAddress = _addressManage.GetModelByCache(shipId);

            //    shippingAddress = _addressManage.GetModelByUserId(userId);
            //    if (shippingAddress == null)
            //    {
            //        return new Result(ResultStatus.Failed, "noReceiverInfo");
            //    }
            //    if (shippingAddress.RegionId < 1)
            //    {
            //        return new Result(ResultStatus.Failed, "noProvinceCity");
            //    }

            //    regionInfo = regionsBLL.GetModelByCache(shippingAddress.RegionId);
            //    if (regionInfo == null)
            //    {
            //        return new Result(ResultStatus.Failed, "noRehionInfo");
            //    }
            //}
            #endregion

            #region 1.获取购物车    循环传过来的List

            //DONE: 2.获取购物车
            //YSWL.MALL.BLL.Shop.Products.ShoppingCartHelper shoppingCartHelper;
            try
            {
                shoppingCartInfo = GetShoppingCartByDepotId(productList, userId, proSaleId, groupBuyId, depotId);
            }
            catch (ArgumentNullException)
            {
                return new Result(ResultStatus.Failed, "PROSALEEXPIRED");
            }
            if (shoppingCartInfo == null ||
                shoppingCartInfo.Items == null ||
                shoppingCartInfo.Items.Count < 1)
            {
                return new Result(ResultStatus.Failed, "NOSHOPPINGCARTINFO");
            }
            //DONE: 2.1 Check 商品库存
            List<ShoppingCartItem> noStockList = new List<ShoppingCartItem>();
            JsonArray notstockArray = new JsonArray();
            JsonObject notstockJson = null;
            foreach (ShoppingCartItem item in shoppingCartInfo.Items)
            {
                //检查购买数量是否大于库存
                if (item.Quantity < 1 || item.Quantity > item.Stock)
                {
                    noStockList.Add(item);
                    notstockJson = new JsonObject();
                    notstockJson.Put("id", item.ProductId);
                    notstockJson.Put("name", item.Name);
                    notstockJson.Put("sku", item.SKU);
                    notstockJson.Put("stockcount", 0);
                    notstockArray.Add(notstockJson);
                }
            }
            if (notstockArray.Length > 0)
            {
                ////自动移除Cookie/DB购物车中的无库存项目
                //if (shoppingCartHelper != null)
                //{
                //    noStockList.ForEach(info =>
                //    {
                //        //TODO: 仅自动删除无库存商品 此处需要DB真实库存
                //        shoppingCartHelper.RemoveItem(info.ItemId);

                //    });
                //}
                return new Result(ResultStatus.Failed, notstockArray);
            }
            #endregion

            #region 3.获取支付基础数据
            if (paymentId < 1)
            {
                return new Result(ResultStatus.Failed, "nopaymentmodelinfo");
            }
            YSWL.Payment.Model.PaymentModeInfo paymentModeInfo =
                   YSWL.Payment.BLL.PaymentModeManage.GetPaymentModeById(paymentId);
            if (null == paymentModeInfo)
            {
                return new Result(ResultStatus.Failed, "nopaymentmodelinfo");
            }
            #endregion

            #region 5.获取配送(物流)
            if (shipTypeId < 1)
            {
                return new Result(ResultStatus.Failed, "NOSHIPPINGTYPE");
            }
            YSWL.MALL.Model.Shop.Shipping.ShippingType shippingType = _shippingTypeManage.GetModelByCache(shipTypeId);
            if (shippingType == null)
            {
                return new Result(ResultStatus.Failed, "NOSHIPPINGTYPE");
            }
            #endregion

            #region 6.生成订单
            //DONE: 5.生成订单
            OrderInfo mainOrder = new OrderInfo();
            #region 填充订单数据

            #region 基础数据
            #region 下单类型
            mainOrder.ReferType = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ReferType.Pos;
            #endregion

            mainOrder.CreatedDate = DateTime.Now;
            bool codePre = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_CreateOrder_PreCode");
            mainOrder.CreateUserId = salesUserId;
            if (codePre)
            {
                mainOrder.OrderCode = mainOrder.ReferOrderPrefix + mainOrder.CreatedDate.ToString("yyyyMMddHHmmssfff");
            }
            else
            {
                mainOrder.OrderCode = mainOrder.CreatedDate.ToString("yyyyMMddHHmmssfff");
            }
            mainOrder.Remark = orderRemark;

            #region 支付信息

            mainOrder.PaymentTypeId = paymentModeInfo.ModeId;
            mainOrder.PaymentTypeName = paymentModeInfo.Name;
            mainOrder.PaymentGateway = paymentModeInfo.Gateway;
            //如果是现金支付，直接修改支付状态已支付
            if (paymentModeInfo.Gateway.Trim() == "cash")
            {
                mainOrder.PaymentStatus = 2;
            }

            #endregion


            #region 优惠券数据

            mainOrder.CouponAmount = 0;
            if (!string.IsNullOrWhiteSpace(couponCode))
            {
                YSWL.MALL.Model.Shop.Coupon.CouponInfo infoModel = couponBLL.GetCouponInfo(couponCode);
                if (infoModel != null && infoModel.Status < 2 && infoModel.Status >= 0 && shoppingCartInfo.TotalAdjustedPrice > infoModel.LimitPrice)//优惠券未使用而且 商品总价大于优惠券限制金额（不含运费）
                {
                    mainOrder.CouponAmount = infoModel.CouponPrice;
                    mainOrder.CouponCode = infoModel.CouponCode;
                    mainOrder.CouponName = infoModel.CouponName;
                    mainOrder.CouponValue = infoModel.CouponPrice;
                    mainOrder.CouponValueType = 1;
                }
            }


            #endregion

            //是否包邮
            bool IsFreeShippingActiv = false;
            #region 获取促销活动赠品
            List<Model.Shop.Activity.ActivityInfo> actInfoList = null;
            //赠品
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> actProductList = null;
            //赠品 目前没有加运费 没有加重量
            if (proSaleId < 1 && groupBuyId < 1)
            {
                actInfoList = activInfoBll.GetActGiftList(shoppingCartInfo, userId, mainOrder.CouponAmount.HasValue ? mainOrder.CouponAmount.Value : 0);

                #region 排除掉赠优惠劵和包邮 2.2版本中没有此功能
                if (actInfoList != null)
                {
                    actInfoList = actInfoList.Where(o => (o.RuleId == 1 || o.RuleId == 2)).ToList();
                }
                #endregion

                if (actInfoList != null)
                {
                    //获取包邮活动
                    List<Model.Shop.Activity.ActivityInfo> freeShippingList = actInfoList.Where(p => p.RuleId == 4).ToList();
                    if (freeShippingList != null && freeShippingList.Count > 0)
                    {
                        //包邮
                        IsFreeShippingActiv = true;
                    }

                    actProductList = YSWL.MALL.BLL.Shop.Activity.ActivityInfo.GetActProList(actInfoList, 0);
                }
            }
            #endregion

            #region 重量/运费/积分

            #region 区域差异运费计算
            //int topRegionId;
            //if (userId > 0)
            //{
            //    if (regionInfo.Depth > 1)
            //    {
            //        topRegionId = Globals.SafeInt(regionInfo.Path.Split(new[] { ',' })[1], -1);
            //    }
            //    else
            //    {
            //        topRegionId = regionInfo.RegionId;
            //    }

            //    YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups shippingRegion =
            //        _shippingRegionManage.GetShippingRegion(shippingType.ModeId, topRegionId);
            //    mainOrder.Freight = mainOrder.FreightAdjusted = mainOrder.FreightActual = shoppingCartInfo.CalcFreight(shippingType, shippingRegion);
            //}
            //else
            //{
            //    mainOrder.Freight = mainOrder.FreightAdjusted = 0;
            //}
            #endregion
            mainOrder.Freight = mainOrder.FreightAdjusted = 0;
            mainOrder.Weight = shoppingCartInfo.TotalWeight;

            if (IsFreeShippingActiv)
            {
                //包邮
                mainOrder.FreightAdjusted = 0;
                mainOrder.IsFreeShipping = true;
            }


            mainOrder.OrderPoint = shoppingCartInfo.TotalPoints;
            #endregion

            #region 订单价格

            //订单商品总价(无任何优惠)
            mainOrder.ProductTotal = shoppingCartInfo.TotalSellPrice;

            //订单总成本价 = 商品总成本价
            mainOrder.OrderCostPrice = shoppingCartInfo.TotalCostPrice;

            //订单总金额(无任何优惠) 商品总价 + 运费
            mainOrder.OrderTotal = shoppingCartInfo.TotalSellPrice + mainOrder.Freight.Value;

            //订单最终支付金额 = 项目调整后总售价 + 调整后运费+其他费用-优惠价格-折扣金额
            //decimal amount = shoppingCartInfo.TotalAdjustedPrice + mainOrder.FreightAdjusted.Value + extraPrice - (mainOrder.CouponAmount ?? 0) - discountPrice;
            decimal amount = realPrice;
            mainOrder.Amount = amount > 0 ? amount : 0;
            //折扣金额
            mainOrder.DiscountAdjusted = shoppingCartInfo.TotalSellPrice - shoppingCartInfo.TotalAdjustedPrice;
            decimal totalRate = shoppingCartInfo.TotalRate; //总价优惠值

            if (mainOrder.Amount < 0)
            {
                LogHelp.AddInvadeLog(
                    string.Format("非法订单金额|{0}|_YSWL.Web.Handlers.Shop.OrderHandler.SubmitOrder",
                        mainOrder.Amount.ToString("F2")), HttpContext.Current.Request);
                return new Result(ResultStatus.Failed, "ILLEGALORDERAMOUNT");
            }

            //附加费用
            mainOrder.OrderOtherCost = extraPrice;
            //折扣金额
            mainOrder.DiscountAdjusted = discountPrice;
            mainOrder.DiscountAmount = discountPrice;
            //优惠金额
            mainOrder.CouponAmount = couponAmount;

            #endregion


            mainOrder.OrderType = 1;


            mainOrder.OrderStatus = 0;

            #endregion

            #region 购买人信息

            mainOrder.BuyerID = userModel != null ? userModel.UserID : -1;
            mainOrder.BuyerName = userModel != null ? userModel.UserName : "";
            mainOrder.ReferID = userModel != null ? userModel.EmployeeID.ToString() : "";
            //TODO: 用户Email为空时, 暂以默认Email下单 BEN ADD 20130701
            string buyEmail = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("Shop_Pay_DefaultEmail");
            buyEmail = String.IsNullOrWhiteSpace(buyEmail) ? "pay@ys56.com" : buyEmail;
            mainOrder.BuyerEmail = userModel != null ? (string.IsNullOrWhiteSpace(userModel.Email) ? buyEmail : userModel.Email) : "";
            mainOrder.BuyerCellPhone = userModel != null ? userModel.Phone : phone;

            #endregion

            #region 拆单对象
            Dictionary<int, List<YSWL.MALL.Model.Shop.Order.OrderItems>> dicSuppOrderItems = new Dictionary<int, List<YSWL.MALL.Model.Shop.Order.OrderItems>>();
            #endregion

            #region 购物车 -> 订单项目
            YSWL.MALL.Model.Shop.Order.OrderItems tmpOrderItem;
            //购物车 -> 订单项目
            shoppingCartInfo.Items.ForEach(item =>
            {
                tmpOrderItem = new YSWL.MALL.Model.Shop.Order.OrderItems
                {
                    //TODO: 警告: 商品信息根据Cookie获取, 暂未与DB及时同步
                    Name = item.Name,
                    SKU = item.SKU,
                    Quantity = item.Quantity,
                    ShipmentQuantity = item.Quantity,
                    ThumbnailsUrl = item.ThumbnailsUrl,
                    Points = item.Points,
                    Weight = item.Weight > 0 ? item.Weight : 0,
                    ProductId = item.ProductId,
                    Description = item.Description,
                    CostPrice = item.CostPrice,
                    SellPrice = item.SellPrice,
                    AdjustedPrice = item.AdjustedPrice,
                    Deduct = item.SellPrice - item.AdjustedPrice,
                    OrderCode = mainOrder.OrderCode,
                    BrandId = item.BrandId,
                    //商家信息
                    SupplierId = item.SupplierId,
                    SupplierName = item.SupplierName,
                    ProductType = 1
                };

                //将SKU信息记录到订单项目的Attribute中 简单记录 逗号分割, 复杂的可以为Json结构
                if (item.SkuValues != null && item.SkuValues.Length > 0)
                {
                    tmpOrderItem.Attribute = string.Join(",", item.SkuValues);
                }

                //填充订单项
                mainOrder.OrderItems.Add(tmpOrderItem);

                //填充商家订单项
                if (tmpOrderItem.SupplierId.HasValue && tmpOrderItem.SupplierId.Value > 0)
                {
                    if (dicSuppOrderItems.ContainsKey(tmpOrderItem.SupplierId.Value))
                    {
                        dicSuppOrderItems[tmpOrderItem.SupplierId.Value].Add(tmpOrderItem);
                    }
                    else
                    {
                        dicSuppOrderItems.Add(tmpOrderItem.SupplierId.Value,
                            new List<YSWL.MALL.Model.Shop.Order.OrderItems> { tmpOrderItem });
                    }
                }
                else
                {
                    if (dicSuppOrderItems.ContainsKey(0))
                    {
                        dicSuppOrderItems[0].Add(tmpOrderItem);
                    }
                    else
                    {
                        dicSuppOrderItems.Add(0,
                            new List<YSWL.MALL.Model.Shop.Order.OrderItems> { tmpOrderItem });
                    }
                }
            });

            #endregion

            #region 添加赠品
            if (actProductList != null && actProductList.Count > 0)
            {
                BLL.Shop.Supplier.SupplierInfo supplierManage = new BLL.Shop.Supplier.SupplierInfo();
                Model.Shop.Supplier.SupplierInfo supplierInfo;
                BLL.Shop.Products.SKUInfo skuManage = new BLL.Shop.Products.SKUInfo();
                foreach (var productInfo in actProductList)
                {
                    supplierInfo = null;
                    if (productInfo.SupplierId > 0)
                    {
                        supplierInfo = supplierManage.GetModelByCache(productInfo.SupplierId);
                    }

                    tmpOrderItem = new Model.Shop.Order.OrderItems()
                    {
                        //TODO: 警告: 商品信息根据Cookie获取, 暂未与DB及时同步
                        Name = productInfo.ProductName,
                        SKU = productInfo.SkuInfos[0].SKU,
                        Quantity = productInfo.Count,
                        ShipmentQuantity = productInfo.Count,
                        ThumbnailsUrl = productInfo.ThumbnailUrl1,
                        Points = productInfo.Points.HasValue ? Globals.SafeInt(productInfo.Points.Value, 0) : 0,
                        Weight = 0, //productInfo.SkuInfos[0].Weight.HasValue?productInfo.SkuInfos[0].Weight.Value:0,
                        ProductId = productInfo.ProductId,
                        Description = productInfo.Description,
                        CostPrice = productInfo.SkuInfos[0].CostPrice.HasValue ? productInfo.SkuInfos[0].CostPrice.Value : 0,
                        SellPrice = productInfo.SalePrice,// productInfo.SkuInfos[0].SalePrice,// productInfo.SalePrice,//
                        AdjustedPrice = productInfo.SalePrice,//促销价// productInfo.SkuInfos[0].SalePrice,
                        Deduct = productInfo.SkuInfos[0].SalePrice - productInfo.SalePrice,
                        OrderCode = mainOrder.OrderCode,
                        BrandId = productInfo.BrandId,
                        ProductType = 2
                    };
                    //商家信息
                    if (supplierInfo != null)
                    {
                        tmpOrderItem.SupplierId = supplierInfo.SupplierId;
                        tmpOrderItem.SupplierName = supplierInfo.Name;
                    }
                    //将SKU信息记录到订单项目的Attribute中 简单记录 逗号分割, 复杂的可以为Json结构
                    List<Model.Shop.Products.SKUItem> listSkuItems = skuManage.GetSKUItemsBySkuId(productInfo.SkuInfos[0].SkuId);
                    if (listSkuItems != null && listSkuItems.Count > 0)
                    {
                        string skuValues = string.Empty;
                        listSkuItems.ForEach(xx =>
                        {
                            skuValues += xx.ValueStr + ",";
                        });
                        tmpOrderItem.Attribute = skuValues.TrimEnd(',');
                    }
                    //填充订单项
                    mainOrder.OrderItems.Add(tmpOrderItem);

                    //填充商家订单项
                    if (tmpOrderItem.SupplierId.HasValue && tmpOrderItem.SupplierId.Value > 0)
                    {
                        if (dicSuppOrderItems.ContainsKey(tmpOrderItem.SupplierId.Value))
                        {
                            dicSuppOrderItems[tmpOrderItem.SupplierId.Value].Add(tmpOrderItem);
                        }
                        else
                        {
                            dicSuppOrderItems.Add(tmpOrderItem.SupplierId.Value,
                                new List<YSWL.MALL.Model.Shop.Order.OrderItems> { tmpOrderItem });
                        }
                    }
                    else
                    {
                        if (dicSuppOrderItems.ContainsKey(0))
                        {
                            dicSuppOrderItems[0].Add(tmpOrderItem);
                        }
                        else
                        {
                            dicSuppOrderItems.Add(0,
                                new List<YSWL.MALL.Model.Shop.Order.OrderItems> { tmpOrderItem });
                        }
                    }
                }
            }
            #endregion

            #region 收货人信息

            mainOrder.RegionId = shippingAddress?.RegionId ?? -1;
            mainOrder.ShipRegion = shippingAddress != null ? shippingAddress.RegionFullName : ""; //_regionManage.GetFullNameById4Cache(regionInfo.RegionId);
            mainOrder.ShipName = shippingAddress != null ? shippingAddress.ShipName : "";
            mainOrder.ShipEmail = shippingAddress != null ? shippingAddress.EmailAddress : "";
            mainOrder.ShipCellPhone = shippingAddress != null ? (!string.IsNullOrEmpty(phone) ? phone : shippingAddress.CelPhone) : phone;
            mainOrder.ShipTelPhone = shippingAddress != null ? shippingAddress.TelPhone : "";
            mainOrder.ShipAddress = shippingAddress != null ? (!string.IsNullOrEmpty(address) ? address : shippingAddress.Address) : address;
            mainOrder.ShipZipCode = shippingAddress != null ? shippingAddress.Zipcode : "";

            #endregion

            #region 绑定线路信息

            bool IsBindLine = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("CRM_BindLine_IsOpen");
            if (IsBindLine)
            {
                mainOrder.LineId = shippingAddress.LineId;
                mainOrder.LineName = lineBll.GetLineName(mainOrder.LineId);
            }

            #endregion

            #region 配送信息(物流)
            //配送日期
            //mainOrder.ShipDate = date;

            mainOrder.ShippingModeId = shippingType.ModeId;
            mainOrder.ShippingModeName = shippingType.Name;
            mainOrder.RealShippingModeId = shippingType.ModeId;
            mainOrder.RealShippingModeName = shippingType.Name;
            mainOrder.ShippingStatus = 0;
            mainOrder.ExpressCompanyName = shippingType.ExpressCompanyName;
            mainOrder.ExpressCompanyAbb = shippingType.ExpressCompanyEn;

            #endregion

            #region 自动拆单
            int subOrderIndex = 1;
            //判断是否购买了多个商家的商品, 并进行拆单
            if (dicSuppOrderItems.Count > 1)
            {
                #region 拆单逻辑
                decimal discountAmount = mainOrder.CouponAmount.HasValue ? mainOrder.CouponAmount.Value : 0;
                var SuppOrderItems = from pair in dicSuppOrderItems orderby pair.Key select pair;
                foreach (KeyValuePair<int, List<YSWL.MALL.Model.Shop.Order.OrderItems>> item in dicSuppOrderItems)
                {
                    //根据主订单构造子订单
                    OrderInfo subOrder = new OrderInfo(mainOrder);

                    #region 子订单基础数据
                    //DONE: 防止运算过快产生相同订单号
                    subOrder.CreatedDate = mainOrder.CreatedDate.AddMilliseconds(subOrderIndex++);
                    if (codePre)
                    {
                        subOrder.OrderCode = subOrder.ReferOrderPrefix + subOrder.CreatedDate.ToString("yyyyMMddHHmmssfff");
                    }
                    else
                    {
                        subOrder.OrderCode = subOrder.CreatedDate.ToString("yyyyMMddHHmmssfff");
                    }
                    #endregion

                    #region Reset 重量/运费/积分/价格
                    subOrder.Weight = 0;
                    subOrder.FreightAdjusted =
                        subOrder.FreightActual =
                            subOrder.Freight = 0;
                    subOrder.OrderPoint = 0;

                    subOrder.ProductTotal = 0;
                    subOrder.OrderCostPrice = 0;
                    subOrder.OrderOptionPrice = 0;
                    subOrder.OrderProfit = 0;
                    subOrder.Amount = 0;
                    subOrder.DiscountAdjusted = 0;
                    #endregion

                    #region 清空限时抢购
                    subOrder.ActivityName = null;
                    subOrder.ActivityFreeAmount = null;
                    subOrder.ActivityStatus = 0;
                    #endregion

                    #region 清空团购数据
                    subOrder.GroupBuyId = null;
                    subOrder.GroupBuyPrice = null;
                    subOrder.GroupBuyStatus = 0;
                    #endregion
                    #region 填充子单商家信息
                    subOrder.SupplierId = item.Key;
                    if (!YSWL.MALL.BLL.Shop.Order.OrderManage.FillSellerInfo(subOrder))
                    {
                        //result.Accumulate(KEY_STATUS, "NOSUPPLIERINFO");
                        return new Result(ResultStatus.Failed, "NOSUPPLIERINFO");
                    }
                    #endregion

                    #region 重新计算 重量/积分/价格
                    item.Value.ForEach(info =>
                    {
                        info.OrderCode = subOrder.OrderCode;
                        subOrder.Weight += info.Weight * info.Quantity;
                        subOrder.OrderPoint += info.Points * info.Quantity;
                        //订单商品总价(无优惠)
                        subOrder.ProductTotal += info.SellPrice * info.Quantity;
                        //订单总成本价 = 项目总成本价
                        subOrder.OrderCostPrice += info.CostPrice * info.Quantity;
                        //订单最终支付金额 = 商品总价
                        subOrder.Amount += info.AdjustedPrice * info.Quantity;
                        subOrder.DiscountAdjusted += (info.SellPrice - info.AdjustedPrice) * info.Quantity;
                    });


                    //DONE: 均摊运费 (根据重量均摊)
                    subOrder.Freight = subOrder.FreightActual = mainOrder.Freight <= 0 ? 0 : (mainOrder.Freight.Value * (decimal)(subOrder.Weight.Value * 1.00 / mainOrder.Weight.Value));
                    subOrder.FreightAdjusted = mainOrder.FreightAdjusted <= 0 ? 0 : (mainOrder.FreightAdjusted.Value * (decimal)(subOrder.Weight.Value * 1.00 / mainOrder.Weight.Value));




                    //订单总金额(含优惠) 商品总价 + 运费
                    subOrder.OrderTotal = subOrder.ProductTotal + subOrder.Freight.Value;
                    //订单最终支付金额 = 商品总价(含优惠) + 调整后运费
                    subOrder.Amount += subOrder.FreightAdjusted.Value;
                    //TODO: 均分主订单的优惠给子订单, 作为退款使用
                    #endregion

                    #region 总价优惠拆单处理
                    if (totalRate > 0)
                    {
                        if (subOrder.Amount > 0)
                        {
                            decimal subTotalRate = totalRate - subOrder.Amount > 0 ? totalRate - subOrder.Amount : 0;
                            subOrder.DiscountAdjusted = subTotalRate > 0
                                                            ? subOrder.DiscountAdjusted + subOrder.Amount
                                                            : subOrder.DiscountAdjusted + totalRate;
                            subOrder.Amount = subTotalRate > 0 ? 0 : subOrder.Amount - totalRate;
                            totalRate = subTotalRate;
                        }
                    }
                    #endregion

                    #region 主订单的优惠券金额给平台
                    //DONE: 主订单的优惠券金额给平台

                    if (discountAmount > 0)
                    {
                        if (subOrder.Amount > 0)
                        {
                            decimal subCoupontAmount = discountAmount - subOrder.Amount > 0 ? discountAmount - subOrder.Amount : 0;
                            subOrder.CouponAmount = subCoupontAmount > 0 ? subOrder.Amount : discountAmount;
                            subOrder.CouponValue = subCoupontAmount > 0 ? subOrder.Amount : subOrder.CouponValue;
                            subOrder.Amount = subCoupontAmount > 0 ? 0 : subOrder.Amount - discountAmount;
                            subOrder.CouponValueType = 1;
                            discountAmount = subCoupontAmount;
                        }
                        else
                        {
                            subOrder.CouponAmount = null;
                            subOrder.CouponCode = null;
                            subOrder.CouponName = null;
                            subOrder.CouponValue = null;
                            subOrder.CouponValueType = null;
                        }
                    }

                    #endregion



                    #endregion

                    //订单项目
                    subOrder.OrderItems = item.Value;
                    subOrder.OrderType = 2;
                    mainOrder.SubOrders.Add(subOrder);
                }
                mainOrder.HasChildren = true;   //有子订单
            }
            else
            {
                //没有购买多个商家的商品
                mainOrder.SupplierId = shoppingCartInfo.Items[0].SupplierId;
                mainOrder.SupplierName = shoppingCartInfo.Items[0].SupplierName;
                mainOrder.HasChildren = false;  //无子订单
            }
            #endregion

            #region 填充主单商家信息
            if (!YSWL.MALL.BLL.Shop.Order.OrderManage.FillSellerInfo(mainOrder))
            {
                return new Result(ResultStatus.Failed, "NOSUPPLIERINFO");
                //  result.Accumulate(KEY_STATUS, "NOSUPPLIERINFO");
                // return result.ToString();
            }
            #endregion

            #region 订单分销逻辑

            #endregion

            #endregion

            #region 执行事务-创建订单
            try
            {
                mainOrder.OrderId = YSWL.MALL.BLL.Shop.Order.OrderManage.CreateOrderPos(mainOrder, depotId);
                if (mainOrder.OrderId > 0)
                {
                    jsonObject.Put("orderid", mainOrder.OrderId);
                    jsonObject.Put("orderCode", mainOrder.OrderCode);
                    jsonObject.Put("allprice", mainOrder.Amount.ToString("F"));
                    jsonObject.Put("realPrice", realPrice);
                    jsonObject.Put("paymenttype", mainOrder.PaymentTypeName);

                    #region 生成促销活动优惠劵
                    activInfoBll.GenerateData(mainOrder, actInfoList);
                    #endregion
                    //更新优惠券信息
                    if (!String.IsNullOrWhiteSpace(mainOrder.CouponCode))
                    {
                        couponBLL.UseCoupon(couponCode, mainOrder.BuyerID, mainOrder.BuyerEmail);
                    }

                    //更新团购信息
                    if (groupBuyId > 0)
                    {
                        groupBuyBll.UpdateBuyCount(groupBuyId, shoppingCartInfo.Quantity);
                    }

                    #region 订单邮件推送
                    bool IsOpenEmail = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("System_Open_OrderEmail");
                    if (IsOpenEmail)
                    {
                        YSWL.MALL.BLL.Ms.EmailTemplet templetBll = new YSWL.MALL.BLL.Ms.EmailTemplet();
                        templetBll.SendOrderEmail(mainOrder, userModel.Email);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Log.LogHelper.AddErrorLog("订单创建失败: " + ex.Message, ex.StackTrace);
                return new Result(ResultStatus.Error, ex);
            }
            #endregion

            #endregion
            return new Result(ResultStatus.Success, jsonObject);
        }

        #endregion

        #region 修改支付状态

        [JsonRpcMethod("ModifyPayStatus", Idempotent = false)]
        [JsonRpcHelp("修改支付状态")] //这个接口后期需要拆分
        public JsonObject ModifyPayStatus(long orderId = -1)
        {
            if (orderId == -1)
            {
                return new Result(ResultStatus.Failed, "noorder");
            }
            YSWL.MALL.Model.Shop.Order.OrderInfo order = orderBll.GetModel(orderId);
            if (order == null)
            {
                return new Result(ResultStatus.Failed, "noorder");
            }
            order.PaymentStatus = (int)YSWL.MALL.Model.Shop.Order.EnumHelper.PaymentStatus.Paid;
            return orderBll.Update(order) ? new Result(ResultStatus.Success, "") : new Result(ResultStatus.Failed, "fail");
        }

        #endregion

        #region 销售统计

        [JsonRpcMethod("GetSalesTotal", Idempotent = false)]
        [JsonRpcHelp("获取销售统计")]
        public JsonObject GetSalesTotal(int userid, DateTime startTime, DateTime endTime)
        {
            int referType = 6;
            startTime = Common.Globals.SafeDateTime(startTime.ToShortDateString() + " 00:00:00", DateTime.Now);
            endTime = Common.Globals.SafeDateTime(endTime.ToShortDateString() + " 23:59:59", DateTime.Now);

            JsonObject result = new JsonObject();
            //销售总额和订单数
            result.Put("order", orderBll.GetOrderCountAmountByUser(userid, startTime, endTime, referType));

            JsonObject paid = new JsonObject();
            //已收金额
            paid.Put("paidamount", orderBll.GetPaidAmountByUser(userid, startTime, endTime, referType));
            //未收金额
            paid.Put("unpaidamount", orderBll.GetUnPaidAmountByUser(userid, startTime, endTime, referType));
            result.Put("paid", paid);

            //支付来源
            List<ViewModel.Order.Payment> paymentData = orderBll.GetPaymentByUser(userid, startTime, endTime, referType);
            JsonObject payment = new JsonObject();
            if (paymentData != null)
            {
                decimal payamount = paymentData.Sum(i => i.Amount);
                payment.Put("paymentamount", payamount);
            }
            else
            {
                payment.Put("paymentamount", null);
            }
            payment.Put("paymentdata", paymentData);
            result.Put("payment", payment);

            //商品相关统计
            List<YSWL.MALL.Model.Shop.Order.OrderItems> orderItems = orderBll.GetOrderItemByUser(userid, startTime, endTime, referType);
            JsonObject product = new JsonObject();
            if (orderItems.Any())
            {
                var productItem = from t in orderItems
                                  group t by new { t.ProductId, t.Name, t.Attribute } into g
                                  select new { name = g.Key.Name, pid = g.Key.ProductId, attr = g.Key.Attribute, count = g.Sum(t => t.ShipmentQuantity) };

                product.Put("procount", orderItems.Sum(t => t.Quantity));
                product.Put("prodata", productItem.OrderByDescending(t=>t.count));
            }
            else
            {
                product.Put("procount", 0);
                product.Put("prodata", null);
            }
            result.Put("product", product);
            return new Result(ResultStatus.Success, result);
        }

        #endregion

        #region 获取购物车列表
        [JsonRpcMethod("GetCartList", Idempotent = false)]
        [JsonRpcHelp("获取购物车列表")]  //这个接口后期需要拆分
        public JsonObject GetCartList(JsonArray productList, int userId)
        {
            if (productList == null)
            {
                return new Result(ResultStatus.Failed, null);
            }
            JsonObject result = new JsonObject();
            JsonArray array = new JsonArray(); ;
            JsonObject json;
            ShoppingCartInfo shoppingCartInfo;
            try
            {
                shoppingCartInfo = GetCart(productList, userId);
            }
            catch (ArgumentNullException)
            {
                return new Result(ResultStatus.Failed, "PROSALEEXPIRED");
            }
            if (shoppingCartInfo == null ||
                shoppingCartInfo.Items == null ||
                shoppingCartInfo.Items.Count < 1)
            {
                return new Result(ResultStatus.Failed, "NOSHOPPINGCARTINFO");
            }
            bool openAlertStock = YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_OpenAlertStock");
            foreach (var item in shoppingCartInfo.Items)
            {
                json = new JsonObject();
                json.Put("id", item.ProductId);
                json.Put("name", item.Name);
                json.Put("number", item.Quantity);
                #region 远程加载数据图片
                if (YSWL.Components.MvcApplication.IsAutoConn)
                {
                    json.Put("pic", String.IsNullOrWhiteSpace(item.ThumbnailsUrl) ? item.ThumbnailsUrl : item.ThumbnailsUrl.Replace("/Upload/", mdmUrl + "/Upload/"));
                }
                else
                {
                    json.Put("pic", item.ThumbnailsUrl);
                }
                #endregion

                json.Put("marketprice", item.MarketPrice.ToString("F"));
                json.Put("saleprice", item.SellPrice.ToString("F"));
                json.Put("adjustedPrice", item.AdjustedPrice.ToString("F"));
                json.Put("sku", item.SKU);
                json.Put("limitQty", item.RestrictionCount);//限购数量
                if (openAlertStock) //开启警戒库存
                {
                    if (item.Stock > item.AlertStock)
                    {
                        json.Put("hasStock", true);
                        json.Put("stockcount", item.Stock);
                    }
                    else
                    {
                        json.Put("hasStock", false);
                    }
                }
                else
                {
                    if (item.Stock > 0)
                    {
                        json.Put("hasStock", true);
                        json.Put("stockcount", item.Stock);
                    }
                    else
                    {
                        json.Put("hasStock", false);
                    }
                }
                json.Put("saleStatus", item.SaleStatus);//商品上下架状态
                json.Put("saleDes", item.SaleDes);//优惠信息
                array.Add(json);
            }
            result.Put("productList", array);
            result.Put("totalRate", shoppingCartInfo.TotalRate);//总价优惠
            result.Put("totalSellPrice", shoppingCartInfo.TotalSellPrice);//优惠前价格
            result.Put("totalAdjustedPrice", shoppingCartInfo.TotalAdjustedPrice);//调整后价格
            return new Result(ResultStatus.Success, result);
        }
        #endregion
        private ShoppingCartInfo GetCart(JsonArray jsonSku, int userId)
        {
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            JsonObject skuItem;
            if (null != jsonSku && jsonSku.Length > 0)
            {
                for (int i = 0; i < jsonSku.Length; i++)
                {
                    skuItem = jsonSku.GetObject(i);
                    string sku = skuItem["sku"].ToString();
                    int count = Globals.SafeInt(skuItem["number"].ToString(), 1);
                    YSWL.MALL.Model.Shop.Products.SKUInfo skuInfo = skuBLL.GetModelBySKU(sku);
                    if (skuInfo == null) continue; //异常数据
                    YSWL.MALL.Model.Shop.Products.ProductInfo productInfo = productManage.GetModel(skuInfo.ProductId);
                    if (productInfo == null) continue; //异常数据
                    YSWL.MALL.Model.Shop.Products.ShoppingCartItem itemInfo = new ShoppingCartItem();
                    itemInfo.MarketPrice = productInfo.MarketPrice.HasValue ? productInfo.MarketPrice.Value : 0;
                    itemInfo.Name = productInfo.ProductName;
                    itemInfo.Quantity = count;
                    itemInfo.SellPrice = skuInfo.SalePrice;
                    itemInfo.AdjustedPrice = skuInfo.SalePrice;
                    itemInfo.SKU = skuInfo.SKU;
                    itemInfo.Stock = skuInfo.Stock;
                    itemInfo.AlertStock = skuInfo.AlertStock;
                    itemInfo.ProductId = skuInfo.ProductId;
                    itemInfo.UserId = userId;
                    itemInfo.BrandId = productInfo.BrandId;
                    itemInfo.SaleStatus = productInfo.SaleStatus;
                    //DONE: 根据SkuId 获取SKUItem值和图片数据 BEN 2013-06-30
                    //List<YSWL.MALL.Model.Shop.Products.SKUItem> listSkuItems = skuBLL.GetSKUItemsBySkuId(skuInfo.SkuId);
                    //if (listSkuItems != null && listSkuItems.Count > 0)
                    //{
                    //    itemInfo.SkuValues = new string[listSkuItems.Count];
                    //    int index = 0;
                    //    listSkuItems.ForEach(xx =>
                    //    {
                    //        itemInfo.SkuValues[index++] = xx.ValueStr;
                    //        if (!string.IsNullOrWhiteSpace(xx.ImageUrl))
                    //        {
                    //            itemInfo.SkuImageUrl = xx.ImageUrl;
                    //        }
                    //    });
                    //}

                    itemInfo.ThumbnailsUrl = productInfo.ThumbnailUrl1;
                    itemInfo.CostPrice = skuInfo.CostPrice.HasValue ? skuInfo.CostPrice.Value : 0;
                    itemInfo.Weight = skuInfo.Weight.HasValue ? skuInfo.Weight.Value : 0;
                    itemInfo.Points = (int)(productInfo.Points.HasValue ? productInfo.Points.Value : 0);
                    itemInfo.SupplierId = productInfo.SupplierId;
                    itemInfo.RestrictionCount = productInfo.RestrictionCount;
                    shoppingCartInfo.Items.Add(itemInfo);


                }
                #region 批销优惠
                try
                {
                    YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct salesRule =
                        new YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct();
                    shoppingCartInfo = salesRule.GetWholeSale(shoppingCartInfo);
                }
                catch (System.Exception ex)
                {
                    throw new Exception("获取批销优惠异常,位置：" + ex.StackTrace);
                }
                #endregion
                return shoppingCartInfo;
            }
            return null;
        }
        private ShoppingCartInfo GetShoppingCart(JsonArray jsonSku, int userId, int prosaleId = -1, int groupbuyId = -1, int regionId = -1)
        {
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            JsonObject skuItem;
            if (null != jsonSku && jsonSku.Length > 0)
            {
                for (int i = 0; i < jsonSku.Length; i++)
                {
                    skuItem = jsonSku.GetObject(i);
                    string sku = skuItem["SKU"].ToString();
                    int count = Globals.SafeInt(skuItem["Count"].ToString(), 1);
                    YSWL.MALL.Model.Shop.Products.SKUInfo skuInfo = skuBLL.GetModelBySKU(sku);
                    if (skuInfo == null) return null;
                    YSWL.MALL.Model.Shop.Products.ProductInfo productInfo = productManage.GetModel(skuInfo.ProductId);
                    if (productInfo == null) return null;
                    YSWL.MALL.Model.Shop.Products.ShoppingCartItem itemInfo = new ShoppingCartItem();
                    itemInfo.MarketPrice = productInfo.MarketPrice.HasValue ? productInfo.MarketPrice.Value : 0;
                    itemInfo.Name = productInfo.ProductName;
                    itemInfo.Quantity = count;
                    itemInfo.SellPrice = skuInfo.SalePrice;
                    itemInfo.AdjustedPrice = skuInfo.SalePrice;
                    itemInfo.SKU = skuInfo.SKU;
                    itemInfo.ProductId = skuInfo.ProductId;
                    itemInfo.UserId = userId;
                    itemInfo.BrandId = productInfo.BrandId;

                    //是否对接多仓，处理逻辑
                    bool IsMultiDepot = YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot();
                    itemInfo.Stock = IsMultiDepot ? YSWL.MALL.BLL.Shop.Products.StockHelper.GetSkuStockByCache(sku, regionId, productInfo.SupplierId) : skuInfo.Stock;
                    #region 限时抢购处理

                    if (prosaleId > 0 && groupbuyId > 0) return null;//既是限时抢购又是团购
                    if (prosaleId > 0)
                    {
                        YSWL.MALL.Model.Shop.Products.ProductInfo proSaleInfo = productManage.GetProSaleModel(prosaleId);
                        if (proSaleInfo == null) return null;

                        //活动已过期 重定向到单品页
                        if (DateTime.Now > proSaleInfo.ProSalesEndDate)
                            throw new ArgumentNullException("活动已过期");

                        //重置价格为 限时抢购价
                        itemInfo.AdjustedPrice = proSaleInfo.ProSalesPrice;
                    }

                    #endregion

                    #region 团购处理

                    if (groupbuyId > 0)
                    {
                        YSWL.MALL.Model.Shop.Products.ProductInfo groupBuyInfo =
                            productManage.GetGroupBuyModel(groupbuyId);
                        if (groupBuyInfo == null) return null;

                        //活动已过期 重定向到单品页
                        if (DateTime.Now > groupBuyInfo.GroupBuy.EndDate)
                            throw new ArgumentNullException("活动已过期");

                        //重置价格为 限时抢购价
                        itemInfo.AdjustedPrice = groupBuyInfo.GroupBuy.Price;
                    }

                    #endregion


                    //DONE: 根据SkuId 获取SKUItem值和图片数据 BEN 2013-06-30
                    List<YSWL.MALL.Model.Shop.Products.SKUItem> listSkuItems = skuBLL.GetSKUItemsBySkuId(skuInfo.SkuId);
                    if (listSkuItems != null && listSkuItems.Count > 0)
                    {
                        itemInfo.SkuValues = new string[listSkuItems.Count];
                        int index = 0;
                        listSkuItems.ForEach(xx =>
                        {
                            itemInfo.SkuValues[index++] = xx.ValueStr;
                            if (!string.IsNullOrWhiteSpace(xx.ImageUrl))
                            {
                                itemInfo.SkuImageUrl = xx.ImageUrl;
                            }
                        });
                    }

                    itemInfo.ThumbnailsUrl = productInfo.ThumbnailUrl1;
                    itemInfo.CostPrice = skuInfo.CostPrice.HasValue ? skuInfo.CostPrice.Value : 0;
                    itemInfo.Weight = skuInfo.Weight.HasValue ? skuInfo.Weight.Value : 0;
                    itemInfo.Points = (int)(productInfo.Points.HasValue ? productInfo.Points.Value : 0);

                    #region 商家Id

                    YSWL.MALL.BLL.Shop.Supplier.SupplierInfo supplierManage =
                        new YSWL.MALL.BLL.Shop.Supplier.SupplierInfo();
                    YSWL.MALL.Model.Shop.Supplier.SupplierInfo supplierInfo =
                        supplierManage.GetModelByCache(productInfo.SupplierId);
                    if (supplierInfo != null)
                    {
                        itemInfo.SupplierId = supplierInfo.SupplierId;
                        itemInfo.SupplierName = supplierInfo.Name;
                    }

                    #endregion

                    shoppingCartInfo.Items.Add(itemInfo);

                }
                #region 批销优惠
                if (prosaleId < 1 && groupbuyId < 1) //限时抢购/团购/组合优惠套装　不参与批销优惠
                {
                    try
                    {
                        YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct salesRule =
                            new YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct();
                        shoppingCartInfo = salesRule.GetWholeSale(shoppingCartInfo);
                    }
                    catch (System.Exception ex)
                    {
                        throw new Exception("获取批销优惠异常,位置：" + ex.StackTrace);
                    }
                }

                #endregion
                return shoppingCartInfo;
            }
            return null;
        }

        private ShoppingCartInfo GetShoppingCartByDepotId(JsonArray jsonSku, int userId, int prosaleId = -1, int groupbuyId = -1, int depotid = -1)
        {
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            JsonObject skuItem;
            if (null != jsonSku && jsonSku.Length > 0)
            {
                for (int i = 0; i < jsonSku.Length; i++)
                {
                    skuItem = jsonSku.GetObject(i);
                    string sku = skuItem["SKU"].ToString();
                    int count = Globals.SafeInt(skuItem["Count"].ToString(), 1);
                    decimal adjustPrice = Globals.SafeDecimal(skuItem["AdjustPrice"], 0);
                    YSWL.MALL.Model.Shop.Products.SKUInfo skuInfo = skuBLL.GetModelBySKU(sku);
                    if (skuInfo == null) return null;
                    YSWL.MALL.Model.Shop.Products.ProductInfo productInfo = productManage.GetModel(skuInfo.ProductId);
                    if (productInfo == null) return null;
                    YSWL.MALL.Model.Shop.Products.ShoppingCartItem itemInfo = new ShoppingCartItem();
                    itemInfo.MarketPrice = productInfo.MarketPrice.HasValue ? productInfo.MarketPrice.Value : 0;
                    itemInfo.Name = productInfo.ProductName;
                    itemInfo.Quantity = count;
                    itemInfo.SellPrice = skuInfo.SalePrice;
                    itemInfo.AdjustedPrice = adjustPrice;
                    itemInfo.SKU = skuInfo.SKU;
                    itemInfo.ProductId = skuInfo.ProductId;
                    itemInfo.UserId = userId;
                    itemInfo.BrandId = productInfo.BrandId;

                    //是否对接多仓，处理逻辑
                    bool IsMultiDepot = YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot();
                    itemInfo.Stock = IsMultiDepot ? YSWL.MALL.BLL.Shop.Products.StockHelper.GetSkuStockByCacheDepotId(sku, depotid, productInfo.SupplierId) : skuInfo.Stock;

                    #region 限时抢购处理

                    //if (prosaleId > 0 && groupbuyId > 0) return null;//既是限时抢购又是团购
                    //if (prosaleId > 0)
                    //{
                    //    YSWL.MALL.Model.Shop.Products.ProductInfo proSaleInfo = productManage.GetProSaleModel(prosaleId);
                    //    if (proSaleInfo == null) return null;

                    //    //活动已过期 重定向到单品页
                    //    if (DateTime.Now > proSaleInfo.ProSalesEndDate)
                    //        throw new ArgumentNullException("活动已过期");

                    //    //重置价格为 限时抢购价
                    //    itemInfo.AdjustedPrice = proSaleInfo.ProSalesPrice;
                    //}

                    #endregion

                    #region 团购处理

                    //if (groupbuyId > 0)
                    //{
                    //    YSWL.MALL.Model.Shop.Products.ProductInfo groupBuyInfo =
                    //        productManage.GetGroupBuyModel(groupbuyId);
                    //    if (groupBuyInfo == null) return null;

                    //    //活动已过期 重定向到单品页
                    //    if (DateTime.Now > groupBuyInfo.GroupBuy.EndDate)
                    //        throw new ArgumentNullException("活动已过期");

                    //    //重置价格为 限时抢购价
                    //    itemInfo.AdjustedPrice = groupBuyInfo.GroupBuy.Price;
                    //}

                    #endregion


                    //DONE: 根据SkuId 获取SKUItem值和图片数据 BEN 2013-06-30
                    List<YSWL.MALL.Model.Shop.Products.SKUItem> listSkuItems = skuBLL.GetSKUItemsBySkuId(skuInfo.SkuId);
                    if (listSkuItems != null && listSkuItems.Count > 0)
                    {
                        itemInfo.SkuValues = new string[listSkuItems.Count];
                        int index = 0;
                        listSkuItems.ForEach(xx =>
                        {
                            itemInfo.SkuValues[index++] = xx.ValueStr;
                            if (!string.IsNullOrWhiteSpace(xx.ImageUrl))
                            {
                                itemInfo.SkuImageUrl = xx.ImageUrl;
                            }
                        });
                    }

                    itemInfo.ThumbnailsUrl = productInfo.ThumbnailUrl1;
                    itemInfo.CostPrice = skuInfo.CostPrice.HasValue ? skuInfo.CostPrice.Value : 0;
                    itemInfo.Weight = skuInfo.Weight.HasValue ? skuInfo.Weight.Value : 0;
                    itemInfo.Points = (int)(productInfo.Points.HasValue ? productInfo.Points.Value : 0);

                    #region 商家Id

                    YSWL.MALL.BLL.Shop.Supplier.SupplierInfo supplierManage =
                        new YSWL.MALL.BLL.Shop.Supplier.SupplierInfo();
                    YSWL.MALL.Model.Shop.Supplier.SupplierInfo supplierInfo =
                        supplierManage.GetModelByCache(productInfo.SupplierId);
                    if (supplierInfo != null)
                    {
                        itemInfo.SupplierId = supplierInfo.SupplierId;
                        itemInfo.SupplierName = supplierInfo.Name;
                    }

                    #endregion

                    shoppingCartInfo.Items.Add(itemInfo);

                }

                #region 批销优惠

                //if (prosaleId < 1 && groupbuyId < 1) //限时抢购/团购/组合优惠套装　不参与批销优惠
                //{
                //    try
                //    {
                //        YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct salesRule =
                //            new YSWL.MALL.BLL.Shop.Sales.SalesRuleProduct();
                //        shoppingCartInfo = salesRule.GetWholeSale(shoppingCartInfo);
                //    }
                //    catch (System.Exception ex)
                //    {
                //        throw new Exception("获取批销优惠异常,位置：" + ex.StackTrace);
                //    }
                //}

                #endregion

                return shoppingCartInfo;
            }
            return null;
        }

        #region  获取金额
        /// <summary>
        /// 获取金额 
        /// </summary>
        /// <returns></returns>
        [JsonRpcMethod("GetTotalPrice", Idempotent = false)]
        [JsonRpcHelp("获取金额")]
        public JsonObject GetTotalPrice(int userId, JsonArray productList, int proSaleId = -1, int groupBuyId = -1)
        {
            if (userId < 1)
            {
                return new Result(ResultStatus.Failed, "USERDATAERROR");
            }
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            try
            {
                shoppingCartInfo = GetShoppingCart(productList, userId, proSaleId, groupBuyId);
            }
            catch (ArgumentNullException)
            {
                return new Result(ResultStatus.Failed, "PROSALEEXPIRED");
            }
            if (shoppingCartInfo == null ||
               shoppingCartInfo.Items == null ||
               shoppingCartInfo.Items.Count < 1)
            {
                return new Result(ResultStatus.Failed, "NOSHOPPINGCARTINFO");
            }
            JsonObject json = new JsonObject();
            json.Put("totalAdjustedPrice", shoppingCartInfo.TotalAdjustedPrice.ToString());
            json.Put("totalSellPrice", shoppingCartInfo.TotalSellPrice.ToString());
            return new Result(ResultStatus.Success, json.ToString());
        }
        #endregion


        [JsonRpcMethod("GetPayList", Idempotent = false)]
        [JsonRpcHelp("获取支付方式")]
        public JsonObject GetPayList()
        {
            List<YSWL.Payment.Model.PaymentModeInfo> paylist = YSWL.Payment.BLL.PaymentModeManage.GetPaymentModes(YSWL.Payment.Model.DriveEnum.Wap);
            if (paylist == null)
            {
                return new Result(ResultStatus.Success, null);
            }
            JsonArray result = new JsonArray();
            JsonObject baseJson;
            foreach (YSWL.Payment.Model.PaymentModeInfo item in paylist)
            {
                #region 不返回微信支付
                if (item.Gateway == "wechat")
                {
                    continue;
                }
                #endregion

                #region 如果是拉卡拉支付状态
                //if (item.Gateway == "lakala")
                //{
                //    baseJson = new JsonObject();
                //    baseJson.Put("id", item.ModeId);
                //    baseJson.Put("name", "银行卡支付");
                //    baseJson.Put("description", item.Description);
                //    result.Add(baseJson);
                //    baseJson = new JsonObject();
                //    baseJson.Put("id", item.ModeId);
                //    baseJson.Put("name", "扫码支付");
                //    baseJson.Put("description", item.Description);
                //    result.Add(baseJson);
                //    continue;
                //}
                #endregion

                baseJson = new JsonObject();
                baseJson.Put("id", item.ModeId);
                baseJson.Put("name", item.Name);
                baseJson.Put("description", item.Description);
                result.Add(baseJson);
            }
            return new Result(ResultStatus.Success, result);
        }
        [JsonRpcMethod("GetShipList", Idempotent = false)]
        [JsonRpcHelp("获取配送方式")]
        public JsonObject GetShipList(int payId = -1)
        {
            //List<YSWL.MALL.Model.Shop.Shipping.ShippingType> list = _shippingTypeManage.GetListByPay(payId);
            List<YSWL.MALL.Model.Shop.Shipping.ShippingType> list = _shippingTypeManage.GetModelList("");
            if (list == null)
            {
                return new Result(ResultStatus.Success, null);
            }
            JsonArray result = new JsonArray();
            JsonObject baseJson;
            foreach (YSWL.MALL.Model.Shop.Shipping.ShippingType item in list)
            {
                baseJson = new JsonObject();
                baseJson.Put("id", item.ModeId);
                baseJson.Put("name", item.Name);
                baseJson.Put("description", item.Description);
                result.Add(baseJson);
            }
            return new Result(ResultStatus.Success, result);
        }

        #region 获取运费
        /// <summary>
        /// 获取运费
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="shipId">收货地址Id</param>
        /// <param name="shipTypeId">配送方式Id</param>
        /// <param name="productList">购物车商品</param>
        /// <returns></returns>
        [JsonRpcMethod("GetFreight", Idempotent = false)]
        [JsonRpcHelp("获取运费")]
        public JsonObject GetFreight(int userId, int shipId, int shipTypeId, JsonArray productList)
        {
            JsonObject jsonObject = new JsonObject();
            decimal Freight = 0;
            #region 获取购物车
            ShoppingCartInfo shoppingCartInfo = new ShoppingCartInfo();
            try
            {
                shoppingCartInfo = GetShoppingCart(productList, userId, -1, -1);
            }
            catch (ArgumentNullException)
            {
                jsonObject.Put("freight", Freight);
                return new Result(ResultStatus.Success, jsonObject);
                //return new Result(ResultStatus.Success, "PROSALEEXPIRED");
            }
            #endregion

            #region 获取收货地址及地区
            YSWL.MALL.Model.Shop.Shipping.ShippingAddress shippingAddress = _addressManage.GetModelByCache(shipId);
            if (shippingAddress == null)
            {
                jsonObject.Put("freight", Freight);
                return new Result(ResultStatus.Success, jsonObject);
                //return new Result(ResultStatus.Failed, "noReceiverInfo");
            }
            YSWL.MALL.Model.Ms.Regions regionInfo = regionsBLL.GetModelByCache(shippingAddress.RegionId);
            if (regionInfo == null)
            {
                jsonObject.Put("freight", Freight);
                return new Result(ResultStatus.Success, jsonObject);
                //return new Result(ResultStatus.Failed, "noRehionInfo");
            }
            #endregion

            #region 获取配送(物流)
            YSWL.MALL.Model.Shop.Shipping.ShippingType shippingType = _shippingTypeManage.GetModelByCache(shipTypeId);
            if (shippingType == null)
            {
                jsonObject.Put("freight", Freight);
                return new Result(ResultStatus.Success, jsonObject);
                //return new Result(ResultStatus.Failed, "NOSHIPPINGTYPE");
            }
            #endregion

            #region 区域差异运费计算
            int topRegionId;
            if (regionInfo.Depth > 1)
            {
                topRegionId = Globals.SafeInt(regionInfo.Path.Split(new[] { ',' })[1], -1);
            }
            else
            {
                topRegionId = regionInfo.RegionId;
            }

            YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups shippingRegion =
                _shippingRegionManage.GetShippingRegion(shippingType.ModeId, topRegionId);
            #endregion

            Freight = shoppingCartInfo.CalcFreight(shippingType, shippingRegion);
            jsonObject.Put("freight", Freight);
            return new Result(ResultStatus.Success, jsonObject);
        }
        #endregion

        #region 地址列表
        [JsonRpcMethod("AddressList", Idempotent = false)]
        [JsonRpcHelp("地址列表")]
        public JsonObject AddressList(int userId, int pageIndex, int pageNum)
        {
            JsonObject jsonResult = new JsonObject();
            List<JsonObject> jsList;
            if (userId < 1)
            {
                return new Result(ResultStatus.Failed, "dataerror");
            }
            pageNum = pageNum < 1 ? 10 : pageNum;
            int totalCount = _addressManage.GetRecordCount(" UserId=" + userId);
            if (totalCount < 1)
            {
                return new Result(ResultStatus.Success, "[]");
            }
            int starIndex = pageIndex > 1 ? (pageIndex - 1) * pageNum + 1 : 0;
            int endIndex = pageIndex * pageNum;
            List<YSWL.MALL.Model.Shop.Shipping.ShippingAddress> attrList =
                _addressManage.GetListByPageEx(" UserId=" + userId, "", starIndex, endIndex);
            if (null != attrList)
            {
                jsList = new List<JsonObject>();
                JsonObject jsonItem;
                foreach (var item in attrList)
                {
                    jsonItem = new JsonObject();
                    jsonItem.Put("id", item.ShippingId);
                    jsonItem.Put("regionId", item.RegionId);
                    jsonItem.Put("regionFullName", item.RegionFullName);
                    jsonItem.Put("name", item.ShipName);
                    jsonItem.Put("phone", item.CelPhone);
                    jsonItem.Put("address", item.Address);
                    jsonItem.Put("zipCode", item.Zipcode);
                    jsonItem.Put("hasDefault", item.IsDefault);
                    jsonItem.Put("email", item.EmailAddress);
                    jsList.Add(jsonItem);
                }
                jsonResult.Put("status", "success");
                jsonResult.Put("result", jsList);
            }
            return jsonResult;
        }
        #endregion

        #region 保存地址
        [JsonRpcMethod("SaveAddress", Idempotent = false)]
        [JsonRpcHelp("保存地址")]
        public JsonObject SaveAddress(int id, int userId, string name, string phonenumber, int regionId,
                                         string address, string zipcode, string celphone, string email)
        {
            JsonObject jsonResult;

            #region 新增地址
            if (id < 1)//新增地址
            {
                jsonResult = new JsonObject();
                if (regionId < 1)
                {
                    jsonResult.Put("response", "saveFailure");
                }
                YSWL.MALL.Model.Shop.Shipping.ShippingAddress modelShip = new YSWL.MALL.Model.Shop.Shipping.ShippingAddress
                {
                    UserId = YSWL.Common.Globals.SafeInt(userId, -1),
                    ShipName = name,
                    RegionId = regionId,
                    Address = address,
                    CelPhone = celphone,
                    Zipcode = zipcode,
                    EmailAddress = email
                };
                if (_addressManage.Add(modelShip) > 0) //新增地址成功
                {
                    jsonResult.Put("response", "saveSuccess");
                }
                else//添加失败 
                {
                    jsonResult.Put("response", "saveFailure");
                }

                //  return jsonResult;
            }
            #endregion

            #region 修改地址
            else//
            {
                jsonResult = new JsonObject();
                YSWL.MALL.Model.Shop.Shipping.ShippingAddress shipModel = _addressManage.GetModelByCache(id);
                if (null != shipModel)
                {
                    shipModel.ShipName = name;
                    shipModel.TelPhone = phonenumber;
                    shipModel.RegionId = YSWL.Common.Globals.SafeInt(regionId, -1);
                    shipModel.Address = address;
                    shipModel.CelPhone = celphone;
                    shipModel.Zipcode = zipcode;
                    shipModel.EmailAddress = email;
                    if (_addressManage.Update(shipModel))
                    {
                        jsonResult.Put("response", "updateSuccess");
                    }
                    else
                    {
                        jsonResult.Put("response", "updateFailure");
                    }

                }
                else
                {
                    jsonResult.Put("response", "updateFailure");
                }

            }
            #endregion

            #region 获取地址列表
            List<YSWL.MALL.Model.Shop.Shipping.ShippingAddress> shipList =
                    _addressManage.GetModelList(" UserId=" + userId);
            List<JsonObject> addList = new List<JsonObject>();
            JsonObject addItem;

            if (null == shipList || shipList.Count < 1)
            {
                jsonResult.Put("addresslist", null);
            }
            else
            {
                jsonResult = new JsonObject();
                foreach (var item in shipList)
                {
                    addItem = new JsonObject();
                    addItem.Put("id", item.ShippingId);
                    addItem.Put("regionId", item.RegionId);
                    addItem.Put("regionFullName", item.RegionFullName);
                    addItem.Put("name", item.ShipName);
                    addItem.Put("phone", item.CelPhone);
                    addItem.Put("address", item.Address);
                    addItem.Put("zipcode", item.Zipcode);
                    addItem.Put("isDefault", item.IsDefault);
                    addItem.Put("email", item.EmailAddress);
                    addList.Add(addItem);
                }
            }
            #endregion

            return new Result(ResultStatus.Success, addList);
        }
        #endregion

        #region 删除地址
        [JsonRpcMethod("DelShippAddress", Idempotent = false)]
        [JsonRpcHelp("删除地址")]
        public JsonObject DelShippAddress(int id, int userId)
        {

            if (id < 1)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            }
            YSWL.MALL.Model.Shop.Shipping.ShippingAddress model = _addressManage.GetModel(id);
            if (model != null && userId == model.UserId)
            {
                try
                {
                    _addressManage.Delete(id);
                    return new Result(ResultStatus.Success, "Success");
                }
                catch (Exception ex)
                {
                    YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(string.Format(HandlerBase.ERROR_MSG_LOG, Request.Headers[HandlerBase.REQUEST_HEADER_METHOD], ex.Message), ex.StackTrace, (HttpRequest)Request);
                    return new Result(ResultStatus.Error, ex);
                }

            }
            return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
        }
        #endregion

        #region 设置默认地址
        [JsonRpcMethod("SetAddressDefault", Idempotent = false)]
        [JsonRpcHelp("设置默认地址")]
        public JsonObject SetDefault(int id, int userId)
        {

            JsonObject jsonResult = new JsonObject();
            if (id < 1)
            {
                jsonResult.Put("status", "failure");
                return jsonResult;
            }
            if (_addressManage.SetDefaultShipAddress(userId, id))
            {
                jsonResult.Put("status", "success");
            }
            else
            {
                jsonResult.Put("status", "failure");
            }
            return jsonResult;
        }
        #endregion
    }
}
