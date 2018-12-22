/**
* WeiBoMsg.cs
*
* 功 能： N/A
* 类 名： WeiBoMsg
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/13 10:43:59   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Ms;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Ms
{
	/// <summary>
	/// 数据访问类:WeiBoMsg
	/// </summary>
	public partial class WeiBoMsg:IWeiBoMsg
	{
		public WeiBoMsg()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("WeiBoId", "Ms_WeiBoMsg");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int WeiBoId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_WeiBoMsg");
            strSql.Append(" where WeiBoId=?WeiBoId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WeiBoId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = WeiBoId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.WeiBoMsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_WeiBoMsg(");
            strSql.Append("WeiboMsg,ImageUrl,CreateDate,PublishDate)");
            strSql.Append(" values (");
            strSql.Append("?WeiboMsg,?ImageUrl,?CreateDate,?PublishDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WeiboMsg", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?PublishDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.WeiboMsg;
            parameters[1].Value = model.ImageUrl;
            parameters[2].Value = model.CreateDate;
            parameters[3].Value = model.PublishDate;

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
        public bool Update(YSWL.MALL.Model.Ms.WeiBoMsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_WeiBoMsg set ");
            strSql.Append("WeiboMsg=?WeiboMsg,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("CreateDate=?CreateDate,");
            strSql.Append("PublishDate=?PublishDate");
            strSql.Append(" where WeiBoId=?WeiBoId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WeiboMsg", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?PublishDate", MySqlDbType.DateTime),
					new MySqlParameter("?WeiBoId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.WeiboMsg;
            parameters[1].Value = model.ImageUrl;
            parameters[2].Value = model.CreateDate;
            parameters[3].Value = model.PublishDate;
            parameters[4].Value = model.WeiBoId;

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
        public bool Delete(int WeiBoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_WeiBoMsg ");
            strSql.Append(" where WeiBoId=?WeiBoId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WeiBoId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = WeiBoId;

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
        public bool DeleteList(string WeiBoIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_WeiBoMsg ");
            strSql.Append(" where WeiBoId in (" + WeiBoIdlist + ")  ");
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
        public YSWL.MALL.Model.Ms.WeiBoMsg GetModel(int WeiBoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WeiBoId,WeiboMsg,ImageUrl,CreateDate,PublishDate from Ms_WeiBoMsg ");
            strSql.Append(" where WeiBoId=?WeiBoId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?WeiBoId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = WeiBoId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Ms.WeiBoMsg model = new YSWL.MALL.Model.Ms.WeiBoMsg();
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
        public YSWL.MALL.Model.Ms.WeiBoMsg DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Ms.WeiBoMsg model = new YSWL.MALL.Model.Ms.WeiBoMsg();
            if (row != null)
            {
                if (row["WeiBoId"] != null && row["WeiBoId"].ToString() != "")
                {
                    model.WeiBoId = int.Parse(row["WeiBoId"].ToString());
                }
                if (row["WeiboMsg"] != null)
                {
                    model.WeiboMsg = row["WeiboMsg"].ToString();
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["PublishDate"] != null && row["PublishDate"].ToString() != "")
                {
                    model.PublishDate = DateTime.Parse(row["PublishDate"].ToString());
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
            strSql.Append("select WeiBoId,WeiboMsg,ImageUrl,CreateDate,PublishDate ");
            strSql.Append(" FROM Ms_WeiBoMsg ");
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
            
            strSql.Append(" WeiBoId,WeiboMsg,ImageUrl,CreateDate,PublishDate ");
            strSql.Append(" FROM Ms_WeiBoMsg ");
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
            strSql.Append("select count(1) FROM Ms_WeiBoMsg ");
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
            strSql.Append("SELECT T.* from Ms_WeiBoMsg T ");
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
                strSql.Append("order by T.WeiBoId desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
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
            parameters[0].Value = "Ms_WeiBoMsg";
            parameters[1].Value = "WeiBoId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

