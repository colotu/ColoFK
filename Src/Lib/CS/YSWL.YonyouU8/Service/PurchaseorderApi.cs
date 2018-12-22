namespace YSWL.YonyouU8.Service
{
    #region Imports
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// 采购订单 API
    /// </summary>
    public class PurchaseorderApi : BillApi
    {
        public const string RESOURCE_ID = "Purchaseorder";

        public PurchaseorderApi()
            : base(RESOURCE_ID) { }
        public PurchaseorderApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
        { }
        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
