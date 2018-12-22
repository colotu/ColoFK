using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    public class ErrorLog : YSWL.MALL.IDAL.SysManage.IErrorLog
    {
        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(YSWL.MALL.Model.SysManage.ErrorLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_ErrorLog(");
            strSql.Append("OPTime,Url,Loginfo,StackTrace)");
            strSql.Append(" values (");
            strSql.Append("?OPTime,?Url,?Loginfo,?StackTrace)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OPTime", MySqlDbType.DateTime),
					new MySqlParameter("?Url", MySqlDbType.VarChar,200),
					new MySqlParameter("?Loginfo", MySqlDbType.VarChar),
					new MySqlParameter("?StackTrace", MySqlDbType.VarChar)};
            parameters[0].Value = DateTime.Now.ToString();
            parameters[1].Value = model.Url;
            parameters[2].Value = model.Loginfo;
            parameters[3].Value = model.StackTrace;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// Update a record
        /// </summary>
        public void Update(YSWL.MALL.Model.SysManage.ErrorLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_ErrorLog set ");
            strSql.Append("OPTime=?OPTime,");
            strSql.Append("Url=?Url,");
            strSql.Append("Loginfo=?Loginfo,");
            strSql.Append("StackTrace=?StackTrace");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?OPTime", MySqlDbType.DateTime),
					new MySqlParameter("?Url", MySqlDbType.VarChar,200),
					new MySqlParameter("?Loginfo", MySqlDbType.VarChar),
					new MySqlParameter("?StackTrace", MySqlDbType.VarChar)};
            parameters[0].Value = model.ID;
            parameters[1].Value = DateTime.Now.ToString();
            parameters[2].Value = model.Url;
            parameters[3].Value = model.Loginfo;
            parameters[4].Value = model.StackTrace;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_ErrorLog ");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// Delete record
        /// </summary>
        public void Delete(string IDList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_ErrorLog ");
            strSql.Append(" where ID in ("+IDList+") ");            
            DbHelperMySQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除某一日期之前的数据
        /// </summary>
        /// <param name="dtDateBefore">日期</param>
        public void DeleteByDate(DateTime dtDateBefore)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_ErrorLog ");
            strSql.Append(" where OPTime <= ?OPTime");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OPTime", MySqlDbType.DateTime)
				};
            parameters[0].Value = dtDateBefore;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        public YSWL.MALL.Model.SysManage.ErrorLog GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    ID,OPTime,Url,Loginfo,StackTrace from SA_ErrorLog ");
            strSql.Append(" where ID=?ID LIMIT 1  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            YSWL.MALL.Model.SysManage.ErrorLog model = new YSWL.MALL.Model.SysManage.ErrorLog();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OPTime"].ToString() != "")
                {
                    model.OPTime = DateTime.Parse(ds.Tables[0].Rows[0]["OPTime"].ToString());
                }
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                model.Loginfo = ds.Tables[0].Rows[0]["Loginfo"].ToString();
                model.StackTrace = ds.Tables[0].Rows[0]["StackTrace"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Query data list
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,OPTime,Url,Loginfo,StackTrace ");
            strSql.Append(" FROM SA_ErrorLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// Query top lines of data 
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" ID,OPTime,Url,Loginfo,StackTrace ");
            strSql.Append(" FROM SA_ErrorLog ");
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
        /*
        /// <summary>
        /// Paging data list
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?PageSize",  MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex",  MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SA_ErrorLog";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


    }
}
