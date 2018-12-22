/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：SEORelation.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/10/15 10:50:22
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Settings;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Settings
{
    /// <summary>
    /// 数据访问类:SEORelation
    /// </summary>
    public partial class SEORelation : ISEORelation
    {
        public SEORelation()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("RelationID", "Ms_SEORelation");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RelationID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Ms_SEORelation");
            strSql.Append(" WHERE RelationID=?RelationID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelationID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = RelationID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Settings.SEORelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT intO Ms_SEORelation(");
            strSql.Append("KeyName,LinkURL,IsCMS,IsShop,IsSNS,IsComment,CreatedDate,IsActive)");
            strSql.Append(" VALUES (");
            strSql.Append("?KeyName,?LinkURL,?IsCMS,?IsShop,?IsSNS,?IsComment,?CreatedDate,?IsActive)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyName", MySqlDbType.VarString,200),
					new MySqlParameter("?LinkURL", MySqlDbType.VarString,500),
					new MySqlParameter("?IsCMS", MySqlDbType.Bit,1),
					new MySqlParameter("?IsShop", MySqlDbType.Bit,1),
					new MySqlParameter("?IsSNS", MySqlDbType.Bit,1),
					new MySqlParameter("?IsComment", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsActive", MySqlDbType.Bit,1)};
            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.LinkURL;
            parameters[2].Value = model.IsCMS;
            parameters[3].Value = model.IsShop;
            parameters[4].Value = model.IsSNS;
            parameters[5].Value = model.IsComment;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.IsActive;

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
        public bool Update(YSWL.MALL.Model.Settings.SEORelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Ms_SEORelation SET ");
            strSql.Append("KeyName=?KeyName,");
            strSql.Append("LinkURL=?LinkURL,");
            strSql.Append("IsCMS=?IsCMS,");
            strSql.Append("IsShop=?IsShop,");
            strSql.Append("IsSNS=?IsSNS,");
            strSql.Append("IsComment=?IsComment,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("IsActive=?IsActive");
            strSql.Append(" WHERE RelationID=?RelationID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyName", MySqlDbType.VarString,200),
					new MySqlParameter("?LinkURL", MySqlDbType.VarString,500),
					new MySqlParameter("?IsCMS", MySqlDbType.Bit,1),
					new MySqlParameter("?IsShop", MySqlDbType.Bit,1),
					new MySqlParameter("?IsSNS", MySqlDbType.Bit,1),
					new MySqlParameter("?IsComment", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsActive", MySqlDbType.Bit,1),
					new MySqlParameter("?RelationID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.KeyName;
            parameters[1].Value = model.LinkURL;
            parameters[2].Value = model.IsCMS;
            parameters[3].Value = model.IsShop;
            parameters[4].Value = model.IsSNS;
            parameters[5].Value = model.IsComment;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.IsActive;
            parameters[8].Value = model.RelationID;

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
        public bool Delete(int RelationID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Ms_SEORelation ");
            strSql.Append(" WHERE RelationID=?RelationID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelationID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = RelationID;

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
        public bool DeleteList(string RelationIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Ms_SEORelation ");
            strSql.Append(" WHERE RelationID in (" + RelationIDlist + ")  ");
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
        public YSWL.MALL.Model.Settings.SEORelation GetModel(int RelationID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT    RelationID,KeyName,LinkURL,IsCMS,IsShop,IsSNS,IsComment,CreatedDate,IsActive FROM Ms_SEORelation ");
            strSql.Append(" WHERE RelationID=?RelationID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RelationID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = RelationID;

            YSWL.MALL.Model.Settings.SEORelation model = new YSWL.MALL.Model.Settings.SEORelation();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RelationID"] != null && ds.Tables[0].Rows[0]["RelationID"].ToString() != "")
                {
                    model.RelationID = int.Parse(ds.Tables[0].Rows[0]["RelationID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KeyName"] != null && ds.Tables[0].Rows[0]["KeyName"].ToString() != "")
                {
                    model.KeyName = ds.Tables[0].Rows[0]["KeyName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkURL"] != null && ds.Tables[0].Rows[0]["LinkURL"].ToString() != "")
                {
                    model.LinkURL = ds.Tables[0].Rows[0]["LinkURL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsCMS"] != null && ds.Tables[0].Rows[0]["IsCMS"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsCMS"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsCMS"].ToString().ToLower() == "true"))
                    {
                        model.IsCMS = true;
                    }
                    else
                    {
                        model.IsCMS = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsShop"] != null && ds.Tables[0].Rows[0]["IsShop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsShop"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsShop"].ToString().ToLower() == "true"))
                    {
                        model.IsShop = true;
                    }
                    else
                    {
                        model.IsShop = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsSNS"] != null && ds.Tables[0].Rows[0]["IsSNS"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsSNS"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsSNS"].ToString().ToLower() == "true"))
                    {
                        model.IsSNS = true;
                    }
                    else
                    {
                        model.IsSNS = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsComment"] != null && ds.Tables[0].Rows[0]["IsComment"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsComment"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsComment"].ToString().ToLower() == "true"))
                    {
                        model.IsComment = true;
                    }
                    else
                    {
                        model.IsComment = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsActive"] != null && ds.Tables[0].Rows[0]["IsActive"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsActive"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsActive"].ToString().ToLower() == "true"))
                    {
                        model.IsActive = true;
                    }
                    else
                    {
                        model.IsActive = false;
                    }
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
            strSql.Append("SELECT RelationID,KeyName,LinkURL,IsCMS,IsShop,IsSNS,IsComment,CreatedDate,IsActive ");
            strSql.Append(" FROM Ms_SEORelation ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(" RelationID,KeyName,LinkURL,IsCMS,IsShop,IsSNS,IsComment,CreatedDate,IsActive ");
            strSql.Append(" FROM Ms_SEORelation ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
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
            strSql.Append("SELECT COUNT(1) FROM Ms_SEORelation ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
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
            strSql.Append("SELECT T.*  FROM Ms_SEORelation T ");
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
                strSql.Append(" order by T.RelationID desc");
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
            parameters[0].Value = "Ms_SEORelation";
            parameters[1].Value = "RelationID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Ms_SEORelation");
            strSql.Append(" WHERE KeyName=?KeyName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?KeyName", MySqlDbType.VarChar,200)
			};
            parameters[0].Value = name;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
    }
}