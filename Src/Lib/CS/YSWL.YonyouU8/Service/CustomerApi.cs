using System;
using System.Collections.Generic;
using System.Text;

namespace YSWL.YonyouU8.Service
{
    /// <summary>
    /// 客户 API
    /// </summary>
    public class CustomerApi : BasicApi
    {
        public const string RESOURCE_ID = "customer";

        public CustomerApi()
            : base(RESOURCE_ID) { }
        public CustomerApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
        { }
    }
}
