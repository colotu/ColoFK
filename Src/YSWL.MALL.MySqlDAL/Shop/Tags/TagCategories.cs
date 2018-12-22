/**
* TagCategories.cs
*
* 功 能： N/A
* 类 名： TagCategories
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012年12月14日 10:13:12   Rock    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
using YSWL.MALL.IDAL.Shop.Tags;

namespace YSWL.MALL.MySqlDAL.Shop.Tags
{
    /// <summary>
    /// 数据访问类:TagCategories
    /// </summary>
    public partial class TagCategories : ITagCategories
    {
        public TagCategories()
        { }

        #region Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_TagCategories");
            strSql.Append(" WHERE ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Tags.TagCategories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_TagCategories(");
            strSql.Append("CategoryName,ParentCategoryId,DisplaySequence,Depth,Path,Meta_Title,Meta_Description,Meta_Keywords,HasChildren,Status,Remark)");
            strSql.Append(" VALUES (");
            strSql.Append("?CategoryName,?ParentCategoryId,?DisplaySequence,?Depth,?Path,?Meta_Title,?Meta_Description,?Meta_Keywords,?HasChildren,?Status,?Remark)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ParentCategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,500),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.CategoryName;
            parameters[1].Value = model.ParentCategoryId;
            parameters[2].Value = model.DisplaySequence;
            parameters[3].Value = model.Depth;
            parameters[4].Value = model.Path;
            parameters[5].Value = model.Meta_Title;
            parameters[6].Value = model.Meta_Description;
            parameters[7].Value = model.Meta_Keywords;
            parameters[8].Value = model.HasChildren;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.Shop.Tags.TagCategories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_TagCategories SET ");
            strSql.Append("CategoryName=?CategoryName,");
            strSql.Append("ParentCategoryId=?ParentCategoryId,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("Depth=?Depth,");
            strSql.Append("Path=?Path,");
            strSql.Append("Meta_Title=?Meta_Title,");
            strSql.Append("Meta_Description=?Meta_Description,");
            strSql.Append("Meta_Keywords=?Meta_Keywords,");
            strSql.Append("HasChildren=?HasChildren,");
            strSql.Append("Status=?Status,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" WHERE ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ParentCategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,500),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CategoryName;
            parameters[1].Value = model.ParentCategoryId;
            parameters[2].Value = model.DisplaySequence;
            parameters[3].Value = model.Depth;
            parameters[4].Value = model.Path;
            parameters[5].Value = model.Meta_Title;
            parameters[6].Value = model.Meta_Description;
            parameters[7].Value = model.Meta_Keywords;
            parameters[8].Value = model.HasChildren;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.ID;

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
            strSql.Append("DELETE FROM Shop_TagCategories ");
            strSql.Append(" WHERE ID=?ID");
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
            strSql.Append("DELETE FROM Shop_TagCategories ");
            strSql.Append(" WHERE ID in (" + IDlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Tags.TagCategories GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,CategoryName,ParentCategoryId,DisplaySequence,Depth,Path,Meta_Title,Meta_Description,Meta_Keywords,HasChildren,Status,Remark FROM Shop_TagCategories ");
            strSql.Append(" WHERE ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Tags.TagCategories model = new YSWL.MALL.Model.Shop.Tags.TagCategories();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CategoryName"] != null && ds.Tables[0].Rows[0]["CategoryName"].ToString() != "")
                {
                    model.CategoryName = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentCategoryId"] != null && ds.Tables[0].Rows[0]["ParentCategoryId"].ToString() != "")
                {
                    model.ParentCategoryId = int.Parse(ds.Tables[0].Rows[0]["ParentCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DisplaySequence"] != null && ds.Tables[0].Rows[0]["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(ds.Tables[0].Rows[0]["DisplaySequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Meta_Title"] != null && ds.Tables[0].Rows[0]["Meta_Title"].ToString() != "")
                {
                    model.Meta_Title = ds.Tables[0].Rows[0]["Meta_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Meta_Description"] != null && ds.Tables[0].Rows[0]["Meta_Description"].ToString() != "")
                {
                    model.Meta_Description = ds.Tables[0].Rows[0]["Meta_Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Meta_Keywords"] != null && ds.Tables[0].Rows[0]["Meta_Keywords"].ToString() != "")
                {
                    model.Meta_Keywords = ds.Tables[0].Rows[0]["Meta_Keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HasChildren"] != null && ds.Tables[0].Rows[0]["HasChildren"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["HasChildren"].ToString() == "1") || (ds.Tables[0].Rows[0]["HasChildren"].ToString().ToLower() == "true"))
                    {
                        model.HasChildren = true;
                    }
                    else
                    {
                        model.HasChildren = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("SELECT ID,CategoryName,ParentCategoryId,DisplaySequence,Depth,Path,Meta_Title,Meta_Description,Meta_Keywords,HasChildren,Status,Remark ");
            strSql.Append(" FROM Shop_TagCategories ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY DisplaySequence  ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(" ID,CategoryName,ParentCategoryId,DisplaySequence,Depth,Path,Meta_Title,Meta_Description,Meta_Keywords,HasChildren,Status,Remark ");
            strSql.Append(" FROM Shop_TagCategories ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(filedOrder.Trim()))
            {
                strSql.Append(" ORDER BY " + filedOrder);
            }
            else
            {
                strSql.Append(" ORDER BY ID");
            }
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
            strSql.Append("SELECT COUNT(1) FROM Shop_TagCategories ");
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
            strSql.Append("SELECT T.* from Shop_SuppProductStatModes T ");
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

        #endregion Method

        #region ExtensionMethod
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool CreateCategory(Model.Shop.Tags.TagCategories model)
        {
            int resultRows = 0;
            MySqlParameter[] parameters = {
					                    new MySqlParameter("_CategoryName", MySqlDbType.VarChar,50),
					                    new MySqlParameter("_ParentCategoryId", MySqlDbType.Int32,4),
					                    new MySqlParameter("_Meta_Title", MySqlDbType.VarChar,1000),
					                    new MySqlParameter("_Meta_Description", MySqlDbType.VarChar,1000),
					                    new MySqlParameter("_Meta_Keywords", MySqlDbType.VarChar,1000),
					                    new MySqlParameter("_HasChildren", MySqlDbType.Bit,1),
					                    new MySqlParameter("_Status", MySqlDbType.Int32,4),
					                    new MySqlParameter("_Remark", MySqlDbType.VarChar,200)
                                        };
            parameters[0].Value = model.CategoryName;
            parameters[1].Value = model.ParentCategoryId;
            parameters[2].Value = model.Meta_Title;
            parameters[3].Value = model.Meta_Description;
            parameters[4].Value = model.Meta_Keywords;
            parameters[5].Value = model.HasChildren;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.Remark;

            DbHelperMySQL.RunProcedure("sp_Shop_TagCategories_Create", parameters, out resultRows);
            return resultRows > 0;
        }

        /// <summary>
        /// 对分类进行排序
        /// </summary>
        public bool TagCategoriesSequence(int ID, Model.Shop.Tags.SequenceIndex Index)
        {
            int AffectedRows = 0;
            MySqlParameter[] parameter = { 
                                       new MySqlParameter("_ID",MySqlDbType.Int32),
                                       new MySqlParameter("_Index",MySqlDbType.Int32)
                                       };
            parameter[0].Value = ID;
            parameter[1].Value = (int)Index;

            DbHelperMySQL.RunProcedure("sp_Shop_TagCategories_SwapSequence", parameter, out AffectedRows);
            return AffectedRows > 0;
        }
        /// <summary>
        /// 删除分类信息
        /// </summary>
        public DataSet DeleteTagCategories(int ID, out int Result)
        {
            MySqlParameter[] parameters = {
					new MySqlParameter("_ID", MySqlDbType.Int32,4),
                    new MySqlParameter("ReturnValue", MySqlDbType.Int32,4)
                                          };
                    parameters[0].Value = ID;
                    parameters[1].Direction = ParameterDirection.ReturnValue;
            DataSet ds = DbHelperMySQL.RunProcedure("sp_Shop_TagCategories_Delete", parameters, "tb", out Result);
            if (Result == 1)
            {
                return ds;
            }
            return null;
        }
        #endregion
    }
}