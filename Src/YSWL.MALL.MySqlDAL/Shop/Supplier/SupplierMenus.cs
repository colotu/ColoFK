/**
* SupplierMenus.cs
*
* 功 能： N/A
* 类 名： SupplierMenus
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/26 17:31:49   Ben    初版
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
	/// 数据访问类:SupplierMenus
	/// </summary>
	public partial class SupplierMenus:ISupplierMenus
	{
		public SupplierMenus()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("MenuId", "Shop_SupplierMenus"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MenuId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_SupplierMenus");
			strSql.Append(" where MenuId=?MenuId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MenuId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = MenuId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Supplier.SupplierMenus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_SupplierMenus(");
			strSql.Append("MenuName,NavURL,MenuTitle,MenuType,Target,IsUsed,Sequence,Visible,URLType,NavTheme,SupplierId)");
			strSql.Append(" values (");
			strSql.Append("?MenuName,?NavURL,?MenuTitle,?MenuType,?Target,?IsUsed,?Sequence,?Visible,?URLType,?NavTheme,?SupplierId)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MenuName", MySqlDbType.VarChar,50),
					new MySqlParameter("?NavURL", MySqlDbType.VarChar,-1),
					new MySqlParameter("?MenuTitle", MySqlDbType.VarChar,50),
					new MySqlParameter("?MenuType", MySqlDbType.Int32,4),
					new MySqlParameter("?Target", MySqlDbType.Int32,4),
					new MySqlParameter("?IsUsed", MySqlDbType.Bit,1),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Visible", MySqlDbType.Int32,4),
					new MySqlParameter("?URLType", MySqlDbType.Int32,4),
					new MySqlParameter("?NavTheme", MySqlDbType.VarChar,100),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.MenuName;
			parameters[1].Value = model.NavURL;
			parameters[2].Value = model.MenuTitle;
			parameters[3].Value = model.MenuType;
			parameters[4].Value = model.Target;
			parameters[5].Value = model.IsUsed;
			parameters[6].Value = model.Sequence;
			parameters[7].Value = model.Visible;
			parameters[8].Value = model.URLType;
			parameters[9].Value = model.NavTheme;
			parameters[10].Value = model.SupplierId;

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
		public bool Update(YSWL.MALL.Model.Shop.Supplier.SupplierMenus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_SupplierMenus set ");
			strSql.Append("MenuName=?MenuName,");
			strSql.Append("NavURL=?NavURL,");
			strSql.Append("MenuTitle=?MenuTitle,");
			strSql.Append("MenuType=?MenuType,");
			strSql.Append("Target=?Target,");
			strSql.Append("IsUsed=?IsUsed,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Visible=?Visible,");
			strSql.Append("URLType=?URLType,");
			strSql.Append("NavTheme=?NavTheme,");
			strSql.Append("SupplierId=?SupplierId");
			strSql.Append(" where MenuId=?MenuId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MenuName", MySqlDbType.VarChar,50),
					new MySqlParameter("?NavURL", MySqlDbType.VarChar,-1),
					new MySqlParameter("?MenuTitle", MySqlDbType.VarChar,50),
					new MySqlParameter("?MenuType", MySqlDbType.Int32,4),
					new MySqlParameter("?Target", MySqlDbType.Int32,4),
					new MySqlParameter("?IsUsed", MySqlDbType.Bit,1),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Visible", MySqlDbType.Int32,4),
					new MySqlParameter("?URLType", MySqlDbType.Int32,4),
					new MySqlParameter("?NavTheme", MySqlDbType.VarChar,100),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?MenuId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.MenuName;
			parameters[1].Value = model.NavURL;
			parameters[2].Value = model.MenuTitle;
			parameters[3].Value = model.MenuType;
			parameters[4].Value = model.Target;
			parameters[5].Value = model.IsUsed;
			parameters[6].Value = model.Sequence;
			parameters[7].Value = model.Visible;
			parameters[8].Value = model.URLType;
			parameters[9].Value = model.NavTheme;
			parameters[10].Value = model.SupplierId;
			parameters[11].Value = model.MenuId;

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
		public bool Delete(int MenuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SupplierMenus ");
			strSql.Append(" where MenuId=?MenuId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MenuId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = MenuId;

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
		public bool DeleteList(string MenuIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SupplierMenus ");
			strSql.Append(" where MenuId in ("+MenuIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Supplier.SupplierMenus GetModel(int MenuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MenuId,MenuName,NavURL,MenuTitle,MenuType,Target,IsUsed,Sequence,Visible,URLType,NavTheme,SupplierId from Shop_SupplierMenus ");
			strSql.Append(" where MenuId=?MenuId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MenuId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = MenuId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Supplier.SupplierMenus model=new YSWL.MALL.Model.Shop.Supplier.SupplierMenus();
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
		public YSWL.MALL.Model.Shop.Supplier.SupplierMenus DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Supplier.SupplierMenus model=new YSWL.MALL.Model.Shop.Supplier.SupplierMenus();
			if (row != null)
			{
				if(row["MenuId"]!=null && row["MenuId"].ToString()!="")
				{
					model.MenuId=int.Parse(row["MenuId"].ToString());
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["NavURL"]!=null)
				{
					model.NavURL=row["NavURL"].ToString();
				}
				if(row["MenuTitle"]!=null)
				{
					model.MenuTitle=row["MenuTitle"].ToString();
				}
				if(row["MenuType"]!=null && row["MenuType"].ToString()!="")
				{
					model.MenuType=int.Parse(row["MenuType"].ToString());
				}
				if(row["Target"]!=null && row["Target"].ToString()!="")
				{
					model.Target=int.Parse(row["Target"].ToString());
				}
				if(row["IsUsed"]!=null && row["IsUsed"].ToString()!="")
				{
					if((row["IsUsed"].ToString()=="1")||(row["IsUsed"].ToString().ToLower()=="true"))
					{
						model.IsUsed=true;
					}
					else
					{
						model.IsUsed=false;
					}
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["Visible"]!=null && row["Visible"].ToString()!="")
				{
					model.Visible=int.Parse(row["Visible"].ToString());
				}
				if(row["URLType"]!=null && row["URLType"].ToString()!="")
				{
					model.URLType=int.Parse(row["URLType"].ToString());
				}
				if(row["NavTheme"]!=null)
				{
					model.NavTheme=row["NavTheme"].ToString();
				}
				if(row["SupplierId"]!=null && row["SupplierId"].ToString()!="")
				{
					model.SupplierId=int.Parse(row["SupplierId"].ToString());
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
			strSql.Append("select MenuId,MenuName,NavURL,MenuTitle,MenuType,Target,IsUsed,Sequence,Visible,URLType,NavTheme,SupplierId ");
			strSql.Append(" FROM Shop_SupplierMenus ");
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
			strSql.Append(" MenuId,MenuName,NavURL,MenuTitle,MenuType,Target,IsUsed,Sequence,Visible,URLType,NavTheme,SupplierId ");
			strSql.Append(" FROM Shop_SupplierMenus ");
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
			strSql.Append("select count(1) FROM Shop_SupplierMenus ");
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
            strSql.Append("SELECT T.* from Shop_SupplierMenus T ");
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
                strSql.Append(" order by T.MenuId desc");
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
			parameters[0].Value = "Shop_SupplierMenus";
			parameters[1].Value = "MenuId";
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

