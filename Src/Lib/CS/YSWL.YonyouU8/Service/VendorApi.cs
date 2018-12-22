﻿
namespace YSWL.YonyouU8.Service
{ 
    /// <summary>
    /// 供应商 API
    /// </summary>
    public class VendorApi : BasicApi
    {
        public const string RESOURCE_ID = "vendor";

        public VendorApi()
            : base(RESOURCE_ID) { }

        public VendorApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
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

