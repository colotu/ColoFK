﻿/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductReviews.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/08/27 14:50:44
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using YSWL.MALL.BLL.SNS;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.Common;
using YSWL.MALL.Model.SNS;

namespace YSWL.MALL.BLL.Shop.Products
{
    /// <summary>
    /// 商品评论表
    /// </summary>
    public partial class ProductReviews
    {
        private readonly IProductReviews dal = DAShopProducts.CreateProductReviews();

        public ProductReviews()
        { }

        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ReviewId)
        {
            return dal.Exists(ReviewId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Products.ProductReviews model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.Products.ProductReviews model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ReviewId)
        {

            return dal.Delete(ReviewId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ReviewIdlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(ReviewIdlist,0) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Products.ProductReviews GetModel(int ReviewId)
        {

            return dal.GetModel(ReviewId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Shop.Products.ProductReviews GetModelByCache(int ReviewId)
        {

            string CacheKey = "ProductReviewsModel-" + ReviewId;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ReviewId);
                    if (objModel != null)
                    {
                    int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Shop.Products.ProductReviews)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Shop.Products.ProductReviews> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Shop.Products.ProductReviews> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Shop.Products.ProductReviews> modelList = new List<YSWL.MALL.Model.Shop.Products.ProductReviews>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Shop.Products.ProductReviews model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod

        public DataSet GetList(int? Status)
        {
            return dal.GetList(Status);
        }

        /// <summary>
        /// 对评论进行审核
        /// </summary>
        public bool AuditComment(string ids,int status)
        {
            return dal.AuditComment(ids, status);
        }

        public List<YSWL.MALL.Model.Shop.Products.ProductReviews> GetReviewsByPage(long productId, string orderBy,int startIndex,
                                                                                   int endIndex)
        {
            DataSet ds = dal.GetListByPage("Status=1 and ProductId=" + productId, orderBy, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }
        public DataSet GetListLeftOrderItems(int? Status)
        {
            return dal.GetListsProdRev(Status);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool AddEx(YSWL.MALL.Model.Shop.Products.ProductReviews model,string productName,bool IsPost=false)
        {
            model.Status = 1;
            //进行敏感字过滤
            if (YSWL.MALL.BLL.Settings.FilterWords.ContainsModWords(model.ReviewText))
            {
                model.Status = 0;
            }
            else
            {
                model.ReviewText = YSWL.MALL.BLL.Settings.FilterWords.ReplaceWords(model.ReviewText);
            }
            int commentId= dal.Add(model);
            if (commentId > 0&&IsPost)
            {
                YSWL.MALL.BLL.SNS.Posts postBll=new YSWL.MALL.BLL.SNS.Posts();
                YSWL.MALL.Model.SNS.Posts postModel=new YSWL.MALL.Model.SNS.Posts();
                postModel.CreatedDate = DateTime.Now;
                postModel.Description = model.ReviewText;
                postModel.ProductName = productName;
                postModel.TargetId =(int)model.ProductId;
                postModel.CreatedNickName = model.UserName;
                postModel.CreatedUserID = model.UserId;
                postModel.Type = 0;
                postBll.AddNormalPost(postModel);
                return true;
            }
            return commentId>0;
        }
        /// <summary>
        /// 增加多条数据
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="OrderId">订单id</param>
        /// <param name="pointers">获得积分</param>
        /// <param name="rankScore">获得成长值</param>
        /// <returns></returns>
        public bool AddEx(List<Model.Shop.Products.ProductReviews> modelList, long OrderId,out int  pointers,out int rankScore)
        {
             pointers = 0;
             rankScore = 0;
             if (modelList == null || modelList.Count <= 0)
             {
                 return false;
             }
             bool ret = dal.AddEx(modelList, OrderId);
             if (ret)
             {
                //加积分
                 foreach (Model.Shop.Products.ProductReviews item in modelList)
                 {
                     if (item != null)
                     {
                         Members.PointsDetail pointBll = new Members.PointsDetail();
                         pointers += pointBll.AddPoints(7, item.UserId, "商品评论操作"); //商品评论积分 
                         rankScore += Members.RankDetail.AddScore(7, item.UserId, "商品评论操作"); //商品评论积分 
                         if (!String.IsNullOrWhiteSpace(item.ImagesNames))
                         {
                             //晒单积分
                             pointers += pointBll.AddPoints(8, item.UserId, "晒单操作"); //商品评论积分 
                             rankScore += Members.RankDetail.AddScore(8, item.UserId, "晒单操作"); //商品评论积分 
                         } 
                     }
                 }
             }
             return ret;
         }


        /// <summary>
        /// 获取包含商品图片和用户头像的评论列表(MC01用到)
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        public List<YSWL.MALL.Model.Shop.Products.Reviews> GetListExByPage(int userId, int startIndex, int endIndex)
        {
            List<YSWL.MALL.Model.Shop.Products.Reviews> modelList = new List<YSWL.MALL.Model.Shop.Products.Reviews>();
            DataSet ds = dal.GetListExByPage(userId, startIndex, endIndex);
            return DataTableToListEx(ds.Tables[0]);
        }

        public List<YSWL.MALL.Model.Shop.Products.Reviews> DataTableToListEx(DataTable dt)
        {
            List<YSWL.MALL.Model.Shop.Products.Reviews> modelList = new List<YSWL.MALL.Model.Shop.Products.Reviews>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Shop.Products.Reviews model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelEx(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }


        public int GetRecord(int userId)
        {
            return dal.GetRecord(userId);
        }




    }
}