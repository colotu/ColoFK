/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductAttributes.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:25
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
	/// 数据访问类:ProductAttribute
	/// </summary>
	public partial class ProductAttribute:IProductAttribute
	{
		public ProductAttribute()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ValueId", "Shop_ProductAttributes"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ProductId,long AttributeId,int ValueId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM Shop_ProductAttributes");
			strSql.Append(" WHERE ProductId=?ProductId and AttributeId=?AttributeId and ValueId=?ValueId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
					new MySqlParameter("?ValueId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ProductId;
			parameters[1].Value = AttributeId;
			parameters[2].Value = ValueId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.Shop.Products.ProductAttribute model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("INSERT INTO Shop_ProductAttributes(");
			strSql.Append("ProductId,AttributeId,ValueId)");
			strSql.Append(" VALUES (");
			strSql.Append("?ProductId,?AttributeId,?ValueId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
					new MySqlParameter("?ValueId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.AttributeId;
			parameters[2].Value = model.ValueId;

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
		public bool Update(YSWL.MALL.Model.Shop.Products.ProductAttribute model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("UPDATE Shop_ProductAttributes SET ");
			strSql.Append("ProductId=?ProductId,");
			strSql.Append("AttributeId=?AttributeId,");
			strSql.Append("ValueId=?ValueId");
			strSql.Append(" WHERE ProductId=?ProductId and AttributeId=?AttributeId and ValueId=?ValueId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
					new MySqlParameter("?ValueId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.AttributeId;
			parameters[2].Value = model.ValueId;

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
		public bool Delete(long ProductId,long AttributeId,int ValueId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_ProductAttributes ");
			strSql.Append(" WHERE ProductId=?ProductId and AttributeId=?AttributeId and ValueId=?ValueId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
					new MySqlParameter("?ValueId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ProductId;
			parameters[1].Value = AttributeId;
			parameters[2].Value = ValueId;

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
		public YSWL.MALL.Model.Shop.Products.ProductAttribute GetModel(long ProductId,long AttributeId,int ValueId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ProductId,AttributeId,ValueId FROM Shop_ProductAttributes ");
			strSql.Append(" WHERE ProductId=?ProductId and AttributeId=?AttributeId and ValueId=?ValueId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
					new MySqlParameter("?ValueId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ProductId;
			parameters[1].Value = AttributeId;
			parameters[2].Value = ValueId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Products.ProductAttribute model=new YSWL.MALL.Model.Shop.Products.ProductAttribute();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductId"]!=null && ds.Tables[0].Rows[0]["ProductId"].ToString()!="")
				{
					model.ProductId=long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AttributeId"]!=null && ds.Tables[0].Rows[0]["AttributeId"].ToString()!="")
				{
					model.AttributeId=long.Parse(ds.Tables[0].Rows[0]["AttributeId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ValueId"]!=null && ds.Tables[0].Rows[0]["ValueId"].ToString()!="")
				{
					model.ValueId=int.Parse(ds.Tables[0].Rows[0]["ValueId"].ToString());
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
			strSql.Append("SELECT ProductId,AttributeId,ValueId ");
			strSql.Append(" FROM Shop_ProductAttributes ");
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
			
			strSql.Append(" ProductId,AttributeId,ValueId ");
			strSql.Append(" FROM Shop_ProductAttributes ");
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
			strSql.Append("SELECT COUNT(1) FROM Shop_ProductAttributes ");
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
            strSql.Append("SELECT T.* from Shop_ProductAttributes T ");
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
			parameters[0].Value = "Shop_ProductAttributes";
			parameters[1].Value = "ValueId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method


        public bool Exists(long? ProductId, long? AttributeId, long? ValueId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_ProductAttributes");
            strSql.Append(" WHERE 1=1 ");
            if (ProductId.HasValue)
            {
                strSql.Append(" AND ProductId=" + ProductId.Value);
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
	}
}

