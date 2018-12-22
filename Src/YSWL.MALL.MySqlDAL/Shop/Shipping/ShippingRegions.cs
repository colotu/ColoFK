﻿/**
* ShippingRegions.cs
*
* 功 能： N/A
* 类 名： ShippingRegions
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/7/8 18:17:32   Ben    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
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
using YSWL.MALL.IDAL.Shop;
using MySql.Data.MySqlClient;

//Please add references
namespace YSWL.MALL.MySqlDAL.Shop.Shipping
{
	/// <summary>
	/// 数据访问类:ShippingRegions
	/// </summary>
	public partial class ShippingRegions:IDAL.Shop.Shipping.IShippingRegions
	{
		public ShippingRegions()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ModeId", "Shop_ShippingRegions"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ModeId,int RegionId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_ShippingRegions");
			strSql.Append(" where ModeId=?ModeId and RegionId=?RegionId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ModeId;
			parameters[1].Value = RegionId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.Shop.Shipping.ShippingRegions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_ShippingRegions(");
			strSql.Append("ModeId,GroupId,RegionId)");
			strSql.Append(" values (");
			strSql.Append("?ModeId,?GroupId,?RegionId)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?GroupId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.ModeId;
			parameters[1].Value = model.GroupId;
			parameters[2].Value = model.RegionId;

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
		public bool Update(YSWL.MALL.Model.Shop.Shipping.ShippingRegions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_ShippingRegions set ");
			strSql.Append("GroupId=?GroupId");
			strSql.Append(" where ModeId=?ModeId and RegionId=?RegionId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?GroupId", MySqlDbType.Int32,4),
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.GroupId;
			parameters[1].Value = model.ModeId;
			parameters[2].Value = model.RegionId;

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
		public bool Delete(int ModeId,int RegionId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_ShippingRegions ");
			strSql.Append(" where ModeId=?ModeId and RegionId=?RegionId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ModeId;
			parameters[1].Value = RegionId;

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
		public YSWL.MALL.Model.Shop.Shipping.ShippingRegions GetModel(int ModeId,int RegionId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ModeId,GroupId,RegionId from Shop_ShippingRegions ");
			strSql.Append(" where ModeId=?ModeId and RegionId=?RegionId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ModeId;
			parameters[1].Value = RegionId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Shipping.ShippingRegions model=new YSWL.MALL.Model.Shop.Shipping.ShippingRegions();
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
		public YSWL.MALL.Model.Shop.Shipping.ShippingRegions DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Shipping.ShippingRegions model=new YSWL.MALL.Model.Shop.Shipping.ShippingRegions();
			if (row != null)
			{
				if(row["ModeId"]!=null && row["ModeId"].ToString()!="")
				{
					model.ModeId=int.Parse(row["ModeId"].ToString());
				}
				if(row["GroupId"]!=null && row["GroupId"].ToString()!="")
				{
					model.GroupId=int.Parse(row["GroupId"].ToString());
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
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
			strSql.Append("select ModeId,GroupId,RegionId ");
			strSql.Append(" FROM Shop_ShippingRegions ");
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
			strSql.Append(" ModeId,GroupId,RegionId ");
			strSql.Append(" FROM Shop_ShippingRegions ");
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
			strSql.Append("select count(1) FROM Shop_ShippingRegions ");
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
            strSql.Append("SELECT T.* from Shop_ShippingRegions T ");
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
                strSql.Append(" order by T.RegionId desc");
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
			parameters[0].Value = "Shop_ShippingRegions";
			parameters[1].Value = "RegionId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

