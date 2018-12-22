using System;
using System.Xml.Serialization;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// CrmMembersGroupBatchaddResponse.
    /// </summary>
    public class CrmMembersGroupBatchaddResponse : TopResponse
    {
        /// <summary>
        /// 添加操作是否成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
    }
}
