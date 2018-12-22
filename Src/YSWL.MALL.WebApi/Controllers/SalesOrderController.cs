using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using YSWL.Common;
using YSWL.Json;
using YSWL.MALL.BLL.SysManage;
using YSWL.MALL.Model.Members;
using YSWL.MALL.ViewModel.Order;
using YSWL.MALL.WebApi.Models;

namespace YSWL.MALL.WebApi.Controllers
{
    [RoutePrefix("v1.0")]
    public class SalesOrderController : ApiControllerBase
    {
        private readonly BLL.Shop.Order.Orders _orderManage = new BLL.Shop.Order.Orders();
        private readonly BLL.Members.Users _userManage = new BLL.Members.Users();
        private readonly BLL.Shop.Order.OrderAction _actionBll = new BLL.Shop.Order.OrderAction();
        private readonly BLL.Ms.Regions _regionsBll = new BLL.Ms.Regions();
        private readonly BLL.Shop.Products.ProductInfo _productManage = new BLL.Shop.Products.ProductInfo();
        private readonly BLL.Shop.Shipping.ShippingAddress _addressManage = new BLL.Shop.Shipping.ShippingAddress();
        private readonly BLL.Shop.Shipping.ShippingRegionGroups _shippingRegionManage = new BLL.Shop.Shipping.ShippingRegionGroups();
        private readonly BLL.Shop.Shipping.ShippingType _shippingTypeManage = new BLL.Shop.Shipping.ShippingType();
        private readonly BLL.Shop.Coupon.CouponInfo _couponBll = new BLL.Shop.Coupon.CouponInfo();
        private readonly BLL.Shop.Activity.ActivityInfo _activInfoBll = new BLL.Shop.Activity.ActivityInfo();
        private readonly BLL.Shop.PromoteSales.GroupBuy _groupBuyBll = new BLL.Shop.PromoteSales.GroupBuy();
        private readonly BLL.Shop.Products.SKUInfo _skuBll = new BLL.Shop.Products.SKUInfo();
        private YSWL.MALL.BLL.MDM.Line lineBll = new YSWL.MALL.BLL.MDM.Line();

        /// <summary>
        /// MDM域名
        /// </summary>
        private readonly string _mdmPath = YSWL.Common.ConfigHelper.GetConfigString("MDM_Url");

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("salesorder/list")]
        public ResponseResult OrderList([FromUri]ViewModel.Order.OrderRequestVm orderVm, int? page = 1, int pageNum = 30)
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

            if (orderVm == null)
            {
                orderVm = new ViewModel.Order.OrderRequestVm();
            }
            StringBuilder strWhere = new StringBuilder();

            strWhere.AppendFormat(" ReferID='{0}' ", orderVm.salesUserId);

            //主订单
            strWhere.Append(" and OrderType=1 ");

            if (!string.IsNullOrEmpty(orderVm.source))
            {
                strWhere.AppendFormat(" and ReferType{0}6", orderVm.source == "pos" ? "=" : "<>");
            }
            if (orderVm.custUserId > 0)
            {
                if (!_userManage.Exists(orderVm.salesUserId, orderVm.custUserId)) //不是当前用户的客户
                {
                    return FailResult(ResponseCode.Unauthorized, "不是当前用户的客户");
                }
            }
            if (orderVm.custUserId>0)
            {
                strWhere.AppendFormat(" and BuyerID= {0}", orderVm.custUserId);
            }
            //获取订单类型

            #region 订单状态

            switch (orderVm.type)
            {
                //待审核
                case 3:
                    strWhere.Append(@" AND OrderStatus=0 and ((PaymentGateway not in ('cod','bank') and PaymentStatus=2 and ShippingStatus=0) 
                                         or (PaymentGateway = 'cod' and PaymentStatus=0 and ShippingStatus=0))");
                    break;
                //待发货
                case 4:
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

            DateTime? start = YSWL.Common.Globals.SafeDateTime(orderVm.startDate, null);
            DateTime? end = YSWL.Common.Globals.SafeDateTime(orderVm.endDate, null);
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
                string endTime =
                    YSWL.Common.Globals.SafeDateTime(end.Value, DateTime.Now).AddDays(1).ToString("yyyy-MM-dd");
                if (strWhere.Length > 1)
                {
                    strWhere.Append(" and  ");
                }
                strWhere.AppendFormat(" CreatedDate <='" + endTime + "' ");
            }

