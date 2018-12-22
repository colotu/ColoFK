using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:FeedbackType
    /// </summary>
    public partial class FeedbackType : IFeedbackType
    {
        public FeedbackType()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("TypeId", "SA_FeedbackType");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_FeedbackType");
            strSql.Append(" where TypeId=?TypeId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = TypeId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.FeedbackType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_FeedbackType(");
            strSql.Append("TypeName,Description)");
            strSql.Append(" values (");
            strSql.Append("?TypeName,?Description)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarString,200),
					new MySqlParameter("?Description",  MySqlDbType.Text)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.Description;

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
        public bool Update(YSWL.MALL.Model.Members.FeedbackType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_FeedbackType set ");
            strSql.Append("TypeName=?TypeName,");
            strSql.Append("Description=?Description");
            strSql.Append(" where TypeId=?TypeId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarString,200),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?TypeId",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.TypeId;

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
        public bool Delete(int TypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_FeedbackType ");
            strSql.Append(" where TypeId=?TypeId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = TypeId;

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
        public bool DeleteList(string TypeIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_FeedbackType ");
            strSql.Append(" where TypeId in (" + TypeIdlist + ")  ");
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
        public YSWL.MALL.Model.Members.FeedbackType GetModel(int TypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  TypeId,TypeName,Description from SA_FeedbackType ");
            strSql.Append(" where TypeId=?TypeId LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = TypeId;

            YSWL.MALL.Model.Members.FeedbackType model = new YSWL.MALL.Model.Members.FeedbackType();
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
        public YSWL.MALL.Model.Members.FeedbackType DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.FeedbackType model = new YSWL.MALL.Model.Members.FeedbackType();
            if (row != null)
            {
                if (row["TypeId"] != null && row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
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
            strSql.Append("select TypeId,TypeName,Description ");
            strSql.Append(" FROM SA_FeedbackType ");
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
            strSql.Append(" TypeId,TypeName,Description ");
            strSql.Append(" FROM SA_FeedbackType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT  " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SA_FeedbackType ");
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
            //    strSql.Append(" order by T.TypeId desc");
            //}
            //strSql.Append(")AS Row, T.*  from SA_FeedbackType T ");
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*  from SA_FeedbackType T ");
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
                strSql.Append(" order by T.TypeId desc");
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
            parameters[0].Value = "SA_FeedbackType";
            parameters[1].Value = "TypeId";
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