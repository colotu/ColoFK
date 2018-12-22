/**
* VideoAlbum.cs
*
* 功 能：
* 类 名： VideoAlbum
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
using YSWL.DBUtility;
using YSWL.MALL.IDAL.CMS;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 数据访问类:VideoAlbum
    /// </summary>
    public partial class VideoAlbum : IVideoAlbum
    {
        public VideoAlbum()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("AlbumID", "CMS_VideoAlbum");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AlbumID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_VideoAlbum");
            strSql.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AlbumID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.CMS.VideoAlbum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_VideoAlbum(");
            strSql.Append("AlbumName,CoverVideo,Description,CreatedUserID,CreatedDate,LastUpdateUserID,LastUpdatedDate,State,Sequence,Privacy,PvCount)");
            strSql.Append(" values (");
            strSql.Append("?AlbumName,?CoverVideo,?Description,?CreatedUserID,?CreatedDate,?LastUpdateUserID,?LastUpdatedDate,?State,?Sequence,?Privacy,?PvCount)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CoverVideo", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?LastUpdateUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?LastUpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?PvCount",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.CoverVideo;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.CreatedDate;
            parameters[5].Value = model.LastUpdateUserID;
            parameters[6].Value = model.LastUpdatedDate;
            parameters[7].Value = model.State;
            parameters[8].Value = model.Sequence;
            parameters[9].Value = model.Privacy;
            parameters[10].Value = model.PvCount;

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
        public bool Update(YSWL.MALL.Model.CMS.VideoAlbum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_VideoAlbum set ");
            strSql.Append("AlbumName=?AlbumName,");
            strSql.Append("CoverVideo=?CoverVideo,");
            strSql.Append("Description=?Description,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("LastUpdateUserID=?LastUpdateUserID,");
            strSql.Append("LastUpdatedDate=?LastUpdatedDate,");
            strSql.Append("State=?State,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("Privacy=?Privacy,");
            strSql.Append("PvCount=?PvCount");
            strSql.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CoverVideo", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?LastUpdateUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?LastUpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?PvCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.CoverVideo;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.CreatedUserID;
            parameters[4].Value = model.CreatedDate;
            parameters[5].Value = model.LastUpdateUserID;
            parameters[6].Value = model.LastUpdatedDate;
            parameters[7].Value = model.State;
            parameters[8].Value = model.Sequence;
            parameters[9].Value = model.Privacy;
            parameters[10].Value = model.PvCount;
            parameters[11].Value = model.AlbumID;

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
        public bool Delete(int AlbumID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_VideoAlbum ");
            strSql.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AlbumID;

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
        public bool DeleteList(string AlbumIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_VideoAlbum ");
            strSql.Append(" where AlbumID in (" + AlbumIDlist + ")  ");
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
        public YSWL.MALL.Model.CMS.VideoAlbum GetModel(int AlbumID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  AlbumID,AlbumName,CoverVideo,Description,CreatedUserID,CreatedDate,LastUpdateUserID,LastUpdatedDate,State,Sequence,Privacy,PvCount from CMS_VideoAlbum ");
            strSql.Append(" where AlbumID=?AlbumID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AlbumID;

            YSWL.MALL.Model.CMS.VideoAlbum model = new YSWL.MALL.Model.CMS.VideoAlbum();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (DataSetTools.DataSetIsNull(ds))
            {
                return null;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AlbumID"] != null && ds.Tables[0].Rows[0]["AlbumID"].ToString() != "")
                {
                    model.AlbumID = int.Parse(ds.Tables[0].Rows[0]["AlbumID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlbumName"] != null && ds.Tables[0].Rows[0]["AlbumName"].ToString() != "")
                {
                    model.AlbumName = ds.Tables[0].Rows[0]["AlbumName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CoverVideo"] != null && ds.Tables[0].Rows[0]["CoverVideo"].ToString() != "")
                {
                    model.CoverVideo = ds.Tables[0].Rows[0]["CoverVideo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateUserID"] != null && ds.Tables[0].Rows[0]["LastUpdateUserID"].ToString() != "")
                {
                    model.LastUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["LastUpdateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdatedDate"] != null && ds.Tables[0].Rows[0]["LastUpdatedDate"].ToString() != "")
                {
                    model.LastUpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Privacy"] != null && ds.Tables[0].Rows[0]["Privacy"].ToString() != "")
                {
                    model.Privacy = int.Parse(ds.Tables[0].Rows[0]["Privacy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PvCount"] != null && ds.Tables[0].Rows[0]["PvCount"].ToString() != "")
                {
                    model.PvCount = int.Parse(ds.Tables[0].Rows[0]["PvCount"].ToString());
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
            strSql.Append("select AlbumID,AlbumName,CoverVideo,Description,CreatedUserID,CreatedDate,LastUpdateUserID,LastUpdatedDate,State,Sequence,Privacy,PvCount ");
            strSql.Append(" FROM CMS_VideoAlbum ");
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
            strSql.Append(" AlbumID,AlbumName,CoverVideo,Description,CreatedUserID,CreatedDate,LastUpdateUserID,LastUpdatedDate,State,Sequence,Privacy,PvCount ");
            strSql.Append(" FROM CMS_VideoAlbum ");
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
            strSql.Append("select count(1) FROM CMS_VideoAlbum ");
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
            //    strSql.Append(" order by T.AlbumID desc");
            //}
            //strSql.Append(")AS Row, T.*  from CMS_VideoAlbum T ");
            //if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*  from CMS_VideoAlbum T ");
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
                strSql.Append(" order by T.AlbumID desc");
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
            parameters[0].Value = "CMS_VideoAlbum";
            parameters[1].Value = "AlbumID";
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM View_VideoAlbum ");

            //strSql.Append(" SELECT * ,Accounts_Users.UserName AS LastUpdateUserName from CMS_VideoAlbum CMSVA ");
            //strSql.Append(" LEFT JOIN Accounts_Users ON Accounts_Users.UserID= CMSVA.LastUpdateUserID ");
            //strSql.Append(" LEFT JOIN (SELECT * ,Accounts_Users.UserName AS CreatedUserName FROM CMS_VideoAlbum CMV ");
            //strSql.Append(" LEFT JOIN  Accounts_Users ON Accounts_Users.UserID= CMV.CreatedUserID) CMSVAS ON CMSVAS.AlbumID=CMSVA.AlbumID  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            {
                strSql.Append(" order by " + orderby);
            }
            else
            {
                strSql.Append(" order by AlbumID desc");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.CMS.VideoAlbum GetModelEx(int AlbumID)
        {
            StringBuilder strSql = new StringBuilder();

            //strSql.Append("select  top 1 *,Accounts_Users.UserName AS LastUpdateUserName from CMS_VideoAlbum CMSVA ");
            //strSql.Append(" LEFT JOIN Accounts_Users ON Accounts_Users.UserID= CMSVA.LastUpdateUserID ");
            //strSql.Append(" LEFT JOIN (SELECT * ,Accounts_Users.UserName AS CreatedUserName FROM CMS_VideoAlbum CMV ");
            //strSql.Append(" LEFT JOIN  Accounts_Users ON Accounts_Users.UserID= CMV.CreatedUserID) CMSVAS ON CMSVAS.AlbumID=CMSVA.AlbumID  ");
            //strSql.Append(" where CMSVA.AlbumID=?AlbumID");
            strSql.Append(" SELECT  * FROM View_VideoAlbum ");
            strSql.Append(" where AlbumID=?AlbumID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AlbumID;

            YSWL.MALL.Model.CMS.VideoAlbum model = new YSWL.MALL.Model.CMS.VideoAlbum();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (DataSetTools.DataSetIsNull(ds))
            {
                return null;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AlbumID"] != null && ds.Tables[0].Rows[0]["AlbumID"].ToString() != "")
                {
                    model.AlbumID = int.Parse(ds.Tables[0].Rows[0]["AlbumID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlbumName"] != null && ds.Tables[0].Rows[0]["AlbumName"].ToString() != "")
                {
                    model.AlbumName = ds.Tables[0].Rows[0]["AlbumName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CoverVideo"] != null && ds.Tables[0].Rows[0]["CoverVideo"].ToString() != "")
                {
                    model.CoverVideo = ds.Tables[0].Rows[0]["CoverVideo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserName"] != null && ds.Tables[0].Rows[0]["CreatedUserName"].ToString() != "")
                {
                    model.CreatedUserName = ds.Tables[0].Rows[0]["CreatedUserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateUserID"] != null && ds.Tables[0].Rows[0]["LastUpdateUserID"].ToString() != "")
                {
                    model.LastUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["LastUpdateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateUserName"] != null && ds.Tables[0].Rows[0]["CreatedUserName"].ToString() != "")
                {
                    model.LastUpdateUserName = ds.Tables[0].Rows[0]["LastUpdateUserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LastUpdatedDate"] != null && ds.Tables[0].Rows[0]["LastUpdatedDate"].ToString() != "")
                {
                    model.LastUpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Privacy"] != null && ds.Tables[0].Rows[0]["Privacy"].ToString() != "")
                {
                    model.Privacy = int.Parse(ds.Tables[0].Rows[0]["Privacy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PvCount"] != null && ds.Tables[0].Rows[0]["PvCount"].ToString() != "")
                {
                    model.PvCount = int.Parse(ds.Tables[0].Rows[0]["PvCount"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #region 批量处理

        /// <summary>
        /// 批量处理
        /// </summary>
        /// <param name="IDlist"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_VideoAlbum set " + strWhere);
            strSql.Append(" where AlbumID in(" + IDlist + ")  ");
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

        #endregion 批量处理

        /// <summary>
        /// 得到最大顺序
        /// </summary>
        public int GetMaxSequence()
        {
            return DbHelperMySQL.GetMaxID("Sequence", "CMS_VideoAlbum");
        }

        #endregion MethodEx
    }
}