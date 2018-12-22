using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YSWL.Json.RPC;
using YSWL.MALL.Model.Settings;
using YSWL.Json;

namespace YSWL.MALL.Web.Handlers.SNS.API
{
    public partial class SNSHandler
    {
        #region 获取广告位
        [JsonRpcMethod("AdDetail", Idempotent = true)]
        [JsonRpcHelp("根据广告位Id获取广告位数据")]
        public JsonArray AdDetail(int Aid,int Top=0)
        {
            YSWL.MALL.BLL.Settings.Advertisement bll = new YSWL.MALL.BLL.Settings.Advertisement();
            List<Advertisement> list = bll.GetListByAidCache(Aid, Top);
            Json.JsonArray array = new JsonArray();
            JsonObject json;
            JsonObject result = new JsonObject();
            if (list == null)
            {
                return null;
            }
            foreach (Advertisement item in list)
            {
                json = new JsonObject();
                json.Put("id", item.AdvertisementId);
                json.Put("title", item.AlternateText);
                json.Put("pic", item.FileUrl);
                json.Put("url", item.NavigateUrl);
                array.Add(json);
            }
            return array;
        }
        #endregion
    }
}