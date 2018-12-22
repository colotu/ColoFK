using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using YSWL.MALL.WebApi.Models;

namespace YSWL.MALL.WebApi.Controllers
{
    /// <summary>
    /// 批发规则
    /// </summary>
    [RoutePrefix("v1.0")]
    public class SaleRuleController : ApiControllerBase
    {
        private readonly BLL.Shop.Sales.SalesRule _ruleBll = new BLL.Shop.Sales.SalesRule();
        private readonly BLL.Shop.Sales.SalesItem _ruleItemBll = new BLL.Shop.Sales.SalesItem();
        private readonly BLL.Shop.Sales.SalesUserRank _userRankBll = new BLL.Shop.Sales.SalesUserRank();
        private readonly BLL.Shop.Sales.SalesRuleProduct _ruleProductBll = new BLL.Shop.Sales.SalesRuleProduct();

        /// <summary>
        /// 获取促销规则列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("salerule/list")]
        public ResponseResult SaleRuleList(string advName = null, int? page = 1,
            int pageNum = 30)
        {
            if (!string.IsNullOrEmpty(advName))
            {
                advName = YSWL.Common.InjectionFilter.SqlFilter(advName);
            }
            List<Model.Shop.Sales.SalesRule> ruleList = _ruleBll.GetListByPageApp(advName, 0, page, pageNum);
            return SuccessResult(ruleList.Select(t => new
            {
                t.RuleId,
                t.RuleName,
                Status = t.Status != 0
            }));
        }

