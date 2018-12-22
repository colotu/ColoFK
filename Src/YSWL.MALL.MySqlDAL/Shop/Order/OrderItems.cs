using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Order;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
using YSWL.MALL.Model.Shop.Order;

namespace YSWL.MALL.MySqlDAL.Shop.Order
{
	/// <summary>
	/// 数据访问类:OrderItem
	/// </summary>
	public partial class OrderItems:IOrderItems
	{
		public OrderItems()
		{}
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ItemId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_OrderItems");
            strSql.Append(" where ItemId=?ItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ItemId", MySqlDbType.Int64)
			};
            parameters[0].Value = ItemId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Order.OrderItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_OrderItems(");
            strSql.Append("OrderId,OrderCode,ProductId,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,ShipmentQuantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName,BrandId,BrandName)");
            strSql.Append(" values (");
            strSql.Append("?OrderId,?OrderCode,?ProductId,?ProductCode,?SKU,?Name,?ThumbnailsUrl,?Description,?Quantity,?ShipmentQuantity,?CostPrice,?SellPrice,?AdjustedPrice,?Attribute,?Remark,?Weight,?Deduct,?Points,?ProductLineId,?SupplierId,?SupplierName,?BrandId,?BrandName)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,200),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipmentQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SellPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?AdjustedPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Attribute", MySqlDbType.Text),
					new MySqlParameter("?Remark", MySqlDbType.Text),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?Deduct", MySqlDbType.Decimal,8),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductLineId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,100),
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4),
					new MySqlParameter("?BrandName", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.ProductId;
            parameters[3].Value = model.ProductCode;
            parameters[4].Value = model.SKU;
            parameters[5].Value = model.Name;
            parameters[6].Value = model.ThumbnailsUrl;
            parameters[7].Value = model.Description;
            parameters[8].Value = model.Quantity;
            parameters[9].Value = model.ShipmentQuantity;
            parameters[10].Value = model.CostPrice;
            parameters[11].Value = model.SellPrice;
            parameters[12].Value = model.AdjustedPrice;
            parameters[13].Value = model.Attribute;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.Weight;
            parameters[16].Value = model.Deduct;
            parameters[17].Value = model.Points;
            parameters[18].Value = model.ProductLineId;
            parameters[19].Value = model.SupplierId;
            parameters[20].Value = model.SupplierName;
            parameters[21].Value = model.BrandId;
            parameters[22].Value = model.BrandName;

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
        public bool Update(YSWL.MALL.Model.Shop.Order.OrderItems model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_OrderItems set ");
            strSql.Append("OrderId=?OrderId,");
            strSql.Append("OrderCode=?OrderCode,");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("ProductCode=?ProductCode,");
            strSql.Append("SKU=?SKU,");
            strSql.Append("Name=?Name,");
            strSql.Append("ThumbnailsUrl=?ThumbnailsUrl,");
            strSql.Append("Description=?Description,");
            strSql.Append("Quantity=?Quantity,");
            strSql.Append("ShipmentQuantity=?ShipmentQuantity,");
            strSql.Append("CostPrice=?CostPrice,");
            strSql.Append("SellPrice=?SellPrice,");
            strSql.Append("AdjustedPrice=?AdjustedPrice,");
            strSql.Append("Attribute=?Attribute,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("Deduct=?Deduct,");
            strSql.Append("Points=?Points,");
            strSql.Append("ProductLineId=?ProductLineId,");
            strSql.Append("SupplierId=?SupplierId,");
            strSql.Append("SupplierName=?SupplierName,");
            strSql.Append("BrandId=?BrandId,");
            strSql.Append("BrandName=?BrandName");
            strSql.Append(" where ItemId=?ItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?OrderCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,200),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?ShipmentQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SellPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?AdjustedPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Attribute", MySqlDbType.Text),
					new MySqlParameter("?Remark", MySqlDbType.Text),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?Deduct", MySqlDbType.Decimal,8),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductLineId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,100),
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4),
					new MySqlParameter("?BrandName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ItemId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderCode;
            parameters[2].Value = model.ProductId;
            parameters[3].Value = model.ProductCode;
            parameters[4].Value = model.SKU;
            parameters[5].Value = model.Name;
            parameters[6].Value = model.ThumbnailsUrl;
            parameters[7].Value = model.Description;
            parameters[8].Value = model.Quantity;
            parameters[9].Value = model.ShipmentQuantity;
            parameters[10].Value = model.CostPrice;
            parameters[11].Value = model.SellPrice;
            parameters[12].Value = model.AdjustedPrice;
            parameters[13].Value = model.Attribute;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.Weight;
            parameters[16].Value = model.Deduct;
            parameters[17].Value = model.Points;
            parameters[18].Value = model.ProductLineId;
            parameters[19].Value = model.SupplierId;
            parameters[20].Value = model.SupplierName;
            parameters[21].Value = model.BrandId;
            parameters[22].Value = model.BrandName;
            parameters[23].Value = model.ItemId;

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
        public bool Delete(long ItemId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderItems ");
            strSql.Append(" where ItemId=?ItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ItemId", MySqlDbType.Int64)
			};
            parameters[0].Value = ItemId;

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
        public bool DeleteList(string ItemIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_OrderItems ");
            strSql.Append(" where ItemId in (" + ItemIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Order.OrderItems GetModel(long ItemId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ItemId,OrderId,OrderCode,ProductId,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,ShipmentQuantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName,BrandId,BrandName from Shop_OrderItems ");
            strSql.Append(" where ItemId=?ItemId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ItemId", MySqlDbType.Int64)
			};
            parameters[0].Value = ItemId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Order.OrderItems model = new YSWL.MALL.Model.Shop.Order.OrderItems();
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
        public YSWL.MALL.Model.Shop.Order.OrderItems DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Order.OrderItems model = new YSWL.MALL.Model.Shop.Order.OrderItems();
            if (row != null)
            {
                if (row["ItemId"] != null && row["ItemId"].ToString() != "")
                {
                    model.ItemId = long.Parse(row["ItemId"].ToString());
                }
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = long.Parse(row["OrderId"].ToString());
                }
                if (row["OrderCode"] != null)
                {
                    model.OrderCode = row["OrderCode"].ToString();
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["ProductCode"] != null)
                {
                    model.ProductCode = row["ProductCode"].ToString();
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["ThumbnailsUrl"] != null)
                {
                    model.ThumbnailsUrl = row["ThumbnailsUrl"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Quantity"] != null && row["Quantity"].ToString() != "")
                {
                    model.Quantity = int.Parse(row["Quantity"].ToString());
                }
                if (row["ShipmentQuantity"] != null && row["ShipmentQuantity"].ToString() != "")
                {
                    model.ShipmentQuantity = int.Parse(row["ShipmentQuantity"].ToString());
                }
                if (row["CostPrice"] != null && row["CostPrice"].ToString() != "")
                {
                    model.CostPrice = decimal.Parse(row["CostPrice"].ToString());
                }
                if (row["SellPrice"] != null && row["SellPrice"].ToString() != "")
                {
                    model.SellPrice = decimal.Parse(row["SellPrice"].ToString());
                }
                if (row["AdjustedPrice"] != null && row["AdjustedPrice"].ToString() != "")
                {
                    model.AdjustedPrice = decimal.Parse(row["AdjustedPrice"].ToString());
                }
                if (row["Attribute"] != null)
                {
                    model.Attribute = row["Attribute"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Weight"] != null && row["Weight"].ToString() != "")
                {
                    model.Weight = int.Parse(row["Weight"].ToString());
                }
                if (row["Deduct"] != null && row["Deduct"].ToString() != "")
                {
                    model.Deduct = decimal.Parse(row["Deduct"].ToString());
                }
                if (row["Points"] != null && row["Points"].ToString() != "")
                {
                    model.Points = int.Parse(row["Points"].ToString());
                }
                if (row["ProductLineId"] != null && row["ProductLineId"].ToString() != "")
                {
                    model.ProductLineId = int.Parse(row["ProductLineId"].ToString());
                }
                if (row["SupplierId"] != null && row["SupplierId"].ToString() != "")
                {
                    model.SupplierId = int.Parse(row["SupplierId"].ToString());
                }
                if (row["SupplierName"] != null)
                {
                    model.SupplierName = row["SupplierName"].ToString();
                }
                if (row["BrandId"] != null && row["BrandId"].ToString() != "")
                {
                    model.BrandId = int.Parse(row["BrandId"].ToString());
                }
                if (row["BrandName"] != null)
                {
                    model.BrandName = row["BrandName"].ToString();
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
            strSql.Append("select ItemId,OrderId,OrderCode,ProductId,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,ShipmentQuantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName,BrandId,BrandName ");
            strSql.Append(" FROM Shop_OrderItems ");
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
            
            strSql.Append(" ItemId,OrderId,OrderCode,ProductId,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,ShipmentQuantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName,BrandId,BrandName ");
            strSql.Append(" FROM Shop_OrderItems ");
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
            strSql.Append("select count(1) FROM Shop_OrderItems ");
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
            strSql.Append("SELECT T.* from Shop_OrderItems T ");
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
                strSql.Append(" order by T.ItemId desc");
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
            parameters[0].Value = "Shop_OrderItems";
            parameters[1].Value = "ItemId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
		#region  ExtensionMethod

	    public  DataSet GetSaleRecordByPage(long  productId ,string  orderby , int startIndex ,int endIndex )
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.SellPrice , T.ShipmentQuantity , p.BuyerName ,p.CreatedDate  from Shop_OrderItems T ");
            strSql.AppendFormat(" JOIN Shop_Orders p ON T.ProductId = {0} AND p.OrderStatus = 2  and  T.OrderId=p.OrderId", productId);
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.ItemId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
	    }


	    public int GetSaleRecordCount(long productId)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT COUNT(1) FROM Shop_OrderItems tt JOIN    Shop_Orders p");
	        strSql.AppendFormat(" ON tt.ProductId={0} AND p.OrderStatus=2 AND tt.OrderId=p.OrderId", productId);
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


        public DataSet GetCommission(decimal DErate, decimal CPrate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
                @"
--设计师 总量/额
SELECT  1 AS Type, SUM(I.Quantity) ToalQuantity
      , SUM(I.SellPrice * I.Quantity) * {0} ToalPrice
FROM    Shop_OrderItems I, Shop_Orders O,Accounts_Users U,Shop_Products P
WHERE I.OrderId = O.OrderId
  AND P.ProductId=I.ProductId AND P.CreateUserID=U.UserID AND U.UserType = 'DE'
AND O.OrderStatus = 2 AND O.OrderType = 1
UNION ALL      
--CP 总量/额         
SELECT  2 AS Type, SUM(I.Quantity) ToalQuantity
      , SUM(I.SellPrice * I.Quantity) * {1} ToalPrice
FROM    Shop_OrderItems I, Shop_Orders O,Accounts_Users U,Shop_Products P
WHERE I.OrderId = O.OrderId
 AND P.ProductId=I.ProductId AND P.CreateUserID=U.UserID AND U.UserType = 'CP'
AND O.OrderStatus = 2 AND O.OrderType = 1

", DErate, CPrate);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        bool IOrderItems.Exists(long ItemId)
        {
            throw new NotImplementedException();
        }

        long IOrderItems.Add(Model.Shop.Order.OrderItems model)
        {
            throw new NotImplementedException();
        }

        bool IOrderItems.Update(Model.Shop.Order.OrderItems model)
        {
            throw new NotImplementedException();
        }

        bool IOrderItems.Delete(long ItemId)
        {
            throw new NotImplementedException();
        }

        bool IOrderItems.DeleteList(string ItemIdlist)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Order.OrderItems IOrderItems.GetModel(long ItemId)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Order.OrderItems IOrderItems.DataRowToModel(DataRow row)
        {
            throw new NotImplementedException();
        }

        DataSet IOrderItems.GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IOrderItems.GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        int IOrderItems.GetRecordCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        int IOrderItems.GetRecordSum(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IOrderItems.GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        DataSet IOrderItems.GetSaleRecordByPage(long productId, string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        int IOrderItems.GetSaleRecordCount(long productId)
        {
            throw new NotImplementedException();
        }

        DataSet IOrderItems.GetCommission(decimal DErate, decimal CPrate)
        {
            throw new NotImplementedException();
        }
        #endregion  ExtensionMethod
    }
}

