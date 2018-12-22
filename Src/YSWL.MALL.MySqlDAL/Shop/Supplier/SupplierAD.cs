/**  版本信息模板在安装目录下，可自行修改。
* SupplierAD.cs
*
* 功 能： N/A
* 类 名： SupplierAD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/10/30 10:48:44   N/A    初版
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
using YSWL.MALL.IDAL.Shop;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Supplier;
using MySql.Data.MySqlClient;

//Please add references
namespace YSWL.MALL.MySqlDAL.Shop.Supplier
{
	/// <summary>
	/// 数据访问类:SupplierAD
	/// </summary>
	public partial class SupplierAD:ISupplierAD
	{
		public SupplierAD()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("AdvertisementId", "Shop_SupplierAD"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AdvertisementId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_SupplierAD");
			strSql.Append(" where AdvertisementId=?AdvertisementId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AdvertisementId", MySqlDbType.Int32,4)			};
			parameters[0].Value = AdvertisementId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int  Add(YSWL.MALL.Model.Shop.Supplier.SupplierAD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_SupplierAD(");
			strSql.Append(" Name,PositionId,ContentType,FileUrl,AlternateText,NavigateUrl,AdvHtml,CreatedDate,CreatedUserID,Status,Sequence,SupplierId)");
			strSql.Append(" values (");
			strSql.Append(" ?Name,?PositionId,?ContentType,?FileUrl,?AlternateText,?NavigateUrl,?AdvHtml,?CreatedDate,?CreatedUserID,?Status,?Sequence,?SupplierId)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?PositionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ContentType", MySqlDbType.Int32,4),
					new MySqlParameter("?FileUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?AlternateText", MySqlDbType.VarChar,200),
					new MySqlParameter("?NavigateUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?AdvHtml", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.PositionId;
			parameters[2].Value = model.ContentType;
			parameters[3].Value = model.FileUrl;
			parameters[4].Value = model.AlternateText;
			parameters[5].Value = model.NavigateUrl;
			parameters[6].Value = model.AdvHtml;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.CreatedUserID;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.Sequence;
			parameters[11].Value = model.SupplierId;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(YSWL.MALL.Model.Shop.Supplier.SupplierAD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_SupplierAD set ");
			strSql.Append("Name=?Name,");
			strSql.Append("PositionId=?PositionId,");
			strSql.Append("ContentType=?ContentType,");
			strSql.Append("FileUrl=?FileUrl,");
			strSql.Append("AlternateText=?AlternateText,");
			strSql.Append("NavigateUrl=?NavigateUrl,");
			strSql.Append("AdvHtml=?AdvHtml,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("CreatedUserID=?CreatedUserID,");
			strSql.Append("Status=?Status,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("SupplierId=?SupplierId");
			strSql.Append(" where AdvertisementId=?AdvertisementId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?PositionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ContentType", MySqlDbType.Int32,4),
					new MySqlParameter("?FileUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?AlternateText", MySqlDbType.VarChar,200),
					new MySqlParameter("?NavigateUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?AdvHtml", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?AdvertisementId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.PositionId;
			parameters[2].Value = model.ContentType;
			parameters[3].Value = model.FileUrl;
			parameters[4].Value = model.AlternateText;
			parameters[5].Value = model.NavigateUrl;
			parameters[6].Value = model.AdvHtml;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.CreatedUserID;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.Sequence;
			parameters[11].Value = model.SupplierId;
			parameters[12].Value = model.AdvertisementId;

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
		public bool Delete(int AdvertisementId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SupplierAD ");
			strSql.Append(" where AdvertisementId=?AdvertisementId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AdvertisementId", MySqlDbType.Int32,4)			};
			parameters[0].Value = AdvertisementId;

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
		public bool DeleteList(string AdvertisementIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SupplierAD ");
			strSql.Append(" where AdvertisementId in ("+AdvertisementIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Supplier.SupplierAD GetModel(int AdvertisementId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AdvertisementId,Name,PositionId,ContentType,FileUrl,AlternateText,NavigateUrl,AdvHtml,CreatedDate,CreatedUserID,Status,Sequence,SupplierId from Shop_SupplierAD ");
			strSql.Append(" where AdvertisementId=?AdvertisementId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?AdvertisementId", MySqlDbType.Int32,4)			};
			parameters[0].Value = AdvertisementId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Supplier.SupplierAD model = new YSWL.MALL.Model.Shop.Supplier.SupplierAD();
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
        public YSWL.MALL.Model.Shop.Supplier.SupplierAD DataRowToModel(DataRow row)
		{
            YSWL.MALL.Model.Shop.Supplier.SupplierAD model = new YSWL.MALL.Model.Shop.Supplier.SupplierAD();
			if (row != null)
			{
				if(row["AdvertisementId"]!=null && row["AdvertisementId"].ToString()!="")
				{
					model.AdvertisementId=int.Parse(row["AdvertisementId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["PositionId"]!=null && row["PositionId"].ToString()!="")
				{
					model.PositionId=int.Parse(row["PositionId"].ToString());
				}
				if(row["ContentType"]!=null && row["ContentType"].ToString()!="")
				{
					model.ContentType=int.Parse(row["ContentType"].ToString());
				}
				if(row["FileUrl"]!=null)
				{
					model.FileUrl=row["FileUrl"].ToString();
				}
				if(row["AlternateText"]!=null)
				{
					model.AlternateText=row["AlternateText"].ToString();
				}
				if(row["NavigateUrl"]!=null)
				{
					model.NavigateUrl=row["NavigateUrl"].ToString();
				}
				if(row["AdvHtml"]!=null)
				{
					model.AdvHtml=row["AdvHtml"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["CreatedUserID"]!=null && row["CreatedUserID"].ToString()!="")
				{
					model.CreatedUserID=int.Parse(row["CreatedUserID"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
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
			strSql.Append("select AdvertisementId,Name,PositionId,ContentType,FileUrl,AlternateText,NavigateUrl,AdvHtml,CreatedDate,CreatedUserID,Status,Sequence,SupplierId ");
			strSql.Append(" FROM Shop_SupplierAD ");
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
			strSql.Append(" AdvertisementId,Name,PositionId,ContentType,FileUrl,AlternateText,NavigateUrl,AdvHtml,CreatedDate,CreatedUserID,Status,Sequence,SupplierId ");
			strSql.Append(" FROM Shop_SupplierAD ");
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
			strSql.Append("select count(1) FROM Shop_SupplierAD ");
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
            strSql.Append("SELECT T.* from Shop_SupplierAD T ");
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
                strSql.Append(" order by T.AdvertisementId desc");
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
			parameters[0].Value = "Shop_SupplierAD";
			parameters[1].Value = "AdvertisementId";
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

