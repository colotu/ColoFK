using System;
using System.Xml.Serialization;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// KfcKeywordSearchResponse.
    /// </summary>
    public class KfcKeywordSearchResponse : TopResponse
    {
        /// <summary>
        /// KFC关键词匹配返回的结果信息
        /// </summary>
        [XmlElement("kfc_search_result")]
        public KfcSearchResult KfcSearchResult { get; set; }
    }
}
