/**
* Comment.cs
*
* 功 能： N/A
* 类 名： Comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/1/30 18:33:35   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.CMS;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 数据访问类:Comment
    /// </summary>
    public partial class Comment : IComment
    {
        public Comment()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "CMS_Comment");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_Comment");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.CMS.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Comment(");
            strSql.Append("ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead,CreatedNickName)");
            strSql.Append(" values (");
            strSql.Append("?ContentId,?Description,?CreatedDate,?CreatedUserID,?ReplyCount,?ParentID,?TypeID,?State,?IsRead,?CreatedNickName)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
					new MySqlParameter("?State", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.ContentId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.ReplyCount;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.IsRead;
            parameters[9].Value = model.CreatedNickName;

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
        public bool Update(YSWL.MALL.Model.CMS.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Comment set ");
            strSql.Append("ContentId=?ContentId,");
            strSql.Append("Description=?Description,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("ReplyCount=?ReplyCount,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("TypeID=?TypeID,");
            strSql.Append("State=?State,");
            strSql.Append("IsRead=?IsRead,");
            strSql.Append("CreatedNickName=?CreatedNickName");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
					new MySqlParameter("?State", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ContentId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.ReplyCount;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.IsRead;
            parameters[9].Value = model.CreatedNickName;
            parameters[10].Value = model.ID;

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
            strSql.Append("delete from CMS_Comment ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
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
            strSql.Append("delete from CMS_Comment ");
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
        public YSWL.MALL.Model.CMS.Comment GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead,CreatedNickName from CMS_Comment ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.CMS.Comment model = new YSWL.MALL.Model.CMS.Comment();
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
        public YSWL.MALL.Model.CMS.Comment DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.CMS.Comment model = new YSWL.MALL.Model.CMS.Comment();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ContentId"] != null && row["ContentId"].ToString() != "")
                {
                    model.ContentId = int.Parse(row["ContentId"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["CreatedUserID"] != null && row["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(row["CreatedUserID"].ToString());
                }
                if (row["ReplyCount"] != null && row["ReplyCount"].ToString() != "")
                {
                    model.ReplyCount = int.Parse(row["ReplyCount"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    if ((row["State"].ToString() == "1") || (row["State"].ToString().ToLower() == "true"))
                    {
                        model.State = true;
                    }
                    else
                    {
                        model.State = false;
                    }
                }
                if (row["IsRead"] != null && row["IsRead"].ToString() != "")
                {
                    if ((row["IsRead"].ToString() == "1") || (row["IsRead"].ToString().ToLower() == "true"))
                    {
                        model.IsRead = true;
                    }
                    else
                    {
                        model.IsRead = false;
                    }
                }
                if (row["CreatedNickName"] != null)
                {
                    model.CreatedNickName = row["CreatedNickName"].ToString();
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
            strSql.Append("select ID,ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead,CreatedNickName ");
            strSql.Append(" FROM CMS_Comment ");
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
            
            strSql.Append(" ID,ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead,CreatedNickName ");
            strSql.Append(" FROM CMS_Comment ");
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
            strSql.Append("select count(1) FROM CMS_Comment ");
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
            strSql.Append("SELECT T.* from CMS_Comment T ");
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
                strSql.Append(" order by T.ID desc");
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
            parameters[0].Value = "CMS_Comment";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetListEx(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(" *,CMS_Content.Title ");
            strSql.Append(" FROM CMS_Comment LEFT JOIN CMS_Content ON CMS_Comment.ContentId = CMS_Content.ContentID");
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

        public int AddEx(YSWL.MALL.Model.CMS.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Comment(");
            strSql.Append("ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead,CreatedNickName)");
            strSql.Append(" values (");
            strSql.Append("?ContentId,?Description,?CreatedDate,?CreatedUserID,?ReplyCount,?ParentID,?TypeID,?State,?IsRead,?CreatedNickName)");
            strSql.Append(";set ?ReturnValue= last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
					new MySqlParameter("?State", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,200),
                     new MySqlParameter("?ReturnValue",MySqlDbType.Int32)};
            parameters[0].Value = model.ContentId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.ReplyCount;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.IsRead;
            parameters[9].Value = model.CreatedNickName;
            parameters[10].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("Update  CMS_Content ");
            strSql4.Append(" Set TotalComment=TotalComment+1 ");
            strSql4.Append(" where ContentID=?ContentID ");
            MySqlParameter[] parameters4 = {
                    	new MySqlParameter("?ContentID", MySqlDbType.Int32,4),
		          };
            parameters4[0].Value = model.ContentId;
            CommandInfo cmd4 = new CommandInfo(strSql4.ToString(), parameters4);
            sqllist.Add(cmd4);
            DbHelperMySQL.ExecuteSqlTran(sqllist);
            return (int)parameters[10].Value;
        }

        public int  AddTran(YSWL.MALL.Model.CMS.Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Comment(");
            strSql.Append("ContentId,Description,CreatedDate,CreatedUserID,ReplyCount,ParentID,TypeID,State,IsRead,CreatedNickName)");
            strSql.Append(" values (");
            strSql.Append("?ContentId,?Description,?CreatedDate,?CreatedUserID,?ReplyCount,?ParentID,?TypeID,?State,?IsRead,?CreatedNickName)");
            strSql.Append(";set ?ReturnValue= last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ContentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
					new MySqlParameter("?State", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRead", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,200),
                     new MySqlParameter("?ReturnValue",MySqlDbType.Int32)};
            parameters[0].Value = model.ContentId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CreatedDate;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.ReplyCount;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.TypeID;
            parameters[7].Value = model.State;
            parameters[8].Value = model.IsRead;
            parameters[9].Value = model.CreatedNickName;
            parameters[10].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            switch (model.TypeID)
            {
                case 2:
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("Update  CMS_Video ");
                    strSql2.Append(" Set TotalComment=TotalComment+1 ");
                    strSql2.Append(" where VideoID=?VideoID ");
                    MySqlParameter[] parameters2 = {
                    	new MySqlParameter("?VideoID", MySqlDbType.Int32,4),
		          };
                    parameters2[0].Value = model.ContentId;
                    CommandInfo cmd2 = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd2);
                    break;
                case 3:
                    StringBuilder strSql4 = new StringBuilder();
                    strSql4.Append("Update  CMS_Content ");
                    strSql4.Append(" Set TotalComment=TotalComment+1 ");
                    strSql4.Append(" where ContentID=?ContentID ");
                    MySqlParameter[] parameters4 = {
                    	new MySqlParameter("?ContentID", MySqlDbType.Int32,4),
		          };
                    parameters4[0].Value = model.ContentId;
                    CommandInfo cmd4 = new CommandInfo(strSql4.ToString(), parameters4);
                    sqllist.Add(cmd4);
                    break;
                default:
                    break;
            }
            DbHelperMySQL.ExecuteSqlTran(sqllist);
            return (int)parameters[10].Value;
       
        }

        /// <summary>
        /// 批量更新状态
        /// </summary>
        /// <param name="IDlist">id列表</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, int state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Comment set ");
            strSql.Append("State=?State");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?State", MySqlDbType.Bit,1)};
            parameters[0].Value = state;
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
        #endregion  ExtensionMethod
    }
}

