﻿/**
* Posts.cs
*
* 功 能： N/A
* 类 名： Posts
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:47   N/A    初版
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
using System.Data.SqlClient;
using YSWL.MALL.IDAL.SNS;
using YSWL.DBUtility;
using System.Collections.Generic;
using YSWL.Common;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
    /// <summary>
    /// 数据访问类:Posts
    /// </summary>
    public partial class Posts : IPosts
    {
        public Posts()
        { }
        #region  BasicMethod





        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.SNS.Posts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_Posts(");
            strSql.Append("CreatedUserID,CreatedNickName,OriginalID,ForwardedID,Description,HasReferUsers,CommentCount,ForwardCount,Type,PostExUrl,VideoUrl,AudioUrl,ImageUrl,TargetId,TopicTitle,Price,ProductLinkUrl,ProductName,FavCount,UserIP,Status,CreatedDate,IsRecommend,Sequence,Tags)");
            strSql.Append(" values (");
            strSql.Append("?CreatedUserID,?CreatedNickName,?OriginalID,?ForwardedID,?Description,?HasReferUsers,?CommentCount,?ForwardCount,?Type,?PostExUrl,?VideoUrl,?AudioUrl,?ImageUrl,?TargetId,?TopicTitle,?Price,?ProductLinkUrl,?ProductName,?FavCount,?UserIP,?Status,?CreatedDate,?IsRecommend,?Sequence,?Tags)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OriginalID", MySqlDbType.Int32,4),
					new MySqlParameter("?ForwardedID", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar),
					new MySqlParameter("?HasReferUsers", MySqlDbType.Bit,1),
					new MySqlParameter("?CommentCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ForwardCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?PostExUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?AudioUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicTitle", MySqlDbType.VarChar,200),
					new MySqlParameter("?Price", MySqlDbType.Decimal,9),
					new MySqlParameter("?ProductLinkUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?FavCount", MySqlDbType.Int32,4),
					new MySqlParameter("?UserIP", MySqlDbType.VarChar,15),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsRecommend", MySqlDbType.Bit,1),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.CreatedUserID;
            parameters[1].Value = model.CreatedNickName;
            parameters[2].Value = model.OriginalID;
            parameters[3].Value = model.ForwardedID;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.HasReferUsers;
            parameters[6].Value = model.CommentCount;
            parameters[7].Value = model.ForwardCount;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.PostExUrl;
            parameters[10].Value = model.VideoUrl;
            parameters[11].Value = model.AudioUrl;
            parameters[12].Value = model.ImageUrl;
            parameters[13].Value = model.TargetId;
            parameters[14].Value = model.TopicTitle;
            parameters[15].Value = model.Price;
            parameters[16].Value = model.ProductLinkUrl;
            parameters[17].Value = model.ProductName;
            parameters[18].Value = model.FavCount;
            parameters[19].Value = model.UserIP;
            parameters[20].Value = model.Status;
            parameters[21].Value = model.CreatedDate;
            parameters[22].Value = model.IsRecommend;
            parameters[23].Value = model.Sequence;
            parameters[24].Value = model.Tags;

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
        public bool Update(YSWL.MALL.Model.SNS.Posts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_Posts set ");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("CreatedNickName=?CreatedNickName,");
            strSql.Append("OriginalID=?OriginalID,");
            strSql.Append("ForwardedID=?ForwardedID,");
            strSql.Append("Description=?Description,");
            strSql.Append("HasReferUsers=?HasReferUsers,");
            strSql.Append("CommentCount=?CommentCount,");
            strSql.Append("ForwardCount=?ForwardCount,");
            strSql.Append("Type=?Type,");
            strSql.Append("PostExUrl=?PostExUrl,");
            strSql.Append("VideoUrl=?VideoUrl,");
            strSql.Append("AudioUrl=?AudioUrl,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("TargetId=?TargetId,");
            strSql.Append("TopicTitle=?TopicTitle,");
            strSql.Append("Price=?Price,");
            strSql.Append("ProductLinkUrl=?ProductLinkUrl,");
            strSql.Append("ProductName=?ProductName,");
            strSql.Append("FavCount=?FavCount,");
            strSql.Append("UserIP=?UserIP,");
            strSql.Append("Status=?Status,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("IsRecommend=?IsRecommend,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("Tags=?Tags");
            strSql.Append(" where PostID=?PostID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OriginalID", MySqlDbType.Int32,4),
					new MySqlParameter("?ForwardedID", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar),
					new MySqlParameter("?HasReferUsers", MySqlDbType.Bit,1),
					new MySqlParameter("?CommentCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ForwardCount", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?PostExUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?AudioUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicTitle", MySqlDbType.VarChar,200),
					new MySqlParameter("?Price", MySqlDbType.Decimal,9),
					new MySqlParameter("?ProductLinkUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?FavCount", MySqlDbType.Int32,4),
					new MySqlParameter("?UserIP", MySqlDbType.VarChar,15),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsRecommend", MySqlDbType.Bit,1),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?PostID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CreatedUserID;
            parameters[1].Value = model.CreatedNickName;
            parameters[2].Value = model.OriginalID;
            parameters[3].Value = model.ForwardedID;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.HasReferUsers;
            parameters[6].Value = model.CommentCount;
            parameters[7].Value = model.ForwardCount;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.PostExUrl;
            parameters[10].Value = model.VideoUrl;
            parameters[11].Value = model.AudioUrl;
            parameters[12].Value = model.ImageUrl;
            parameters[13].Value = model.TargetId;
            parameters[14].Value = model.TopicTitle;
            parameters[15].Value = model.Price;
            parameters[16].Value = model.ProductLinkUrl;
            parameters[17].Value = model.ProductName;
            parameters[18].Value = model.FavCount;
            parameters[19].Value = model.UserIP;
            parameters[20].Value = model.Status;
            parameters[21].Value = model.CreatedDate;
            parameters[22].Value = model.IsRecommend;
            parameters[23].Value = model.Sequence;
            parameters[24].Value = model.Tags;
            parameters[25].Value = model.PostID;

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
        public bool Delete(int PostID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_Posts ");
            strSql.Append(" where PostID=?PostID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PostID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PostID;

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
        public bool DeleteList(string PostIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_Posts ");
            strSql.Append(" where PostID in (" + PostIDlist + ")  ");
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
        public YSWL.MALL.Model.SNS.Posts GetModel(int PostID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  PostID,CreatedUserID,CreatedNickName,OriginalID,ForwardedID,Description,HasReferUsers,CommentCount,ForwardCount,Type,PostExUrl,VideoUrl,AudioUrl,ImageUrl,TargetId,TopicTitle,Price,ProductLinkUrl,ProductName,FavCount,UserIP,Status,CreatedDate,IsRecommend,Sequence,Tags from SNS_Posts ");
            strSql.Append(" where PostID=?PostID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PostID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PostID;

            YSWL.MALL.Model.SNS.Posts model = new YSWL.MALL.Model.SNS.Posts();
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
        public YSWL.MALL.Model.SNS.Posts DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.SNS.Posts model = new YSWL.MALL.Model.SNS.Posts();
            if (row != null)
            {
                if (row["PostID"] != null && row["PostID"].ToString() != "")
                {
                    model.PostID = int.Parse(row["PostID"].ToString());
                }
                if (row["CreatedUserID"] != null && row["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(row["CreatedUserID"].ToString());
                }
                if (row["CreatedNickName"] != null)
                {
                    model.CreatedNickName = row["CreatedNickName"].ToString();
                }
                if (row["OriginalID"] != null && row["OriginalID"].ToString() != "")
                {
                    model.OriginalID = int.Parse(row["OriginalID"].ToString());
                }
                if (row["ForwardedID"] != null && row["ForwardedID"].ToString() != "")
                {
                    model.ForwardedID = int.Parse(row["ForwardedID"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["HasReferUsers"] != null && row["HasReferUsers"].ToString() != "")
                {
                    if ((row["HasReferUsers"].ToString() == "1") || (row["HasReferUsers"].ToString().ToLower() == "true"))
                    {
                        model.HasReferUsers = true;
                    }
                    else
                    {
                        model.HasReferUsers = false;
                    }
                }
                if (row["CommentCount"] != null && row["CommentCount"].ToString() != "")
                {
                    model.CommentCount = int.Parse(row["CommentCount"].ToString());
                }
                if (row["ForwardCount"] != null && row["ForwardCount"].ToString() != "")
                {
                    model.ForwardCount = int.Parse(row["ForwardCount"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["PostExUrl"] != null)
                {
                    model.PostExUrl = row["PostExUrl"].ToString();
                }
                if (row["VideoUrl"] != null)
                {
                    model.VideoUrl = row["VideoUrl"].ToString();
                }
                if (row["AudioUrl"] != null)
                {
                    model.AudioUrl = row["AudioUrl"].ToString();
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["TargetId"] != null && row["TargetId"].ToString() != "")
                {
                    model.TargetId = int.Parse(row["TargetId"].ToString());
                }
                if (row["TopicTitle"] != null)
                {
                    model.TopicTitle = row["TopicTitle"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["ProductLinkUrl"] != null)
                {
                    model.ProductLinkUrl = row["ProductLinkUrl"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["FavCount"] != null && row["FavCount"].ToString() != "")
                {
                    model.FavCount = int.Parse(row["FavCount"].ToString());
                }
                if (row["UserIP"] != null)
                {
                    model.UserIP = row["UserIP"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["IsRecommend"] != null && row["IsRecommend"].ToString() != "")
                {
                    if ((row["IsRecommend"].ToString() == "1") || (row["IsRecommend"].ToString().ToLower() == "true"))
                    {
                        model.IsRecommend = true;
                    }
                    else
                    {
                        model.IsRecommend = false;
                    }
                }
                if (row["Sequence"] != null && row["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(row["Sequence"].ToString());
                }
                if (row["Tags"] != null)
                {
                    model.Tags = row["Tags"].ToString();
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
            strSql.Append("select PostID,CreatedUserID,CreatedNickName,OriginalID,ForwardedID,Description,HasReferUsers,CommentCount,ForwardCount,Type,PostExUrl,VideoUrl,AudioUrl,ImageUrl,TargetId,TopicTitle,Price,ProductLinkUrl,ProductName,FavCount,UserIP,Status,CreatedDate,IsRecommend,Sequence,Tags ");
            strSql.Append(" FROM SNS_Posts ");
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
            
            strSql.Append(" PostID,CreatedUserID,CreatedNickName,OriginalID,ForwardedID,Description,HasReferUsers,CommentCount,ForwardCount,Type,PostExUrl,VideoUrl,AudioUrl,ImageUrl,TargetId,TopicTitle,Price,ProductLinkUrl,ProductName,FavCount,UserIP,Status,CreatedDate,IsRecommend,Sequence,Tags ");
            strSql.Append(" FROM SNS_Posts ");
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
            strSql.Append("select count(1) FROM SNS_Posts ");
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
                strSql.Append("order by T.PostID desc");
            }
            strSql.Append(")AS Row, T.*  from SNS_Posts T ");
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
            parameters[0].Value = "SNS_Posts";
            parameters[1].Value = "PostID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 更新动态转发的数量 是直接转发的动态和原始动态
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public int UpdateForwardCount(string StrWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SNS_Posts Set ForWardCount=ForWardCount+1");
            strSql.Append(" (");
            if (!string.IsNullOrEmpty(StrWhere.Trim()))
            {
                strSql.Append("where PostId in(" + StrWhere + ")");
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
        /// 转发动态的事务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddForwardPost(YSWL.MALL.Model.SNS.Posts model)
        {
            //转发的时候除过转发的内容以外，还应该直接转发动态的id和原始动态id，对他们的转发次数分别加1
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_Posts(");
            strSql.Append("Type,TopicTitle,CreatedUserID,UserIP,Status,CreatedDate,CreatedNickName,OriginalID,ForwardedID,Description,HasReferUsers)");
            strSql.Append(" values (");
            strSql.Append("?Type,?TopicTitle,?CreatedUserID,?UserIP,?Status,?CreatedDate,?CreatedNickName,?OriginalID,?ForwardedID,?Description,?HasReferUsers)");
            strSql.Append(";set ?ReturnValue= @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicTitle", MySqlDbType.VarChar,200),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserIP", MySqlDbType.VarChar,15),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?OriginalID", MySqlDbType.Int32,4),
					new MySqlParameter("?ForwardedID", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar),
					new MySqlParameter("?HasReferUsers", MySqlDbType.Bit,1),
					new MySqlParameter("?ReturnValue",MySqlDbType.Int32)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.TopicTitle;
            parameters[2].Value = model.CreatedUserID;
            parameters[3].Value = model.UserIP;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.CreatedNickName;
            parameters[7].Value = model.OriginalID;
            parameters[8].Value = model.ForwardedID;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.HasReferUsers;
            parameters[11].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            StringBuilder strSql2;

            strSql2 = new StringBuilder();
            strSql2.Append("update SNS_Posts");
            strSql2.Append(" set ForwardCount=ForwardCount+1");
            strSql2.Append(" where PostID in( " + (model.OriginalID == model.ForwardedID ? model.OriginalID.ToString() : model.OriginalID + "," + model.ForwardedID) + " )");
            cmd = new CommandInfo(strSql2.ToString(), null);
            sqllist.Add(cmd);
            DbHelperMySQL.ExecuteSqlTran(sqllist);
            return (int)parameters[11].Value;
        }
        #region 加入动态所涉及的方法
        /// <summary>
        /// 添加的动态的处理，有三种类型一种是动态，一种是商品，一种图片
        /// </summary>
        /// <param name="model"></param>
        /// <param name="AlbumId"></param>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public Model.SNS.Posts AddPost(Model.SNS.Posts model, int AlbumId, long Pid, int PhotoCateId, YSWL.MALL.Model.SNS.Products PModel, int RecommandStateInt, string photoAdress, string mapLng, string mapLat, bool CreatePost)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object TargetID = "0";
                    object PostID;
                     try
                     {
                    //如果是图片或者商品的类型，则先向图片或者商品的表中插入相应记录，再加入相应的专辑
                         if (model.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Photo || model.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Product)
                    {
                        //YSWL.MALL.Model.SNS.Products PModel = new Model.SNS.Products();
                        TargetID = DbHelperMySQL.GetSingle4Trans(GenerateImageInfo(model, PModel, AlbumId, Pid, PhotoCateId, RecommandStateInt, photoAdress, mapLng, mapLat), transaction);
                        model.TargetId = Globals.SafeInt(TargetID.ToString(), -1);
                             int type=model.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Photo ? (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Photo : (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Product;
                             DbHelperMySQL.GetSingle4Trans(GenerateAblumInfo(type,model.CreatedUserID, AlbumId, model.TargetId,model.Description), transaction);
                        DbHelperMySQL.GetSingle4Trans(GenerateUpdateUserEx(model.CreatedUserID), transaction);
                        DbHelperMySQL.GetSingle4Trans(GenerateUpdateAlbum(AlbumId), transaction);
                    }
                    //在向相应的动态表中加入相应的记录
                         if (CreatePost)
                         {
                             PostID = DbHelperMySQL.GetSingle4Trans(GeneratePostInfo(model), transaction);
                             model.PostID = Common.Globals.SafeInt(PostID.ToString(), 0);
                         }
                    
                        transaction.Commit();
                        return model;
                     }
                     catch (SqlException)
                     {
                         transaction.Rollback();
                         return null
 ;
                     }
                }
            }
        }



        public Model.SNS.Posts AddProductPost(YSWL.MALL.Model.SNS.Products PModel, int AlbumId, bool CreatePost)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object PostID;
                    try
                    {
                        //如果是图片或者商品的类型，则先向图片或者商品的表中插入相应记录，再加入相应的专辑

                        object targetID = DbHelperMySQL.GetSingle4Trans(GenerateProductInfo(PModel), transaction);
                         int TargetId = Globals.SafeInt(targetID.ToString(), -1);
                         DbHelperMySQL.GetSingle4Trans(GenerateAblumInfo((int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Product, PModel.CreateUserID, AlbumId, TargetId, PModel.ShareDescription), transaction);
                            DbHelperMySQL.GetSingle4Trans(GenerateUpdateUserEx(PModel.CreateUserID), transaction);
                            DbHelperMySQL.GetSingle4Trans(GenerateUpdateAlbum(AlbumId), transaction);

                            YSWL.MALL.Model.SNS.Posts model = new Model.SNS.Posts();
                        //在向相应的动态表中加入相应的记录
                        if (CreatePost)
                        {
                            model.Description = PModel.ShareDescription;
                            model.CreatedUserID = PModel.CreateUserID;
                            model.CreatedNickName = PModel.CreatedNickName;
                            model.ProductName = PModel.ProductName;
                            model.Status = PModel.Status;
                            model.CreatedDate = DateTime.Now;
                            model.Type = (int) YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Product;
                            model.TargetId = TargetId;
                            model.ImageUrl = PModel.ThumbImageUrl;
                            model.Price = PModel.Price;
                            model.ProductLinkUrl = PModel.ProductUrl;
                            PostID = DbHelperMySQL.GetSingle4Trans(GeneratePostInfo(model), transaction);
                            model.PostID = Common.Globals.SafeInt(PostID.ToString(), 0);
                        }

                        transaction.Commit();
                        return model;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        return null
;
                    }
                }
            }
        }


        public Model.SNS.Posts AddBlogPost(Model.SNS.Posts model,  YSWL.MALL.Model.SNS.UserBlog blogModel, bool CreatePost)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object TargetID = "0";
                    object PostID;
                    try
                    {

                        TargetID = DbHelperMySQL.GetSingle4Trans(GenerateBlog(blogModel), transaction);
                            model.TargetId = Globals.SafeInt(TargetID.ToString(), -1);
                        //在向相应的动态表中加入相应的记录
                        if (CreatePost)
                        {
                            PostID = DbHelperMySQL.GetSingle4Trans(GeneratePostInfo(model), transaction);
                            model.PostID = Common.Globals.SafeInt(PostID.ToString(), 0);
                        }

                        transaction.Commit();
                        return model;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        return null
;
                    }
                }
            }
        }


        /// <summary>
        /// 加入动态表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private CommandInfo GeneratePostInfo(Model.SNS.Posts model)
        {
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into SNS_Posts(");
            strSql2.Append("CreatedUserID,CreatedNickName,Description,HasReferUsers,Type,PostExUrl,VideoUrl,AudioUrl,ImageUrl,TargetId,TopicTitle,Price,ProductLinkUrl,ProductName,UserIP,Status,CreatedDate)");
            strSql2.Append(" values (");
            strSql2.Append("?CreatedUserID,?CreatedNickName,?Description,?HasReferUsers,?Type,?PostExUrl,?VideoUrl,?AudioUrl,?ImageUrl,?TargetId,?TopicTitle,?Price,?ProductLinkUrl,?ProductName,?UserIP,?Status,?CreatedDate)");
            strSql2.Append(";select @@IDENTITY");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Description", MySqlDbType.VarChar),
					new MySqlParameter("?HasReferUsers", MySqlDbType.Bit,1),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?PostExUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?AudioUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicTitle", MySqlDbType.VarChar,200),
					new MySqlParameter("?Price", MySqlDbType.Decimal,9),
					new MySqlParameter("?ProductLinkUrl", MySqlDbType.VarChar,500),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserIP", MySqlDbType.VarChar,15),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
            parameters2[0].Value = model.CreatedUserID;
            parameters2[1].Value = model.CreatedNickName;
            parameters2[2].Value = model.Description;
            parameters2[3].Value = model.HasReferUsers;
            parameters2[4].Value = model.Type;
            parameters2[5].Value = model.PostExUrl;
            parameters2[6].Value = model.VideoUrl;
            parameters2[7].Value = model.AudioUrl;
            if (!string.IsNullOrEmpty(model.ImageUrl)&&model.ImageUrl.Split('|').Length >= 2 && model.Type != (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Product)
            {
                parameters2[8].Value = model.ImageUrl.Split('|')[1];
            }
            else
            {
                parameters2[8].Value = model.ImageUrl;
            }
            parameters2[9].Value = model.TargetId;
            parameters2[10].Value = model.TopicTitle;
            parameters2[11].Value = model.Price;
            parameters2[12].Value = model.ProductLinkUrl;
            parameters2[13].Value = model.ProductName;
            parameters2[14].Value = model.UserIP;
            parameters2[15].Value = model.Status;
            parameters2[16].Value = model.CreatedDate;
            return new CommandInfo(strSql2.ToString(),
                 parameters2, EffentNextType.ExcuteEffectRows);

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public CommandInfo GenerateBlog(YSWL.MALL.Model.SNS.UserBlog blogModel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_UserBlog(");
            strSql.Append("Title,Summary,Description,UserID,UserName,LinkUrl,Status,Keywords,Recomend,Attachment,Remark,PvCount,TotalComment,TotalFav,TotalShare,CreatedDate)");
            strSql.Append(" values (");
            strSql.Append("?Title,?Summary,?Description,?UserID,?UserName,?LinkUrl,?Status,?Keywords,?Recomend,?Attachment,?Remark,?PvCount,?TotalComment,?TotalFav,?TotalShare,?CreatedDate)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Title", MySqlDbType.VarChar,100),
					new MySqlParameter("?Summary", MySqlDbType.VarChar,300),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
					new MySqlParameter("?LinkUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Keywords", MySqlDbType.VarChar,50),
					new MySqlParameter("?Recomend", MySqlDbType.Int32,4),
					new MySqlParameter("?Attachment", MySqlDbType.VarChar,200),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?PvCount", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalComment", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalFav", MySqlDbType.Int32,4),
					new MySqlParameter("?TotalShare", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
            parameters[0].Value = blogModel.Title;
            parameters[1].Value = blogModel.Summary;
            parameters[2].Value = blogModel.Description;
            parameters[3].Value = blogModel.UserID;
            parameters[4].Value = blogModel.UserName;
            parameters[5].Value = blogModel.LinkUrl;
            parameters[6].Value = blogModel.Status;
            parameters[7].Value = blogModel.Keywords;
            parameters[8].Value = 0;
            parameters[9].Value =blogModel.Attachment;
            parameters[10].Value = blogModel.Remark;
            parameters[11].Value = 0;
            parameters[12].Value =0;
            parameters[13].Value = 0;
            parameters[14].Value =0;
            parameters[15].Value = blogModel.CreatedDate;

            return new CommandInfo(strSql.ToString(),
                  parameters, EffentNextType.ExcuteEffectRows);
        }

        /// <summary>
        /// 加入专辑
        /// </summary>
        /// <param name="model"></param>
        /// <param name="AlbumId"></param>
        /// <param name="TargetId"></param>
        /// <returns></returns>
        private CommandInfo GenerateAblumInfo(int type,int userId, int AlbumId, int TargetId,string desc="")
        {
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("insert into SNS_UserAlbumDetail(");
            strSql1.Append("AlbumID,TargetID,Type,Description,AlbumUserId)");
            strSql1.Append(" values (");
            strSql1.Append("?AlbumID,?TargetID,?Type,?Description,?AlbumUserId)");
            strSql1.Append(";select @@IDENTITY");
            MySqlParameter[] parameters1 = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
                    new MySqlParameter("?AlbumUserId", MySqlDbType.Int32,4)};
            parameters1[0].Value = AlbumId;
            parameters1[1].Value = TargetId;
            parameters1[2].Value = type;//(model.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Photo ? (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Photo : (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Product);
            parameters1[3].Value = desc;
            parameters1[4].Value = userId;
            return new CommandInfo(strSql1.ToString(),
                  parameters1, EffentNextType.ExcuteEffectRows);

        }
        public CommandInfo GenerateUpdateAlbum(int AlbumId)
        {
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("update SNS_UserAlbums set ");
            strSql1.Append("PhotoCount=PhotoCount+1 ");
            strSql1.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters1 = { new MySqlParameter("?AlbumID", MySqlDbType.Int32, 4) };
            parameters1[0].Value = AlbumId;
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), parameters1, EffentNextType.ExcuteEffectRows);
            return cmd1;

        }

        public CommandInfo GenerateUpdateUserEx(int UserId)
        {
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("update Accounts_UsersExp set ShareCount=ShareCount+1,ProductsCount=ProductsCount+1 WHERE UserID=?UserID ");
            MySqlParameter[] parameters4 = { new MySqlParameter("?UserID", MySqlDbType.Int32, 4) };
            parameters4[0].Value = UserId;
            CommandInfo cmd4= new CommandInfo(strSql4.ToString(), parameters4, EffentNextType.ExcuteEffectRows);
            return cmd4;

        }
        /// <summary>
        /// 想商品或图片表中加入相应的记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="AlbumId"></param>
        /// <param name="Pid"></param>
        /// <returns></returns>
        private CommandInfo GenerateImageInfo(Model.SNS.Posts model, YSWL.MALL.Model.SNS.Products PModel, int AlbumId, long Pid, int PhotoCateId, int RecommandStateInt, string photoAddress, string mapLng, string mapLat)
        {
            //int AblumDetailType;
            if (model.Type != (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Normal)
            {
               if (model.Type == (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Product)
                {
           
                    #region 向相应的商品表中插入数据
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into SNS_Products(");
                    strSql.Append("ProductName,Price,ProductSourceID,CategoryID,ProductUrl,CreateUserID,CreatedNickName,ThumbImageUrl,NormalImageUrl,Status,ShareDescription,CreatedDate,Tags,IsRecomend)");
                    strSql.Append(" values (");
                    strSql.Append("?ProductName,?Price,?ProductSourceID,?CategoryID,?ProductUrl,?CreateUserID,?CreatedNickName,?ThumbImageUrl,?NormalImageUrl,?Status,?ShareDescription,?CreatedDate,?Tags,?IsRecomend)");
                    strSql.Append(";select @@IDENTITY");
                    MySqlParameter[] parameters = {
                        new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
                        new MySqlParameter("?Price", MySqlDbType.Decimal,9),
                        new MySqlParameter("?ProductSourceID", MySqlDbType.Int32,4),
                        new MySqlParameter("?CategoryID", MySqlDbType.Int32,4),
                        new MySqlParameter("?ProductUrl", MySqlDbType.VarChar,500),
                        new MySqlParameter("?CreateUserID", MySqlDbType.Int32,4),
                        new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
                        new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,300),
                        new MySqlParameter("?NormalImageUrl", MySqlDbType.VarChar,300),
                        new MySqlParameter("?Status", MySqlDbType.Int32,4),
                        new MySqlParameter("?ShareDescription", MySqlDbType.VarChar,200),
                        new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                        new MySqlParameter("?Tags",MySqlDbType.VarChar,400),  
                        new MySqlParameter("?IsRecomend", MySqlDbType.Int32,4)
                      
                      };
                    parameters[0].Value = PModel.ProductName;
                    parameters[1].Value = PModel.Price;
                    parameters[2].Value = PModel.ProductSourceID;
                    parameters[3].Value = PModel.CategoryID;
                    parameters[4].Value = PModel.ProductUrl;
                    parameters[5].Value = PModel.CreateUserID;
                    parameters[6].Value = PModel.CreatedNickName;
                    parameters[7].Value = PModel.ThumbImageUrl;
                    parameters[8].Value = PModel.NormalImageUrl;
                    parameters[9].Value = PModel.Status;
                    parameters[10].Value = PModel.ShareDescription;
                    parameters[11].Value = PModel.CreatedDate;
                    parameters[12].Value = PModel.Tags;
                    parameters[13].Value = RecommandStateInt;
    
                    return new CommandInfo(strSql.ToString(),
                                   parameters, EffentNextType.ExcuteEffectRows);
                    #endregion
                }
                else
                {
                    //AblumDetailType = (int)YSWL.MALL.Model.SNS.EnumHelper.ImageType.Picture;
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into SNS_Photos(");
                    strSql.Append(" PhotoUrl,Description,Status,CreatedUserID,CreatedNickName,CreatedDate,CategoryId,ThumbImageUrl,NormalImageUrl,IsRecomend,MapLng,MapLat,PhotoAddress,Type)");
                    strSql.Append(" values (");
                    strSql.Append(" ?PhotoUrl,?Description,?Status,?CreatedUserID,?CreatedNickName,?CreatedDate,?CategoryId,?ThumbImageUrl,?NormalImageUrl,?IsRecomend,?MapLng,?MapLat,?PhotoAddress,?Type)");
                    strSql.Append(";select @@IDENTITY");
                    MySqlParameter[] parameters = {
					new MySqlParameter("?PhotoUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,200),
                    new MySqlParameter("?NormalImageUrl", MySqlDbType.VarChar,200),
                    new MySqlParameter("?IsRecomend", MySqlDbType.Int32,4),
                     new MySqlParameter("?MapLng", MySqlDbType.VarChar,200),
                    new MySqlParameter("?MapLat", MySqlDbType.VarChar,200),
                     new MySqlParameter("?PhotoAddress", MySqlDbType.VarChar,300),
                     new MySqlParameter("?Type", MySqlDbType.Int32,4),
                                                };
                    if (!String.IsNullOrWhiteSpace(model.ImageUrl) && model.ImageUrl.Split('|').Length >= 2)
                    {
                        parameters[0].Value = model.ImageUrl.Split('|')[0];
                        parameters[7].Value = model.ImageUrl.Split('|')[1]; 
                    }
                    else
                    {
                        parameters[0].Value = "";
                        parameters[7].Value = "";
                    }
                    parameters[1].Value = model.Description;
                    ///设置默认的状态
                    
                    if (model.Status==(int)YSWL.MALL.Model.SNS.EnumHelper.PostStatus.AlreadyChecked)
                    {
                        parameters[2].Value =(int)YSWL.MALL.Model.SNS.EnumHelper.PhotoStatus.AlreadyChecked;
                    }
                    else
                    {
                        parameters[2].Value = (int)YSWL.MALL.Model.SNS.EnumHelper.PhotoStatus.UnChecked;
                    }
                    parameters[3].Value = model.CreatedUserID;
                    parameters[4].Value = model.CreatedNickName;
                    parameters[5].Value = model.CreatedDate;
                    parameters[6].Value = PhotoCateId;
                    parameters[9].Value = RecommandStateInt;
                    parameters[10].Value = mapLng;
                    parameters[11].Value = mapLat;
                    parameters[12].Value = photoAddress;
                    parameters[13].Value = 0;
                    return new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows);

                }

            }
            return null;
        }

        private CommandInfo GenerateProductInfo(YSWL.MALL.Model.SNS.Products PModel)
        {
                    #region 向相应的商品表中插入数据
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into SNS_Products(");
                    strSql.Append("ProductName,Price,ProductSourceID,CategoryID,ProductUrl,CreateUserID,CreatedNickName,ThumbImageUrl,NormalImageUrl,Status,ShareDescription,CreatedDate,Tags,IsRecomend)");
                    strSql.Append(" values (");
                    strSql.Append("?ProductName,?Price,?ProductSourceID,?CategoryID,?ProductUrl,?CreateUserID,?CreatedNickName,?ThumbImageUrl,?NormalImageUrl,?Status,?ShareDescription,?CreatedDate,?Tags,?IsRecomend)");
                    strSql.Append(";select @@IDENTITY");
                    MySqlParameter[] parameters = {
                        new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
                        new MySqlParameter("?Price", MySqlDbType.Decimal,9),
                        new MySqlParameter("?ProductSourceID", MySqlDbType.Int32,4),
                        new MySqlParameter("?CategoryID", MySqlDbType.Int32,4),
                        new MySqlParameter("?ProductUrl", MySqlDbType.VarChar,500),
                        new MySqlParameter("?CreateUserID", MySqlDbType.Int32,4),
                        new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
                        new MySqlParameter("?ThumbImageUrl", MySqlDbType.VarChar,300),
                        new MySqlParameter("?NormalImageUrl", MySqlDbType.VarChar,300),
                        new MySqlParameter("?Status", MySqlDbType.Int32,4),
                        new MySqlParameter("?ShareDescription", MySqlDbType.VarChar,200),
                        new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                        new MySqlParameter("?Tags",MySqlDbType.VarChar,400),  
                        new MySqlParameter("?IsRecomend", MySqlDbType.Int32,4)
                      
                      };
                    parameters[0].Value = PModel.ProductName;
                    parameters[1].Value = PModel.Price;
                    parameters[2].Value = PModel.ProductSourceID;
                    parameters[3].Value = PModel.CategoryID;
                    parameters[4].Value = PModel.ProductUrl;
                    parameters[5].Value = PModel.CreateUserID;
                    parameters[6].Value = PModel.CreatedNickName;
                    parameters[7].Value = PModel.ThumbImageUrl;
                    parameters[8].Value = PModel.NormalImageUrl;
                    parameters[9].Value = PModel.Status;
                    parameters[10].Value = PModel.ShareDescription;
                    parameters[11].Value = PModel.CreatedDate;
                    parameters[12].Value = PModel.Tags;
                    parameters[13].Value = 0;

                    return new CommandInfo(strSql.ToString(),
                                   parameters, EffentNextType.ExcuteEffectRows);
                    #endregion
        }
        #endregion

        public bool UpdateToDel(int PostID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_Posts set ");
            strSql.Append("PostExUrl=?PostExUrl,");
            strSql.Append("VideoUrl=?VideoUrl,");
            strSql.Append("AudioUrl=?AudioUrl,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("Status=?Status,");
            strSql.Append("Description=?Description");
            strSql.Append(" where PostID=?PostID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PostExUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?VideoUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?AudioUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
                     new MySqlParameter("?PostID", MySqlDbType.Int32,4),
                 new MySqlParameter("?Description", MySqlDbType.VarChar,100)};
            parameters[0].Value = "";
            parameters[1].Value = "";
            parameters[2].Value = "";
            parameters[3].Value = "";
            parameters[4].Value = (int)YSWL.MALL.Model.SNS.EnumHelper.PostStatus.AlreadyDel;
            parameters[5].Value = PostID;
            parameters[6].Value = "此动态已删除";
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

        #region 更新为删除状态
        /// <summary>
        /// 更新为删除状态
        /// </summary>
        /// <param name="sqllist"></param>
        /// <param name="PostID"></param>
        public void UpdateStatus(List<CommandInfo> sqllist, int PostID)
        {
            #region 更新为删除状态
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SNS_Posts SET STATUS=?STATUS Where PostID=?PostID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?STATUS", MySqlDbType.Int32,4),
                    new MySqlParameter("?PostID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = (int)YSWL.MALL.Model.SNS.EnumHelper.PostStatus.AlreadyDel;
            parameters[1].Value = PostID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            #endregion
        }
        #endregion


        #region 删除动态
        /// <summary>
        /// 更新为删除状态
        /// </summary>
        /// <param name="sqllist"></param>
        /// <param name="PostID"></param>
        public void DeleteNormal(List<CommandInfo> sqllist, int PostID)
        {
            #region 更新为删除状态
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete SNS_Posts  Where PostID=?PostID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?PostID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PostID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            #endregion
        }
        #endregion


        #region  删除单个动态
        /// <summary>
        /// 删除单个评论信息
        /// </summary>
        /// <param name="PostID"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool DeleteEx(int PostID)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            YSWL.MALL.MySqlDAL.SNS.Comments dal = new YSWL.MALL.MySqlDAL.SNS.Comments();
            YSWL.MALL.Model.SNS.Posts Model = new YSWL.MALL.Model.SNS.Posts();
            Model = GetModel(PostID);
            if (Model == null)
                return true ;
            //0：一般；1：图片；2：商品。
            int? Type = Model.Type;
            if (Type.HasValue)
            {
                     //一般
                if (Type.Value == (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Normal || Type.Value == (int)YSWL.MALL.Model.SNS.EnumHelper.PostContentType.Video)
                     {
                        //更新为删除状态
                        DeleteNormal(sqllist, PostID);
                        //删除评论信息
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("delete from SNS_Comments ");
                        strSql.Append(" where TargetId=?TargetId  AND Type=?Type");
                        MySqlParameter[] parameters = {
                    new MySqlParameter("?TargetId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Type", MySqlDbType.Int32,4)};
                        parameters[0].Value = PostID;
                        parameters[1].Value = Type;
                        CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
                        sqllist.Add(cmd); 
                         return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;
                     }
                
            }
              return false;
        }
        #endregion
        #region  删除一般动态
        public bool DeleteListByNormalPost(string PostIDs)
        {
         
                    List<CommandInfo> sqllist = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("Delete SNS_Posts  Where PostID in (" + PostIDs + ")");
                    CommandInfo cmd = new CommandInfo(strSql.ToString(),null);
                    sqllist.Add(cmd);
          
                    //删除评论信息
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.Append("delete from SNS_Comments ");
                    strSql1.Append(" where TargetId in(select PostID from SNS_Posts where PostId in (" + PostIDs + "))  AND Type=0");
                    CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), null);
                    sqllist.Add(cmd1);
                    return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;
        }
        #endregion

        public bool UpdateStatusList(string PostIds, int Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE SNS_Posts SET STATUS="+Status+" Where PostID in ("+PostIds+")");
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

        public bool UpdateFavCount(int postId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SNS_Posts Set FavCount=FavCount+1 where PostId=?PostId");
            strSql.Append(" ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?PostId", MySqlDbType.Int32,4)};
            parameters[0].Value = postId;
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


        public bool UpdateCommentCount(int postId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SNS_Posts Set CommentCount=CommentCount+1 where PostId=?PostId");
            strSql.Append(" ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?PostId", MySqlDbType.Int32,4)};
            parameters[0].Value = postId;
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

        public DataSet GetPostUserIds(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select CreatedUserID from SNS_Posts  where PostID IN (" + ids + ") ");
            //  strSql.Append("ORDER BY AddedDate DESC ");
            return DbHelperMySQL.Query((strSql.ToString()));
        }

        #endregion


    }
}