        /// <summary>
        /// 获取规则详情
        /// </summary>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("salerule/detail")]
        public ResponseResult SaleRuleDetail(int ruleId)
        {
            if (ruleId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            ViewModel.Shop.SalesRuleVm model = new ViewModel.Shop.SalesRuleVm();

            //规则信息
            Model.Shop.Sales.SalesRule ruleModel = _ruleBll.GetModel(ruleId);

            if (ruleModel != null)
            {
                model.RuleName = ruleModel.RuleName;
                model.RuleId = ruleModel.RuleId;
                model.RuleMode = ruleModel.RuleMode;
                model.Status = ruleModel.Status != 0;
                model.RuleUnit = ruleModel.RuleUnit;

                //获取选中的会员等级
                List<Model.Shop.Sales.SalesUserRank> userRanks = _userRankBll.GetModelList(" RuleId=" + ruleId);
                if (userRanks != null && userRanks.Count > 0)
                {
                    model.RankItem = userRanks.Select(t => t.RankId).ToList();
                }
                //规则项信息
                List<Model.Shop.Sales.SalesItem> itemList = _ruleItemBll.GetModelList(" RuleId=" + ruleId);
                if (itemList != null && itemList.Count > 0)
                {
                    model.RuleItem = itemList.Select(t => new ViewModel.Shop.SaleRuleItemVm
                    {
                        ItemId = ruleId,
                        ItemType = t.ItemType,
                        RuleId = t.RuleId,
                        UnitValue = t.UnitValue,
                        RateValue = t.RateValue
                    }).ToList();
                }

                return SuccessResult(model);
            }
            return FailResult(ResponseCode.NotFound, "规则不存在");
        }

        /// <summary>
        /// 添加规则
        /// </summary>
        /// <returns></returns>
        [Route("salerule/add")]
        [HttpPost]
        public ResponseResult SaleRuleAdd(ViewModel.Shop.SalesRuleVm model)
        {
            if (string.IsNullOrEmpty(model?.RuleName) || model.RuleItem == null)
            {
                return FailResult(ResponseCode.ParamError);
            }
            Model.Shop.Sales.SalesRule ruleModel = new Model.Shop.Sales.SalesRule
            {
                RuleName = model.RuleName,
                RuleUnit = model.RuleUnit,
                RuleMode = model.RuleMode,
                Type = 0,
                CreatedDate = DateTime.Now,
                CreatedUserID = model.CreatedUserID,
                Status = model.Status ? 1 : 0
            };
            //添加批发规则
            int ruleId = _ruleBll.Add(ruleModel);
            if (ruleId > 0)
            {
                foreach (var item in model.RuleItem)
                {
                    Model.Shop.Sales.SalesItem itemModel = new Model.Shop.Sales.SalesItem
                    {
                        ItemType = item.ItemType,
                        UnitValue = item.UnitValue,
                        RateValue = item.RateValue,
                        RuleId = ruleId
                    };
                    //添加规则项
                    _ruleItemBll.Add(itemModel);
                }
                if (model.RankItem != null)
                {
                    foreach (int item in model.RankItem)
                    {
                        Model.Shop.Sales.SalesUserRank userRankModel = new Model.Shop.Sales.SalesUserRank
                        {
                            RankId = YSWL.Common.Globals.SafeInt(item, 0),
                            RuleId = ruleId
                        };
                        //添加规则等级
                        _userRankBll.Add(userRankModel);
                    }
                }
                //if (model.ProductsStatus && model.ProductItem != null)
                //{
                //    foreach (Model.Shop.Sales.SalesRuleProduct item in model.ProductItem)
                //    {
                //        item.RuleId = ruleId;
                //    }
                //    //添加规则商品
                //    _ruleProductBll.AddSaleRuleBatch(model.ProductItem);
                //}

                return SuccessResult("添加成功");
            }
            return FailResult(ResponseCode.BadGateway, "添加失败");
        }

        /// <summary>
        /// 编辑规则
        /// </summary>
        /// <returns></returns>
        [Route("salerule/edit")]
        [HttpPost]
        public ResponseResult SaleRuleUpdate(ViewModel.Shop.SalesRuleVm model)
        {
            if (string.IsNullOrEmpty(model?.RuleName) || model.RuleId < 1 || model.RuleItem == null)
            {
                return FailResult(ResponseCode.ParamError);
            }
            if (model.RuleItem?.Count < 1)
            {
                return FailResult(ResponseCode.ParamError, "请填写优惠规则项");
            }
            Model.Shop.Sales.SalesRule ruleModel = _ruleBll.GetModel(model.RuleId);

            ruleModel.RuleId = model.RuleId;
            ruleModel.RuleName = model.RuleName;
            ruleModel.RuleUnit = model.RuleUnit;
            ruleModel.RuleMode = model.RuleMode;
            ruleModel.CreatedDate = DateTime.Now;
            ruleModel.CreatedUserID = model.CreatedUserID;
            ruleModel.Status = model.Status ? 1 : 0;
            //添加批发规则
            bool isSuccess = _ruleBll.Update(ruleModel);
            if (!isSuccess)
            {
                return FailResult(ResponseCode.BadGateway, "编辑失败");
            }
            _ruleItemBll.DeleteByRuleId(ruleModel.RuleId);
            foreach (var item in model.RuleItem)
            {
                Model.Shop.Sales.SalesItem itemModel = new Model.Shop.Sales.SalesItem
                {
                    ItemType = item.ItemType,
                    UnitValue = item.UnitValue,
                    RateValue = item.RateValue,
                    RuleId = model.RuleId
                };
                //添加规则项
                _ruleItemBll.Add(itemModel);
            }
            _userRankBll.DeleteByRuleId(ruleModel.RuleId);
            if (model.RankItem != null)
            {
                foreach (int item in model.RankItem)
                {
                    Model.Shop.Sales.SalesUserRank userRankModel = new Model.Shop.Sales.SalesUserRank
                    {
                        RankId = YSWL.Common.Globals.SafeInt(item, 0),
                        RuleId = model.RuleId
                    };
                    //添加规则等级
                    _userRankBll.Add(userRankModel);
                }
            }
            //if (model.ProductsStatus && model.ProductItem != null)
            //{
            //    if (!_ruleProductBll.DeleteByRule(model.RuleId))
            //    {
            //        return FailResult(ResponseCode.BadGateway, "设置规则商品失败");
            //    }
            //    foreach (Model.Shop.Sales.SalesRuleProduct item in model.ProductItem)
            //    {
            //        item.RuleId = model.RuleId;
            //    }
            //    //添加规则商品
            //    _ruleProductBll.AddSaleRuleBatch(model.ProductItem);
            //}

            return SuccessResult("编辑成功");
        }

        /// <summary>
        /// 批量删除规则等级
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [Route("salerule/delete")]
        [HttpGet]
        public ResponseResult SaleRuleDelete(string ids = null)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return FailResult(ResponseCode.ParamError);
            }
            return _ruleBll.DeleteListEx(ids) ? SuccessResult("删除成功") : FailResult(ResponseCode.InternalServerError, "删除失败");
        }
    }
}