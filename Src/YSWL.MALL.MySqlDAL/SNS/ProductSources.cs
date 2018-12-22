/**
* ProductSources.cs
*
* 功 能： N/A
* 类 名： ProductSources
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:50   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.SNS;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
	/// <summary>
	/// 数据访问类:ProductSources
	/// </summary>
	public partial class ProductSources:IProductSources
	{
		public ProductSources()
		{}
		#region  BasicMethod

		
		/// <summary>
		/// 是否存在
		/// </summary>
        public bool Exists(string WebSiteName, string WebSiteUrl)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_ProductSources");
            strSql.Append(" where WebSiteName=?WebSiteName or WebSiteUrl=?WebSiteUrl");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WebSiteName", MySqlDbType.VarChar,100),
					new MySqlParameter("?WebSiteUrl", MySqlDbType.VarChar,200)
			};
            parameters[0].Value = WebSiteName;
            parameters[1].Value = WebSiteUrl;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.ProductSources model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_ProductSources(");
			strSql.Append("WebSiteName,WebSiteUrl,WebSiteLogo,CategoryTags,PriceTags,ImagesTag,Status)");
			strSql.Append(" values (");
			strSql.Append("?WebSiteName,?WebSiteUrl,?WebSiteLogo,?CategoryTags,?PriceTags,?ImagesTag,?Status)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WebSiteName", MySqlDbType.VarChar,100),
					new MySqlParameter("?WebSiteUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?WebSiteLogo", MySqlDbType.VarChar,200),
					new MySqlParameter("?CategoryTags", MySqlDbType.VarChar),
					new MySqlParameter("?PriceTags", MySqlDbType.VarChar),
					new MySqlParameter("?ImagesTag", MySqlDbType.VarChar),
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
			parameters[0].Value = model.WebSiteName;
			parameters[1].Value = model.WebSiteUrl;
			parameters[2].Value = model.WebSiteLogo;
			parameters[3].Value = model.CategoryTags;
			parameters[4].Value = model.PriceTags;
			parameters[5].Value = model.ImagesTag;
			parameters[6].Value = model.Status;

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
		public bool Update(YSWL.MALL.Model.SNS.ProductSources model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_ProductSources set ");
			strSql.Append("WebSiteName=?WebSiteName,");
			strSql.Append("WebSiteUrl=?WebSiteUrl,");
			strSql.Append("WebSiteLogo=?WebSiteLogo,");
			strSql.Append("CategoryTags=?CategoryTags,");
			strSql.Append("PriceTags=?PriceTags,");
			strSql.Append("ImagesTag=?ImagesTag,");
			strSql.Append("Status=?Status");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?WebSiteName", MySqlDbType.VarChar,100),
					new MySqlParameter("?WebSiteUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?WebSiteLogo", MySqlDbType.VarChar,200),
					new MySqlParameter("?CategoryTags", MySqlDbType.VarChar),
					new MySqlParameter("?PriceTags", MySqlDbType.VarChar),
					new MySqlParameter("?ImagesTag", MySqlDbType.VarChar),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.WebSiteName;
			parameters[1].Value = model.WebSiteUrl;
			parameters[2].Value = model.WebSiteLogo;
			parameters[3].Value = model.CategoryTags;
			parameters[4].Value = model.PriceTags;
			parameters[5].Value = model.ImagesTag;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.ID;

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
		public bool Delete(int ID)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_ProductSources ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_ProductSources ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public YSWL.MALL.Model.SNS.ProductSources GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,WebSiteName,WebSiteUrl,WebSiteLogo,CategoryTags,PriceTags,ImagesTag,Status from SNS_ProductSources ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

			YSWL.MALL.Model.SNS.ProductSources model=new YSWL.MALL.Model.SNS.ProductSources();
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
		public YSWL.MALL.Model.SNS.ProductSources DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.ProductSources model=new YSWL.MALL.Model.SNS.ProductSources();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["WebSiteName"]!=null)
				{
					model.WebSiteName=row["WebSiteName"].ToString();
				}
				if(row["WebSiteUrl"]!=null)
				{
					model.WebSiteUrl=row["WebSiteUrl"].ToString();
				}
				if(row["WebSiteLogo"]!=null)
				{
					model.WebSiteLogo=row["WebSiteLogo"].ToString();
				}
				if(row["CategoryTags"]!=null)
				{
					model.CategoryTags=row["CategoryTags"].ToString();
				}
				if(row["PriceTags"]!=null)
				{
					model.PriceTags=row["PriceTags"].ToString();
				}
				if(row["ImagesTag"]!=null)
				{
					model.ImagesTag=row["ImagesTag"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
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
			strSql.Append("select ID,WebSiteName,WebSiteUrl,WebSiteLogo,CategoryTags,PriceTags,ImagesTag,Status ");
			strSql.Append(" FROM SNS_ProductSources ");
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
			
			strSql.Append(" ID,WebSiteName,WebSiteUrl,WebSiteLogo,CategoryTags,PriceTags,ImagesTag,Status ");
			strSql.Append(" FROM SNS_ProductSources ");
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
			strSql.Append("select count(1) FROM SNS_ProductSources ");
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_ProductSources T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "SNS_ProductSources";
			parameters[1].Value = "ID";
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

