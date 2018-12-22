/**
* Trials.cs
*
* 功 能： N/A
* 类 名： Trials
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/5/22 17:39:52   N/A    初版
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
using YSWL.MALL.IDAL.Shop.Trial;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Trial
{
	/// <summary>
	/// 数据访问类:Trials
	/// </summary>
	public partial class Trials:ITrials
	{
		public Trials()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("TrialId", "Shop_Trials"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TrialId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_Trials");
			strSql.Append(" where TrialId=?TrialId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TrialId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TrialId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Trial.Trials model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_Trials(");
			strSql.Append("CategoryId,TrialName,EnterpriseId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,LinklUrl,TrialStatus,StartDate,EndDate,CreatedDate,CreatedUserID,VistiCounts,TrialCounts,DisplaySequence,MarketPrice,LowestSalePrice,MainCategoryPath,ExtendCategoryPath,Points,ImageUrl,ThumbnailUrl,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle)");
			strSql.Append(" values (");
			strSql.Append("?CategoryId,?TrialName,?EnterpriseId,?RegionId,?ShortDescription,?Unit,?Description,?Meta_Title,?Meta_Description,?Meta_Keywords,?LinklUrl,?TrialStatus,?StartDate,?EndDate,?CreatedDate,?CreatedUserID,?VistiCounts,?TrialCounts,?DisplaySequence,?MarketPrice,?LowestSalePrice,?MainCategoryPath,?ExtendCategoryPath,?Points,?ImageUrl,?ThumbnailUrl,?MaxQuantity,?MinQuantity,?Tags,?SeoUrl,?SeoImageAlt,?SeoImageTitle)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?TrialName", MySqlDbType.VarChar,200),
					new MySqlParameter("?EnterpriseId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShortDescription", MySqlDbType.VarChar,2000),
					new MySqlParameter("?Unit", MySqlDbType.VarChar,50),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?LinklUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?TrialStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?VistiCounts", MySqlDbType.Int32,4),
					new MySqlParameter("?TrialCounts", MySqlDbType.Int32,4),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?MainCategoryPath", MySqlDbType.VarChar,256),
					new MySqlParameter("?ExtendCategoryPath", MySqlDbType.VarChar,256),
					new MySqlParameter("?Points", MySqlDbType.Decimal,9),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?MaxQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?MinQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,50),
					new MySqlParameter("?SeoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar,300)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.TrialName;
			parameters[2].Value = model.EnterpriseId;
			parameters[3].Value = model.RegionId;
			parameters[4].Value = model.ShortDescription;
			parameters[5].Value = model.Unit;
			parameters[6].Value = model.Description;
			parameters[7].Value = model.Meta_Title;
			parameters[8].Value = model.Meta_Description;
			parameters[9].Value = model.Meta_Keywords;
			parameters[10].Value = model.LinklUrl;
			parameters[11].Value = model.TrialStatus;
			parameters[12].Value = model.StartDate;
			parameters[13].Value = model.EndDate;
			parameters[14].Value = model.CreatedDate;
			parameters[15].Value = model.CreatedUserID;
			parameters[16].Value = model.VistiCounts;
			parameters[17].Value = model.TrialCounts;
			parameters[18].Value = model.DisplaySequence;
			parameters[19].Value = model.MarketPrice;
			parameters[20].Value = model.LowestSalePrice;
			parameters[21].Value = model.MainCategoryPath;
			parameters[22].Value = model.ExtendCategoryPath;
			parameters[23].Value = model.Points;
			parameters[24].Value = model.ImageUrl;
			parameters[25].Value = model.ThumbnailUrl;
			parameters[26].Value = model.MaxQuantity;
			parameters[27].Value = model.MinQuantity;
			parameters[28].Value = model.Tags;
			parameters[29].Value = model.SeoUrl;
			parameters[30].Value = model.SeoImageAlt;
			parameters[31].Value = model.SeoImageTitle;

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
		public bool Update(YSWL.MALL.Model.Shop.Trial.Trials model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_Trials set ");
			strSql.Append("CategoryId=?CategoryId,");
			strSql.Append("TrialName=?TrialName,");
			strSql.Append("EnterpriseId=?EnterpriseId,");
			strSql.Append("RegionId=?RegionId,");
			strSql.Append("ShortDescription=?ShortDescription,");
			strSql.Append("Unit=?Unit,");
			strSql.Append("Description=?Description,");
			strSql.Append("Meta_Title=?Meta_Title,");
			strSql.Append("Meta_Description=?Meta_Description,");
			strSql.Append("Meta_Keywords=?Meta_Keywords,");
			strSql.Append("LinklUrl=?LinklUrl,");
			strSql.Append("TrialStatus=?TrialStatus,");
			strSql.Append("StartDate=?StartDate,");
			strSql.Append("EndDate=?EndDate,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("CreatedUserID=?CreatedUserID,");
			strSql.Append("VistiCounts=?VistiCounts,");
			strSql.Append("TrialCounts=?TrialCounts,");
			strSql.Append("DisplaySequence=?DisplaySequence,");
			strSql.Append("MarketPrice=?MarketPrice,");
			strSql.Append("LowestSalePrice=?LowestSalePrice,");
			strSql.Append("MainCategoryPath=?MainCategoryPath,");
			strSql.Append("ExtendCategoryPath=?ExtendCategoryPath,");
			strSql.Append("Points=?Points,");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("ThumbnailUrl=?ThumbnailUrl,");
			strSql.Append("MaxQuantity=?MaxQuantity,");
			strSql.Append("MinQuantity=?MinQuantity,");
			strSql.Append("Tags=?Tags,");
			strSql.Append("SeoUrl=?SeoUrl,");
			strSql.Append("SeoImageAlt=?SeoImageAlt,");
			strSql.Append("SeoImageTitle=?SeoImageTitle");
			strSql.Append(" where TrialId=?TrialId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?TrialName", MySqlDbType.VarChar,200),
					new MySqlParameter("?EnterpriseId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ShortDescription", MySqlDbType.VarChar,2000),
					new MySqlParameter("?Unit", MySqlDbType.VarChar,50),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?LinklUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?TrialStatus", MySqlDbType.Int16,2),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?VistiCounts", MySqlDbType.Int32,4),
					new MySqlParameter("?TrialCounts", MySqlDbType.Int32,4),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?MainCategoryPath", MySqlDbType.VarChar,256),
					new MySqlParameter("?ExtendCategoryPath", MySqlDbType.VarChar,256),
					new MySqlParameter("?Points", MySqlDbType.Decimal,9),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?MaxQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?MinQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,50),
					new MySqlParameter("?SeoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar,300),
					new MySqlParameter("?TrialId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.CategoryId;
			parameters[1].Value = model.TrialName;
			parameters[2].Value = model.EnterpriseId;
			parameters[3].Value = model.RegionId;
			parameters[4].Value = model.ShortDescription;
			parameters[5].Value = model.Unit;
			parameters[6].Value = model.Description;
			parameters[7].Value = model.Meta_Title;
			parameters[8].Value = model.Meta_Description;
			parameters[9].Value = model.Meta_Keywords;
			parameters[10].Value = model.LinklUrl;
			parameters[11].Value = model.TrialStatus;
			parameters[12].Value = model.StartDate;
			parameters[13].Value = model.EndDate;
			parameters[14].Value = model.CreatedDate;
			parameters[15].Value = model.CreatedUserID;
			parameters[16].Value = model.VistiCounts;
			parameters[17].Value = model.TrialCounts;
			parameters[18].Value = model.DisplaySequence;
			parameters[19].Value = model.MarketPrice;
			parameters[20].Value = model.LowestSalePrice;
			parameters[21].Value = model.MainCategoryPath;
			parameters[22].Value = model.ExtendCategoryPath;
			parameters[23].Value = model.Points;
			parameters[24].Value = model.ImageUrl;
			parameters[25].Value = model.ThumbnailUrl;
			parameters[26].Value = model.MaxQuantity;
			parameters[27].Value = model.MinQuantity;
			parameters[28].Value = model.Tags;
			parameters[29].Value = model.SeoUrl;
			parameters[30].Value = model.SeoImageAlt;
			parameters[31].Value = model.SeoImageTitle;
			parameters[32].Value = model.TrialId;

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
		public bool Delete(int TrialId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Trials ");
			strSql.Append(" where TrialId=?TrialId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TrialId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TrialId;

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
		public bool DeleteList(string TrialIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Trials ");
			strSql.Append(" where TrialId in ("+TrialIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Trial.Trials GetModel(int TrialId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  TrialId,CategoryId,TrialName,EnterpriseId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,LinklUrl,TrialStatus,StartDate,EndDate,CreatedDate,CreatedUserID,VistiCounts,TrialCounts,DisplaySequence,MarketPrice,LowestSalePrice,MainCategoryPath,ExtendCategoryPath,Points,ImageUrl,ThumbnailUrl,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle from Shop_Trials ");
			strSql.Append(" where TrialId=?TrialId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TrialId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TrialId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Trial.Trials model=new YSWL.MALL.Model.Shop.Trial.Trials();
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
		public YSWL.MALL.Model.Shop.Trial.Trials DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Trial.Trials model=new YSWL.MALL.Model.Shop.Trial.Trials();
			if (row != null)
			{
				if(row["TrialId"]!=null && row["TrialId"].ToString()!="")
				{
					model.TrialId=int.Parse(row["TrialId"].ToString());
				}
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
				}
				if(row["TrialName"]!=null)
				{
					model.TrialName=row["TrialName"].ToString();
				}
				if(row["EnterpriseId"]!=null && row["EnterpriseId"].ToString()!="")
				{
					model.EnterpriseId=int.Parse(row["EnterpriseId"].ToString());
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
				}
				if(row["ShortDescription"]!=null)
				{
					model.ShortDescription=row["ShortDescription"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Meta_Title"]!=null)
				{
					model.Meta_Title=row["Meta_Title"].ToString();
				}
				if(row["Meta_Description"]!=null)
				{
					model.Meta_Description=row["Meta_Description"].ToString();
				}
				if(row["Meta_Keywords"]!=null)
				{
					model.Meta_Keywords=row["Meta_Keywords"].ToString();
				}
				if(row["LinklUrl"]!=null)
				{
					model.LinklUrl=row["LinklUrl"].ToString();
				}
				if(row["TrialStatus"]!=null && row["TrialStatus"].ToString()!="")
				{
					model.TrialStatus=int.Parse(row["TrialStatus"].ToString());
				}
				if(row["StartDate"]!=null && row["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(row["StartDate"].ToString());
				}
				if(row["EndDate"]!=null && row["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(row["EndDate"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["CreatedUserID"]!=null && row["CreatedUserID"].ToString()!="")
				{
					model.CreatedUserID=int.Parse(row["CreatedUserID"].ToString());
				}
				if(row["VistiCounts"]!=null && row["VistiCounts"].ToString()!="")
				{
					model.VistiCounts=int.Parse(row["VistiCounts"].ToString());
				}
				if(row["TrialCounts"]!=null && row["TrialCounts"].ToString()!="")
				{
					model.TrialCounts=int.Parse(row["TrialCounts"].ToString());
				}
				if(row["DisplaySequence"]!=null && row["DisplaySequence"].ToString()!="")
				{
					model.DisplaySequence=int.Parse(row["DisplaySequence"].ToString());
				}
				if(row["MarketPrice"]!=null && row["MarketPrice"].ToString()!="")
				{
					model.MarketPrice=decimal.Parse(row["MarketPrice"].ToString());
				}
				if(row["LowestSalePrice"]!=null && row["LowestSalePrice"].ToString()!="")
				{
					model.LowestSalePrice=decimal.Parse(row["LowestSalePrice"].ToString());
				}
				if(row["MainCategoryPath"]!=null)
				{
					model.MainCategoryPath=row["MainCategoryPath"].ToString();
				}
				if(row["ExtendCategoryPath"]!=null)
				{
					model.ExtendCategoryPath=row["ExtendCategoryPath"].ToString();
				}
				if(row["Points"]!=null && row["Points"].ToString()!="")
				{
					model.Points=decimal.Parse(row["Points"].ToString());
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["ThumbnailUrl"]!=null)
				{
					model.ThumbnailUrl=row["ThumbnailUrl"].ToString();
				}
				if(row["MaxQuantity"]!=null && row["MaxQuantity"].ToString()!="")
				{
					model.MaxQuantity=int.Parse(row["MaxQuantity"].ToString());
				}
				if(row["MinQuantity"]!=null && row["MinQuantity"].ToString()!="")
				{
					model.MinQuantity=int.Parse(row["MinQuantity"].ToString());
				}
				if(row["Tags"]!=null)
				{
					model.Tags=row["Tags"].ToString();
				}
				if(row["SeoUrl"]!=null)
				{
					model.SeoUrl=row["SeoUrl"].ToString();
				}
				if(row["SeoImageAlt"]!=null)
				{
					model.SeoImageAlt=row["SeoImageAlt"].ToString();
				}
				if(row["SeoImageTitle"]!=null)
				{
					model.SeoImageTitle=row["SeoImageTitle"].ToString();
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
			strSql.Append("select TrialId,CategoryId,TrialName,EnterpriseId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,LinklUrl,TrialStatus,StartDate,EndDate,CreatedDate,CreatedUserID,VistiCounts,TrialCounts,DisplaySequence,MarketPrice,LowestSalePrice,MainCategoryPath,ExtendCategoryPath,Points,ImageUrl,ThumbnailUrl,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle ");
			strSql.Append(" FROM Shop_Trials ");
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
			strSql.Append(" TrialId,CategoryId,TrialName,EnterpriseId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,LinklUrl,TrialStatus,StartDate,EndDate,CreatedDate,CreatedUserID,VistiCounts,TrialCounts,DisplaySequence,MarketPrice,LowestSalePrice,MainCategoryPath,ExtendCategoryPath,Points,ImageUrl,ThumbnailUrl,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle ");
			strSql.Append(" FROM Shop_Trials ");
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
			strSql.Append("select count(1) FROM Shop_Trials ");
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
            strSql.Append("SELECT T.* from Shop_Trials T ");
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
                strSql.Append(" order by T.TrialId desc");
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
			parameters[0].Value = "Shop_Trials";
			parameters[1].Value = "TrialId";
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

