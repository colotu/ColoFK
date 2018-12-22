using System;
using System.Xml.Serialization;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// CrmGrademktMemberDetailDeleteResponse.
    /// </summary>
    public class CrmGrademktMemberDetailDeleteResponse : TopResponse
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        [XmlElement("module")]
        public bool Module { get; set; }
    }
}
