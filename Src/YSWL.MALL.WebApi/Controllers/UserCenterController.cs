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
    public class UserCenterController : ApiControllerBase
    {
        private readonly BLL.Shop.Shipping.ShippingAddress _addressManage = new BLL.Shop.Shipping.ShippingAddress();

        /// <summary>
        /// 获取收货地址列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("address/list")]
        public ResponseResult List(int userId=0,int? page = 1, int pageNum = 30)
        {
            if (userId<1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            if (!page.HasValue || page <= 0)
            {
                page = 1;
            }
            int startIndex = (page.Value - 1) * pageNum + 1;
            int endIndex = startIndex + pageNum - 1;
            List<Model.Shop.Shipping.ShippingAddress> attrList =
                _addressManage.GetListByPageEx(" UserId=" + userId, "", startIndex, endIndex);
            return SuccessResult(attrList.Select(t=>new
            {
                t.ShippingId,
                t.RegionId,
                t.RegionFullName,
                t.ShipName,
                t.CelPhone,
                t.Address,
                t.IsDefault,
                t.EmailAddress
            }));
        }

        /// <summary>
        /// 新增收获地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("address/add")]
        public ResponseResult Add(ViewModel.UserCenter.AddressRequestVm vm)
        {
            if (vm.UserId<1||vm.RegionId<1||string.IsNullOrEmpty(vm.Address)||
                string.IsNullOrEmpty(vm.ShipName))
            {
                return FailResult(ResponseCode.ParamError);
            }
            Model.Shop.Shipping.ShippingAddress model=new Model.Shop.Shipping.ShippingAddress
            {
                UserId=vm.UserId,
                ShipName=vm.ShipName,
                RegionId=vm.RegionId,
                Address=vm.Address,
                CelPhone=vm.CelPhone,
                EmailAddress=vm.EmailAddress
            };
            int count= _addressManage.Add(model);
            return count > 0 ? SuccessResult("新增成功") : FailResult(ResponseCode.BadGateway, "新增失败");
        }
            
        /// <summary>
        /// 编辑收获地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("address/edit")]
        public ResponseResult Edit(ViewModel.UserCenter.AddressRequestVm vm)
        {
            if (vm.ShippingId < 1||vm.UserId < 1 || vm.RegionId < 1 || string.IsNullOrEmpty(vm.Address) ||
                string.IsNullOrEmpty(vm.ShipName))
            {
                return FailResult(ResponseCode.ParamError);
            }

            Model.Shop.Shipping.ShippingAddress shippingAddress = _addressManage.GetModel(vm.ShippingId);

            shippingAddress.UserId = vm.UserId;
            shippingAddress.ShipName = vm.ShipName;
            shippingAddress.RegionId = vm.RegionId;
            shippingAddress.Address = vm.Address;
            shippingAddress.CelPhone = vm.CelPhone;
            shippingAddress.EmailAddress = vm.EmailAddress;

            bool isUpdate= _addressManage.Update(shippingAddress);
            return isUpdate? SuccessResult("编辑成功") : FailResult(ResponseCode.BadGateway, "编辑失败");
        }


        /// <summary>
        /// 默认收获地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("address/setdefault")]
        public ResponseResult SetDefault(ViewModel.UserCenter.AddressRequestVm vm)
        {
            if (vm.ShippingId < 1 || vm.UserId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            bool isUpdate = _addressManage.SetDefaultShipAddress(vm.UserId, vm.ShippingId);
            return isUpdate ? SuccessResult("设置成功") : FailResult(ResponseCode.BadGateway, "设置失败");
        }

        /// <summary>
        /// 删除收获地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("address/del")]
        public ResponseResult Del(ViewModel.UserCenter.AddressRequestVm vm)
        {
            if (vm.ShippingId < 1 )
            {
                return FailResult(ResponseCode.ParamError);
            }
            bool isUpdate = _addressManage.Delete(vm.ShippingId);
            return isUpdate ? SuccessResult("删除成功") : FailResult(ResponseCode.BadGateway, "删除失败");
        }
    }
}