using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:UserBind
    /// </summary>
    public partial class UserBind : IUserBind
    {
        public UserBind()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("BindId", "Accounts_UserBind");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BindId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UserBind");
            strSql.Append(" where BindId=?BindId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BindId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = BindId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.UserBind model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserBind(");
            strSql.Append("UserId,TokenAccess,TokenExpireTime,TokenRefresh,MediaUserID,MediaNickName,MediaID,iHome,Comment,GroupTopic,Status)");
            strSql.Append(" values (");
            strSql.Append("?UserId,?TokenAccess,?TokenExpireTime,?TokenRefresh,?MediaUserID,?MediaNickName,?MediaID,?iHome,?Comment,?GroupTopic,?Status)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?TokenAccess", MySqlDbType.VarChar,200),
					new MySqlParameter("?TokenExpireTime", MySqlDbType.DateTime),
					new MySqlParameter("?TokenRefresh", MySqlDbType.VarChar,200),
					new MySqlParameter("?MediaUserID", MySqlDbType.VarChar,1000),
					new MySqlParameter("?MediaNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?MediaID", MySqlDbType.Int32,4),
					new MySqlParameter("?iHome", MySqlDbType.Bit,1),
					new MySqlParameter("?Comment", MySqlDbType.Bit,1),
					new MySqlParameter("?GroupTopic", MySqlDbType.Bit,1),
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.TokenAccess;
            parameters[2].Value = model.TokenExpireTime;
            parameters[3].Value = model.TokenRefresh;
            parameters[4].Value = model.MediaUserID;
            parameters[5].Value = model.MediaNickName;
            parameters[6].Value = model.MediaID;
            parameters[7].Value = model.iHome;
            parameters[8].Value = model.Comment;
            parameters[9].Value = model.GroupTopic;
            parameters[10].Value = model.Status;

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
        public bool Update(YSWL.MALL.Model.Members.UserBind model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UserBind set ");
            strSql.Append("UserId=?UserId,");
            strSql.Append("TokenAccess=?TokenAccess,");
            strSql.Append("TokenExpireTime=?TokenExpireTime,");
            strSql.Append("TokenRefresh=?TokenRefresh,");
            strSql.Append("MediaUserID=?MediaUserID,");
            strSql.Append("MediaNickName=?MediaNickName,");
            strSql.Append("MediaID=?MediaID,");
            strSql.Append("iHome=?iHome,");
            strSql.Append("Comment=?Comment,");
            strSql.Append("GroupTopic=?GroupTopic,");
            strSql.Append("Status=?Status");
            strSql.Append(" where BindId=?BindId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?TokenAccess", MySqlDbType.VarChar,200),
					new MySqlParameter("?TokenExpireTime", MySqlDbType.DateTime),
					new MySqlParameter("?TokenRefresh", MySqlDbType.VarChar,200),
					new MySqlParameter("?MediaUserID", MySqlDbType.VarChar,1000),
					new MySqlParameter("?MediaNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?MediaID", MySqlDbType.Int32,4),
					new MySqlParameter("?iHome", MySqlDbType.Bit,1),
					new MySqlParameter("?Comment", MySqlDbType.Bit,1),
					new MySqlParameter("?GroupTopic", MySqlDbType.Bit,1),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?BindId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.TokenAccess;
            parameters[2].Value = model.TokenExpireTime;
            parameters[3].Value = model.TokenRefresh;
            parameters[4].Value = model.MediaUserID;
            parameters[5].Value = model.MediaNickName;
            parameters[6].Value = model.MediaID;
            parameters[7].Value = model.iHome;
            parameters[8].Value = model.Comment;
            parameters[9].Value = model.GroupTopic;
            parameters[10].Value = model.Status;
            parameters[11].Value = model.BindId;

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
        public bool Delete(int BindId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UserBind ");
            strSql.Append(" where BindId=?BindId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BindId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = BindId;

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
        public bool DeleteList(string BindIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UserBind ");
            strSql.Append(" where BindId in (" + BindIdlist + ")  ");
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
        public YSWL.MALL.Model.Members.UserBind GetModel(int BindId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BindId,UserId,TokenAccess,TokenExpireTime,TokenRefresh,MediaUserID,MediaNickName,MediaID,iHome,Comment,GroupTopic,Status from Accounts_UserBind ");
            strSql.Append(" where BindId=?BindId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BindId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = BindId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.UserBind model = new YSWL.MALL.Model.Members.UserBind();
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
        public YSWL.MALL.Model.Members.UserBind DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.UserBind model = new YSWL.MALL.Model.Members.UserBind();
            if (row != null)
            {
                if (row["BindId"] != null && row["BindId"].ToString() != "")
                {
                    model.BindId = int.Parse(row["BindId"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["TokenAccess"] != null)
                {
                    model.TokenAccess = row["TokenAccess"].ToString();
                }
                if (row["TokenExpireTime"] != null && row["TokenExpireTime"].ToString() != "")
                {
                    model.TokenExpireTime = DateTime.Parse(row["TokenExpireTime"].ToString());
                }
                if (row["TokenRefresh"] != null)
                {
                    model.TokenRefresh = row["TokenRefresh"].ToString();
                }
                if (row["MediaUserID"] != null)
                {
                    model.MediaUserID = row["MediaUserID"].ToString();
                }
                if (row["MediaNickName"] != null)
                {
                    model.MediaNickName = row["MediaNickName"].ToString();
                }
                if (row["MediaID"] != null && row["MediaID"].ToString() != "")
                {
                    model.MediaID = int.Parse(row["MediaID"].ToString());
                }
                if (row["iHome"] != null && row["iHome"].ToString() != "")
                {
                    if ((row["iHome"].ToString() == "1") || (row["iHome"].ToString().ToLower() == "true"))
                    {
                        model.iHome = true;
                    }
                    else
                    {
                        model.iHome = false;
                    }
                }
                if (row["Comment"] != null && row["Comment"].ToString() != "")
                {
                    if ((row["Comment"].ToString() == "1") || (row["Comment"].ToString().ToLower() == "true"))
                    {
                        model.Comment = true;
                    }
                    else
                    {
                        model.Comment = false;
                    }
                }
                if (row["GroupTopic"] != null && row["GroupTopic"].ToString() != "")
                {
                    if ((row["GroupTopic"].ToString() == "1") || (row["GroupTopic"].ToString().ToLower() == "true"))
                    {
                        model.GroupTopic = true;
                    }
                    else
                    {
                        model.GroupTopic = false;
                    }
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
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
            strSql.Append("select BindId,UserId,TokenAccess,TokenExpireTime,TokenRefresh,MediaUserID,MediaNickName,MediaID,iHome,Comment,GroupTopic,Status ");
            strSql.Append(" FROM Accounts_UserBind ");
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
            
            strSql.Append(" BindId,UserId,TokenAccess,TokenExpireTime,TokenRefresh,MediaUserID,MediaNickName,MediaID,iHome,Comment,GroupTopic,Status ");
            strSql.Append(" FROM Accounts_UserBind ");
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
            strSql.Append("select count(1) FROM Accounts_UserBind ");
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
            strSql.Append("SELECT T.* from Accounts_UserBind T ");
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
                strSql.Append(" order by T.BindId desc");
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
            parameters[0].Value = "Accounts_UserBind";
            parameters[1].Value = "BindId";
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
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Members.UserBind GetModel(int userId, int MediaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_UserBind ");
            strSql.Append(" where userId=?UserId and MediaID=?MediaID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?MediaID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = userId;
            parameters[1].Value = MediaID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.UserBind model = new YSWL.MALL.Model.Members.UserBind();
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


        public bool Exists(int userId, string MediaUserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UserBind");
            strSql.Append(" where userId=?UserId and MediaUserID=?MediaUserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?MediaUserID", MySqlDbType.VarChar,1000)
			};
            parameters[0].Value = userId;
            parameters[1].Value = MediaUserID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(YSWL.MALL.Model.Members.UserBind model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UserBind set ");
            strSql.Append("TokenAccess=?TokenAccess,");
            strSql.Append("TokenExpireTime=?TokenExpireTime,");
            strSql.Append("TokenRefresh=?TokenRefresh,");
            strSql.Append("MediaNickName=?MediaNickName,");
            strSql.Append("MediaID=?MediaID,");
            strSql.Append("iHome=?iHome,");
            strSql.Append("Comment=?Comment,");
            strSql.Append("GroupTopic=?GroupTopic,");
            strSql.Append("Status=?Status");
            strSql.Append(" where UserId=?UserId and MediaUserID=?MediaUserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?TokenAccess", MySqlDbType.VarChar,200),
					new MySqlParameter("?TokenExpireTime", MySqlDbType.DateTime),
					new MySqlParameter("?TokenRefresh", MySqlDbType.VarChar,200),
					new MySqlParameter("?MediaUserID", MySqlDbType.VarChar,1000),
					new MySqlParameter("?MediaNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?MediaID", MySqlDbType.Int32,4),
					new MySqlParameter("?iHome", MySqlDbType.Bit,1),
					new MySqlParameter("?Comment", MySqlDbType.Bit,1),
					new MySqlParameter("?GroupTopic", MySqlDbType.Bit,1),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?BindId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.TokenAccess;
            parameters[2].Value = model.TokenExpireTime;
            parameters[3].Value = model.TokenRefresh;
            parameters[4].Value = model.MediaUserID;
            parameters[5].Value = model.MediaNickName;
            parameters[6].Value = model.MediaID;
            parameters[7].Value = model.iHome;
            parameters[8].Value = model.Comment;
            parameters[9].Value = model.GroupTopic;
            parameters[10].Value = model.Status;
            parameters[11].Value = model.BindId;

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
