using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.ViewModel.SNS
{
    #region 组装的三级类别viewmodel


    //父级元素
    public class ProductCategory
    {
        public YSWL.MALL.Model.SNS.Categories ParentModel = new Model.SNS.Categories();
        public List<YSWL.MALL.ViewModel.SNS.SonCategory> SonList = new List<SonCategory>();
        public List<YSWL.MALL.Model.SNS.Categories> ChildList = new List<Model.SNS.Categories>();
        public List<YSWL.MALL.ViewModel.SNS.CType> TagsList = new List<CType>();
        public List<YSWL.MALL.Model.SNS.Products> ProductListWaterfall { get; set; }
        private List<YSWL.MALL.Model.SNS.SearchWordTop> _keywordlist { get; set; }
        public List<YSWL.MALL.Model.SNS.SearchWordTop>[] KeyWordList4For { get; set; }
        private Webdiyer.WebControls.Mvc.PagedList<YSWL.MALL.Model.SNS.Products> _productPagedList;
        public Webdiyer.WebControls.Mvc.PagedList<YSWL.MALL.Model.SNS.Products> ProductPagedList
        {
            get { return _productPagedList; }
            set
            {
                _productPagedList = value;
                if (value == null || value.Count < 1) return;
                List<YSWL.MALL.Model.SNS.Products>[] list = new[] { new List<YSWL.MALL.Model.SNS.Products>(), new List<YSWL.MALL.Model.SNS.Products>(), new List<YSWL.MALL.Model.SNS.Products>(), new List<YSWL.MALL.Model.SNS.Products>() };
                int index = 0;
                value.ForEach(image =>
                {
                    //reset
                    if (index == 4) index = 0;
                    list[index++].Add(image);
                });
                this.ProductList4ForCol = list;
            }
        }
        public List<YSWL.MALL.Model.SNS.SearchWordTop> KeyWordList
        {
            get { return _keywordlist; }
            set
            {
                _keywordlist = value;

                if (value == null || value.Count < 1) return;
                List<YSWL.MALL.Model.SNS.SearchWordTop>[] list = new[] { new List<YSWL.MALL.Model.SNS.SearchWordTop>(), new List<YSWL.MALL.Model.SNS.SearchWordTop>(), new List<YSWL.MALL.Model.SNS.SearchWordTop>(), new List<YSWL.MALL.Model.SNS.SearchWordTop>() };
                int index = 0;
                value.ForEach(image =>
                {
                    //reset
                    if (index == 4) index = 0;
                    list[index++].Add(image);
                });
                this.KeyWordList4For = list;
            }

        }
        public List<YSWL.MALL.Model.SNS.Products>[] ProductList4ForCol { get; set; }
        private List<YSWL.MALL.Model.SNS.Comments> _commentlist;
        public List<YSWL.MALL.Model.SNS.Comments> CommentList
        {
            get { return _commentlist; }
            set
            {
                _commentlist = value;
                if (_commentlist != null && _commentlist.Count > 0 && ProductPagedList != null && ProductPagedList.Count > 0)
                {
                    ProductPagedList.ForEach(item => SetDicComment(item.ProductID, (from comment in _commentlist where comment.TargetId == item.ProductID select comment)));
                }
            }
        }
        public Dictionary<long, IEnumerable<YSWL.MALL.Model.SNS.Comments>> DicCommentList = new Dictionary<long, IEnumerable<Model.SNS.Comments>>();
        public string CurrentCateName { set; get; }
        public int CurrentCid { set; get; }
        public int CurrentMinPrice { set; get; }
        public int CurrentMaxPrice { set; get; }
        public string CurrentSequence { set; get; }
        public void SetDicComment(long ProductId, IEnumerable<YSWL.MALL.Model.SNS.Comments> list)
        {
            this.DicCommentList.Add(ProductId, list);
        }

    }

    #region 分类的子集model
    /// <summary>
    ///子集元素
    /// </summary>
    public class SonCategory
    {
        //父元素的model
        public YSWL.MALL.Model.SNS.Categories ParentModel = new Model.SNS.Categories();
        //对应的资源的list
        public List<YSWL.MALL.Model.SNS.Categories> Grandson = new List<YSWL.MALL.Model.SNS.Categories>();
    }

    #endregion
    #region 标签类别和标签子集的model
    public class CType
    {
        public YSWL.MALL.Model.SNS.TagType MTagType = new Model.SNS.TagType();
        public List<YSWL.MALL.Model.SNS.Tags> Taglist = new List<Model.SNS.Tags>();

    }
    #endregion
    #endregion
}
