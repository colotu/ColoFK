/**
* VideoClass.cs
*
* 功 能：
* 类 名： VideoClass
*
* Ver    变更日期             负责人：  变更内容
* ───────────────────────────────────
* V0.01  2012/5/22 16:28:49  蒋海滨    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Data;
using System.Text;
using YSWL.Common;
using YSWL.Common.Video;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.CMS;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 数据访问类:VideoClass
    /// </summary>
    public partial class VideoClass : IVideoClass
    {
        public VideoClass()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("VideoClassID", "CMS_VideoClass");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int VideoClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_VideoClass");
            strSql.Append(" where VideoClassID=?VideoClassID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?VideoClassID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = VideoClassID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.CMS.VideoClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_VideoClass(");
            strSql.Append("VideoClassName,ParentID,Sequence,Path,Depth)");
            strSql.Append(" values (");
            strSql.Append("?VideoClassName,?ParentID,?Sequence,?Path,?Depth)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?VideoClassName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.VideoClassName;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.Depth;

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
        public bool Update(YSWL.MALL.Model.CMS.VideoClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_VideoClass set ");
            strSql.Append("VideoClassName=?VideoClassName,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("Path=?Path,");
            strSql.Append("Depth=?Depth");
            strSql.Append(" where VideoClassID=?VideoClassID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?VideoClassName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4),
					new MySqlParameter("?VideoClassID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.VideoClassName;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.VideoClassID;

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
        public bool Delete(int VideoClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_VideoClass ");
            strSql.Append(" where VideoClassID=?VideoClassID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?VideoClassID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = VideoClassID;

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
        public bool DeleteList(string VideoClassIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_VideoClass ");
            strSql.Append(" where VideoClassID in (" + VideoClassIDlist + ")  ");
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
        public YSWL.MALL.Model.CMS.VideoClass GetModel(int VideoClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   VideoClassID,VideoClassName,ParentID,Sequence,Path,Depth from CMS_VideoClass ");
            strSql.Append(" where VideoClassID=?VideoClassID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?VideoClassID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = VideoClassID;

            YSWL.MALL.Model.CMS.VideoClass model = new YSWL.MALL.Model.CMS.VideoClass();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (DataSetTools.DataSetIsNull(ds))
            {
                return null;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["VideoClassID"] != null && ds.Tables[0].Rows[0]["VideoClassID"].ToString() != "")
                {
                    model.VideoClassID = int.Parse(ds.Tables[0].Rows[0]["VideoClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VideoClassName"] != null && ds.Tables[0].Rows[0]["VideoClassName"].ToString() != "")
                {
                    model.VideoClassName = ds.Tables[0].Rows[0]["VideoClassName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
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
            strSql.Append("select VideoClassID,VideoClassName,ParentID,Sequence,Path,Depth ");
            strSql.Append(" FROM CMS_VideoClass ");
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
            strSql.Append(" VideoClassID,VideoClassName,ParentID,Sequence,Path,Depth ");
            strSql.Append(" FROM CMS_VideoClass ");
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
            strSql.Append("select count(1) FROM CMS_VideoClass ");
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
            //if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            //{
            //    strSql.Append(" order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append(" order by T.VideoClassID desc");
            //}
            //strSql.Append(")AS Row, T.*  from CMS_VideoClass T ");
            //if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT  T.*  from CMS_VideoClass T ");
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
                strSql.Append(" order by T.VideoClassID desc");
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
            parameters[0].Value = "CMS_VideoClass";
            parameters[1].Value = "VideoClassID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region MethodEx

        /// <summary>
        /// 级联删除分类及子类
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public int DeleteEx(int VideoClassID)
        {
            int rows;
            MySqlParameter[] parameters = {
					new MySqlParameter("?_VideoClassID",  MySqlDbType.Int32)
					};
            parameters[0].Value = VideoClassID;
            //return (DbHelperMySQL.RunProcedure("sp_CMS_VideoClass_Delete", parameters, out rows));
            DbHelperMySQL.RunProcedure("sp_CMS_VideoClass_Delete", parameters, out rows);
            return rows;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddEx(YSWL.MALL.Model.CMS.VideoClass model)
        {
            int rows;
            MySqlParameter[] parameters = {
					new MySqlParameter("?_VideoClassName", MySqlDbType.VarString,30),
					new MySqlParameter("?_Sequence",  MySqlDbType.Int32),
					new MySqlParameter("?_ParentID",  MySqlDbType.Int32)
					};
            parameters[0].Value = model.VideoClassName;
            parameters[1].Value = model.Sequence;
            parameters[2].Value = model.ParentID;
            //return DbHelperMySQL.RunProcedure("sp_CMS_VideoClass_Create", parameters, out rows);
            DbHelperMySQL.RunProcedure("sp_CMS_VideoClass_Create", parameters, out rows);
            return rows;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere, string orderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select VideoClassID,VideoClassName,ParentID,Sequence,Path,Depth ");
            strSql.Append(" FROM CMS_VideoClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderBy.Trim()))
            {
                strSql.Append(" order by " + orderBy);
            }
            else
            {
                strSql.Append(" order by VideoClassID desc");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据ParentID得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.CMS.VideoClass GetModelByParentID(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   VideoClassID,VideoClassName,ParentID,Sequence,Path,Depth from CMS_VideoClass ");
            strSql.Append(" where VideoClassID=?ParentID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ParentID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ParentID;

            YSWL.MALL.Model.CMS.VideoClass model = new YSWL.MALL.Model.CMS.VideoClass();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (DataSetTools.DataSetIsNull(ds))
            {
                return null;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["VideoClassID"] != null && ds.Tables[0].Rows[0]["VideoClassID"].ToString() != "")
                {
                    model.VideoClassID = int.Parse(ds.Tables[0].Rows[0]["VideoClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VideoClassName"] != null && ds.Tables[0].Rows[0]["VideoClassName"].ToString() != "")
                {
                    model.VideoClassName = ds.Tables[0].Rows[0]["VideoClassName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到最大顺序
        /// </summary>
        public int GetMaxSequence()
        {
            return DbHelperMySQL.GetMaxID("Sequence", "CMS_VideoClass");
        }

        /// <summary>
        /// 对类别进行排序
        /// </summary>
        /// <param name="VideoClassId">类别ID</param>
        /// <param name="zIndex">排序方式</param>
        /// <returns></returns>
        public int SwapCategorySequence(int VideoClassId, SwapSequenceIndex zIndex)
        {
            int rows;
            MySqlParameter[] parameters = {
					new MySqlParameter("?_VideoClassId",  MySqlDbType.Int32),
					new MySqlParameter("?_ZIndex",  MySqlDbType.Int32)
					};
            parameters[0].Value = VideoClassId;
            parameters[1].Value = (int)zIndex;
            //return DbHelperMySQL.RunProcedure("sp_CMS_SwapVideoClassSequence", parameters, out rows);
            DbHelperMySQL.RunProcedure("sp_CMS_SwapVideoClassSequence", parameters, out rows);
            return rows;
        }

        #endregion MethodEx
    }
}