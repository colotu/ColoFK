
namespace YSWL.YonyouU8.Service
{
    /// <summary>
    /// 存货 API
    /// </summary>
    public class InventoryApi : BasicApi
    {
        public const string RESOURCE_ID = "inventory";

        public InventoryApi()
            : base(RESOURCE_ID) { }
        public InventoryApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
        { }
    }
}
