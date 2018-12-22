using System.Collections.Generic;

namespace YSWL.YonyouU8.Service
{ 
    /// <summary>
    /// 商旅订单 API
    /// </summary>
    public class BusinesstravelorderApi : BillApi
    {
        public const string RESOURCE_ID = "businesstravelorder";

        public BusinesstravelorderApi()
            : base(RESOURCE_ID) { }
        public BusinesstravelorderApi(string fromAccount, string toAccount, string appKey)  : base(RESOURCE_ID, fromAccount, toAccount, appKey) 
        { }
        public new Model.BusinessObject List(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Audit(string voucherCode
            , string userId
            , string personCode
            , string opinion
            , bool agree)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Abandon(string voucherCode
            , string userId
            , string personCode
            , string opinion)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject History(string voucherCode
            , string userId
            , string personCode)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Tasks(string personCode
            , int? state
            , string taskDesc)
        {
            throw new System.NotImplementedException();
        }

    }
}
