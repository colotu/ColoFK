using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//请先添加引用
using YSWL.MALL.IDAL.Poll;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Poll
{
    /// <summary>
    /// 数据访问类Topics。
    /// </summary>
    public class Topics : ITopics
    {
        public Topics()
        { }

        #region 成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FormID, string Title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Poll_Topics");
            strSql.Append(" where FormID=?FormID and Title=?Title");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FormID",  MySqlDbType.Int32,4),
                                        new MySqlParameter("?Title", MySqlDbType.VarChar)};
            parameters[0].Value = FormID;
            parameters[1].Value = Title;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Poll.Topics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Poll_Topics(");
            strSql.Append("Title,Type,FormID)");
            strSql.Append(" values (");
            strSql.Append("?Title,?Type,?FormID)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?FormID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Type;
            parameters[2].Value = model.FormID;

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
        /// 更新一条数据
        /// </summary>
        public void Update(YSWL.MALL.Model.Poll.Topics model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Poll_Topics set ");
            strSql.Append("Title=?Title,");
            strSql.Append("Type=?Type,");
            strSql.Append("FormID=?FormID");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Title", MySqlDbType.VarChar),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?FormID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.FormID;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Topics ");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ClassIDlist"></param>
        /// <returns></returns>
        public bool DeleteList(string ClassIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Topics ");
            strSql.Append(" where ID in (" + ClassIDlist + ")  ");
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
        public YSWL.MALL.Model.Poll.Topics GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ID,Title,Type,FormID from Poll_Topics ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            YSWL.MALL.Model.Poll.Topics model = new YSWL.MALL.Model.Poll.Topics();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select ROW_NUMBER() OVER(ORDER BY ID ASC) AS RowNum, ID,Title,Type,FormID ");
            //strSql.Append(" FROM Poll_Topics ");
            //if (strWhere.Trim() != "")
            //{
            //    strSql.Append(" where " + strWhere);
            //}
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,Title,Type,FormID ");
            strSql.Append(" FROM Poll_Topics ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ");
            
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
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion 成员方法
    }
}