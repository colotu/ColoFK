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
	/// 数据访问类:OrderLookupList
	/// </summary>
	public partial class OrderLookupList:IOrderLookupList
	{
		public OrderLookupList()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("LookupListId", "Shop_OrderLookupList");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LookupListId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_OrderLookupList");
            strSql.Append(" where LookupListId=?LookupListId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupListId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LookupListId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Order.OrderLookupList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_OrderLookupList(");
            strSql.Append("Name,SelectMode,Description)");
            strSql.Append(" values (");
            strSql.Append("?Name,?SelectMode,?Description)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?SelectMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,1000)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.SelectMode;
            parameters[2].Value = model.Description;

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
        public bool Update(YSWL.MALL.Model.Shop.Order.OrderLookupList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_OrderLookupList set ");
            strSql.Append("Name=?Name,");
            strSql.Append("SelectMode=?SelectMode,");
            strSql.Append("Description=?Description");
            strSql.Append(" where LookupListId=?LookupListId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?SelectMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?LookupListId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.SelectMode;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.LookupListId;

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
        public bool Delete(int LookupListId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderLookupList ");
            strSql.Append(" where LookupListId=?LookupListId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupListId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LookupListId;

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
        public bool DeleteList(string LookupListIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderLookupList ");
            strSql.Append(" where LookupListId in (" + LookupListIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Order.OrderLookupList GetModel(int LookupListId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  LookupListId,Name,SelectMode,Description from Shop_OrderLookupList ");
            strSql.Append(" where LookupListId=?LookupListId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupListId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LookupListId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Order.OrderLookupList model = new YSWL.MALL.Model.Shop.Order.OrderLookupList();
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
        public YSWL.MALL.Model.Shop.Order.OrderLookupList DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Order.OrderLookupList model = new YSWL.MALL.Model.Shop.Order.OrderLookupList();
            if (row != null)
            {
                if (row["LookupListId"] != null && row["LookupListId"].ToString() != "")
                {
                    model.LookupListId = int.Parse(row["LookupListId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["SelectMode"] != null && row["SelectMode"].ToString() != "")
                {
                    model.SelectMode = int.Parse(row["SelectMode"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
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
            strSql.Append("select LookupListId,Name,SelectMode,Description ");
            strSql.Append(" FROM Shop_OrderLookupList ");
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
            
            strSql.Append(" LookupListId,Name,SelectMode,Description ");
            strSql.Append(" FROM Shop_OrderLookupList ");
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
            strSql.Append("select count(1) FROM Shop_OrderLookupList ");
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
            strSql.Append("SELECT T.* from Shop_OrderLookupList T ");
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
                strSql.Append(" order by T.LookupListId desc");
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
            parameters[0].Value = "Shop_OrderLookupList";
            parameters[1].Value = "LookupListId";
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

