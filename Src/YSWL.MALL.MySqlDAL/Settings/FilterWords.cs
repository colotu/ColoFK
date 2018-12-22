/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：FilterWords.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/08/24 11:00:36
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Settings;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Settings
{
    /// <summary>
    /// 数据访问类:FilterWords
    /// </summary>
    public partial class FilterWords : IFilterWords
    {
        public FilterWords()
        { }

        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("FilterId", "SA_FilterWords");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FilterId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_FilterWords");
            strSql.Append(" where FilterId=?FilterId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FilterId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = FilterId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Settings.FilterWords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_FilterWords(");
            strSql.Append("WordPattern,ActionType,RepalceWord)");
            strSql.Append(" values (");
            strSql.Append("?WordPattern,?ActionType,?RepalceWord)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WordPattern", MySqlDbType.VarChar,100),
					new MySqlParameter("?ActionType", MySqlDbType.Int32,4),
					new MySqlParameter("?RepalceWord", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.WordPattern;
            parameters[1].Value = model.ActionType;
            parameters[2].Value = model.RepalceWord;

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
        public bool Update(YSWL.MALL.Model.Settings.FilterWords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_FilterWords set ");
            strSql.Append("WordPattern=?WordPattern,");
            strSql.Append("ActionType=?ActionType,");
            strSql.Append("RepalceWord=?RepalceWord");
            strSql.Append(" where FilterId=?FilterId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WordPattern", MySqlDbType.VarChar,100),
					new MySqlParameter("?ActionType", MySqlDbType.Int32,4),
					new MySqlParameter("?RepalceWord", MySqlDbType.VarChar,100),
					new MySqlParameter("?FilterId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.WordPattern;
            parameters[1].Value = model.ActionType;
            parameters[2].Value = model.RepalceWord;
            parameters[3].Value = model.FilterId;

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
        public bool Delete(int FilterId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_FilterWords ");
            strSql.Append(" where FilterId=?FilterId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FilterId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = FilterId;

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
        public bool DeleteList(string FilterIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_FilterWords ");
            strSql.Append(" where FilterId in (" + FilterIdlist + ")  ");
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
        public YSWL.MALL.Model.Settings.FilterWords GetModel(int FilterId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  FilterId,WordPattern,ActionType,RepalceWord from SA_FilterWords ");
            strSql.Append(" where FilterId=?FilterId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FilterId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = FilterId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Settings.FilterWords model = new YSWL.MALL.Model.Settings.FilterWords();
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
        public YSWL.MALL.Model.Settings.FilterWords DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Settings.FilterWords model = new YSWL.MALL.Model.Settings.FilterWords();
            if (row != null)
            {
                if (row["FilterId"] != null && row["FilterId"].ToString() != "")
                {
                    model.FilterId = int.Parse(row["FilterId"].ToString());
                }
                if (row["WordPattern"] != null)
                {
                    model.WordPattern = row["WordPattern"].ToString();
                }
                if (row["ActionType"] != null && row["ActionType"].ToString() != "")
                {
                    model.ActionType = int.Parse(row["ActionType"].ToString());
                }
                if (row["RepalceWord"] != null)
                {
                    model.RepalceWord = row["RepalceWord"].ToString();
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
            strSql.Append("select FilterId,WordPattern,ActionType,RepalceWord ");
            strSql.Append(" FROM SA_FilterWords ");
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
            
            strSql.Append(" FilterId,WordPattern,ActionType,RepalceWord ");
            strSql.Append(" FROM SA_FilterWords ");
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
            strSql.Append("select count(1) FROM SA_FilterWords ");
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
            strSql.Append("SELECT T.* from SA_FilterWords T ");
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
                strSql.Append(" order by T.FilterId desc");
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
            parameters[0].Value = "SA_FilterWords";
            parameters[1].Value = "FilterId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region 扩展方法

        public Model.Settings.FilterWords GetByWordPattern(string wordPattern)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FilterId,WordPattern,ActionType,RepalceWord from SA_FilterWords ");
            strSql.Append(" where WordPattern='?WordPattern'");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WordPattern", MySqlDbType.VarChar,100)
			};
            parameters[0].Value = wordPattern;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Settings.FilterWords model = new YSWL.MALL.Model.Settings.FilterWords();
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

        public bool UpdateActionType(string ids, int type, string replace)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_FilterWords set ");
            strSql.Append("ActionType=?ActionType,RepalceWord=?RepalceWord");
            strSql.Append(" where FilterId in (" + ids + ")  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionType", MySqlDbType.Int32,4),
                    	new MySqlParameter("?RepalceWord", MySqlDbType.VarChar,100)
                                        };
            parameters[0].Value = type;
            parameters[1].Value = replace;

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

        public bool Exists(string word)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_FilterWords");
            strSql.Append(" where WordPattern=?WordPattern");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WordPattern", MySqlDbType.VarChar,100)
			};
            parameters[0].Value = word;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        #endregion
    }
}