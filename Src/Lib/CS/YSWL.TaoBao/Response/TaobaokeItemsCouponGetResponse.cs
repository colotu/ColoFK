using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// TaobaokeItemsCouponGetResponse.
    /// </summary>
    public class TaobaokeItemsCouponGetResponse : TopResponse
    {
        /// <summary>
        /// 淘宝客商品对象列表
        /// </summary>
        [XmlArray("taobaoke_items")]
        [XmlArrayItem("taobaoke_item")]
        public List<TaobaokeItem> TaobaokeItems { get; set; }

        /// <summary>
        /// 搜索到符合条件的结果总数
        /// </summary>
        [XmlElement("total_results")]
        public long TotalResults { get; set; }
    }
}
