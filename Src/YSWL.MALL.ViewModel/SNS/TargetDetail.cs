using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.ViewModel.SNS
{
    #region 对图片和商品的model进行封装
    public class TargetDetail
    {
        public YSWL.MALL.Model.Members.UsersExpModel UserModel = new Model.Members.UsersExpModel();
        public YSWL.MALL.Model.SNS.UserAlbums UserAlums = new Model.SNS.UserAlbums();
        public List<YSWL.MALL.Model.SNS.Tags> ProductTagList = new List<Model.SNS.Tags>();
        public List<YSWL.MALL.Model.SNS.PhotoTags> PhotoTagList = new List<Model.SNS.PhotoTags>();
        public List<YSWL.MALL.Model.SNS.Products>[] RecommandProduct4ThreeCol { get; set; }
        public List<YSWL.MALL.Model.SNS.Photos>[] RecommandPhoto4ThreeCol { get; set; }
        private List<YSWL.MALL.Model.SNS.Products> _recommandproduct ;
        public List<YSWL.MALL.Model.SNS.Products> RecommandProduct
        {
            get { return _recommandproduct; }
            set{_recommandproduct=value;
            if (value == null || value.Count < 1) return;
            List<YSWL.MALL.Model.SNS.Products>[] list = new[] { new List<YSWL.MALL.Model.SNS.Products>(), new List<YSWL.MALL.Model.SNS.Products>(), new List<YSWL.MALL.Model.SNS.Products>()};
            int index = 0;
            value.ForEach(image =>
            {
                //reset
                if (index == 3) index = 0;
                list[index++].Add(image);
            });
            this.RecommandProduct4ThreeCol = list;
            }
        }
        private List<YSWL.MALL.Model.SNS.Photos> _recommandphoto;
        public List<YSWL.MALL.Model.SNS.Photos> RecommandPhoto
        {
            get { return _recommandphoto; }
            set
            {
                _recommandphoto = value;
                if (value == null || value.Count < 1) return;
                List<YSWL.MALL.Model.SNS.Photos>[] listPhoto = new[] { new List<YSWL.MALL.Model.SNS.Photos>(), new List<YSWL.MALL.Model.SNS.Photos>(), new List<YSWL.MALL.Model.SNS.Photos>() };
                int index = 0;
                value.ForEach(image =>
                {
                    //reset
                    if (index == 3) index = 0;
                    listPhoto[index++].Add(image);
                });
                this.RecommandPhoto4ThreeCol = listPhoto;
            }
        }
        public int FavCount { get; set; }
        public List<YSWL.MALL.Model.SNS.UserFavourite> FavUserList { get; set; }
        public List<string> AlumsCoverList=new List<string>();
        public List<string> CovorImageList { get; set; }
        public int CommentPageSize { set; get; }
        private YSWL.MALL.Model.SNS.Photos photo;
        public YSWL.MALL.Model.SNS.Photos Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                if (photo != null)
                {
                    this.TargetId = photo.PhotoID;
                    this.Type = "Photo";
                    this.Userid = photo.CreatedUserID;
                    this.Nickname = photo.CreatedNickName;
                    this.Commentcount = photo.CommentCount;
                    this.CreatedDate = photo.CreatedDate;
                    this.Favouritecount = photo.FavouriteCount;
                    this.Sharedes = photo.Description;
                    this._targetname = photo.PhotoName;
                    this._thumbimageurl = photo.ThumbImageUrl;
                    this.PvCount = photo.PVCount;
                    this.Imageurl = photo.PhotoUrl;
                    this.IsRecommand = photo.IsRecomend;
                    this.Tags = photo.Tags;
                }
            }
        }
        private YSWL.MALL.Model.SNS.Products product;

        public YSWL.MALL.Model.SNS.Products Product
        {
            get { return product; }
            set
            {
                product = value;
                if (product != null)
                {
                    this.TargetId = Convert.ToInt32(product.ProductID);
                    this.Type = "Product";
                    this.Userid = product.CreateUserID;
                    this.Nickname = product.CreatedNickName;
                    this.Commentcount = product.CommentCount;
                    this.CreatedDate = product.CreatedDate;
                    this.Favouritecount = product.FavouriteCount;
                    this.Sharedes = product.ShareDescription;
                    this._targetname = product.ProductName;
                    this._thumbimageurl = product.ThumbImageUrl;
                    this.ProductUrl = product.ProductUrl;
                    this.Price = Product.Price.HasValue? Product.Price.Value:0;
                    this.PvCount = Product.PVCount;
                    this.IsRecommand = product.IsRecomend;
                    this.Tags = product.Tags;

                }

            }
        }
        private List<YSWL.MALL.Model.SNS.Comments> _commentlist;
        public List<YSWL.MALL.Model.SNS.Comments> CommentList
        {
            get { return _commentlist; }
            set
            {
                _commentlist = value;
                if (_commentlist != null && _commentlist.Count > 0 && RecommandProduct != null && RecommandProduct.Count > 0)
                {
                    RecommandProduct.ForEach(item => SetDicComment(item.ProductID, (from comment in _commentlist where comment.TargetId == item.ProductID select comment)));
                }
            }
        }
        public void SetDicComment(long ProductId, IEnumerable<YSWL.MALL.Model.SNS.Comments> list)
        {
            this.DicCommentList.Add(ProductId, list);
        }
        public Dictionary<long, IEnumerable<YSWL.MALL.Model.SNS.Comments>> DicCommentList = new Dictionary<long, IEnumerable<Model.SNS.Comments>>();
        private int _targetid;

        public int TargetId
        {
            get { return _targetid; }
            set { _targetid = value; }
        }
        private string _tags;
        public string Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }
        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _targetname;

        public string Targetname
        {
            get { return _targetname; }
            set { _targetname = value; }
        }
        private int _commentcount;

        public int Commentcount
        {
            get { return _commentcount; }
            set { _commentcount = value; }
        }
        private int _favouritecount;

        public int Favouritecount
        {
            get { return _favouritecount; }
            set { _favouritecount = value; }
        }
        private string _thumbimageurl;

        public string Thumbimageurl
        {
            get { return _thumbimageurl; }
            set { _thumbimageurl = value; }
        }
        private string _imageurl;
        public string Imageurl
        {
            get { return _imageurl; }
            set { _imageurl = value; }
        }
        private string _sharedes;

        public string Sharedes
        {
            get { return _sharedes; }
            set { _sharedes = value; }
        }
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private int _userid;

        public int Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        private string _nickname;

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        private DateTime _createddate;

        public DateTime CreatedDate
        {
            get { return _createddate; }
            set { _createddate = value; }
        }
        private string _producturl;

        public string ProductUrl
        {
            get { return _producturl; }
            set { _producturl = value; }
        }
        private int _isrecommand;
        public int IsRecommand
        {
            get { return _isrecommand; }
            set { _isrecommand = value; }
        }
        private int _pvcount;
        public int PvCount
        {
            get { return _pvcount; }
            set { _pvcount = value; }
        }
    } 
    #endregion
}
