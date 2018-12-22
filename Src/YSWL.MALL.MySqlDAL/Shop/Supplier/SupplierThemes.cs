/**
* SupplierThemes.cs
*
* 功 能： N/A
* 类 名： SupplierThemes
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/26 17:31:51   Ben    初版
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
	/// 数据访问类:SupplierThemes
	/// </summary>
	public partial class SupplierThemes:ISupplierThemes
	{
		public SupplierThemes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ThemeId", "Shop_SupplierThemes"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ThemeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_SupplierThemes");
			strSql.Append(" where ThemeId=?ThemeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ThemeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ThemeId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Supplier.SupplierThemes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_SupplierThemes(");
			strSql.Append("Name,Description,ImageUrl,Author,WebSite,Language,CreatedDate,UpdatedDate,Remark)");
			strSql.Append(" values (");
			strSql.Append("?Name,?Description,?ImageUrl,?Author,?WebSite,?Language,?CreatedDate,?UpdatedDate,?Remark)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,100),
					new MySqlParameter("?Author", MySqlDbType.VarChar,100),
					new MySqlParameter("?WebSite", MySqlDbType.VarChar,200),
					new MySqlParameter("?Language", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.ImageUrl;
			parameters[3].Value = model.Author;
			parameters[4].Value = model.WebSite;
			parameters[5].Value = model.Language;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.UpdatedDate;
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
		public bool Update(YSWL.MALL.Model.Shop.Supplier.SupplierThemes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_SupplierThemes set ");
			strSql.Append("Name=?Name,");
			strSql.Append("Description=?Description,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("Author=?Author,");
			strSql.Append("WebSite=?WebSite,");
			strSql.Append("Language=?Language,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("UpdatedDate=?UpdatedDate,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ThemeId=?ThemeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,100),
					new MySqlParameter("?Author", MySqlDbType.VarChar,100),
					new MySqlParameter("?WebSite", MySqlDbType.VarChar,200),
					new MySqlParameter("?Language", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100),
					new MySqlParameter("?ThemeId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.ImageUrl;
			parameters[3].Value = model.Author;
			parameters[4].Value = model.WebSite;
			parameters[5].Value = model.Language;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.UpdatedDate;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.ThemeId;

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
		public bool Delete(int ThemeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SupplierThemes ");
			strSql.Append(" where ThemeId=?ThemeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ThemeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ThemeId;

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
		public bool DeleteList(string ThemeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SupplierThemes ");
			strSql.Append(" where ThemeId in ("+ThemeIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Supplier.SupplierThemes GetModel(int ThemeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ThemeId,Name,Description,ImageUrl,Author,WebSite,Language,CreatedDate,UpdatedDate,Remark from Shop_SupplierThemes ");
			strSql.Append(" where ThemeId=?ThemeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ThemeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ThemeId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Supplier.SupplierThemes model=new YSWL.MALL.Model.Shop.Supplier.SupplierThemes();
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
		public YSWL.MALL.Model.Shop.Supplier.SupplierThemes DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Supplier.SupplierThemes model=new YSWL.MALL.Model.Shop.Supplier.SupplierThemes();
			if (row != null)
			{
				if(row["ThemeId"]!=null && row["ThemeId"].ToString()!="")
				{
					model.ThemeId=int.Parse(row["ThemeId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["Author"]!=null)
				{
					model.Author=row["Author"].ToString();
				}
				if(row["WebSite"]!=null)
				{
					model.WebSite=row["WebSite"].ToString();
				}
				if(row["Language"]!=null)
				{
					model.Language=row["Language"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["UpdatedDate"]!=null && row["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(row["UpdatedDate"].ToString());
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
			strSql.Append("select ThemeId,Name,Description,ImageUrl,Author,WebSite,Language,CreatedDate,UpdatedDate,Remark ");
			strSql.Append(" FROM Shop_SupplierThemes ");
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
			strSql.Append(" ThemeId,Name,Description,ImageUrl,Author,WebSite,Language,CreatedDate,UpdatedDate,Remark ");
			strSql.Append(" FROM Shop_SupplierThemes ");
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
			strSql.Append("select count(1) FROM Shop_SupplierThemes ");
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
            strSql.Append("SELECT T.* from Shop_SupplierThemes T ");
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
                strSql.Append(" order by T.ThemeId desc");
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
			parameters[0].Value = "Shop_SupplierThemes";
			parameters[1].Value = "ThemeId";
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

