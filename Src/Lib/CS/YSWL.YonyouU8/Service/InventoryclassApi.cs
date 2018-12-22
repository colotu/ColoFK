
namespace YSWL.YonyouU8.Service
{ /// <summary>
    /// 存货分类 API
    /// </summary>
    public class InventoryclassApi : BasicApi
    {
        public const string RESOURCE_ID = "inventoryclass";

        public InventoryclassApi()
            : base(RESOURCE_ID) { }

        public InventoryclassApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
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
