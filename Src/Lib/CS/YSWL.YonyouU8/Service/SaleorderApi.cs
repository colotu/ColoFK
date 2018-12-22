namespace YSWL.YonyouU8.Service
{
    #region Imports

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// 销售订单 API
    /// </summary>
    public class SaleorderApi : BillApi
    {
        public const string RESOURCE_ID = "saleorder";

        public SaleorderApi()
            : base(RESOURCE_ID) { }
        public SaleorderApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
        { }
        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }
      
    }
}
