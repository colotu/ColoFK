/**
* OnLineShopPhoto.cs
*
* 功 能： N/A
* 类 名： OnLineShopPhoto
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:46   N/A    初版
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
	/// 数据访问类:OnLineShopPhoto
	/// </summary>
	public partial class OnLineShopPhoto:IOnLineShopPhoto
	{
		public OnLineShopPhoto()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PhotoID,int ProductID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_OnLineShopPhoto");
			strSql.Append(" where PhotoID=?PhotoID and ProductID=?ProductID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoID", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4)			};
			parameters[0].Value = PhotoID;
			parameters[1].Value = ProductID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.SNS.OnLineShopPhoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_OnLineShopPhoto(");
			strSql.Append("PhotoID,ProductID,CreatedUserId,CreatedNickName,CreatedDate,Status)");
			strSql.Append(" values (");
			strSql.Append("?PhotoID,?ProductID,?CreatedUserId,?CreatedNickName,?CreatedDate,?Status)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoID", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
			parameters[0].Value = model.PhotoID;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.CreatedUserId;
			parameters[3].Value = model.CreatedNickName;
			parameters[4].Value = model.CreatedDate;
			parameters[5].Value = model.Status;

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
		public bool Update(YSWL.MALL.Model.SNS.OnLineShopPhoto model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_OnLineShopPhoto set ");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedNickName=?CreatedNickName,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Status=?Status");
			strSql.Append(" where PhotoID=?PhotoID and ProductID=?ProductID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?PhotoID", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.CreatedUserId;
			parameters[1].Value = model.CreatedNickName;
			parameters[2].Value = model.CreatedDate;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.PhotoID;
			parameters[5].Value = model.ProductID;

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
		public bool Delete(int PhotoID,int ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_OnLineShopPhoto ");
			strSql.Append(" where PhotoID=?PhotoID and ProductID=?ProductID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoID", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4)			};
			parameters[0].Value = PhotoID;
			parameters[1].Value = ProductID;

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
		public YSWL.MALL.Model.SNS.OnLineShopPhoto GetModel(int PhotoID,int ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PhotoID,ProductID,CreatedUserId,CreatedNickName,CreatedDate,Status from SNS_OnLineShopPhoto ");
            strSql.Append(" where PhotoID=?PhotoID and ProductID=?ProductID  LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoID", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4)			};
			parameters[0].Value = PhotoID;
			parameters[1].Value = ProductID;

			YSWL.MALL.Model.SNS.OnLineShopPhoto model=new YSWL.MALL.Model.SNS.OnLineShopPhoto();
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
		public YSWL.MALL.Model.SNS.OnLineShopPhoto DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.OnLineShopPhoto model=new YSWL.MALL.Model.SNS.OnLineShopPhoto();
			if (row != null)
			{
				if(row["PhotoID"]!=null && row["PhotoID"].ToString()!="")
				{
					model.PhotoID=int.Parse(row["PhotoID"].ToString());
				}
				if(row["ProductID"]!=null && row["ProductID"].ToString()!="")
				{
					model.ProductID=int.Parse(row["ProductID"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedNickName"]!=null)
				{
					model.CreatedNickName=row["CreatedNickName"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
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
			strSql.Append("select PhotoID,ProductID,CreatedUserId,CreatedNickName,CreatedDate,Status ");
			strSql.Append(" FROM SNS_OnLineShopPhoto ");
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
			
			strSql.Append(" PhotoID,ProductID,CreatedUserId,CreatedNickName,CreatedDate,Status ");
			strSql.Append(" FROM SNS_OnLineShopPhoto ");
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
			strSql.Append("select count(1) FROM SNS_OnLineShopPhoto ");
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
				strSql.Append("order by T.ProductID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_OnLineShopPhoto T ");
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
			parameters[0].Value = "SNS_OnLineShopPhoto";
			parameters[1].Value = "ProductID";
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

