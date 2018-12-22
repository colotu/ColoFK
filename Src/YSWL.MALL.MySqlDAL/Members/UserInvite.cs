/**
* UserInvite.cs
*
* 功 能： N/A
* 类 名： UserInvite
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/7/9 13:49:11   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Members;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:UserInvite
    /// </summary>
    public partial class UserInvite : IUserInvite
    {
        public UserInvite()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("InviteId", "Accounts_UserInvite");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int InviteId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UserInvite");
            strSql.Append(" where InviteId=?InviteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?InviteId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = InviteId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.UserInvite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserInvite(");
            strSql.Append("UserId,UserNick,InviteUserId,InviteNick,IsRebate,IsNew,CreatedDate,Remark,RebateDesc)");
            strSql.Append(" values (");
            strSql.Append("?UserId,?UserNick,?InviteUserId,?InviteNick,?IsRebate,?IsNew,?CreatedDate,?Remark,?RebateDesc)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserNick", MySqlDbType.VarChar,200),
					new MySqlParameter("?InviteUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?InviteNick", MySqlDbType.VarChar,200),
					new MySqlParameter("?IsRebate", MySqlDbType.Bit,1),
					new MySqlParameter("?IsNew", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?RebateDesc", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.UserNick;
            parameters[2].Value = model.InviteUserId;
            parameters[3].Value = model.InviteNick;
            parameters[4].Value = model.IsRebate;
            parameters[5].Value = model.IsNew;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.RebateDesc;

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
        public bool Update(YSWL.MALL.Model.Members.UserInvite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UserInvite set ");
            strSql.Append("UserId=?UserId,");
            strSql.Append("UserNick=?UserNick,");
            strSql.Append("InviteUserId=?InviteUserId,");
            strSql.Append("InviteNick=?InviteNick,");
            strSql.Append("IsRebate=?IsRebate,");
            strSql.Append("IsNew=?IsNew,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("RebateDesc=?RebateDesc");
            strSql.Append(" where InviteId=?InviteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserNick", MySqlDbType.VarChar,200),
					new MySqlParameter("?InviteUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?InviteNick", MySqlDbType.VarChar,200),
					new MySqlParameter("?IsRebate", MySqlDbType.Bit,1),
					new MySqlParameter("?IsNew", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?RebateDesc", MySqlDbType.VarChar,200),
					new MySqlParameter("?InviteId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserId;
            parameters[1].Value = model.UserNick;
            parameters[2].Value = model.InviteUserId;
            parameters[3].Value = model.InviteNick;
            parameters[4].Value = model.IsRebate;
            parameters[5].Value = model.IsNew;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.RebateDesc;
            parameters[9].Value = model.InviteId;

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
        public bool Delete(int InviteId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UserInvite ");
            strSql.Append(" where InviteId=?InviteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?InviteId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = InviteId;

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
        public bool DeleteList(string InviteIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_UserInvite ");
            strSql.Append(" where InviteId in (" + InviteIdlist + ")  ");
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
        public YSWL.MALL.Model.Members.UserInvite GetModel(int InviteId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select InviteId,UserId,UserNick,InviteUserId,InviteNick,IsRebate,IsNew,CreatedDate,Remark,RebateDesc from Accounts_UserInvite ");
            strSql.Append(" where InviteId=?InviteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?InviteId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = InviteId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.UserInvite model = new YSWL.MALL.Model.Members.UserInvite();
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
        public YSWL.MALL.Model.Members.UserInvite DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.UserInvite model = new YSWL.MALL.Model.Members.UserInvite();
            if (row != null)
            {
                if (row["InviteId"] != null && row["InviteId"].ToString() != "")
                {
                    model.InviteId = int.Parse(row["InviteId"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserNick"] != null)
                {
                    model.UserNick = row["UserNick"].ToString();
                }
                if (row["InviteUserId"] != null && row["InviteUserId"].ToString() != "")
                {
                    model.InviteUserId = int.Parse(row["InviteUserId"].ToString());
                }
                if (row["InviteNick"] != null)
                {
                    model.InviteNick = row["InviteNick"].ToString();
                }
                if (row["IsRebate"] != null && row["IsRebate"].ToString() != "")
                {
                    if ((row["IsRebate"].ToString() == "1") || (row["IsRebate"].ToString().ToLower() == "true"))
                    {
                        model.IsRebate = true;
                    }
                    else
                    {
                        model.IsRebate = false;
                    }
                }
                if (row["IsNew"] != null && row["IsNew"].ToString() != "")
                {
                    if ((row["IsNew"].ToString() == "1") || (row["IsNew"].ToString().ToLower() == "true"))
                    {
                        model.IsNew = true;
                    }
                    else
                    {
                        model.IsNew = false;
                    }
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["RebateDesc"] != null)
                {
                    model.RebateDesc = row["RebateDesc"].ToString();
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
            strSql.Append("select InviteId,UserId,UserNick,InviteUserId,InviteNick,IsRebate,IsNew,CreatedDate,Remark,RebateDesc ");
            strSql.Append(" FROM Accounts_UserInvite ");
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
           
            strSql.Append(" InviteId,UserId,UserNick,InviteUserId,InviteNick,IsRebate,IsNew,CreatedDate,Remark,RebateDesc ");
            strSql.Append(" FROM Accounts_UserInvite ");
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
            strSql.Append("select count(1) FROM Accounts_UserInvite ");
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
            strSql.Append("SELECT T.* from Accounts_UserInvite T ");
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
                strSql.Append(" order by T.InviteId desc");
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
            parameters[0].Value = "Accounts_UserInvite";
            parameters[1].Value = "InviteId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool UpdateStatus(int InviteId, int Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UserInvite set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where InviteId=?InviteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?InviteId", MySqlDbType.Int32,4)};
            parameters[0].Value = Status;
            parameters[1].Value = InviteId;

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


        public YSWL.MALL.Model.Members.UserInvite GetModelEx(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDepthAndPath(int UserId, int depth, string path)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion  ExtensionMethod
    }
}