            #endregion

            //订单号
            if (!String.IsNullOrWhiteSpace(orderVm.keyWords))
            {
                if (strWhere.Length > 1)
                {
                    strWhere.Append(" and  ");
                }
                strWhere.AppendFormat(" ( OrderCode like '%{0}%'  or  BuyerName  like '%{0}%'  )",
                    YSWL.Common.InjectionFilter.SqlFilter(orderVm.keyWords));
            }
            //根据客户名称赛选
            if (!string.IsNullOrEmpty(orderVm.customerName))
            {
                strWhere.AppendFormat(" and BuyerName like '%{0}%'", orderVm.customerName);
            }
            //收货人姓名
            if (!string.IsNullOrEmpty(orderVm.shipName))
            {
                strWhere.AppendFormat(" and ShipName like '%{0}%'", orderVm.shipName);
            }
            //收货人电话
            if (!string.IsNullOrEmpty(orderVm.shipCellPhone))
            {
                strWhere.AppendFormat(" and ShipCellPhone='{0}'", orderVm.shipCellPhone);
            }

            int toalCount = _orderManage.GetRecordCount(strWhere.ToString());
            YSWL.Json.JsonArray jsonArray = new JsonArray();
            JsonObject json;
            List<Model.Shop.Order.OrderInfo> orderList = _orderManage.GetListByPageEX(strWhere.ToString(), "",
                startIndex, endIndex);
            if (orderList == null || orderList.Count <= 0)
            {
                return SuccessResult(jsonArray);
            }

