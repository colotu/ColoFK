using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    /// <summary>
    /// 用户日志的操作类
    /// </summary>
    public class UserLog : YSWL.MALL.IDAL.SysManage.IUserLog
    {
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="model"></param>
        public void LogUserAdd(YSWL.MALL.Model.SysManage.UserLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_UserLog(");
            strSql.Append("OPTime,Url,OPInfo,UserName,UserType,UserIP)");
            strSql.Append(" values (");
            strSql.Append("?OPTime,?Url,?OPInfo,?UserName,?UserType,?UserIP)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OPTime", MySqlDbType.DateTime),
					new MySqlParameter("?Url", MySqlDbType.VarChar,200),
					new MySqlParameter("?OPInfo", MySqlDbType.VarString),
                    new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?UserType", MySqlDbType.VarChar,2),
                    new MySqlParameter("?UserIP", MySqlDbType.VarChar,20)};
            parameters[0].Value = DateTime.Now;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.OPInfo;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserType;
            parameters[5].Value = model.UserIP;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据查询条件获取日志列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回的数据集</returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,OPTime,url,OPInfo,UserName,UserType,UserIp ");
            strSql.Append(" FROM SA_UserLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " Order By OPTime Desc ");
            }
            else
            {
                strSql.Append(" Order By OPTime Desc ");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条日志记录
        /// </summary>
        /// <param name="iID">要删除的日志编号</param>
        public void LogUserDelete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM SA_UserLog ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
				};
            parameters[0].Value = ID;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void LogUserDelete(string IdList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM SA_UserLog ");
            strSql.Append(" where ID in(" + IdList + ")");
            DbHelperMySQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除某一日期之前的数据
        /// </summary>
        /// <param name="dtDateBefore">日期</param>
        public void LogUserDelete(DateTime dtDateBefore)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete FROM SA_UserLog ");
            strSql.Append(" where OPTime <= ?OPTime");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OPTime", MySqlDbType.DateTime)
				};
            parameters[0].Value = dtDateBefore;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除某一日期之前的数据用存储过程
        /// </summary>
        /// <param name="dtDateBefore">日期</param>
        public void LogDelete(DateTime dtDateBefore)
        {
            MySqlParameter[] parameters = { new MySqlParameter("?_OPTime", MySqlDbType.DateTime), };

            parameters[0].Value = dtDateBefore;
            DbHelperMySQL.RunProcedure("sp_LogUser_delete", parameters);
        }

        ///// <summary>
        ///// 得到要查询的数据的总数
        ///// </summary>
        ///// <param name="strTable">要查询的表</param>
        ///// <param name="strWhere">查询的条件,如果没有条件填1=1</param>
        ///// <returns>返回的记录总数</returns>
        //public int GetRecSum(string strTable, string strWhere)
        //{
        //    string strCmd = "select count(*) from " + strTable + "   where  " + strWhere;
        //    int iResult = Convert.ToInt32(DbHelperMySQL.GetSingle(strCmd));
        //    return iResult;
        //}

        /// <summary>
        /// 得到要查询的数据的总数
        /// </summary>
        /// <param name="strTable">要查询的表</param>
        /// <param name="strWhere">查询的条件,如果没有条件填1=1</param>
        /// <returns>返回的记录总数</returns>
        public int GetCount(string strWhere)
        {
            string strCmd = "select count(*) from  SA_UserLog   where  " + strWhere;
            int iResult = Convert.ToInt32(DbHelperMySQL.GetSingle(strCmd));
            return iResult;
        }
    }
}