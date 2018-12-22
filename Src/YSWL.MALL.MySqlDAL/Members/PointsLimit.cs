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
    /// 数据访问类:PointsLimit
    /// </summary>
    public partial class PointsLimit : IPointsLimit
    {
        public PointsLimit()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("LimitID", "Accounts_PointsLimit");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LimitID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_PointsLimit");
            strSql.Append(" where LimitID=?LimitID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LimitID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.PointsLimit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_PointsLimit(");
            strSql.Append("Name,Cycle,CycleUnit,MaxTimes,TargetId,TargetType)");
            strSql.Append(" values (");
            strSql.Append("?Name,?Cycle,?CycleUnit,?MaxTimes,?TargetId,?TargetType)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?Cycle", MySqlDbType.Int32,4),
					new MySqlParameter("?CycleUnit", MySqlDbType.VarChar,50),
					new MySqlParameter("?MaxTimes", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Cycle;
            parameters[2].Value = model.CycleUnit;
            parameters[3].Value = model.MaxTimes;
            parameters[4].Value = model.TargetId;
            parameters[5].Value = model.TargetType;

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
        public bool Update(YSWL.MALL.Model.Members.PointsLimit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_PointsLimit set ");
            strSql.Append("Name=?Name,");
            strSql.Append("Cycle=?Cycle,");
            strSql.Append("CycleUnit=?CycleUnit,");
            strSql.Append("MaxTimes=?MaxTimes,");
            strSql.Append("TargetId=?TargetId,");
            strSql.Append("TargetType=?TargetType");
            strSql.Append(" where LimitID=?LimitID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?Cycle", MySqlDbType.Int32,4),
					new MySqlParameter("?CycleUnit", MySqlDbType.VarChar,50),
					new MySqlParameter("?MaxTimes", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetType", MySqlDbType.Int32,4),
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Cycle;
            parameters[2].Value = model.CycleUnit;
            parameters[3].Value = model.MaxTimes;
            parameters[4].Value = model.TargetId;
            parameters[5].Value = model.TargetType;
            parameters[6].Value = model.LimitID;

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
        public bool Delete(int LimitID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_PointsLimit ");
            strSql.Append(" where LimitID=?LimitID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LimitID;

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
        public bool DeleteList(string LimitIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_PointsLimit ");
            strSql.Append(" where LimitID in (" + LimitIDlist + ")  ");
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
        public YSWL.MALL.Model.Members.PointsLimit GetModel(int LimitID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  LimitID,Name,Cycle,CycleUnit,MaxTimes,TargetId,TargetType from Accounts_PointsLimit ");
            strSql.Append(" where LimitID=?LimitID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LimitID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.PointsLimit model = new YSWL.MALL.Model.Members.PointsLimit();
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
        public YSWL.MALL.Model.Members.PointsLimit DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.PointsLimit model = new YSWL.MALL.Model.Members.PointsLimit();
            if (row != null)
            {
                if (row["LimitID"] != null && row["LimitID"].ToString() != "")
                {
                    model.LimitID = int.Parse(row["LimitID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Cycle"] != null && row["Cycle"].ToString() != "")
                {
                    model.Cycle = int.Parse(row["Cycle"].ToString());
                }
                if (row["CycleUnit"] != null)
                {
                    model.CycleUnit = row["CycleUnit"].ToString();
                }
                if (row["MaxTimes"] != null && row["MaxTimes"].ToString() != "")
                {
                    model.MaxTimes = int.Parse(row["MaxTimes"].ToString());
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
            strSql.Append("select LimitID,Name,Cycle,CycleUnit,MaxTimes,TargetId,TargetType ");
            strSql.Append(" FROM Accounts_PointsLimit ");
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
            
            strSql.Append(" LimitID,Name,Cycle,CycleUnit,MaxTimes,TargetId,TargetType ");
            strSql.Append(" FROM Accounts_PointsLimit ");
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
            strSql.Append("select count(1) FROM Accounts_PointsLimit ");
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
            strSql.Append("SELECT T.* from Accounts_PointsLimit T ");
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
                strSql.Append(" order by T.LimitID desc");
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
            parameters[0].Value = "Accounts_PointsLimit";
            parameters[1].Value = "LimitID";
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
        /// 删除条件限制（更新引用该条件限制的规则）
        /// </summary>
        public bool DeleteEX(int PointsLimitID)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除条件限制
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_PointsLimit ");
            strSql.Append(" where LimitID=?LimitID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PointsLimitID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            //更新引用的积分规则
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("UPDATE Accounts_PointsRule SET LimitID=-1 WHERE LimitID=?LimitID");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4)
                                        };
            parameters2[0].Value = PointsLimitID;
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

        public bool ExistsLimit(int limitid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_PointsRule");
            strSql.Append(" where LimitID=?LimitID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LimitID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = limitid;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该限制名称
        /// </summary>
        public bool ExistsName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_PointsLimit");
            strSql.Append(" where Name=?Name");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,255)
			};
            parameters[0].Value = name;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        #endregion
    }
}
