using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
using YSWL.IDAL.CMS;

namespace YSWL.MySQLDAL.Comment
{
    /// <summary>
    /// 数据访问类:Comment
    /// </summary>
    public partial class Comment : IComment
    {
        public Comment()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "CMS_Comment");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_Comment");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.CMS.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Comment(");
            strSql.Append("ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead)");
            strSql.Append(" values (");
            strSql.Append("?ContentId,?Description,?CreatedDate,?CreatedUserID,?ReplyCount,?ParentID,?TypeID,?State,?IsRead)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
					new MySqlParameter("?State", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1)};
            parameters[0].Value = model.ContentId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.ReplyCount;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.IsRead;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Comment set ");
            strSql.Append("ContentId=?ContentId,");
            strSql.Append("Description=?Description,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("ReplyCount=?ReplyCount,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("TypeID=?TypeID,");
            strSql.Append("State=?State,");
            strSql.Append("IsRead=?IsRead");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
					new MySqlParameter("?State", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1),
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ContentId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.ReplyCount;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.IsRead;
            parameters[9].Value = model.ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_Comment ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = ID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_Comment ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            return rows > 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.CMS.Comment GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from CMS_Comment ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = ID;

            Model.Comment.Comment model = new Model.Comment.Comment();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContentId"] != null && ds.Tables[0].Rows[0]["ContentId"].ToString() != "")
                {
                    model.ContentId = int.Parse(ds.Tables[0].Rows[0]["ContentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReplyCount"] != null && ds.Tables[0].Rows[0]["ReplyCount"].ToString() != "")
                {
                    model.ReplyCount = int.Parse(ds.Tables[0].Rows[0]["ReplyCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["State"].ToString() == "1") || (ds.Tables[0].Rows[0]["State"].ToString().ToLower() == "true"))
                    {
                        model.State = true;
                    }
                    else
                    {
                        model.State = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsRead"] != null && ds.Tables[0].Rows[0]["IsRead"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsRead"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsRead"].ToString().ToLower() == "true"))
                    {
                        model.IsRead = true;
                    }
                    else
                    {
                        model.IsRead = false;
                    }
                }
                return model;
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Comment.*,AU.UserName  FROM CMS_Comment Comment");
            strSql.Append(" LEFT JOIN Accounts_Users AU ON Comment.CreatedUserID=AU.UserID ");
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
            strSql.Append(" ID,ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead ");
            strSql.Append(" FROM CMS_Comment ");
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
            parameters[0].Value = "Comment";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        public bool UpdateStates(string strList, bool bResult)
        {
            string str = string.Empty;
            if (!string.IsNullOrWhiteSpace(strList))
            {
                if (bResult)
                {
                    str = "Update CMS_Comment Set State = 1 Where ID in (" + strList + ")";
                }
                else
                {
                    str = "Update CMS_Comment Set State = 0 Where ID in (" + strList + ")";
                }
            }
            int rows = DbHelperMySQL.ExecuteSql(str);
            return rows > 0;
        }

        #endregion Method
    }
}