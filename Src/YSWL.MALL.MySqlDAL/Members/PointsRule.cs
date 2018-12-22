using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:PointsRule
    /// </summary>
    public partial class PointsRule : IPointsRule
    {
        public PointsRule()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("RuleId", "Accounts_PointsRule");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RuleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_PointsRule");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RuleId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.PointsRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_PointsRule(");
            strSql.Append("ActionId,LimitID,Name,Score,Description,TargetId,TargetType)");
            strSql.Append(" values (");
            strSql.Append("?ActionId,?LimitID,?Name,?Score,?Description,?TargetId,?TargetType)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int32,4),
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,-1),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ActionId;
            parameters[1].Value = model.LimitID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Score;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.TargetId;
            parameters[6].Value = model.TargetType;

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
        public bool Update(YSWL.MALL.Model.Members.PointsRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_PointsRule set ");
            strSql.Append("ActionId=?ActionId,");
            strSql.Append("LimitID=?LimitID,");
            strSql.Append("Name=?Name,");
            strSql.Append("Score=?Score,");
            strSql.Append("Description=?Description,");
            strSql.Append("TargetId=?TargetId,");
            strSql.Append("TargetType=?TargetType");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int32,4),
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,-1),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ActionId;
            parameters[1].Value = model.LimitID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Score;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.TargetId;
            parameters[6].Value = model.TargetType;
            parameters[7].Value = model.RuleId;

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
        public bool Delete(int RuleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_PointsRule ");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RuleId;

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
        public bool DeleteList(string RuleIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_PointsRule ");
            strSql.Append(" where RuleId in (" + RuleIdlist + ")  ");
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
        public YSWL.MALL.Model.Members.PointsRule GetModel(int RuleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RuleId,ActionId,LimitID,Name,Score,Description,TargetId,TargetType from Accounts_PointsRule ");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RuleId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.PointsRule model = new YSWL.MALL.Model.Members.PointsRule();
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
        public YSWL.MALL.Model.Members.PointsRule DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.PointsRule model = new YSWL.MALL.Model.Members.PointsRule();
            if (row != null)
            {
                if (row["RuleId"] != null && row["RuleId"].ToString() != "")
                {
                    model.RuleId = int.Parse(row["RuleId"].ToString());
                }
                if (row["ActionId"] != null && row["ActionId"].ToString() != "")
                {
                    model.ActionId = int.Parse(row["ActionId"].ToString());
                }
                if (row["LimitID"] != null && row["LimitID"].ToString() != "")
                {
                    model.LimitID = int.Parse(row["LimitID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Score"] != null && row["Score"].ToString() != "")
                {
                    model.Score = int.Parse(row["Score"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["TargetId"] != null && row["TargetId"].ToString() != "")
                {
                    model.TargetId = int.Parse(row["TargetId"].ToString());
                }
                if (row["TargetType"] != null && row["TargetType"].ToString() != "")
                {
                    model.TargetType = int.Parse(row["TargetType"].ToString());
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
            strSql.Append("select RuleId,ActionId,LimitID,Name,Score,Description,TargetId,TargetType ");
            strSql.Append(" FROM Accounts_PointsRule ");
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
            
            strSql.Append(" RuleId,ActionId,LimitID,Name,Score,Description,TargetId,TargetType ");
            strSql.Append(" FROM Accounts_PointsRule ");
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
            strSql.Append("select count(1) FROM Accounts_PointsRule ");
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
            strSql.Append("SELECT T.* from Accounts_PointsRule T ");
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
                strSql.Append(" order by T.RuleId desc");
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
            parameters[0].Value = "Accounts_PointsRule";
            parameters[1].Value = "RuleId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region 扩展方法
        public string GetRuleName(int ruleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Name  ");
            strSql.Append("FROM Accounts_PointsRule ");
            strSql.AppendFormat("WHERE RuleId={0}", ruleid);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());

            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Members.PointsRule GetModel(int ActionId, int TargetId, int TargetType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Accounts_PointsRule ");
            strSql.Append(" where ActionId=?ActionId  and  TargetId=?TargetId and TargetType=?TargetType");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TargetType", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ActionId;
            parameters[1].Value = TargetId;
            parameters[2].Value = TargetType;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.PointsRule model = new YSWL.MALL.Model.Members.PointsRule();
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

        public bool Exists(int ActionId, int targetId, int targetType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_PointsRule");
            strSql.Append(" where ActionId=?ActionId and TargetId=?TargetId and TargetType=?TargetType");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TargetType", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ActionId;
            parameters[1].Value = targetId;
            parameters[2].Value = targetType;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该规则码
        /// </summary>
        public bool ExistsActionId(int ActionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_PointsRule");
            strSql.Append(" where ActionId=?ActionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ActionId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        #endregion
    }
}

