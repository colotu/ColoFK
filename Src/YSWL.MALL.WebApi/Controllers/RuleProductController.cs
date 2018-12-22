using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Http;
using YSWL.Json;
using YSWL.MALL.WebApi.Models;

namespace YSWL.MALL.WebApi.Controllers
{
    /// <summary>
    /// 规则商品相关操作
    /// </summary>
    [RoutePrefix("v1.0")]
    public class RuleProductController : ApiControllerBase
    {
        private readonly BLL.Shop.Sales.SalesRuleProduct _ruleProductBll = new BLL.Shop.Sales.SalesRuleProduct();
        private readonly BLL.Shop.Products.ProductInfo _productManage = new BLL.Shop.Products.ProductInfo();
        /// <summary>
        /// MDM域名
        /// </summary>
        private readonly string _mdmPath = YSWL.Common.ConfigHelper.GetConfigString("MDM_Url");

        [Route("rule/product")]
        [HttpGet]
        public ResponseResult ProductList(int ruleId = 0, string categoryId = null, string productName = null, string brandId = null
            , int? page = 1, int pageNum = 30)
        {
            if (ruleId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            if (!string.IsNullOrEmpty(productName))
            {
                productName = YSWL.Common.InjectionFilter.SqlFilter(productName);
            }
            //获取已选择数据
            DataSet ds = _ruleProductBll.GetRuleProductsApp(ruleId, categoryId, productName,brandId);
            StringBuilder strPIds = new StringBuilder();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strPIds.Append(ds.Tables[0].Rows[i]["ProductId"]);
                    strPIds.Append(",");
                }
            }
            string[] skus = strPIds.ToString().TrimEnd(',').Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (skus.Length < 0)
            {
                return FailResult(ResponseCode.NotFound, "请求商品错误");
            }
            if (!page.HasValue || page <= 0)
            {
                page = 1;
            }
            int startIndex = (page.Value - 1) * pageNum + 1;
            int endIndex = startIndex + pageNum - 1;
            List<Model.Shop.Products.ProductInfo> prodList = _productManage.GetRuleProductListApp(
                skus.Distinct().ToArray(), startIndex, endIndex,brandId);
            JsonObject json;
            JsonArray jsonArray = new JsonArray();
            if (prodList != null)
            {
                foreach (Model.Shop.Products.ProductInfo item in prodList)
                {
                    json = new JsonObject();
                    json.Put("id", item.ProductId);
                    json.Put("name", item.ProductName);
                    json.Put("pic", $"{_mdmPath?.TrimEnd('/')}{item.ThumbnailUrl1}");
                    json.Put("marketprice", item.MarketPrice.HasValue ? item.MarketPrice.Value.ToString("F") : "0.00");
                    json.Put("saleprice", item.LowestSalePrice.ToString("F"));
                    //json.Put("brand", item.BrandName);
                    json.Put("code", item.ProductCode);
                    //json.Put("commentCount", _reviewsBll.GetRecordCount("Status=1 and ProductId=" + item.ProductId));
                    jsonArray.Add(json);
                }
            }
            return SuccessResult(jsonArray);
        }

