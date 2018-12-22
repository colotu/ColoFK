using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.CMS;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 数据访问类:Photo
    /// </summary>
    public partial class Photo : IPhoto
    {
        public Photo()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("PhotoID", "CMS_Photo");
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxSequence()
        {
            return DbHelperMySQL.GetMaxID("Sequence", "CMS_Photo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PhotoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_Photo");
            strSql.Append(" where PhotoID=?PhotoID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = PhotoID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.CMS.Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_Photo(");
            strSql.Append("PhotoName,ImageUrl,Description,AlbumID,State,CreatedUserID,CreatedDate,PVCount,ClassID,ThumbImageUrl,NormalImageUrl,Sequence,IsRecomend,CommentCount,Tags)");
            strSql.Append(" values (");
            strSql.Append("?PhotoName,?ImageUrl,?Description,?AlbumID,?State,?CreatedUserID,?CreatedDate,?PVCount,?ClassID,?ThumbImageUrl,?NormalImageUrl,?Sequence,?IsRecomend,?CommentCount,?Tags)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?PVCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Bit,1),
					new MySqlParameter("?CommentCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.PhotoName;
            parameters[1].Value = model.ImageUrl;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.AlbumID;
            parameters[4].Value = model.State;
            parameters[5].Value = model.CreatedUserID;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.PVCount;
            parameters[8].Value = model.ClassID;
            parameters[9].Value = model.ThumbImageUrl;
            parameters[10].Value = model.NormalImageUrl;
            parameters[11].Value = model.Sequence;
            parameters[12].Value = model.IsRecomend;
            parameters[13].Value = model.CommentCount;
            parameters[14].Value = model.Tags;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.Photo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_Photo set ");
            strSql.Append("PhotoName=?PhotoName,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("Description=?Description,");
            strSql.Append("AlbumID=?AlbumID,");
            strSql.Append("State=?State,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("PVCount=?PVCount,");
            strSql.Append("ClassID=?ClassID,");
            strSql.Append("ThumbImageUrl=?ThumbImageUrl,");
            strSql.Append("NormalImageUrl=?NormalImageUrl,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("IsRecomend=?IsRecomend,");
            strSql.Append("CommentCount=?CommentCount,");
            strSql.Append("Tags=?Tags");
            strSql.Append(" where PhotoID=?PhotoID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?AlbumID",  MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?PVCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?IsRecomend", MySqlDbType.Bit,1),
					new MySqlParameter("?CommentCount",  MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,200),
					new MySqlParameter("?PhotoID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.PhotoName;
            parameters[1].Value = model.ImageUrl;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.AlbumID;
            parameters[4].Value = model.State;
            parameters[5].Value = model.CreatedUserID;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.PVCount;
            parameters[8].Value = model.ClassID;
            parameters[9].Value = model.ThumbImageUrl;
            parameters[10].Value = model.NormalImageUrl;
            parameters[11].Value = model.Sequence;
            parameters[12].Value = model.IsRecomend;
            parameters[13].Value = model.CommentCount;
            parameters[14].Value = model.Tags;
            parameters[15].Value = model.PhotoID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PhotoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_Photo ");
            strSql.Append(" where PhotoID=?PhotoID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = PhotoID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PhotoIDlist, out DataSet imageList)
        {
            StringBuilder strImg = new StringBuilder();
            strImg.Append(" SELECT ImageUrl ,ThumbImageUrl,NormalImageUrl FROM CMS_Photo");
            strImg.AppendFormat(" WHERE PhotoID IN ({0})  ", PhotoIDlist);
            imageList = DbHelperMySQL.Query(strImg.ToString());

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_Photo ");
            strSql.Append(" where PhotoID in (" + PhotoIDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            return rows > 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.CMS.Photo GetModel(int PhotoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   CMSP.*,AU.UserName AS CreatedUserName from CMS_Photo CMSP ");
            strSql.Append(" LEFT JOIN Accounts_Users AU ON CMSP.CreatedUserID=AU.UserID ");
            strSql.Append(" where PhotoID=?PhotoID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = PhotoID;

            Model.CMS.Photo model = new Model.CMS.Photo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PhotoID"] != null && ds.Tables[0].Rows[0]["PhotoID"].ToString() != "")
                {
                    model.PhotoID = int.Parse(ds.Tables[0].Rows[0]["PhotoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PhotoName"] != null && ds.Tables[0].Rows[0]["PhotoName"].ToString() != "")
                {
                    model.PhotoName = ds.Tables[0].Rows[0]["PhotoName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImageUrl"] != null && ds.Tables[0].Rows[0]["ImageUrl"].ToString() != "")
                {
                    model.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AlbumID"] != null && ds.Tables[0].Rows[0]["AlbumID"].ToString() != "")
                {
                    model.AlbumID = int.Parse(ds.Tables[0].Rows[0]["AlbumID"].ToString());
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
                if (ds.Tables[0].Rows[0]["ClassID"] != null && ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ThumbImageUrl"] != null && ds.Tables[0].Rows[0]["ThumbImageUrl"].ToString() != "")
                {
                    model.ThumbImageUrl = ds.Tables[0].Rows[0]["ThumbImageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NormalImageUrl"] != null && ds.Tables[0].Rows[0]["NormalImageUrl"].ToString() != "")
                {
                    model.NormalImageUrl = ds.Tables[0].Rows[0]["NormalImageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRecomend"] != null && ds.Tables[0].Rows[0]["IsRecomend"].ToString() != "")
                {
                    model.IsRecomend = (ds.Tables[0].Rows[0]["IsRecomend"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsRecomend"].ToString().ToLower() == "true");
                }
                if (ds.Tables[0].Rows[0]["CommentCount"] != null && ds.Tables[0].Rows[0]["CommentCount"].ToString() != "")
                {
                    model.CommentCount = int.Parse(ds.Tables[0].Rows[0]["CommentCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Tags"] != null && ds.Tables[0].Rows[0]["Tags"].ToString() != "")
                {
                    model.Tags = ds.Tables[0].Rows[0]["Tags"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedUserName"] != null && ds.Tables[0].Rows[0]["CreatedUserName"].ToString() != "")
                {
                    model.CreatedUserName = ds.Tables[0].Rows[0]["CreatedUserName"].ToString();
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
            strSql.Append("select T.*,PA.CoverPhoto FROM CMS_Photo  T LEFT JOIN CMS_PhotoAlbum PA ON T.AlbumID = PA.AlbumID");
            strSql.Append(" ");
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
            strSql.Append(" *  FROM CMS_Photo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top);
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
            parameters[0].Value = "CMS_Photo";
            parameters[1].Value = "PhotoID";
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
            strSql.Append("select count(1) FROM CMS_Photo T");
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
            //    strSql.Append(" order by T.PhotoID ASC");
            //}
            //strSql.Append(")AS Row, T.*,PA.CoverPhoto  from CMS_Photo T LEFT JOIN CMS_PhotoAlbum PA ON T.AlbumID = PA.AlbumID");
            //if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*,PA.CoverPhoto  from CMS_Photo T LEFT JOIN CMS_PhotoAlbum PA ON T.AlbumID = PA.AlbumID ");
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
                strSql.Append(" order by T.PhotoID ASC");
            }

            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 批量修改图片所属相册
        /// </summary>
        /// <param name="AlbumID">相册ID</param>
        /// <param name="newAlbumId">新相册ID</param>
        /// <returns></returns>
        public bool UpdatePhotoAlbum(int AlbumID, int newAlbumId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update CMS_Photo set AlbumID = ?newAlbumId where AlbumID = ?AlbumID");
            MySqlParameter[] parameters = {
                                            new MySqlParameter("?newAlbumId",  MySqlDbType.Int32),
                                            new MySqlParameter("?AlbumID",  MySqlDbType.Int32)
                                        };
            parameters[0].Value = newAlbumId;
            parameters[1].Value = AlbumID;
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        public DataSet GetListAroundPhotoId(int Top, int PhotoId, int ClassId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * ");
            strSql.Append("FROM    CMS_Photo ");
            strSql.Append("WHERE   PhotoID IN ( SELECT PhotoID ");
            strSql.Append("                     FROM   ( SELECT ");
            strSql.Append("                                        PhotoID , ");
            strSql.Append("                                        ABS(PhotoID - " + PhotoId + ") AS seq ");
            strSql.Append("                              FROM      ( SELECT    * ");
            strSql.Append("                                          FROM      CMS_Photo ");
            strSql.Append("                                          WHERE     ClassID = " + ClassId + " ");
            strSql.Append("                                        ) temp ");
            strSql.Append("                              ORDER BY  seq LIMIT " + Top + " ");
            strSql.Append("                            ) temp1 ) ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取需要重新生成缩略图的数据
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListToReGen(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select PhotoID from CMS_Photo  ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append("WHERE  " + strWhere);
            }

            //  strSql.Append("ORDER BY AddedDate DESC ");
            return DbHelperMySQL.Query((strSql.ToString()));
        }

        #endregion Extension Method
    }
}