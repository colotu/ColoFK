using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.Model.SysManage;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.SysManage
{
    /// <summary>
    /// DAL base on MySqlParameter
    /// </summary>
    public class SysTree : YSWL.MALL.IDAL.SysManage.ISysTree
    {
        public int AddTreeNode(SysNode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Tree(");
            strSql.Append("TreeText,ParentID,Location,OrderID,comment,Url,PermissionID,ImageUrl,TreeType,Enabled)");
            strSql.Append(" values (");
            strSql.Append("?TreeText,?ParentID,?Location,?OrderID,?comment,?Url,?PermissionID,?ImageUrl,?TreeType,?Enabled)");
            MySqlParameter[] parameters = {
											new MySqlParameter("?TreeText", MySqlDbType.VarChar,100),
											new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
											new MySqlParameter("?Location", MySqlDbType.VarChar,50),
											new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
											new MySqlParameter("?comment", MySqlDbType.VarChar,50),
											new MySqlParameter("?Url", MySqlDbType.VarChar,100),
											new MySqlParameter("?PermissionID",  MySqlDbType.Int32,4),
											new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,100),
											new MySqlParameter("?TreeType", MySqlDbType.Int16),
											new MySqlParameter("?Enabled", MySqlDbType.Bit)};

            parameters[0].Value = model.TreeText;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Location;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.Comment;
            parameters[5].Value = model.Url;
            parameters[6].Value = model.PermissionID;
            parameters[7].Value = model.ImageUrl;
            parameters[8].Value = model.TreeType;
            parameters[9].Value = model.Enabled;

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

        public void UpdateNode(SysNode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Tree set ");
            strSql.Append("TreeText=?TreeText,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("Location=?Location,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("comment=?comment,");
            strSql.Append("Url=?Url,");
            strSql.Append("PermissionID=?PermissionID,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("TreeType=?TreeType,");
            strSql.Append("Enabled=?Enabled");
            strSql.Append(" where NodeID=?NodeID");

            MySqlParameter[] parameters = {
											new MySqlParameter("?NodeID",  MySqlDbType.Int32,4),
											new MySqlParameter("?TreeText", MySqlDbType.VarChar,100),
											new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
											new MySqlParameter("?Location", MySqlDbType.VarChar,50),
											new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
											new MySqlParameter("?comment", MySqlDbType.VarChar,50),
											new MySqlParameter("?Url", MySqlDbType.VarChar,100),
											new MySqlParameter("?PermissionID",  MySqlDbType.Int32,4),
											new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,100),
											new MySqlParameter("?TreeType", MySqlDbType.Int16),
											new MySqlParameter("?Enabled", MySqlDbType.Bit)};
            parameters[0].Value = model.NodeID;
            parameters[1].Value = model.TreeText;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Location;
            parameters[4].Value = model.OrderID;
            parameters[5].Value = model.Comment;
            parameters[6].Value = model.Url;
            parameters[7].Value = model.PermissionID;
            parameters[8].Value = model.ImageUrl;
            parameters[9].Value = model.TreeType;
            parameters[10].Value = model.Enabled;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DelTreeNode(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Tree ");
            strSql.Append(" where NodeID=?NodeID");

            MySqlParameter[] parameters = {
											new MySqlParameter("?NodeID",  MySqlDbType.Int32,4)
										};
            parameters[0].Value = NodeID;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void DelTreeNodes(string nodeidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Tree ");
            strSql.Append(" where NodeID in(" + nodeidlist + ")");
            DbHelperMySQL.ExecuteSql(strSql.ToString());
        }

        public void MoveNodes(string nodeidlist, int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Tree set ");
            strSql.Append("ParentID=" + ParentID);
            strSql.Append(" where NodeID in(" + nodeidlist + ")");

            DbHelperMySQL.ExecuteSql(strSql.ToString());
        }

        public DataSet GetTreeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Tree ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by parentid,orderid ");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        public int GetPermissionCatalogID(int permissionID)
        {
            string sql = "select CategoryID from Accounts_Permissions where PermissionID=" + permissionID;
            object res = DbHelperMySQL.GetSingle(sql);
            if (res == null)
            {
                return 0;
            }
            return (int)res;
        }

        /// <summary>
        /// Get Menu Node
        /// </summary>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public SysNode GetNode(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Tree ");
            strSql.Append(" where NodeID=?NodeID");

            MySqlParameter[] parameters = {
											new MySqlParameter("?NodeID",  MySqlDbType.Int32,4)
										};
            parameters[0].Value = NodeID;

            SysNode node = new SysNode();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                node.NodeID = int.Parse(ds.Tables[0].Rows[0]["NodeID"].ToString());
                node.TreeText = ds.Tables[0].Rows[0]["TreeText"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    node.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                node.Location = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    node.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                node.Comment = ds.Tables[0].Rows[0]["comment"].ToString();
                node.Url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["PermissionID"].ToString() != "")
                {
                    node.PermissionID = int.Parse(ds.Tables[0].Rows[0]["PermissionID"].ToString());
                }
                node.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                node.TreeType = int.Parse(ds.Tables[0].Rows[0]["TreeType"].ToString());
                node.Enabled = bool.Parse(ds.Tables[0].Rows[0]["Enabled"].ToString());
                return node;
            }
            else
            {
                return null;
            }
        }

        #region 日志

        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="time"></param>
        /// <param name="loginfo"></param>
        public void AddLog(string time, string loginfo, string Particular)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Log(");
            strSql.Append("datetime,loginfo,Particular)");
            strSql.Append(" values (");
            strSql.Append("'" + time + "',");
            strSql.Append("'" + loginfo + "',");
            strSql.Append("'" + Particular + "'");
            strSql.Append(")");
            DbHelperMySQL.ExecuteSql(strSql.ToString());
        }

        public void DeleteLog(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Log ");
            strSql.Append(" where ID= " + ID);
            DbHelperMySQL.ExecuteSql(strSql.ToString());
        }

        public void DelOverdueLog(int days)
        {
            string str = " DATEDIFF(datetime,now())>" + days;
            DeleteLog(str);
        }

        public void DeleteLog(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperMySQL.ExecuteSql(strSql.ToString());
        }

        public DataSet GetLogs(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID DESC");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataRow GetLog(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SA_Log ");
            strSql.Append(" where ID= " + ID);
            return DbHelperMySQL.Query(strSql.ToString()).Tables[0].Rows[0];
        }
        /// <summary>
        /// 修改启用状态
        /// </summary>
        /// <param name="nodeid"></param>
        public void UpdateEnabled(int nodeid)
        {
            //UPDATE SA_Tree SET Enabled=(Enabled+1)%2 WHERE NodeID=12
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Tree set ");
            strSql.Append("Enabled=(Enabled+1)%2");
            strSql.Append(" where NodeID=?NodeID");
            MySqlParameter[] parameters = {
											new MySqlParameter("?NodeID", MySqlDbType.Int32,4),
										 };
            parameters[0].Value = nodeid;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion 日志


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.SysManage.SysNode DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.SysManage.SysNode model = new YSWL.MALL.Model.SysManage.SysNode();
            if (row != null)
            {
                if (row["NodeID"] != null && row["NodeID"].ToString() != "")
                {
                    model.NodeID = int.Parse(row["NodeID"].ToString());
                }
                if (row["TreeText"] != null)
                {
                    model.TreeText = row["TreeText"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["ParentPath"] != null)
                {
                    model.ParentPath = row["ParentPath"].ToString();
                }
                if (row["Location"] != null)
                {
                    model.Location = row["Location"].ToString();
                }
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["Comment"] != null)
                {
                    model.Comment = row["Comment"].ToString();
                }
                if (row["Url"] != null)
                {
                    model.Url = row["Url"].ToString();
                }
                if (row["PermissionID"] != null && row["PermissionID"].ToString() != "")
                {
                    model.PermissionID = int.Parse(row["PermissionID"].ToString());
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["ModuleID"] != null && row["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(row["ModuleID"].ToString());
                }
                if (row["KeShiDM"] != null && row["KeShiDM"].ToString() != "")
                {
                    model.KeShiDM = int.Parse(row["KeShiDM"].ToString());
                }
                if (row["KeshiPublic"] != null)
                {
                    model.KeshiPublic = row["KeshiPublic"].ToString();
                }
                if (row["TreeType"] != null && row["TreeType"].ToString() != "")
                {
                    model.TreeType = int.Parse(row["TreeType"].ToString());
                }
                if (row["Enabled"] != null && row["Enabled"].ToString() != "")
                {
                    if ((row["Enabled"].ToString() == "1") || (row["Enabled"].ToString().ToLower() == "true"))
                    {
                        model.Enabled = true;
                    }
                    else
                    {
                        model.Enabled = false;
                    }
                }
            }
            return model;
        }

    }
}