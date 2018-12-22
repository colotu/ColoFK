
namespace YSWL.YonyouU8.Service
{
    /// <summary>
    /// 项目 API
    /// </summary>
   public  class FitemApi : BasicApi
    {
       public const string RESOURCE_ID = "fitem";

       public FitemApi()
           : base(RESOURCE_ID){ }

        public FitemApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
        { }
        public new Model.BusinessObject Get(string id)
       {
           throw new System.NotImplementedException();
       }

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
