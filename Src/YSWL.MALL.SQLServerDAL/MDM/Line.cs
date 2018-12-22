/**  版本信息模板在安装目录下，可自行修改。
* Line.cs
*
* 功 能： N/A
* 类 名： Line
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/28 16:38:29   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.MDM;
using YSWL.DBUtility;//Please add references
namespace YSWL.MALL.SQLServerDAL.MDM
{
    /// <summary>
    /// 数据访问类:Line
    /// </summary>
    public partial class Line : ILine
    {
        public Line()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DBHelper.DefaultDBHelper.GetMaxID("LineId", "TMS_Line");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LineId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TMS_Line");
            strSql.Append(" where LineId=@LineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LineId", SqlDbType.Int,4)
            };
            parameters[0].Value = LineId;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.MDM.Line model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TMS_Line(");
            strSql.Append("LineName,TransporterId,LineType,StartRegionId,StartContact,StartPhone,StartAddress,EndRegionId,EndContact,EndPhone,EndAddress,MinHour,MaxHour,StartHour,StartDate,EndDate,MinCost,MinPickFee,MinSendFee,OrderFee,StorageFee,FreeDays,Status,CreateUserId,CreateUserName,CreatedDate,UpdateUserId,UpdateUserName,UpdateDate,Remark,DriverId)");
            strSql.Append(" values (");
            strSql.Append("@LineName,@TransporterId,@LineType,@StartRegionId,@StartContact,@StartPhone,@StartAddress,@EndRegionId,@EndContact,@EndPhone,@EndAddress,@MinHour,@MaxHour,@StartHour,@StartDate,@EndDate,@MinCost,@MinPickFee,@MinSendFee,@OrderFee,@StorageFee,@FreeDays,@Status,@CreateUserId,@CreateUserName,@CreatedDate,@UpdateUserId,@UpdateUserName,@UpdateDate,@Remark,@DriverId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@LineName", SqlDbType.NVarChar,50),
                    new SqlParameter("@TransporterId", SqlDbType.Int,4),
                    new SqlParameter("@LineType", SqlDbType.Int,4),
                    new SqlParameter("@StartRegionId", SqlDbType.Int,4),
                    new SqlParameter("@StartContact", SqlDbType.NVarChar,50),
                    new SqlParameter("@StartPhone", SqlDbType.NVarChar,50),
                    new SqlParameter("@StartAddress", SqlDbType.NVarChar,200),
                    new SqlParameter("@EndRegionId", SqlDbType.Int,4),
                    new SqlParameter("@EndContact", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndPhone", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndAddress", SqlDbType.NVarChar,200),
                    new SqlParameter("@MinHour", SqlDbType.Int,4),
                    new SqlParameter("@MaxHour", SqlDbType.Int,4),
                    new SqlParameter("@StartHour", SqlDbType.NVarChar,200),
                    new SqlParameter("@StartDate", SqlDbType.Date,3),
                    new SqlParameter("@EndDate", SqlDbType.Date,3),
                    new SqlParameter("@MinCost", SqlDbType.Money,8),
                    new SqlParameter("@MinPickFee", SqlDbType.Money,8),
                    new SqlParameter("@MinSendFee", SqlDbType.Money,8),
                    new SqlParameter("@OrderFee", SqlDbType.Money,8),
                    new SqlParameter("@StorageFee", SqlDbType.Money,8),
                    new SqlParameter("@FreeDays", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@CreateUserId", SqlDbType.Int,4),
                    new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreatedDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUserId", SqlDbType.Int,4),
                    new SqlParameter("@UpdateUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
                    new SqlParameter("@DriverId", SqlDbType.Int,4)};
            parameters[0].Value = model.LineName;
            parameters[1].Value = model.TransporterId;
            parameters[2].Value = model.LineType;
            parameters[3].Value = model.StartRegionId;
            parameters[4].Value = model.StartContact;
            parameters[5].Value = model.StartPhone;
            parameters[6].Value = model.StartAddress;
            parameters[7].Value = model.EndRegionId;
            parameters[8].Value = model.EndContact;
            parameters[9].Value = model.EndPhone;
            parameters[10].Value = model.EndAddress;
            parameters[11].Value = model.MinHour;
            parameters[12].Value = model.MaxHour;
            parameters[13].Value = model.StartHour;
            parameters[14].Value = model.StartDate;
            parameters[15].Value = model.EndDate;
            parameters[16].Value = model.MinCost;
            parameters[17].Value = model.MinPickFee;
            parameters[18].Value = model.MinSendFee;
            parameters[19].Value = model.OrderFee;
            parameters[20].Value = model.StorageFee;
            parameters[21].Value = model.FreeDays;
            parameters[22].Value = model.Status;
            parameters[23].Value = model.CreateUserId;
            parameters[24].Value = model.CreateUserName;
            parameters[25].Value = model.CreatedDate;
            parameters[26].Value = model.UpdateUserId;
            parameters[27].Value = model.UpdateUserName;
            parameters[28].Value = model.UpdateDate;
            parameters[29].Value = model.Remark;
            parameters[30].Value = model.DriverId;

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
        public bool Update(YSWL.MALL.Model.MDM.Line model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TMS_Line set ");
            strSql.Append("LineName=@LineName,");
            strSql.Append("TransporterId=@TransporterId,");
            strSql.Append("LineType=@LineType,");
            strSql.Append("StartRegionId=@StartRegionId,");
            strSql.Append("StartContact=@StartContact,");
            strSql.Append("StartPhone=@StartPhone,");
            strSql.Append("StartAddress=@StartAddress,");
            strSql.Append("EndRegionId=@EndRegionId,");
            strSql.Append("EndContact=@EndContact,");
            strSql.Append("EndPhone=@EndPhone,");
            strSql.Append("EndAddress=@EndAddress,");
            strSql.Append("MinHour=@MinHour,");
            strSql.Append("MaxHour=@MaxHour,");
            strSql.Append("StartHour=@StartHour,");
            strSql.Append("StartDate=@StartDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("MinCost=@MinCost,");
            strSql.Append("MinPickFee=@MinPickFee,");
            strSql.Append("MinSendFee=@MinSendFee,");
            strSql.Append("OrderFee=@OrderFee,");
            strSql.Append("StorageFee=@StorageFee,");
            strSql.Append("FreeDays=@FreeDays,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateUserId=@CreateUserId,");
            strSql.Append("CreateUserName=@CreateUserName,");
            strSql.Append("CreatedDate=@CreatedDate,");
            strSql.Append("UpdateUserId=@UpdateUserId,");
            strSql.Append("UpdateUserName=@UpdateUserName,");
            strSql.Append("UpdateDate=@UpdateDate,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("DriverId=@DriverId");
            strSql.Append(" where LineId=@LineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LineName", SqlDbType.NVarChar,50),
                    new SqlParameter("@TransporterId", SqlDbType.Int,4),
                    new SqlParameter("@LineType", SqlDbType.Int,4),
                    new SqlParameter("@StartRegionId", SqlDbType.Int,4),
                    new SqlParameter("@StartContact", SqlDbType.NVarChar,50),
                    new SqlParameter("@StartPhone", SqlDbType.NVarChar,50),
                    new SqlParameter("@StartAddress", SqlDbType.NVarChar,200),
                    new SqlParameter("@EndRegionId", SqlDbType.Int,4),
                    new SqlParameter("@EndContact", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndPhone", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndAddress", SqlDbType.NVarChar,200),
                    new SqlParameter("@MinHour", SqlDbType.Int,4),
                    new SqlParameter("@MaxHour", SqlDbType.Int,4),
                    new SqlParameter("@StartHour", SqlDbType.NVarChar,200),
                    new SqlParameter("@StartDate", SqlDbType.Date,3),
                    new SqlParameter("@EndDate", SqlDbType.Date,3),
                    new SqlParameter("@MinCost", SqlDbType.Money,8),
                    new SqlParameter("@MinPickFee", SqlDbType.Money,8),
                    new SqlParameter("@MinSendFee", SqlDbType.Money,8),
                    new SqlParameter("@OrderFee", SqlDbType.Money,8),
                    new SqlParameter("@StorageFee", SqlDbType.Money,8),
                    new SqlParameter("@FreeDays", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@CreateUserId", SqlDbType.Int,4),
                    new SqlParameter("@CreateUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreatedDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUserId", SqlDbType.Int,4),
                    new SqlParameter("@UpdateUserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
                    new SqlParameter("@DriverId", SqlDbType.Int,4),
                    new SqlParameter("@LineId", SqlDbType.Int,4)};
            parameters[0].Value = model.LineName;
            parameters[1].Value = model.TransporterId;
            parameters[2].Value = model.LineType;
            parameters[3].Value = model.StartRegionId;
            parameters[4].Value = model.StartContact;
            parameters[5].Value = model.StartPhone;
            parameters[6].Value = model.StartAddress;
            parameters[7].Value = model.EndRegionId;
            parameters[8].Value = model.EndContact;
            parameters[9].Value = model.EndPhone;
            parameters[10].Value = model.EndAddress;
            parameters[11].Value = model.MinHour;
            parameters[12].Value = model.MaxHour;
            parameters[13].Value = model.StartHour;
            parameters[14].Value = model.StartDate;
            parameters[15].Value = model.EndDate;
            parameters[16].Value = model.MinCost;
            parameters[17].Value = model.MinPickFee;
            parameters[18].Value = model.MinSendFee;
            parameters[19].Value = model.OrderFee;
            parameters[20].Value = model.StorageFee;
            parameters[21].Value = model.FreeDays;
            parameters[22].Value = model.Status;
            parameters[23].Value = model.CreateUserId;
            parameters[24].Value = model.CreateUserName;
            parameters[25].Value = model.CreatedDate;
            parameters[26].Value = model.UpdateUserId;
            parameters[27].Value = model.UpdateUserName;
            parameters[28].Value = model.UpdateDate;
            parameters[29].Value = model.Remark;
            parameters[30].Value = model.DriverId;
            parameters[31].Value = model.LineId;

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
        public bool Delete(int LineId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMS_Line ");
            strSql.Append(" where LineId=@LineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LineId", SqlDbType.Int,4)
            };
            parameters[0].Value = LineId;

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
        public bool DeleteList(string LineIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TMS_Line ");
            strSql.Append(" where LineId in (" + LineIdlist + ")  ");
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
        public YSWL.MALL.Model.MDM.Line GetModel(int LineId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LineId,LineName,TransporterId,LineType,StartRegionId,StartContact,StartPhone,StartAddress,EndRegionId,EndContact,EndPhone,EndAddress,MinHour,MaxHour,StartHour,StartDate,EndDate,MinCost,MinPickFee,MinSendFee,OrderFee,StorageFee,FreeDays,Status,CreateUserId,CreateUserName,CreatedDate,UpdateUserId,UpdateUserName,UpdateDate,Remark,DriverId from TMS_Line ");
            strSql.Append(" where LineId=@LineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LineId", SqlDbType.Int,4)
            };
            parameters[0].Value = LineId;

            YSWL.MALL.Model.MDM.Line model = new YSWL.MALL.Model.MDM.Line();
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
        public YSWL.MALL.Model.MDM.Line DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.MDM.Line model = new YSWL.MALL.Model.MDM.Line();
            if (row != null)
            {
                if (row["LineId"] != null && row["LineId"].ToString() != "")
                {
                    model.LineId = int.Parse(row["LineId"].ToString());
                }
                if (row["LineName"] != null)
                {
                    model.LineName = row["LineName"].ToString();
                }
                if (row["TransporterId"] != null && row["TransporterId"].ToString() != "")
                {
                    model.TransporterId = int.Parse(row["TransporterId"].ToString());
                }
                if (row["LineType"] != null && row["LineType"].ToString() != "")
                {
                    model.LineType = int.Parse(row["LineType"].ToString());
                }
                if (row["StartRegionId"] != null && row["StartRegionId"].ToString() != "")
                {
                    model.StartRegionId = int.Parse(row["StartRegionId"].ToString());
                }
                if (row["StartContact"] != null)
                {
                    model.StartContact = row["StartContact"].ToString();
                }
                if (row["StartPhone"] != null)
                {
                    model.StartPhone = row["StartPhone"].ToString();
                }
                if (row["StartAddress"] != null)
                {
                    model.StartAddress = row["StartAddress"].ToString();
                }
                if (row["EndRegionId"] != null && row["EndRegionId"].ToString() != "")
                {
                    model.EndRegionId = int.Parse(row["EndRegionId"].ToString());
                }
                if (row["EndContact"] != null)
                {
                    model.EndContact = row["EndContact"].ToString();
                }
                if (row["EndPhone"] != null)
                {
                    model.EndPhone = row["EndPhone"].ToString();
                }
                if (row["EndAddress"] != null)
                {
                    model.EndAddress = row["EndAddress"].ToString();
                }
                if (row["MinHour"] != null && row["MinHour"].ToString() != "")
                {
                    model.MinHour = int.Parse(row["MinHour"].ToString());
                }
                if (row["MaxHour"] != null && row["MaxHour"].ToString() != "")
                {
                    model.MaxHour = int.Parse(row["MaxHour"].ToString());
                }
                if (row["StartHour"] != null)
                {
                    model.StartHour = row["StartHour"].ToString();
                }
                if (row["StartDate"] != null && row["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(row["StartDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["MinCost"] != null && row["MinCost"].ToString() != "")
                {
                    model.MinCost = decimal.Parse(row["MinCost"].ToString());
                }
                if (row["MinPickFee"] != null && row["MinPickFee"].ToString() != "")
                {
                    model.MinPickFee = decimal.Parse(row["MinPickFee"].ToString());
                }
                if (row["MinSendFee"] != null && row["MinSendFee"].ToString() != "")
                {
                    model.MinSendFee = decimal.Parse(row["MinSendFee"].ToString());
                }
                if (row["OrderFee"] != null && row["OrderFee"].ToString() != "")
                {
                    model.OrderFee = decimal.Parse(row["OrderFee"].ToString());
                }
                if (row["StorageFee"] != null && row["StorageFee"].ToString() != "")
                {
                    model.StorageFee = decimal.Parse(row["StorageFee"].ToString());
                }
                if (row["FreeDays"] != null && row["FreeDays"].ToString() != "")
                {
                    model.FreeDays = int.Parse(row["FreeDays"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreateUserId"] != null && row["CreateUserId"].ToString() != "")
                {
                    model.CreateUserId = int.Parse(row["CreateUserId"].ToString());
                }
                if (row["CreateUserName"] != null)
                {
                    model.CreateUserName = row["CreateUserName"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["UpdateUserId"] != null && row["UpdateUserId"].ToString() != "")
                {
                    model.UpdateUserId = int.Parse(row["UpdateUserId"].ToString());
                }
                if (row["UpdateUserName"] != null)
                {
                    model.UpdateUserName = row["UpdateUserName"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["DriverId"] != null && row["DriverId"].ToString() != "")
                {
                    model.DriverId = int.Parse(row["DriverId"].ToString());
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
            strSql.Append("select LineId,LineName,TransporterId,LineType,StartRegionId,StartContact,StartPhone,StartAddress,EndRegionId,EndContact,EndPhone,EndAddress,MinHour,MaxHour,StartHour,StartDate,EndDate,MinCost,MinPickFee,MinSendFee,OrderFee,StorageFee,FreeDays,Status,CreateUserId,CreateUserName,CreatedDate,UpdateUserId,UpdateUserName,UpdateDate,Remark,DriverId ");
            strSql.Append(" FROM TMS_Line ");
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
            strSql.Append(" LineId,LineName,TransporterId,LineType,StartRegionId,StartContact,StartPhone,StartAddress,EndRegionId,EndContact,EndPhone,EndAddress,MinHour,MaxHour,StartHour,StartDate,EndDate,MinCost,MinPickFee,MinSendFee,OrderFee,StorageFee,FreeDays,Status,CreateUserId,CreateUserName,CreatedDate,UpdateUserId,UpdateUserName,UpdateDate,Remark,DriverId ");
            strSql.Append(" FROM TMS_Line ");
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
            strSql.Append("select count(1) FROM TMS_Line ");
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
                strSql.Append("order by T.LineId desc");
            }
            strSql.Append(")AS Row, T.*  from TMS_Line T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "TMS_Line";
			parameters[1].Value = "LineId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.DefaultDBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获取线路名称
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
	    public  string GetLineName(int lineId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  LineName from TMS_Line ");
            strSql.Append(" where LineId=@LineId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LineId", SqlDbType.Int,4)
            };
            parameters[0].Value = lineId;
            YSWL.MALL.Model.MDM.Line model = new YSWL.MALL.Model.MDM.Line();
            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameters);
            return Common.Globals.SafeString(obj, "");
        }

        #endregion  ExtensionMethod
    }
}

