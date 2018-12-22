using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Order;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Order
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
            strSql.Append("select count(1) from Shop_OrderAction");
            strSql.Append(" where ActionId=?ActionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int64)
			};
            parameters[0].Value = ActionId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Order.OrderAction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_OrderAction(");
            strSql.Append("OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("?OrderId,?OrderCode,?UserId,?Username,?ActionCode,?ActionDate,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Username", MySqlDbType.VarChar,200),
					new MySqlParameter("?ActionCode", MySqlDbType.VarChar,100),
					new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,1000)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.Username;
            parameters[4].Value = model.ActionCode;
            parameters[5].Value = model.ActionDate;
            parameters[6].Value = model.Remark;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
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
            strSql.Append("update Shop_OrderAction set ");
            strSql.Append("OrderId=?OrderId,");
            strSql.Append("OrderCode=?OrderCode,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("Username=?Username,");
            strSql.Append("ActionCode=?ActionCode,");
            strSql.Append("ActionDate=?ActionDate,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where ActionId=?ActionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Username", MySqlDbType.VarChar,200),
					new MySqlParameter("?ActionCode", MySqlDbType.VarChar,100),
					new MySqlParameter("?ActionDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,1000),
					new MySqlParameter("?ActionId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.Username;
            parameters[4].Value = model.ActionCode;
            parameters[5].Value = model.ActionDate;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.ActionId;

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
        public bool Delete(long ActionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderAction ");
            strSql.Append(" where ActionId=?ActionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int64)
			};
            parameters[0].Value = ActionId;

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
        public bool DeleteList(string ActionIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderAction ");
            strSql.Append(" where ActionId in (" + ActionIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Order.OrderAction GetModel(long ActionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ActionId,OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark from Shop_OrderAction ");
            strSql.Append(" where ActionId=?ActionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ActionId", MySqlDbType.Int64)
			};
            parameters[0].Value = ActionId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Order.OrderAction model = new YSWL.MALL.Model.Shop.Order.OrderAction();
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
            strSql.Append(" FROM Shop_OrderAction ");
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
            
            strSql.Append(" ActionId,OrderId,OrderCode,UserId,Username,ActionCode,ActionDate,Remark ");
            strSql.Append(" FROM Shop_OrderAction ");
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
            strSql.Append("select count(1) FROM Shop_OrderAction ");
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
            strSql.Append("SELECT T.* from Shop_OrderAction T ");
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
                strSql.Append(" order by T.ActionId desc");
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
            parameters[0].Value = "Shop_OrderAction";
            parameters[1].Value = "ActionId";
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

