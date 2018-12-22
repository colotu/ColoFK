using System;
using System.Xml.Serialization;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// AlibabaLogisticsRouteQueryResponse.
    /// </summary>
    public class AlibabaLogisticsRouteQueryResponse : TopResponse
    {
        /// <summary>
        /// 查询线路的结果
        /// </summary>
        [XmlElement("query_route_result")]
        public QueryRouteResult QueryRouteResult { get; set; }
    }
}
