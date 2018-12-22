/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：RelatedProducts.cs
// 文件功能描述：
//
// 创建标识： [Ben]  2012/06/11 20:36:31
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Products;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// 数据访问类:RelatedProduct
    /// </summary>
    public partial class RelatedProduct : IRelatedProduct
    {
        public RelatedProduct()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("RelatedId", "Shop_RelatedProducts");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RelatedId, long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_RelatedProducts");
            strSql.Append(" WHERE RelatedId=?RelatedId and ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelatedId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
            parameters[0].Value = RelatedId;
            parameters[1].Value = ProductId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Shop.Products.RelatedProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_RelatedProducts(");
            strSql.Append("RelatedId,ProductId)");
            strSql.Append(" VALUES (");
            strSql.Append("?RelatedId,?ProductId)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelatedId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.RelatedId;
            parameters[1].Value = model.ProductId;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.RelatedProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_RelatedProducts SET ");
            strSql.Append("RelatedId=?RelatedId,");
            strSql.Append("ProductId=?ProductId");
            strSql.Append(" WHERE RelatedId=?RelatedId and ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelatedId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.RelatedId;
            parameters[1].Value = model.ProductId;

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
        public bool Delete(int RelatedId, long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_RelatedProducts ");
            strSql.Append(" WHERE RelatedId=?RelatedId and ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelatedId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
            parameters[0].Value = RelatedId;
            parameters[1].Value = ProductId;

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
        public YSWL.MALL.Model.Shop.Products.RelatedProduct GetModel(int RelatedId, long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT RelatedId,ProductId FROM Shop_RelatedProducts ");
            strSql.Append(" WHERE RelatedId=?RelatedId and ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelatedId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
            parameters[0].Value = RelatedId;
            parameters[1].Value = ProductId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.RelatedProduct model = new YSWL.MALL.Model.Shop.Products.RelatedProduct();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RelatedId"] != null && ds.Tables[0].Rows[0]["RelatedId"].ToString() != "")
                {
                    model.RelatedId = int.Parse(ds.Tables[0].Rows[0]["RelatedId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"] != null && ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
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
            strSql.Append("SELECT RelatedId,ProductId ");
            strSql.Append(" FROM Shop_RelatedProducts ");
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
            strSql.Append(" RelatedId,ProductId ");
            strSql.Append(" FROM Shop_RelatedProducts ");
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
            strSql.Append("SELECT COUNT(1) FROM Shop_RelatedProducts ");
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
            strSql.Append("SELECT T.* from Shop_RelatedProducts T ");
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
                strSql.Append(" order by T.ProductId desc");
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
            parameters[0].Value = "Shop_RelatedProducts";
            parameters[1].Value = "ProductId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        public DataSet IsDoubleRelated(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*,CASE  WHEN B.RelatedId IS NULL THEN 0 ELSE 1 END AS IsRelated   FROM( ");
            strSql.Append("SELECT * FROM Shop_RelatedProducts P ");
            strSql.AppendFormat("WHERE P.ProductId={0})A ", productId);
            strSql.Append("LEFT JOIN (SELECT * FROM Shop_RelatedProducts RP ");
            strSql.AppendFormat("WHERE RP.RelatedId={0})B ON  A.RelatedId = B.ProductId ", productId);

            return DbHelperMySQL.Query(strSql.ToString());
        }
    }
}