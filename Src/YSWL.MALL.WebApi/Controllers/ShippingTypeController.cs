using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YSWL.MALL.WebApi.Models;

namespace YSWL.MALL.WebApi.Controllers
{
    [RoutePrefix("v1.0")]
    public class ShippingTypeController : ApiControllerBase
    {
        private readonly YSWL.MALL.BLL.Shop.Shipping.ShippingType _shippingTypeBll = new BLL.Shop.Shipping.ShippingType();
        private readonly YSWL.MALL.BLL.Shop.Shipping.ShippingPayment _payBll = new BLL.Shop.Shipping.ShippingPayment();
        /// <summary>
        /// 获取配送方式列表
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("shippingtype/list")]
        public ResponseResult ShippingList()
        {
            List<Model.Shop.Shipping.ShippingType> shippingTypeList = _shippingTypeBll.GetModelList("");
            return SuccessResult(shippingTypeList);
        }

        /// <summary>
        /// 获取物流公司列表
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [Route("company/list")]
        public ResponseResult ComTypeList()
        {
            List<ViewModel.Shop.ComType> comTypesList = YSWL.MALL.WebApi.Common.ExpressHelper.GetAllComType();
            return SuccessResult(comTypesList);
        }

        /// <summary>
        /// 添加配送方式
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("shippingtype/add")]
        public ResponseResult ShippingTypeAdd(YSWL.MALL.Model.Shop.Shipping.ShippingType model)
        {
            model.ModeId = _shippingTypeBll.Add(model);
            if (model.ModeId > 0)
            {
                //保存地区价格
                //SaveShippingRegionGroups(model);
                List<YSWL.Payment.Model.PaymentModeInfo> paylist = YSWL.Payment.BLL.PaymentModeManage.GetPaymentModes(YSWL.Payment.Model.DriveEnum.Wap);
                foreach (var payItem in paylist)
                {
                    Model.Shop.Shipping.ShippingPayment payModel = new Model.Shop.Shipping.ShippingPayment
                    {
                        //支付Id
                        PaymentModeId = payItem.ModeId,
                        ShippingModeId = model.ModeId
                    };
                    _payBll.Add(payModel);
                }
                return SuccessResult("添加成功");
            }
            return FailResult(ResponseCode.BadGateway, "添加失败");
        }

        /// <summary>
        /// 编辑配送方式
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("shippingtype/edit")]
        public ResponseResult ShippingTypeEdit(YSWL.MALL.Model.Shop.Shipping.ShippingType model)
        {
            return _shippingTypeBll.Update(model) ?
             SuccessResult("编辑成功") : FailResult(ResponseCode.BadGateway, "编辑失败");
        }

        #region 私有方法

        private void SaveShippingRegionGroups(Model.Shop.Shipping.ShippingType shippingType)
        {
            string data = "";
            if (string.IsNullOrWhiteSpace(data)) return;

            List<YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups> list = GetRegionGroups(shippingType, data);
            if (list == null || list.Count < 1) return;

            BLL.Shop.Shipping.ShippingRegionGroups regionGroupManage = new BLL.Shop.Shipping.ShippingRegionGroups();
            regionGroupManage.SaveShippingRegionGroups(shippingType, list);
        }

        private List<YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups> GetRegionGroups(
            Model.Shop.Shipping.ShippingType shippingType,
            string data)
        {
            List<YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups> list = new List<YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups>();
            Json.JsonArray jsonArray = null;
            try
            {
                jsonArray = YSWL.Json.Conversion.JsonConvert.Import<Json.JsonArray>(data);
                if (jsonArray == null || jsonArray.Length < 1) return null;

                YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups model;
                foreach (Json.JsonObject jsonObject in jsonArray)
                {
                    model = new YSWL.MALL.Model.Shop.Shipping.ShippingRegionGroups();
                    model.ModeId = shippingType.ModeId;
                    model.RegionIds = ((Json.JsonArray)jsonObject["ids"]).Cast<string>().ToArray();
                    model.Price = YSWL.Common.Globals.SafeDecimal(jsonObject["price"], decimal.Zero);
                    model.AddPrice = YSWL.Common.Globals.SafeDecimal(jsonObject["addprice"], null);
                    list.Add(model);
                }
            }
            catch { }
            return list;
        }

        #endregion
    }
}