        /// <summary>
        /// 获取没有规则的商品列表
        /// </summary>
        /// <returns></returns>
        [Route("rule/noruleproduct")]
        [HttpGet]
        public ResponseResult ProductNoRuleList(int ruleId = 0, string categoryId = null,string brandId=null
            , string productName = null, int? page = 1, int pageNum = 30)
        {
            if (ruleId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            if (!string.IsNullOrEmpty(productName))
            {
                productName = YSWL.Common.InjectionFilter.SqlFilter(productName);
            }

            if (!page.HasValue || page <= 0)
            {
                page = 1;
            }
            int startIndex = (page.Value - 1) * pageNum + 1;
            int endIndex = startIndex + pageNum - 1;
            List<Model.Shop.Products.ProductInfo> prodList = _productManage.GetNoRuleProductListApp(
                productName, categoryId, brandId, 1, ruleId, startIndex, endIndex);
            JsonObject json;
            JsonArray jsonArray = new JsonArray();
            if (prodList != null)
            {
                foreach (Model.Shop.Products.ProductInfo item in prodList)
                {
                    json = new JsonObject();
                    json.Put("id", item.ProductId);
                    json.Put("name", item.ProductName);
                    json.Put("pic", $"{_mdmPath?.TrimEnd('/')}{item.ThumbnailUrl1}");
                    json.Put("marketprice", item.MarketPrice.HasValue ? item.MarketPrice.Value.ToString("F") : "0.00");
                    json.Put("saleprice", item.LowestSalePrice.ToString("F"));
                    json.Put("code", item.ProductCode);
                    jsonArray.Add(json);
                }
            }
            return SuccessResult(jsonArray);
        }

        /// <summary>
        /// 设置规则商品
        /// </summary>
        /// <param name="ruleProductModel"></param> 
        /// <returns></returns>
        [Route("rule/addproduct")]
        [HttpPost]
        public ResponseResult AddProduct(Model.Shop.Sales.SalesRuleProduct ruleProductModel)
        {
            if (ruleProductModel.RuleId < 1 || ruleProductModel.ProductId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            if (_ruleProductBll.Exists(ruleProductModel.RuleId, ruleProductModel.ProductId))
            {
                return FailResult(ResponseCode.OrderExists, "数据已存在");
            }
            return _ruleProductBll.Add(ruleProductModel)
                ? SuccessResult("添加成功")
                : FailResult(ResponseCode.BadGateway, "添加失败");
        }

        /// <summary>
        /// 删除规则商品
        /// </summary>
        /// <param name="ruleProductModel"></param>
        /// <returns></returns>
        [Route("rule/delproduct")]
        [HttpPost]
        public ResponseResult DeleteProduct(Model.Shop.Sales.SalesRuleProduct ruleProductModel)
        {
            if (ruleProductModel.RuleId < 1 || ruleProductModel.ProductId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            return _ruleProductBll.Delete(ruleProductModel.RuleId, ruleProductModel.ProductId)
                ? SuccessResult("删除成功")
                : FailResult(ResponseCode.BadGateway, "删除失败");
        }

        /// <summary>
        /// 批量加入规则商品
        /// </summary>
        /// <returns></returns>
        [Route("rule/addallproduct")]
        [HttpGet]
        public ResponseResult AddProduct(int ruleId = 0, string name = "", int categoryId = 0, int status = 0)
        {
            if (ruleId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            if (!string.IsNullOrEmpty(name))
            {
                name = YSWL.Common.InjectionFilter.SqlFilter(name);
            }
            int count = _ruleProductBll.AddList(ruleId, name, categoryId, status);
            return count > 0 ? SuccessResult($"一键加入规则商品成功，共添加了【{count}】个商品") : FailResult(ResponseCode.BadGateway, "一键加入规则商品失败");
        }

        /// <summary>
        /// 批量删除规则商品
        /// </summary>
        /// <returns></returns>
        [Route("rule/delallproduct")]
        [HttpGet]
        public ResponseResult DeleteProducts(int ruleId = 0)
        {
            if (ruleId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            return _ruleProductBll.DeleteByRule(ruleId) ? SuccessResult("删除成功")
                : FailResult(ResponseCode.BadGateway, "删除失败");
        }

        /// <summary>
        /// 批量删除规则商品
        /// </summary>
        /// <returns></returns>
        [Route("rule/batchdelproduct")]
        [HttpPost]
        public ResponseResult BatchDeleteProducts(ViewModel.Shop.RuleProductVm model)
        {
            if (model?.RuleId < 1 || model?.ProductIds?.Count < 0)
            {
                return FailResult(ResponseCode.ParamError);

            }
            List<Model.Shop.Sales.SalesRuleProduct> ruleProductList = model.ProductIds.Select(pid => new Model.Shop.Sales.SalesRuleProduct
            {
                RuleId = model.RuleId,
                ProductId = pid
            }).ToList();
            return _ruleProductBll.DeleteSaleRuleBatch(ruleProductList) ? SuccessResult("删除成功")
                : FailResult(ResponseCode.BadGateway, "删除失败");
        }

        /// <summary>
        /// 批量删除规则商品
        /// </summary>
        /// <returns></returns>
        [Route("rule/batchaddproduct")]
        [HttpPost]
        public ResponseResult BatchAddProducts(List<Model.Shop.Sales.SalesRuleProduct> modelList)
        {
            if (modelList?.Count < 0)
            {
                return FailResult(ResponseCode.ParamError);
            }
            return _ruleProductBll.AddSaleRuleBatch(modelList) ? SuccessResult("新增成功")
                : FailResult(ResponseCode.BadGateway, "新增失败"); ;
        }
    }
}