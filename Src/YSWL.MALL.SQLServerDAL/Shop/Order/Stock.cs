using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Order;

namespace YSWL.MALL.SQLServerDAL.Shop.Order
{
    public partial class Stock : IStock
    {
        public int GetWMSSalesStock(string sku, int depotId, int ownerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT SUM(UsableStock) UsableStock FROM  WMS_StockItem  ");
            strSql.Append("  WHERE SKU=@SKU AND DepotId=@DepotId AND StoreType<=2 AND ShelfProStatus=1 and OwnerId=@OwnerId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SKU", SqlDbType.NVarChar,50),
                        new SqlParameter("@DepotId", SqlDbType.Int),
                            new SqlParameter("@OwnerId", SqlDbType.Int)

            };
            parameters[0].Value = sku;
            parameters[1].Value = depotId;
            parameters[2].Value = ownerId;

            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        public int GetERPSalesStock(string sku, int depotId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UsableStock FROM ERP_Stock ");
            strSql.Append(" where  SKU=@SKU and DepotId=@DepotId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SKU", SqlDbType.NVarChar,50),
                        new SqlParameter("@DepotId", SqlDbType.Int)

            };
            parameters[0].Value = sku;
            parameters[1].Value = depotId;

            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
