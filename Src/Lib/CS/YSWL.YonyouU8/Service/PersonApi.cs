
namespace YSWL.YonyouU8.Service
{
    /// <summary>
    /// 人员 API
    /// </summary>
    public class PersonApi : BasicApi
    {
        public const string RESOURCE_ID = "person";

        public PersonApi()
            : base(RESOURCE_ID) { }

        public PersonApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
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

