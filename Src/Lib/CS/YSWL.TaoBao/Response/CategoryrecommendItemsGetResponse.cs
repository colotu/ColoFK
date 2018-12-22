using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using YSWL.TaoBao.Domain;

namespace YSWL.TaoBao.Response
{
    /// <summary>
    /// CategoryrecommendItemsGetResponse.
    /// </summary>
    public class CategoryrecommendItemsGetResponse : TopResponse
    {
        /// <summary>
        /// 返回关联的商品集合
        /// </summary>
        [XmlArray("favorite_items")]
        [XmlArrayItem("favorite_item")]
        public List<FavoriteItem> FavoriteItems { get; set; }
    }
}
