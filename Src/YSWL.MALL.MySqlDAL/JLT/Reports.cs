/**
* Reports.cs
*
* 功 能： N/A
* 类 名： Reports
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/1/24 15:53:42   N/A    初版
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
    /// 数据访问类:Reports
    /// </summary>
    public partial class Reports : IReports
    {
        public Reports()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "JLT_Reports");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from JLT_Reports");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.JLT.Reports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JLT_Reports(");
            strSql.Append("EnterpriseID,UserId,Title,Content,Type,Status,FileNames,FileDataPath,CreatedDate,ReportDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("?EnterpriseID,?UserId,?Title,?Content,?Type,?Status,?FileNames,?FileDataPath,?CreatedDate,?ReportDate,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?EnterpriseID", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Title", MySqlDbType.VarChar,200),
                    new MySqlParameter("?Content", MySqlDbType.Text),
                    new MySqlParameter("?Type", MySqlDbType.Int16,2),
                    new MySqlParameter("?Status", MySqlDbType.Int16,2),
                    new MySqlParameter("?FileNames", MySqlDbType.VarChar,500),
                    new MySqlParameter("?FileDataPath", MySqlDbType.VarChar,500),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?ReportDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.EnterpriseID;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.FileNames;
            parameters[7].Value = model.FileDataPath;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.ReportDate;
            parameters[10].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.JLT.Reports model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JLT_Reports set ");
            strSql.Append("EnterpriseID=?EnterpriseID,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("Title=?Title,");
            strSql.Append("Content=?Content,");
            strSql.Append("Type=?Type,");
            strSql.Append("Status=?Status,");
            strSql.Append("FileNames=?FileNames,");
            strSql.Append("FileDataPath=?FileDataPath,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("ReportDate=?ReportDate,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?EnterpriseID", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Title", MySqlDbType.VarChar,200),
                    new MySqlParameter("?Content", MySqlDbType.Text),
                    new MySqlParameter("?Type", MySqlDbType.Int16,2),
                    new MySqlParameter("?Status", MySqlDbType.Int16,2),
                    new MySqlParameter("?FileNames", MySqlDbType.VarChar,500),
                    new MySqlParameter("?FileDataPath", MySqlDbType.VarChar,500),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?ReportDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.EnterpriseID;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.FileNames;
            parameters[7].Value = model.FileDataPath;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.ReportDate;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JLT_Reports ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JLT_Reports ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public YSWL.MALL.Model.JLT.Reports GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,EnterpriseID,UserId,Title,Content,Type,Status,FileNames,FileDataPath,CreatedDate,ReportDate,Remark from JLT_Reports ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = ID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.JLT.Reports model = new YSWL.MALL.Model.JLT.Reports();
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
        public YSWL.MALL.Model.JLT.Reports DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.JLT.Reports model = new YSWL.MALL.Model.JLT.Reports();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["EnterpriseID"] != null && row["EnterpriseID"].ToString() != "")
                {
                    model.EnterpriseID = int.Parse(row["EnterpriseID"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Title"] != null)
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Content"] != null)
                {
                    model.Content = row["Content"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["FileNames"] != null)
                {
                    model.FileNames = row["FileNames"].ToString();
                }
                if (row["FileDataPath"] != null)
                {
                    model.FileDataPath = row["FileDataPath"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["ReportDate"] != null && row["ReportDate"].ToString() != "")
                {
                    model.ReportDate = DateTime.Parse(row["ReportDate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select ID,EnterpriseID,UserId,Title,Content,Type,Status,FileNames,FileDataPath,CreatedDate,ReportDate,Remark ");
            strSql.Append(" FROM JLT_Reports ");
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
            
            strSql.Append(" ID,EnterpriseID,UserId,Title,Content,Type,Status,FileNames,FileDataPath,CreatedDate,ReportDate,Remark ");
            strSql.Append(" FROM JLT_Reports ");
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
            strSql.Append("select count(1) FROM JLT_Reports ");
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
            strSql.Append("SELECT T.* from JLT_Reports T ");
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
            parameters[0].Value = "JLT_Reports";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RP.UserId,Content,Type,Status,FileDataPath,CreatedDate,ReportDate,Remark,AU.UserName,FileNames ");
            strSql.Append(" FROM JLT_Reports RP LEFT JOIN Accounts_Users AU ON RP.UserId = AU.UserId");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public bool Update(int id, string fileNames, string fileDataPath)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JLT_Reports set ");
            strSql.Append("FileNames=?FileNames,");
            strSql.Append("FileDataPath=?FileDataPath");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?FileNames", MySqlDbType.VarChar,500),
                    new MySqlParameter("?FileDataPath", MySqlDbType.VarChar,2000),
                    new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = fileNames;
            parameters[1].Value = fileDataPath;
            parameters[2].Value = id;

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
        #endregion  ExtensionMethod
    }
}

