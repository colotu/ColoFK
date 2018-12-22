/**
* AttendanceType.cs
*
* 功 能： N/A
* 类 名： AttendanceType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/12/27 22:58:29   N/A    初版
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
    /// 数据访问类:AttendanceType
    /// </summary>
    public partial class AttendanceType : IAttendanceType
    {
        public AttendanceType()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("TypeID", "JLT_AttendanceType");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from JLT_AttendanceType");
            strSql.Append(" where TypeID=?TypeID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = TypeID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.JLT.AttendanceType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JLT_AttendanceType(");
            strSql.Append("TypeName,CreatedDate,Status,Sequence,Remark)");
            strSql.Append(" values (");
            strSql.Append("?TypeName,?CreatedDate,?Status,?Sequence,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.CreatedDate;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.Sequence;
            parameters[4].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.JLT.AttendanceType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JLT_AttendanceType set ");
            strSql.Append("TypeName=?TypeName,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Status=?Status,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where TypeID=?TypeID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.CreatedDate;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.Sequence;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.TypeID;

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
        public bool Delete(int TypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JLT_AttendanceType ");
            strSql.Append(" where TypeID=?TypeID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = TypeID;

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
        public bool DeleteList(string TypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JLT_AttendanceType ");
            strSql.Append(" where TypeID in (" + TypeIDlist + ")  ");
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
        public YSWL.MALL.Model.JLT.AttendanceType GetModel(int TypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  TypeID,TypeName,CreatedDate,Status,Sequence,Remark from JLT_AttendanceType ");
            strSql.Append(" where TypeID=?TypeID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = TypeID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.JLT.AttendanceType model = new YSWL.MALL.Model.JLT.AttendanceType();
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
        public YSWL.MALL.Model.JLT.AttendanceType DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.JLT.AttendanceType model = new YSWL.MALL.Model.JLT.AttendanceType();
            if (row != null)
            {
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Sequence"] != null && row["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(row["Sequence"].ToString());
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
            strSql.Append("select TypeID,TypeName,CreatedDate,Status,Sequence,Remark ");
            strSql.Append(" FROM JLT_AttendanceType ");
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
            
            strSql.Append(" TypeID,TypeName,CreatedDate,Status,Sequence,Remark ");
            strSql.Append(" FROM JLT_AttendanceType ");
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
            strSql.Append("select count(1) FROM JLT_AttendanceType ");
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
            strSql.Append("SELECT T.* from JLT_AttendanceType T ");
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
                strSql.Append(" order by T.TypeID desc");
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
            parameters[0].Value = "JLT_AttendanceType";
            parameters[1].Value = "TypeID";
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
            strSql.Append("update JLT_AttendanceType set " + strWhere);
            strSql.Append(" where TypeID in(" + IDlist + ")  ");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM JLT_AttendanceType ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                strSql.Append(" order by " + orderBy);
            }
            else
            {
                strSql.Append(" order by TypeID desc");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion  ExtensionMethod
    }
}

