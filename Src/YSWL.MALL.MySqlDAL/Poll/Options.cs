using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//请先添加引用
using YSWL.MALL.IDAL.Poll;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Poll
{
    /// <summary>
    /// 数据访问类Options。
    /// </summary>
    public class Options : IOptions
    {
        #region 成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TopicID, string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Poll_Options");
            strSql.Append(" where TopicID=?TopicID and Name=?Name ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TopicID",  MySqlDbType.Int32,4),
                                        new MySqlParameter("?Name", MySqlDbType.VarChar)};
            parameters[0].Value = TopicID;
            parameters[1].Value = Name;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Poll.Options model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Poll_Options(");
            strSql.Append("Name,TopicID,isChecked,SubmitNum)");
            strSql.Append(" values (");
            strSql.Append("?Name,?TopicID,?isChecked,?SubmitNum)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,150),
					new MySqlParameter("?TopicID",  MySqlDbType.Int32,4),
					new MySqlParameter("?isChecked", MySqlDbType.Int16,2),
					new MySqlParameter("?SubmitNum",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.TopicID;
            parameters[2].Value = model.isChecked;
            parameters[3].Value = model.SubmitNum;

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
        public void Update(YSWL.MALL.Model.Poll.Options model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Poll_Options set ");
            strSql.Append("Name=?Name,");
            strSql.Append("TopicID=?TopicID,");
            strSql.Append("isChecked=?isChecked,");
            strSql.Append("SubmitNum=?SubmitNum");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,150),
					new MySqlParameter("?TopicID",  MySqlDbType.Int32,4),
					new MySqlParameter("?isChecked", MySqlDbType.Int16,2),
					new MySqlParameter("?SubmitNum",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.TopicID;
            parameters[3].Value = model.isChecked;
            parameters[4].Value = model.SubmitNum;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Poll_Options ");
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
            strSql.Append("delete from Poll_Options ");
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
        public YSWL.MALL.Model.Poll.Options GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ID,Name,TopicID,isChecked,SubmitNum from Poll_Options ");
            strSql.Append(" where ID=?ID  LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;

            YSWL.MALL.Model.Poll.Options model = new YSWL.MALL.Model.Poll.Options();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["TopicID"].ToString() != "")
                {
                    model.TopicID = int.Parse(ds.Tables[0].Rows[0]["TopicID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isChecked"].ToString() != "")
                {
                    model.isChecked = int.Parse(ds.Tables[0].Rows[0]["isChecked"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SubmitNum"].ToString() != "")
                {
                    model.SubmitNum = int.Parse(ds.Tables[0].Rows[0]["SubmitNum"].ToString());
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
            strSql.Append("select ID,Name,TopicID,isChecked,SubmitNum ");
            strSql.Append(" FROM Poll_Options ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到问卷投票统计
        /// </summary>
        /// <param name="FormID"></param>
        /// <returns></returns>
        public DataSet GetCountList(int FormID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name,SubmitNum,TopicID from Poll_Options ");
            strSql.Append(" where TopicID in  (");
            strSql.Append(" select ID from Poll_Topics where FormID=" + FormID);
            strSql.Append(")");
            strSql.Append(" order by ID");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到问卷投票统计
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataSet GetCountList(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Name,SubmitNum,TopicID from Poll_Options ");
            strSql.Append(" where TopicID in  (");
            strSql.Append(" select ID from Poll_Topics ");
            if (strwhere.Length > 0)
                strSql.AppendFormat(" where {0} ", strwhere);
            strSql.Append(")");
            strSql.Append("order by ID");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion 成员方法
    }
}