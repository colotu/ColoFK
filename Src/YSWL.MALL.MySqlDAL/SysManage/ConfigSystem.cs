using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    /// <summary>
    /// Config system
    /// </summary>
    public class ConfigSystem : YSWL.MALL.IDAL.SysManage.IConfigSystem
    {
        #region Method

        /// <summary>
        /// Whether there is Exists
        /// </summary>
        public bool Exists(string Keyname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_Config_System");
            strSql.Append(" where Keyname=?Keyname ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar)};
            parameters[0].Value = Keyname;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Add a record
        /// </summary>
        public int Add(string Keyname, string Value, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Config_System(");
            strSql.Append("Keyname,Value,Description)");
            strSql.Append(" values (");
            strSql.Append("?Keyname,?Value,?Description)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Value", MySqlDbType.VarChar),
                    new MySqlParameter("?Description", MySqlDbType.VarChar,200)};
            parameters[0].Value = Keyname;
            parameters[1].Value = Value;
            parameters[2].Value = Description;

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
        /// Add a record
        /// </summary>
        public int Add(string Keyname, string Value, string Description, YSWL.MALL.Model.SysManage.ApplicationKeyType KeyType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Config_System(");
            strSql.Append("Keyname,Value,Description,KeyType)");
            strSql.Append(" values (");
            strSql.Append("?Keyname,?Value,?Description,?KeyType)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Value", MySqlDbType.VarChar),
                    new MySqlParameter("?Description", MySqlDbType.VarChar,200),
                    new MySqlParameter("?KeyType",  MySqlDbType.Int32)};
            parameters[0].Value = Keyname;
            parameters[1].Value = Value;
            parameters[2].Value = Description;
            parameters[3].Value = (int)(KeyType);

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

        public void Update(int ID, string Keyname, string Value, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Config_System set ");
            strSql.Append("Keyname=?Keyname,");
            strSql.Append("Value=?Value,");
            strSql.Append("Description=?Description");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Value", MySqlDbType.VarChar),
                    new MySqlParameter("?Description", MySqlDbType.VarChar,200)};
            parameters[0].Value = ID;
            parameters[1].Value = Keyname;
            parameters[2].Value = Value;
            parameters[3].Value = Description;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Update a record
        /// </summary>
        public bool Update(string Keyname, string Value, string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Config_System set ");
            strSql.Append("Value=?Value,");
            strSql.Append("Description=?Description");
            strSql.Append(" where Keyname=?Keyname ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Value", MySqlDbType.VarChar),
                    new MySqlParameter("?Description", MySqlDbType.VarChar,200)};
            parameters[0].Value = Keyname;
            parameters[1].Value = Value;
            parameters[2].Value = Description;

            return (DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters) > 0);
        }

        /// <summary>
        /// Update a record
        /// </summary>
        public bool Update(string Keyname, string Value)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SA_Config_System SET ");
            strSql.Append("Value=?Value");
            strSql.Append(" WHERE Keyname=?Keyname");
            MySqlParameter[] parameters = {					
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Value", MySqlDbType.VarChar,-1),
                    new MySqlParameter("?KeyType", MySqlDbType.Int32)};
            parameters[0].Value = Keyname;
            parameters[1].Value = Value;

            return (DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters) > 0);
        }

        /// <summary>
        /// Update a record
        /// </summary>
        public bool Update(string Keyname, string Value, YSWL.MALL.Model.SysManage.ApplicationKeyType KeyType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SA_Config_System SET ");
            strSql.Append("Value=?Value");
            strSql.Append(" WHERE Keyname=?Keyname AND KeyType=?KeyType");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Value", MySqlDbType.VarChar),
                    new MySqlParameter("?KeyType",  MySqlDbType.Int32)};
            parameters[0].Value = Keyname;
            parameters[1].Value = Value;
            parameters[2].Value = (int)(KeyType);

            return (DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters) > 0);
        }

        /// <summary>
        /// Delete a record
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Config_System ");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        public string GetValue(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Value from SA_Config_System ");
            strSql.Append(" where ID=?ID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ID;
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// Get an object entity
        /// </summary>
        public string GetValue(string Keyname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Value from SA_Config_System ");
            strSql.Append(" where Keyname=?Keyname ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Keyname", MySqlDbType.VarChar)};
            parameters[0].Value = Keyname;
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// Query data list
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Keyname,Value,Description ");
            strSql.Append(" FROM SA_Config_System ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion Method

        #region MethodEx

        public void UpdateConnectionString(string connectionString)
        {
            DbHelperMySQL.connectionString = connectionString;
        }

        public string GetDescription(string Keyname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Description from SA_Config_System ");
            strSql.Append(" where Keyname=?Keyname ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Keyname", SqlDbType.NVarChar)};
            parameters[0].Value = Keyname;
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        #endregion
    }
}