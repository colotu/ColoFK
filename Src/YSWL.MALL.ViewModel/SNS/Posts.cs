using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.MALL.Model.SNS;

namespace YSWL.MALL.ViewModel.SNS
{
    public class Posts
    {
        public YSWL.MALL.Model.SNS.Posts Post { get; set; }
        public YSWL.MALL.Model.SNS.Posts OrigPost { get; set; }

    }

    public class VodeoList
    {
        public Model.Members.UsersExpModel UserModel { get; set; }
        public List<Posts> VodeoListWaterfall { get; set; }
        public int CommentCount { get; set; }
        public int CommentPageSize { get; set; }
        public Webdiyer.WebControls.Mvc.PagedList<Model.SNS.Posts> VodeoPagedList { get; set; }
    }
}
