using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.Model.Tao;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Tao;
using YSWL.TaoBao.Request;
using YSWL.TaoBao.Response;
using YSWL.TaoBao;
namespace YSWL.MALL.BLL.Tao
{
	/// <summary>
	/// Product
	/// </summary>
	public partial class Product
	{
        private readonly IProduct dal = DATao.CreateProduct();
		public Product()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ProductID)
        {
            return dal.Exists(ProductID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Tao.Product model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Tao.Product model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ProductID)
        {

            return dal.Delete(ProductID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ProductIDlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(ProductIDlist,0) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Tao.Product GetModel(long ProductID)
        {

            return dal.GetModel(ProductID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Tao.Product GetModelByCache(long ProductID)
        {

            string CacheKey = "ProductModel-" + ProductID;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ProductID);
                    if (objModel != null)
                    {
                      int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Tao.Product)objModel;
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
        public List<YSWL.MALL.Model.Tao.Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.Product> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Tao.Product> modelList = new List<YSWL.MALL.Model.Tao.Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Tao.Product model;
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
		#region  ExtensionMethod

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public int GetRecordCountEX(int cid, string Coupon, int type)
        //{
        //    return dal.GetRecordCountEx("", cid);
        //}

        /// <summary>
        /// 删除一条数据（事务删除）
        /// </summary>
        public bool DeleteEX(int ProductID)
        {
            return dal.DeleteEX(ProductID);
        }

        /// <summary>
        /// 批量删除数据（事务删除）
        /// </summary>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        public bool DeleteListEX(string ProductIds)
        {
            return dal.DeleteListEX(ProductIds);
        }

        /// <summary>
        /// 批量转移分类
        /// </summary>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        public bool UpdateCateList(string ProductIds, int CateId)
        {
            return dal.UpdateCateList(ProductIds, CateId);
        }

        /// <summary>
        /// 批量推荐到首页
        /// </summary>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        public bool UpdateRecomendList(string ProductIds, int Recomend)
        {
            return dal.UpdateRecomendList(ProductIds, Recomend);
        }

        public bool UpdateRecomend(int ProductId, int Recomend)
        {
            return dal.UpdateRecomend(ProductId, Recomend);
        }

        public bool UpdateStatus(int ProductId, int Status)
        {
            return dal.UpdateStatus(ProductId, Status);
        }

        /// <summary>
        /// 批量转移分类
        /// </summary>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        public bool UpdateEX(int ProductId, int CateId)
        {
            return dal.UpdateEX(ProductId, CateId);
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCountEx(string strWhere, int CateId)
        {
            return dal.GetRecordCountEx(strWhere, CateId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere, int CateId)
        {
            return dal.GetListEx(strWhere, CateId);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.Product> GetListByPageEx(string strWhere, int CateId, string orderby, int startIndex, int endIndex)
        {
            DataSet ds= dal.GetListByPageEx(strWhere, CateId, orderby, startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }


        public void AddProduct()
        {
            ITopClient client = BLL.Tao.TaoBaoConfig.GetTopClient();
            TaobaokeItemsCouponGetRequest req = new TaobaokeItemsCouponGetRequest();
            req.Keyword = "品牌";
            req.ShopType = "b";
            req.Sort = "commissionRate_desc";
            req.StartCredit = "5goldencrown";
            req.Fields = "num_iid,title,nick,pic_url,price,click_url,commission,commission_rate,commission_num,commission_volume,shop_click_url,seller_credit_score,item_location,volume,coupon_price,coupon_rate,coupon_start_time,coupon_end_time,shop_type";
            req.PageSize = 100L;
            TaobaokeItemsCouponGetResponse response = client.Execute(req);
          
            if (response.TaobaokeItems.Count > 0)
            {
                  YSWL.MALL.Model.Tao.Product product = null;
                foreach(var item in response.TaobaokeItems)
                {
                    if (!Exists(item.NumIid))
                    {
                        product = new Model.Tao.Product();
                        product.CategoryID = 0;
                        product.ClickUrl = item.ClickUrl;
                        product.Commission = Common.Globals.SafeDecimal(item.Commission, 0);
                        product.CommissionNum = Common.Globals.SafeInt(item.CommissionNum, 0);
                        product.CommissionRate = Common.Globals.SafeDecimal(item.CommissionRate, 0);
                        product.CommissionVolume = Common.Globals.SafeDecimal(item.CommissionVolume, 0);
                        product.CouponEndTime = Common.Globals.SafeDateTime(item.CouponEndTime, DateTime.Now);
                        product.CouponPrice = Common.Globals.SafeDecimal(item.CouponPrice, 0);
                        product.CouponRate = Common.Globals.SafeDecimal(item.CouponRate, 0);
                        product.CouponStartTime = Common.Globals.SafeDateTime(item.CouponStartTime, DateTime.Now);
                        product.ImageUrl = item.PicUrl;
                        product.Price = Common.Globals.SafeDecimal(item.Price, 0);
                        product.ProductID = item.NumIid;
                        product.ProductName = item.Title.Replace("<span class=H>", "").Replace("</span>", ""); 
                        product.Rebate = product.Commission * 0.8m;
                        product.Recomend = 1;
                        product.SellerNick = item.Nick;
                        product.SellerScore = item.SellerCreditScore;
                        product.ShopType = item.ShopType;
                        product.ShopUrl = item.ShopClickUrl;
                        product.SkipCount = 0;
                        product.Status = 1;
                        product.Tags = "";
                        product.Volume = item.Volume;
                        product.CreatedDate = DateTime.Now;
                        Add(product);
                    }
                }
            }
        }
        /// <summary>
        /// 根据条件获取淘宝商品数据
        /// </summary>
        /// <param name="cid">商品分类ID</param>
        /// <param name="keyword">商品关键字</param>
        /// <param name="page_no">页数</param>
        /// <param name="page_size">每页返回结果数</param>
        /// <param name="shop_type">店铺类型.默认all,商城:b,集市:c </param>
        /// <param name="area">商品所在地</param>
        /// <param name="start_coupon_rate">设置折扣比例范围下限,如：7000表示70.00% </param>
        /// <param name="end_coupon_rate">设置折扣比例范围上限,如：8000表示80.00%.注：要起始折扣比率和最高折扣比率一起设置才有效 </param>
        /// <param name="start_commission_rate">起始佣金比率选项，如：1234表示12.34% </param>
        /// <param name="end_commission_rate">最高佣金比率选项，如：2345表示23.45%。注：要起始佣金比率和最高佣金比率一起设置才有效。 </param>
        /// <param name="start_credit">卖家信用: 1heart(一心) 2heart (两心) 3heart(三心) 4heart(四心) 5heart(五心) 1diamond(一钻) 2diamond(两钻) 3diamond(三钻) 4diamond(四钻) 5diamond(五钻) 1crown(一冠) 2crown(两冠) 3crown(三冠) 4crown(四冠) 5crown(五冠) 1goldencrown(一黄冠) 2goldencrown(二黄冠) 3goldencrown(三黄冠) 4goldencrown(四黄冠) 5goldencrown(五黄冠) </param>
        /// <param name="end_credit">可选值和start_credit一样.start_credit的值一定要小于或等于end_credit的值。注：end_credit与start_credit一起使用才生效 </param>
        public void GetProductDate(int cid, string keyword, int page_no=1, int page_size = 40, string shop_type = "all", string area = "", int start_coupon_rate = 0, int end_coupon_rate = 0, int start_commission_rate = 0, int end_commission_rate = 0, string start_credit = "", string end_credit = "")
        {
            ITopClient client = BLL.Tao.TaoBaoConfig.GetTopClient();
            TaobaokeItemsCouponGetRequest req = new TaobaokeItemsCouponGetRequest();
            //获取返利比率
            string RebateRate = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("RebateRate");
            decimal Rate = Common.Globals.SafeDecimal(RebateRate, 0.8m);
            if (cid > 0)
            {
                req.Cid = cid;
            }
            req.PageNo = page_no;
            req.PageSize = page_size;
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                req.Keyword = keyword;
            }
            if (!String.IsNullOrWhiteSpace(area))
            {
                req.Area = area;
            }
            if (start_coupon_rate > 0)
            {
                req.StartCouponRate = start_coupon_rate;
            }
            if (end_coupon_rate > 0)
            {
                req.EndCouponRate = end_coupon_rate;
            }

            if (start_commission_rate > 0)
            {
                req.StartCommissionRate = start_commission_rate;
            }
            if (end_commission_rate > 0)
            {
                req.EndCommissionRate = end_commission_rate;
            }
            if (!String.IsNullOrWhiteSpace(start_credit))
            {
                req.StartCredit = start_credit;
            }
            if (!String.IsNullOrWhiteSpace(end_credit))
            {
                req.EndCredit = end_credit;
            }
            req.ShopType = shop_type;
            req.Sort = "commissionRate_desc";
            req.StartCredit = "5goldencrown";
            req.Fields = "num_iid,title,nick,pic_url,price,click_url,commission,commission_rate,commission_num,commission_volume,shop_click_url,seller_credit_score,item_location,volume,coupon_price,coupon_rate,coupon_start_time,coupon_end_time,shop_type";
            TaobaokeItemsCouponGetResponse response = client.Execute(req);

            if (response.TaobaokeItems.Count > 0)
            {
                YSWL.MALL.Model.Tao.Product product = null;
                foreach (var item in response.TaobaokeItems)
                {
                    if (!Exists(item.NumIid))
                    {
                        product = new Model.Tao.Product();
                        product.CategoryID = 0;
                        product.ClickUrl = item.ClickUrl;
                        product.Commission = Common.Globals.SafeDecimal(item.Commission, 0);
                        product.CommissionNum = Common.Globals.SafeInt(item.CommissionNum, 0);
                        product.CommissionRate = Common.Globals.SafeDecimal(item.CommissionRate, 0);
                        product.CommissionVolume = Common.Globals.SafeDecimal(item.CommissionVolume, 0);
                        product.CouponEndTime = Common.Globals.SafeDateTime(item.CouponEndTime, DateTime.Now);
                        product.CouponPrice = Common.Globals.SafeDecimal(item.CouponPrice, 0);
                        product.CouponRate = Common.Globals.SafeDecimal(item.CouponRate, 0);
                        product.CouponStartTime = Common.Globals.SafeDateTime(item.CouponStartTime, DateTime.Now);
                        product.ImageUrl = item.PicUrl;
                        product.Price = Common.Globals.SafeDecimal(item.Price, 0);
                        product.ProductID = item.NumIid;
                        product.ProductName = item.Title.Replace("<span class=H>", "").Replace("</span>", ""); 
                        product.Rebate = product.Commission * Rate;
                        product.Recomend = 0;
                        product.SellerNick = item.Nick;
                        product.SellerScore = item.SellerCreditScore;
                        product.ShopType = item.ShopType;
                        product.ShopUrl = item.ShopClickUrl;
                        product.SkipCount = 0;
                        product.Status = 1;
                        product.Tags = keyword;
                        product.Volume = item.Volume;
                        product.CreatedDate = DateTime.Now;
                        Add(product);
                    }
                }
            }
        }


        public YSWL.MALL.Model.Tao.Product GetProductModel(string ProductId)
        {
            //获取返利比率
            string RebateRate = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("RebateRate");
            decimal Rate = Common.Globals.SafeDecimal(RebateRate, 0.8m);

            YSWL.MALL.Model.Tao.Product PModel = new Model.Tao.Product();
            ITopClient client = BLL.SNS.TaoBaoConfig.GetTopClient();
            TaobaokeWidgetItemsConvertRequest req = new TaobaokeWidgetItemsConvertRequest();
            req.Fields = "num_iid,title,nick,pic_url,price,click_url,commission,commission_rate,commission_num,commission_volume,shop_click_url,seller_credit_score,item_location,volume";
            req.NumIids = ProductId;// "7644984798";
            TaobaokeWidgetItemsConvertResponse response = client.Execute(req);
            //是推广淘宝客数据
            if (response.TaobaokeItems.Count > 0)
            {
                PModel.ClickUrl = response.TaobaokeItems[0].ClickUrl;
                PModel.Commission = Common.Globals.SafeDecimal(response.TaobaokeItems[0].Commission, 0);
                PModel.CommissionNum = Common.Globals.SafeInt(response.TaobaokeItems[0].CommissionNum, 0);
                PModel.CommissionRate = Common.Globals.SafeDecimal(response.TaobaokeItems[0].CommissionRate, 0);
                PModel.ImageUrl = response.TaobaokeItems[0].PicUrl;
                PModel.Price = Common.Globals.SafeDecimal(response.TaobaokeItems[0].Price, 0);
                PModel.CouponPrice = Common.Globals.SafeDecimal(response.TaobaokeItems[0].CouponPrice, 0);
                PModel.ProductID = response.TaobaokeItems[0].NumIid;
                PModel.ProductName = response.TaobaokeItems[0].Title.Replace("<span class=H>", "").Replace("</span>", "");
                PModel.Rebate = PModel.Commission * Rate;
                PModel.SellerNick = response.TaobaokeItems[0].Nick;
                PModel.SellerScore = response.TaobaokeItems[0].SellerCreditScore;
                PModel.ShopUrl = response.TaobaokeItems[0].ShopClickUrl;
                PModel.Volume = response.TaobaokeItems[0].Volume;
                PModel.CreatedDate = DateTime.Now;

            }
            else
            {
                ItemGetRequest reqEx = new ItemGetRequest();
                reqEx.Fields = "num_iid,title,price,num_iid,title,cid,nick,desc,price,item_img.url,shop_click_url,num,props_name,detail_url,pic_url";
                reqEx.NumIid =Common.Globals.SafeLong(ProductId,0);
                ItemGetResponse responseEx = client.Execute(reqEx);
                if (responseEx.Item != null)
                {
                    PModel.ClickUrl = responseEx.Item.DetailUrl;
                    PModel.Commission = 0;
                    PModel.CommissionNum = 0;
                    PModel.CommissionRate = 0;
                    PModel.ImageUrl = responseEx.Item.PicUrl;
                    PModel.Price = Common.Globals.SafeDecimal(responseEx.Item.Price, 0);
                    PModel.ProductID = responseEx.Item.NumIid;
                    PModel.CouponPrice = Common.Globals.SafeDecimal(responseEx.Item.Price, 0);
                    PModel.ProductName = responseEx.Item.Title.Replace("<span class=H>", "").Replace("</span>", "");
                    PModel.Rebate = 0;
                    PModel.SellerNick = responseEx.Item.Nick;
                    PModel.SellerScore = 0;
                    //PModel.Volume = responseEx.Item.;
                    PModel.CreatedDate = DateTime.Now;
                }
            }
         

            return PModel;
        }

        public List<YSWL.MALL.Model.Tao.Product> GetFavList(string sessionKey)
        {
             ITopClient client = BLL.Tao.TaoBaoConfig.GetTopClient();
            FavoriteSearchRequest req = new FavoriteSearchRequest();
            req.CollectType = "ITEM";
            req.PageNo = 10L;
            FavoriteSearchResponse response = client.Execute(req, sessionKey);
            List<YSWL.MALL.Model.Tao.Product> ProductList = new List<Model.Tao.Product>();
            if (response.CollectItems.Count > 0)
            {
                YSWL.MALL.Model.Tao.Product product = null;
                foreach (var item in response.CollectItems)
                {
                   product= GetProductModel(item.ItemNumid.ToString());
                   ProductList.Add(product);
                }
            }
            return ProductList;
        }

        public List<YSWL.MALL.Model.Tao.Product> GetTopRateList(int top, string SellerNick)
        {
            DataSet ds = dal.GetList(top, " Status=1 and SellerNick='" + Common.InjectionFilter.SqlFilter(SellerNick) + "'", "Rebate desc");
            return DataTableToList(ds.Tables[0]);
        }
		#endregion  ExtensionMethod
	}
}

