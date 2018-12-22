﻿/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：AccessoriesValues.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:21
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
	/// 数据访问类:AccessoriesValues
	/// </summary>
	public partial class AccessoriesValue:IAccessoriesValue
	{
		public AccessoriesValue()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("AccessoriesId", "Shop_AccessoriesValues");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AccessoriesId, int AccessoriesValueId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_AccessoriesValues");
            strSql.Append(" where AccessoriesId=?AccessoriesId and AccessoriesValueId=?AccessoriesValueId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4),
					new MySqlParameter("?AccessoriesValueId", MySqlDbType.Int32,4)			};
            parameters[0].Value = AccessoriesId;
            parameters[1].Value = AccessoriesValueId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Products.AccessoriesValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_AccessoriesValues(");
            strSql.Append("AccessoriesId,SKU)");
            strSql.Append(" values (");
            strSql.Append("?AccessoriesId,?SKU)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.AccessoriesId;
            parameters[1].Value = model.SKU;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.Products.AccessoriesValue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_AccessoriesValues set ");
            strSql.Append("SKU=?SKU");
            strSql.Append(" where AccessoriesValueId=?AccessoriesValueId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
					new MySqlParameter("?AccessoriesValueId", MySqlDbType.Int32,4),
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.SKU;
            parameters[1].Value = model.AccessoriesValueId;
            parameters[2].Value = model.AccessoriesId;

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
        public bool Delete(int AccessoriesValueId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_AccessoriesValues ");
            strSql.Append(" where AccessoriesValueId=?AccessoriesValueId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesValueId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AccessoriesValueId;

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
        public bool Delete(int AccessoriesId, int AccessoriesValueId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_AccessoriesValues ");
            strSql.Append(" where AccessoriesId=?AccessoriesId and AccessoriesValueId=?AccessoriesValueId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4),
					new MySqlParameter("?AccessoriesValueId", MySqlDbType.Int32,4)			};
            parameters[0].Value = AccessoriesId;
            parameters[1].Value = AccessoriesValueId;

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
        public bool DeleteList(string AccessoriesValueIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_AccessoriesValues ");
            strSql.Append(" where AccessoriesValueId in (" + AccessoriesValueIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.AccessoriesValue GetModel(int AccessoriesValueId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccessoriesValueId,AccessoriesId,SKU from Shop_AccessoriesValues ");
            strSql.Append(" where AccessoriesValueId=?AccessoriesValueId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesValueId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AccessoriesValueId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.AccessoriesValue model = new YSWL.MALL.Model.Shop.Products.AccessoriesValue();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Products.AccessoriesValue DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Products.AccessoriesValue model = new YSWL.MALL.Model.Shop.Products.AccessoriesValue();
            if (row != null)
            {
                if (row["AccessoriesValueId"] != null && row["AccessoriesValueId"].ToString() != "")
                {
                    model.AccessoriesValueId = int.Parse(row["AccessoriesValueId"].ToString());
                }
                if (row["AccessoriesId"] != null && row["AccessoriesId"].ToString() != "")
                {
                    model.AccessoriesId = int.Parse(row["AccessoriesId"].ToString());
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccessoriesValueId,AccessoriesId,SKU ");
            strSql.Append(" FROM Shop_AccessoriesValues ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(" AccessoriesValueId,AccessoriesId,SKU ");
            strSql.Append(" FROM Shop_AccessoriesValues ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            strSql.Append("select count(1) FROM Shop_AccessoriesValues ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append("SELECT T.* from Shop_AccessoriesValues T ");
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
                strSql.Append(" order by T.AccessoriesValueId desc");
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
            parameters[0].Value = "Shop_AccessoriesValues";
            parameters[1].Value = "AccessoriesValueId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       /// <param name="AccessoriesId">组合id</param>
        /// <param name="sku">sku</param>
       /// <returns></returns>
        public bool Exists(int AccessoriesId, string  sku)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_AccessoriesValues");
            strSql.Append(" where AccessoriesId=?AccessoriesId and SKU=?SKU ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)			};
            parameters[0].Value = AccessoriesId;
            parameters[1].Value = sku;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
       /// <summary>
        /// 删除一条数据
       /// </summary>
        ///<param name="AccessoriesId">组合id</param>
        /// <param name="sku">sku</param>
       /// <returns></returns>
        public bool Delete(int AccessoriesId, string sku)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_AccessoriesValues ");
            strSql.Append(" where AccessoriesId=?AccessoriesId and SKU=?SKU ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4),
					new MySqlParameter("?SKU",  MySqlDbType.VarChar,50)		};
            parameters[0].Value = AccessoriesId;
            parameters[1].Value = sku;

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
        #endregion
    }
}

