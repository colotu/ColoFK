using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Gift;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Shop.Gift
{
    /// <summary>
    /// 数据访问类:ExchangeDetail
    /// </summary>
    public partial class ExchangeDetail : IExchangeDetail
    {
        public ExchangeDetail()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("DetailID", "Shop_ExchangeDetail");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_ExchangeDetail");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = DetailID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Gift.ExchangeDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_ExchangeDetail(");
            strSql.Append("Type,GiftID,UserID,OrderID,GiftName,Price,CouponCode,CostScore,Status,Description,CreatedDate)");
            strSql.Append(" values (");
            strSql.Append("?Type,?GiftID,?UserID,?OrderID,?GiftName,?Price,?CouponCode,?CostScore,?Status,?Description,?CreatedDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
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
            parameters[0].Value = model.Type;
            parameters[1].Value = model.GiftID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.GiftName;
            parameters[5].Value = model.Price;
            parameters[6].Value = model.CouponCode;
            parameters[7].Value = model.CostScore;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.CreatedDate;

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
        public bool Update(YSWL.MALL.Model.Shop.Gift.ExchangeDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ExchangeDetail set ");
            strSql.Append("Type=?Type,");
            strSql.Append("GiftID=?GiftID,");
            strSql.Append("UserID=?UserID,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("GiftName=?GiftName,");
            strSql.Append("Price=?Price,");
            strSql.Append("CouponCode=?CouponCode,");
            strSql.Append("CostScore=?CostScore,");
            strSql.Append("Status=?Status,");
            strSql.Append("Description=?Description,");
            strSql.Append("CreatedDate=?CreatedDate");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
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
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.GiftID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.GiftName;
            parameters[5].Value = model.Price;
            parameters[6].Value = model.CouponCode;
            parameters[7].Value = model.CostScore;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.CreatedDate;
            parameters[11].Value = model.DetailID;

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
        public bool Delete(int DetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ExchangeDetail ");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = DetailID;

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
        public bool DeleteList(string DetailIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ExchangeDetail ");
            strSql.Append(" where DetailID in (" + DetailIDlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Gift.ExchangeDetail GetModel(int DetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DetailID,Type,GiftID,UserID,OrderID,GiftName,Price,CouponCode,CostScore,Status,Description,CreatedDate from Shop_ExchangeDetail ");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = DetailID;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Gift.ExchangeDetail model = new YSWL.MALL.Model.Shop.Gift.ExchangeDetail();
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
        public YSWL.MALL.Model.Shop.Gift.ExchangeDetail DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Gift.ExchangeDetail model = new YSWL.MALL.Model.Shop.Gift.ExchangeDetail();
            if (row != null)
            {
                if (row["DetailID"] != null && row["DetailID"].ToString() != "")
                {
                    model.DetailID = int.Parse(row["DetailID"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["GiftID"] != null && row["GiftID"].ToString() != "")
                {
                    model.GiftID = int.Parse(row["GiftID"].ToString());
                }
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["GiftName"] != null)
                {
                    model.GiftName = row["GiftName"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["CouponCode"] != null)
                {
                    model.CouponCode = row["CouponCode"].ToString();
                }
                if (row["CostScore"] != null && row["CostScore"].ToString() != "")
                {
                    model.CostScore = int.Parse(row["CostScore"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
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
            strSql.Append("select DetailID,Type,GiftID,UserID,OrderID,GiftName,Price,CouponCode,CostScore,Status,Description,CreatedDate ");
            strSql.Append(" FROM Shop_ExchangeDetail ");
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
            
            strSql.Append(" DetailID,Type,GiftID,UserID,OrderID,GiftName,Price,CouponCode,CostScore,Status,Description,CreatedDate ");
            strSql.Append(" FROM Shop_ExchangeDetail ");
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
            strSql.Append("select count(1) FROM Shop_ExchangeDetail ");
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
            strSql.Append("SELECT T.* from Shop_ExchangeDetail T ");
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
                strSql.Append(" order by T.DetailID desc");
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
            parameters[0].Value = "Shop_ExchangeDetail";
            parameters[1].Value = "DetailID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region 扩展方法
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="detailId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool SetStatus(int detailId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ExchangeDetail set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where DetailID=?DetailID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?DetailID", MySqlDbType.Int32,4)};
            parameters[0].Value = status;
            parameters[1].Value = detailId;

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
        /// 批量设置状态
        /// </summary>
        /// <param name="detailId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool SetStatusList(string detailIds, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ExchangeDetail set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where DetailID in (" + detailIds + ")");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
            parameters[0].Value = status;

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
        #endregion
    }
}