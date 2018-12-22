/**
* UserAttendance.cs
*
* 功 能： N/A
* 类 名： UserAttendance
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/1/20 16:07:41   N/A    初版
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
using YSWL.MALL.IDAL.JLT;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.JLT
{
	/// <summary>
	/// 数据访问类:UserAttendance
	/// </summary>
	public partial class UserAttendance:IUserAttendance
	{
		public UserAttendance()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "JLT_UserAttendance"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from JLT_UserAttendance");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.JLT.UserAttendance model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JLT_UserAttendance(");
			strSql.Append("EnterpriseID,UserID,UserName,TrueName,Latitude,Longitude,Address,Kilometers,TypeID,CreatedDate,AttendanceDate,Description,ImagePath,Score,Status,ReviewedUserID,ReviewedDescription,ReviewedDate,ReviewedStatus,Remark)");
			strSql.Append(" values (");
			strSql.Append("?EnterpriseID,?UserID,?UserName,?TrueName,?Latitude,?Longitude,?Address,?Kilometers,?TypeID,?CreatedDate,?AttendanceDate,?Description,?ImagePath,?Score,?Status,?ReviewedUserID,?ReviewedDescription,?ReviewedDate,?ReviewedStatus,?Remark)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?EnterpriseID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Latitude", MySqlDbType.VarChar,50),
					new MySqlParameter("?Longitude", MySqlDbType.VarChar,50),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?Kilometers", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?AttendanceDate", MySqlDbType.DateTime),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImagePath", MySqlDbType.VarChar,500),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewedDescription", MySqlDbType.VarChar,300),
					new MySqlParameter("?ReviewedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReviewedStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.EnterpriseID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.TrueName;
			parameters[4].Value = model.Latitude;
			parameters[5].Value = model.Longitude;
			parameters[6].Value = model.Address;
			parameters[7].Value = model.Kilometers;
			parameters[8].Value = model.TypeID;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.AttendanceDate;
			parameters[11].Value = model.Description;
			parameters[12].Value = model.ImagePath;
			parameters[13].Value = model.Score;
			parameters[14].Value = model.Status;
			parameters[15].Value = model.ReviewedUserID;
			parameters[16].Value = model.ReviewedDescription;
			parameters[17].Value = model.ReviewedDate;
			parameters[18].Value = model.ReviewedStatus;
			parameters[19].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.JLT.UserAttendance model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JLT_UserAttendance set ");
			strSql.Append("EnterpriseID=?EnterpriseID,");
			strSql.Append("UserID=?UserID,");
			strSql.Append("UserName=?UserName,");
			strSql.Append("TrueName=?TrueName,");
			strSql.Append("Latitude=?Latitude,");
			strSql.Append("Longitude=?Longitude,");
			strSql.Append("Address=?Address,");
			strSql.Append("Kilometers=?Kilometers,");
			strSql.Append("TypeID=?TypeID,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("AttendanceDate=?AttendanceDate,");
			strSql.Append("Description=?Description,");
			strSql.Append("ImagePath=?ImagePath,");
			strSql.Append("Score=?Score,");
			strSql.Append("Status=?Status,");
			strSql.Append("ReviewedUserID=?ReviewedUserID,");
			strSql.Append("ReviewedDescription=?ReviewedDescription,");
			strSql.Append("ReviewedDate=?ReviewedDate,");
			strSql.Append("ReviewedStatus=?ReviewedStatus,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?EnterpriseID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Latitude", MySqlDbType.VarChar,50),
					new MySqlParameter("?Longitude", MySqlDbType.VarChar,50),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?Kilometers", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?AttendanceDate", MySqlDbType.DateTime),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImagePath", MySqlDbType.VarChar,500),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewedDescription", MySqlDbType.VarChar,300),
					new MySqlParameter("?ReviewedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReviewedStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.EnterpriseID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.TrueName;
			parameters[4].Value = model.Latitude;
			parameters[5].Value = model.Longitude;
			parameters[6].Value = model.Address;
			parameters[7].Value = model.Kilometers;
			parameters[8].Value = model.TypeID;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.AttendanceDate;
			parameters[11].Value = model.Description;
			parameters[12].Value = model.ImagePath;
			parameters[13].Value = model.Score;
			parameters[14].Value = model.Status;
			parameters[15].Value = model.ReviewedUserID;
			parameters[16].Value = model.ReviewedDescription;
			parameters[17].Value = model.ReviewedDate;
			parameters[18].Value = model.ReviewedStatus;
			parameters[19].Value = model.Remark;
			parameters[20].Value = model.ID;

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
			strSql.Append("delete from JLT_UserAttendance ");
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
			strSql.Append("delete from JLT_UserAttendance ");
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
		public YSWL.MALL.Model.JLT.UserAttendance GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ID,EnterpriseID,UserID,UserName,TrueName,Latitude,Longitude,Address,Kilometers,TypeID,CreatedDate,AttendanceDate,Description,ImagePath,Score,Status,ReviewedUserID,ReviewedDescription,ReviewedDate,ReviewedStatus,Remark from JLT_UserAttendance ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.JLT.UserAttendance model=new YSWL.MALL.Model.JLT.UserAttendance();
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
		public YSWL.MALL.Model.JLT.UserAttendance DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.JLT.UserAttendance model=new YSWL.MALL.Model.JLT.UserAttendance();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["EnterpriseID"]!=null && row["EnterpriseID"].ToString()!="")
				{
					model.EnterpriseID=int.Parse(row["EnterpriseID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["TrueName"]!=null)
				{
					model.TrueName=row["TrueName"].ToString();
				}
				if(row["Latitude"]!=null)
				{
					model.Latitude=row["Latitude"].ToString();
				}
				if(row["Longitude"]!=null)
				{
					model.Longitude=row["Longitude"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Kilometers"]!=null && row["Kilometers"].ToString()!="")
				{
					model.Kilometers=int.Parse(row["Kilometers"].ToString());
				}
				if(row["TypeID"]!=null && row["TypeID"].ToString()!="")
				{
					model.TypeID=int.Parse(row["TypeID"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["AttendanceDate"]!=null && row["AttendanceDate"].ToString()!="")
				{
					model.AttendanceDate=DateTime.Parse(row["AttendanceDate"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["ImagePath"]!=null)
				{
					model.ImagePath=row["ImagePath"].ToString();
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=int.Parse(row["Score"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["ReviewedUserID"]!=null && row["ReviewedUserID"].ToString()!="")
				{
					model.ReviewedUserID=int.Parse(row["ReviewedUserID"].ToString());
				}
				if(row["ReviewedDescription"]!=null)
				{
					model.ReviewedDescription=row["ReviewedDescription"].ToString();
				}
				if(row["ReviewedDate"]!=null && row["ReviewedDate"].ToString()!="")
				{
					model.ReviewedDate=DateTime.Parse(row["ReviewedDate"].ToString());
				}
				if(row["ReviewedStatus"]!=null && row["ReviewedStatus"].ToString()!="")
				{
					model.ReviewedStatus=int.Parse(row["ReviewedStatus"].ToString());
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
			strSql.Append("select ID,EnterpriseID,UserID,UserName,TrueName,Latitude,Longitude,Address,Kilometers,TypeID,CreatedDate,AttendanceDate,Description,ImagePath,Score,Status,ReviewedUserID,ReviewedDescription,ReviewedDate,ReviewedStatus,Remark ");
			strSql.Append(" FROM JLT_UserAttendance ");
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
			
			strSql.Append(" ID,EnterpriseID,UserID,UserName,TrueName,Latitude,Longitude,Address,Kilometers,TypeID,CreatedDate,AttendanceDate,Description,ImagePath,Score,Status,ReviewedUserID,ReviewedDescription,ReviewedDate,ReviewedStatus,Remark ");
			strSql.Append(" FROM JLT_UserAttendance ");
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
			strSql.Append("select count(1) FROM JLT_UserAttendance ");
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
            strSql.Append("SELECT T.* from JLT_UserAttendance T ");
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
                strSql.Append(" order by T.ID desc");
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
			parameters[0].Value = "JLT_UserAttendance";
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
        /// <summary>
        /// 批量处理
        /// </summary>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JLT_UserAttendance set " + strWhere);
            strSql.Append(" where ID in(" + IDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        /// 统计考勤
        /// </summary>
        /// <param name="strWhere">条件</param>
        public DataSet Statistics(string strWhere)
        {
            return DbHelperMySQL.RunProcedure("sp_UserAttendance_Statistics",
              new IDataParameter[]
                  {
                      DbHelperMySQL.CreateInParam("_SqlWhere", MySqlDbType.VarChar, 3000, strWhere)
                  }, "StatisticsTable");
        }

        /// <summary>
        /// 获取用户考勤数据
        /// </summary>
        /// <param name="strWhere">条件</param>
        public DataSet GetCollectAttendance(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
SELECT  T.UserID
      , T.UserName
      , T.AttendanceDate
      , STUFF(( SELECT  '　' + RTRIM(CONVERT(CHAR(8), CreatedDate, 114))
                FROM    JLT_UserAttendance
                WHERE   UserID = T.UserID
                        AND AttendanceDate = T.AttendanceDate
              FOR
                XML PATH('')
              ), 1, 1, '') AS CreatedDate
FROM    ( SELECT DISTINCT
                    UserID
                  , UserName
                  , AttendanceDate
          FROM      JLT_UserAttendance");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) T");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

