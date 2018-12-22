using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.ViewModel.SNS
{
    public class PostsPage
    {
            public List<YSWL.MALL.ViewModel.SNS.Posts> DataList = new List<ViewModel.SNS.Posts>();
            public List<YSWL.MALL.Model.SNS.AlbumType> AlbumTypeList=new List<Model.SNS.AlbumType>();
            public int PageSize{set ;get;}
            public string Type{get;set;}
            public int DataCount{set;get;}
            public  int UserID{set;get;}
            public string NickName { set; get; }
            public YSWL.MALL.Model.SNS.PostsSet Setting { set; get; }
    }
}
