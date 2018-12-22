using System;
using System.Xml.Serialization;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// SimbaLoginAuthsignGetResponse.
    /// </summary>
    public class SimbaLoginAuthsignGetResponse : TopResponse
    {
        /// <summary>
        /// 登陆签名
        /// </summary>
        [XmlElement("subway_token")]
        public string SubwayToken { get; set; }
    }
}
