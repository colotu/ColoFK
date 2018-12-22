using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.SysManage;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    /// <summary>
    /// 数据访问类:TaskQueue
    /// </summary>
    public partial class TaskQueue : ITaskQueue
    {
        public TaskQueue()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "SA_TaskQueue");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_TaskQueue");
            strSql.Append(" where ID=?ID and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Type",  MySqlDbType.Int32,4)			};
            parameters[0].Value = ID;
            parameters[1].Value = Type;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.SysManage.TaskQueue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_TaskQueue(");
            strSql.Append("ID,Type,TaskId,Status,RunDate)");
            strSql.Append(" values (");
            strSql.Append("?ID,?Type,?TaskId,?Status,?RunDate)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Type",  MySqlDbType.Int32,4),
					new MySqlParameter("?TaskId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?RunDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.TaskId;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.RunDate;

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
        public bool Update(YSWL.MALL.Model.SysManage.TaskQueue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_TaskQueue set ");
            strSql.Append("TaskId=?TaskId,");
            strSql.Append("Status=?Status,");
            strSql.Append("RunDate=?RunDate");
            strSql.Append(" where ID=?ID and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TaskId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?RunDate", MySqlDbType.DateTime),
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Type",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.TaskId;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.RunDate;
            parameters[3].Value = model.ID;
            parameters[4].Value = model.Type;

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
        public bool Delete(int ID, int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_TaskQueue ");
            strSql.Append(" where ID=?ID and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Type",  MySqlDbType.Int32,4)			};
            parameters[0].Value = ID;
            parameters[1].Value = Type;

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
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.SysManage.TaskQueue GetModel(int ID, int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    ID,Type,TaskId,Status,RunDate from SA_TaskQueue ");
            strSql.Append(" where ID=?ID and Type=?Type limit 1  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Type",  MySqlDbType.Int32,4)			};
            parameters[0].Value = ID;
            parameters[1].Value = Type;

            YSWL.MALL.Model.SysManage.TaskQueue model = new YSWL.MALL.Model.SysManage.TaskQueue();
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
        public YSWL.MALL.Model.SysManage.TaskQueue DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.SysManage.TaskQueue model = new YSWL.MALL.Model.SysManage.TaskQueue();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["TaskId"] != null && row["TaskId"].ToString() != "")
                {
                    model.TaskId = int.Parse(row["TaskId"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["RunDate"] != null && row["RunDate"].ToString() != "")
                {
                    model.RunDate = DateTime.Parse(row["RunDate"].ToString());
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
            strSql.Append("select ID,Type,TaskId,Status,RunDate ");
            strSql.Append(" FROM SA_TaskQueue ");
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
            strSql.Append(" ID,Type,TaskId,Status,RunDate ");
            strSql.Append(" FROM SA_TaskQueue ");
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
            strSql.Append("select count(1) FROM SA_TaskQueue ");
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
            strSql.Append("SELECT T.* from SA_TaskQueue T ");
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
                strSql.Append(" order by T.Type desc");
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
                    new MySqlParameter("?PageSize",  MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex",  MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SA_TaskQueue";
            parameters[1].Value = "Type";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion BasicMethod

        #region ExtensionMethod

        public bool DeleteArticle()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_TaskQueue where type=0");
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

        public DataSet GetContinueTask(int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Type,TaskId,Status,RunDate ");
            strSql.Append(" FROM SA_TaskQueue ");
            strSql.Append(" where  type=" + type + "  and Status=0 order by ID");
            return DbHelperMySQL.Query(strSql.ToString());
        }
        public int GetMaxIdByIdType(int Type)
        {
             StringBuilder strSql = new StringBuilder();
             strSql.Append("SELECT ID FROM SA_TaskQueue WHERE Type=" + Type + " ORDER BY  ID DESC LIMIT 1");
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
        public YSWL.MALL.Model.SysManage.TaskQueue GetLastModel(int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ID,Type,TaskId,Status,RunDate from SA_TaskQueue ");
            strSql.Append(" where type=" + type + " and Status=1 order by ID desc LIMIT 1 ");

            YSWL.MALL.Model.SysManage.TaskQueue model = new YSWL.MALL.Model.SysManage.TaskQueue();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
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
        /// 删除指定类型任务列表 0： 表示文章，1：表示商品
        /// </summary>
        /// <returns></returns>
        public bool DeleteTask(int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_TaskQueue where type=?Type");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Type",  MySqlDbType.Int32,4)			};
            parameters[0].Value = Type;
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


        public int ImageCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM SA_TaskQueue WHERE Type=4 AND Status=0");

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
        /// 是否存在该记录
        /// </summary>
        public bool ExistsTask(int taskId, int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_TaskQueue");
            strSql.Append(" where TaskId=?TaskId and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TaskId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Type",  MySqlDbType.Int32,4)			};
            parameters[0].Value = taskId;
            parameters[1].Value = Type;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        #endregion ExtensionMethod
    }
}