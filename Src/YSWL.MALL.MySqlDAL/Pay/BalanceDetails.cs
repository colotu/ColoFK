/**  版本信息模板在安装目录下，可自行修改。
* BalanceDetails.cs
*
* 功 能： N/A
* 类 名： BalanceDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/9/3 14:45:12   N/A    初版
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
    /// 数据访问类:BalanceDetails
    /// </summary>
    public partial class BalanceDetails:IBalanceDetails
    {
        public BalanceDetails()
        {}
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long JournalNumber)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from Pay_BalanceDetails");
            strSql.Append(" where JournalNumber=?JournalNumber");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?JournalNumber", MySqlDbType.Int64)
            };
            parameters[0].Value = JournalNumber;

            return DbHelperMySQL.Exists(strSql.ToString(),parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Pay.BalanceDetails model)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Pay_BalanceDetails(");
            strSql.Append("UserId,TradeDate,TradeType,Income,Expenses,Balance,Payer,Payee,Remark)");
            strSql.Append(" values (");
            strSql.Append("?UserId,?TradeDate,?TradeType,?Income,?Expenses,?Balance,?Payer,?Payee,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                    new MySqlParameter("?TradeType", MySqlDbType.Int32,4),
                    new MySqlParameter("?Income", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Expenses", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Payer", MySqlDbType.Int32,4),
                    new MySqlParameter("?Payee", MySqlDbType.Int32,4),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,2000)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.TradeDate;
            parameters[2].Value = model.TradeType;
            parameters[3].Value = model.Income;
            parameters[4].Value = model.Expenses;
            parameters[5].Value = model.Balance;
            parameters[6].Value = model.Payer;
            parameters[7].Value = model.Payee;
            parameters[8].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.Pay.BalanceDetails model)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("update Pay_BalanceDetails set ");
            strSql.Append("UserId=?UserId,");
            strSql.Append("TradeDate=?TradeDate,");
            strSql.Append("TradeType=?TradeType,");
            strSql.Append("Income=?Income,");
            strSql.Append("Expenses=?Expenses,");
            strSql.Append("Balance=?Balance,");
            strSql.Append("Payer=?Payer,");
            strSql.Append("Payee=?Payee,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where JournalNumber=?JournalNumber");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                    new MySqlParameter("?TradeType", MySqlDbType.Int32,4),
                    new MySqlParameter("?Income", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Expenses", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Payer", MySqlDbType.Int32,4),
                    new MySqlParameter("?Payee", MySqlDbType.Int32,4),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,2000),
                    new MySqlParameter("?JournalNumber", MySqlDbType.Int64,8)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.TradeDate;
            parameters[2].Value = model.TradeType;
            parameters[3].Value = model.Income;
            parameters[4].Value = model.Expenses;
            parameters[5].Value = model.Balance;
            parameters[6].Value = model.Payer;
            parameters[7].Value = model.Payee;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.JournalNumber;

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
        public bool Delete(long JournalNumber)
        {
            
            StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Pay_BalanceDetails ");
            strSql.Append(" where JournalNumber=?JournalNumber");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?JournalNumber", MySqlDbType.Int64)
            };
            parameters[0].Value = JournalNumber;

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
        public bool DeleteList(string JournalNumberlist )
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Pay_BalanceDetails ");
            strSql.Append(" where JournalNumber in ("+JournalNumberlist + ")  ");
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
        public YSWL.MALL.Model.Pay.BalanceDetails GetModel(long JournalNumber)
        {
            
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select  JournalNumber,UserId,TradeDate,TradeType,Income,Expenses,Balance,Payer,Payee,Remark from Pay_BalanceDetails ");
            strSql.Append(" where JournalNumber=?JournalNumber");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?JournalNumber", MySqlDbType.Int64)
            };
            parameters[0].Value = JournalNumber;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Pay.BalanceDetails model=new YSWL.MALL.Model.Pay.BalanceDetails();
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
        public YSWL.MALL.Model.Pay.BalanceDetails DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Pay.BalanceDetails model=new YSWL.MALL.Model.Pay.BalanceDetails();
            if (row != null)
            {
                if(row["JournalNumber"]!=null && row["JournalNumber"].ToString()!="")
                {
                    model.JournalNumber=long.Parse(row["JournalNumber"].ToString());
                }
                if(row["UserId"]!=null && row["UserId"].ToString()!="")
                {
                    model.UserId=int.Parse(row["UserId"].ToString());
                }
                if(row["TradeDate"]!=null && row["TradeDate"].ToString()!="")
                {
                    model.TradeDate=DateTime.Parse(row["TradeDate"].ToString());
                }
                if(row["TradeType"]!=null && row["TradeType"].ToString()!="")
                {
                    model.TradeType=int.Parse(row["TradeType"].ToString());
                }
                if(row["Income"]!=null && row["Income"].ToString()!="")
                {
                    model.Income=decimal.Parse(row["Income"].ToString());
                }
                if(row["Expenses"]!=null && row["Expenses"].ToString()!="")
                {
                    model.Expenses=decimal.Parse(row["Expenses"].ToString());
                }
                if(row["Balance"]!=null && row["Balance"].ToString()!="")
                {
                    model.Balance=decimal.Parse(row["Balance"].ToString());
                }
                if(row["Payer"]!=null && row["Payer"].ToString()!="")
                {
                    model.Payer=int.Parse(row["Payer"].ToString());
                }
                if(row["Payee"]!=null && row["Payee"].ToString()!="")
                {
                    model.Payee=int.Parse(row["Payee"].ToString());
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
            strSql.Append("select JournalNumber,UserId,TradeDate,TradeType,Income,Expenses,Balance,Payer,Payee,Remark ");
            strSql.Append(" FROM Pay_BalanceDetails ");
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
            
            strSql.Append(" JournalNumber,UserId,TradeDate,TradeType,Income,Expenses,Balance,Payer,Payee,Remark ");
            strSql.Append(" FROM Pay_BalanceDetails ");
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
            strSql.Append("select count(1) FROM Pay_BalanceDetails ");
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
            strSql.Append("SELECT T.* from Pay_BalanceDetails T ");
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
                strSql.Append(" order by T.JournalNumber desc");
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
            parameters[0].Value = "Pay_BalanceDetails";
            parameters[1].Value = "JournalNumber";
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
        /// 余额支付
        /// </summary>
        /// <param name="amount">支付金额</param>
        /// <param name="userId">支付用户</param>
        /// <param name="remark">日志信息</param>
        public bool Pay(decimal amount, int userId, string remark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
UPDATE  Accounts_UsersExp
SET     Balance = Balance - ?Amount
WHERE   UserID = ?UserId
;
INSERT  Pay_BalanceDetails
        ( UserId
        , TradeDate
        , TradeType
        , Income
        , Expenses
        , Balance
        , Payer
        , Payee
        , Remark
        )
VALUES  ( ?UserId        , -- UserId - int
          now()      , -- TradeDate - datetime
          2              , -- TradeType - int
          NULL           , -- Income - money
          ?Amount        , -- Expenses - money
          ( SELECT  Balance
            FROM    Accounts_UsersExp
            WHERE   UserID = ?UserId
          )              , -- Balance - money
          ?UserId        , -- Payer - int
          NULL             , -- Payee - int
          ?Remark          -- Remark - nvarchar(2000)
        )
");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Amount", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,2000)};
            parameters[0].Value = userId;
            parameters[1].Value = amount;
            parameters[2].Value = remark;

            return (DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters) > 0);
        }
        #endregion  ExtensionMethod
    }
}

