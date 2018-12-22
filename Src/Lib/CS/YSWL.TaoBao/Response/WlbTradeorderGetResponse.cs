using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// WlbTradeorderGetResponse.
    /// </summary>
    public class WlbTradeorderGetResponse : TopResponse
    {
        /// <summary>
        /// 物流宝订单列表信息
        /// </summary>
        [XmlArray("wlb_order_list")]
        [XmlArrayItem("wlb_order")]
        public List<WlbOrder> WlbOrderList { get; set; }
    }
}
