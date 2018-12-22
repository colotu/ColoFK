using System;
using System.Xml.Serialization;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// ProductPropimgUploadResponse.
    /// </summary>
    public class ProductPropimgUploadResponse : TopResponse
    {
        /// <summary>
        /// 支持返回产品属性图片中的：url,id,created,modified
        /// </summary>
        [XmlElement("product_prop_img")]
        public ProductPropImg ProductPropImg { get; set; }
    }
}
