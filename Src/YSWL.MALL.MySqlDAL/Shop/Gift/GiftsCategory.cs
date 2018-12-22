using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Gift;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Shop.Gift
{
    /// <summary>
    /// 数据访问类:GiftsCategory
    /// </summary>
    public partial class GiftsCategory : IGiftsCategory
    {
        public GiftsCategory()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("CategoryID", "Shop_GiftsCategory");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CategoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_GiftsCategory");
            strSql.Append(" where CategoryID=?CategoryID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = CategoryID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Gift.GiftsCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_GiftsCategory(");
            strSql.Append("ParentCategoryId,Name,Depth,Path,DisplaySequence,Description,Theme,HasChildren)");
            strSql.Append(" values (");
            strSql.Append("?ParentCategoryId,?Name,?Depth,?Path,?DisplaySequence,?Description,?Theme,?HasChildren)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ParentCategoryId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarString,200),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarString,200),
					new MySqlParameter("?DisplaySequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarString),
					new MySqlParameter("?Theme", MySqlDbType.VarString,200),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1)};
            parameters[0].Value = model.ParentCategoryId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Depth;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.DisplaySequence;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.Theme;
            parameters[7].Value = model.HasChildren;

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
        public bool Update(YSWL.MALL.Model.Shop.Gift.GiftsCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_GiftsCategory set ");
            strSql.Append("ParentCategoryId=?ParentCategoryId,");
            strSql.Append("Name=?Name,");
            strSql.Append("Depth=?Depth,");
            strSql.Append("Path=?Path,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("Description=?Description,");
            strSql.Append("Theme=?Theme,");
            strSql.Append("HasChildren=?HasChildren");
            strSql.Append(" where CategoryID=?CategoryID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ParentCategoryId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarString,200),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarString,200),
					new MySqlParameter("?DisplaySequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarString),
					new MySqlParameter("?Theme", MySqlDbType.VarString,200),
					new MySqlParameter("?HasChildren", MySqlDbType.Bit,1),
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ParentCategoryId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Depth;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.DisplaySequence;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.Theme;
            parameters[7].Value = model.HasChildren;
            parameters[8].Value = model.CategoryID;

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
        public bool Delete(int CategoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_GiftsCategory ");
            strSql.Append(" where CategoryID=?CategoryID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)
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

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string CategoryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_GiftsCategory ");
            strSql.Append(" where CategoryID in (" + CategoryIDlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Gift.GiftsCategory GetModel(int CategoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   CategoryID,ParentCategoryId,Name,Depth,Path,DisplaySequence,Description,Theme,HasChildren from Shop_GiftsCategory ");
            strSql.Append(" where CategoryID=?CategoryID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = CategoryID;

            YSWL.MALL.Model.Shop.Gift.GiftsCategory model = new YSWL.MALL.Model.Shop.Gift.GiftsCategory();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CategoryID"] != null && ds.Tables[0].Rows[0]["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(ds.Tables[0].Rows[0]["CategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentCategoryId"] != null && ds.Tables[0].Rows[0]["ParentCategoryId"].ToString() != "")
                {
                    model.ParentCategoryId = int.Parse(ds.Tables[0].Rows[0]["ParentCategoryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DisplaySequence"] != null && ds.Tables[0].Rows[0]["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(ds.Tables[0].Rows[0]["DisplaySequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Theme"] != null && ds.Tables[0].Rows[0]["Theme"].ToString() != "")
                {
                    model.Theme = ds.Tables[0].Rows[0]["Theme"].ToString();
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
            strSql.Append("select CategoryID,ParentCategoryId,Name,Depth,Path,DisplaySequence,Description,Theme,HasChildren ");
            strSql.Append(" FROM Shop_GiftsCategory ");
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
            strSql.Append(" CategoryID,ParentCategoryId,Name,Depth,Path,DisplaySequence,Description,Theme,HasChildren ");
            strSql.Append(" FROM Shop_GiftsCategory ");
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
            strSql.Append("select count(1) FROM Shop_GiftsCategory ");
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
            strSql.Append("SELECT T.*  from Shop_GiftsCategory T  ");
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
                strSql.Append(" order by T.CategoryID desc");
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
            parameters[0].Value = "Shop_GiftsCategory";
            parameters[1].Value = "CategoryID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region 扩展方法

        public bool UpdatePathAndDepth(int id, int parentid)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo();
            if (parentid == 0)
            {
                //更新自己
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update Shop_GiftsCategory set ");
                strSql.Append("Depth=?Depth,");
                strSql.Append("Path=?Path,");
                strSql.Append("HasChildren='false'");
                strSql.Append(" where CategoryID=?CategoryID;");
                MySqlParameter[] parameters = {
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarString,200),
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)};
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
                strSql.Append("update Shop_GiftsCategory set ");
                strSql.Append("Depth=(select t.depth from (select s.depth from Shop_GiftsCategory s where CategoryID=?ParentCategoryID)t)+1,");
                strSql.Append("Path=(select path from (select CONCAT((select s.Path from Shop_GiftsCategory s where CategoryID=?ParentCategoryID),?Path)path)t), ");	
                strSql.Append("HasChildren='true'");
                strSql.Append(" where CategoryID=?CategoryID;");
                MySqlParameter[] parameters = {
					new MySqlParameter("?Path", MySqlDbType.VarString,200),
					new MySqlParameter("?ParentCategoryID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)};
                parameters[0].Value = "|" + id;
                parameters[1].Value = parentid;
                parameters[2].Value = id;
                cmd = new CommandInfo(strSql.ToString(), parameters);
                sqllist.Add(cmd);
            }

            //更新子类
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update Shop_GiftsCategory set ");
            strSql2.Append("Depth=(select t.depth from (select s.depth from Shop_GiftsCategory s where CategoryID=?CategoryID)t)+1,");
            strSql2.Append("Path=(select path from (select CONCAT((select s.Path from Shop_GiftsCategory s where CategoryID=?CategoryID),?Path)path)t) ");	
            strSql2.Append(" where ParentCategoryId=?CategoryID;");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?Path", MySqlDbType.VarString,200),
					new MySqlParameter("?ParentCategoryID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)};
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
        public bool AddCategory(YSWL.MALL.Model.Shop.Gift.GiftsCategory model)
        {
            int categoryid = Add(model);
            if (categoryid > 0)
            {
                return UpdatePathAndDepth(categoryid, model.ParentCategoryId.Value);
            }
            return false;
        }

        /// <summary>
        /// 修改分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCategory(YSWL.MALL.Model.Shop.Gift.GiftsCategory model)
        {
            if (Update(model))
            {
                return UpdatePathAndDepth(model.CategoryID, model.ParentCategoryId.Value);
            }
            return false;
        }

        /// <summary>
        /// 获得数据列表(是否排序)
        /// </summary>
        public DataSet GetCategoryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryID,ParentCategoryId,Name,Depth,Path,DisplaySequence,Description,Theme,HasChildren ");
            strSql.Append(" FROM Shop_GiftsCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " ORDER BY path");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除分类信息
        /// </summary>
        public bool DeleteCategory(int CategoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_GiftsCategory ");
            strSql.Append(" where CategoryID=?CategoryID or path like (select path from (select CONCAT((select Shop_GiftsCategory.Path from Shop_GiftsCategory where CategoryID=?CategoryID),'|%')path)t) ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)
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

        /// <summary>
        /// 对分类进行排序
        /// </summary>
        public bool SwapSequence(int CategoryId, Model.Shop.Products.SwapSequenceIndex zIndex)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("update Shop_GiftsCategory set ");
            //if ((int)zIndex == 1)
            //{
            //    strSql.Append("DisplaySequence=DisplaySequence-1");
            //}
            //if ((int)zIndex == 0)
            //{
            //    strSql.Append("DisplaySequence=DisplaySequence+1");
            //}
            //strSql.Append(" where CategoryID=?CategoryID");
            //MySqlParameter[] parameters = {
            //        new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4)
            //                            };
            //parameters[0].Value = CategoryId;
            //int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        #endregion 扩展方法
    }
}