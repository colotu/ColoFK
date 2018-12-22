using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Ms;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Ms
{
    /// <summary>
    /// 数据访问类:EmailTemplet
    /// </summary>
    public partial class EmailTemplet : IEmailTemplet
    {
        public EmailTemplet()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("TempletId", "Ms_EmailTemplet");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TempletId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_EmailTemplet");
            strSql.Append(" where TempletId=?TempletId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TempletId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = TempletId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.EmailTemplet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_EmailTemplet(");
            strSql.Append("EmailType,EmailPriority,TagDescription,EmailDescription,EmailSubject,EmailBody)");
            strSql.Append(" values (");
            strSql.Append("?EmailType,?EmailPriority,?TagDescription,?EmailDescription,?EmailSubject,?EmailBody)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?EmailType", MySqlDbType.VarString,100),
					new MySqlParameter("?EmailPriority",  MySqlDbType.Int32,4),
					new MySqlParameter("?TagDescription", MySqlDbType.VarString,500),
					new MySqlParameter("?EmailDescription", MySqlDbType.VarString,500),
					new MySqlParameter("?EmailSubject", MySqlDbType.VarString,1024),
					new MySqlParameter("?EmailBody", MySqlDbType.LongText)};
            parameters[0].Value = model.EmailType;
            parameters[1].Value = model.EmailPriority;
            parameters[2].Value = model.TagDescription;
            parameters[3].Value = model.EmailDescription;
            parameters[4].Value = model.EmailSubject;
            parameters[5].Value = model.EmailBody;

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
        public bool Update(YSWL.MALL.Model.Ms.EmailTemplet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_EmailTemplet set ");
            strSql.Append("EmailType=?EmailType,");
            strSql.Append("EmailPriority=?EmailPriority,");
            strSql.Append("TagDescription=?TagDescription,");
            strSql.Append("EmailDescription=?EmailDescription,");
            strSql.Append("EmailSubject=?EmailSubject,");
            strSql.Append("EmailBody=?EmailBody");
            strSql.Append(" where TempletId=?TempletId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?EmailType", MySqlDbType.VarString,100),
					new MySqlParameter("?EmailPriority",  MySqlDbType.Int32,4),
					new MySqlParameter("?TagDescription", MySqlDbType.VarString,500),
					new MySqlParameter("?EmailDescription", MySqlDbType.VarString,500),
					new MySqlParameter("?EmailSubject", MySqlDbType.VarString,1024),
					new MySqlParameter("?EmailBody", MySqlDbType.LongText),
					new MySqlParameter("?TempletId",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.EmailType;
            parameters[1].Value = model.EmailPriority;
            parameters[2].Value = model.TagDescription;
            parameters[3].Value = model.EmailDescription;
            parameters[4].Value = model.EmailSubject;
            parameters[5].Value = model.EmailBody;
            parameters[6].Value = model.TempletId;

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
        public bool Delete(int TempletId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_EmailTemplet ");
            strSql.Append(" where TempletId=?TempletId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TempletId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = TempletId;

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
        public bool DeleteList(string TempletIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_EmailTemplet ");
            strSql.Append(" where TempletId in (" + TempletIdlist + ")  ");
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
        public YSWL.MALL.Model.Ms.EmailTemplet GetModel(int TempletId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    TempletId,EmailType,EmailPriority,TagDescription,EmailDescription,EmailSubject,EmailBody from Ms_EmailTemplet ");
            strSql.Append(" where TempletId=?TempletId LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TempletId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = TempletId;

            YSWL.MALL.Model.Ms.EmailTemplet model = new YSWL.MALL.Model.Ms.EmailTemplet();
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
        public YSWL.MALL.Model.Ms.EmailTemplet DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Ms.EmailTemplet model = new YSWL.MALL.Model.Ms.EmailTemplet();
            if (row != null)
            {
                if (row["TempletId"] != null && row["TempletId"].ToString() != "")
                {
                    model.TempletId = int.Parse(row["TempletId"].ToString());
                }
                if (row["EmailType"] != null)
                {
                    model.EmailType = row["EmailType"].ToString();
                }
                if (row["EmailPriority"] != null && row["EmailPriority"].ToString() != "")
                {
                    model.EmailPriority = int.Parse(row["EmailPriority"].ToString());
                }
                if (row["TagDescription"] != null)
                {
                    model.TagDescription = row["TagDescription"].ToString();
                }
                if (row["EmailDescription"] != null)
                {
                    model.EmailDescription = row["EmailDescription"].ToString();
                }
                if (row["EmailSubject"] != null)
                {
                    model.EmailSubject = row["EmailSubject"].ToString();
                }
                if (row["EmailBody"] != null)
                {
                    model.EmailBody = row["EmailBody"].ToString();
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
            strSql.Append("select TempletId,EmailType,EmailPriority,TagDescription,EmailDescription,EmailSubject,EmailBody ");
            strSql.Append(" FROM Ms_EmailTemplet ");
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
            strSql.Append(" TempletId,EmailType,EmailPriority,TagDescription,EmailDescription,EmailSubject,EmailBody ");
            strSql.Append(" FROM Ms_EmailTemplet ");
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
            strSql.Append("select count(1) FROM Ms_EmailTemplet ");
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
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append(" order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append(" order by T.TempletId desc");
            //}
            //strSql.Append(")AS Row, T.*  from Ms_EmailTemplet T ");
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT  T.*  from Ms_EmailTemplet T  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.TempletId desc");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
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
                    new MySqlParameter("?PageSize",  MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex",  MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Ms_EmailTemplet";
            parameters[1].Value = "TempletId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion BasicMethod

        #region ExtensionMethod

        #endregion ExtensionMethod
    }
}