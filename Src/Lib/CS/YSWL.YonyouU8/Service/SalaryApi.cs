namespace YSWL.YonyouU8.Service
{
    /// <summary>
    /// 工资记录 API
    /// </summary>
    public class SalaryApi : BasicApi
    {
        public const string RESOURCE_ID = "salary";

        public SalaryApi()
            : base(RESOURCE_ID) { }
        public SalaryApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
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