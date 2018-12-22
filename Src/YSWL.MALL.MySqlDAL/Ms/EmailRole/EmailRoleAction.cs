using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Ms.EmailRole;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Ms.EmailRole
{
    class EmailRoleAction : IEmailRoleAction
    {
        public int Add(int roleId, int emailActionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_EmailRoleAction(RoleId,ActionId)  values(");
            strSql.Append(" ?RoleId,?ActionId)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RoleId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ActionId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = roleId;
            parameters[1].Value = emailActionId;
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        public bool Delete(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_EmailRoleAction ");
            strSql.Append(" where RoleId=?RoleId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RoleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = roleId;
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
    }
}
