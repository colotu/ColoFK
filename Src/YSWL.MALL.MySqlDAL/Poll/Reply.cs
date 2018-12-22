using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//请先添加引用
using YSWL.MALL.IDAL.Poll;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Poll
{
    /// <summary>
    /// 数据访问类Reply。
    /// </summary>
    public class Reply : IReply
    {
        #region 成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "Poll_Reply");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Poll_Reply");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Poll.Reply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Poll_Reply(");
            strSql.Append("TopicID,ReContent,ReTime)");
            strSql.Append(" values (");
            strSql.Append("?TopicID,?ReContent,?ReTime)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TopicID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ReContent", MySqlDbType.VarChar,300),
					new MySqlParameter("?ReTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.TopicID;
            parameters[1].Value = model.ReContent;
            parameters[2].Value = model.ReTime;

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
        public void Update(YSWL.MALL.Model.Poll.Reply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Poll_Reply set ");
            strSql.Append("TopicID=?TopicID,");
            strSql.Append("ReContent=?ReContent,");
            strSql.Append("ReTime=?ReTime");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?TopicID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ReContent", MySqlDbType.VarChar,300),
					new MySqlParameter("?ReTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.TopicID;
            parameters[2].Value = model.ReContent;
            parameters[3].Value = model.ReTime;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Reply ");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Poll.Reply GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    ID,TopicID,ReContent,ReTime from Poll_Reply ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            YSWL.MALL.Model.Poll.Reply model = new YSWL.MALL.Model.Poll.Reply();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TopicID"].ToString() != "")
                {
                    model.TopicID = int.Parse(ds.Tables[0].Rows[0]["TopicID"].ToString());
                }
                model.ReContent = ds.Tables[0].Rows[0]["ReContent"].ToString();
                if (ds.Tables[0].Rows[0]["ReTime"].ToString() != "")
                {
                    model.ReTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReTime"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,TopicID,ReContent,ReTime ");
            strSql.Append(" FROM Poll_Reply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion 成员方法
    }
}