using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:PointsDetail
    /// </summary>
    public partial class PointsDetail : IPointsDetail
    {
        public PointsDetail()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("DetailID", "Accounts_PointsDetail");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_PointsDetail");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = DetailID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.PointsDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_PointsDetail(");
            strSql.Append("RuleId,UserID,Score,ExtData,CurrentPoints,Description,CreatedDate,Type)");
            strSql.Append(" values (");
            strSql.Append("?RuleId,?UserID,?Score,?ExtData,?CurrentPoints,?Description,?CreatedDate,?Type)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?ExtData", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CurrentPoints", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Type", MySqlDbType.Int32,4)};
            parameters[0].Value = model.RuleId;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Score;
            parameters[3].Value = model.ExtData;
            parameters[4].Value = model.CurrentPoints;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.Type;

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
        public bool Update(YSWL.MALL.Model.Members.PointsDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_PointsDetail set ");
            strSql.Append("RuleId=?RuleId,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("Score=?Score,");
            strSql.Append("ExtData=?ExtData,");
            strSql.Append("CurrentPoints=?CurrentPoints,");
            strSql.Append("Description=?Description,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Type=?Type");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?ExtData", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CurrentPoints", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.RuleId;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Score;
            parameters[3].Value = model.ExtData;
            parameters[4].Value = model.CurrentPoints;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.Type;
            parameters[8].Value = model.DetailID;

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
        public bool Delete(int DetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_PointsDetail ");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = DetailID;

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
        public bool DeleteList(string DetailIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_PointsDetail ");
            strSql.Append(" where DetailID in (" + DetailIDlist + ")  ");
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
        public YSWL.MALL.Model.Members.PointsDetail GetModel(int DetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DetailID,RuleId,UserID,Score,ExtData,CurrentPoints,Description,CreatedDate,Type from Accounts_PointsDetail ");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = DetailID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.PointsDetail model = new YSWL.MALL.Model.Members.PointsDetail();
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
        public YSWL.MALL.Model.Members.PointsDetail DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.PointsDetail model = new YSWL.MALL.Model.Members.PointsDetail();
            if (row != null)
            {
                if (row["DetailID"] != null && row["DetailID"].ToString() != "")
                {
                    model.DetailID = int.Parse(row["DetailID"].ToString());
                }
                if (row["RuleId"] != null && row["RuleId"].ToString() != "")
                {
                    model.RuleId = int.Parse(row["RuleId"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["Score"] != null && row["Score"].ToString() != "")
                {
                    model.Score = int.Parse(row["Score"].ToString());
                }
                if (row["ExtData"] != null)
                {
                    model.ExtData = row["ExtData"].ToString();
                }
                if (row["CurrentPoints"] != null && row["CurrentPoints"].ToString() != "")
                {
                    model.CurrentPoints = int.Parse(row["CurrentPoints"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
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
            strSql.Append("select DetailID,RuleId,UserID,Score,ExtData,CurrentPoints,Description,CreatedDate,Type ");
            strSql.Append(" FROM Accounts_PointsDetail ");
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
            
            strSql.Append(" DetailID,RuleId,UserID,Score,ExtData,CurrentPoints,Description,CreatedDate,Type ");
            strSql.Append(" FROM Accounts_PointsDetail ");
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
            strSql.Append("select count(1) FROM Accounts_PointsDetail ");
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
            strSql.Append("SELECT T.* from Accounts_PointsDetail T ");
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
                strSql.Append(" order by T.DetailID desc");
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
            parameters[0].Value = "Accounts_PointsDetail";
            parameters[1].Value = "DetailID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region 扩展方法
        /// <summary>
        /// 添加积分明细（事务处理，需要更新个人的总积分）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddDetail(YSWL.MALL.Model.Members.PointsDetail model)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            //添加积分明细
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_PointsDetail(");
            strSql.Append("RuleID,UserID,Score,ExtData,CurrentPoints,Description,CreatedDate,Type)");
            strSql.Append(" values (");
            strSql.Append("?RuleID,?UserID,?Score,?ExtData,0,?Description,?CreatedDate,?Type)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?RuleID", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserID", MySqlDbType.Int32,4),
                    new MySqlParameter("?Score", MySqlDbType.Int32,4),
                    new MySqlParameter("?ExtData", MySqlDbType.VarChar),
                    new MySqlParameter("?Description", MySqlDbType.VarChar),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
            new MySqlParameter("?Type", MySqlDbType.Int32,4)};
            parameters[0].Value = model.RuleId;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.Score;
            parameters[3].Value = model.ExtData;
            //if (model.Type == 0)
            //{
            //    parameters[4].Value = model.Score;
            //}
            //if (model.Type == 1)
            //{
            //    parameters[4].Value = -model.Score;
            //}
            parameters[4].Value = model.Description;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.Type;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //更新个人积分数
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update Accounts_UsersExp set ");
            if (model.Type == 0)//获取积分
            {
                strSql2.Append("Points=Points+?Points");
            }
            if (model.Type == 1)//消费积分
            {
                strSql2.Append("Points=Points-?Points");
            }
            strSql2.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserID", MySqlDbType.Int32,4)
                                        };
            parameters2[0].Value = model.Score;
            parameters2[1].Value = model.UserID;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdatePoints(int userId, int points, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersExp set ");
            if (type == 0)//获取积分
            {
                strSql.Append("Points=Points+?Points");
            }
            if (type == 1)//消费积分
            {
                strSql.Append("Points=Points-?Points");
            }
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserID", MySqlDbType.Int32,4)
                                        };
            parameters2[0].Value = points;
            parameters2[1].Value = userId;
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters2);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetSignCount(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Accounts_PointsDetail ");
            strSql.Append(" WHERE UserID=?UserID and  RuleId=(SELECT RuleId  FROM Accounts_PointsRule WHERE ActionId=10) ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = userId;
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

        public DataSet GetSignListByPage(int userId, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from Accounts_PointsDetail T ");
            strSql.AppendFormat(" WHERE UserID={0} and  RuleId=(SELECT RuleId  FROM Accounts_PointsRule WHERE ActionId=10) ", userId);
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.DetailID desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public int GetCount(int userid, string unit, int cycle, int RuleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Accounts_PointsDetail ");
            //dal.GetRecordCount(" userid=" + userid + " and RuleId=" + RuleId + " and datediff( " + unit + ", CreatedDate, GETDATE())<" + cycle);

            strSql.AppendFormat(" where  userid={0}  and RuleId={1} and timestampdiff({2}, CreatedDate, now())<{3} ", userid, RuleId, unit, cycle);
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

        #endregion



        
    }
}