using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.DBUtility;//�����������
using YSWL.MALL.IDAL.Poll;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Poll
{
    /// <summary>
    /// ���ݷ�����Users��
    /// </summary>
    public class PollUsers : IPollUsers
    {



        #region  BasicMethod

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("UserID", "Poll_Users");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Poll_Users");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = UserID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(YSWL.MALL.Model.Poll.PollUsers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Poll_Users(");
            strSql.Append("UserName,Password,TrueName,Age,Sex,Phone,Email,UserType,SysUserId)");
            strSql.Append(" values (");
            strSql.Append("?UserName,?Password,?TrueName,?Age,?Sex,?Phone,?Email,?UserType,?SysUserId)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Password", MySqlDbType.Binary,50),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Age", MySqlDbType.Int32,4),
					new MySqlParameter("?Sex", MySqlDbType.VarChar,2),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Email", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserType", MySqlDbType.VarChar,2),
					new MySqlParameter("?SysUserId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Age;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.UserType;
            parameters[8].Value = model.SysUserId;

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
        /// ����һ������
        /// </summary>
        public bool Update(YSWL.MALL.Model.Poll.PollUsers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Poll_Users set ");
            strSql.Append("UserName=?UserName,");
            strSql.Append("Password=?Password,");
            strSql.Append("TrueName=?TrueName,");
            strSql.Append("Age=?Age,");
            strSql.Append("Sex=?Sex,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("Email=?Email,");
            strSql.Append("UserType=?UserType,");
            strSql.Append("SysUserId=?SysUserId");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Password", MySqlDbType.Binary,50),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Age", MySqlDbType.Int32,4),
					new MySqlParameter("?Sex", MySqlDbType.VarChar,2),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Email", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserType", MySqlDbType.VarChar,2),
					new MySqlParameter("?SysUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Age;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.UserType;
            parameters[8].Value = model.SysUserId;
            parameters[9].Value = model.UserID;

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
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Users ");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = UserID;

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
        /// ����ɾ������
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Users ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
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
        /// �õ�һ������ʵ��
        /// </summary>
        public YSWL.MALL.Model.Poll.PollUsers GetModel(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  UserID,UserName,Password,TrueName,Age,Sex,Phone,Email,UserType,SysUserId from Poll_Users ");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = UserID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Poll.PollUsers model = new YSWL.MALL.Model.Poll.PollUsers();
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
        /// �õ�һ������ʵ��
        /// </summary>
        public YSWL.MALL.Model.Poll.PollUsers DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Poll.PollUsers model = new YSWL.MALL.Model.Poll.PollUsers();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null && row["Password"].ToString() != "")
                {
                    model.Password = (byte[])row["Password"];
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["UserType"] != null)
                {
                    model.UserType = row["UserType"].ToString();
                }
                if (row["SysUserId"] != null && row["SysUserId"].ToString() != "")
                {
                    model.SysUserId = int.Parse(row["SysUserId"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserName,Password,TrueName,Age,Sex,Phone,Email,UserType,SysUserId ");
            strSql.Append(" FROM Poll_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(" UserID,UserName,Password,TrueName,Age,Sex,Phone,Email,UserType,SysUserId ");
            strSql.Append(" FROM Poll_Users ");
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
        /// ��ȡ��¼����
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Poll_Users ");
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
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.* from Poll_Users T ");
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
                strSql.Append(" order by T.UserID desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
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
            parameters[0].Value = "Poll_Users";
            parameters[1].Value = "UserID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod


        /// <summary>
        /// �Ƿ���ڸü�¼��ϵͳ�е��û���
        /// </summary>
        /// <param name="UserId">ϵͳ�û�UserID</param>
        /// <returns></returns>
        public bool ExistsSysUser(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Poll_Users");
            strSql.Append(" where SysUserId=?SysUserId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SysUserId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = UserId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

    }
}

