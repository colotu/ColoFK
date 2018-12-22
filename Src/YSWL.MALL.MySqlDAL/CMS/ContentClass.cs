using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.CMS;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 栏目类型数据访问类
    /// </summary>
    public partial class ContentClass : IContentClass
    {
        public ContentClass()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ClassID", "CMS_ContentClass");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_ContentClass");
            strSql.Append(" where ClassID=?ClassID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ClassID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.CMS.ContentClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_ContentClass(");
            strSql.Append("ClassName,ClassIndex,Sequence,ParentId,State,AllowSubclass,AllowAddContent,ImageUrl,Description,Keywords,ClassTypeID,ClassModel,PageModelName,CreatedDate,CreatedUserID,Path,Depth,Remark,Meta_Title,Meta_Description,Meta_Keywords,SeoUrl,SeoImageAlt,SeoImageTitle,IndexChar)");
            strSql.Append(" values (");
            strSql.Append("?ClassName,?ClassIndex,?Sequence,?ParentId,?State,?AllowSubclass,?AllowAddContent,?ImageUrl,?Description,?Keywords,?ClassTypeID,?ClassModel,?PageModelName,?CreatedDate,?CreatedUserID,?Path,?Depth,?Remark,?Meta_Title,?Meta_Description,?Meta_Keywords,?SeoUrl,?SeoImageAlt,?SeoImageTitle,?IndexChar)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarString,200),
					new MySqlParameter("?ClassIndex", MySqlDbType.VarChar,50),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentId",  MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?AllowSubclass", MySqlDbType.Bit,1),
					new MySqlParameter("?AllowAddContent", MySqlDbType.Bit,1),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?Keywords", MySqlDbType.VarChar,50),
					new MySqlParameter("?ClassTypeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassModel", MySqlDbType.Int16,2),
					new MySqlParameter("?PageModelName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarString,1000),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarString,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarString,1000),
					new MySqlParameter("?SeoUrl", MySqlDbType.VarString,300),
					new MySqlParameter("?SeoImageAlt", MySqlDbType.VarString,300),
					new MySqlParameter("?SeoImageTitle", MySqlDbType.VarString,300),
					new MySqlParameter("?IndexChar", MySqlDbType.VarString,200)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ClassIndex;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.State;
            parameters[5].Value = model.AllowSubclass;
            parameters[6].Value = model.AllowAddContent;
            parameters[7].Value = model.ImageUrl;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Keywords;
            parameters[10].Value = model.ClassTypeID;
            parameters[11].Value = model.ClassModel;
            parameters[12].Value = model.PageModelName;
            parameters[13].Value = model.CreatedDate;
            parameters[14].Value = model.CreatedUserID;
            parameters[15].Value = model.Path;
            parameters[16].Value = model.Depth;
            parameters[17].Value = model.Remark;
            parameters[18].Value = model.Meta_Title;
            parameters[19].Value = model.Meta_Description;
            parameters[20].Value = model.Meta_Keywords;
            parameters[21].Value = model.SeoUrl;
            parameters[22].Value = model.SeoImageAlt;
            parameters[23].Value = model.SeoImageTitle;
            parameters[24].Value = model.IndexChar;

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
        public bool Update(YSWL.MALL.Model.CMS.ContentClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_ContentClass set ");
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("ClassIndex=?ClassIndex,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("ParentId=?ParentId,");
            strSql.Append("State=?State,");
            strSql.Append("AllowSubclass=?AllowSubclass,");
            strSql.Append("AllowAddContent=?AllowAddContent,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("Description=?Description,");
            strSql.Append("Keywords=?Keywords,");
            strSql.Append("ClassTypeID=?ClassTypeID,");
            strSql.Append("ClassModel=?ClassModel,");
            strSql.Append("PageModelName=?PageModelName,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("Path=?Path,");
            strSql.Append("Depth=?Depth,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("Meta_Title=?Meta_Title,");
            strSql.Append("Meta_Description=?Meta_Description,");
            strSql.Append("Meta_Keywords=?Meta_Keywords,");
            strSql.Append("SeoUrl=?SeoUrl,");
            strSql.Append("SeoImageAlt=?SeoImageAlt,");
            strSql.Append("SeoImageTitle=?SeoImageTitle,");
            strSql.Append("IndexChar=?IndexChar");
            strSql.Append(" where ClassID=?ClassID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarString,200),
					new MySqlParameter("?ClassIndex", MySqlDbType.VarChar,50),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentId",  MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?AllowSubclass", MySqlDbType.Bit,1),
					new MySqlParameter("?AllowAddContent", MySqlDbType.Bit,1),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?Keywords", MySqlDbType.VarChar,50),
					new MySqlParameter("?ClassTypeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassModel", MySqlDbType.Int16,2),
					new MySqlParameter("?PageModelName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarString,1000),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarString,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarString,1000),
					new MySqlParameter("?SeoUrl", MySqlDbType.VarString,300),
					new MySqlParameter("?SeoImageAlt", MySqlDbType.VarString,300),
					new MySqlParameter("?SeoImageTitle", MySqlDbType.VarString,300),
					new MySqlParameter("?IndexChar", MySqlDbType.VarString,200),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ClassIndex;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.State;
            parameters[5].Value = model.AllowSubclass;
            parameters[6].Value = model.AllowAddContent;
            parameters[7].Value = model.ImageUrl;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Keywords;
            parameters[10].Value = model.ClassTypeID;
            parameters[11].Value = model.ClassModel;
            parameters[12].Value = model.PageModelName;
            parameters[13].Value = model.CreatedDate;
            parameters[14].Value = model.CreatedUserID;
            parameters[15].Value = model.Path;
            parameters[16].Value = model.Depth;
            parameters[17].Value = model.Remark;
            parameters[18].Value = model.Meta_Title;
            parameters[19].Value = model.Meta_Description;
            parameters[20].Value = model.Meta_Keywords;
            parameters[21].Value = model.SeoUrl;
            parameters[22].Value = model.SeoImageAlt;
            parameters[23].Value = model.SeoImageTitle;
            parameters[24].Value = model.IndexChar;
            parameters[25].Value = model.ClassID;

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
        public bool Delete(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_ContentClass ");
            strSql.Append(" where ClassID=?ClassID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ClassID;

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
        public bool DeleteList(string ClassIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_ContentClass ");
            strSql.Append(" where ClassID in (" + ClassIDlist + ")  ");
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
        public YSWL.MALL.Model.CMS.ContentClass GetModel(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ClassID,ClassName,ClassIndex,Sequence,ParentId,State,AllowSubclass,AllowAddContent,ImageUrl,Description,Keywords,ClassTypeID,ClassModel,PageModelName,CreatedDate,CreatedUserID,Path,Depth,Remark,Meta_Title,Meta_Description,Meta_Keywords,SeoUrl,SeoImageAlt,SeoImageTitle,IndexChar from CMS_ContentClass ");
            strSql.Append(" where ClassID=?ClassID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ClassID;

            YSWL.MALL.Model.CMS.ContentClass model = new YSWL.MALL.Model.CMS.ContentClass();
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
        public YSWL.MALL.Model.CMS.ContentClass DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.CMS.ContentClass model = new YSWL.MALL.Model.CMS.ContentClass();
            if (row != null)
            {
                if (row["ClassID"] != null && row["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(row["ClassID"].ToString());
                }
                if (row["ClassName"] != null)
                {
                    model.ClassName = row["ClassName"].ToString();
                }
                if (row["ClassIndex"] != null)
                {
                    model.ClassIndex = row["ClassIndex"].ToString();
                }
                if (row["Sequence"] != null && row["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(row["Sequence"].ToString());
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["AllowSubclass"] != null && row["AllowSubclass"].ToString() != "")
                {
                    if ((row["AllowSubclass"].ToString() == "1") || (row["AllowSubclass"].ToString().ToLower() == "true"))
                    {
                        model.AllowSubclass = true;
                    }
                    else
                    {
                        model.AllowSubclass = false;
                    }
                }
                if (row["AllowAddContent"] != null && row["AllowAddContent"].ToString() != "")
                {
                    if ((row["AllowAddContent"].ToString() == "1") || (row["AllowAddContent"].ToString().ToLower() == "true"))
                    {
                        model.AllowAddContent = true;
                    }
                    else
                    {
                        model.AllowAddContent = false;
                    }
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Keywords"] != null)
                {
                    model.Keywords = row["Keywords"].ToString();
                }
                if (row["ClassTypeID"] != null && row["ClassTypeID"].ToString() != "")
                {
                    model.ClassTypeID = int.Parse(row["ClassTypeID"].ToString());
                }
                if (row["ClassModel"] != null && row["ClassModel"].ToString() != "")
                {
                    model.ClassModel = int.Parse(row["ClassModel"].ToString());
                }
                if (row["PageModelName"] != null)
                {
                    model.PageModelName = row["PageModelName"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["CreatedUserID"] != null && row["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(row["CreatedUserID"].ToString());
                }
                if (row["Path"] != null)
                {
                    model.Path = row["Path"].ToString();
                }
                if (row["Depth"] != null && row["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(row["Depth"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Meta_Title"] != null)
                {
                    model.Meta_Title = row["Meta_Title"].ToString();
                }
                if (row["Meta_Description"] != null)
                {
                    model.Meta_Description = row["Meta_Description"].ToString();
                }
                if (row["Meta_Keywords"] != null)
                {
                    model.Meta_Keywords = row["Meta_Keywords"].ToString();
                }
                if (row["SeoUrl"] != null)
                {
                    model.SeoUrl = row["SeoUrl"].ToString();
                }
                if (row["SeoImageAlt"] != null)
                {
                    model.SeoImageAlt = row["SeoImageAlt"].ToString();
                }
                if (row["SeoImageTitle"] != null)
                {
                    model.SeoImageTitle = row["SeoImageTitle"].ToString();
                }
                if (row["IndexChar"] != null)
                {
                    model.IndexChar = row["IndexChar"].ToString();
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
            strSql.Append("select ClassID,ClassName,ClassIndex,Sequence,ParentId,State,AllowSubclass,AllowAddContent,ImageUrl,Description,Keywords,ClassTypeID,ClassModel,PageModelName,CreatedDate,CreatedUserID,Path,Depth,Remark,Meta_Title,Meta_Description,Meta_Keywords,SeoUrl,SeoImageAlt,SeoImageTitle,IndexChar ");
            strSql.Append(" FROM CMS_ContentClass ");
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
            strSql.Append(" ClassID,ClassName,ClassIndex,Sequence,ParentId,State,AllowSubclass,AllowAddContent,ImageUrl,Description,Keywords,ClassTypeID,ClassModel,PageModelName,CreatedDate,CreatedUserID,Path,Depth,Remark,Meta_Title,Meta_Description,Meta_Keywords,SeoUrl,SeoImageAlt,SeoImageTitle,IndexChar ");
            strSql.Append(" FROM CMS_ContentClass ");
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
            strSql.Append("select count(1) FROM CMS_ContentClass ");
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
            //    strSql.Append(" order by T.ClassID desc");
            //}
            //strSql.Append(")AS Row, T.*  from CMS_ContentClass T ");
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT  T.*  from CMS_ContentClass T ");
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
                strSql.Append(" order by T.ClassID desc");
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
            parameters[0].Value = "CMS_ContentClass";
            parameters[1].Value = "ClassID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion BasicMethod

        #region Method

        #region 获取树集合

        /// <summary>
        /// 获取树集合
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetTreeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM CMS_ContentClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY ParentId,Sequence ");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion 获取树集合

        #region 分页获取数据列表

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
			parameters[0].Value = "CMS_ContentClass";
			parameters[1].Value = "ClassID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion 分页获取数据列表

        #region 批量更新数据

        /// <summary>
        /// 批量更新数据
        /// </summary>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE CMS_ContentClass set " + strWhere);
            strSql.Append(" WHERE ClassID IN(" + IDlist + ")  ");
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

        #endregion 批量更新数据

        #region 更新类别排序

        /// <summary>
        /// 更新类别排序
        /// </summary>
        /// <param name="VideoClassId">类别ID</param>
        /// <param name="zIndex">排序方式</param>
        /// <returns></returns>
        public int SwapCategorySequence(int ContentClassId, YSWL.Common.Video.SwapSequenceIndex zIndex)
        {
            int rows;
            MySqlParameter[] parameters = {
					new MySqlParameter("?_ClassID",  MySqlDbType.Int32),
					new MySqlParameter("?_ZIndex",  MySqlDbType.Int32)
					};
            parameters[0].Value = ContentClassId;
            parameters[1].Value = (int)zIndex;
            //return DbHelperMySQL.RunProcedure("sp_CMS_SwapContentClassSequence", parameters, out rows);
            DbHelperMySQL.RunProcedure("sp_CMS_SwapContentClassSequence", parameters, out rows);
            return rows;
        }

        #endregion 更新类别排序

        #region 删除分类信息

        /// <summary>
        /// 删除分类信息
        /// </summary>
        public bool DeleteCategory(int categoryId)
        {
            int AffectedRows = 0;
            MySqlParameter[] parameter = {
                                       new MySqlParameter("?_ClassID",MySqlDbType.Int32),
                                       new MySqlParameter("?_Status",MySqlDbType.Int32)
                                       };
            parameter[0].Value = categoryId;
            parameter[1].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("sp_CMS_Category_Delete", parameter, out AffectedRows);
            return (int)(parameter[1].Value) > 0;
        }

        #endregion 删除分类信息

        #region 获得数据列表

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByView(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *  FROM View_ContentClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion 获得数据列表

        #region 获得前几行数据

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetListByView(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(" * ");
            strSql.Append(" FROM View_ContentClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" ORDER BY " + filedOrder);
            }
            else
            {
                strSql.Append(" ORDER BY ClassID ASC ");
            }
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion 获得前几行数据

        public bool AddExt(YSWL.MALL.Model.CMS.ContentClass model)
        {
            int rows;
            MySqlParameter[] parameters = {
					new MySqlParameter("?_ClassName", MySqlDbType.VarString,200),
					new MySqlParameter("?_ClassIndex", MySqlDbType.VarChar,50),
					new MySqlParameter("?_Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?_ParentId",  MySqlDbType.Int32,4),
					new MySqlParameter("?_State", MySqlDbType.Int16,2),
					new MySqlParameter("?_AllowSubclass", MySqlDbType.Bit,1),
					new MySqlParameter("?_AllowAddContent", MySqlDbType.Bit,1),
					new MySqlParameter("?_ImageUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?_Description",  MySqlDbType.Text),
					new MySqlParameter("?_Keywords", MySqlDbType.VarChar,50),
					new MySqlParameter("?_ClassTypeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?_ClassModel", MySqlDbType.Int16,2),
					new MySqlParameter("?_PageModelName", MySqlDbType.VarChar,200),
					new MySqlParameter("?_CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?_Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?_Meta_Title", MySqlDbType.VarString,1000),
					new MySqlParameter("?_Meta_Description", MySqlDbType.VarString,1000),
					new MySqlParameter("?_Meta_Keywords", MySqlDbType.VarString,1000),
					new MySqlParameter("?_SeoUrl", MySqlDbType.VarString,300),
					new MySqlParameter("?_SeoImageAlt", MySqlDbType.VarString,300),
					new MySqlParameter("?_SeoImageTitle", MySqlDbType.VarString,300),
					new MySqlParameter("?_IndexChar", MySqlDbType.VarString,200)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ClassIndex;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.State;
            parameters[5].Value = model.AllowSubclass;
            parameters[6].Value = model.AllowAddContent;
            parameters[7].Value = model.ImageUrl;
            parameters[8].Value = model.Description;
            parameters[9].Value = model.Keywords;
            parameters[10].Value = model.ClassTypeID;
            parameters[11].Value = model.ClassModel;
            parameters[12].Value = model.PageModelName;
            parameters[13].Value = model.CreatedUserID;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.Meta_Title;
            parameters[16].Value = model.Meta_Description;
            parameters[17].Value = model.Meta_Keywords;
            parameters[18].Value = model.SeoUrl;
            parameters[19].Value = model.SeoImageAlt;
            parameters[20].Value = model.SeoImageTitle;
            parameters[21].Value = model.IndexChar;
            DbHelperMySQL.RunProcedure("sp_CMS_ContentClass_Create", parameters, out rows);
            if (rows >= 0)
            {
                return true;
            } return false;
        }

        /// <summary>
        /// 获取NamePath
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetNamePathByPath(string path)
        {
            path = path.Replace("|", ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM CMS_ContentClass ");
            strSql.Append("WHERE ClassID in (" + path + ")");
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            string Name = "";
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    if (i == 0)
                        Name = dr["ClassName"].ToString();
                    else
                        Name = Name + "/" + dr["ClassName"].ToString();

                    //if (!(i == 0 && (RegionName == "北京" || RegionName == "上海" || RegionName == "天津" || RegionName == "重庆")))
                    //{
                    //    strReg.Append(RegionName);
                    //}
                }
            }
            return Name;
        }

        public string GetUrlByPath(string path)
        {
            path = path.Replace("|", ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM CMS_ContentClass ");
            strSql.Append("WHERE ClassID in (" + path + ")");
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            string Url = "";
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    if (i == 0)
                    {
                        Url = String.IsNullOrWhiteSpace(dr["SeoUrl"].ToString()) ? dr["ClassID"].ToString() : dr["SeoUrl"].ToString();
                    }
                    else
                    {
                        Url = Url + "/" + (String.IsNullOrWhiteSpace(dr["SeoUrl"].ToString()) ? dr["ClassID"].ToString() : dr["SeoUrl"].ToString());
                    }
                }
            }
            return Url;
        }

        #endregion Method
    }
}