﻿/**  版本信息模板在安装目录下，可自行修改。
* RechargeRequest.cs
*
* 功 能： N/A
* 类 名： RechargeRequest
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
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Pay;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Pay
{
    /// <summary>
    /// 数据访问类:RechargeRequest
    /// </summary>
    public partial class RechargeRequest : IRechargeRequest
    {
        public RechargeRequest()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Pay.RechargeRequest model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pay_RechargeRequest(");
            strSql.Append("TradeDate,RechargeBlance,UserId,SellerId,Status,Tradetype,PaymentTypeId,PaymentGateway)");
            strSql.Append(" values (");
            strSql.Append("?TradeDate,?RechargeBlance,?UserId,?SellerId,?Status,?Tradetype,?PaymentTypeId,?PaymentGateway)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                    new MySqlParameter("?RechargeBlance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?SellerId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?Tradetype", MySqlDbType.Int32,4),
                    new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?PaymentGateway", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.TradeDate;
            parameters[1].Value = model.RechargeBlance;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.SellerId;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Tradetype;
            parameters[6].Value = model.PaymentTypeId;
            parameters[7].Value = model.PaymentGateway;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(YSWL.MALL.Model.Pay.RechargeRequest model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pay_RechargeRequest set ");
            strSql.Append("TradeDate=?TradeDate,");
            strSql.Append("RechargeBlance=?RechargeBlance,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("SellerId=?SellerId,");
            strSql.Append("Status=?Status,");
            strSql.Append("Tradetype=?Tradetype,");
            strSql.Append("PaymentTypeId=?PaymentTypeId,");
            strSql.Append("PaymentGateway=?PaymentGateway");
            strSql.Append(" where RechargeId=?RechargeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                    new MySqlParameter("?RechargeBlance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?SellerId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?Tradetype", MySqlDbType.Int32,4),
                    new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?PaymentGateway", MySqlDbType.VarChar,50),
                    new MySqlParameter("?RechargeId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.TradeDate;
            parameters[1].Value = model.RechargeBlance;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.SellerId;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Tradetype;
            parameters[6].Value = model.PaymentTypeId;
            parameters[7].Value = model.PaymentGateway;
            parameters[8].Value = model.RechargeId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(long RechargeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pay_RechargeRequest ");
            strSql.Append(" where RechargeId=?RechargeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?RechargeId", MySqlDbType.Int64)
            };
            parameters[0].Value = RechargeId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string RechargeIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pay_RechargeRequest ");
            strSql.Append(" where RechargeId in (" + RechargeIdlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Pay.RechargeRequest GetModel(long RechargeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  RechargeId,TradeDate,RechargeBlance,UserId,SellerId,Status,Tradetype,PaymentTypeId,PaymentGateway from Pay_RechargeRequest ");
            strSql.Append(" where RechargeId=?RechargeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?RechargeId", MySqlDbType.Int64)
            };
            parameters[0].Value = RechargeId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Pay.RechargeRequest model = new YSWL.MALL.Model.Pay.RechargeRequest();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public YSWL.MALL.Model.Pay.RechargeRequest DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Pay.RechargeRequest model = new YSWL.MALL.Model.Pay.RechargeRequest();
            if (row != null)
            {
                if (row["RechargeId"] != null && row["RechargeId"].ToString() != "")
                {
                    model.RechargeId = long.Parse(row["RechargeId"].ToString());
                }
                if (row["TradeDate"] != null && row["TradeDate"].ToString() != "")
                {
                    model.TradeDate = DateTime.Parse(row["TradeDate"].ToString());
                }
                if (row["RechargeBlance"] != null && row["RechargeBlance"].ToString() != "")
                {
                    model.RechargeBlance = decimal.Parse(row["RechargeBlance"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["SellerId"] != null && row["SellerId"].ToString() != "")
                {
                    model.SellerId = int.Parse(row["SellerId"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Tradetype"] != null && row["Tradetype"].ToString() != "")
                {
                    model.Tradetype = int.Parse(row["Tradetype"].ToString());
                }
                if (row["PaymentTypeId"] != null && row["PaymentTypeId"].ToString() != "")
                {
                    model.PaymentTypeId = int.Parse(row["PaymentTypeId"].ToString());
                }
                if (row["PaymentGateway"] != null)
                {
                    model.PaymentGateway = row["PaymentGateway"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RechargeId,TradeDate,RechargeBlance,UserId,SellerId,Status,Tradetype,PaymentTypeId,PaymentGateway ");
            strSql.Append(" FROM Pay_RechargeRequest ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(" RechargeId,TradeDate,RechargeBlance,UserId,SellerId,Status,Tradetype,PaymentTypeId,PaymentGateway ");
            strSql.Append(" FROM Pay_RechargeRequest ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Pay_RechargeRequest ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append("SELECT T.* from Pay_RechargeRequest T ");
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
                strSql.Append(" order by T.RechargeId desc");
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
            parameters[0].Value = "Pay_RechargeRequest";
            parameters[1].Value = "RechargeId";
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
        /// 更新状态
        /// </summary>
        /// <param name="model"></param>
        /// <param name="currbalance">当前余额</param>
        /// <param name="rechargeMoney">充值后得到的金额</param>
        /// <returns></returns>
        public bool UpdateStatus(Model.Pay.RechargeRequest model, decimal currbalance, decimal rechargeMoney)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pay_RechargeRequest set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where RechargeId=?RechargeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                                        new MySqlParameter("?RechargeId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.Status;
            parameters[1].Value = model.RechargeId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //更新用户表中的余额
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" update Accounts_UsersExp set ");
            strSql2.Append(" Balance=Balance+ ?Balance where UserID=?UserId");
            MySqlParameter[] parameters2 = {
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                   new MySqlParameter("?UserId", MySqlDbType.Int32,4)
                                        };
            parameters2[0].Value = rechargeMoney;//充值金额
            parameters2[1].Value = model.UserId;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into Pay_BalanceDetails(");
            strSql3.Append("UserId,TradeDate,TradeType,Income,Balance,Remark)");
            strSql3.Append(" values (");
            strSql3.Append("?UserId,?TradeDate,?TradeType,?Income,?Balance,?Remark)");
            strSql3.Append(";select last_insert_id()");
            MySqlParameter[] parameters3 = {
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                    new MySqlParameter("?TradeType", MySqlDbType.Int32,4),
                    new MySqlParameter("?Income", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,2000)
                 };
            parameters3[0].Value = model.UserId;
            parameters3[1].Value = DateTime.Now;
            parameters3[2].Value = 1;
            parameters3[3].Value = rechargeMoney;//收入
            parameters3[4].Value = currbalance + rechargeMoney;//余额
            parameters3[5].Value = "充值操作"; //备注


            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            int rows = DbHelperMySQL.ExecuteSqlTran(sqllist);
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
        /// 线下充值
        /// </summary>
        /// <param name="currbalance">当前余额</param>
        /// <param name="rechargeMoney">充值后得到的金额</param>
        public bool OfflineRecharge(int userId, decimal currbalance, decimal rechargeMoney,decimal payMoney ,string msg = "线下充值")
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pay_RechargeRequest(");
            strSql.Append("TradeDate,RechargeBlance,UserId,SellerId,Status,Tradetype,PaymentTypeId,PaymentGateway)");
            strSql.Append(" values (");
            strSql.Append("?TradeDate,?RechargeBlance,?UserId,?SellerId,?Status,?Tradetype,?PaymentTypeId,?PaymentGateway)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                    new MySqlParameter("?RechargeBlance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?SellerId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?Tradetype", MySqlDbType.Int32,4),
                    new MySqlParameter("?PaymentTypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?PaymentGateway", MySqlDbType.VarChar,50)};
            parameters[0].Value = DateTime.Now;
            parameters[1].Value = payMoney;
            parameters[2].Value = userId;
            parameters[3].Value = null;
            parameters[4].Value = 1;//状态
            parameters[5].Value = 2;//类型
            parameters[6].Value = -1;
            parameters[7].Value = "advanceaccount";//支付网关  赋值为预付款账户(余额支付)
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //更新用户表中的余额
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(" update Accounts_UsersExp set ");
            strSql2.Append(" Balance=Balance+ ?Balance where UserID=?UserId");
            MySqlParameter[] parameters2 = {
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                   new MySqlParameter("?UserId", MySqlDbType.Int32,4)
                                        };
            parameters2[0].Value = rechargeMoney;//充值金额
            parameters2[1].Value = userId;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into Pay_BalanceDetails(");
            strSql3.Append("UserId,TradeDate,TradeType,Income,Balance,Remark)");
            strSql3.Append(" values (");
            strSql3.Append("?UserId,?TradeDate,?TradeType,?Income,?Balance,?Remark)");
            strSql3.Append(";select last_insert_id()");
            MySqlParameter[] parameters3 = {
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TradeDate", MySqlDbType.DateTime),
                    new MySqlParameter("?TradeType", MySqlDbType.Int32,4),
                    new MySqlParameter("?Income", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,2000)
                 };
            parameters3[0].Value = userId;
            parameters3[1].Value = DateTime.Now;
            parameters3[2].Value = 1;
            parameters3[3].Value = rechargeMoney;//收入
            parameters3[4].Value = currbalance + rechargeMoney;//余额
            parameters3[5].Value = msg; //备注

            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0;
        }

        /// <summary>
        /// 获得数据列表 与users表内联 与支付类型表内联
        /// </summary>
        public DataSet GetListEx(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  rech.*,users.UserName,pay.Name ");
            strSql.Append(" FROM  Pay_RechargeRequest AS rech ");
            strSql.Append(" INNER JOIN  Accounts_Users AS users ");
            strSql.Append(" ON rech.UserID= users.UserID  ");
            strSql.Append("  INNER JOIN Pay_PaymentTypes AS pay ON  rech.PaymentTypeId=pay.ModeId");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperMySQL.Query(strSql.ToString());
        }


        public int GetTotalcount(string startTime, string endTime)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select count(*) from Pay_RechargeRequest where  ");
            stringBuilder.Append("convert(date,TradeDate)>='" + Common.InjectionFilter.SqlFilter(startTime) + "'");
            stringBuilder.Append(" and convert(date,TradeDate)<='" + Common.InjectionFilter.SqlFilter(endTime) + "'");
            object returnValue = DbHelperMySQL.GetSingle(stringBuilder.ToString());
            if (returnValue == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(returnValue);
            }
        }

        public int GetTotalAmount(string startTime, string endTime)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select sum(RechargeBlance) from Pay_RechargeRequest where  ");
            stringBuilder.Append("convert(date,TradeDate)>='" + Common.InjectionFilter.SqlFilter(startTime) + "'");
            stringBuilder.Append(" and convert(date,TradeDate)<='" + Common.InjectionFilter.SqlFilter(endTime) + "'");
            object returnValue = DbHelperMySQL.GetSingle(stringBuilder.ToString());
            if (returnValue == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(returnValue);
            }
        }
        #endregion  ExtensionMethod
    }
}

