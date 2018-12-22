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
    /// ���ݷ�����Forms��
    /// </summary>
    public class Forms : IForms
    {
        #region ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("FormID", "Poll_Forms");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int FormID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Poll_Forms");
            strSql.Append(" where FormID=?FormID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FormID",  MySqlDbType.Int32,4)};
            parameters[0].Value = FormID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(YSWL.MALL.Model.Poll.Forms model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Poll_Forms(");
            strSql.Append("Name,IsActive,Description)");
            strSql.Append(" values (");
            strSql.Append("?Name,?IsActive,?Description)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsActive", MySqlDbType.Bit),
					new MySqlParameter("?Description", MySqlDbType.VarChar,300)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.IsActive;
            parameters[2].Value = model.Description;

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

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(YSWL.MALL.Model.Poll.Forms model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Poll_Forms set ");
            strSql.Append("Name=?Name,");
            strSql.Append("IsActive=?IsActive,");
            strSql.Append("Description=?Description");
            strSql.Append(" where FormID=?FormID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FormID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?IsActive", MySqlDbType.Bit),
					new MySqlParameter("?Description", MySqlDbType.VarChar,300)};
            parameters[0].Value = model.FormID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.IsActive;
            parameters[3].Value = model.Description;

            return DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int FormID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Forms ");
            strSql.Append(" where FormID= " + FormID.ToString());

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from Poll_Topics where FormID= " + FormID.ToString());

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from Poll_UserPoll ");
            strSql2.Append(" where TopicID in (select ID from Poll_Topics where FormID=" + FormID.ToString() + ") ");

            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete from Poll_Options ");
            strSql4.Append(" where TopicID in (select ID from Poll_Topics where FormID=" + FormID.ToString() + ") ");

            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("delete from Poll_Reply ");
            strSql5.Append(" where TopicID in (select ID from Poll_Topics where FormID=" + FormID.ToString() + ") ");

            List<string> sqllist = new List<string>();

            sqllist.Add(strSql2.ToString());
            sqllist.Add(strSql4.ToString());
            sqllist.Add(strSql5.ToString());
            sqllist.Add(strSql3.ToString());
            sqllist.Add(strSql.ToString());

            DbHelperMySQL.ExecuteSqlTran(sqllist);
        }

        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="ClassIDlist"></param>
        /// <returns></returns>
        public bool DeleteList(string FormIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Forms ");
            strSql.Append(" where FormID in (" + FormIDlist + ")  ");

            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete from Poll_Topics where FormID in (" + FormIDlist + ")  ");

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from Poll_UserPoll ");
            strSql2.Append(" where TopicID in (select ID from Poll_Topics where FormID in(" + FormIDlist + ")) ");

            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete from Poll_Options ");
            strSql4.Append(" where TopicID in (select ID from Poll_Topics where FormID in(" + FormIDlist + ")) ");

            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("delete from Poll_Reply ");
            strSql5.Append(" where TopicID in (select ID from Poll_Topics where FormID in(" + FormIDlist + ")) ");

            List<string> sqllist = new List<string>();

            sqllist.Add(strSql2.ToString());
            sqllist.Add(strSql4.ToString());
            sqllist.Add(strSql5.ToString());
            sqllist.Add(strSql3.ToString());
            sqllist.Add(strSql.ToString());
            int rows = DbHelperMySQL.ExecuteSqlTran(sqllist);
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
        public YSWL.MALL.Model.Poll.Forms GetModel(int FormID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Poll_Forms ");
            strSql.Append(" where FormID=?FormID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FormID",  MySqlDbType.Int32,4)};
            parameters[0].Value = FormID;

            YSWL.MALL.Model.Poll.Forms model = new YSWL.MALL.Model.Poll.Forms();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["FormID"].ToString() != "")
                {
                    model.FormID = int.Parse(ds.Tables[0].Rows[0]["FormID"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();

                if (ds.Tables[0].Rows[0]["IsActive"] != null && ds.Tables[0].Rows[0]["IsActive"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsActive"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsActive"].ToString().ToLower() == "true"))
                    {
                        model.IsActive = true;
                    }
                    else
                    {
                        model.IsActive = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Poll_Forms ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion ��Ա����
    }
}