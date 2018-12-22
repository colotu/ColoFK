﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.SNS;
using YSWL.DBUtility;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
    /// <summary>
    /// 数据访问类:CategorySource
    /// </summary>
    public partial class CategorySource : ICategorySource
    {
        public CategorySource()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("SourceId", "SNS_CategorySource");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SourceId, int CategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SNS_CategorySource");
            strSql.Append(" where SourceId=?SourceId and CategoryId=?CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SourceId", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4)			};
            parameters[0].Value = SourceId;
            parameters[1].Value = CategoryId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.SNS.CategorySource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_CategorySource(");
            strSql.Append("SourceId,CategoryId,Name,Description,ParentID,Path,Depth,Sequence,HasChildren,IsMenu,Type,MenuIsShow,MenuSequence,CreatedUserID,CreatedDate,Status,SnsCategoryId)");
            strSql.Append(" values (");
            strSql.Append("?SourceId,?CategoryId,?Name,?Description,?ParentID,?Path,?Depth,?Sequence,?HasChildren,?IsMenu,?Type,?MenuIsShow,?MenuSequence,?CreatedUserID,?CreatedDate,?Status,?SnsCategoryId)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SourceId", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,50),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1),
					new MySqlParameter("?IsMenu", MySqlDbType.Bit,1),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?MenuIsShow", MySqlDbType.Bit,1),
					new MySqlParameter("?MenuSequence", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?SnsCategoryId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.SourceId;
            parameters[1].Value = model.CategoryId;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.Path;
            parameters[6].Value = model.Depth;
            parameters[7].Value = model.Sequence;
            parameters[8].Value = model.HasChildren;
            parameters[9].Value = model.IsMenu;
            parameters[10].Value = model.Type;
            parameters[11].Value = model.MenuIsShow;
            parameters[12].Value = model.MenuSequence;
            parameters[13].Value = model.CreatedUserID;
            parameters[14].Value = model.CreatedDate;
            parameters[15].Value = model.Status;
            parameters[16].Value = model.SnsCategoryId;

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
        public bool Update(YSWL.MALL.Model.SNS.CategorySource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_CategorySource set ");
            strSql.Append("Name=?Name,");
            strSql.Append("Description=?Description,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("Path=?Path,");
            strSql.Append("Depth=?Depth,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("HasChildren=?HasChildren,");
            strSql.Append("IsMenu=?IsMenu,");
            strSql.Append("Type=?Type,");
            strSql.Append("MenuIsShow=?MenuIsShow,");
            strSql.Append("MenuSequence=?MenuSequence,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Status=?Status,");
            strSql.Append("SnsCategoryId=?SnsCategoryId");
            strSql.Append(" where SourceId=?SourceId and CategoryId=?CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,50),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,50),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1),
					new MySqlParameter("?IsMenu", MySqlDbType.Bit,1),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?MenuIsShow", MySqlDbType.Bit,1),
					new MySqlParameter("?MenuSequence", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?SnsCategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?SourceId", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.Sequence;
            parameters[6].Value = model.HasChildren;
            parameters[7].Value = model.IsMenu;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.MenuIsShow;
            parameters[10].Value = model.MenuSequence;
            parameters[11].Value = model.CreatedUserID;
            parameters[12].Value = model.CreatedDate;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.SnsCategoryId;
            parameters[15].Value = model.SourceId;
            parameters[16].Value = model.CategoryId;

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
        public bool Delete(int SourceId, int CategoryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_CategorySource ");
            strSql.Append(" where SourceId=?SourceId and CategoryId=?CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SourceId", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4)			};
            parameters[0].Value = SourceId;
            parameters[1].Value = CategoryId;

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
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.SNS.CategorySource GetModel(int SourceId, int CategoryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SourceId,CategoryId,Name,Description,ParentID,Path,Depth,Sequence,HasChildren,IsMenu,Type,MenuIsShow,MenuSequence,CreatedUserID,CreatedDate,Status,SnsCategoryId from SNS_CategorySource ");
            strSql.Append(" where SourceId=?SourceId and CategoryId=?CategoryId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SourceId", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4)			};
            parameters[0].Value = SourceId;
            parameters[1].Value = CategoryId;

            YSWL.MALL.Model.SNS.CategorySource model = new YSWL.MALL.Model.SNS.CategorySource();
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
        public YSWL.MALL.Model.SNS.CategorySource DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.SNS.CategorySource model = new YSWL.MALL.Model.SNS.CategorySource();
            if (row != null)
            {
                if (row["SourceId"] != null && row["SourceId"].ToString() != "")
                {
                    model.SourceId = int.Parse(row["SourceId"].ToString());
                }
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(row["CategoryId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(row["ParentID"].ToString());
                }
                if (row["Path"] != null)
                {
                    model.Path = row["Path"].ToString();
                }
                if (row["Depth"] != null && row["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(row["Depth"].ToString());
                }
                if (row["Sequence"] != null && row["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(row["Sequence"].ToString());
                }
                if (row["HasChildren"] != null && row["HasChildren"].ToString() != "")
                {
                    if ((row["HasChildren"].ToString() == "1") || (row["HasChildren"].ToString().ToLower() == "true"))
                    {
                        model.HasChildren = true;
                    }
                    else
                    {
                        model.HasChildren = false;
                    }
                }
                if (row["IsMenu"] != null && row["IsMenu"].ToString() != "")
                {
                    if ((row["IsMenu"].ToString() == "1") || (row["IsMenu"].ToString().ToLower() == "true"))
                    {
                        model.IsMenu = true;
                    }
                    else
                    {
                        model.IsMenu = false;
                    }
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["MenuIsShow"] != null && row["MenuIsShow"].ToString() != "")
                {
                    if ((row["MenuIsShow"].ToString() == "1") || (row["MenuIsShow"].ToString().ToLower() == "true"))
                    {
                        model.MenuIsShow = true;
                    }
                    else
                    {
                        model.MenuIsShow = false;
                    }
                }
                if (row["MenuSequence"] != null && row["MenuSequence"].ToString() != "")
                {
                    model.MenuSequence = int.Parse(row["MenuSequence"].ToString());
                }
                if (row["CreatedUserID"] != null && row["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(row["CreatedUserID"].ToString());
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["SnsCategoryId"] != null && row["SnsCategoryId"].ToString() != "")
                {
                    model.SnsCategoryId = int.Parse(row["SnsCategoryId"].ToString());
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
            strSql.Append("select SourceId,CategoryId,Name,Description,ParentID,Path,Depth,Sequence,HasChildren,IsMenu,Type,MenuIsShow,MenuSequence,CreatedUserID,CreatedDate,Status,SnsCategoryId ");
            strSql.Append(" FROM SNS_CategorySource ");
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
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SourceId,CategoryId,Name,Description,ParentID,Path,Depth,Sequence,HasChildren,IsMenu,Type,MenuIsShow,MenuSequence,CreatedUserID,CreatedDate,Status,SnsCategoryId ");
            strSql.Append(" FROM SNS_CategorySource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SNS_CategorySource ");
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
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CategoryId desc");
            }
            strSql.Append(")AS Row, T.*  from SNS_CategorySource T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "SNS_CategorySource";
            parameters[1].Value = "CategoryId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
        #region 扩展方法
        public bool UpdatePathAndDepth(int id, int parentid)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo();
            if (parentid == 0)
            {
                //更新自己
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SNS_CategorySource set ");
                strSql.Append("Depth=?Depth,");
                strSql.Append("Path=?Path,");
                strSql.Append("HasChildren='false'");
                strSql.Append(" where CategoryID=?CategoryID");
                MySqlParameter[] parameters = {
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,200),
					new MySqlParameter("?CategoryID", MySqlDbType.Int32,4)};
                parameters[0].Value = 1;
                parameters[1].Value = id;
                parameters[2].Value = id;
                cmd = new CommandInfo(strSql.ToString(), parameters);
                sqllist.Add(cmd);
            }
            else
            {
                //更新自己
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SNS_CategorySource set ");
                strSql.Append("Depth=(select SNS_CategorySource.depth from SNS_CategorySource where CategoryID=?ParentID)+1,");
                strSql.Append("Path=(select SNS_CategorySource.Path from SNS_CategorySource where CategoryID=?ParentID)+?Path,");
                strSql.Append("HasChildren='true'");
                strSql.Append(" where CategoryID=?CategoryID");
                MySqlParameter[] parameters = {
					new MySqlParameter("?Path", MySqlDbType.VarChar,200),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryID", MySqlDbType.Int32,4)};
                parameters[0].Value = "|" + id;
                parameters[1].Value = parentid;
                parameters[2].Value = id;
                cmd = new CommandInfo(strSql.ToString(), parameters);
                sqllist.Add(cmd);


            }
            //更新子类
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("UPDATE SNS_CategorySource set");
            strSql2.Append(" Depth=(select SNS_CategorySource.depth from SNS_CategorySource where CategoryID=?CategoryID)+1,");
            strSql2.Append(" Path=(select SNS_CategorySource.Path from SNS_CategorySource where CategoryID=?CategoryID)+?Path ");
            strSql2.Append("where ParentID=?CategoryID");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?Path", MySqlDbType.VarChar,200),
					new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryID", MySqlDbType.Int32,4)};
            parameters2[0].Value = "|" + id;
            parameters2[1].Value = parentid;
            parameters2[2].Value = id;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddCategory(YSWL.MALL.Model.SNS.CategorySource model)
        {
            int categoryid = Add(model);
            if (categoryid > 0)
            {
                return UpdatePathAndDepth(categoryid, model.ParentID);
            }
            return false;
        }

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCategory(YSWL.MALL.Model.SNS.CategorySource model)
        {
            if (Update(model))
            {
                return UpdatePathAndDepth(model.CategoryId, model.ParentID);
            }
            return false;
        }

        /// <summary>
        /// 获得数据列表(是否排序)
        /// </summary>
        public DataSet GetCategoryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SNS_CategorySource ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY path ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除分类信息
        /// </summary>
        public bool DeleteCategory(int CategoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_CategorySource ");
            strSql.Append(" where path like (select SNS_CategorySource.Path from SNS_CategorySource where CategoryId=?CategoryId)+'%'");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = CategoryID;
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

        //暂时针对淘宝实现
        public bool UpdateSNSCate(int CategoryId, int SNSCateId, bool IsLoop)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_CategorySource set ");
            strSql.Append("SnsCategoryId=?SnsCategoryId");
            if (IsLoop)
            {
                strSql.Append(" where  path like (select path from SNS_CategorySource where CategoryId=?CategoryId)+'%';");
            }
            else
            {
                strSql.Append(" where  CategoryId=?CategoryId ");
            }
            MySqlParameter[] parameters = {
					new MySqlParameter("?SnsCategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4)};
            parameters[0].Value = SNSCateId;
            parameters[1].Value = CategoryId;


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
        /// 批量对应分类
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="SNSCateId"></param>
        /// <param name="IsLoop"></param>
        /// <returns></returns>
        public bool UpdateSNSCateList(string ids, int SNSCateId, bool IsLoop)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_CategorySource set ");
            strSql.Append("SnsCategoryId=?SnsCategoryId");
            if (IsLoop)
            {

                var arry = ids.Split(',');
                int i = 0;
                foreach (string str in arry)
                {
                    if (i == 0)
                    {
                        strSql.Append(" where  path like (select path from SNS_CategorySource where CategoryId =" + str + ")+'%'");
                    }
                    else
                    {
                        strSql.Append(" or  path like (select path from SNS_CategorySource where CategoryId =" + str + ")+'%'");
                    }
                    i++;
                }

            }
            else
            {
                strSql.Append(" where  CategoryId in (" + ids + ") ");
            }
            MySqlParameter[] parameters = {
					new MySqlParameter("?SnsCategoryId", MySqlDbType.Int32,4)};
            parameters[0].Value = SNSCateId;


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
        /// 是否需要更新
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="name"></param>
        /// <param name="SourceId"></param>
        /// <returns></returns>
        public bool IsUpdate(long CategoryId, string name, int SourceId,int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SNS_CategorySource ");
            strSql.Append(" where SourceId=?SourceId and CategoryId=?CategoryId and (Name<>?Name or  ParentID<>?ParentID)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SourceId", MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
                    	new MySqlParameter("?ParentID", MySqlDbType.Int32,4),
                    	new MySqlParameter("?Name", MySqlDbType.VarChar,50)
                                        };
            parameters[0].Value = SourceId;
            parameters[1].Value = CategoryId;
            parameters[2].Value = ParentID;
            parameters[3].Value = name;
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                int count=Common.Globals.SafeInt(obj.ToString(), 0);

                return count > 0 ? true : false;
            }
        }

        #endregion
    }
}

