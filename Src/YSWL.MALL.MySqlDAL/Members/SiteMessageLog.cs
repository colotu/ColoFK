using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:SiteMessageLog
    /// </summary>
    public partial class SiteMessageLog : ISiteMessageLog
    {
        public SiteMessageLog()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "SA_SiteMessageLog");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_SiteMessageLog");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.SiteMessageLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_SiteMessageLog(");
            strSql.Append("MessageID,MessageType,MessageState,ReceiverID,Ext1,Ext2,ReceiverUserName)");
            strSql.Append(" values (");
            strSql.Append("?MessageID,?MessageType,?MessageState,?ReceiverID,?Ext1,?Ext2,?ReceiverUserName)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?MessageID",  MySqlDbType.Int32,4),
					new MySqlParameter("?MessageType", MySqlDbType.VarString,50),
					new MySqlParameter("?MessageState", MySqlDbType.VarString,50),
					new MySqlParameter("?ReceiverID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Ext1", MySqlDbType.VarString,300),
					new MySqlParameter("?Ext2", MySqlDbType.VarString,300),
					new MySqlParameter("?ReceiverUserName", MySqlDbType.VarString,100)};
            parameters[0].Value = model.MessageID;
            parameters[1].Value = model.MessageType;
            parameters[2].Value = model.MessageState;
            parameters[3].Value = model.ReceiverID;
            parameters[4].Value = model.Ext1;
            parameters[5].Value = model.Ext2;
            parameters[6].Value = model.ReceiverUserName;

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
        public bool Update(YSWL.MALL.Model.Members.SiteMessageLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_SiteMessageLog set ");
            strSql.Append("MessageID=?MessageID,");
            strSql.Append("MessageType=?MessageType,");
            strSql.Append("MessageState=?MessageState,");
            strSql.Append("ReceiverID=?ReceiverID,");
            strSql.Append("Ext1=?Ext1,");
            strSql.Append("Ext2=?Ext2,");
            strSql.Append("ReceiverUserName=?ReceiverUserName");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?MessageID",  MySqlDbType.Int32,4),
					new MySqlParameter("?MessageType", MySqlDbType.VarString,50),
					new MySqlParameter("?MessageState", MySqlDbType.VarString,50),
					new MySqlParameter("?ReceiverID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Ext1", MySqlDbType.VarString,300),
					new MySqlParameter("?Ext2", MySqlDbType.VarString,300),
					new MySqlParameter("?ReceiverUserName", MySqlDbType.VarString,100),
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.MessageID;
            parameters[1].Value = model.MessageType;
            parameters[2].Value = model.MessageState;
            parameters[3].Value = model.ReceiverID;
            parameters[4].Value = model.Ext1;
            parameters[5].Value = model.Ext2;
            parameters[6].Value = model.ReceiverUserName;
            parameters[7].Value = model.ID;

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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_SiteMessageLog ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_SiteMessageLog ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public YSWL.MALL.Model.Members.SiteMessageLog GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ID,MessageID,MessageType,MessageState,ReceiverID,Ext1,Ext2,ReceiverUserName from SA_SiteMessageLog ");
            strSql.Append(" where ID=?ID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

            YSWL.MALL.Model.Members.SiteMessageLog model = new YSWL.MALL.Model.Members.SiteMessageLog();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MessageID"] != null && ds.Tables[0].Rows[0]["MessageID"].ToString() != "")
                {
                    model.MessageID = int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MessageType"] != null && ds.Tables[0].Rows[0]["MessageType"].ToString() != "")
                {
                    model.MessageType = ds.Tables[0].Rows[0]["MessageType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MessageState"] != null && ds.Tables[0].Rows[0]["MessageState"].ToString() != "")
                {
                    model.MessageState = ds.Tables[0].Rows[0]["MessageState"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReceiverID"] != null && ds.Tables[0].Rows[0]["ReceiverID"].ToString() != "")
                {
                    model.ReceiverID = int.Parse(ds.Tables[0].Rows[0]["ReceiverID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Ext1"] != null && ds.Tables[0].Rows[0]["Ext1"].ToString() != "")
                {
                    model.Ext1 = ds.Tables[0].Rows[0]["Ext1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Ext2"] != null && ds.Tables[0].Rows[0]["Ext2"].ToString() != "")
                {
                    model.Ext2 = ds.Tables[0].Rows[0]["Ext2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReceiverUserName"] != null && ds.Tables[0].Rows[0]["ReceiverUserName"].ToString() != "")
                {
                    model.ReceiverUserName = ds.Tables[0].Rows[0]["ReceiverUserName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MessageID,MessageType,MessageState,ReceiverID,Ext1,Ext2,ReceiverUserName ");
            strSql.Append(" FROM SA_SiteMessageLog ");
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
            strSql.Append(" ID,MessageID,MessageType,MessageState,ReceiverID,Ext1,Ext2,ReceiverUserName ");
            strSql.Append(" FROM SA_SiteMessageLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT  " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SA_SiteMessageLog ");
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
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append(" order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append(" order by T.ID desc");
            //}
            //strSql.Append(")AS Row, T.*  from SA_SiteMessageLog T ");
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*  from SA_SiteMessageLog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.ID desc");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
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
                    new MySqlParameter("?PageSize",  MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex",  MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SA_SiteMessageLog";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method
    }
}