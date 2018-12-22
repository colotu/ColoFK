using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:Guestbook
    /// </summary>
    public partial class Guestbook : IGuestbook
    {
        public Guestbook()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "SA_Guestbook");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_Guestbook");
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
        public int Add(YSWL.MALL.Model.Members.Guestbook model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Guestbook(");
            strSql.Append("CreateUserID,CreateNickName,ToUserID,ToNickName,CreatorUserIP,Title,Description,CreatedDate,CreatorEmail,CreatorRegion,CreatorCompany,CreatorPageSite,CreatorPhone,CreatorQQ,CreatorMsn,CreatorSex,HandlerNickName,HandlerUserID,HandlerDate,Privacy,ReplyCount,ReplyDescription,ParentID,Status)");
            strSql.Append(" values (");
            strSql.Append("?CreateUserID,?CreateNickName,?ToUserID,?ToNickName,?CreatorUserIP,?Title,?Description,?CreatedDate,?CreatorEmail,?CreatorRegion,?CreatorCompany,?CreatorPageSite,?CreatorPhone,?CreatorQQ,?CreatorMsn,?CreatorSex,?HandlerNickName,?HandlerUserID,?HandlerDate,?Privacy,?ReplyCount,?ReplyDescription,?ParentID,?Status)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CreateUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreateNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ToUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ToNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorUserIP", MySqlDbType.VarChar,20),
					new MySqlParameter("?Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatorEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorRegion", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorCompany", MySqlDbType.VarChar,100),
					new MySqlParameter("?CreatorPageSite", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreatorPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?CreatorQQ", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorMsn", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorSex", MySqlDbType.Bit,1),
					new MySqlParameter("?HandlerNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?HandlerUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?HandlerDate", MySqlDbType.DateTime),
					new MySqlParameter("?Privacy", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyDescription", MySqlDbType.VarChar,500),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CreateUserID;
            parameters[1].Value = model.CreateNickName;
            parameters[2].Value = model.ToUserID;
            parameters[3].Value = model.ToNickName;
            parameters[4].Value = model.CreatorUserIP;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.CreatedDate;
            parameters[8].Value = model.CreatorEmail;
            parameters[9].Value = model.CreatorRegion;
            parameters[10].Value = model.CreatorCompany;
            parameters[11].Value = model.CreatorPageSite;
            parameters[12].Value = model.CreatorPhone;
            parameters[13].Value = model.CreatorQQ;
            parameters[14].Value = model.CreatorMsn;
            parameters[15].Value = model.CreatorSex;
            parameters[16].Value = model.HandlerNickName;
            parameters[17].Value = model.HandlerUserID;
            parameters[18].Value = model.HandlerDate;
            parameters[19].Value = model.Privacy;
            parameters[20].Value = model.ReplyCount;
            parameters[21].Value = model.ReplyDescription;
            parameters[22].Value = model.ParentID;
            parameters[23].Value = model.Status;

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
        public bool Update(YSWL.MALL.Model.Members.Guestbook model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Guestbook set ");
            strSql.Append("CreateUserID=?CreateUserID,");
            strSql.Append("CreateNickName=?CreateNickName,");
            strSql.Append("ToUserID=?ToUserID,");
            strSql.Append("ToNickName=?ToNickName,");
            strSql.Append("CreatorUserIP=?CreatorUserIP,");
            strSql.Append("Title=?Title,");
            strSql.Append("Description=?Description,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("CreatorEmail=?CreatorEmail,");
            strSql.Append("CreatorRegion=?CreatorRegion,");
            strSql.Append("CreatorCompany=?CreatorCompany,");
            strSql.Append("CreatorPageSite=?CreatorPageSite,");
            strSql.Append("CreatorPhone=?CreatorPhone,");
            strSql.Append("CreatorQQ=?CreatorQQ,");
            strSql.Append("CreatorMsn=?CreatorMsn,");
            strSql.Append("CreatorSex=?CreatorSex,");
            strSql.Append("HandlerNickName=?HandlerNickName,");
            strSql.Append("HandlerUserID=?HandlerUserID,");
            strSql.Append("HandlerDate=?HandlerDate,");
            strSql.Append("Privacy=?Privacy,");
            strSql.Append("ReplyCount=?ReplyCount,");
            strSql.Append("ReplyDescription=?ReplyDescription,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("Status=?Status");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CreateUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreateNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ToUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ToNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorUserIP", MySqlDbType.VarChar,20),
					new MySqlParameter("?Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatorEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorRegion", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorCompany", MySqlDbType.VarChar,100),
					new MySqlParameter("?CreatorPageSite", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreatorPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?CreatorQQ", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorMsn", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatorSex", MySqlDbType.Bit,1),
					new MySqlParameter("?HandlerNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?HandlerUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?HandlerDate", MySqlDbType.DateTime),
					new MySqlParameter("?Privacy", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyDescription", MySqlDbType.VarChar,500),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CreateUserID;
            parameters[1].Value = model.CreateNickName;
            parameters[2].Value = model.ToUserID;
            parameters[3].Value = model.ToNickName;
            parameters[4].Value = model.CreatorUserIP;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.CreatedDate;
            parameters[8].Value = model.CreatorEmail;
            parameters[9].Value = model.CreatorRegion;
            parameters[10].Value = model.CreatorCompany;
            parameters[11].Value = model.CreatorPageSite;
            parameters[12].Value = model.CreatorPhone;
            parameters[13].Value = model.CreatorQQ;
            parameters[14].Value = model.CreatorMsn;
            parameters[15].Value = model.CreatorSex;
            parameters[16].Value = model.HandlerNickName;
            parameters[17].Value = model.HandlerUserID;
            parameters[18].Value = model.HandlerDate;
            parameters[19].Value = model.Privacy;
            parameters[20].Value = model.ReplyCount;
            parameters[21].Value = model.ReplyDescription;
            parameters[22].Value = model.ParentID;
            parameters[23].Value = model.Status;
            parameters[24].Value = model.ID;

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
            strSql.Append("delete from SA_Guestbook ");
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
            strSql.Append("delete from SA_Guestbook ");
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
        public YSWL.MALL.Model.Members.Guestbook GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,CreateUserID,CreateNickName,ToUserID,ToNickName,CreatorUserIP,Title,Description,CreatedDate,CreatorEmail,CreatorRegion,CreatorCompany,CreatorPageSite,CreatorPhone,CreatorQQ,CreatorMsn,CreatorSex,HandlerNickName,HandlerUserID,HandlerDate,Privacy,ReplyCount,ReplyDescription,ParentID,Status from SA_Guestbook ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.Guestbook model = new YSWL.MALL.Model.Members.Guestbook();
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
        public YSWL.MALL.Model.Members.Guestbook DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.Guestbook model = new YSWL.MALL.Model.Members.Guestbook();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CreateUserID"] != null && row["CreateUserID"].ToString() != "")
                {
                    model.CreateUserID = int.Parse(row["CreateUserID"].ToString());
                }
                if (row["CreateNickName"] != null && row["CreateNickName"].ToString() != "")
                {
                    model.CreateNickName = row["CreateNickName"].ToString();
                }
                if (row["ToUserID"] != null && row["ToUserID"].ToString() != "")
                {
                    model.ToUserID = int.Parse(row["ToUserID"].ToString());
                }
                if (row["ToNickName"] != null && row["ToNickName"].ToString() != "")
                {
                    model.ToNickName = row["ToNickName"].ToString();
                }
                if (row["CreatorUserIP"] != null && row["CreatorUserIP"].ToString() != "")
                {
                    model.CreatorUserIP = row["CreatorUserIP"].ToString();
                }
                if (row["Title"] != null && row["Title"].ToString() != "")
                {
                    model.Title = row["Title"].ToString();
                }
                if (row["Description"] != null && row["Description"].ToString() != "")
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["CreatorEmail"] != null && row["CreatorEmail"].ToString() != "")
                {
                    model.CreatorEmail = row["CreatorEmail"].ToString();
                }
                if (row["CreatorRegion"] != null && row["CreatorRegion"].ToString() != "")
                {
                    model.CreatorRegion = row["CreatorRegion"].ToString();
                }
                if (row["CreatorCompany"] != null && row["CreatorCompany"].ToString() != "")
                {
                    model.CreatorCompany = row["CreatorCompany"].ToString();
                }
                if (row["CreatorPageSite"] != null && row["CreatorPageSite"].ToString() != "")
                {
                    model.CreatorPageSite = row["CreatorPageSite"].ToString();
                }
                if (row["CreatorPhone"] != null && row["CreatorPhone"].ToString() != "")
                {
                    model.CreatorPhone = row["CreatorPhone"].ToString();
                }
                if (row["CreatorQQ"] != null && row["CreatorQQ"].ToString() != "")
                {
                    model.CreatorQQ = row["CreatorQQ"].ToString();
                }
                if (row["CreatorMsn"] != null && row["CreatorMsn"].ToString() != "")
                {
                    model.CreatorMsn = row["CreatorMsn"].ToString();
                }
                if (row["CreatorSex"] != null && row["CreatorSex"].ToString() != "")
                {
                    if ((row["CreatorSex"].ToString() == "1") || (row["CreatorSex"].ToString().ToLower() == "true"))
                    {
                        model.CreatorSex = true;
                    }
                    else
                    {
                        model.CreatorSex = false;
                    }
                }
                if (row["HandlerNickName"] != null && row["HandlerNickName"].ToString() != "")
                {
                    model.HandlerNickName = row["HandlerNickName"].ToString();
                }
                if (row["HandlerUserID"] != null && row["HandlerUserID"].ToString() != "")
                {
                    model.HandlerUserID = int.Parse(row["HandlerUserID"].ToString());
                }
                if (row["HandlerDate"] != null && row["HandlerDate"].ToString() != "")
                {
                    model.HandlerDate = DateTime.Parse(row["HandlerDate"].ToString());
                }
                if (row["Privacy"] != null && row["Privacy"].ToString() != "")
                {
                    model.Privacy = int.Parse(row["Privacy"].ToString());
                }
                if (row["ReplyCount"] != null && row["ReplyCount"].ToString() != "")
                {
                    model.ReplyCount = int.Parse(row["ReplyCount"].ToString());
                }
                if (row["ReplyDescription"] != null && row["ReplyDescription"].ToString() != "")
                {
                    model.ReplyDescription = row["ReplyDescription"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
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
            strSql.Append("select ID,CreateUserID,CreateNickName,ToUserID,ToNickName,CreatorUserIP,Title,Description,CreatedDate,CreatorEmail,CreatorRegion,CreatorCompany,CreatorPageSite,CreatorPhone,CreatorQQ,CreatorMsn,CreatorSex,HandlerNickName,HandlerUserID,HandlerDate,Privacy,ReplyCount,ReplyDescription,ParentID,Status ");
            strSql.Append(" FROM SA_Guestbook ");
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
            
            strSql.Append(" ID,CreateUserID,CreateNickName,ToUserID,ToNickName,CreatorUserIP,Title,Description,CreatedDate,CreatorEmail,CreatorRegion,CreatorCompany,CreatorPageSite,CreatorPhone,CreatorQQ,CreatorMsn,CreatorSex,HandlerNickName,HandlerUserID,HandlerDate,Privacy,ReplyCount,ReplyDescription,ParentID,Status ");
            strSql.Append(" FROM SA_Guestbook ");
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
            strSql.Append("select count(1) FROM SA_Guestbook ");
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
            strSql.Append("SELECT T.* from SA_Guestbook T ");
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
            parameters[0].Value = "SA_Guestbook";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}