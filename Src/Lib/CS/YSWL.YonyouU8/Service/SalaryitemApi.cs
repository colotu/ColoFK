using System;
using System.Collections.Generic;
using System.Text;

namespace YSWL.YonyouU8.Service
{ /// <summary>
    /// 工资项目 API
    /// </summary>
    public class SalaryitemApi : BasicApi
    {
        public const string RESOURCE_ID = "salaryitem";

        public SalaryitemApi()
            : base(RESOURCE_ID) { }
        public SalaryitemApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
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
