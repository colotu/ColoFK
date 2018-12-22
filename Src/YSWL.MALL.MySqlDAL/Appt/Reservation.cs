/**  版本信息模板在安装目录下，可自行修改。
* Reservation.cs
*
* 功 能： N/A
* 类 名： Reservation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/2 19:07:47   N/A    初版
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
using YSWL.MALL.IDAL.Appt;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Appt
{
	/// <summary>
	/// 数据访问类:Reservation
	/// </summary>
	public partial class Reservation:IReservation
	{
		public Reservation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ReservalId", "Appt_Reservation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReservalId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Appt_Reservation");
			strSql.Append(" where ReservalId=?ReservalId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ReservalId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ReservalId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Appt.Reservation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Appt_Reservation(");
			strSql.Append("Name,RegionId,ContactName,ContactPhone,ReservalDate,Content,Address,ContactEmail,Status,CreatedDate,CreatedUserId,SupplierId,ServiceId,OrderCode,Remark)");
			strSql.Append(" values (");
			strSql.Append("?Name,?RegionId,?ContactName,?ContactPhone,?ReservalDate,?Content,?Address,?ContactEmail,?Status,?CreatedDate,?CreatedUserId,?SupplierId,?ServiceId,?OrderCode,?Remark)");
            strSql.Append(";select last_insert_id();");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ContactName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ContactPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ReservalDate", MySqlDbType.DateTime),
					new MySqlParameter("?Content", MySqlDbType.VarChar,50),
					new MySqlParameter("?Address", MySqlDbType.VarChar,100),
					new MySqlParameter("?ContactEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?ServiceId", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,100),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.RegionId;
			parameters[2].Value = model.ContactName;
			parameters[3].Value = model.ContactPhone;
			parameters[4].Value = model.ReservalDate;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.Address;
			parameters[7].Value = model.ContactEmail;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.CreatedUserId;
			parameters[11].Value = model.SupplierId;
			parameters[12].Value = model.ServiceId;
			parameters[13].Value = model.OrderCode;
			parameters[14].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.Appt.Reservation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Appt_Reservation set ");
			strSql.Append("Name=?Name,");
			strSql.Append("RegionId=?RegionId,");
			strSql.Append("ContactName=?ContactName,");
			strSql.Append("ContactPhone=?ContactPhone,");
			strSql.Append("ReservalDate=?ReservalDate,");
			strSql.Append("Content=?Content,");
			strSql.Append("Address=?Address,");
			strSql.Append("ContactEmail=?ContactEmail,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("SupplierId=?SupplierId,");
			strSql.Append("ServiceId=?ServiceId,");
			strSql.Append("OrderCode=?OrderCode,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ReservalId=?ReservalId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?ContactName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ContactPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?ReservalDate", MySqlDbType.DateTime),
					new MySqlParameter("?Content", MySqlDbType.VarChar,50),
					new MySqlParameter("?Address", MySqlDbType.VarChar,100),
					new MySqlParameter("?ContactEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?ServiceId", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,100),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,50),
					new MySqlParameter("?ReservalId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.RegionId;
			parameters[2].Value = model.ContactName;
			parameters[3].Value = model.ContactPhone;
			parameters[4].Value = model.ReservalDate;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.Address;
			parameters[7].Value = model.ContactEmail;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.CreatedUserId;
			parameters[11].Value = model.SupplierId;
			parameters[12].Value = model.ServiceId;
			parameters[13].Value = model.OrderCode;
			parameters[14].Value = model.Remark;
			parameters[15].Value = model.ReservalId;

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
		public bool Delete(int ReservalId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Appt_Reservation ");
			strSql.Append(" where ReservalId=?ReservalId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ReservalId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ReservalId;

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
		public bool DeleteList(string ReservalIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Appt_Reservation ");
			strSql.Append(" where ReservalId in ("+ReservalIdlist + ")  ");
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
		public YSWL.MALL.Model.Appt.Reservation GetModel(int ReservalId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ReservalId,Name,RegionId,ContactName,ContactPhone,ReservalDate,Content,Address,ContactEmail,Status,CreatedDate,CreatedUserId,SupplierId,ServiceId,OrderCode,Remark from Appt_Reservation ");
			strSql.Append(" where ReservalId=?ReservalId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ReservalId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ReservalId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Appt.Reservation model=new YSWL.MALL.Model.Appt.Reservation();
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
		public YSWL.MALL.Model.Appt.Reservation DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Appt.Reservation model=new YSWL.MALL.Model.Appt.Reservation();
			if (row != null)
			{
				if(row["ReservalId"]!=null && row["ReservalId"].ToString()!="")
				{
					model.ReservalId=int.Parse(row["ReservalId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
				}
				if(row["ContactName"]!=null)
				{
					model.ContactName=row["ContactName"].ToString();
				}
				if(row["ContactPhone"]!=null)
				{
					model.ContactPhone=row["ContactPhone"].ToString();
				}
				if(row["ReservalDate"]!=null && row["ReservalDate"].ToString()!="")
				{
					model.ReservalDate=DateTime.Parse(row["ReservalDate"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["ContactEmail"]!=null)
				{
					model.ContactEmail=row["ContactEmail"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["SupplierId"]!=null && row["SupplierId"].ToString()!="")
				{
					model.SupplierId=int.Parse(row["SupplierId"].ToString());
				}
				if(row["ServiceId"]!=null && row["ServiceId"].ToString()!="")
				{
					model.ServiceId=int.Parse(row["ServiceId"].ToString());
				}
				if(row["OrderCode"]!=null)
				{
					model.OrderCode=row["OrderCode"].ToString();
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
			strSql.Append("select ReservalId,Name,RegionId,ContactName,ContactPhone,ReservalDate,Content,Address,ContactEmail,Status,CreatedDate,CreatedUserId,SupplierId,ServiceId,OrderCode,Remark ");
			strSql.Append(" FROM Appt_Reservation ");
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
			
			strSql.Append(" ReservalId,Name,RegionId,ContactName,ContactPhone,ReservalDate,Content,Address,ContactEmail,Status,CreatedDate,CreatedUserId,SupplierId,ServiceId,OrderCode,Remark ");
			strSql.Append(" FROM Appt_Reservation ");
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
			strSql.Append("select count(1) FROM Appt_Reservation ");
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
            strSql.Append("SELECT T.* from Appt_Reservation T ");
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
                strSql.Append(" order by T.ReservalId desc");
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
			parameters[0].Value = "Appt_Reservation";
			parameters[1].Value = "ReservalId";
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

