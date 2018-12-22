/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：AdvertisePosition.cs
// 文件功能描述：
//
// 创建标识： [孙鹏]  2012/05/31 13:22:19
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Settings;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Settings
{
    /// <summary>
    /// 数据访问类:AdvertisePosition
    /// </summary>
    public partial class AdvertisePosition : IAdvertisePosition
    {
        public AdvertisePosition()
        { }

        #region Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AdvPositionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM AD_AdvertisePosition");
            strSql.Append(" WHERE AdvPositionId=?AdvPositionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvPositionId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AdvPositionId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Settings.AdvertisePosition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT intO AD_AdvertisePosition(");
            strSql.Append("AdvPositionName,ShowType,RepeatColumns,Width,Height,AdvHtml,IsOne,TimeInterval,CreatedDate,CreatedUserID)");
            strSql.Append(" VALUES (");
            strSql.Append("?AdvPositionName,?ShowType,?RepeatColumns,?Width,?Height,?AdvHtml,?IsOne,?TimeInterval,?CreatedDate,?CreatedUserID)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvPositionName", MySqlDbType.VarString,50),
					new MySqlParameter("?ShowType",  MySqlDbType.Int32,4),
					new MySqlParameter("?RepeatColumns",  MySqlDbType.Int32,4),
					new MySqlParameter("?Width",  MySqlDbType.Int32,4),
					new MySqlParameter("?Height",  MySqlDbType.Int32,4),
					new MySqlParameter("?AdvHtml", MySqlDbType.VarString,1000),
					new MySqlParameter("?IsOne", MySqlDbType.Bit,1),
					new MySqlParameter("?TimeInterval",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.AdvPositionName;
            parameters[1].Value = model.ShowType;
            parameters[2].Value = model.RepeatColumns;
            parameters[3].Value = model.Width;
            parameters[4].Value = model.Height;
            parameters[5].Value = model.AdvHtml;
            parameters[6].Value = model.IsOne;
            parameters[7].Value = model.TimeInterval;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.CreatedUserID;

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
        public bool Update(YSWL.MALL.Model.Settings.AdvertisePosition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AD_AdvertisePosition SET ");
            strSql.Append("AdvPositionName=?AdvPositionName,");
            strSql.Append("ShowType=?ShowType,");
            strSql.Append("RepeatColumns=?RepeatColumns,");
            strSql.Append("Width=?Width,");
            strSql.Append("Height=?Height,");
            strSql.Append("AdvHtml=?AdvHtml,");
            strSql.Append("IsOne=?IsOne,");
            strSql.Append("TimeInterval=?TimeInterval,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("CreatedUserID=?CreatedUserID");
            strSql.Append(" WHERE AdvPositionId=?AdvPositionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvPositionName", MySqlDbType.VarString,50),
					new MySqlParameter("?ShowType",  MySqlDbType.Int32,4),
					new MySqlParameter("?RepeatColumns",  MySqlDbType.Int32,4),
					new MySqlParameter("?Width",  MySqlDbType.Int32,4),
					new MySqlParameter("?Height",  MySqlDbType.Int32,4),
					new MySqlParameter("?AdvHtml", MySqlDbType.VarString,1000),
					new MySqlParameter("?IsOne", MySqlDbType.Bit,1),
					new MySqlParameter("?TimeInterval",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?AdvPositionId",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.AdvPositionName;
            parameters[1].Value = model.ShowType;
            parameters[2].Value = model.RepeatColumns;
            parameters[3].Value = model.Width;
            parameters[4].Value = model.Height;
            parameters[5].Value = model.AdvHtml;
            parameters[6].Value = model.IsOne;
            parameters[7].Value = model.TimeInterval;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.CreatedUserID;
            parameters[10].Value = model.AdvPositionId;

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
        public bool Delete(int AdvPositionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM AD_AdvertisePosition ");
            strSql.Append(" WHERE AdvPositionId=?AdvPositionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvPositionId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AdvPositionId;

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
        public bool DeleteList(string AdvPositionIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM AD_AdvertisePosition ");
            strSql.Append(" WHERE AdvPositionId in (" + AdvPositionIdlist + ")  ");
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
        public YSWL.MALL.Model.Settings.AdvertisePosition GetModel(int AdvPositionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT    * FROM AD_AdvertisePosition ");
            strSql.Append(" WHERE AdvPositionId=?AdvPositionId LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvPositionId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AdvPositionId;

            YSWL.MALL.Model.Settings.AdvertisePosition model = new YSWL.MALL.Model.Settings.AdvertisePosition();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AdvPositionId"] != null && ds.Tables[0].Rows[0]["AdvPositionId"].ToString() != "")
                {
                    model.AdvPositionId = int.Parse(ds.Tables[0].Rows[0]["AdvPositionId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdvPositionName"] != null && ds.Tables[0].Rows[0]["AdvPositionName"].ToString() != "")
                {
                    model.AdvPositionName = ds.Tables[0].Rows[0]["AdvPositionName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ShowType"] != null && ds.Tables[0].Rows[0]["ShowType"].ToString() != "")
                {
                    model.ShowType = int.Parse(ds.Tables[0].Rows[0]["ShowType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RepeatColumns"] != null && ds.Tables[0].Rows[0]["RepeatColumns"].ToString() != "")
                {
                    model.RepeatColumns = int.Parse(ds.Tables[0].Rows[0]["RepeatColumns"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Width"] != null && ds.Tables[0].Rows[0]["Width"].ToString() != "")
                {
                    model.Width = int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Height"] != null && ds.Tables[0].Rows[0]["Height"].ToString() != "")
                {
                    model.Height = int.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdvHtml"] != null && ds.Tables[0].Rows[0]["AdvHtml"].ToString() != "")
                {
                    model.AdvHtml = ds.Tables[0].Rows[0]["AdvHtml"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsOne"] != null && ds.Tables[0].Rows[0]["IsOne"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsOne"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOne"].ToString().ToLower() == "true"))
                    {
                        model.IsOne = true;
                    }
                    else
                    {
                        model.IsOne = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["TimeInterval"] != null && ds.Tables[0].Rows[0]["TimeInterval"].ToString() != "")
                {
                    model.TimeInterval = int.Parse(ds.Tables[0].Rows[0]["TimeInterval"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
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
            strSql.Append("SELECT AdvPositionId,AdvPositionName,ShowType,RepeatColumns,Width,Height,AdvHtml,IsOne,TimeInterval,CreatedDate,CreatedUserID ");
            strSql.Append(" FROM AD_AdvertisePosition ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(" AdvPositionId,AdvPositionName,ShowType,RepeatColumns,Width,Height,AdvHtml,IsOne,TimeInterval,CreatedDate,CreatedUserID ");
            strSql.Append(" FROM AD_AdvertisePosition ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
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
            strSql.Append("SELECT COUNT(1) FROM AD_AdvertisePosition ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
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
            strSql.Append("SELECT  T.*  FROM AD_AdvertisePosition T  ");
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
                strSql.Append(" order by T.AdvPositionId desc");
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
            parameters[0].Value = "AD_AdvertisePosition";
            parameters[1].Value = "AdvPositionId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method
    }
}