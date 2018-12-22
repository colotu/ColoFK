/**
* Inquiry.cs
*
* 功 能： N/A
* 类 名： Inquiry
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/9/4 19:23:28   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Inquiry;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Inquiry
{
	/// <summary>
	/// 数据访问类:Inquiry
	/// </summary>
	public partial class InquiryInfo:IInquiryInfo
	{
		public InquiryInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long InquiryId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_Inquiry");
			strSql.Append(" where InquiryId=?InquiryId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?InquiryId", MySqlDbType.Int64)
			};
			parameters[0].Value = InquiryId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(YSWL.MALL.Model.Shop.Inquiry.InquiryInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_Inquiry(");
			strSql.Append("ParentId,UserId,UserName,Email,CellPhone,Telephone,RegionId,Company,Address,QQ,Status,LeaveMsg,ReplyMsg,MarketPrice,Amount,CreatedDate,UpdatedDate,UpdatedUserId,Remark)");
			strSql.Append(" values (");
			strSql.Append("?ParentId,?UserId,?UserName,?Email,?CellPhone,?Telephone,?RegionId,?Company,?Address,?QQ,?Status,?LeaveMsg,?ReplyMsg,?MarketPrice,?Amount,?CreatedDate,?UpdatedDate,?UpdatedUserId,?Remark)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ParentId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,100),
					new MySqlParameter("?Telephone", MySqlDbType.VarChar,100),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Company", MySqlDbType.VarChar,200),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,100),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?LeaveMsg", MySqlDbType.Text),
					new MySqlParameter("?ReplyMsg", MySqlDbType.Text),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};
			parameters[0].Value = model.ParentId;
			parameters[1].Value = model.UserId;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.CellPhone;
			parameters[5].Value = model.Telephone;
			parameters[6].Value = model.RegionId;
			parameters[7].Value = model.Company;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.QQ;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.LeaveMsg;
			parameters[12].Value = model.ReplyMsg;
			parameters[13].Value = model.MarketPrice;
			parameters[14].Value = model.Amount;
			parameters[15].Value = model.CreatedDate;
			parameters[16].Value = model.UpdatedDate;
			parameters[17].Value = model.UpdatedUserId;
			parameters[18].Value = model.Remark;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.Shop.Inquiry.InquiryInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_Inquiry set ");
			strSql.Append("ParentId=?ParentId,");
			strSql.Append("UserId=?UserId,");
			strSql.Append("UserName=?UserName,");
			strSql.Append("Email=?Email,");
			strSql.Append("CellPhone=?CellPhone,");
			strSql.Append("Telephone=?Telephone,");
			strSql.Append("RegionId=?RegionId,");
			strSql.Append("Company=?Company,");
			strSql.Append("Address=?Address,");
			strSql.Append("QQ=?QQ,");
			strSql.Append("Status=?Status,");
			strSql.Append("LeaveMsg=?LeaveMsg,");
			strSql.Append("ReplyMsg=?ReplyMsg,");
			strSql.Append("MarketPrice=?MarketPrice,");
			strSql.Append("Amount=?Amount,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("UpdatedDate=?UpdatedDate,");
			strSql.Append("UpdatedUserId=?UpdatedUserId,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where InquiryId=?InquiryId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ParentId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
					new MySqlParameter("?CellPhone", MySqlDbType.VarChar,100),
					new MySqlParameter("?Telephone", MySqlDbType.VarChar,100),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Company", MySqlDbType.VarChar,200),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,100),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?LeaveMsg", MySqlDbType.Text),
					new MySqlParameter("?ReplyMsg", MySqlDbType.Text),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500),
					new MySqlParameter("?InquiryId", MySqlDbType.Int64,8)};
			parameters[0].Value = model.ParentId;
			parameters[1].Value = model.UserId;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.CellPhone;
			parameters[5].Value = model.Telephone;
			parameters[6].Value = model.RegionId;
			parameters[7].Value = model.Company;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.QQ;
			parameters[10].Value = model.Status;
			parameters[11].Value = model.LeaveMsg;
			parameters[12].Value = model.ReplyMsg;
			parameters[13].Value = model.MarketPrice;
			parameters[14].Value = model.Amount;
			parameters[15].Value = model.CreatedDate;
			parameters[16].Value = model.UpdatedDate;
			parameters[17].Value = model.UpdatedUserId;
			parameters[18].Value = model.Remark;
			parameters[19].Value = model.InquiryId;

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
		public bool Delete(long InquiryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Inquiry ");
			strSql.Append(" where InquiryId=?InquiryId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?InquiryId", MySqlDbType.Int64)
			};
			parameters[0].Value = InquiryId;

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
		public bool DeleteList(string InquiryIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Inquiry ");
			strSql.Append(" where InquiryId in ("+InquiryIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Inquiry.InquiryInfo GetModel(long InquiryId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  InquiryId,ParentId,UserId,UserName,Email,CellPhone,Telephone,RegionId,Company,Address,QQ,Status,LeaveMsg,ReplyMsg,MarketPrice,Amount,CreatedDate,UpdatedDate,UpdatedUserId,Remark from Shop_Inquiry ");
			strSql.Append(" where InquiryId=?InquiryId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?InquiryId", MySqlDbType.Int64)
			};
			parameters[0].Value = InquiryId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Inquiry.InquiryInfo model=new YSWL.MALL.Model.Shop.Inquiry.InquiryInfo();
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
		public YSWL.MALL.Model.Shop.Inquiry.InquiryInfo DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Inquiry.InquiryInfo model=new YSWL.MALL.Model.Shop.Inquiry.InquiryInfo();
			if (row != null)
			{
				if(row["InquiryId"]!=null && row["InquiryId"].ToString()!="")
				{
					model.InquiryId=long.Parse(row["InquiryId"].ToString());
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=long.Parse(row["ParentId"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["CellPhone"]!=null)
				{
					model.CellPhone=row["CellPhone"].ToString();
				}
				if(row["Telephone"]!=null)
				{
					model.Telephone=row["Telephone"].ToString();
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["LeaveMsg"]!=null)
				{
					model.LeaveMsg=row["LeaveMsg"].ToString();
				}
				if(row["ReplyMsg"]!=null)
				{
					model.ReplyMsg=row["ReplyMsg"].ToString();
				}
				if(row["MarketPrice"]!=null && row["MarketPrice"].ToString()!="")
				{
					model.MarketPrice=decimal.Parse(row["MarketPrice"].ToString());
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["UpdatedDate"]!=null && row["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(row["UpdatedDate"].ToString());
				}
				if(row["UpdatedUserId"]!=null && row["UpdatedUserId"].ToString()!="")
				{
					model.UpdatedUserId=int.Parse(row["UpdatedUserId"].ToString());
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
			strSql.Append("select InquiryId,ParentId,UserId,UserName,Email,CellPhone,Telephone,RegionId,Company,Address,QQ,Status,LeaveMsg,ReplyMsg,MarketPrice,Amount,CreatedDate,UpdatedDate,UpdatedUserId,Remark ");
			strSql.Append(" FROM Shop_Inquiry ");
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
			
			strSql.Append(" InquiryId,ParentId,UserId,UserName,Email,CellPhone,Telephone,RegionId,Company,Address,QQ,Status,LeaveMsg,ReplyMsg,MarketPrice,Amount,CreatedDate,UpdatedDate,UpdatedUserId,Remark ");
			strSql.Append(" FROM Shop_Inquiry ");
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
			strSql.Append("select count(1) FROM Shop_Inquiry ");
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
            strSql.Append("SELECT T.* from Shop_Inquiry T ");
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
                strSql.Append(" order by T.InquiryId desc");
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
			parameters[0].Value = "Shop_Inquiry";
			parameters[1].Value = "InquiryId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

	    public bool DeleteEx(long InquiryId)
	    {
            //事务处理
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Inquiry ");
            strSql.Append(" where InquiryId=?InquiryId");
            MySqlParameter[] parameters = {
						new MySqlParameter("?InquiryId", MySqlDbType.Int64)
			};
            parameters[0].Value = InquiryId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from Shop_InquiryItem ");
            strSql1.Append(" where InquiryId=?InquiryId  ");
            MySqlParameter[] parameters1 = {
							new MySqlParameter("?InquiryId", MySqlDbType.Int64)
                                         };
            parameters1[0].Value = InquiryId;
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd1);

            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;
	    }

	    #endregion  ExtensionMethod
	}
}

