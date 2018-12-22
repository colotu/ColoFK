using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.CMS;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 数据访问类:PhotoAlbum
    /// </summary>
    public class PhotoAlbum : IPhotoAlbum
    {
        public PhotoAlbum()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("AlbumID", "CMS_PhotoAlbum");
        }

        /// <summary>
        /// 得到最大Sequence
        /// </summary>
        public int GetMaxSequence()
        {
            return DbHelperMySQL.GetMaxID("Sequence", "CMS_PhotoAlbum");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AlbumID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_PhotoAlbum");
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
        public int Add(Model.CMS.PhotoAlbum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_PhotoAlbum(");
            strSql.Append("AlbumName,Description,CoverPhoto,State,CreatedUserID,CreatedDate,PVCount,Sequence,Privacy,LastUpdatedDate)");
            strSql.Append(" values (");
            strSql.Append("?AlbumName,?Description,?CoverPhoto,?State,?CreatedUserID,?CreatedDate,?PVCount,?Sequence,?Privacy,?LastUpdatedDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?CoverPhoto",  MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?PVCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?LastUpdatedDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CoverPhoto;
            parameters[3].Value = model.State;
            parameters[4].Value = model.CreatedUserID;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.PVCount;
            parameters[7].Value = model.Sequence;
            parameters[8].Value = model.Privacy;
            parameters[9].Value = model.LastUpdatedDate;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.PhotoAlbum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_PhotoAlbum set ");
            strSql.Append("AlbumName=?AlbumName,");
            strSql.Append("Description=?Description,");
            strSql.Append("CoverPhoto=?CoverPhoto,");
            strSql.Append("State=?State,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("PVCount=?PVCount,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("Privacy=?Privacy,");
            strSql.Append("LastUpdatedDate=?LastUpdatedDate");
            strSql.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumName",  MySqlDbType.VarChar,200),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?CoverPhoto",  MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?PVCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
					new MySqlParameter("?LastUpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.AlbumName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.CoverPhoto;
            parameters[3].Value = model.State;
            parameters[4].Value = model.CreatedUserID;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.PVCount;
            parameters[7].Value = model.Sequence;
            parameters[8].Value = model.Privacy;
            parameters[9].Value = model.LastUpdatedDate;
            parameters[10].Value = model.AlbumID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AlbumID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_PhotoAlbum ");
            strSql.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = AlbumID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string AlbumIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_PhotoAlbum ");
            strSql.Append(" where AlbumID in (" + AlbumIDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            return rows > 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.CMS.PhotoAlbum GetModel(int AlbumID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   AlbumID,AlbumName,Description,CoverPhoto,State,CreatedUserID,CreatedDate,PVCount,Sequence,Privacy,LastUpdatedDate from CMS_PhotoAlbum ");
            strSql.Append(" where AlbumID=?AlbumID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = AlbumID;

            Model.CMS.PhotoAlbum model = new Model.CMS.PhotoAlbum();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
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
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CoverPhoto"] != null && ds.Tables[0].Rows[0]["CoverPhoto"].ToString() != "")
                {
                    model.CoverPhoto = int.Parse(ds.Tables[0].Rows[0]["CoverPhoto"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PVCount"] != null && ds.Tables[0].Rows[0]["PVCount"].ToString() != "")
                {
                    model.PVCount = int.Parse(ds.Tables[0].Rows[0]["PVCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Privacy"] != null && ds.Tables[0].Rows[0]["Privacy"].ToString() != "")
                {
                    model.Privacy = int.Parse(ds.Tables[0].Rows[0]["Privacy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdatedDate"] != null && ds.Tables[0].Rows[0]["LastUpdatedDate"].ToString() != "")
                {
                    model.LastUpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdatedDate"].ToString());
                }
                return model;
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PL.*,p.ThumbImageUrl FROM CMS_PhotoAlbum PL LEFT JOIN CMS_Photo P ON p.PhotoID = PL.CoverPhoto");
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
            strSql.Append(" * FROM CMS_PhotoAlbum ");
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
            parameters[0].Value = "CMS_PhotoAlbum";
            parameters[1].Value = "AlbumID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region Extension Method

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM CMS_PhotoAlbum ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
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
            //    strSql.Append(" order by T.AlbumID ASC");
            //}
            //strSql.Append(")AS Row, T.*,P.ThumbImageUrl from CMS_PhotoAlbum T LEFT JOIN CMS_Photo P ON p.PhotoID = T.CoverPhoto");
            //if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*,P.ThumbImageUrl from CMS_PhotoAlbum T LEFT JOIN CMS_Photo P ON p.PhotoID = T.CoverPhoto ");
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
                strSql.Append(" order by T.AlbumID ASC");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion Extension Method
    }
}