/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：SKUItems.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:32
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// 数据访问类:SKUItem
    /// </summary>
    public partial class SKUItem : ISKUItem
    {
        public SKUItem()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long SkuId, long AttributeId, long ValueId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_SKUItems");
            strSql.Append(" WHERE SkuId=?SkuId and AttributeId=?AttributeId and ValueId=?ValueId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
                    new MySqlParameter("?ValueId", MySqlDbType.Int64,8)			};
            parameters[0].Value = SkuId;
            parameters[1].Value = AttributeId;
            parameters[2].Value = ValueId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Shop.Products.SKUItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_SKUItems(");
            strSql.Append("SkuId,AttributeId,ValueId)");
            strSql.Append(" VALUES (");
            strSql.Append("?SkuId,?AttributeId,?ValueId)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
                    new MySqlParameter("?ValueId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.SkuId;
            parameters[1].Value = model.AttributeId;
            parameters[2].Value = model.ValueId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.Products.SKUItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_SKUItems SET ");
            strSql.Append("SkuId=?SkuId,");
            strSql.Append("AttributeId=?AttributeId,");
            strSql.Append("ValueId=?ValueId");
            strSql.Append(" WHERE SkuId=?SkuId and AttributeId=?AttributeId and ValueId=?ValueId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
                    new MySqlParameter("?ValueId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.SkuId;
            parameters[1].Value = model.AttributeId;
            parameters[2].Value = model.ValueId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long SkuId, long AttributeId, long ValueId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_SKUItems ");
            strSql.Append(" WHERE SkuId=?SkuId and AttributeId=?AttributeId and ValueId=?ValueId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
                    new MySqlParameter("?ValueId", MySqlDbType.Int64,8)			};
            parameters[0].Value = SkuId;
            parameters[1].Value = AttributeId;
            parameters[2].Value = ValueId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Products.SKUItem GetModel(long SkuId, long AttributeId, long ValueId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  SkuId,AttributeId,ValueId FROM Shop_SKUItems ");
            strSql.Append(" WHERE SkuId=?SkuId and AttributeId=?AttributeId and ValueId=?ValueId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
                    new MySqlParameter("?ValueId", MySqlDbType.Int64,8)			};
            parameters[0].Value = SkuId;
            parameters[1].Value = AttributeId;
            parameters[2].Value = ValueId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.SKUItem model = new YSWL.MALL.Model.Shop.Products.SKUItem();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SkuId"] != null && ds.Tables[0].Rows[0]["SkuId"].ToString() != "")
                {
                    model.SkuId = long.Parse(ds.Tables[0].Rows[0]["SkuId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AttributeId"] != null && ds.Tables[0].Rows[0]["AttributeId"].ToString() != "")
                {
                    model.AttributeId = long.Parse(ds.Tables[0].Rows[0]["AttributeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ValueId"] != null && ds.Tables[0].Rows[0]["ValueId"].ToString() != "")
                {
                    model.ValueId = long.Parse(ds.Tables[0].Rows[0]["ValueId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SkuId,AttributeId,ValueId ");
            strSql.Append(" FROM Shop_SKUItems ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");

            strSql.Append(" SkuId,AttributeId,ValueId ");
            strSql.Append(" FROM Shop_SKUItems ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_SKUItems ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.* from Shop_SKUItems T ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.ValueId desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?PageSize", MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Shop_SKUItems";
            parameters[1].Value = "ValueId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        public DataSet GetSKUItem4AttrValByProductId(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
SELECT  SR.SkuId
      , SI.SpecId
      , SI.AttributeId
      , SI.ValueId
      , SI.ImageUrl
      , SI.ValueStr
      , SI.ProductId
      
      , AB.AttributeName
      , AB.DisplaySequence AS AB_DisplaySequence
      , AB.UsageMode
      , AB.UseAttributeImage
      , AB.UserDefinedPic
      
      , AV.DisplaySequence AS AV_DisplaySequence
      , AV.ValueStr AS AV_ValueStr
      , AV.ImageUrl AS AV_ImageUrl
FROM    Shop_SKUItems SI
        LEFT JOIN Shop_SKURelation SR ON SI.SpecId = SR.SpecId
        LEFT JOIN Shop_Attributes AB ON AB.AttributeId = SI.AttributeId
        LEFT JOIN Shop_AttributeValues AV ON SI.ValueId = AV.ValueId
WHERE   SI.ProductId = ?ProductId
ORDER BY AB_DisplaySequence,SI.AttributeId,AV_DisplaySequence
");
            MySqlParameter[] parameter = { 
                                           new MySqlParameter("?ProductId",MySqlDbType.Int64,8)
                                       };
            parameter[0].Value = productId;
            return DbHelperMySQL.Query(strSql.ToString(), parameter);
        }

        public DataSet GetSKUItem4AttrValBySkuId(long skuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
SELECT  SR.SkuId
      , SI.SpecId
      , SI.AttributeId
      , SI.ValueId
      , SI.ImageUrl
      , SI.ValueStr
      , SI.ProductId
      
      , AB.AttributeName
      , AB.DisplaySequence AS AB_DisplaySequence
      , AB.UsageMode
      , AB.UseAttributeImage
      , AB.UserDefinedPic
      
      , AV.DisplaySequence AS AV_DisplaySequence
      , AV.ValueStr AS AV_ValueStr
      , AV.ImageUrl AS AV_ImageUrl
FROM    Shop_SKUItems SI
        LEFT JOIN Shop_SKURelation SR ON SI.SpecId = SR.SpecId
        LEFT JOIN Shop_Attributes AB ON AB.AttributeId = SI.AttributeId
        LEFT JOIN Shop_AttributeValues AV ON SI.ValueId = AV.ValueId
WHERE   SR.SkuId = ?SkuId
ORDER BY AB_DisplaySequence,SI.AttributeId,AV_DisplaySequence
");
            MySqlParameter[] parameter = { 
                                           new MySqlParameter("?SkuId",MySqlDbType.Int64,8)
                                       };
            parameter[0].Value = skuId;
            return DbHelperMySQL.Query(strSql.ToString(), parameter);
        }

        public bool Exists(long? SkuId, long? AttributeId, long? ValueId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_SKUItems");
            strSql.Append(" WHERE 1=1 ");
            if (SkuId.HasValue)
            {
                strSql.Append(" AND SkuId=" + SkuId.Value);
            }
            if (AttributeId.HasValue)
            {
                strSql.Append(" AND AttributeId=" + AttributeId.Value);
            }
            if (ValueId.HasValue)
            {
                strSql.Append(" AND ValueId=" + ValueId.Value);
            }
            return DbHelperMySQL.Exists(strSql.ToString());
        }

        public DataSet AttributeValuesInfo(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*,B.UserDefinedPic  ");
            strSql.Append("FROM Shop_SKUItems A ");
            strSql.Append("LEFT JOIN Shop_Attributes  B ON A.AttributeId = B.AttributeId ");
            strSql.Append("WHERE ProductId=?ProductId ");
            MySqlParameter[] parameter = { 
                                           new MySqlParameter("?ProductId",MySqlDbType.Int64,8)
                                       };
            parameter[0].Value = productId;
            return DbHelperMySQL.Query(strSql.ToString(), parameter);
        }
    }
}

