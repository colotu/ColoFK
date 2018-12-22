/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：Advertisement.cs
// 文件功能描述：
//
// 创建标识： [Ben]  2012/05/31 14:04:16
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.Common;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Settings;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Settings
{
    /// <summary>
    /// 数据访问类:Advertisement
    /// </summary>
    public partial class Advertisement : IAdvertisement
    {
        public Advertisement()
        { }

        #region Method

        /// <summary>
        /// 得到最大顺序
        /// </summary>
        public int GetMaxSequence()
        {
            return DbHelperMySQL.GetMaxID("Sequence", "AD_Advertisement");
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Settings.Advertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT intO AD_Advertisement(");
            strSql.Append("AdvertisementName,AdvPositionId,ContentType,FileUrl,AlternateText,NavigateUrl,AdvHtml,Impressions,CreatedDate,CreatedUserID,State,StartDate,EndDate,DayMaxPV,DayMaxIP,CPMPrice,AutoStop,Sequence,EnterpriseID)");
            strSql.Append(" VALUES (");
            strSql.Append("?AdvertisementName,?AdvPositionId,?ContentType,?FileUrl,?AlternateText,?NavigateUrl,?AdvHtml,?Impressions,?CreatedDate,?CreatedUserID,?State,?StartDate,?EndDate,?DayMaxPV,?DayMaxIP,?CPMPrice,?AutoStop,?Sequence,?EnterpriseID)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvertisementName", MySqlDbType.VarString,50),
					new MySqlParameter("?AdvPositionId",  MySqlDbType.Int32,4),
					new MySqlParameter("?ContentType",  MySqlDbType.Int32,4),
					new MySqlParameter("?FileUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?AlternateText", MySqlDbType.VarString,200),
					new MySqlParameter("?NavigateUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?AdvHtml", MySqlDbType.VarString),
					new MySqlParameter("?Impressions",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?State",  MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?DayMaxPV",  MySqlDbType.Int32,4),
					new MySqlParameter("?DayMaxIP",  MySqlDbType.Int32,4),
					new MySqlParameter("?CPMPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?AutoStop",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?EnterpriseID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.AdvertisementName;
            parameters[1].Value = model.AdvPositionId;
            parameters[2].Value = model.ContentType;
            parameters[3].Value = model.FileUrl;
            parameters[4].Value = model.AlternateText;
            parameters[5].Value = model.NavigateUrl;
            parameters[6].Value = model.AdvHtml;
            parameters[7].Value = model.Impressions;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.CreatedUserID;
            parameters[10].Value = model.State;
            parameters[11].Value = model.StartDate;
            parameters[12].Value = model.EndDate;
            parameters[13].Value = model.DayMaxPV;
            parameters[14].Value = model.DayMaxIP;
            parameters[15].Value = model.CPMPrice;
            parameters[16].Value = model.AutoStop;
            parameters[17].Value = model.Sequence;
            parameters[18].Value = model.EnterpriseID;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Settings.Advertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AD_Advertisement SET ");
            strSql.Append("AdvertisementName=?AdvertisementName,");
            strSql.Append("AdvPositionId=?AdvPositionId,");
            strSql.Append("ContentType=?ContentType,");
            strSql.Append("FileUrl=?FileUrl,");
            strSql.Append("AlternateText=?AlternateText,");
            strSql.Append("NavigateUrl=?NavigateUrl,");
            strSql.Append("AdvHtml=?AdvHtml,");
            strSql.Append("Impressions=?Impressions,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("State=?State,");
            strSql.Append("StartDate=?StartDate,");
            strSql.Append("EndDate=?EndDate,");
            strSql.Append("DayMaxPV=?DayMaxPV,");
            strSql.Append("DayMaxIP=?DayMaxIP,");
            strSql.Append("CPMPrice=?CPMPrice,");
            strSql.Append("AutoStop=?AutoStop,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("EnterpriseID=?EnterpriseID");
            strSql.Append(" WHERE AdvertisementId=?AdvertisementId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvertisementName", MySqlDbType.VarString,50),
					new MySqlParameter("?AdvPositionId",  MySqlDbType.Int32,4),
					new MySqlParameter("?ContentType",  MySqlDbType.Int32,4),
					new MySqlParameter("?FileUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?AlternateText", MySqlDbType.VarString,200),
					new MySqlParameter("?NavigateUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?AdvHtml", MySqlDbType.VarString),
					new MySqlParameter("?Impressions",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?State",  MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?DayMaxPV",  MySqlDbType.Int32,4),
					new MySqlParameter("?DayMaxIP",  MySqlDbType.Int32,4),
					new MySqlParameter("?CPMPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?AutoStop",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?EnterpriseID",  MySqlDbType.Int32,4),
					new MySqlParameter("?AdvertisementId",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.AdvertisementName;
            parameters[1].Value = model.AdvPositionId;
            parameters[2].Value = model.ContentType;
            parameters[3].Value = model.FileUrl;
            parameters[4].Value = model.AlternateText;
            parameters[5].Value = model.NavigateUrl;
            parameters[6].Value = model.AdvHtml;
            parameters[7].Value = model.Impressions;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.CreatedUserID;
            parameters[10].Value = model.State;
            parameters[11].Value = model.StartDate;
            parameters[12].Value = model.EndDate;
            parameters[13].Value = model.DayMaxPV;
            parameters[14].Value = model.DayMaxIP;
            parameters[15].Value = model.CPMPrice;
            parameters[16].Value = model.AutoStop;
            parameters[17].Value = model.Sequence;
            parameters[18].Value = model.EnterpriseID;
            parameters[19].Value = model.AdvertisementId;

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
        public bool Delete(int AdvertisementId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM AD_Advertisement ");
            strSql.Append(" WHERE AdvertisementId=?AdvertisementId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvertisementId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AdvertisementId;

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
        public bool DeleteList(string AdvertisementIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM AD_Advertisement ");
            strSql.Append(" WHERE AdvertisementId in (" + AdvertisementIdlist + ")  ");
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
        public YSWL.MALL.Model.Settings.Advertisement GetModel(int AdvertisementId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT   * FROM AD_Advertisement ");
            strSql.Append(" WHERE AdvertisementId=?AdvertisementId LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvertisementId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AdvertisementId;

            YSWL.MALL.Model.Settings.Advertisement model = new YSWL.MALL.Model.Settings.Advertisement();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AdvertisementId"] != null && ds.Tables[0].Rows[0]["AdvertisementId"].ToString() != "")
                {
                    model.AdvertisementId = int.Parse(ds.Tables[0].Rows[0]["AdvertisementId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdvertisementName"] != null && ds.Tables[0].Rows[0]["AdvertisementName"].ToString() != "")
                {
                    model.AdvertisementName = ds.Tables[0].Rows[0]["AdvertisementName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AdvPositionId"] != null && ds.Tables[0].Rows[0]["AdvPositionId"].ToString() != "")
                {
                    model.AdvPositionId = int.Parse(ds.Tables[0].Rows[0]["AdvPositionId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContentType"] != null && ds.Tables[0].Rows[0]["ContentType"].ToString() != "")
                {
                    model.ContentType = int.Parse(ds.Tables[0].Rows[0]["ContentType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileUrl"] != null && ds.Tables[0].Rows[0]["FileUrl"].ToString() != "")
                {
                    model.FileUrl = ds.Tables[0].Rows[0]["FileUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AlternateText"] != null && ds.Tables[0].Rows[0]["AlternateText"].ToString() != "")
                {
                    model.AlternateText = ds.Tables[0].Rows[0]["AlternateText"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NavigateUrl"] != null && ds.Tables[0].Rows[0]["NavigateUrl"].ToString() != "")
                {
                    model.NavigateUrl = ds.Tables[0].Rows[0]["NavigateUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AdvHtml"] != null && ds.Tables[0].Rows[0]["AdvHtml"].ToString() != "")
                {
                    model.AdvHtml = ds.Tables[0].Rows[0]["AdvHtml"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Impressions"] != null && ds.Tables[0].Rows[0]["Impressions"].ToString() != "")
                {
                    model.Impressions = int.Parse(ds.Tables[0].Rows[0]["Impressions"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartDate"] != null && ds.Tables[0].Rows[0]["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndDate"] != null && ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DayMaxPV"] != null && ds.Tables[0].Rows[0]["DayMaxPV"].ToString() != "")
                {
                    model.DayMaxPV = int.Parse(ds.Tables[0].Rows[0]["DayMaxPV"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DayMaxIP"] != null && ds.Tables[0].Rows[0]["DayMaxIP"].ToString() != "")
                {
                    model.DayMaxIP = int.Parse(ds.Tables[0].Rows[0]["DayMaxIP"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPMPrice"] != null && ds.Tables[0].Rows[0]["CPMPrice"].ToString() != "")
                {
                    model.CPMPrice = decimal.Parse(ds.Tables[0].Rows[0]["CPMPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AutoStop"] != null && ds.Tables[0].Rows[0]["AutoStop"].ToString() != "")
                {
                    model.AutoStop = int.Parse(ds.Tables[0].Rows[0]["AutoStop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EnterpriseID"] != null && ds.Tables[0].Rows[0]["EnterpriseID"].ToString() != "")
                {
                    model.EnterpriseID = int.Parse(ds.Tables[0].Rows[0]["EnterpriseID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Settings.Advertisement GetModelByAdvPositionId(int AdvPositionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT    * FROM AD_Advertisement ");
            strSql.Append(" WHERE AdvPositionId=?AdvPositionId LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AdvPositionId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = AdvPositionId;

            YSWL.MALL.Model.Settings.Advertisement model = new YSWL.MALL.Model.Settings.Advertisement();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AdvertisementId"] != null && ds.Tables[0].Rows[0]["AdvertisementId"].ToString() != "")
                {
                    model.AdvertisementId = int.Parse(ds.Tables[0].Rows[0]["AdvertisementId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdvertisementName"] != null && ds.Tables[0].Rows[0]["AdvertisementName"].ToString() != "")
                {
                    model.AdvertisementName = ds.Tables[0].Rows[0]["AdvertisementName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AdvPositionId"] != null && ds.Tables[0].Rows[0]["AdvPositionId"].ToString() != "")
                {
                    model.AdvPositionId = int.Parse(ds.Tables[0].Rows[0]["AdvPositionId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContentType"] != null && ds.Tables[0].Rows[0]["ContentType"].ToString() != "")
                {
                    model.ContentType = int.Parse(ds.Tables[0].Rows[0]["ContentType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileUrl"] != null && ds.Tables[0].Rows[0]["FileUrl"].ToString() != "")
                {
                    model.FileUrl = ds.Tables[0].Rows[0]["FileUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AlternateText"] != null && ds.Tables[0].Rows[0]["AlternateText"].ToString() != "")
                {
                    model.AlternateText = ds.Tables[0].Rows[0]["AlternateText"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NavigateUrl"] != null && ds.Tables[0].Rows[0]["NavigateUrl"].ToString() != "")
                {
                    model.NavigateUrl = ds.Tables[0].Rows[0]["NavigateUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AdvHtml"] != null && ds.Tables[0].Rows[0]["AdvHtml"].ToString() != "")
                {
                    model.AdvHtml = ds.Tables[0].Rows[0]["AdvHtml"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Impressions"] != null && ds.Tables[0].Rows[0]["Impressions"].ToString() != "")
                {
                    model.Impressions = int.Parse(ds.Tables[0].Rows[0]["Impressions"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StartDate"] != null && ds.Tables[0].Rows[0]["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndDate"] != null && ds.Tables[0].Rows[0]["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DayMaxPV"] != null && ds.Tables[0].Rows[0]["DayMaxPV"].ToString() != "")
                {
                    model.DayMaxPV = int.Parse(ds.Tables[0].Rows[0]["DayMaxPV"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DayMaxIP"] != null && ds.Tables[0].Rows[0]["DayMaxIP"].ToString() != "")
                {
                    model.DayMaxIP = int.Parse(ds.Tables[0].Rows[0]["DayMaxIP"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPMPrice"] != null && ds.Tables[0].Rows[0]["CPMPrice"].ToString() != "")
                {
                    model.CPMPrice = decimal.Parse(ds.Tables[0].Rows[0]["CPMPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AutoStop"] != null && ds.Tables[0].Rows[0]["AutoStop"].ToString() != "")
                {
                    model.AutoStop = int.Parse(ds.Tables[0].Rows[0]["AutoStop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EnterpriseID"] != null && ds.Tables[0].Rows[0]["EnterpriseID"].ToString() != "")
                {
                    model.EnterpriseID = int.Parse(ds.Tables[0].Rows[0]["EnterpriseID"].ToString());
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
            strSql.Append("SELECT * ");
            strSql.Append(" FROM AD_Advertisement ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int? Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append(" AdvertisementId,AdvertisementName,AdvPositionId,ContentType,FileUrl,AlternateText,NavigateUrl,AdvHtml,Impressions,CreatedDate,CreatedUserID,State,StartDate,EndDate,DayMaxPV,DayMaxIP,CPMPrice,AutoStop,Sequence,EnterpriseID ");
            strSql.Append(" FROM AD_Advertisement ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(filedOrder.Trim()))
            {
                strSql.Append(" ORDER BY " + filedOrder);
            }
            if (Top.HasValue && Top.Value > 0)
            {
                strSql.Append(" LIMIT  " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Settings.Advertisement> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Settings.Advertisement> modelList = new List<YSWL.MALL.Model.Settings.Advertisement>();
            if (DataTableTools.DataTableIsNull(dt))
            {
                return null;
            }
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Settings.Advertisement model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new YSWL.MALL.Model.Settings.Advertisement();
                    model.Row = n + 1;
                    if (dt.Rows[n]["AdvertisementId"] != null && dt.Rows[n]["AdvertisementId"].ToString() != "")
                    {
                        model.AdvertisementId = int.Parse(dt.Rows[n]["AdvertisementId"].ToString());
                    }
                    if (dt.Rows[n]["AdvertisementName"] != null && dt.Rows[n]["AdvertisementName"].ToString() != "")
                    {
                        model.AdvertisementName = dt.Rows[n]["AdvertisementName"].ToString();
                    }
                    if (dt.Rows[n]["AdvPositionId"] != null && dt.Rows[n]["AdvPositionId"].ToString() != "")
                    {
                        model.AdvPositionId = int.Parse(dt.Rows[n]["AdvPositionId"].ToString());
                    }
                    if (dt.Rows[n]["ContentType"] != null && dt.Rows[n]["ContentType"].ToString() != "")
                    {
                        model.ContentType = int.Parse(dt.Rows[n]["ContentType"].ToString());
                    }
                    if (dt.Rows[n]["FileUrl"] != null && dt.Rows[n]["FileUrl"].ToString() != "")
                    {
                        model.FileUrl = dt.Rows[n]["FileUrl"].ToString();
                    }
                    if (dt.Rows[n]["AlternateText"] != null && dt.Rows[n]["AlternateText"].ToString() != "")
                    {
                        model.AlternateText = dt.Rows[n]["AlternateText"].ToString();
                    }
                    if (dt.Rows[n]["NavigateUrl"] != null && dt.Rows[n]["NavigateUrl"].ToString() != "")
                    {
                        model.NavigateUrl = dt.Rows[n]["NavigateUrl"].ToString();
                    }
                    if (dt.Rows[n]["AdvHtml"] != null && dt.Rows[n]["AdvHtml"].ToString() != "")
                    {
                        model.AdvHtml = dt.Rows[n]["AdvHtml"].ToString();
                    }
                    if (dt.Rows[n]["Impressions"] != null && dt.Rows[n]["Impressions"].ToString() != "")
                    {
                        model.Impressions = int.Parse(dt.Rows[n]["Impressions"].ToString());
                    }
                    if (dt.Rows[n]["CreatedDate"] != null && dt.Rows[n]["CreatedDate"].ToString() != "")
                    {
                        model.CreatedDate = DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
                    }
                    if (dt.Rows[n]["CreatedUserID"] != null && dt.Rows[n]["CreatedUserID"].ToString() != "")
                    {
                        model.CreatedUserID = int.Parse(dt.Rows[n]["CreatedUserID"].ToString());
                    }
                    if (dt.Rows[n]["State"] != null && dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["StartDate"] != null && dt.Rows[n]["StartDate"].ToString() != "")
                    {
                        model.StartDate = DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
                    }
                    if (dt.Rows[n]["EndDate"] != null && dt.Rows[n]["EndDate"].ToString() != "")
                    {
                        model.EndDate = DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
                    }
                    if (dt.Rows[n]["DayMaxPV"] != null && dt.Rows[n]["DayMaxPV"].ToString() != "")
                    {
                        model.DayMaxPV = int.Parse(dt.Rows[n]["DayMaxPV"].ToString());
                    }
                    if (dt.Rows[n]["DayMaxIP"] != null && dt.Rows[n]["DayMaxIP"].ToString() != "")
                    {
                        model.DayMaxIP = int.Parse(dt.Rows[n]["DayMaxIP"].ToString());
                    }
                    if (dt.Rows[n]["CPMPrice"] != null && dt.Rows[n]["CPMPrice"].ToString() != "")
                    {
                        model.CPMPrice = decimal.Parse(dt.Rows[n]["CPMPrice"].ToString());
                    }
                    if (dt.Rows[n]["AutoStop"] != null && dt.Rows[n]["AutoStop"].ToString() != "")
                    {
                        model.AutoStop = int.Parse(dt.Rows[n]["AutoStop"].ToString());
                    }
                    if (dt.Rows[n]["Sequence"] != null && dt.Rows[n]["Sequence"].ToString() != "")
                    {
                        model.Sequence = int.Parse(dt.Rows[n]["Sequence"].ToString());
                    }
                    if (dt.Rows[n]["EnterpriseID"] != null && dt.Rows[n]["EnterpriseID"].ToString() != "")
                    {
                        model.EnterpriseID = int.Parse(dt.Rows[n]["EnterpriseID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM AD_Advertisement ");
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
            strSql.Append("SELECT  T.*  FROM AD_Advertisement T  ");
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
                strSql.Append(" order by T.AdvertisementId desc");
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
            parameters[0].Value = "AD_Advertisement";
            parameters[1].Value = "AdvertisementId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        public DataSet GetTransitionImg(int Aid, int ContentType, int? Num)
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT  ");
            //if (Num.HasValue)
            //{
            //    strSql.Append(" TOP " + Num.Value);
            //}
            //strSql.Append(" * FROM (    ");
            //strSql.Append("SELECT  A.* FROM Ms_Enterprise C ");
            //strSql.Append("LEFT  JOIN AD_Advertisement A ON C.EnterpriseID=A.EnterpriseID)B  ");
            //strSql.Append("LEFT JOIN AD_AdvertisePosition D ON B.AdvPositionId=D.AdvPositionId ");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ");
            strSql.Append(" * FROM AD_Advertisement ADV ");
            strSql.Append("LEFT JOIN AD_AdvertisePosition ADP ON ADV.AdvPositionId = ADP.AdvPositionId ");
            strSql.AppendFormat("WHERE   ADP.AdvPositionId ={0} AND ContentType={1} AND State=1 ", Aid, ContentType);

            if (Num.HasValue)
            {
                strSql.Append(" LIMIT " + Num.Value);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet SelectInfoByContentType(int ContentType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT   *");
            strSql.Append("FROM AD_Advertisement  ");
            strSql.AppendFormat("WHERE ContentType={0} AND State=1 LIMIT 1 ", ContentType);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public int IsExist(int AdvPositionId, int contentType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) ");
            strSql.Append("FROM AD_Advertisement  ");
            strSql.AppendFormat("WHERE AdvPositionId={0} AND State=1  AND ContentType={1}", AdvPositionId, contentType);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj != null) return Convert.ToInt32(obj);
            return 0;
        }

        public DataSet GetContentType(int AdvPositionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT ContentType ");
            strSql.Append("FROM AD_Advertisement ");
            strSql.AppendFormat("WHERE  AdvPositionId= {0}", AdvPositionId);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetDefindCode(int AdvPositionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM AD_AdvertisePosition");
            strSql.AppendFormat(" WHERE  AdvPositionId = {0}", AdvPositionId);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public bool UpdateSeq(int seq, int advId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE AD_Advertisement SET ");
            strSql.Append("Sequence=?Sequence");
            strSql.Append(" WHERE AdvertisementId=?AdvertisementId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?AdvertisementId", MySqlDbType.Int32,4)};
            parameters[0].Value = seq;
            parameters[1].Value = advId;

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
    }
}