            foreach (Model.Shop.Order.OrderInfo item in orderList)
            {
                json = new JsonObject();
                json.Put("orderId", item.OrderId);
                json.Put("orderCode", item.OrderCode);
                json.Put("mainStatus",
                    _orderManage.GetOrderType(item.PaymentGateway, item.OrderStatus, item.PaymentStatus,
                        item.ShippingStatus));
                //Paying:等待付款,PreHandle:等待处理,Cancel:取消订单,Locking:订单锁定,PreConfirm:等待付款确认,Handling:配货中，Shiped:已发货,Complete:已完成
                //等待付款  可 支付 或 取消 ,  已发货   可 确认收货
                json.Put("mainStatusStr",
                    _orderManage.GetOrderTypeStr(item.PaymentGateway, item.OrderStatus, item.PaymentStatus,
                        item.ShippingStatus));
                json.Put("time", item.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                json.Put("allprice", item.Amount.ToString("F"));
                json.Put("buyerID", item.BuyerID);
                json.Put("buyerName", item.BuyerName); //买家名称即客户名称
                json.Put("sources", _orderManage.GetOrderReferTypeStr(item.ReferType)); //来源

                //暂时实时读取创建人名称  后面要加字段，直接从订单表中获取
                if (item.ReferType.HasValue)
                {
                    switch (item.ReferType.Value)
                    {
                        case (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ReferType.WeChat:
                        case (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ReferType.PC:
                        case (int)YSWL.MALL.Model.Shop.Order.EnumHelper.ReferType.Ding:
                            json.Put("createUser", item.BuyerName);//下单人是客户自己
                            break;
                        default:
                            json.Put("createUser", GetName(_userManage.GetModelByCache(item.CreateUserId)));//获取下单人    返回truename如果没有返回username
                            //获取下单人    返回truename如果没有返回username
                            break;
                    }
                }
                else
                {
                    json.Put("createUser", GetName(_userManage.GetModelByCache(item.CreateUserId)));
                    //获取下单人    返回truename如果没有返回username
                }
                jsonArray.Add(json);
            }
            return SuccessResult(jsonArray);
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("salesorder/detail")]
        public ResponseResult OrderDetail(int salesUserId = 0, int custUserId = 0, long orderId = -1)
        {
            if (salesUserId < 1 || custUserId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            //Safe
            if (!_userManage.Exists(salesUserId, custUserId))//不是当前用户的客户
            {
                return FailResult(ResponseCode.Unauthorized, "不是当前用户的客户");
            }

            YSWL.MALL.Model.Shop.Order.OrderInfo orderModel = _orderManage.GetModelInfo(orderId);

            if (orderModel == null || orderModel.BuyerID != custUserId)
            {
                return FailResult(ResponseCode.NotFound, "订单不存在");
            }

            List<JsonObject> resultList = new List<JsonObject>();
            JsonObject jsonObject = new JsonObject();
            List<JsonObject> jsonList;//=new List<JsonObject>();
            JsonObject jsonItem;
            #region order_follow 部分的信息
            List<YSWL.MALL.Model.Shop.Order.OrderAction> actionList = _actionBll.GetModelList(" OrderId=" + orderId);
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
                string fullName = _regionsBll.GetFullNameById4Cache(orderModel.RegionId);
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
            paymentjson.Put("freightAdjusted", orderModel.FreightAdjusted.HasValue ? orderModel.FreightAdjusted.Value.ToString("F") : "0.00");
            paymentjson.Put("productprice", orderModel.ProductTotal.ToString("F"));
            paymentjson.Put("orderprice", orderModel.Amount.ToString("F"));
            paymentjson.Put("returnprice", (orderModel.OrderTotal - orderModel.Amount).ToString("F"));
            paymentjson.Put("discountAdjusted", orderModel.DiscountAdjusted?.ToString("F"));
            jsonObject.Put("payment_info", paymentjson);
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
                        if (WebApiApplication.IsAutoConn)
                        {
                            jsonItem.Put("pic", String.IsNullOrWhiteSpace(itemse.ThumbnailsUrl) ? itemse.ThumbnailsUrl : itemse.ThumbnailsUrl.Replace("/Upload/", _mdmPath + "/Upload/"));
                        }
                        else
                        {
                            jsonItem.Put("pic", itemse.ThumbnailsUrl);
                        }
                        Model.Shop.Products.ProductInfo pro = _productManage.GetModelByCache(itemse.ProductId);
                        if (null != pro)
                        {
                            sku.Put("marketprice", pro.MarketPrice.HasValue ? pro.MarketPrice.Value.ToString("F") : "0.00");
                        }
                        else
                        {
                            sku.Put("marketprice", "0.00");
                        }
                        sku.Put("saleprice", itemse.SellPrice.ToString("F"));
                        sku.Put("number", itemse.Quantity);
                        proamount += itemse.Quantity * itemse.SellPrice;
                        skuList.Add(sku);
                    }
                    jsonItem.Put("buyitem", skuList);
                    jsonList.Add(jsonItem);

                    //计算商品总数量
                    jsonObject.Put("productcount", productSku.Sum(i => i.Quantity));
                    //计算商品总价格
                    jsonObject.Put("proamount", proamount);
                }
                jsonObject.Put("payment_info", paymentjson);
                jsonObject.Put("orderId", orderId);
                jsonObject.Put("productlist", jsonList);
                //其他价格
                jsonObject.Put("freight", orderModel.Freight ?? 0M);
            }

            #endregion
            return SuccessResult(jsonObject);
        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("salesorder/submit")]
        public ResponseResult SubmitOrder([FromBody]OrderSubmitVm orderVm)
        {
            JsonObject jsonObject = new JsonObject();
            string orderRemark = orderVm.remark;
            if (!string.IsNullOrWhiteSpace(orderRemark))
            {
                orderRemark = InjectionFilter.Filter(orderRemark);
            }
            #region 发票信息 保存到备注中
            string invoice = "";
            if (!string.IsNullOrWhiteSpace(orderVm.invoiceHeader))
            {
                invoice += "发票抬头：" + InjectionFilter.Filter(orderVm.invoiceHeader);
            }
            if (!string.IsNullOrWhiteSpace(orderVm.invoiceContent))
            {
                invoice += "     发票内容：" + InjectionFilter.Filter(orderVm.invoiceContent);
            }
            if (!String.IsNullOrWhiteSpace(invoice))
            {
                invoice = $" （{invoice}）";
            }
            orderRemark += invoice;
            #endregion

            YSWL.MALL.Model.Shop.Products.ShoppingCartInfo shoppingCartInfo;

            #region 2.购买人的数据

            if (orderVm.salesUserId <= 0)
            {
                return FailResult(ResponseCode.ParamError, "notlogin");
            }
            if (orderVm.userId < 1)
            {
                return FailResult(ResponseCode.ParamError, "nopersonInfo");
            }
            YSWL.MALL.Model.Members.Users userModel = _userManage.GetModelByCache(orderVm.userId);
            if (null != userModel)
            {
                if (userModel.UserType == "AA")
                {
                    return FailResult(ResponseCode.ParamError, "notlogin");
                }
                if (userModel.EmployeeID != orderVm.salesUserId)
                {
                    //信息不匹配
                    return FailResult(ResponseCode.ParamError, "notlogin");
                }
                YSWL.Common.Cookies.setCookie("SubmitOrder_ReferType_" + userModel.UserID,
                    ((int)YSWL.MALL.Model.Shop.Order.EnumHelper.ReferType.SalesMan).ToString(), 1440);
            }
            else
            {
                return FailResult(ResponseCode.ParamError, "nopersonInfo");
            }

            #endregion

            #region 4.获取收货人

            if (orderVm.shipId < 1)
            {
                return FailResult(ResponseCode.ParamError, "noShippingAddress");
            }
            YSWL.MALL.Model.Shop.Shipping.ShippingAddress shippingAddress = _addressManage.GetModelByCache(orderVm.shipId);
            if (shippingAddress == null)
            {
                return FailResult(ResponseCode.ParamError, "noReceiverInfo");
            }
            if (orderVm.regionId < 1)
            {
                return FailResult(ResponseCode.ParamError, "noProvinceCity");
            }

            YSWL.MALL.Model.Ms.Regions regionInfo = _regionsBll.GetModelByCache(orderVm.regionId);
            if (regionInfo == null)
            {
                return FailResult(ResponseCode.ParamError, "noRehionInfo");
            }
            #endregion

            #region 1.获取购物车    循环传过来的List

            //DONE: 2.获取购物车
            try
            {
                shoppingCartInfo = GetShoppingCart(orderVm.productList, orderVm.userId, orderVm.proSaleId, orderVm.groupBuyId, orderVm.regionId);
            }
            catch (ArgumentNullException)
            {
                return ErrorResult(ResponseCode.ParamError, "PROSALEEXPIRED");
            }
            if (shoppingCartInfo == null ||
                shoppingCartInfo.Items == null ||
                shoppingCartInfo.Items.Count < 1)
            {
                return FailResult(ResponseCode.ParamError, "NOSHOPPINGCARTINFO");
            }
            //DONE: 2.1 Check 商品库存
            List<YSWL.MALL.Model.Shop.Products.ShoppingCartItem> noStockList = new List<YSWL.MALL.Model.Shop.Products.ShoppingCartItem>();
            JsonArray notstockArray = new JsonArray();
            JsonObject notstockJson = null;
            foreach (YSWL.MALL.Model.Shop.Products.ShoppingCartItem item in shoppingCartInfo.Items)
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
                return Result(ResultStatus.Fail, notstockArray);
                //return Result(ResultStatus.Fail, "库存不足");
            }
            #endregion

