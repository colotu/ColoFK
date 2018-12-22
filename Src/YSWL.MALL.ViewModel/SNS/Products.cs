using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.MALL.Model.SNS;

namespace YSWL.MALL.ViewModel.SNS
{
    public  class Products:YSWL.MALL.Model.SNS.Products
    {
        public List<YSWL.MALL.Model.SNS.Comments> commentlist;

    }

    public class ProductAlbum
    {
        public List<YSWL.MALL.Model.SNS.UserAlbums> UserAlbums = new List<UserAlbums>();
        public List<YSWL.MALL.Model.SNS.Categories> ProductCateList = new List<YSWL.MALL.Model.SNS.Categories>();
    }
}
