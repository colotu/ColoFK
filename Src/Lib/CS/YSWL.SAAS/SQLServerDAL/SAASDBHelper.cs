using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using YSWL.Common;
using YSWL.Common.DEncrypt;

namespace YSWL.SAAS.SQLServerDAL
{
   public class SAASDBHelper
    {

        /// <summary>
        /// 查询企业数据库配置
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.BaseConnection))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        public static object GetSingle4Trans(CommandInfo commandInfo, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand();
            string cmdText = commandInfo.CommandText;
            SqlParameter[] cmdParms = (SqlParameter[])commandInfo.Parameters;
            PrepareCommand(cmd, trans.Connection, trans, cmdText, cmdParms);
            object obj = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return null;
            }
            else
            {
                return obj;
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.BaseConnection))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }


        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(PubConstant.BaseConnection))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }


        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (
                SqlConnection connection = new SqlConnection(PubConstant.BaseConnection))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="cmdList">SQL语句的CommandInfo</param>
        /// <param name="trans">外部事务对象</param>
        /// <remarks>警告:内部不触发事务的提交和回滚</remarks>
        /// <remarks>只使用了CommandInfo-EffentNextType.ExcuteEffectRows, 其它项暂不支持</remarks>
        public static int ExecuteSqlTran4Indentity(System.Collections.Generic.List<CommandInfo> cmdList, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand();
            int count = 0;
            int indentity = 0;
            //循环
            foreach (CommandInfo commandInfo in cmdList)
            {
                string cmdText = commandInfo.CommandText;
                SqlParameter[] cmdParms = (SqlParameter[])commandInfo.Parameters;
                foreach (SqlParameter parameter in cmdParms)
                {
                    if (parameter.Direction == ParameterDirection.InputOutput)
                    {
                        parameter.Value = indentity;
                    }
                }
                PrepareCommand(cmd, trans.Connection, trans, cmdText, cmdParms);
                //执行 并计数
                int val = cmd.ExecuteNonQuery();
                count += val;
                if (commandInfo.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
                {
                    //未执行成功抛出异常, 由外部进行事务回滚
                    throw new SqlExecutionException("DbHelperSQL.ExecuteSqlTran4Indentity - [" + cmd.CommandText + "] 未执行成功!");
                }
                foreach (SqlParameter parameter in cmdParms)
                {
                    if (parameter.Direction == ParameterDirection.Output)
                    {
                        indentity = Convert.ToInt32(parameter.Value);
                    }
                }
                cmd.Parameters.Clear();
            }
            return count;
        }

        /// <summary>
        /// 组织参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }



        ///// <summary>
        ///// 将企业链接串保存到内存字典中
        ///// </summary>
        ///// <param name="businnessTag">企业标识</param>
        ///// <param name="cnnStr">链接串</param>
        ///// <param name="applicationId">应用Id</param>
        //public static void SaveConnectionStr(string businnessTag, string cnnStr, int applicationId)
        //{
        //    if (connectionStrs != null && !connectionStrs.Any(k => k.Key == businnessTag))
        //    {
        //        connectionStrs.Add(businnessTag, cnnStr);
        //        applicationIds.Add(businnessTag, applicationId);
        //    }
        //}
   

    }

}