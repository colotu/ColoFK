using System;
using System.Collections.Generic;
using YSWL.TaoBao.Response;
using YSWL.TaoBao.Util;

namespace YSWL.TaoBao.Request
{
    /// <summary>
    /// TOP API: taobao.traderate.list.add
    /// </summary>
    public class TraderateListAddRequest : ITopRequest<TraderateListAddResponse>
    {
        /// <summary>
        /// 是否匿名，卖家评不能匿名。可选值:true(匿名),false(非匿名)。 注意：如果买家匿名购买，那么买家的评价默认匿名
        /// </summary>
        public Nullable<bool> Anony { get; set; }

        /// <summary>
        /// 评价内容,最大长度: 500个汉字 .注意：当评价结果为good时就不用输入评价内容.评价内容为neutral/bad的时候需要输入评价内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评价结果。可选值:good(好评),neutral(中评),bad(差评)
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 评价者角色。可选值:seller(卖家),buyer(买家)
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 交易ID
        /// </summary>
        public Nullable<long> Tid { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.traderate.list.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("anony", this.Anony);
            parameters.Add("content", this.Content);
            parameters.Add("result", this.Result);
            parameters.Add("role", this.Role);
            parameters.Add("tid", this.Tid);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("result", this.Result);
            RequestValidator.ValidateRequired("role", this.Role);
            RequestValidator.ValidateRequired("tid", this.Tid);
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
