/**
* CouponHistory.cs
*
* 功 能： N/A
* 类 名： CouponHistory
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/26 17:20:57   N/A    初版
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
using YSWL.MALL.IDAL.Shop.Coupon;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Coupon
{
	/// <summary>
	/// 数据访问类:CouponHistory
	/// </summary>
	public partial class CouponHistory:ICouponHistory
	{
		public CouponHistory()
		{}
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CouponCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_CouponHistory");
            strSql.Append(" where CouponCode=?CouponCode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,200)			};
            parameters[0].Value = CouponCode;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Shop.Coupon.CouponHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_CouponHistory(");
            strSql.Append("CouponCode,CategoryId,ClassId,SupplierId,RuleId,CouponName,CouponPwd,UserId,UserEmail,Status,CouponPrice,LimitPrice,NeedPoint,IsPwd,IsReuse,StartDate,EndDate,GenerateTime,UsedDate)");
            strSql.Append(" values (");
            strSql.Append("?CouponCode,?CategoryId,?ClassId,?SupplierId,?RuleId,?CouponName,?CouponPwd,?UserId,?UserEmail,?Status,?CouponPrice,?LimitPrice,?NeedPoint,?IsPwd,?IsReuse,?StartDate,?EndDate,?GenerateTime,?UsedDate)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,200),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CouponPwd", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CouponPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LimitPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?NeedPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?IsPwd", MySqlDbType.Int32,4),
					new MySqlParameter("?IsReuse", MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?GenerateTime", MySqlDbType.DateTime),
					new MySqlParameter("?UsedDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.CouponCode;
            parameters[1].Value = model.CategoryId;
            parameters[2].Value = model.ClassId;
            parameters[3].Value = model.SupplierId;
            parameters[4].Value = model.RuleId;
            parameters[5].Value = model.CouponName;
            parameters[6].Value = model.CouponPwd;
            parameters[7].Value = model.UserId;
            parameters[8].Value = model.UserEmail;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.CouponPrice;
            parameters[11].Value = model.LimitPrice;
            parameters[12].Value = model.NeedPoint;
            parameters[13].Value = model.IsPwd;
            parameters[14].Value = model.IsReuse;
            parameters[15].Value = model.StartDate;
            parameters[16].Value = model.EndDate;
            parameters[17].Value = model.GenerateTime;
            parameters[18].Value = model.UsedDate;

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
        public bool Update(YSWL.MALL.Model.Shop.Coupon.CouponHistory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_CouponHistory set ");
            strSql.Append("CategoryId=?CategoryId,");
            strSql.Append("ClassId=?ClassId,");
            strSql.Append("SupplierId=?SupplierId,");
            strSql.Append("RuleId=?RuleId,");
            strSql.Append("CouponName=?CouponName,");
            strSql.Append("CouponPwd=?CouponPwd,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("UserEmail=?UserEmail,");
            strSql.Append("Status=?Status,");
            strSql.Append("CouponPrice=?CouponPrice,");
            strSql.Append("LimitPrice=?LimitPrice,");
            strSql.Append("NeedPoint=?NeedPoint,");
            strSql.Append("IsPwd=?IsPwd,");
            strSql.Append("IsReuse=?IsReuse,");
            strSql.Append("StartDate=?StartDate,");
            strSql.Append("EndDate=?EndDate,");
            strSql.Append("GenerateTime=?GenerateTime,");
            strSql.Append("UsedDate=?UsedDate");
            strSql.Append(" where CouponCode=?CouponCode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CouponPwd", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CouponPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LimitPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?NeedPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?IsPwd", MySqlDbType.Int32,4),
					new MySqlParameter("?IsReuse", MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?GenerateTime", MySqlDbType.DateTime),
					new MySqlParameter("?UsedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.ClassId;
            parameters[2].Value = model.SupplierId;
            parameters[3].Value = model.RuleId;
            parameters[4].Value = model.CouponName;
            parameters[5].Value = model.CouponPwd;
            parameters[6].Value = model.UserId;
            parameters[7].Value = model.UserEmail;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.CouponPrice;
            parameters[10].Value = model.LimitPrice;
            parameters[11].Value = model.NeedPoint;
            parameters[12].Value = model.IsPwd;
            parameters[13].Value = model.IsReuse;
            parameters[14].Value = model.StartDate;
            parameters[15].Value = model.EndDate;
            parameters[16].Value = model.GenerateTime;
            parameters[17].Value = model.UsedDate;
            parameters[18].Value = model.CouponCode;

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
        public bool Delete(string CouponCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_CouponHistory ");
            strSql.Append(" where CouponCode=?CouponCode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,200)			};
            parameters[0].Value = CouponCode;

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
        public bool DeleteList(string CouponCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_CouponHistory ");
            strSql.Append(" where CouponCode in (" + CouponCodelist + ")  ");
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
        public YSWL.MALL.Model.Shop.Coupon.CouponHistory GetModel(string CouponCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  CouponCode,CategoryId,ClassId,SupplierId,RuleId,CouponName,CouponPwd,UserId,UserEmail,Status,CouponPrice,LimitPrice,NeedPoint,IsPwd,IsReuse,StartDate,EndDate,GenerateTime,UsedDate from Shop_CouponHistory ");
            strSql.Append(" where CouponCode=?CouponCode ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,200)			};
            parameters[0].Value = CouponCode;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Coupon.CouponHistory model = new YSWL.MALL.Model.Shop.Coupon.CouponHistory();
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
        public YSWL.MALL.Model.Shop.Coupon.CouponHistory DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Coupon.CouponHistory model = new YSWL.MALL.Model.Shop.Coupon.CouponHistory();
            if (row != null)
            {
                if (row["CouponCode"] != null)
                {
                    model.CouponCode = row["CouponCode"].ToString();
                }
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(row["CategoryId"].ToString());
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["SupplierId"] != null && row["SupplierId"].ToString() != "")
                {
                    model.SupplierId = int.Parse(row["SupplierId"].ToString());
                }
                if (row["RuleId"] != null && row["RuleId"].ToString() != "")
                {
                    model.RuleId = int.Parse(row["RuleId"].ToString());
                }
                if (row["CouponName"] != null)
                {
                    model.CouponName = row["CouponName"].ToString();
                }
                if (row["CouponPwd"] != null)
                {
                    model.CouponPwd = row["CouponPwd"].ToString();
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserEmail"] != null)
                {
                    model.UserEmail = row["UserEmail"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CouponPrice"] != null && row["CouponPrice"].ToString() != "")
                {
                    model.CouponPrice = decimal.Parse(row["CouponPrice"].ToString());
                }
                if (row["LimitPrice"] != null && row["LimitPrice"].ToString() != "")
                {
                    model.LimitPrice = decimal.Parse(row["LimitPrice"].ToString());
                }
                if (row["NeedPoint"] != null && row["NeedPoint"].ToString() != "")
                {
                    model.NeedPoint = int.Parse(row["NeedPoint"].ToString());
                }
                if (row["IsPwd"] != null && row["IsPwd"].ToString() != "")
                {
                    model.IsPwd = int.Parse(row["IsPwd"].ToString());
                }
                if (row["IsReuse"] != null && row["IsReuse"].ToString() != "")
                {
                    model.IsReuse = int.Parse(row["IsReuse"].ToString());
                }
                if (row["StartDate"] != null && row["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(row["StartDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["GenerateTime"] != null && row["GenerateTime"].ToString() != "")
                {
                    model.GenerateTime = DateTime.Parse(row["GenerateTime"].ToString());
                }
                if (row["UsedDate"] != null && row["UsedDate"].ToString() != "")
                {
                    model.UsedDate = DateTime.Parse(row["UsedDate"].ToString());
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
            strSql.Append("select CouponCode,CategoryId,ClassId,SupplierId,RuleId,CouponName,CouponPwd,UserId,UserEmail,Status,CouponPrice,LimitPrice,NeedPoint,IsPwd,IsReuse,StartDate,EndDate,GenerateTime,UsedDate ");
            strSql.Append(" FROM Shop_CouponHistory ");
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
            
            strSql.Append(" CouponCode,CategoryId,ClassId,SupplierId,RuleId,CouponName,CouponPwd,UserId,UserEmail,Status,CouponPrice,LimitPrice,NeedPoint,IsPwd,IsReuse,StartDate,EndDate,GenerateTime,UsedDate ");
            strSql.Append(" FROM Shop_CouponHistory ");
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
            strSql.Append("select count(1) FROM Shop_CouponHistory ");
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
            strSql.Append("SELECT T.* from Shop_CouponHistory T ");
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
                strSql.Append(" order by T.CouponCode desc");
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
            parameters[0].Value = "Shop_CouponHistory";
            parameters[1].Value = "CouponCode";
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

