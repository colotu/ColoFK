using System.Collections.Generic;
using System.Web.Http;
using YSWL.MALL.Model.Shop.Products;
using YSWL.MALL.BLL.Shop.Service;
using YSWL.Common.WebApi;
using YSWL.MALL.WebApi.Filter;

namespace YSWL.MALL.WebApi.Controllers
{
    [RoutePrefix("api")]
    [WebApiAuth]
    public class ProductController : ApiBaseController
    {
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="productInfos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("product/create")]
        public ResponseBase AddProduct(List<ProductInfo> productInfos)
        {
            PMSServiceHelper.SyncProductInfo(productInfos);
            return new ResponseBase { ResponseCode = ResponseCode.RequestSuccess };
        }

        /// <summary>
        /// 添加单个商品
        /// </summary>
        /// <param name="productInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("product/create_one")]
        public ResponseBase AddProductOne(ProductInfo productInfo)
        {
            PMSServiceHelper.SyncProductInfoOne(productInfo);
            return new ResponseBase { ResponseCode = ResponseCode.RequestSuccess };
        }

        ///  <summary>
        /// 添加商品分类
        ///  </summary>
        /// <param name="categoryInfos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("categorie/create")]
        public ResponseBase AddCategories(List<CategoryInfo> categoryInfos)
        {
            PMSServiceHelper.SyncCategory(categoryInfos);
            return new ResponseBase { ResponseCode = ResponseCode.RequestSuccess };
        }

        ///  <summary>
        /// 添加品牌分类
        ///  </summary>
        /// <param name="brandInfos"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("brand/create")]
        public ResponseBase AddBrand(List<BrandInfo> brandInfos)
        {
            PMSServiceHelper.SyncBrands(brandInfos);
            return new ResponseBase { ResponseCode = ResponseCode.RequestSuccess };
        }

        /// <summary>
        /// 同步商品类型数据
        /// </summary>
        /// <param name="productTypes"></param>
        [HttpPost]
        [Route("type/create")]
        public ResponseBase AddType(List<ProductType> productTypes)
        {
            PMSServiceHelper.SyncProductType(productTypes);
            return new ResponseBase { ResponseCode = ResponseCode.RequestSuccess };
        }

        /// <summary>
        /// 同步属性表数据
        /// </summary>
        /// <param name="attributeInfos"></param>
        [HttpPost]
        [Route("attribute/create")]
        public ResponseBase AddAttribute(List<AttributeInfo> attributeInfos)
        {
            PMSServiceHelper.SyncAttribute(attributeInfos);
            return new ResponseBase { ResponseCode = ResponseCode.RequestSuccess };
        }
    }
}