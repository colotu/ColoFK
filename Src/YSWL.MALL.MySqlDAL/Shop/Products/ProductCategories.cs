/**
* ProductCategories.cs
*
* 功 能： N/A
* 类 名： ProductCategories
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012年12月14日 11:37:55  Rock    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
using YSWL.MALL.IDAL.Shop.Products;

namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// 数据访问类:ProductCategories
    /// </summary>
    public partial class ProductCategories : IProductCategories
    {
        public ProductCategories()
        { }

        #region Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Shop.Products.ProductCategories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_ProductCategories(");
            strSql.Append("CategoryId,ProductId,CategoryPath)");
            strSql.Append(" VALUES (");
            strSql.Append("?CategoryId,?ProductId,?CategoryPath)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?CategoryPath", MySqlDbType.VarChar)
                                        };
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.ProductId;
            parameters[2].Value = model.CategoryPath;

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
        public bool Delete(long produtId)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_ProductCategories ");
            strSql.Append(" WHERE ProductId=?ProductId");
            MySqlParameter[] param ={
                            new MySqlParameter("?ProductId",MySqlDbType.Int64)
                            };
            param[0].Value = produtId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), param);
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
        public YSWL.MALL.Model.Shop.Products.ProductCategories GetModel(long produtId)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  CategoryId,ProductId,CategoryPath FROM Shop_ProductCategories ");
            strSql.Append(" WHERE ProductId=?ProductId");
            MySqlParameter[] param ={
                            new MySqlParameter("?ProductId",MySqlDbType.Int64)
                            };
            param[0].Value = produtId;
            strSql.Append(" LIMIT 1 ");
            Model.Shop.Products.ProductCategories model = new Model.Shop.Products.ProductCategories();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryId"] != null && ds.Tables[0].Rows[0]["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"] != null && ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CategoryPath"] != null && ds.Tables[0].Rows[0]["CategoryPath"].ToString() != "")
                {
                    model.CategoryPath =ds.Tables[0].Rows[0]["CategoryPath"].ToString();
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
            strSql.Append("SELECT CategoryId,ProductId,CategoryPath ");
            strSql.Append(" FROM Shop_ProductCategories ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
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
            
            strSql.Append(" CategoryId,ProductId,CategoryPath ");
            strSql.Append(" FROM Shop_ProductCategories ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
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
            strSql.Append("SELECT COUNT(1) FROM Shop_ProductCategories ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
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
            strSql.Append("SELECT T.* from Shop_ProductCategories T ");
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
                strSql.Append(" order by T.TagID desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion Method

         
    }
}