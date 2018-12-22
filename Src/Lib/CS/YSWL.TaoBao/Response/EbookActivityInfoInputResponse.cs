using System;
using System.Xml.Serialization;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// EbookActivityInfoInputResponse.
    /// </summary>
    public class EbookActivityInfoInputResponse : TopResponse
    {
        /// <summary>
        /// 是否操作成功
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
    }
}
