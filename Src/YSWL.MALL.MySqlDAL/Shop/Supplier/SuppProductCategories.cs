/**
* SuppProductCategories.cs
*
* 功 能： N/A
* 类 名： SuppProductCategories
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/26 17:31:52   Ben    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Supplier;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Supplier
{
	/// <summary>
	/// 数据访问类:SuppProductCategories
	/// </summary>
	public partial class SuppProductCategories:ISuppProductCategories
	{
		public SuppProductCategories()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("CategoryId", "Shop_SuppProductCategories"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CategoryId,long ProductId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_SuppProductCategories");
			strSql.Append(" where CategoryId=?CategoryId and ProductId=?ProductId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
			parameters[0].Value = CategoryId;
			parameters[1].Value = ProductId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.Shop.Supplier.SuppProductCategories model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_SuppProductCategories(");
			strSql.Append("CategoryId,ProductId,CategoryPath)");
			strSql.Append(" values (");
			strSql.Append("?CategoryId,?ProductId,?CategoryPath)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?CategoryPath", MySqlDbType.VarChar,4000)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.CategoryPath;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.Shop.Supplier.SuppProductCategories model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_SuppProductCategories set ");
			strSql.Append("CategoryPath=?CategoryPath");
			strSql.Append(" where CategoryId=?CategoryId and ProductId=?ProductId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryPath", MySqlDbType.VarChar,4000),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
			parameters[0].Value = model.CategoryPath;
			parameters[1].Value = model.CategoryId;
			parameters[2].Value = model.ProductId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int CategoryId,long ProductId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SuppProductCategories ");
			strSql.Append(" where CategoryId=?CategoryId and ProductId=?ProductId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
			parameters[0].Value = CategoryId;
			parameters[1].Value = ProductId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public YSWL.MALL.Model.Shop.Supplier.SuppProductCategories GetModel(int CategoryId,long ProductId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CategoryId,ProductId,CategoryPath from Shop_SuppProductCategories ");
			strSql.Append(" where CategoryId=?CategoryId and ProductId=?ProductId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
			parameters[0].Value = CategoryId;
			parameters[1].Value = ProductId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Supplier.SuppProductCategories model=new YSWL.MALL.Model.Shop.Supplier.SuppProductCategories();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public YSWL.MALL.Model.Shop.Supplier.SuppProductCategories DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Supplier.SuppProductCategories model=new YSWL.MALL.Model.Shop.Supplier.SuppProductCategories();
			if (row != null)
			{
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
				}
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=long.Parse(row["ProductId"].ToString());
				}
				if(row["CategoryPath"]!=null)
				{
					model.CategoryPath=row["CategoryPath"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CategoryId,ProductId,CategoryPath ");
			strSql.Append(" FROM Shop_SuppProductCategories ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(" CategoryId,ProductId,CategoryPath ");
			strSql.Append(" FROM Shop_SuppProductCategories ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Shop_SuppProductCategories ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("SELECT T.* from Shop_SuppProductCategories T ");
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
			parameters[0].Value = "Shop_SuppProductCategories";
			parameters[1].Value = "ProductId";
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
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Supplier.SuppProductCategories GetModel(long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryId,ProductId,CategoryPath from Shop_SuppProductCategories ");
            strSql.Append(" where  ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
            parameters[0].Value = ProductId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Supplier.SuppProductCategories model = new YSWL.MALL.Model.Shop.Supplier.SuppProductCategories();
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_SuppProductCategories ");
            strSql.Append(" where ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
            parameters[0].Value = ProductId;

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

		#endregion  ExtensionMethod
	}
}

