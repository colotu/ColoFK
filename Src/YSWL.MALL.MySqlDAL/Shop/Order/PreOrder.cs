/**  版本信息模板在安装目录下，可自行修改。
* PreOrder.cs
*
* 功 能： N/A
* 类 名： PreOrder
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/30 12:02:11   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using YSWL.MALL.IDAL.Shop;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.PrePro;
using MySql.Data.MySqlClient;//Please add references
namespace YSWL.MALL.MySqlDAL.Shop.Order
{
    /// <summary>
    /// 数据访问类:PreOrder
    /// </summary>
    public partial class PreOrder : IPreOrder
    {
        public PreOrder()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("PreOrderId", "Shop_PreOrder");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long PreOrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_PreOrder");
            strSql.Append(" where PreOrderId=?PreOrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PreOrderId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PreOrderId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.PrePro.PreOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_PreOrder(");
            strSql.Append("ProductId,ProductName,Count,SKU,Phone,UserId,UserName,CreatedDate,HandleUserId,HandleDate,DeliveryTip,Status,Remark)");
            strSql.Append(" values (");
            strSql.Append("?ProductId,?ProductName,?Count,?SKU,?Phone,?UserId,?UserName,?CreatedDate,?HandleUserId,?HandleDate,?DeliveryTip,?Status,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Count", MySqlDbType.Int32,4),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?HandleUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?HandleDate", MySqlDbType.DateTime),
					new MySqlParameter("?DeliveryTip", MySqlDbType.VarChar,100),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.Count;
            parameters[3].Value = model.SKU;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.UserId;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.CreatedDate;
            parameters[8].Value = model.HandleUserId;
            parameters[9].Value = model.HandleDate;
            parameters[10].Value = model.DeliveryTip;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.Remark;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Common.Globals.SafeLong(obj, 0);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.PrePro.PreOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_PreOrder set ");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("ProductName=?ProductName,");
            strSql.Append("Count=?Count,");
            strSql.Append("SKU=?SKU,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("HandleUserId=?HandleUserId,");
            strSql.Append("HandleDate=?HandleDate,");
            strSql.Append("DeliveryTip=?DeliveryTip,");
            strSql.Append("Status=?Status,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where PreOrderId=?PreOrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Count", MySqlDbType.Int32,4),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?HandleUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?HandleDate", MySqlDbType.DateTime),
					new MySqlParameter("?DeliveryTip", MySqlDbType.VarChar,100),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500),
					new MySqlParameter("?PreOrderId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.Count;
            parameters[3].Value = model.SKU;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.UserId;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.CreatedDate;
            parameters[8].Value = model.HandleUserId;
            parameters[9].Value = model.HandleDate;
            parameters[10].Value = model.DeliveryTip;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.PreOrderId;

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
        public bool Delete(long PreOrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_PreOrder ");
            strSql.Append(" where PreOrderId=?PreOrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PreOrderId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PreOrderId;

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
        public bool DeleteList(string PreOrderIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_PreOrder ");
            strSql.Append(" where PreOrderId in (" + PreOrderIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.PrePro.PreOrder GetModel(long PreOrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PreOrderId,ProductId,ProductName,Count,SKU,Phone,UserId,UserName,CreatedDate,HandleUserId,HandleDate,DeliveryTip,Status,Remark from Shop_PreOrder ");
            strSql.Append(" where PreOrderId=?PreOrderId  LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PreOrderId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PreOrderId;

            YSWL.MALL.Model.Shop.PrePro.PreOrder model = new YSWL.MALL.Model.Shop.PrePro.PreOrder();
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
        public YSWL.MALL.Model.Shop.PrePro.PreOrder DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.PrePro.PreOrder model = new YSWL.MALL.Model.Shop.PrePro.PreOrder();
            if (row != null)
            {
                if (row["PreOrderId"] != null && row["PreOrderId"].ToString() != "")
                {
                    model.PreOrderId = int.Parse(row["PreOrderId"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Count"] != null && row["Count"].ToString() != "")
                {
                    model.Count = int.Parse(row["Count"].ToString());
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["HandleUserId"] != null && row["HandleUserId"].ToString() != "")
                {
                    model.HandleUserId = int.Parse(row["HandleUserId"].ToString());
                }
                if (row["HandleDate"] != null && row["HandleDate"].ToString() != "")
                {
                    model.HandleDate = DateTime.Parse(row["HandleDate"].ToString());
                }
                if (row["DeliveryTip"] != null)
                {
                    model.DeliveryTip = row["DeliveryTip"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
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
            strSql.Append("select PreOrderId,ProductId,ProductName,Count,SKU,Phone,UserId,UserName,CreatedDate,HandleUserId,HandleDate,DeliveryTip,Status,Remark ");
            strSql.Append(" FROM Shop_PreOrder ");
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
            strSql.Append(" PreOrderId,ProductId,ProductName,Count,SKU,Phone,UserId,UserName,CreatedDate,HandleUserId,HandleDate,DeliveryTip,Status,Remark ");
            strSql.Append(" FROM Shop_PreOrder ");
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
            strSql.Append("select count(1) FROM Shop_PreOrder ");
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
            strSql.Append("SELECT T.* from Shop_PreOrder T ");
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
                strSql.Append(" order by T.PreOrderId desc");
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
            parameters[0].Value = "Shop_PreOrder";
            parameters[1].Value = "PreOrderId";
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int userId, string sku, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_PreOrder  ");
            strSql.Append(" where SKU=?SKU and UserId=?UserId  and Status=?Status ");
            MySqlParameter[] parameters = {
                    	new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
                        new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                         new MySqlParameter("?Status", MySqlDbType.Int16,2)
			};
            parameters[0].Value = sku;
            parameters[1].Value = userId;
            parameters[2].Value = status;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.PrePro.PreOrder GetModel(int userId, string sku, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Shop_PreOrder ");
            strSql.Append(" where  SKU=?SKU and UserId=?UserId    and Status=?Status  LIMIT 1");
            MySqlParameter[] parameters = {
                    	new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
                        new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                             new MySqlParameter("?Status", MySqlDbType.Int16,2)
			};
            parameters[0].Value = sku;
            parameters[1].Value = userId;
            parameters[2].Value = status;
            YSWL.MALL.Model.Shop.PrePro.PreOrder model = new YSWL.MALL.Model.Shop.PrePro.PreOrder();
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
        /// 更新一条数据
        /// </summary>
        public bool Update(long PreOrderId, int count, string deliveryTip)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_PreOrder set ");
            strSql.Append("Count=Count+?Count,");
            strSql.Append("DeliveryTip=?DeliveryTip ");
            strSql.Append(" where PreOrderId=?PreOrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Count", MySqlDbType.Int32,4),	
				new MySqlParameter("?DeliveryTip", MySqlDbType.VarChar,100),
					new MySqlParameter("?PreOrderId", MySqlDbType.Int32,4)};
            parameters[0].Value = count;
            parameters[1].Value = deliveryTip;
            parameters[2].Value = PreOrderId;
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
        ///  更新状态 
        /// </summary>
        /// <param name="PreOrderId">Id</param>
        /// <param name="Status">状态</param>
        /// <param name="HandleUserId">处理人Id</param>
        /// <returns></returns>
        public bool UpdateStatus(long PreOrderId, int Status, int HandleUserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_PreOrder set ");
            strSql.Append("Status=?Status,");
            strSql.Append("HandleUserId=?HandleUserId,");
            strSql.Append("HandleDate=?HandleDate");
            strSql.Append(" where PreOrderId=?PreOrderId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?HandleUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?HandleDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?PreOrderId", MySqlDbType.Int32,4)};
            parameters[0].Value = HandleUserId;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = Status;
            parameters[3].Value = PreOrderId;
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
        ///  批量修改状态
        /// </summary>
        /// <param name="IDlist"></param>
        /// <param name="Status"></param>
        /// <param name="HandleUserId"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, int Status, int HandleUserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_PreOrder set ");
            strSql.Append("Status=?Status,");
            strSql.Append("HandleUserId=?HandleUserId,");
            strSql.Append("HandleDate=?HandleDate");
            strSql.Append(" where PreOrderId in(" + IDlist + ")  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?HandleUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?HandleDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Status", MySqlDbType.Int16,2)};
            parameters[0].Value = HandleUserId;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = Status;

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
        #endregion  ExtensionMethod
    }
}
