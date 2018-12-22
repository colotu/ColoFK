/**  
* CMBC_LogPay.cs
*
* 功 能： N/A
* 类 名： CMBC_LogPay
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/4 10:34:28   N/A    初版
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
using YSWL.MALL.IDAL.Pay;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Pay
{
	/// <summary>
	/// 数据访问类:CMBC_LogPay
	/// </summary>
	public partial class CMBC_LogPay:ICMBC_LogPay
	{
		public CMBC_LogPay()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(YSWL.MALL.Model.Pay.CMBC_LogPay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Pay_CMBC_LogPay(");
			strSql.Append("MCHNT_CD,TERM_ID,INST_DATE,INST_TIME,VERT_NUM,SEQ_NUM,USER_ID,BILL_PAY_AMT,BILL_PAY_WAY,BILL_NUM,COD_AMT,TRAN_AMT,BACK_NUM,BACK_AMT,ACT_AMT,DIF_AMT,REMARKS,RESERVE,RET_CD)");
			strSql.Append(" values (");
			strSql.Append("?MCHNT_CD,?TERM_ID,?INST_DATE,?INST_TIME,?VERT_NUM,?SEQ_NUM,?USER_ID,?BILL_PAY_AMT,?BILL_PAY_WAY,?BILL_NUM,?COD_AMT,?TRAN_AMT,?BACK_NUM,?BACK_AMT,?ACT_AMT,?DIF_AMT,?REMARKS,?RESERVE,?RET_CD)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MCHNT_CD", MySqlDbType.VarChar,50),
					new MySqlParameter("?TERM_ID", MySqlDbType.VarChar,50),
					new MySqlParameter("?INST_DATE", MySqlDbType.Date,3),
					new MySqlParameter("?INST_TIME", MySqlDbType.DateTime),
					new MySqlParameter("?VERT_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?SEQ_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?USER_ID", MySqlDbType.Int32,4),
					new MySqlParameter("?BILL_PAY_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?BILL_PAY_WAY", MySqlDbType.Int16,2),
					new MySqlParameter("?BILL_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?COD_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?TRAN_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?BACK_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?BACK_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?ACT_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?DIF_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?REMARKS", MySqlDbType.VarChar,50),
					new MySqlParameter("?RESERVE", MySqlDbType.VarChar,50),
					new MySqlParameter("?RET_CD", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.MCHNT_CD;
			parameters[1].Value = model.TERM_ID;
			parameters[2].Value = model.INST_DATE;
			parameters[3].Value = model.INST_TIME;
			parameters[4].Value = model.VERT_NUM;
			parameters[5].Value = model.SEQ_NUM;
			parameters[6].Value = model.USER_ID;
			parameters[7].Value = model.BILL_PAY_AMT;
			parameters[8].Value = model.BILL_PAY_WAY;
			parameters[9].Value = model.BILL_NUM;
			parameters[10].Value = model.COD_AMT;
			parameters[11].Value = model.TRAN_AMT;
			parameters[12].Value = model.BACK_NUM;
			parameters[13].Value = model.BACK_AMT;
			parameters[14].Value = model.ACT_AMT;
			parameters[15].Value = model.DIF_AMT;
			parameters[16].Value = model.REMARKS;
			parameters[17].Value = model.RESERVE;
			parameters[18].Value = model.RET_CD;

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
		public bool Update(YSWL.MALL.Model.Pay.CMBC_LogPay model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Pay_CMBC_LogPay set ");
			strSql.Append("MCHNT_CD=?MCHNT_CD,");
			strSql.Append("TERM_ID=?TERM_ID,");
			strSql.Append("INST_DATE=?INST_DATE,");
			strSql.Append("INST_TIME=?INST_TIME,");
			strSql.Append("VERT_NUM=?VERT_NUM,");
			strSql.Append("SEQ_NUM=?SEQ_NUM,");
			strSql.Append("USER_ID=?USER_ID,");
			strSql.Append("BILL_PAY_AMT=?BILL_PAY_AMT,");
			strSql.Append("BILL_PAY_WAY=?BILL_PAY_WAY,");
			strSql.Append("BILL_NUM=?BILL_NUM,");
			strSql.Append("COD_AMT=?COD_AMT,");
			strSql.Append("TRAN_AMT=?TRAN_AMT,");
			strSql.Append("BACK_NUM=?BACK_NUM,");
			strSql.Append("BACK_AMT=?BACK_AMT,");
			strSql.Append("ACT_AMT=?ACT_AMT,");
			strSql.Append("DIF_AMT=?DIF_AMT,");
			strSql.Append("REMARKS=?REMARKS,");
			strSql.Append("RESERVE=?RESERVE,");
			strSql.Append("RET_CD=?RET_CD");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?MCHNT_CD", MySqlDbType.VarChar,50),
					new MySqlParameter("?TERM_ID", MySqlDbType.VarChar,50),
					new MySqlParameter("?INST_DATE", MySqlDbType.Date,3),
					new MySqlParameter("?INST_TIME", MySqlDbType.DateTime),
					new MySqlParameter("?VERT_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?SEQ_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?USER_ID", MySqlDbType.Int32,4),
					new MySqlParameter("?BILL_PAY_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?BILL_PAY_WAY", MySqlDbType.Int16,2),
					new MySqlParameter("?BILL_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?COD_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?TRAN_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?BACK_NUM", MySqlDbType.VarChar,50),
					new MySqlParameter("?BACK_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?ACT_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?DIF_AMT", MySqlDbType.Decimal,8),
					new MySqlParameter("?REMARKS", MySqlDbType.VarChar,50),
					new MySqlParameter("?RESERVE", MySqlDbType.VarChar,50),
					new MySqlParameter("?RET_CD", MySqlDbType.VarChar,50),
					new MySqlParameter("?ID", MySqlDbType.Int64,8)};
			parameters[0].Value = model.MCHNT_CD;
			parameters[1].Value = model.TERM_ID;
			parameters[2].Value = model.INST_DATE;
			parameters[3].Value = model.INST_TIME;
			parameters[4].Value = model.VERT_NUM;
			parameters[5].Value = model.SEQ_NUM;
			parameters[6].Value = model.USER_ID;
			parameters[7].Value = model.BILL_PAY_AMT;
			parameters[8].Value = model.BILL_PAY_WAY;
			parameters[9].Value = model.BILL_NUM;
			parameters[10].Value = model.COD_AMT;
			parameters[11].Value = model.TRAN_AMT;
			parameters[12].Value = model.BACK_NUM;
			parameters[13].Value = model.BACK_AMT;
			parameters[14].Value = model.ACT_AMT;
			parameters[15].Value = model.DIF_AMT;
			parameters[16].Value = model.REMARKS;
			parameters[17].Value = model.RESERVE;
			parameters[18].Value = model.RET_CD;
			parameters[19].Value = model.ID;

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
		public bool Delete(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Pay_CMBC_LogPay ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int64)
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
			strSql.Append("delete from Pay_CMBC_LogPay ");
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
		public YSWL.MALL.Model.Pay.CMBC_LogPay GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MCHNT_CD,TERM_ID,INST_DATE,INST_TIME,VERT_NUM,SEQ_NUM,USER_ID,BILL_PAY_AMT,BILL_PAY_WAY,BILL_NUM,COD_AMT,TRAN_AMT,BACK_NUM,BACK_AMT,ACT_AMT,DIF_AMT,REMARKS,RESERVE,RET_CD from Pay_CMBC_LogPay ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int64)
			};
			parameters[0].Value = ID;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Pay.CMBC_LogPay model=new YSWL.MALL.Model.Pay.CMBC_LogPay();
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
		public YSWL.MALL.Model.Pay.CMBC_LogPay DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Pay.CMBC_LogPay model=new YSWL.MALL.Model.Pay.CMBC_LogPay();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["MCHNT_CD"]!=null)
				{
					model.MCHNT_CD=row["MCHNT_CD"].ToString();
				}
				if(row["TERM_ID"]!=null)
				{
					model.TERM_ID=row["TERM_ID"].ToString();
				}
				if(row["INST_DATE"]!=null && row["INST_DATE"].ToString()!="")
				{
					model.INST_DATE=DateTime.Parse(row["INST_DATE"].ToString());
				}
				if(row["INST_TIME"]!=null && row["INST_TIME"].ToString()!="")
				{
					model.INST_TIME=DateTime.Parse(row["INST_TIME"].ToString());
				}
				if(row["VERT_NUM"]!=null)
				{
					model.VERT_NUM=row["VERT_NUM"].ToString();
				}
				if(row["SEQ_NUM"]!=null)
				{
					model.SEQ_NUM=row["SEQ_NUM"].ToString();
				}
				if(row["USER_ID"]!=null && row["USER_ID"].ToString()!="")
				{
					model.USER_ID=int.Parse(row["USER_ID"].ToString());
				}
				if(row["BILL_PAY_AMT"]!=null && row["BILL_PAY_AMT"].ToString()!="")
				{
					model.BILL_PAY_AMT=decimal.Parse(row["BILL_PAY_AMT"].ToString());
				}
				if(row["BILL_PAY_WAY"]!=null && row["BILL_PAY_WAY"].ToString()!="")
				{
					model.BILL_PAY_WAY=int.Parse(row["BILL_PAY_WAY"].ToString());
				}
				if(row["BILL_NUM"]!=null)
				{
					model.BILL_NUM=row["BILL_NUM"].ToString();
				}
				if(row["COD_AMT"]!=null && row["COD_AMT"].ToString()!="")
				{
					model.COD_AMT=decimal.Parse(row["COD_AMT"].ToString());
				}
				if(row["TRAN_AMT"]!=null && row["TRAN_AMT"].ToString()!="")
				{
					model.TRAN_AMT=decimal.Parse(row["TRAN_AMT"].ToString());
				}
				if(row["BACK_NUM"]!=null)
				{
					model.BACK_NUM=row["BACK_NUM"].ToString();
				}
				if(row["BACK_AMT"]!=null && row["BACK_AMT"].ToString()!="")
				{
					model.BACK_AMT=decimal.Parse(row["BACK_AMT"].ToString());
				}
				if(row["ACT_AMT"]!=null && row["ACT_AMT"].ToString()!="")
				{
					model.ACT_AMT=decimal.Parse(row["ACT_AMT"].ToString());
				}
				if(row["DIF_AMT"]!=null && row["DIF_AMT"].ToString()!="")
				{
					model.DIF_AMT=decimal.Parse(row["DIF_AMT"].ToString());
				}
				if(row["REMARKS"]!=null)
				{
					model.REMARKS=row["REMARKS"].ToString();
				}
				if(row["RESERVE"]!=null)
				{
					model.RESERVE=row["RESERVE"].ToString();
				}
				if(row["RET_CD"]!=null)
				{
					model.RET_CD=row["RET_CD"].ToString();
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
			strSql.Append("select ID,MCHNT_CD,TERM_ID,INST_DATE,INST_TIME,VERT_NUM,SEQ_NUM,USER_ID,BILL_PAY_AMT,BILL_PAY_WAY,BILL_NUM,COD_AMT,TRAN_AMT,BACK_NUM,BACK_AMT,ACT_AMT,DIF_AMT,REMARKS,RESERVE,RET_CD ");
			strSql.Append(" FROM Pay_CMBC_LogPay ");
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
			
			strSql.Append(" ID,MCHNT_CD,TERM_ID,INST_DATE,INST_TIME,VERT_NUM,SEQ_NUM,USER_ID,BILL_PAY_AMT,BILL_PAY_WAY,BILL_NUM,COD_AMT,TRAN_AMT,BACK_NUM,BACK_AMT,ACT_AMT,DIF_AMT,REMARKS,RESERVE,RET_CD ");
			strSql.Append(" FROM Pay_CMBC_LogPay ");
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
			strSql.Append("select count(1) FROM Pay_CMBC_LogPay ");
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
            strSql.Append("SELECT T.* from Pay_CMBC_LogPay T ");
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
			parameters[0].Value = "Pay_CMBC_LogPay";
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

