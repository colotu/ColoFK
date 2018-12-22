using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.DBUtility;//�����������
using YSWL.MALL.IDAL.Poll;

namespace YSWL.MALL.SQLServerDAL.Poll
{
    /// <summary>
    /// ���ݷ�����Topics��
    /// </summary>
    public class Topics : ITopics
    {
        public Topics()
        { }

        #region ��Ա����

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int FormID, string Title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Poll_Topics");
            strSql.Append(" where FormID=@FormID and Title=@Title");
            SqlParameter[] parameters = {
					new SqlParameter("@FormID", SqlDbType.Int,4),
                                        new SqlParameter("@Title", SqlDbType.NVarChar)};
            parameters[0].Value = FormID;
            parameters[1].Value = Title;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(YSWL.MALL.Model.Poll.Topics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Poll_Topics(");
            strSql.Append("Title,Type,FormID)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Type,@FormID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@FormID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.FormID;

            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameters);
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
        public void Update(YSWL.MALL.Model.Poll.Topics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Poll_Topics set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Type=@Type,");
            strSql.Append("FormID=@FormID");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar),
					new SqlParameter("@Type", SqlDbType.SmallInt,2),
					new SqlParameter("@FormID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.FormID;

            DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Topics ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="ClassIDlist"></param>
        /// <returns></returns>
        public bool DeleteList(string ClassIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Topics ");
            strSql.Append(" where ID in (" + ClassIDlist + ")  ");
            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString());
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
        public YSWL.MALL.Model.Poll.Topics GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Title,Type,FormID from Poll_Topics ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            YSWL.MALL.Model.Poll.Topics model = new YSWL.MALL.Model.Poll.Topics();
            DataSet ds = DBHelper.DefaultDBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FormID"].ToString() != "")
                {
                    model.FormID = int.Parse(ds.Tables[0].Rows[0]["FormID"].ToString());
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
            strSql.Append("select ROW_NUMBER() OVER(ORDER BY ID ASC) AS RowNum, ID,Title,Type,FormID ");
            strSql.Append(" FROM Poll_Topics ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,Title,Type,FormID ");
            strSql.Append(" FROM Poll_Topics ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(filedOrder); //ORDER BY ID ASC
            }
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }
        #endregion ��Ա����
    }
}