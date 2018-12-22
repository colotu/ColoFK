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
	/// 数据访问类:OrderLookupItems
	/// </summary>
	public partial class OrderLookupItems:IOrderLookupItems
	{
		public OrderLookupItems()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("LookupItemId", "Shop_OrderLookupItems");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LookupItemId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_OrderLookupItems");
            strSql.Append(" where LookupItemId=?LookupItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupItemId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LookupItemId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Order.OrderLookupItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_OrderLookupItems(");
            strSql.Append("LookupListId,Name,IsInputRequired,InputTitle,AppendMoney,CalculateMode,Remark)");
            strSql.Append(" values (");
            strSql.Append("?LookupListId,?Name,?IsInputRequired,?InputTitle,?AppendMoney,?CalculateMode,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupListId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsInputRequired", MySqlDbType.Bit,1),
					new MySqlParameter("?InputTitle", MySqlDbType.VarChar,20),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,8),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300)};
            parameters[0].Value = model.LookupListId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.IsInputRequired;
            parameters[3].Value = model.InputTitle;
            parameters[4].Value = model.AppendMoney;
            parameters[5].Value = model.CalculateMode;
            parameters[6].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.Shop.Order.OrderLookupItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_OrderLookupItems set ");
            strSql.Append("LookupListId=?LookupListId,");
            strSql.Append("Name=?Name,");
            strSql.Append("IsInputRequired=?IsInputRequired,");
            strSql.Append("InputTitle=?InputTitle,");
            strSql.Append("AppendMoney=?AppendMoney,");
            strSql.Append("CalculateMode=?CalculateMode,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where LookupItemId=?LookupItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupListId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsInputRequired", MySqlDbType.Bit,1),
					new MySqlParameter("?InputTitle", MySqlDbType.VarChar,20),
					new MySqlParameter("?AppendMoney", MySqlDbType.Decimal,8),
					new MySqlParameter("?CalculateMode", MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,300),
					new MySqlParameter("?LookupItemId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.LookupListId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.IsInputRequired;
            parameters[3].Value = model.InputTitle;
            parameters[4].Value = model.AppendMoney;
            parameters[5].Value = model.CalculateMode;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.LookupItemId;

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
        public bool Delete(int LookupItemId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderLookupItems ");
            strSql.Append(" where LookupItemId=?LookupItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupItemId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LookupItemId;

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
        public bool DeleteList(string LookupItemIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderLookupItems ");
            strSql.Append(" where LookupItemId in (" + LookupItemIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Order.OrderLookupItems GetModel(int LookupItemId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  LookupItemId,LookupListId,Name,IsInputRequired,InputTitle,AppendMoney,CalculateMode,Remark from Shop_OrderLookupItems ");
            strSql.Append(" where LookupItemId=?LookupItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?LookupItemId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = LookupItemId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Order.OrderLookupItems model = new YSWL.MALL.Model.Shop.Order.OrderLookupItems();
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
        public YSWL.MALL.Model.Shop.Order.OrderLookupItems DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Order.OrderLookupItems model = new YSWL.MALL.Model.Shop.Order.OrderLookupItems();
            if (row != null)
            {
                if (row["LookupItemId"] != null && row["LookupItemId"].ToString() != "")
                {
                    model.LookupItemId = int.Parse(row["LookupItemId"].ToString());
                }
                if (row["LookupListId"] != null && row["LookupListId"].ToString() != "")
                {
                    model.LookupListId = int.Parse(row["LookupListId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["IsInputRequired"] != null && row["IsInputRequired"].ToString() != "")
                {
                    if ((row["IsInputRequired"].ToString() == "1") || (row["IsInputRequired"].ToString().ToLower() == "true"))
                    {
                        model.IsInputRequired = true;
                    }
                    else
                    {
                        model.IsInputRequired = false;
                    }
                }
                if (row["InputTitle"] != null)
                {
                    model.InputTitle = row["InputTitle"].ToString();
                }
                if (row["AppendMoney"] != null && row["AppendMoney"].ToString() != "")
                {
                    model.AppendMoney = decimal.Parse(row["AppendMoney"].ToString());
                }
                if (row["CalculateMode"] != null && row["CalculateMode"].ToString() != "")
                {
                    model.CalculateMode = int.Parse(row["CalculateMode"].ToString());
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
            strSql.Append("select LookupItemId,LookupListId,Name,IsInputRequired,InputTitle,AppendMoney,CalculateMode,Remark ");
            strSql.Append(" FROM Shop_OrderLookupItems ");
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
            
            strSql.Append(" LookupItemId,LookupListId,Name,IsInputRequired,InputTitle,AppendMoney,CalculateMode,Remark ");
            strSql.Append(" FROM Shop_OrderLookupItems ");
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
            strSql.Append("select count(1) FROM Shop_OrderLookupItems ");
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
            strSql.Append("SELECT T.* from Shop_OrderLookupItems T ");
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
                strSql.Append(" order by T.LookupItemId desc");
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
            parameters[0].Value = "Shop_OrderLookupItems";
            parameters[1].Value = "LookupItemId";
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

