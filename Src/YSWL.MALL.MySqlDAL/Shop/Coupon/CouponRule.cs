/**
* CouponRule.cs
*
* 功 能： N/A
* 类 名： CouponRule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/26 17:21:01   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Coupon;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Coupon
{
    /// <summary>
    /// 数据访问类:CouponRule
    /// </summary>
    public partial class CouponRule : ICouponRule
    {
        public CouponRule()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("RuleId", "Shop_CouponRule");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RuleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_CouponRule");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RuleId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Coupon.CouponRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_CouponRule(");
            strSql.Append("CategoryId,ClassId,SupplierId,Name,PreName,ImageUrl,CouponPrice,LimitPrice,CouponDesc,SendCount,NeedPoint,IsPwd,IsReuse,Status,Recommend,StartDate,EndDate,CreateDate,CreateUserId,Type,CpLength,PwdLength)");
            strSql.Append(" values (");
            strSql.Append("?CategoryId,?ClassId,?SupplierId,?Name,?PreName,?ImageUrl,?CouponPrice,?LimitPrice,?CouponDesc,?SendCount,?NeedPoint,?IsPwd,?IsReuse,?Status,?Recommend,?StartDate,?EndDate,?CreateDate,?CreateUserId,?Type,?CpLength,?PwdLength)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?PreName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CouponPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LimitPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponDesc", MySqlDbType.VarChar,-1),
					new MySqlParameter("?SendCount", MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?IsPwd", MySqlDbType.Int32,4),
					new MySqlParameter("?IsReuse", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Recommend", MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreateUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?CpLength", MySqlDbType.Int32,4),
					new MySqlParameter("?PwdLength", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.ClassId;
            parameters[2].Value = model.SupplierId;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.PreName;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.CouponPrice;
            parameters[7].Value = model.LimitPrice;
            parameters[8].Value = model.CouponDesc;
            parameters[9].Value = model.SendCount;
            parameters[10].Value = model.NeedPoint;
            parameters[11].Value = model.IsPwd;
            parameters[12].Value = model.IsReuse;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.Recommend;
            parameters[15].Value = model.StartDate;
            parameters[16].Value = model.EndDate;
            parameters[17].Value = model.CreateDate;
            parameters[18].Value = model.CreateUserId;
            parameters[19].Value = model.Type;
            parameters[20].Value = model.CpLength;
            parameters[21].Value = model.PwdLength;

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
        public bool Update(YSWL.MALL.Model.Shop.Coupon.CouponRule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_CouponRule set ");
            strSql.Append("CategoryId=?CategoryId,");
            strSql.Append("ClassId=?ClassId,");
            strSql.Append("SupplierId=?SupplierId,");
            strSql.Append("Name=?Name,");
            strSql.Append("PreName=?PreName,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("CouponPrice=?CouponPrice,");
            strSql.Append("LimitPrice=?LimitPrice,");
            strSql.Append("CouponDesc=?CouponDesc,");
            strSql.Append("SendCount=?SendCount,");
            strSql.Append("NeedPoint=?NeedPoint,");
            strSql.Append("IsPwd=?IsPwd,");
            strSql.Append("IsReuse=?IsReuse,");
            strSql.Append("Status=?Status,");
            strSql.Append("Recommend=?Recommend,");
            strSql.Append("StartDate=?StartDate,");
            strSql.Append("EndDate=?EndDate,");
            strSql.Append("CreateDate=?CreateDate,");
            strSql.Append("CreateUserId=?CreateUserId,");
            strSql.Append("Type=?Type,");
            strSql.Append("CpLength=?CpLength,");
            strSql.Append("PwdLength=?PwdLength");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?PreName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CouponPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LimitPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponDesc", MySqlDbType.VarChar,-1),
					new MySqlParameter("?SendCount", MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?IsPwd", MySqlDbType.Int32,4),
					new MySqlParameter("?IsReuse", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Recommend", MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreateUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?CpLength", MySqlDbType.Int32,4),
					new MySqlParameter("?PwdLength", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.ClassId;
            parameters[2].Value = model.SupplierId;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.PreName;
            parameters[5].Value = model.ImageUrl;
            parameters[6].Value = model.CouponPrice;
            parameters[7].Value = model.LimitPrice;
            parameters[8].Value = model.CouponDesc;
            parameters[9].Value = model.SendCount;
            parameters[10].Value = model.NeedPoint;
            parameters[11].Value = model.IsPwd;
            parameters[12].Value = model.IsReuse;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.Recommend;
            parameters[15].Value = model.StartDate;
            parameters[16].Value = model.EndDate;
            parameters[17].Value = model.CreateDate;
            parameters[18].Value = model.CreateUserId;
            parameters[19].Value = model.Type;
            parameters[20].Value = model.CpLength;
            parameters[21].Value = model.PwdLength;
            parameters[22].Value = model.RuleId;

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
        public bool Delete(int RuleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_CouponRule ");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RuleId;

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
        public bool DeleteList(string RuleIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_CouponRule ");
            strSql.Append(" where RuleId in (" + RuleIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Coupon.CouponRule GetModel(int RuleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  RuleId,CategoryId,ProductId,ProductSku,ClassId,SupplierId,Name,PreName,ImageUrl,CouponPrice,LimitPrice,CouponDesc,SendCount,NeedPoint,IsPwd,IsReuse,Status,Recommend,StartDate,EndDate,CreateDate,CreateUserId,Type,CpLength,PwdLength from Shop_CouponRule ");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RuleId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Coupon.CouponRule model = new YSWL.MALL.Model.Shop.Coupon.CouponRule();
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
        public YSWL.MALL.Model.Shop.Coupon.CouponRule DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Coupon.CouponRule model = new YSWL.MALL.Model.Shop.Coupon.CouponRule();
            if (row != null)
            {
                if (row["RuleId"] != null && row["RuleId"].ToString() != "")
                {
                    model.RuleId = int.Parse(row["RuleId"].ToString());
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
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["PreName"] != null)
                {
                    model.PreName = row["PreName"].ToString();
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["CouponPrice"] != null && row["CouponPrice"].ToString() != "")
                {
                    model.CouponPrice = decimal.Parse(row["CouponPrice"].ToString());
                }
                if (row["LimitPrice"] != null && row["LimitPrice"].ToString() != "")
                {
                    model.LimitPrice = decimal.Parse(row["LimitPrice"].ToString());
                }
                if (row["CouponDesc"] != null)
                {
                    model.CouponDesc = row["CouponDesc"].ToString();
                }
                if (row["SendCount"] != null && row["SendCount"].ToString() != "")
                {
                    model.SendCount = int.Parse(row["SendCount"].ToString());
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
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Recommend"] != null && row["Recommend"].ToString() != "")
                {
                    model.Recommend = int.Parse(row["Recommend"].ToString());
                }
                if (row["StartDate"] != null && row["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(row["StartDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CreateUserId"] != null && row["CreateUserId"].ToString() != "")
                {
                    model.CreateUserId = int.Parse(row["CreateUserId"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["CpLength"] != null && row["CpLength"].ToString() != "")
                {
                    model.CpLength = int.Parse(row["CpLength"].ToString());
                }
                if (row["PwdLength"] != null && row["PwdLength"].ToString() != "")
                {
                    model.PwdLength = int.Parse(row["PwdLength"].ToString());
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
            strSql.Append("select RuleId,CategoryId,ClassId,ProductId,ProductSku,SupplierId,Name,PreName,ImageUrl,CouponPrice,LimitPrice,CouponDesc,SendCount,NeedPoint,IsPwd,IsReuse,Status,Recommend,StartDate,EndDate,CreateDate,CreateUserId,Type,CpLength,PwdLength ");
            strSql.Append(" FROM Shop_CouponRule ");
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

            strSql.Append(" RuleId,CategoryId,ClassId,SupplierId,Name,PreName,ImageUrl,CouponPrice,LimitPrice,CouponDesc,SendCount,NeedPoint,IsPwd,IsReuse,Status,Recommend,StartDate,EndDate,CreateDate,CreateUserId,Type,CpLength,PwdLength ");
            strSql.Append(" FROM Shop_CouponRule ");
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
            strSql.Append("select count(1) FROM Shop_CouponRule ");
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
            strSql.Append("SELECT T.* from Shop_CouponRule T ");
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
                strSql.Append(" order by T.RuleId desc");
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
            parameters[0].Value = "Shop_CouponRule";
            parameters[1].Value = "RuleId";
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
        ///级联删除数据
        /// </summary>
        public bool DeleteEx(int RuleId)
        {
            //事务处理
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_CouponRule ");
            strSql.Append(" where RuleId=?RuleId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RuleId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from Shop_CouponInfo ");
            strSql1.Append(" where RuleId=?RuleId  ");
            MySqlParameter[] parameters1 = {
						new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
                                         };
            parameters1[0].Value = RuleId;
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd1);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from Shop_CouponHistory ");
            strSql2.Append(" where RuleId=?RuleId  ");
            MySqlParameter[] parameters2 = {
						new MySqlParameter("?RuleId", MySqlDbType.Int32,4)
                                         };
            parameters2[0].Value = RuleId;
            CommandInfo cmd2 = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd2);


            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;
        }


        public bool GenCoupon(YSWL.MALL.Model.Shop.Coupon.CouponInfo infoModel)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            //添加优惠券
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into Shop_CouponInfo(");
            strSql3.Append("CouponCode,CategoryId,ClassId,SupplierId,RuleId,CouponName,CouponPwd,UserId,UserEmail,Status,CouponPrice,LimitPrice,NeedPoint,IsPwd,IsReuse,StartDate,EndDate,GenerateTime,UsedDate)");
            strSql3.Append(" values (");
            strSql3.Append("?CouponCode,?CategoryId,?ClassId,?SupplierId,?RuleId,?CouponName,?CouponPwd,?UserId,?UserEmail,?Status,?CouponPrice,?LimitPrice,?NeedPoint,?IsPwd,?IsReuse,?StartDate,?EndDate,?GenerateTime,?UsedDate)");
            MySqlParameter[] parameters3 = {
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
            parameters3[0].Value = infoModel.CouponCode;
            parameters3[1].Value = infoModel.CategoryId;
            parameters3[2].Value = infoModel.ClassId;
            parameters3[3].Value = infoModel.SupplierId;
            parameters3[4].Value = infoModel.RuleId;
            parameters3[5].Value = infoModel.CouponName;
            parameters3[6].Value = infoModel.CouponPwd;
            parameters3[7].Value = infoModel.UserId;
            parameters3[8].Value = infoModel.UserEmail;
            parameters3[9].Value = infoModel.Status;
            parameters3[10].Value = infoModel.CouponPrice;
            parameters3[11].Value = infoModel.LimitPrice;
            parameters3[12].Value = infoModel.NeedPoint;
            parameters3[13].Value = infoModel.IsPwd;
            parameters3[14].Value = infoModel.IsReuse;
            parameters3[15].Value = infoModel.StartDate;
            parameters3[16].Value = infoModel.EndDate;
            parameters3[17].Value = infoModel.GenerateTime;
            parameters3[18].Value = infoModel.UsedDate;
            CommandInfo cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //添加兑换记录
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("insert into Shop_ExchangeDetail(");
            strSql4.Append("Type,GiftID,UserID,OrderID,GiftName,Price,CouponCode,CostScore,Status,Description,CreatedDate)");
            strSql4.Append(" values (");
            strSql4.Append("?Type,?GiftID,?UserID,?OrderID,?GiftName,?Price,?CouponCode,?CostScore,?Status,?Description,?CreatedDate)");
            strSql4.Append(";select last_insert_id()");
            MySqlParameter[] parameters4 = {
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?GiftID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,4),
					new MySqlParameter("?GiftName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Price", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,200),
					new MySqlParameter("?CostScore", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
            parameters4[0].Value = 1;
            parameters4[1].Value = 0;
            parameters4[2].Value = infoModel.UserId;
            parameters4[3].Value = 0;
            parameters4[4].Value = "";
            parameters4[5].Value = infoModel.CouponPrice;
            parameters4[6].Value = infoModel.CouponCode;
            parameters4[7].Value = infoModel.NeedPoint;
            parameters4[8].Value = 1;
            parameters4[9].Value = "积分兑换优惠券";
            parameters4[10].Value = infoModel.GenerateTime;
            cmd = new CommandInfo(strSql4.ToString(), parameters4);
            sqllist.Add(cmd);

            //添加积分明细
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_PointsDetail(");
            strSql.Append("RuleId,UserID,Score,ExtData,CurrentPoints,Description,CreatedDate,Type)");
            strSql.Append(" values (");
            strSql.Append("?RuleId,?UserID,?Score,?ExtData,0,?Description,?CreatedDate,?Type)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?RuleId", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserID", MySqlDbType.Int32,4),
                    new MySqlParameter("?Score", MySqlDbType.Int32,4),
                    new MySqlParameter("?ExtData", MySqlDbType.VarChar),
                    new MySqlParameter("?Description", MySqlDbType.VarChar),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
            new MySqlParameter("?Type", MySqlDbType.Int32,4)};
            parameters[0].Value = -1;
            parameters[1].Value = infoModel.UserId;
            parameters[2].Value = infoModel.NeedPoint;
            parameters[3].Value = "";
            parameters[4].Value = "兑换优惠券";
            parameters[5].Value = infoModel.GenerateTime;
            parameters[6].Value = 1;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //更新个人积分数
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update Accounts_UsersExp set ");

            strSql2.Append("Points=Points-?Points");

            strSql2.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserID", MySqlDbType.Int32,4)
                                        };
            parameters2[0].Value = infoModel.NeedPoint;
            parameters2[1].Value = infoModel.UserId;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int ImportExcelData(YSWL.MALL.Model.Shop.Coupon.CouponRule ruleModel, bool IsDate, bool IsPrice, bool IsLimitPrice, DataTable dt)
        {
            string connectionString = PubConstant.GetConnectionString("ConnectionString");
            int count = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    int rowsCount = dt.Rows.Count;
                    YSWL.MALL.Model.Shop.Coupon.CouponInfo model;
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into Shop_CouponRule(");
                    strSql.Append("CategoryId,ClassId,SupplierId,Name,PreName,ImageUrl,CouponPrice,LimitPrice,CouponDesc,SendCount,NeedPoint,IsPwd,IsReuse,Status,Recommend,StartDate,EndDate,CreateDate,CreateUserId,Type,CpLength,PwdLength)");
                    strSql.Append(" values (");
                    strSql.Append("?CategoryId,?ClassId,?SupplierId,?Name,?PreName,?ImageUrl,?CouponPrice,?LimitPrice,?CouponDesc,?SendCount,?NeedPoint,?IsPwd,?IsReuse,?Status,?Recommend,?StartDate,?EndDate,?CreateDate,?CreateUserId,?Type,?CpLength,?PwdLength)");
                    strSql.Append(";select last_insert_id()");
                    MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?PreName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CouponPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?LimitPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?CouponDesc", MySqlDbType.VarChar,-1),
					new MySqlParameter("?SendCount", MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPoint", MySqlDbType.Int32,4),
					new MySqlParameter("?IsPwd", MySqlDbType.Int32,4),
					new MySqlParameter("?IsReuse", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Recommend", MySqlDbType.Int32,4),
					new MySqlParameter("?StartDate", MySqlDbType.DateTime),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreateUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4),
					new MySqlParameter("?CpLength", MySqlDbType.Int32,4),
					new MySqlParameter("?PwdLength", MySqlDbType.Int32,4)};
                    parameters[0].Value = ruleModel.CategoryId;
                    parameters[1].Value = ruleModel.ClassId;
                    parameters[2].Value = ruleModel.SupplierId;
                    parameters[3].Value = ruleModel.Name;
                    parameters[4].Value = ruleModel.PreName;
                    parameters[5].Value = ruleModel.ImageUrl;
                    parameters[6].Value = ruleModel.CouponPrice;
                    parameters[7].Value = ruleModel.LimitPrice;
                    parameters[8].Value = ruleModel.CouponDesc;
                    parameters[9].Value = ruleModel.SendCount;
                    parameters[10].Value = ruleModel.NeedPoint;
                    parameters[11].Value = ruleModel.IsPwd;
                    parameters[12].Value = ruleModel.IsReuse;
                    parameters[13].Value = ruleModel.Status;
                    parameters[14].Value = ruleModel.Recommend;
                    parameters[15].Value = ruleModel.StartDate;
                    parameters[16].Value = ruleModel.EndDate;
                    parameters[17].Value = ruleModel.CreateDate;
                    parameters[18].Value = ruleModel.CreateUserId;
                    parameters[19].Value = ruleModel.Type;
                    parameters[20].Value = ruleModel.CpLength;
                    parameters[21].Value = ruleModel.PwdLength;

                    object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
                    int ruleId = Common.Globals.SafeInt(obj, 0);
                    if (ruleId == 0)
                    {
                        return 0;
                    }

                    StringBuilder infostrSql = new StringBuilder();
                    infostrSql.Append("insert into Shop_CouponInfo(");
                    infostrSql.Append("CouponCode,CategoryId,ClassId,SupplierId,RuleId,CouponName,CouponPwd,UserId,UserEmail,Status,CouponPrice,LimitPrice,NeedPoint,IsPwd,IsReuse,StartDate,EndDate,GenerateTime,UsedDate)");
                    infostrSql.Append(" values (");
                    infostrSql.Append("?CouponCode,?CategoryId,?ClassId,?SupplierId,?RuleId,?CouponName,?CouponPwd,?UserId,?UserEmail,?Status,?CouponPrice,?LimitPrice,?NeedPoint,?IsPwd,?IsReuse,?StartDate,?EndDate,?GenerateTime,?UsedDate)");
                    MySqlParameter[] infoparameters = {
					new MySqlParameter("?CouponCode", MySqlDbType.VarChar,200),
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?RuleId", MySqlDbType.Int32,4),
					new MySqlParameter("?CouponName", MySqlDbType.VarChar,200),
					new MySqlParameter("?CouponPwd", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserId", MySqlDbType.VarChar,200),
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

                    cmd.Connection = conn;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        #region 插入优惠券数据
                        model = new YSWL.MALL.Model.Shop.Coupon.CouponInfo();
                        if (dt.Rows[n]["优惠券卡号"] != null && dt.Rows[n]["优惠券卡号"].ToString() != "")
                        {
                            model.CouponCode = dt.Rows[n]["优惠券卡号"].ToString();
                        }
                        if (dt.Rows[n]["面值"] != null && dt.Rows[n]["面值"].ToString() != "")
                        {
                            model.CouponPrice = Common.Globals.SafeDecimal(dt.Rows[n]["面值"].ToString(), 0);
                        }
                        if (dt.Rows[n]["最低消费金额"] != null && dt.Rows[n]["最低消费金额"].ToString() != "")
                        {
                            model.LimitPrice = Common.Globals.SafeDecimal(dt.Rows[n]["最低消费金额"].ToString(), 0);
                        }
                        if (dt.Rows[n]["开始时间"] != null && dt.Rows[n]["开始时间"].ToString() != "")
                        {
                            model.StartDate = Common.Globals.SafeDateTime(dt.Rows[n]["开始时间"].ToString(), DateTime.Now);
                        }
                        if (dt.Rows[n]["结束时间"] != null && dt.Rows[n]["结束时间"].ToString() != "")
                        {
                            model.EndDate = Common.Globals.SafeDateTime(dt.Rows[n]["结束时间"].ToString(), DateTime.Now);
                        }

                        if (String.IsNullOrWhiteSpace(model.CouponCode))
                        {
                            continue;
                        }
                        model.StartDate = IsDate ? ruleModel.StartDate : model.StartDate;
                        model.EndDate = IsDate ? ruleModel.EndDate : model.EndDate;
                        model.LimitPrice = IsLimitPrice ? ruleModel.LimitPrice : model.LimitPrice;
                        model.CouponPrice = IsPrice ? ruleModel.CouponPrice : model.CouponPrice;
                        #region 判断重复
                        StringBuilder exsitSql = new StringBuilder();
                        exsitSql.Append("select count(1) from Shop_CouponInfo");
                        exsitSql.Append(" where CouponCode=?CouponCode  ");
                        MySqlParameter[] exsitpars = {
					        new MySqlParameter("?CouponCode", MySqlDbType.VarChar)};
                        exsitpars[0].Value = model.CouponCode;
                        cmd.CommandText = exsitSql.ToString();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(exsitpars);
                        object codeobj = cmd.ExecuteScalar();

                        if (Common.Globals.SafeInt(codeobj.ToString(), 0) > 0)
                        {
                            continue;
                        }

                        #endregion
                        model.Status = ruleModel.Status;
                        model.CategoryId = ruleModel.CategoryId;
                        model.ClassId = ruleModel.ClassId;
                        model.CouponName = ruleModel.Name;
                        model.CouponPwd = "";
                        model.GenerateTime = DateTime.Now;
                        model.IsPwd = ruleModel.IsPwd;
                        model.IsReuse = ruleModel.IsReuse;
                        model.NeedPoint = 0;
                        model.RuleId = ruleId;
                        model.SupplierId = ruleModel.SupplierId;
                        model.UserId = 0;

                        infoparameters[0].Value = model.CouponCode;
                        infoparameters[1].Value = model.CategoryId;
                        infoparameters[2].Value = model.ClassId;
                        infoparameters[3].Value = model.SupplierId;
                        infoparameters[4].Value = model.RuleId;
                        infoparameters[5].Value = model.CouponName;
                        infoparameters[6].Value = model.CouponPwd;
                        infoparameters[7].Value = model.UserId;
                        infoparameters[8].Value = model.UserEmail;
                        infoparameters[9].Value = model.Status;
                        infoparameters[10].Value = model.CouponPrice;
                        infoparameters[11].Value = model.LimitPrice;
                        infoparameters[12].Value = model.NeedPoint;
                        infoparameters[13].Value = model.IsPwd;
                        infoparameters[14].Value = model.IsReuse;
                        infoparameters[15].Value = model.StartDate;
                        infoparameters[16].Value = model.EndDate;
                        infoparameters[17].Value = model.GenerateTime;
                        infoparameters[18].Value = model.UsedDate;
                        cmd.CommandText = infostrSql.ToString();
                        cmd.Parameters.Clear();
                        foreach (MySqlParameter parameter in infoparameters)
                        {
                            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                                (parameter.Value == null))
                            {
                                parameter.Value = DBNull.Value;
                            }
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.ExecuteNonQuery();
                        #endregion
                        count++;

                    }
                    #region 更新活动Count
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.Append("update Shop_CouponRule set ");
                    strSql1.Append("SendCount=" + count);
                    strSql1.Append(" where RuleId=?RuleId");
                    MySqlParameter[] parameters1 = { new MySqlParameter("?RuleId", MySqlDbType.Int32, 4) };
                    parameters1[0].Value = ruleModel.RuleId;
                    cmd.CommandText = strSql1.ToString();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(parameters1);
                    cmd.ExecuteNonQuery();
                    #endregion
                }
            }
            return count;
        }

        #endregion  ExtensionMethod
    }
}