            #region 3.获取支付基础数据
            if (orderVm.paymentId < 1)
            {
                return FailResult(ResponseCode.ParamError, "nopaymentmodelinfo");
            }
            YSWL.Payment.Model.PaymentModeInfo paymentModeInfo =
                   YSWL.Payment.BLL.PaymentModeManage.GetPaymentModeById(orderVm.paymentId);
            if (null == paymentModeInfo)
            {
                return FailResult(ResponseCode.ParamError, "nopaymentmodelinfo");
            }
            #endregion

            #region 5.获取配送(物流)
            if (orderVm.shipTypeId < 1)
            {
                return FailResult(ResponseCode.ParamError, "NOSHIPPINGTYPE");
            }
            YSWL.MALL.Model.Shop.Shipping.ShippingType shippingType = _shippingTypeManage.GetModelByCache(orderVm.shipTypeId);
            if (shippingType == null)
            {
                return FailResult(ResponseCode.ParamError, "NOSHIPPINGTYPE");
            }
            #endregion

            #region 6.生成订单
            //DONE: 5.生成订单
            Model.Shop.Order.OrderInfo mainOrder = new Model.Shop.Order.OrderInfo
            {
                ReferType = (int) Model.Shop.Order.EnumHelper.ReferType.SalesMan,
                CreatedDate = DateTime.Now
            };

