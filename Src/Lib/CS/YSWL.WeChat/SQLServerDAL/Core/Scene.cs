﻿/**  版本信息模板在安装目录下，可自行修改。
* Scene.cs
*
* 功 能： N/A
* 类 名： Scene
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/20 12:32:06   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.WeChat.IDAL.Core;
using YSWL.DBUtility;//Please add references
namespace YSWL.WeChat.SQLServerDAL.Core
{
	/// <summary>
	/// 数据访问类:Scene
	/// </summary>
	public partial class Scene:IScene
	{
		public Scene()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DBHelper.DefaultDBHelper.GetMaxID("SceneId", "WeChat_Scene");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SceneId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WeChat_Scene");
            strSql.Append(" where SceneId=@SceneId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SceneId", SqlDbType.Int,4)
            };
            parameters[0].Value = SceneId;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.WeChat.Model.Core.Scene model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WeChat_Scene(");
            strSql.Append("OpenId,Name,CreateTime,CreatedUserId,Remark,ImageUrl)");
            strSql.Append(" values (");
            strSql.Append("@OpenId,@Name,@CreateTime,@CreatedUserId,@Remark,@ImageUrl)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OpenId", SqlDbType.NVarChar,200),
                    new SqlParameter("@Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatedUserId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@ImageUrl", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.OpenId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.CreatedUserId;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.ImageUrl;

            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(YSWL.WeChat.Model.Core.Scene model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WeChat_Scene set ");
            strSql.Append("OpenId=@OpenId,");
            strSql.Append("Name=@Name,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("CreatedUserId=@CreatedUserId,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("ImageUrl=@ImageUrl");
            strSql.Append(" where SceneId=@SceneId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OpenId", SqlDbType.NVarChar,200),
                    new SqlParameter("@Name", SqlDbType.NVarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@CreatedUserId", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@ImageUrl", SqlDbType.NVarChar,500),
                    new SqlParameter("@SceneId", SqlDbType.Int,4)};
            parameters[0].Value = model.OpenId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.CreatedUserId;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.SceneId;

            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int SceneId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WeChat_Scene ");
            strSql.Append(" where SceneId=@SceneId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SceneId", SqlDbType.Int,4)
            };
            parameters[0].Value = SceneId;

            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string SceneIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WeChat_Scene ");
            strSql.Append(" where SceneId in (" + SceneIdlist + ")  ");
            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString());
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
        public YSWL.WeChat.Model.Core.Scene GetModel(int SceneId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SceneId,OpenId,Name,CreateTime,CreatedUserId,Remark,ImageUrl from WeChat_Scene ");
            strSql.Append(" where SceneId=@SceneId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SceneId", SqlDbType.Int,4)
            };
            parameters[0].Value = SceneId;

            YSWL.WeChat.Model.Core.Scene model = new YSWL.WeChat.Model.Core.Scene();
            DataSet ds = DBHelper.DefaultDBHelper.Query(strSql.ToString(), parameters);
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
        public YSWL.WeChat.Model.Core.Scene DataRowToModel(DataRow row)
        {
            YSWL.WeChat.Model.Core.Scene model = new YSWL.WeChat.Model.Core.Scene();
            if (row != null)
            {
                if (row["SceneId"] != null && row["SceneId"].ToString() != "")
                {
                    model.SceneId = int.Parse(row["SceneId"].ToString());
                }
                if (row["OpenId"] != null)
                {
                    model.OpenId = row["OpenId"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["CreatedUserId"] != null && row["CreatedUserId"].ToString() != "")
                {
                    model.CreatedUserId = int.Parse(row["CreatedUserId"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
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
            strSql.Append("select SceneId,OpenId,Name,CreateTime,CreatedUserId,Remark,ImageUrl ");
            strSql.Append(" FROM WeChat_Scene ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
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
            strSql.Append(" SceneId,OpenId,Name,CreateTime,CreatedUserId,Remark,ImageUrl ");
            strSql.Append(" FROM WeChat_Scene ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM WeChat_Scene ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString());
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
                strSql.Append("order by T.SceneId desc");
            }
            strSql.Append(")AS Row, T.*  from WeChat_Scene T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }

 

        #endregion  BasicMethod
        #region  ExtensionMethod

	    public YSWL.WeChat.Model.Core.Scene GetSceneInfo(int userId)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from WeChat_Scene ");
            strSql.Append(" where CreatedUserId=@CreatedUserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@CreatedUserId", SqlDbType.Int,4)
            };
            parameters[0].Value = userId;

            YSWL.WeChat.Model.Core.Scene model = new YSWL.WeChat.Model.Core.Scene();
            DataSet ds = DBHelper.DefaultDBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }

        }

	    #endregion  ExtensionMethod
    }
}

