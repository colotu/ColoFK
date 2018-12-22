/**
* UserAlbumDetail.cs
*
* 功 能： N/A
* 类 名： UserAlbumDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:15:00   N/A    初版
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
using System.Collections.Generic;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
    /// <summary>
    /// 数据访问类:UserAlbumDetail
    /// </summary>
    public partial class UserAlbumDetail : IUserAlbumDetail
    {
        public UserAlbumDetail()
        { }
        #region  BasicMethod



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AlbumID, int TargetID, int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SNS_UserAlbumDetail");
            strSql.Append(" where AlbumID=?AlbumID and TargetID=?TargetID and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4)			};
            parameters[0].Value = AlbumID;
            parameters[1].Value = TargetID;
            parameters[2].Value = Type;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.SNS.UserAlbumDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_UserAlbumDetail(");
            strSql.Append("AlbumID,TargetID,Type,Description)");
            strSql.Append(" values (");
            strSql.Append("?AlbumID,?TargetID,?Type,?Description)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
                    new MySqlParameter("?AlbumUserId", MySqlDbType.Int32,4),     };
            parameters[0].Value = model.AlbumID;
            parameters[1].Value = model.TargetID;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.AlbumUserId;

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
        public bool Update(YSWL.MALL.Model.SNS.UserAlbumDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_UserAlbumDetail set ");
            strSql.Append("Description=?Description");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
					new MySqlParameter("?ID", MySqlDbType.Int32,4),
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Description;
            parameters[1].Value = model.ID;
            parameters[2].Value = model.AlbumID;
            parameters[3].Value = model.TargetID;
            parameters[4].Value = model.Type;

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
            strSql.Append("delete from SNS_UserAlbumDetail ");
            strSql.Append(" where ID=?ID");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AlbumID, int TargetID, int Type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_UserAlbumDetail ");
            strSql.Append(" where AlbumID=?AlbumID and TargetID=?TargetID and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4)			};
            parameters[0].Value = AlbumID;
            parameters[1].Value = TargetID;
            parameters[2].Value = Type;

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
            strSql.Append("delete from SNS_UserAlbumDetail ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public YSWL.MALL.Model.SNS.UserAlbumDetail GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,AlbumID,TargetID,Type,Description from SNS_UserAlbumDetail ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

            YSWL.MALL.Model.SNS.UserAlbumDetail model = new YSWL.MALL.Model.SNS.UserAlbumDetail();
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
        public YSWL.MALL.Model.SNS.UserAlbumDetail DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.SNS.UserAlbumDetail model = new YSWL.MALL.Model.SNS.UserAlbumDetail();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["AlbumID"] != null && row["AlbumID"].ToString() != "")
                {
                    model.AlbumID = int.Parse(row["AlbumID"].ToString());
                }
                if (row["TargetID"] != null && row["TargetID"].ToString() != "")
                {
                    model.TargetID = int.Parse(row["TargetID"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
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
            strSql.Append("select ID,AlbumID,TargetID,Type,Description ");
            strSql.Append(" FROM SNS_UserAlbumDetail ");
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
            
            strSql.Append(" ID,AlbumID,TargetID,Type,Description ");
            strSql.Append(" FROM SNS_UserAlbumDetail ");
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
            strSql.Append("select count(1) FROM SNS_UserAlbumDetail ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from SNS_UserAlbumDetail T ");
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
            parameters[0].Value = "SNS_UserAlbumDetail";
            parameters[1].Value = "ID";
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
        /// 获得专辑的推荐产品照片
        /// </summary>
        public List<string> GetThumbImageByAlbum(int AlbumID,int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT A.ThumbImageUrl FROM    ( ");
            switch (type)
            {
                case 0:
                    strSql.AppendFormat(
                        " SELECT p.ThumbImageUrl ,  p.PhotoID ID  FROM      SNS_UserAlbumDetail d ,SNS_Photos p WHERE     d.Type = 0 AND d.AlbumID = {0} AND d.TargetID = p.PhotoID LIMIT 9",
                        AlbumID);
                    break;
                case 1:
                    strSql.AppendFormat(
                     " SELECT p.ThumbImageUrl , p.ProductID ID FROM      SNS_UserAlbumDetail d ,SNS_Products p WHERE     d.Type = 1 AND d.AlbumID = {0} AND d.TargetID = p.ProductID LIMIT 9",
                     AlbumID);
                    break;

                default:
                    strSql.AppendFormat(
                  " SELECT p.ThumbImageUrl ,  p.PhotoID ID  FROM      SNS_UserAlbumDetail d ,SNS_Photos p WHERE     d.Type = 0 AND d.AlbumID = {0} AND d.TargetID = p.PhotoID LIMIT 9",
                  AlbumID);
                    strSql.Append(" UNION ");
                    strSql.AppendFormat(
              " SELECT p.ThumbImageUrl , p.ProductID ID FROM      SNS_UserAlbumDetail d ,SNS_Products p WHERE     d.Type = 1 AND d.AlbumID = {0} AND d.TargetID = p.ProductID LIMIT 9",
              AlbumID);
                    break;
            }
            strSql.Append("        ) A ORDER BY A.ID DESC   LIMIT 9 ");
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            List<string> imglist = new List<string>();
            if (ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr != null)
                    {
                        //专辑的产品图片 300x300 替换为 60x60 的以减少流量损耗, BEN ADD 2012-11-26
                        imglist.Add(dr["ThumbImageUrl"].ToString().Replace("300x300", "60x60"));
                    }
                }
            }
            return imglist;
        }


        /// <summary>
        /// 获得专辑下的图片记录总数
        /// </summary>
        public int GetRecordCount4AlbumImgByAlbumID(int albumID, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) FROM SNS_UserAlbumDetail  where  AlbumID={0}", albumID);
            if (type != -1)
            {
                strSql.AppendFormat(" and type={0}", type);
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
        /// 获得专辑下的图片数据列表
        /// </summary>
        public DataSet GetAlbumImgListByPage(int albumID, string orderby, int startIndex, int endIndex, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from ");
            //TODO: GetAlbumImgListByPage 结果集中的Type字段 并非来自于Photo表, 而是在Sql文中增加的固定字段 0:数据来自Photo表 1:数据来自产品表
            switch (type)
            {
                case  0:
                                strSql.Append(" (select uad.ID,p.PhotoID TargetID,p.PhotoName TargetName,p.Description Description,p.TopCommentsId TopCommentsId,p.CommentCount,p.FavouriteCount,p.ThumbImageUrl,0 price,0 Type ");
            strSql.AppendFormat("  FROM      SNS_UserAlbumDetail uad   INNER JOIN SNS_Photos p ON uad.TargetID = p.PhotoID AND uad.Type = 0  AND uad.AlbumID = {0}",albumID);
                    break;
                case  1:
                                   strSql.Append(" (select uad.ID,p.ProductID TargetID,p.ProductName TargetName,p.ShareDescription Description,p.TopCommentsId TopCommentsId,p.CommentCount,p.FavouriteCount,p.ThumbImageUrl,p.Price,1 Type");
                      strSql.AppendFormat(" FROM   SNS_UserAlbumDetail uad  INNER JOIN SNS_Products p ON uad.TargetID = p.ProductID AND uad.Type = 1 AND uad.AlbumID = {0}", albumID);
                    break;
                default:
                      strSql.Append(" (select uad.ID,p.ProductID TargetID,p.ProductName TargetName,p.ShareDescription Description,p.TopCommentsId TopCommentsId,p.CommentCount,p.FavouriteCount,p.ThumbImageUrl,p.Price,1 Type");
                      strSql.AppendFormat(" FROM   SNS_UserAlbumDetail uad  INNER JOIN SNS_Products p ON uad.TargetID = p.ProductID AND uad.Type = 1 AND uad.AlbumID = {0}", albumID);
            strSql.Append(" union");
            strSql.Append(" select uad.ID,p.PhotoID TargetID,p.PhotoName TargetName,p.Description Description,p.TopCommentsId TopCommentsId,p.CommentCount,p.FavouriteCount,p.ThumbImageUrl,0 price,0 Type ");
            strSql.AppendFormat("  FROM      SNS_UserAlbumDetail uad   INNER JOIN SNS_Photos p ON uad.TargetID = p.PhotoID AND uad.Type = 0  AND uad.AlbumID = {0}",albumID);
          
                    break;
            }
            strSql.Append("  )T ");
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            return DbHelperMySQL.Query(strSql.ToString());
        }

        public bool AddEx(YSWL.MALL.Model.SNS.UserAlbumDetail model)
        {

            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_UserAlbumDetail(");
            strSql.Append("AlbumID,TargetID,Type,Description,AlbumUserId)");
            strSql.Append(" values (");
            strSql.Append("?AlbumID,?TargetID,?Type,?Description,?AlbumUserId)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4),
					new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,200),
                    new MySqlParameter("?AlbumUserId", MySqlDbType.Int32,4),     };
            parameters[0].Value = model.AlbumID;
            parameters[1].Value = model.TargetID;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.AlbumUserId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("update SNS_UserAlbums set ");
            strSql1.Append("PhotoCount=PhotoCount+1 ");
            strSql1.Append(" where AlbumID=?AlbumID");
            MySqlParameter[] parameters1 = { new MySqlParameter("?AlbumID", MySqlDbType.Int32, 4) };
            parameters1[0].Value = model.AlbumID;
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd1);

            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;

        }



        /// <summary>
        /// 删除专辑中具体图片的信息的动作
        /// </summary>
        /// <param name="TargetId"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool DeleteEx(int AlbumID, int TargetId, int Type)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            #region 删除专辑中的具体图片
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from SNS_UserAlbumDetail ");
            strSql1.Append(" where TargetID=?TargetID and Type=?Type and AlbumID=?AlbumID");
            MySqlParameter[] parameters1 = {
					new MySqlParameter("?TargetID", MySqlDbType.Int32,4),
                    new MySqlParameter("?Type", MySqlDbType.Int32,4),
                    new MySqlParameter("?AlbumID", MySqlDbType.Int32,4)
			};
            parameters1[0].Value = TargetId;
            parameters1[1].Value = Type;
            parameters1[2].Value = AlbumID;
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd1);
            #endregion

            #region  专辑图片数量-1
            StringBuilder strSql = new StringBuilder();

            strSql.Append("update SNS_UserAlbums set PhotoCount=PhotoCount-1");
            strSql.Append(" where AlbumID=?AlbumID ");


            MySqlParameter[] parameters = {
					new MySqlParameter("?AlbumID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AlbumID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            #endregion

            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;

        }
        #endregion  ExtensionMethod
    }
}

