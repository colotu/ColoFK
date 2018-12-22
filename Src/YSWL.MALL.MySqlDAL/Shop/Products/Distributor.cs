/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：Distributors.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:23
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
	/// 数据访问类:Distributors
	/// </summary>
	public partial class Distributor:IDistributor
	{
		public Distributor()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("DistributorId", "Shop_Distributors"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DistributorId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM Shop_Distributors");
			strSql.Append(" WHERE DistributorId=?DistributorId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DistributorId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = DistributorId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Products.Distributor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("INSERT INTO Shop_Distributors(");
			strSql.Append("DistributorName)");
			strSql.Append(" VALUES (");
			strSql.Append("?DistributorName)");
			strSql.Append(";SELECT last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DistributorName", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.DistributorName;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.Shop.Products.Distributor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("UPDATE Shop_Distributors SET ");
			strSql.Append("DistributorName=?DistributorName");
			strSql.Append(" WHERE DistributorId=?DistributorId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DistributorName", MySqlDbType.VarChar,50),
					new MySqlParameter("?DistributorId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.DistributorName;
			parameters[1].Value = model.DistributorId;

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
		public bool Delete(int DistributorId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_Distributors ");
			strSql.Append(" WHERE DistributorId=?DistributorId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DistributorId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = DistributorId;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string DistributorIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_Distributors ");
			strSql.Append(" WHERE DistributorId in ("+DistributorIdlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public YSWL.MALL.Model.Shop.Products.Distributor GetModel(int DistributorId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT DistributorId,DistributorName FROM Shop_Distributors ");
			strSql.Append(" WHERE DistributorId=?DistributorId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DistributorId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = DistributorId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Products.Distributor model=new YSWL.MALL.Model.Shop.Products.Distributor();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DistributorId"]!=null && ds.Tables[0].Rows[0]["DistributorId"].ToString()!="")
				{
					model.DistributorId=int.Parse(ds.Tables[0].Rows[0]["DistributorId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DistributorName"]!=null && ds.Tables[0].Rows[0]["DistributorName"].ToString()!="")
				{
					model.DistributorName=ds.Tables[0].Rows[0]["DistributorName"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT DistributorId,DistributorName ");
			strSql.Append(" FROM Shop_Distributors ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ");
			
			strSql.Append(" DistributorId,DistributorName ");
			strSql.Append(" FROM Shop_Distributors ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM Shop_Distributors ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
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
            strSql.Append("SELECT T.* from Shop_Distributors T ");
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
                strSql.Append(" order by T.DistributorId desc");
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
			parameters[0].Value = "Shop_Distributors";
			parameters[1].Value = "DistributorId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

