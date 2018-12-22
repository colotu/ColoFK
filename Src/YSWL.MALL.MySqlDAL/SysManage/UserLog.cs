using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    /// <summary>
    /// �û���־�Ĳ�����
    /// </summary>
    public class UserLog : YSWL.MALL.IDAL.SysManage.IUserLog
    {
        /// <summary>
        /// ������־
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
        /// ���ݲ�ѯ������ȡ��־�б�
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <returns>���ص����ݼ�</returns>
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
        /// ɾ��һ����־��¼
        /// </summary>
        /// <param name="iID">Ҫɾ������־���</param>
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
        /// ɾ��ĳһ����֮ǰ������
        /// </summary>
        /// <param name="dtDateBefore">����</param>
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
        /// ɾ��ĳһ����֮ǰ�������ô洢����
        /// </summary>
        /// <param name="dtDateBefore">����</param>
        public void LogDelete(DateTime dtDateBefore)
        {
            MySqlParameter[] parameters = { new MySqlParameter("?_OPTime", MySqlDbType.DateTime), };

            parameters[0].Value = dtDateBefore;
            DbHelperMySQL.RunProcedure("sp_LogUser_delete", parameters);
        }

        ///// <summary>
        ///// �õ�Ҫ��ѯ�����ݵ�����
        ///// </summary>
        ///// <param name="strTable">Ҫ��ѯ�ı�</param>
        ///// <param name="strWhere">��ѯ������,���û��������1=1</param>
        ///// <returns>���صļ�¼����</returns>
        //public int GetRecSum(string strTable, string strWhere)
        //{
        //    string strCmd = "select count(*) from " + strTable + "   where  " + strWhere;
        //    int iResult = Convert.ToInt32(DbHelperMySQL.GetSingle(strCmd));
        //    return iResult;
        //}

        /// <summary>
        /// �õ�Ҫ��ѯ�����ݵ�����
        /// </summary>
        /// <param name="strTable">Ҫ��ѯ�ı�</param>
        /// <param name="strWhere">��ѯ������,���û��������1=1</param>
        /// <returns>���صļ�¼����</returns>
        public int GetCount(string strWhere)
        {
            string strCmd = "select count(*) from  SA_UserLog   where  " + strWhere;
            int iResult = Convert.ToInt32(DbHelperMySQL.GetSingle(strCmd));
            return iResult;
        }
    }
}