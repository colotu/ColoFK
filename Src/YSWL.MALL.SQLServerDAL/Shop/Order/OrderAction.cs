﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Order;
using YSWL.DBUtility;//Please add references
namespace YSWL.MALL.SQLServerDAL.Shop.Order
{
	/// <summary>
	/// 数据访问类:OrderAction
	/// </summary>
	public partial class OrderAction:IOrderAction
	{
		public OrderAction()
		{}
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ActionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OMS_OrderAction");
            strSql.Append(" where ActionId=@ActionId");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.BigInt)
			};
            parameters[0].Value = ActionId;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Order.OrderAction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OMS_OrderAction(");
            strSql.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@OrderCode,@UserId,@Username,@ActionCode,@ActionDate,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.BigInt,8),
					new SqlParameter("@OrderCode", SqlDbType.NVarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.NVarChar,200),
					new SqlParameter("@ActionCode", SqlDbType.NVarChar,100),
					new SqlParameter("@ActionDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.Username;
            parameters[4].Value = model.ActionCode;
            parameters[5].Value = model.ActionDate;
            parameters[6].Value = model.Remark;

            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.Order.OrderAction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OMS_OrderAction set ");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("OrderCode=@OrderCode,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Username=@Username,");
            strSql.Append("ActionCode=@ActionCode,");
            strSql.Append("ActionDate=@ActionDate,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ActionId=@ActionId");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderId", SqlDbType.BigInt,8),
					new SqlParameter("@OrderCode", SqlDbType.NVarChar,50),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Username", SqlDbType.NVarChar,200),
					new SqlParameter("@ActionCode", SqlDbType.NVarChar,100),
					new SqlParameter("@ActionDate", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@ActionId", SqlDbType.BigInt,8)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.Username;
            parameters[4].Value = model.ActionCode;
            parameters[5].Value = model.ActionDate;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.ActionId;

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
        public bool Delete(long ActionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OMS_OrderAction ");
            strSql.Append(" where ActionId=@ActionId");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.BigInt)
			};
            parameters[0].Value = ActionId;

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
        public bool DeleteList(string ActionIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OMS_OrderAction ");
            strSql.Append(" where ActionId in (" + ActionIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Order.OrderAction GetModel(long ActionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ActionId,OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark from OMS_OrderAction ");
            strSql.Append(" where ActionId=@ActionId");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.BigInt)
			};
            parameters[0].Value = ActionId;

            YSWL.MALL.Model.Shop.Order.OrderAction model = new YSWL.MALL.Model.Shop.Order.OrderAction();
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
        public YSWL.MALL.Model.Shop.Order.OrderAction DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Order.OrderAction model = new YSWL.MALL.Model.Shop.Order.OrderAction();
            if (row != null)
            {
                if (row["ActionId"] != null && row["ActionId"].ToString() != "")
                {
                    model.ActionId = long.Parse(row["ActionId"].ToString());
                }
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = long.Parse(row["OrderId"].ToString());
                }
                if (row["OrderCode"] != null)
                {
                    model.OrderCode = row["OrderCode"].ToString();
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Username"] != null)
                {
                    model.Username = row["Username"].ToString();
                }
                if (row["ActionCode"] != null)
                {
                    model.ActionCode = row["ActionCode"].ToString();
                }
                if (row["ActionDate"] != null && row["ActionDate"].ToString() != "")
                {
                    model.ActionDate = DateTime.Parse(row["ActionDate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select ActionId,OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark ");
            strSql.Append(" FROM OMS_OrderAction ");
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
            strSql.Append(" ActionId,OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark ");
            strSql.Append(" FROM OMS_OrderAction ");
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
            strSql.Append("select count(1) FROM OMS_OrderAction ");
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
                strSql.Append("order by T.ActionId desc");
            }
            strSql.Append(")AS Row, T.*  from OMS_OrderAction T ");
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
                    new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.NVarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NVarChar,1000),
                    };
            parameters[0].Value = "OMS_OrderAction";
            parameters[1].Value = "ActionId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelper.DefaultDBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

