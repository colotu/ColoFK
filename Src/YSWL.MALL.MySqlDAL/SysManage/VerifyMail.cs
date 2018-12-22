using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.SysManage;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    /// <summary>
    /// 数据访问类:VerifyMail
    /// </summary>
    public partial class VerifyMail : IVerifyMail
    {
        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KeyValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_VerifyMail");
            strSql.Append(" where KeyValue=?KeyValue ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyValue", MySqlDbType.VarChar,50)			};
            parameters[0].Value = KeyValue;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.SysManage.VerifyMail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_VerifyMail(");
            strSql.Append("UserName,KeyValue,CreatedDate,Status,ValidityType)");
            strSql.Append(" values (");
            strSql.Append("?UserName,?KeyValue,?CreatedDate,?Status,?ValidityType)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarString,50),
					new MySqlParameter("?KeyValue", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?ValidityType",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.KeyValue;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.ValidityType;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.SysManage.VerifyMail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_VerifyMail set ");
            strSql.Append("UserName=?UserName,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Status=?Status,");
            strSql.Append("ValidityType=?ValidityType");
            strSql.Append(" where KeyValue=?KeyValue ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarString,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?ValidityType",  MySqlDbType.Int32,4),
					new MySqlParameter("?KeyValue", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.CreatedDate;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.ValidityType;
            parameters[4].Value = model.KeyValue;

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
        public bool Delete(string KeyValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_VerifyMail ");
            strSql.Append(" where KeyValue=?KeyValue ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyValue", MySqlDbType.VarChar,50)			};
            parameters[0].Value = KeyValue;

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
        public bool DeleteList(string KeyValuelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_VerifyMail ");
            strSql.Append(" where KeyValue in (" + KeyValuelist + ")  ");
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
        public YSWL.MALL.Model.SysManage.VerifyMail GetModel(string KeyValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    UserName,KeyValue,CreatedDate,Status,ValidityType from Accounts_VerifyMail ");
            strSql.Append(" where KeyValue=?KeyValue limit 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyValue", MySqlDbType.VarChar,50)			};
            parameters[0].Value = KeyValue;

            YSWL.MALL.Model.SysManage.VerifyMail model = new YSWL.MALL.Model.SysManage.VerifyMail();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KeyValue"] != null && ds.Tables[0].Rows[0]["KeyValue"].ToString() != "")
                {
                    model.KeyValue = ds.Tables[0].Rows[0]["KeyValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ValidityType"] != null && ds.Tables[0].Rows[0]["ValidityType"].ToString() != "")
                {
                    model.ValidityType = int.Parse(ds.Tables[0].Rows[0]["ValidityType"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName,KeyValue,CreatedDate,Status,ValidityType ");
            strSql.Append(" FROM Accounts_VerifyMail ");
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
            strSql.Append(" UserName,KeyValue,CreatedDate,Status,ValidityType ");
            strSql.Append(" FROM Accounts_VerifyMail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Accounts_VerifyMail ");
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
            strSql.Append("SELECT T.* from Accounts_VerifyMail T ");
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
                strSql.Append(" order by T.KeyValue desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion Method
    }
}