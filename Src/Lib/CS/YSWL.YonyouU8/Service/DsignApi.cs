﻿
namespace YSWL.YonyouU8.Service
{ 
    /// <summary>
    /// 凭证类别 API
    /// </summary>
    public class DsignApi : BasicApi
    {
        public const string RESOURCE_ID = "dsign";

        public DsignApi()
            : base(RESOURCE_ID) { }

        public DsignApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
        { }
        public new Model.BusinessObject Add(string data, string biz_id)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Add2(string data, string tradeid)
        {
            throw new System.NotImplementedException();
        }
    }
}
