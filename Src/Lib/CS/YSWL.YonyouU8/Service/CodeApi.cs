
namespace YSWL.YonyouU8.Service
{
    /// <summary>
    /// 科目 API
    /// </summary>
    public class CodeApi : BasicApi
    {
        public const string RESOURCE_ID = "code";

        public CodeApi()
            : base(RESOURCE_ID) { }

        public CodeApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
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
