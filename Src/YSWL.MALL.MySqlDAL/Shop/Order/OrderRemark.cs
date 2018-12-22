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
	/// 数据访问类:OrderRemark
	/// </summary>
	public partial class OrderRemark:IOrderRemark
	{
		public OrderRemark()
		{}
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long RemarkId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_OrderRemark");
            strSql.Append(" where RemarkId=?RemarkId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RemarkId", MySqlDbType.Int64)
			};
            parameters[0].Value = RemarkId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Order.OrderRemark model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_OrderRemark(");
            strSql.Append("OrderId,OrderCode,UserId,UserName,Remark,CreatedDate)");
            strSql.Append(" values (");
            strSql.Append("?OrderId,?OrderCode,?UserId,?UserName,?Remark,?CreatedDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,1000),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.CreatedDate;

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
        public bool Update(YSWL.MALL.Model.Shop.Order.OrderRemark model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_OrderRemark set ");
            strSql.Append("OrderId=?OrderId,");
            strSql.Append("OrderCode=?OrderCode,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("CreatedDate=?CreatedDate");
            strSql.Append(" where RemarkId=?RemarkId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,1000),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?RemarkId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.RemarkId;

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
        public bool Delete(long RemarkId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderRemark ");
            strSql.Append(" where RemarkId=?RemarkId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RemarkId", MySqlDbType.Int64)
			};
            parameters[0].Value = RemarkId;

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
        public bool DeleteList(string RemarkIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderRemark ");
            strSql.Append(" where RemarkId in (" + RemarkIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Order.OrderRemark GetModel(long RemarkId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  RemarkId,OrderId,OrderCode,UserId,UserName,Remark,CreatedDate from Shop_OrderRemark ");
            strSql.Append(" where RemarkId=?RemarkId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RemarkId", MySqlDbType.Int64)
			};
            parameters[0].Value = RemarkId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Order.OrderRemark model = new YSWL.MALL.Model.Shop.Order.OrderRemark();
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
        public YSWL.MALL.Model.Shop.Order.OrderRemark DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Order.OrderRemark model = new YSWL.MALL.Model.Shop.Order.OrderRemark();
            if (row != null)
            {
                if (row["RemarkId"] != null && row["RemarkId"].ToString() != "")
                {
                    model.RemarkId = long.Parse(row["RemarkId"].ToString());
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
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
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
            strSql.Append("select RemarkId,OrderId,OrderCode,UserId,UserName,Remark,CreatedDate ");
            strSql.Append(" FROM Shop_OrderRemark ");
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
            
            strSql.Append(" RemarkId,OrderId,OrderCode,UserId,UserName,Remark,CreatedDate ");
            strSql.Append(" FROM Shop_OrderRemark ");
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
            strSql.Append("select count(1) FROM Shop_OrderRemark ");
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
            strSql.Append("SELECT T.* from Shop_OrderRemark T ");
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
                strSql.Append(" order by T.RemarkId desc");
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
            parameters[0].Value = "Shop_OrderRemark";
            parameters[1].Value = "RemarkId";
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

