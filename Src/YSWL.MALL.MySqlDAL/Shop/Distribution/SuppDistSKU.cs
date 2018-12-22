/**  版本信息模板在安装目录下，可自行修改。
* SuppDistSKU.cs
*
* 功 能： N/A
* 类 名： SuppDistSKU
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/26 18:31:56   N/A    初版
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
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Distribution;
using YSWL.DBUtility;
using System.Collections.Generic;
using MySql.Data.MySqlClient;//Please add references
namespace YSWL.MALL.MySqlDAL.Shop.Distribution
{
    /// <summary>
    /// 数据访问类:SuppDistSKU
    /// </summary>
    public partial class SuppDistSKU : ISuppDistSKU
    {
        public SuppDistSKU()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int supplierId,string SKU)
        {
            if (TabExists(supplierId))
            {
                string TableName = "Shop_SuppDistSKU_" + supplierId;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from " + TableName);
                strSql.Append(" where SKU=?SKU ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)			};
                parameters[0].Value = SKU;

                return DbHelperMySQL.Exists(strSql.ToString(), parameters);
            }
            return false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(int supplierId,YSWL.MALL.Model.Shop.Distribution.SuppDistSKU model)
        {
            string TableName = "Shop_SuppDistSKU_" + supplierId;
            CreateTab(supplierId);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + TableName + "(");
            strSql.Append("SKU,ProductId,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling)");
            strSql.Append(" values (");
            strSql.Append("?SKU,?ProductId,?Weight,?Stock,?AlertStock,?CostPrice,?SalePrice,?Upselling)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?AlertStock", MySqlDbType.Int32,4),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Upselling", MySqlDbType.Bit,1)};
            parameters[0].Value = model.SKU;
            parameters[1].Value = model.ProductId;
            parameters[2].Value = model.Weight;
            parameters[3].Value = model.Stock;
            parameters[4].Value = model.AlertStock;
            parameters[5].Value = model.CostPrice;
            parameters[6].Value = model.SalePrice;
            parameters[7].Value = model.Upselling;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(int supplierId,YSWL.MALL.Model.Shop.Distribution.SuppDistSKU model)
        {
            if (TabExists(supplierId))
            {
                string TableName = "Shop_SuppDistSKU_" + supplierId;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update " + TableName + " set ");
                strSql.Append("ProductId=?ProductId,");
                strSql.Append("Weight=?Weight,");
                strSql.Append("Stock=?Stock,");
                strSql.Append("AlertStock=?AlertStock,");
                strSql.Append("CostPrice=?CostPrice,");
                strSql.Append("SalePrice=?SalePrice,");
                strSql.Append("Upselling=?Upselling");
                strSql.Append(" where SKU=?SKU ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?AlertStock", MySqlDbType.Int32,4),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Upselling", MySqlDbType.Bit,1),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)};
                parameters[0].Value = model.ProductId;
                parameters[1].Value = model.Weight;
                parameters[2].Value = model.Stock;
                parameters[3].Value = model.AlertStock;
                parameters[4].Value = model.CostPrice;
                parameters[5].Value = model.SalePrice;
                parameters[6].Value = model.Upselling;
                parameters[7].Value = model.SKU;

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
            return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int supplierId, string SKU)
        {
            if (TabExists(supplierId))
            {
                string TableName = "Shop_SuppDistSKU_" + supplierId;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from " + TableName);
                strSql.Append(" where SKU=?SKU ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)			};
                parameters[0].Value = SKU;

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
            return false;
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(int supplierId, string SKUlist)
        {
            if (TabExists(supplierId))
            {
                string TableName = "Shop_SuppDistSKU_" + supplierId;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from  " + TableName);
                strSql.Append(" where SKU in (" + SKUlist + ")  ");
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
            return false;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Distribution.SuppDistSKU GetModel(int supplierId, string SKU)
        {
            string TableName = "Shop_SuppDistSKU_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SKU,ProductId,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling from  " + TableName);
                strSql.Append(" where SKU=?SKU ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)			};
                parameters[0].Value = SKU;
                strSql.Append(" LIMIT 1 ");
                YSWL.MALL.Model.Shop.Distribution.SuppDistSKU model = new YSWL.MALL.Model.Shop.Distribution.SuppDistSKU();
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
            return null;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Distribution.SuppDistSKU DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Distribution.SuppDistSKU model = new YSWL.MALL.Model.Shop.Distribution.SuppDistSKU();
            if (row != null)
            {
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["Weight"] != null && row["Weight"].ToString() != "")
                {
                    model.Weight = int.Parse(row["Weight"].ToString());
                }
                if (row["Stock"] != null && row["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(row["Stock"].ToString());
                }
                if (row["AlertStock"] != null && row["AlertStock"].ToString() != "")
                {
                    model.AlertStock = int.Parse(row["AlertStock"].ToString());
                }
                if (row["CostPrice"] != null && row["CostPrice"].ToString() != "")
                {
                    model.CostPrice = decimal.Parse(row["CostPrice"].ToString());
                }
                if (row["SalePrice"] != null && row["SalePrice"].ToString() != "")
                {
                    model.SalePrice = decimal.Parse(row["SalePrice"].ToString());
                }
                if (row["Upselling"] != null && row["Upselling"].ToString() != "")
                {
                    if ((row["Upselling"].ToString() == "1") || (row["Upselling"].ToString().ToLower() == "true"))
                    {
                        model.Upselling = true;
                    }
                    else
                    {
                        model.Upselling = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int supplierId, string strWhere)
        {
            string TableName = "Shop_SuppDistSKU_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select SKU,ProductId,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling ");
                strSql.Append(" FROM  " + TableName);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return DbHelperMySQL.Query(strSql.ToString());
            }
            return null;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int supplierId, int Top, string strWhere, string filedOrder)
        {
              string TableName = "Shop_SuppDistSKU_" + supplierId;
              if (TabExists(supplierId))
              {
                  StringBuilder strSql = new StringBuilder();
                  strSql.Append("select ");
                  if (Top > 0)
                  {
                      strSql.Append(" top " + Top.ToString());
                  }
                  strSql.Append(" SKU,ProductId,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling ");
                  strSql.Append(" FROM  " + TableName);
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
              return null;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(int supplierId, string strWhere)
        {
               string TableName = "Shop_SuppDistSKU_" + supplierId;
               if (TabExists(supplierId))
               {
                   StringBuilder strSql = new StringBuilder();
                   strSql.Append("select count(1) FROM  " + TableName);
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
               return 0;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int supplierId, string strWhere, string orderby, int startIndex, int endIndex)
        {
            string TableName = "Shop_SuppDistSKU_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * from " + TableName + " T ");
                if (!string.IsNullOrEmpty(strWhere.Trim()))
                {
                    strSql.Append(" WHERE " + strWhere);
                }
                if (!string.IsNullOrEmpty(orderby.Trim()))
                {
                    strSql.Append(" order by T." + orderby);
                }
                else
                {
                    strSql.Append(" order by T.SKU desc");
                }
                strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
                return DbHelperMySQL.Query(strSql.ToString());
            }
            return null;
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
            parameters[0].Value = "Shop_SuppDistSKU";
            parameters[1].Value = "SKU";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool TabExists(int  supplierId)
        {
            string TableName = "Shop_SuppDistSKU_" + supplierId;
            string strsql = "SHOW TABLES LIKE '" + TableName + "'";
            object obj = DbHelperMySQL.GetSingle(strsql);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CreateTab(int  supplierId)
        {
            if (!TabExists(supplierId))
            {
                string TableName = "Shop_SuppDistSKU_" + supplierId;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("CREATE TABLE " + TableName + " (");
                strSql.Append(" SKU                  national varchar(50) not null,");
                strSql.Append(" ProductId            bigint not null,");
                strSql.Append(" Weight               int not null default 0,");
                strSql.Append(" Stock                int not null,");
                strSql.Append(" AlertStock           int not null,");
                strSql.Append(" CostPrice            float(8,2) not null default 0,");
                strSql.Append(" SalePrice            float(8,2) not null,");
                strSql.Append(" Upselling            bool not null,");
                strSql.Append(" primary key (SKU))");
                DbHelperMySQL.ExecuteSql(strSql.ToString());
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteEx(int supplierId, YSWL.MALL.Model.Shop.Distribution.SuppDistSKU SKUInfo)
        {
            if (TabExists(supplierId))
            {
                string TableName = "Shop_SuppDistSKU_" + supplierId;
                string ProductTable = "Shop_SuppDistProduct_" + supplierId;
                List<CommandInfo> sqllist = new List<CommandInfo>();
                CommandInfo cmd = new CommandInfo();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from " + TableName);
                strSql.Append(" where SKU=?SKU ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)			
                                            };
                parameters[0].Value = SKUInfo.SKU;
                cmd = new CommandInfo(strSql.ToString(), parameters);
                sqllist.Add(cmd);
                //更新 分销商库存
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update " + ProductTable + " set ");
                strSql2.Append("Stock=Stock-?Stock");
                strSql2.Append(" where ProductId=?ProductId ");
                MySqlParameter[] parameters2 = {
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
                parameters2[0].Value = SKUInfo.Stock;
                parameters2[1].Value = SKUInfo.ProductId;
                cmd = new CommandInfo(strSql2.ToString(), parameters2);
                sqllist.Add(cmd);

               //更新整个商品SKU库存
                StringBuilder strSql3 = new StringBuilder();
                strSql3.Append("UPDATE Shop_SKUs SET ");
                strSql3.Append("Stock=Stock+?Stock");
                strSql3.Append(" WHERE Sku=?SKU");
                MySqlParameter[] parameters3 = {
                    new MySqlParameter("?Stock", MySqlDbType.Int32,4),
                    new MySqlParameter("?SKU", MySqlDbType.VarChar,50)
                                             };
                parameters3[0].Value = SKUInfo.Stock;
                parameters3[1].Value = SKUInfo.SKU;
                cmd = new CommandInfo(strSql3.ToString(), parameters3);
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
            return false;
        }
        #endregion  ExtensionMethod
    }
}

