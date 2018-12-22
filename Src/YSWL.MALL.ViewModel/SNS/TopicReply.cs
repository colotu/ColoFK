using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webdiyer.WebControls.Mvc;

namespace YSWL.MALL.ViewModel.SNS
{
     public  class TopicReply
     {   
         public  YSWL.MALL.Model.Members.UsersExpModel TopicPostUser{set;get;}
         public   YSWL.MALL.Model.SNS.GroupTopics Topic {set; get;}
         public YSWL.MALL.Model.SNS.Groups Group { set; get; }
         public List<YSWL.MALL.Model.SNS.GroupTopics> UserPostTopics { set; get; }
         public List<YSWL.MALL.Model.SNS.Groups> UserJoinGroups { set; get; }
         public List<YSWL.MALL.Model.SNS.GroupTopics> HotTopic { set; get; }
         public PagedList<YSWL.MALL.Model.SNS.GroupTopicReply> TopicsReply { set; get; }

    }
}
