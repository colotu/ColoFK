using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.SysManage;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    /// <summary>
    /// 配置参数类别
    /// </summary>
    public class ConfigType : IConfigType
    {
        #region BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_Config_Type");
            strSql.Append(" where TypeName=?TypeName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarString,50)
			};
            parameters[0].Value = TypeName;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(string TypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Config_Type(");
            strSql.Append("TypeName)");
            strSql.Append(" values (");
            strSql.Append("?TypeName)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarString,50)};
            parameters[0].Value = TypeName;

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
        public bool Update(int KeyType, string TypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Config_Type set ");
            strSql.Append("TypeName=?TypeName");
            strSql.Append(" where KeyType=?KeyType");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarString,50),
					new MySqlParameter("?KeyType",  MySqlDbType.Int32,4)};
            parameters[0].Value = TypeName;
            parameters[1].Value = KeyType;

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
        public bool Delete(int KeyType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Config_Type ");
            strSql.Append(" where KeyType=?KeyType");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyType",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = KeyType;

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
        public bool DeleteList(string KeyTypelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Config_Type ");
            strSql.Append(" where KeyType in (" + KeyTypelist + ")  ");
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
        public string GetTypeName(int KeyType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TypeName from SA_Config_Type ");
            strSql.Append(" where KeyType=?KeyType");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyType",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = KeyType;
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["TypeName"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select KeyType,TypeName ");
            strSql.Append(" FROM SA_Config_Type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion BasicMethod

        #region ExtensionMethod

        #endregion ExtensionMethod
    }
}