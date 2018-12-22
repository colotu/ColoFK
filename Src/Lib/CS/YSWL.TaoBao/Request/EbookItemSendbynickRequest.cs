using System;
using System.Collections.Generic;
using YSWL.TaoBao.Response;
using YSWL.TaoBao.Util;

namespace YSWL.TaoBao.Request
{
    /// <summary>
    /// TOP API: taobao.ebook.item.sendbynick
    /// </summary>
    public class EbookItemSendbynickRequest : ITopRequest<EbookItemSendbynickResponse>
    {
        /// <summary>
        /// 送电子书的活动ID
        /// </summary>
        public Nullable<long> ActId { get; set; }

        /// <summary>
        /// 送电子书的活动名称
        /// </summary>
        public string ActName { get; set; }

        /// <summary>
        /// 关联的淘宝订单
        /// </summary>
        public Nullable<long> BizOrderId { get; set; }

        /// <summary>
        /// 买家（接收方）的淘宝账号nick。
        /// </summary>
        public string BuyerNick { get; set; }

        /// <summary>
        /// 书库ID
        /// </summary>
        public Nullable<long> EbookLibId { get; set; }

        /// <summary>
        /// 商品ID，不可为空、0和负数。
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 电子书商品标题，30字以内。
        /// </summary>
        public string ItemTitle { get; set; }

        /// <summary>
        /// 接入系统的业务ID（在业务方必须唯一），长度不能超过20位。
        /// </summary>
        public string OutBizId { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.ebook.item.sendbynick";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("act_id", this.ActId);
            parameters.Add("act_name", this.ActName);
            parameters.Add("biz_order_id", this.BizOrderId);
            parameters.Add("buyer_nick", this.BuyerNick);
            parameters.Add("ebook_lib_id", this.EbookLibId);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("item_title", this.ItemTitle);
            parameters.Add("out_biz_id", this.OutBizId);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("buyer_nick", this.BuyerNick);
            RequestValidator.ValidateRequired("ebook_lib_id", this.EbookLibId);
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateRequired("item_title", this.ItemTitle);
            RequestValidator.ValidateRequired("out_biz_id", this.OutBizId);
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