            #region 填充订单数据

            #region 基础数据

            bool codePre = ConfigSystem.GetBoolValueByCache("Shop_CreateOrder_PreCode");
            mainOrder.CreateUserId = orderVm.salesUserId;
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

            #endregion


            #region 优惠券数据

            mainOrder.CouponAmount = 0;
            if (!string.IsNullOrWhiteSpace(orderVm.couponCode))
            {
                YSWL.MALL.Model.Shop.Coupon.CouponInfo infoModel = _couponBll.GetCouponInfo(orderVm.couponCode);
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
            bool isFreeShippingActiv = false;
            #region 获取促销活动赠品
            List<Model.Shop.Activity.ActivityInfo> actInfoList = null;
            //赠品
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> actProductList = null;
            //赠品 目前没有加运费 没有加重量
            if (orderVm.proSaleId < 1 && orderVm.groupBuyId < 1)
            {
                actInfoList = _activInfoBll.GetActGiftList(shoppingCartInfo, orderVm.userId, mainOrder.CouponAmount.HasValue ? mainOrder.CouponAmount.Value : 0);

                #region 排除掉赠优惠劵和包邮 2.2版本中没有此功能

                actInfoList = actInfoList?.Where(o => (o.RuleId == 1 || o.RuleId == 2)).ToList();

                #endregion

                if (actInfoList != null)
                {
                    //获取包邮活动
                    List<Model.Shop.Activity.ActivityInfo> freeShippingList = actInfoList.Where(p => p.RuleId == 4).ToList();
                    if (freeShippingList != null && freeShippingList.Count > 0)
                    {
                        //包邮
                        isFreeShippingActiv = true;
                    }

                    actProductList = BLL.Shop.Activity.ActivityInfo.GetActProList(actInfoList, 0);
                }
            }
            #endregion

            #region 重量/运费/积分

            #region 区域差异运费计算

            int topRegionId = regionInfo.Depth > 1 ? Globals.SafeInt(regionInfo.Path.Split(',')[1], -1) : regionInfo.RegionId;

            Model.Shop.Shipping.ShippingRegionGroups shippingRegion =
                _shippingRegionManage.GetShippingRegion(shippingType.ModeId, topRegionId);
            #endregion

            mainOrder.Weight = shoppingCartInfo.TotalWeight;
            mainOrder.Freight = mainOrder.FreightAdjusted = mainOrder.FreightActual = shoppingCartInfo.CalcFreight(shippingType, shippingRegion);
            if (isFreeShippingActiv)
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

            //订单最终支付金额 = 项目调整后总售价 + 调整后运费-优惠券价格
            decimal amount = shoppingCartInfo.TotalAdjustedPrice + mainOrder.FreightAdjusted.Value - (mainOrder.CouponAmount.HasValue ? mainOrder.CouponAmount.Value : 0);
            mainOrder.Amount = amount > 0 ? amount : 0;
            //折扣金额
            mainOrder.DiscountAdjusted = shoppingCartInfo.TotalSellPrice - shoppingCartInfo.TotalAdjustedPrice;
            decimal totalRate = shoppingCartInfo.TotalRate; //总价优惠值

            if (mainOrder.Amount < 0)
            {
                LogHelp.AddInvadeLog(
                    $"非法订单金额|{mainOrder.Amount.ToString("F2")}|_YSWL.Web.Handlers.Shop.OrderHandler.SubmitOrder", HttpContext.Current.Request);
                return FailResult(ResponseCode.ExecuteError, "ILLEGALORDERAMOUNT");
            }

            #endregion

            #region 限时抢购
            if (orderVm.proSaleId > 0)
            {
                YSWL.MALL.Model.Shop.Products.ProductInfo proSaleInfo = _productManage.GetProSaleModel(orderVm.proSaleId);
                if (proSaleInfo != null)
                {
                    mainOrder.ActivityName = string.Format("限时抢购[{0}]", proSaleInfo.CountDownId);
                    //活动优惠金额 = 总金额(含运费无任何优惠) - 最终支付(含运费优惠后)
                    mainOrder.ActivityFreeAmount = mainOrder.OrderTotal - mainOrder.Amount;
                    mainOrder.ActivityStatus = 1;
                }
            }
            #endregion

            #region 团购数据
            if (orderVm.groupBuyId > 0)
            {
                YSWL.MALL.Model.Shop.PromoteSales.GroupBuy buyModel = _groupBuyBll.GetModelByCache(orderVm.groupBuyId);
                if (buyModel != null)
                {
                    mainOrder.GroupBuyId = buyModel.GroupBuyId;
                    mainOrder.GroupBuyPrice = buyModel.Price;
                    mainOrder.GroupBuyStatus = 1;
                }
            }
            #endregion

            mainOrder.OrderType = 1;


            mainOrder.OrderStatus = 0;

            #endregion

            #region 购买人信息

            mainOrder.BuyerID = userModel.UserID;
            mainOrder.BuyerName = userModel.TrueName; //String.IsNullOrWhiteSpace(userModel.TrueName)? userModel.UserName: userModel.TrueName;
            mainOrder.ReferID = userModel.EmployeeID.ToString();
            //TODO: 用户Email为空时, 暂以默认Email下单 BEN ADD 20130701
            string buyEmail = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("Shop_Pay_DefaultEmail");
            buyEmail = String.IsNullOrWhiteSpace(buyEmail) ? "pay@ys56.com" : buyEmail;
            mainOrder.BuyerEmail = string.IsNullOrWhiteSpace(userModel.Email) ? buyEmail : userModel.Email;
            mainOrder.BuyerCellPhone = userModel.Phone;

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

            mainOrder.RegionId = shippingAddress.RegionId;
            mainOrder.ShipRegion = shippingAddress.RegionFullName; //_regionManage.GetFullNameById4Cache(regionInfo.RegionId);
            mainOrder.ShipName = shippingAddress.ShipName;
            mainOrder.ShipEmail = shippingAddress.EmailAddress;
            mainOrder.ShipCellPhone = shippingAddress.CelPhone;
            mainOrder.ShipTelPhone = shippingAddress.TelPhone;
            mainOrder.ShipAddress = shippingAddress.Address;
            mainOrder.ShipZipCode = shippingAddress.Zipcode;

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
                decimal discountAmount = mainOrder.CouponAmount ?? 0;
                foreach (KeyValuePair<int, List<YSWL.MALL.Model.Shop.Order.OrderItems>> item in dicSuppOrderItems)
                {
                    //根据主订单构造子订单
                    YSWL.MALL.Model.Shop.Order.OrderInfo subOrder = new YSWL.MALL.Model.Shop.Order.OrderInfo(mainOrder);

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
                        return FailResult(ResponseCode.ExecuteError, "NOSUPPLIERINFO");
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
                return FailResult(ResponseCode.ExecuteError, "NOSUPPLIERINFO");
            }
            #endregion

            #endregion

            #region 执行事务-创建订单
            try
            {
                mainOrder.OrderId = YSWL.MALL.BLL.Shop.Order.OrderManage.CreateOrder(mainOrder);
                if (mainOrder.OrderId > 0)
                {
                    jsonObject.Put("orderId", mainOrder.OrderId);
                    jsonObject.Put("orderCode", mainOrder.OrderCode);
                    jsonObject.Put("allprice", mainOrder.Amount.ToString("F"));
                    jsonObject.Put("paymenttype", mainOrder.PaymentTypeName);

                    #region 生成促销活动优惠劵
                    _activInfoBll.GenerateData(mainOrder, actInfoList);
                    #endregion
                    //更新优惠券信息
                    if (!String.IsNullOrWhiteSpace(mainOrder.CouponCode))
                    {
                        _couponBll.UseCoupon(orderVm.couponCode, mainOrder.BuyerID, mainOrder.BuyerEmail);
                    }

                    //更新团购信息
                    if (orderVm.groupBuyId > 0)
                    {
                        _groupBuyBll.UpdateBuyCount(orderVm.groupBuyId, shoppingCartInfo.Quantity);
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
                return ErrorResult(ResponseCode.ExecuteError, ex.Message);
            }
            #endregion

            #endregion

            return SuccessResult(jsonObject);
        }

        private string GetName(YSWL.MALL.Model.Members.Users userModel)
        {
            if (userModel == null)
            {
                return "";
            }
            return !String.IsNullOrWhiteSpace(userModel.TrueName) ? userModel.TrueName : userModel.UserName;
        }

        private YSWL.MALL.Model.Shop.Products.ShoppingCartInfo GetShoppingCart(List<YSWL.MALL.ViewModel.Order.ProductVm> jsonSku, int userId, int prosaleId = -1, int groupbuyId = -1, int regionId = -1)
        {
            YSWL.MALL.Model.Shop.Products.ShoppingCartInfo shoppingCartInfo = new YSWL.MALL.Model.Shop.Products.ShoppingCartInfo();
            if (null != jsonSku && jsonSku.Count > 0)
            {
                foreach (ProductVm product in jsonSku)
                {
                    var skuItem = product;
                    string sku = skuItem.SKU;
                    int count = skuItem.Count;
                    YSWL.MALL.Model.Shop.Products.SKUInfo skuInfo = _skuBll.GetModelBySKU(sku);
                    if (skuInfo == null) return null;
                    YSWL.MALL.Model.Shop.Products.ProductInfo productInfo = _productManage.GetModel(skuInfo.ProductId);
                    if (productInfo == null) return null;
                    YSWL.MALL.Model.Shop.Products.ShoppingCartItem itemInfo = new YSWL.MALL.Model.Shop.Products.ShoppingCartItem();
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
                        YSWL.MALL.Model.Shop.Products.ProductInfo proSaleInfo = _productManage.GetProSaleModel(prosaleId);
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
                            _productManage.GetGroupBuyModel(groupbuyId);
                        if (groupBuyInfo == null) return null;

                        //活动已过期 重定向到单品页
                        if (DateTime.Now > groupBuyInfo.GroupBuy.EndDate)
                            throw new ArgumentNullException("活动已过期");

                        //重置价格为 限时抢购价
                        itemInfo.AdjustedPrice = groupBuyInfo.GroupBuy.Price;
                    }

                    #endregion


                    //DONE: 根据SkuId 获取SKUItem值和图片数据 BEN 2013-06-30
                    List<YSWL.MALL.Model.Shop.Products.SKUItem> listSkuItems = _skuBll.GetSKUItemsBySkuId(skuInfo.SkuId);
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

  }
}