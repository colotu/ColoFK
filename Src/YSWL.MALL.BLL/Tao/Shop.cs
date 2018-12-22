using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.Model.Tao;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Tao;
using YSWL.TaoBao;
using YSWL.TaoBao.Request;
using YSWL.TaoBao.Response;
using System.Linq;
namespace YSWL.MALL.BLL.Tao
{
    /// <summary>
    /// Shop
    /// </summary>
    public partial class Shop
    {
        private readonly IShop dal = DATao.CreateShop();
        public Shop()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ShopId)
        {
            return dal.Exists(ShopId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Tao.Shop model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Tao.Shop model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ShopId)
        {

            return dal.Delete(ShopId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ShopIdlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(ShopIdlist,0) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Tao.Shop GetModel(long ShopId)
        {

            return dal.GetModel(ShopId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Tao.Shop GetModelByCache(long ShopId)
        {

            string CacheKey = "ShopModel-" + ShopId;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ShopId);
                    if (objModel != null)
                    {
                      int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Tao.Shop)objModel;
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
        public List<YSWL.MALL.Model.Tao.Shop> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.Shop> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Tao.Shop> modelList = new List<YSWL.MALL.Model.Tao.Shop>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Tao.Shop model;
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
        public bool Exists(string  name)
        {
            return dal.Exists(name);
        }
        public void AddShop()
        {
            ITopClient client = BLL.SNS.TaoBaoConfig.GetTopClient();
            TaobaokeShopsGetRequest req = new TaobaokeShopsGetRequest();
            req.Fields = "seller_nick,user_id,click_url, shop_title ,commission_rate, seller_credit,shop_type,auction_count,total_auction";
            req.Keyword = "女装";
            req.StartCredit = "5heart";
            // req.StartCredit = "1crown";
            req.OnlyMall = true;
            req.PageSize = 100L;
            TaobaokeShopsGetResponse response = client.Execute(req);
            if (response.TaobaokeShops.Count > 0)
            {
                YSWL.MALL.Model.Tao.Shop shopModel = null;
                foreach (var item in response.TaobaokeShops)
                {
                    if (!Exists(item.ShopTitle))
                    {
                        shopModel = new Model.Tao.Shop();
                        ShopGetRequest req2 = new ShopGetRequest();
                        req2.Fields = "pic_path";
                        req2.Nick = item.SellerNick;
                        ShopGetResponse response2 = client.Execute(req2);
                        shopModel.CategoryId = 0;
                        shopModel.AuctionCount = item.AuctionCount;
                        shopModel.ClickUrl = item.ClickUrl;
                        shopModel.Recomend = 0;
                        shopModel.SellerCredit = item.SellerCredit == null ? "" : item.SellerCredit;
                        shopModel.SellerNick = item.SellerNick;
                        shopModel.ShopName = item.ShopTitle;
                        shopModel.Status = 1;
                        shopModel.TotalAuction = item.TotalAuction;
                        shopModel.CommissionRate = item.CommissionRate;
                        if (response2.Shop != null && !String.IsNullOrWhiteSpace(response2.Shop.PicPath))
                        {
                            shopModel.ShopLogo = "http://logo.taobao.com/shop-logo" + response2.Shop.PicPath;
                        }
                        else
                        {
                            shopModel.ShopLogo = "";
                        }
                        Add(shopModel);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="keyword"></param>
        /// <param name="start_credit"></param>
        /// <param name="end_credit"></param>
        /// <param name="start_commissionrate"></param>
        /// <param name="end_commissionrate"></param>
        public void GetShopDate(int cid, string keyword, int page_no = 1, int page_size = 40, string start_credit = "", string end_credit = "", string start_commissionrate="", string end_commissionrate="")
        {
            //循环获取商铺
            ITopClient client = BLL.SNS.TaoBaoConfig.GetTopClient();
            TaobaokeShopsGetRequest req = new TaobaokeShopsGetRequest();
            req.Fields = "seller_nick,user_id,click_url, shop_title ,commission_rate, seller_credit,shop_type,auction_count,total_auction";
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

            if (!String.IsNullOrWhiteSpace(start_commissionrate))
            {
                req.StartCommissionrate = start_commissionrate;
            }
            if (!String.IsNullOrWhiteSpace(end_commissionrate))
            {
                req.EndCommissionrate = end_commissionrate;
            }
            if (!String.IsNullOrWhiteSpace(start_credit))
            {
                req.StartCredit = start_credit;
            }
            if (!String.IsNullOrWhiteSpace(end_credit))
            {
                req.EndCredit = end_credit;
            }
            TaobaokeShopsGetResponse response = client.Execute(req);
            if (response.TaobaokeShops.Count > 0)
            {
                YSWL.MALL.Model.Tao.Shop shopModel = null;
                foreach (var item in response.TaobaokeShops)
                {
                    if (!Exists(item.ShopTitle))
                    {
                        shopModel = new Model.Tao.Shop();
                        ShopGetRequest req2 = new ShopGetRequest();
                        req2.Fields = "pic_path";
                        req2.Nick = item.SellerNick;
                        ShopGetResponse response2 = client.Execute(req2);
                        shopModel.CategoryId = 0;
                        shopModel.AuctionCount = item.AuctionCount;
                        shopModel.ClickUrl = item.ClickUrl;
                        shopModel.Recomend = 0;
                        shopModel.SellerCredit = item.SellerCredit == null ? "" : item.SellerCredit;
                        shopModel.SellerNick = item.SellerNick;
                        shopModel.ShopName = item.ShopTitle;
                        shopModel.Status = 1;
                        shopModel.TotalAuction = item.TotalAuction;
                        shopModel.CommissionRate = item.CommissionRate;
                        if (response2.Shop != null && !String.IsNullOrWhiteSpace(response2.Shop.PicPath))
                        {
                            shopModel.ShopLogo = "http://logo.taobao.com/shop-logo" + response2.Shop.PicPath;
                        }
                        else
                        {
                            shopModel.ShopLogo = "";
                        }
                        Add(shopModel);
                    }
                }
            }
        }
        /// <summary>
        /// 批量转移分类
        /// </summary>
        /// <param name="ProductIds"></param>
        /// <returns></returns>
        public bool UpdateCateList(string ids, int CateId)
        {
            return dal.UpdateCateList(ids, CateId);
        }

        public bool UpdateStateList(string ids, int state)
        {
            return dal.UpdateStateList(ids, state);
        }

        public bool UpdateRecomendList(string ids, int Recomend)
        {
            return dal.UpdateRecomendList(ids, Recomend);
        }
        /// <summary>
        /// 获取推荐的前几条数据
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<YSWL.MALL.Model.Tao.Shop> GetTopList(int top)
        {
            DataSet ds = dal.GetList(top, " Status=1 and  Recomend=2", "CommissionRate desc");
            return DataTableToList(ds.Tables[0]);
        }

        public List<YSWL.MALL.Model.Tao.Shop> GetRecommdList(int top)
        {
            List<YSWL.MALL.Model.Tao.Shop> list = GetTopList(6);
            List<YSWL.MALL.Model.Tao.Shop> ShopList = new List<YSWL.MALL.Model.Tao.Shop>();
            YSWL.MALL.BLL.Tao.Product productBll=new Product();
            foreach (var item in list)
            {
               
                List<YSWL.MALL.Model.Tao.Product> products = productBll.GetTopRateList(2, item.SellerNick);
                if (products != null && products.Count > 0)
                {
                    item.Product1 = products.ElementAt(0);
                    if (products.Count > 1)
                    {
                        item.Product1 = products.ElementAt(1);
                    }
                }
                ShopList.Add(item);
            }
            return ShopList;
        }
        #endregion  ExtensionMethod
    }
}

