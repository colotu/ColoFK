/**  版本信息模板在安装目录下，可自行修改。
* SuppDistProduct.cs
*
* 功 能： N/A
* 类 名： SuppDistProduct
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/27 17:36:25   N/A    初版
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
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Distribution
{
    /// <summary>
    /// 数据访问类:SuppDistProduct
    /// </summary>
    public partial class SuppDistProduct : ISuppDistProduct
    {
        public SuppDistProduct()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int supplierId, long ProductId)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from " + TableName);
                strSql.Append(" where ProductId=?ProductId ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
                parameters[0].Value = ProductId;

                return DbHelperMySQL.Exists(strSql.ToString(), parameters);
            }
            return false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(int supplierId, YSWL.MALL.Model.Shop.Distribution.SuppDistProduct model)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            CreateTab(supplierId);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + TableName + " (");
            strSql.Append("ProductId,TypeId,BrandId,ProductName,SaleStatus,AddedDate,SaleCounts,MarketPrice,Stock,LowestSalePrice,HasSKU,DisplaySequence,ImageUrl,ThumbnailUrl1)");
            strSql.Append(" values (");
            strSql.Append("?ProductId,?TypeId,?BrandId,?ProductName,?SaleStatus,?AddedDate,?SaleCounts,?MarketPrice,?Stock,?LowestSalePrice,?HasSKU,?DisplaySequence,?ImageUrl,?ThumbnailUrl1)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?SaleStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?AddedDate", MySqlDbType.DateTime),
					new MySqlParameter("?SaleCounts", MySqlDbType.Int32,4),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?HasSKU", MySqlDbType.Bit,1),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.BrandId;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.SaleStatus;
            parameters[5].Value = model.AddedDate;
            parameters[6].Value = model.SaleCounts;
            parameters[7].Value = model.MarketPrice;
            parameters[8].Value = model.Stock;
            parameters[9].Value = model.LowestSalePrice;
            parameters[10].Value = model.HasSKU;
            parameters[11].Value = model.DisplaySequence;
            parameters[12].Value = model.ImageUrl;
            parameters[13].Value = model.ThumbnailUrl1;

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
        public bool Update(int supplierId, YSWL.MALL.Model.Shop.Distribution.SuppDistProduct model)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update " + TableName + " set ");
                strSql.Append("TypeId=?TypeId,");
                strSql.Append("BrandId=?BrandId,");
                strSql.Append("ProductName=?ProductName,");
                strSql.Append("SaleStatus=?SaleStatus,");
                strSql.Append("AddedDate=?AddedDate,");
                strSql.Append("SaleCounts=?SaleCounts,");
                strSql.Append("MarketPrice=?MarketPrice,");
                strSql.Append("Stock=?Stock,");
                strSql.Append("LowestSalePrice=?LowestSalePrice,");
                strSql.Append("HasSKU=?HasSKU,");
                strSql.Append("DisplaySequence=?DisplaySequence,");
                strSql.Append("ImageUrl=?ImageUrl,");
                strSql.Append("ThumbnailUrl1=?ThumbnailUrl1");
                strSql.Append(" where ProductId=?ProductId ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
					new MySqlParameter("?SaleStatus", MySqlDbType.Int32,4),
					new MySqlParameter("?AddedDate", MySqlDbType.DateTime),
					new MySqlParameter("?SaleCounts", MySqlDbType.Int32,4),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?HasSKU", MySqlDbType.Bit,1),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar,255),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
                parameters[0].Value = model.TypeId;
                parameters[1].Value = model.BrandId;
                parameters[2].Value = model.ProductName;
                parameters[3].Value = model.SaleStatus;
                parameters[4].Value = model.AddedDate;
                parameters[5].Value = model.SaleCounts;
                parameters[6].Value = model.MarketPrice;
                parameters[7].Value = model.Stock;
                parameters[8].Value = model.LowestSalePrice;
                parameters[9].Value = model.HasSKU;
                parameters[10].Value = model.DisplaySequence;
                parameters[11].Value = model.ImageUrl;
                parameters[12].Value = model.ThumbnailUrl1;
                parameters[13].Value = model.ProductId;

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
        public bool Delete(int supplierId, long ProductId)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from  " + TableName);
                strSql.Append(" where ProductId=?ProductId ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
                parameters[0].Value = ProductId;

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
        public bool DeleteList(int supplierId, string ProductIdlist)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from  " + TableName);
                strSql.Append(" where ProductId in (" + ProductIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Distribution.SuppDistProduct GetModel(int supplierId, long ProductId)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ProductId,TypeId,BrandId,ProductName,SaleStatus,AddedDate,SaleCounts,MarketPrice,Stock,LowestSalePrice,HasSKU,DisplaySequence,ImageUrl,ThumbnailUrl1 from  " + TableName);
                strSql.Append(" where ProductId=?ProductId ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
                parameters[0].Value = ProductId;
                strSql.Append(" LIMIT 1 ");
                YSWL.MALL.Model.Shop.Distribution.SuppDistProduct model = new YSWL.MALL.Model.Shop.Distribution.SuppDistProduct();
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
        public YSWL.MALL.Model.Shop.Distribution.SuppDistProduct DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Distribution.SuppDistProduct model = new YSWL.MALL.Model.Shop.Distribution.SuppDistProduct();
            if (row != null)
            {
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["TypeId"] != null && row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                if (row["BrandId"] != null && row["BrandId"].ToString() != "")
                {
                    model.BrandId = int.Parse(row["BrandId"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["SaleStatus"] != null && row["SaleStatus"].ToString() != "")
                {
                    model.SaleStatus = int.Parse(row["SaleStatus"].ToString());
                }
                if (row["AddedDate"] != null && row["AddedDate"].ToString() != "")
                {
                    model.AddedDate = DateTime.Parse(row["AddedDate"].ToString());
                }
                if (row["SaleCounts"] != null && row["SaleCounts"].ToString() != "")
                {
                    model.SaleCounts = int.Parse(row["SaleCounts"].ToString());
                }
                if (row["MarketPrice"] != null && row["MarketPrice"].ToString() != "")
                {
                    model.MarketPrice = decimal.Parse(row["MarketPrice"].ToString());
                }
                if (row["Stock"] != null && row["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(row["Stock"].ToString());
                }
                if (row["LowestSalePrice"] != null && row["LowestSalePrice"].ToString() != "")
                {
                    model.LowestSalePrice = decimal.Parse(row["LowestSalePrice"].ToString());
                }
                if (row["HasSKU"] != null && row["HasSKU"].ToString() != "")
                {
                    if ((row["HasSKU"].ToString() == "1") || (row["HasSKU"].ToString().ToLower() == "true"))
                    {
                        model.HasSKU = true;
                    }
                    else
                    {
                        model.HasSKU = false;
                    }
                }
                if (row["DisplaySequence"] != null && row["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(row["DisplaySequence"].ToString());
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["ThumbnailUrl1"] != null)
                {
                    model.ThumbnailUrl1 = row["ThumbnailUrl1"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int supplierId, string strWhere)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ProductId,TypeId,BrandId,ProductName,SaleStatus,AddedDate,SaleCounts,MarketPrice,Stock,LowestSalePrice,HasSKU,DisplaySequence,ImageUrl,ThumbnailUrl1 ");
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
            string TableName = "Shop_SuppDistProduct_" + supplierId;
            if (TabExists(supplierId))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ");
                
                strSql.Append(" ProductId,TypeId,BrandId,ProductName,SaleStatus,AddedDate,SaleCounts,MarketPrice,Stock,LowestSalePrice,HasSKU,DisplaySequence,ImageUrl,ThumbnailUrl1 ");
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
            string TableName = "Shop_SuppDistProduct_" + supplierId;
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
            string TableName = "Shop_SuppDistProduct_" + supplierId;
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
                    strSql.Append(" order by T.ProductId desc");
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
            parameters[0].Value = "Shop_SuppDistProduct";
            parameters[1].Value = "ProductId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool TabExists(int supplierId)
        {
            string TableName = "Shop_SuppDistProduct_" + supplierId;
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

        public void CreateTab(int supplierId)
        {
            if (!TabExists(supplierId))
            {
                string TableName = "Shop_SuppDistProduct_" + supplierId;
                StringBuilder strSql = new StringBuilder();
                strSql.Append("CREATE TABLE " + TableName + " (");
                strSql.Append("ProductId            bigint not null,");
                strSql.Append("TypeId               int,");
                strSql.Append("BrandId              int not null,");
                strSql.Append("ProductName          national varchar(200) not null,");
                strSql.Append("SaleStatus           int not null,");
                strSql.Append("AddedDate            datetime not null,");
                strSql.Append("SaleCounts           int not null default 0,");
                strSql.Append("MarketPrice          float(8,2),");
                strSql.Append("Stock                int not null,");
                strSql.Append("LowestSalePrice      float(8,2) not null,");
                strSql.Append("HasSKU               bool not null,");
                strSql.Append("DisplaySequence      int not null default 0,");
                strSql.Append("ImageUrl             national varchar(255),");
                strSql.Append("ThumbnailUrl1        national varchar(255),");
                strSql.Append("primary key (ProductId))");
                DbHelperMySQL.ExecuteSql(strSql.ToString());
            }
        }
        #endregion  ExtensionMethod
    }
}

