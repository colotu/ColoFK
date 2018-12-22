using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    public class TreeFavorite : YSWL.MALL.IDAL.SysManage.ITreeFavorite
    {
        public TreeFavorite()
        { }

        #region Method

        /// <summary>
        /// Whether there is Exists
        /// </summary>
        public bool Exists(int UserID, int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_TreeFavorite");
            strSql.Append(" where UserID=?UserID and  NodeID=?NodeID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?NodeID",  MySqlDbType.Int32,4)
					};
            parameters[0].Value = UserID;
            parameters[1].Value = NodeID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(int UserID, int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_TreeFavorite(");
            strSql.Append("UserID,NodeID,CreatDate)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?NodeID,?CreatDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?NodeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatDate", MySqlDbType.DateTime)};
            parameters[0].Value = UserID;
            parameters[1].Value = NodeID;
            parameters[2].Value = DateTime.Now;

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

        ///<summary>
        /// 更新一个OrderID
        /// </summary>
        public void UpDate(int OrderID, int UserID, int NodeID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("UPDATE SA_TreeFavorite SET OrderID = ?OrderID where UserID =?UserID and NodeID=?NodeID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?NodeID",MySqlDbType.Int32,4)};
            parameters[0].Value = OrderID;
            parameters[1].Value = UserID;
            parameters[2].Value = NodeID;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_TreeFavorite ");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DeleteByUser(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_TreeFavorite ");
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4)
					};
            parameters[0].Value = UserID;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public void Delete(int UserID, int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_TreeFavorite ");
            strSql.Append(" where UserID=?UserID and  NodeID=?NodeID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?NodeID",  MySqlDbType.Int32,4)
					};
            parameters[0].Value = UserID;
            parameters[1].Value = NodeID;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Query data list
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserID,NodeID,CreatDate ");
            strSql.Append(" FROM SA_TreeFavorite ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetNodeIDsByUser(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NodeID ");
            strSql.Append(" FROM SA_TreeFavorite ");
            if (UserID > 0)
            {
                strSql.Append(" where UserID=" + UserID);
            }

            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetMenuListByUser(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SA_TreeFavorite.*,SA_Tree.TreeText,SA_Tree.Url from SA_TreeFavorite  ");
            strSql.Append(" left join SA_Tree on SA_TreeFavorite.NodeID=SA_Tree.NodeID ");
            if (UserID > 0)
            {
                strSql.Append(" where UserID=" + UserID);
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
            strSql.Append(" ID,UserID,NodeID,CreatDate ");
            strSql.Append(" FROM SA_TreeFavorite ");
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

        #endregion Method
    }
}