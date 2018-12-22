/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：AttributeValues.cs
// 文件功能描述：
// 
// 创建标识： [Ben]              2012/06/11 20:36:22
// 修改标识： [Rock]            2012年6月14日 17:00:46
// 修改描述：新增 【AttributeValueManage】方法
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
    /// 数据访问类:AttributeValues
    /// </summary>
    public partial class AttributeValue : IAttributeValue
    {
        public AttributeValue()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ValueId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_AttributeValues");
            strSql.Append(" WHERE ValueId=?ValueId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ValueId", MySqlDbType.Int64)
			};
            parameters[0].Value = ValueId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Products.AttributeValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_AttributeValues(");
            strSql.Append("AttributeId,DisplaySequence,ValueStr,ImageUrl)");
            strSql.Append(" VALUES (");
            strSql.Append("?AttributeId,?DisplaySequence,?ValueStr,?ImageUrl)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?ValueStr", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.AttributeId;
            parameters[1].Value = model.DisplaySequence;
            parameters[2].Value = model.ValueStr;
            parameters[3].Value = model.ImageUrl;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.Products.AttributeValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_AttributeValues SET ");
            strSql.Append("AttributeId=?AttributeId,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("ValueStr=?ValueStr,");
            strSql.Append("ImageUrl=?ImageUrl");
            strSql.Append(" WHERE ValueId=?ValueId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?ValueStr", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ValueId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.AttributeId;
            parameters[1].Value = model.DisplaySequence;
            parameters[2].Value = model.ValueStr;
            parameters[3].Value = model.ImageUrl;
            parameters[4].Value = model.ValueId;

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
        public bool Delete(long ValueId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_AttributeValues ");
            strSql.Append(" WHERE ValueId=?ValueId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ValueId", MySqlDbType.Int64)
			};
            parameters[0].Value = ValueId;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ValueIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_AttributeValues ");
            strSql.Append(" WHERE ValueId in (" + ValueIdlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public YSWL.MALL.Model.Shop.Products.AttributeValue GetModel(long ValueId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ValueId,AttributeId,DisplaySequence,ValueStr,ImageUrl FROM Shop_AttributeValues ");
            strSql.Append(" WHERE ValueId=?ValueId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ValueId", MySqlDbType.Int64)
			};
            parameters[0].Value = ValueId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.AttributeValue model = new YSWL.MALL.Model.Shop.Products.AttributeValue();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ValueId"] != null && ds.Tables[0].Rows[0]["ValueId"].ToString() != "")
                {
                    model.ValueId = long.Parse(ds.Tables[0].Rows[0]["ValueId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AttributeId"] != null && ds.Tables[0].Rows[0]["AttributeId"].ToString() != "")
                {
                    model.AttributeId = long.Parse(ds.Tables[0].Rows[0]["AttributeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DisplaySequence"] != null && ds.Tables[0].Rows[0]["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(ds.Tables[0].Rows[0]["DisplaySequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ValueStr"] != null && ds.Tables[0].Rows[0]["ValueStr"].ToString() != "")
                {
                    model.ValueStr = ds.Tables[0].Rows[0]["ValueStr"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImageUrl"] != null && ds.Tables[0].Rows[0]["ImageUrl"].ToString() != "")
                {
                    model.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
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
            strSql.Append("SELECT ValueId,AttributeId,DisplaySequence,ValueStr,ImageUrl ");
            strSql.Append(" FROM Shop_AttributeValues ");
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
            
            strSql.Append(" ValueId,AttributeId,DisplaySequence,ValueStr,ImageUrl ");
            strSql.Append(" FROM Shop_AttributeValues ");
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
            strSql.Append("SELECT COUNT(1) FROM Shop_AttributeValues ");
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
            strSql.Append("SELECT T.* from Shop_AttributeValues T ");
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
            parameters[0].Value = "Shop_AttributeValues";
            parameters[1].Value = "ValueId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        #region NewMethod
        public bool AttributeValueManage(Model.Shop.Products.AttributeValue model, Model.Shop.Products.DataProviderAction Action)
        {
            int rows = 0;
            MySqlParameter[] param = { 
                                   new MySqlParameter("_Action",MySqlDbType.Int32),
                                   new MySqlParameter("_ValueId",MySqlDbType.Int64),
                                   new MySqlParameter("_AttributeId",MySqlDbType.Int64),
                                   new MySqlParameter("_ValueStr",MySqlDbType.VarChar),
                                   new MySqlParameter("_ImageUrl",MySqlDbType.VarChar)
                                   };
            param[0].Value = (int)Action;
            param[1].Value = model.ValueId;
            param[2].Value = model.AttributeId;
            param[3].Value = model.ValueStr;
            param[4].Value = model.ImageUrl;
            DbHelperMySQL.RunProcedure("sp_Shop_AttributesValuesCreateEditDelete", param, out rows);
            if (rows > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByAttribute(long AttributeId)
        {
            return GetList(" AttributeId=" + AttributeId.ToString() + " ORDER BY DisplaySequence ");
        }

        public bool DeleteImage(long valueId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_AttributeValues SET ImageUrl=N''");
            strSql.Append("WHERE ValueId=?ValueId");
            MySqlParameter[] param ={
                            new MySqlParameter("?ValueId",MySqlDbType.Int64)
                            };
            param[0].Value = valueId;
            if (DbHelperMySQL.ExecuteSql(strSql.ToString(),param) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        public DataSet GetList(long? AttributeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ValueId,AttributeId,DisplaySequence,ValueStr,ImageUrl ");
            strSql.Append(" FROM Shop_AttributeValues ");
            if (AttributeId.HasValue)
            {
                strSql.Append("WHERE AttributeId=?AttributeId");
                MySqlParameter[] param ={
                            new MySqlParameter("?AttributeId",MySqlDbType.Int64)
                            };
                param[0].Value = AttributeId.Value;
                return DbHelperMySQL.Query(strSql.ToString(),param);
            }
            else
            {
                return DbHelperMySQL.Query(strSql.ToString());
            }
        }

        public DataSet GetAttributeValue(int ? cateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *  ");
            strSql.Append("FROM Shop_AttributeValues ");
            strSql.Append("WHERE AttributeId IN ( ");
            strSql.Append("SELECT DISTINCT AttributeId FROM Shop_ProductAttributes ");
            strSql.Append("WHERE ProductId IN(SELECT ProductId FROM Shop_Products ");
            if (cateID.HasValue)
            {
                strSql.AppendFormat("WHERE CategoryId ={0} ", cateID.Value);
            }
            strSql.Append(")) ");
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 根据商品listid和属性id获取商品属性值
        /// </summary>
        /// <param name="PordIDList">商品idList</param>
        ///  <param name="attrid">属性id</param>
        /// <returns></returns>
        public DataSet GetAttrValue(string PordIDList,int attrid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT  PA.ProductId  as ProductId,v.AttributeId,  V.ValueId ,V.ValueStr");
            strSql.Append(" FROM  Shop_ProductAttributes PA");
            strSql.Append("  LEFT JOIN Shop_AttributeValues V ON PA.ValueId = V.ValueId ");
            strSql.AppendFormat(" WHERE  PA.ProductId IN ( {0}) AND pa.AttributeId={1}  ORDER BY PA.ProductId DESC ", PordIDList, attrid);
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_AttributeValues");
            if (!String.IsNullOrWhiteSpace(strWhere))
            {
                strSql.AppendFormat(" where {0} " ,strWhere);
            }
            return DbHelperMySQL.Exists(strSql.ToString());
        }
    }
}

