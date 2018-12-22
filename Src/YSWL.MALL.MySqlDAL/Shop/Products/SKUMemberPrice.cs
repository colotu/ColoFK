/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：SKUMemberPrice.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:33
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
	/// 数据访问类:SKUMemberPrice
	/// </summary>
	public partial class SKUMemberPrice:ISKUMemberPrice
	{
		public SKUMemberPrice()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("GradeId", "Shop_SKUMemberPrice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long SkuId,int GradeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM Shop_SKUMemberPrice");
			strSql.Append(" WHERE SkuId=?SkuId and GradeId=?GradeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
					new MySqlParameter("?GradeId", MySqlDbType.Int32,4)			};
			parameters[0].Value = SkuId;
			parameters[1].Value = GradeId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.Shop.Products.SKUMemberPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("INSERT INTO Shop_SKUMemberPrice(");
			strSql.Append("SkuId,GradeId,MemberSalePrice)");
			strSql.Append(" VALUES (");
			strSql.Append("?SkuId,?GradeId,?MemberSalePrice)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
					new MySqlParameter("?GradeId", MySqlDbType.Int32,4),
					new MySqlParameter("?MemberSalePrice", MySqlDbType.Decimal,8)};
			parameters[0].Value = model.SkuId;
			parameters[1].Value = model.GradeId;
			parameters[2].Value = model.MemberSalePrice;

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
		public bool Update(YSWL.MALL.Model.Shop.Products.SKUMemberPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("UPDATE Shop_SKUMemberPrice SET ");
			strSql.Append("MemberSalePrice=?MemberSalePrice");
			strSql.Append(" WHERE SkuId=?SkuId and GradeId=?GradeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MemberSalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
					new MySqlParameter("?GradeId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.MemberSalePrice;
			parameters[1].Value = model.SkuId;
			parameters[2].Value = model.GradeId;

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
		public bool Delete(long SkuId,int GradeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_SKUMemberPrice ");
			strSql.Append(" WHERE SkuId=?SkuId and GradeId=?GradeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
					new MySqlParameter("?GradeId", MySqlDbType.Int32,4)			};
			parameters[0].Value = SkuId;
			parameters[1].Value = GradeId;

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
		public YSWL.MALL.Model.Shop.Products.SKUMemberPrice GetModel(long SkuId,int GradeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT SkuId,GradeId,MemberSalePrice FROM Shop_SKUMemberPrice ");
			strSql.Append(" WHERE SkuId=?SkuId and GradeId=?GradeId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SkuId", MySqlDbType.Int64,8),
					new MySqlParameter("?GradeId", MySqlDbType.Int32,4)			};
			parameters[0].Value = SkuId;
			parameters[1].Value = GradeId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Products.SKUMemberPrice model=new YSWL.MALL.Model.Shop.Products.SKUMemberPrice();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["SkuId"]!=null && ds.Tables[0].Rows[0]["SkuId"].ToString()!="")
				{
					model.SkuId=long.Parse(ds.Tables[0].Rows[0]["SkuId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GradeId"]!=null && ds.Tables[0].Rows[0]["GradeId"].ToString()!="")
				{
					model.GradeId=int.Parse(ds.Tables[0].Rows[0]["GradeId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberSalePrice"]!=null && ds.Tables[0].Rows[0]["MemberSalePrice"].ToString()!="")
				{
					model.MemberSalePrice=decimal.Parse(ds.Tables[0].Rows[0]["MemberSalePrice"].ToString());
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
			strSql.Append("SELECT SkuId,GradeId,MemberSalePrice ");
			strSql.Append(" FROM Shop_SKUMemberPrice ");
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

			strSql.Append(" SkuId,GradeId,MemberSalePrice ");
			strSql.Append(" FROM Shop_SKUMemberPrice ");
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
			strSql.Append("SELECT COUNT(1) FROM Shop_SKUMemberPrice ");
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
            strSql.Append("SELECT T.* from Shop_SKUMemberPrice T ");
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
                strSql.Append(" order by T.GradeId desc");
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
			parameters[0].Value = "Shop_SKUMemberPrice";
			parameters[1].Value = "GradeId";
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

