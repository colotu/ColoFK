/**
* ShipperInfo.cs
*
* 功 能： N/A
* 类 名： ShipperInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/19 16:53:39   Ben    初版
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
using YSWL.MALL.IDAL.Shop.Sales;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Sales
{
	/// <summary>
    /// 数据访问类:ShipperInfo
	/// </summary>
	public partial class ShipperInfo:IShipperInfo
	{
		public ShipperInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ShipperId", "Shop_Shippers"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ShipperId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_Shippers");
			strSql.Append(" where ShipperId=?ShipperId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShipperId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ShipperId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Sales.ShipperInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_Shippers(");
			strSql.Append("IsDefault,ShipperTag,ShipperName,RegionId,Address,CellPhone,TelPhone,Zipcode,Remark)");
			strSql.Append(" values (");
			strSql.Append("?IsDefault,?ShipperTag,?ShipperName,?RegionId,?Address,?CellPhone,?TelPhone,?Zipcode,?Remark)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?IsDefault", MySqlDbType.Bit,1),
					new MySqlParameter("?ShipperTag", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperName", MySqlDbType.VarChar,100),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,300),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Zipcode", MySqlDbType.VarChar,20),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300)};
			parameters[0].Value = model.IsDefault;
			parameters[1].Value = model.ShipperTag;
			parameters[2].Value = model.ShipperName;
			parameters[3].Value = model.RegionId;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.CellPhone;
			parameters[6].Value = model.TelPhone;
			parameters[7].Value = model.Zipcode;
			parameters[8].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.Shop.Sales.ShipperInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_Shippers set ");
			strSql.Append("IsDefault=?IsDefault,");
			strSql.Append("ShipperTag=?ShipperTag,");
			strSql.Append("ShipperName=?ShipperName,");
			strSql.Append("RegionId=?RegionId,");
			strSql.Append("Address=?Address,");
			strSql.Append("CellPhone=?CellPhone,");
			strSql.Append("TelPhone=?TelPhone,");
			strSql.Append("Zipcode=?Zipcode,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ShipperId=?ShipperId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?IsDefault", MySqlDbType.Bit,1),
					new MySqlParameter("?ShipperTag", MySqlDbType.VarChar,100),
					new MySqlParameter("?ShipperName", MySqlDbType.VarChar,100),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,300),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Zipcode", MySqlDbType.VarChar,20),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300),
					new MySqlParameter("?ShipperId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.IsDefault;
			parameters[1].Value = model.ShipperTag;
			parameters[2].Value = model.ShipperName;
			parameters[3].Value = model.RegionId;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.CellPhone;
			parameters[6].Value = model.TelPhone;
			parameters[7].Value = model.Zipcode;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.ShipperId;

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
		public bool Delete(int ShipperId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Shippers ");
			strSql.Append(" where ShipperId=?ShipperId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShipperId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ShipperId;

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
		public bool DeleteList(string ShipperIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Shippers ");
			strSql.Append(" where ShipperId in ("+ShipperIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Sales.ShipperInfo GetModel(int ShipperId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ShipperId,IsDefault,ShipperTag,ShipperName,RegionId,Address,CellPhone,TelPhone,Zipcode,Remark from Shop_Shippers ");
			strSql.Append(" where ShipperId=?ShipperId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ShipperId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ShipperId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Sales.ShipperInfo model=new YSWL.MALL.Model.Shop.Sales.ShipperInfo();
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
		public YSWL.MALL.Model.Shop.Sales.ShipperInfo DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Sales.ShipperInfo model=new YSWL.MALL.Model.Shop.Sales.ShipperInfo();
			if (row != null)
			{
				if(row["ShipperId"]!=null && row["ShipperId"].ToString()!="")
				{
					model.ShipperId=int.Parse(row["ShipperId"].ToString());
				}
				if(row["IsDefault"]!=null && row["IsDefault"].ToString()!="")
				{
					if((row["IsDefault"].ToString()=="1")||(row["IsDefault"].ToString().ToLower()=="true"))
					{
						model.IsDefault=true;
					}
					else
					{
						model.IsDefault=false;
					}
				}
				if(row["ShipperTag"]!=null)
				{
					model.ShipperTag=row["ShipperTag"].ToString();
				}
				if(row["ShipperName"]!=null)
				{
					model.ShipperName=row["ShipperName"].ToString();
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["CellPhone"]!=null)
				{
					model.CellPhone=row["CellPhone"].ToString();
				}
				if(row["TelPhone"]!=null)
				{
					model.TelPhone=row["TelPhone"].ToString();
				}
				if(row["Zipcode"]!=null)
				{
					model.Zipcode=row["Zipcode"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select ShipperId,IsDefault,ShipperTag,ShipperName,RegionId,Address,CellPhone,TelPhone,Zipcode,Remark ");
			strSql.Append(" FROM Shop_Shippers ");
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
			strSql.Append(" ShipperId,IsDefault,ShipperTag,ShipperName,RegionId,Address,CellPhone,TelPhone,Zipcode,Remark ");
			strSql.Append(" FROM Shop_Shippers ");
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
			strSql.Append("select count(1) FROM Shop_Shippers ");
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
            strSql.Append("SELECT T.* from Shop_Shippers T ");
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
                strSql.Append(" order by T.ShipperId desc");
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
			parameters[0].Value = "Shop_Shippers";
			parameters[1].Value = "ShipperId";
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

