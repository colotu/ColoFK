
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.ViewModel.SNS
{
    public class ProfileLeft
    {
        public List<YSWL.MALL.Model.SNS.UserShip> shipList { get; set; }
        public List<YSWL.MALL.Model.SNS.Groups> joingroupList { get; set; }
        public List<YSWL.MALL.Model.SNS.Groups> creategroupList { get; set; }
    }

    public class SelfRight
    {
        public YSWL.MALL.Model.Members.UsersExpModel UserInfo { get; set; }
        public List<YSWL.MALL.Model.SNS.Groups> MyGroups { get; set; }
        public List<YSWL.MALL.ViewModel.SNS.AlbumIndex> MyAlbum { get; set; }
      
    }
}
