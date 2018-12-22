/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：Products.cs
// 文件功能描述：
//
// 创建标识： [Ben]  2012/06/11 20:36:27
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.MALL.Model.Shop.Products;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// 数据访问类:Products
    /// </summary>
    public partial class ProductInfo : IProductInfo
    {
        public ProductInfo()
        {
        }

        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Products");
            strSql.Append(" where ProductId=?ProductId");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64)
            };
            parameters[0].Value = ProductId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Products.ProductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_Products(");
            strSql.Append(
                "CategoryId,TypeId,BrandId,ProductName,ProductCode,SupplierId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,SaleStatus,AddedDate,VistiCounts,SaleCounts,Stock,DisplaySequence,LineId,MarketPrice,LowestSalePrice,PenetrationStatus,MainCategoryPath,ExtendCategoryPath,HasSKU,Points,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle,SalesType,RestrictionCount)");
            strSql.Append(" values (");
            strSql.Append(
                "?CategoryId,?TypeId,?BrandId,?ProductName,?ProductCode,?SupplierId,?RegionId,?ShortDescription,?Unit,?Description,?Meta_Title,?Meta_Description,?Meta_Keywords,?SaleStatus,?AddedDate,?VistiCounts,?SaleCounts,?Stock,?DisplaySequence,?LineId,?MarketPrice,?LowestSalePrice,?PenetrationStatus,?MainCategoryPath,?ExtendCategoryPath,?HasSKU,?Points,?ImageUrl,?ThumbnailUrl1,?ThumbnailUrl2,?ThumbnailUrl3,?ThumbnailUrl4,?ThumbnailUrl5,?ThumbnailUrl6,?ThumbnailUrl7,?ThumbnailUrl8,?MaxQuantity,?MinQuantity,?Tags,?SeoUrl,?SeoImageAlt,?SeoImageTitle,?SalesType,?RestrictionCount)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?CategoryId", MySqlDbType.Int32, 4),
                new MySqlParameter("?TypeId", MySqlDbType.Int32, 4),
                new MySqlParameter("?BrandId", MySqlDbType.Int32, 4),
                new MySqlParameter("?ProductName", MySqlDbType.VarChar, 200),
                new MySqlParameter("?ProductCode", MySqlDbType.VarChar, 50),
                new MySqlParameter("?SupplierId", MySqlDbType.Int32, 4),
                new MySqlParameter("?RegionId", MySqlDbType.Int32, 4),
                new MySqlParameter("?ShortDescription", MySqlDbType.VarChar, 2000),
                new MySqlParameter("?Unit", MySqlDbType.VarChar, 50),
                new MySqlParameter("?Description", MySqlDbType.Text),
                new MySqlParameter("?Meta_Title", MySqlDbType.VarChar, 100),
                new MySqlParameter("?Meta_Description", MySqlDbType.VarChar, 1000),
                new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar, 1000),
                new MySqlParameter("?SaleStatus", MySqlDbType.Int32, 4),
                new MySqlParameter("?AddedDate", MySqlDbType.DateTime),
                new MySqlParameter("?VistiCounts", MySqlDbType.Int32, 4),
                new MySqlParameter("?SaleCounts", MySqlDbType.Int32, 4),
                new MySqlParameter("?Stock", MySqlDbType.Int32, 4),
                new MySqlParameter("?DisplaySequence", MySqlDbType.Int32, 4),
                new MySqlParameter("?LineId", MySqlDbType.Int32, 4),
                new MySqlParameter("?MarketPrice", MySqlDbType.Decimal, 8),
                new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal, 8),
                new MySqlParameter("?PenetrationStatus", MySqlDbType.Int16, 2),
                new MySqlParameter("?MainCategoryPath", MySqlDbType.VarChar, 256),
                new MySqlParameter("?ExtendCategoryPath", MySqlDbType.VarChar, 256),
                new MySqlParameter("?HasSKU", MySqlDbType.Bit, 1),
                new MySqlParameter("?Points", MySqlDbType.Decimal, 9),
                new MySqlParameter("?ImageUrl", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl2", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl3", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl4", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl5", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl6", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl7", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl8", MySqlDbType.VarChar, 255),
                new MySqlParameter("?MaxQuantity", MySqlDbType.Int32, 4),
                new MySqlParameter("?MinQuantity", MySqlDbType.Int32, 4),
                new MySqlParameter("?Tags", MySqlDbType.VarChar, 50),
                new MySqlParameter("?SeoUrl", MySqlDbType.VarChar, 300),
                new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar, 300),
                new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar, 300),
                new MySqlParameter("?SalesType", MySqlDbType.Int16, 2),
                new MySqlParameter("?RestrictionCount", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.BrandId;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.ProductCode;
            parameters[5].Value = model.SupplierId;
            parameters[6].Value = model.RegionId;
            parameters[7].Value = model.ShortDescription;
            parameters[8].Value = model.Unit;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.Meta_Title;
            parameters[11].Value = model.Meta_Description;
            parameters[12].Value = model.Meta_Keywords;
            parameters[13].Value = model.SaleStatus;
            parameters[14].Value = model.AddedDate;
            parameters[15].Value = model.VistiCounts;
            parameters[16].Value = model.SaleCounts;
            parameters[17].Value = model.Stock;
            parameters[18].Value = model.DisplaySequence;
            parameters[19].Value = model.LineId;
            parameters[20].Value = model.MarketPrice;
            parameters[21].Value = model.LowestSalePrice;
            parameters[22].Value = model.PenetrationStatus;
            parameters[23].Value = model.MainCategoryPath;
            parameters[24].Value = model.ExtendCategoryPath;
            parameters[25].Value = model.HasSKU;
            parameters[26].Value = model.Points;
            parameters[27].Value = model.ImageUrl;
            parameters[28].Value = model.ThumbnailUrl1;
            parameters[29].Value = model.ThumbnailUrl2;
            parameters[30].Value = model.ThumbnailUrl3;
            parameters[31].Value = model.ThumbnailUrl4;
            parameters[32].Value = model.ThumbnailUrl5;
            parameters[33].Value = model.ThumbnailUrl6;
            parameters[34].Value = model.ThumbnailUrl7;
            parameters[35].Value = model.ThumbnailUrl8;
            parameters[36].Value = model.MaxQuantity;
            parameters[37].Value = model.MinQuantity;
            parameters[38].Value = model.Tags;
            parameters[39].Value = model.SeoUrl;
            parameters[40].Value = model.SeoImageAlt;
            parameters[41].Value = model.SeoImageTitle;
            parameters[42].Value = model.SalesType;
            parameters[43].Value = model.RestrictionCount;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.ProductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Products set ");
            strSql.Append("CategoryId=?CategoryId,");
            strSql.Append("TypeId=?TypeId,");
            strSql.Append("BrandId=?BrandId,");
            strSql.Append("ProductName=?ProductName,");
            strSql.Append("ProductCode=?ProductCode,");
            strSql.Append("SupplierId=?SupplierId,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("ShortDescription=?ShortDescription,");
            strSql.Append("Unit=?Unit,");
            strSql.Append("Description=?Description,");
            strSql.Append("Meta_Title=?Meta_Title,");
            strSql.Append("Meta_Description=?Meta_Description,");
            strSql.Append("Meta_Keywords=?Meta_Keywords,");
            strSql.Append("SaleStatus=?SaleStatus,");
            strSql.Append("AddedDate=?AddedDate,");
            strSql.Append("VistiCounts=?VistiCounts,");
            strSql.Append("SaleCounts=?SaleCounts,");
            strSql.Append("Stock=?Stock,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("LineId=?LineId,");
            strSql.Append("MarketPrice=?MarketPrice,");
            strSql.Append("LowestSalePrice=?LowestSalePrice,");
            strSql.Append("PenetrationStatus=?PenetrationStatus,");
            strSql.Append("MainCategoryPath=?MainCategoryPath,");
            strSql.Append("ExtendCategoryPath=?ExtendCategoryPath,");
            strSql.Append("HasSKU=?HasSKU,");
            strSql.Append("Points=?Points,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("ThumbnailUrl1=?ThumbnailUrl1,");
            strSql.Append("ThumbnailUrl2=?ThumbnailUrl2,");
            strSql.Append("ThumbnailUrl3=?ThumbnailUrl3,");
            strSql.Append("ThumbnailUrl4=?ThumbnailUrl4,");
            strSql.Append("ThumbnailUrl5=?ThumbnailUrl5,");
            strSql.Append("ThumbnailUrl6=?ThumbnailUrl6,");
            strSql.Append("ThumbnailUrl7=?ThumbnailUrl7,");
            strSql.Append("ThumbnailUrl8=?ThumbnailUrl8,");
            strSql.Append("MaxQuantity=?MaxQuantity,");
            strSql.Append("MinQuantity=?MinQuantity,");
            strSql.Append("Tags=?Tags,");
            strSql.Append("SeoUrl=?SeoUrl,");
            strSql.Append("SeoImageAlt=?SeoImageAlt,");
            strSql.Append("SeoImageTitle=?SeoImageTitle,");
            strSql.Append("SalesType=?SalesType,");
            strSql.Append("RestrictionCount=?RestrictionCount");
            strSql.Append(" where ProductId=?ProductId");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?CategoryId", MySqlDbType.Int32, 4),
                new MySqlParameter("?TypeId", MySqlDbType.Int32, 4),
                new MySqlParameter("?BrandId", MySqlDbType.Int32, 4),
                new MySqlParameter("?ProductName", MySqlDbType.VarChar, 200),
                new MySqlParameter("?ProductCode", MySqlDbType.VarChar, 50),
                new MySqlParameter("?SupplierId", MySqlDbType.Int32, 4),
                new MySqlParameter("?RegionId", MySqlDbType.Int32, 4),
                new MySqlParameter("?ShortDescription", MySqlDbType.VarChar, 2000),
                new MySqlParameter("?Unit", MySqlDbType.VarChar, 50),
                new MySqlParameter("?Description", MySqlDbType.Text),
                new MySqlParameter("?Meta_Title", MySqlDbType.VarChar, 100),
                new MySqlParameter("?Meta_Description", MySqlDbType.VarChar, 1000),
                new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar, 1000),
                new MySqlParameter("?SaleStatus", MySqlDbType.Int32, 4),
                new MySqlParameter("?AddedDate", MySqlDbType.DateTime),
                new MySqlParameter("?VistiCounts", MySqlDbType.Int32, 4),
                new MySqlParameter("?SaleCounts", MySqlDbType.Int32, 4),
                new MySqlParameter("?Stock", MySqlDbType.Int32, 4),
                new MySqlParameter("?DisplaySequence", MySqlDbType.Int32, 4),
                new MySqlParameter("?LineId", MySqlDbType.Int32, 4),
                new MySqlParameter("?MarketPrice", MySqlDbType.Decimal, 8),
                new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal, 8),
                new MySqlParameter("?PenetrationStatus", MySqlDbType.Int16, 2),
                new MySqlParameter("?MainCategoryPath", MySqlDbType.VarChar, 256),
                new MySqlParameter("?ExtendCategoryPath", MySqlDbType.VarChar, 256),
                new MySqlParameter("?HasSKU", MySqlDbType.Bit, 1),
                new MySqlParameter("?Points", MySqlDbType.Decimal, 9),
                new MySqlParameter("?ImageUrl", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl2", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl3", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl4", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl5", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl6", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl7", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl8", MySqlDbType.VarChar, 255),
                new MySqlParameter("?MaxQuantity", MySqlDbType.Int32, 4),
                new MySqlParameter("?MinQuantity", MySqlDbType.Int32, 4),
                new MySqlParameter("?Tags", MySqlDbType.VarChar, 50),
                new MySqlParameter("?SeoUrl", MySqlDbType.VarChar, 300),
                new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar, 300),
                new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar, 300),
                new MySqlParameter("?SalesType", MySqlDbType.Int16, 2),
                new MySqlParameter("?RestrictionCount", MySqlDbType.Int32, 4),
                new MySqlParameter("?ProductId", MySqlDbType.Int64, 8)
            };
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.BrandId;
            parameters[3].Value = model.ProductName;
            parameters[4].Value = model.ProductCode;
            parameters[5].Value = model.SupplierId;
            parameters[6].Value = model.RegionId;
            parameters[7].Value = model.ShortDescription;
            parameters[8].Value = model.Unit;
            parameters[9].Value = model.Description;
            parameters[10].Value = model.Meta_Title;
            parameters[11].Value = model.Meta_Description;
            parameters[12].Value = model.Meta_Keywords;
            parameters[13].Value = model.SaleStatus;
            parameters[14].Value = model.AddedDate;
            parameters[15].Value = model.VistiCounts;
            parameters[16].Value = model.SaleCounts;
            parameters[17].Value = model.Stock;
            parameters[18].Value = model.DisplaySequence;
            parameters[19].Value = model.LineId;
            parameters[20].Value = model.MarketPrice;
            parameters[21].Value = model.LowestSalePrice;
            parameters[22].Value = model.PenetrationStatus;
            parameters[23].Value = model.MainCategoryPath;
            parameters[24].Value = model.ExtendCategoryPath;
            parameters[25].Value = model.HasSKU;
            parameters[26].Value = model.Points;
            parameters[27].Value = model.ImageUrl;
            parameters[28].Value = model.ThumbnailUrl1;
            parameters[29].Value = model.ThumbnailUrl2;
            parameters[30].Value = model.ThumbnailUrl3;
            parameters[31].Value = model.ThumbnailUrl4;
            parameters[32].Value = model.ThumbnailUrl5;
            parameters[33].Value = model.ThumbnailUrl6;
            parameters[34].Value = model.ThumbnailUrl7;
            parameters[35].Value = model.ThumbnailUrl8;
            parameters[36].Value = model.MaxQuantity;
            parameters[37].Value = model.MinQuantity;
            parameters[38].Value = model.Tags;
            parameters[39].Value = model.SeoUrl;
            parameters[40].Value = model.SeoImageAlt;
            parameters[41].Value = model.SeoImageTitle;
            parameters[42].Value = model.SalesType;
            parameters[43].Value = model.RestrictionCount;
            parameters[44].Value = model.ProductId;

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
        public bool Delete(long ProductId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Products ");
            strSql.Append(" where ProductId=?ProductId");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64)
            };
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

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ProductIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Products ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Products.ProductInfo GetModel(long ProductId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "select  CategoryId,TypeId,ProductId,BrandId,ProductName,ProductCode,SupplierId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,SaleStatus,AddedDate,VistiCounts,SaleCounts,Stock,DisplaySequence,LineId,MarketPrice,LowestSalePrice,PenetrationStatus,MainCategoryPath,ExtendCategoryPath,HasSKU,Points,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle,SalesType,RestrictionCount from Shop_Products ");
            strSql.Append(" where ProductId=?ProductId");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64)
            };
            parameters[0].Value = ProductId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.ProductInfo model = new YSWL.MALL.Model.Shop.Products.ProductInfo();
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
        public YSWL.MALL.Model.Shop.Products.ProductInfo DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Products.ProductInfo model = new YSWL.MALL.Model.Shop.Products.ProductInfo();
            if (row != null)
            {
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(row["CategoryId"].ToString());
                }
                if (row["TypeId"] != null && row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["BrandId"] != null && row["BrandId"].ToString() != "")
                {
                    model.BrandId = int.Parse(row["BrandId"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["ProductCode"] != null)
                {
                    model.ProductCode = row["ProductCode"].ToString();
                }
                if (row["SupplierId"] != null && row["SupplierId"].ToString() != "")
                {
                    model.SupplierId = int.Parse(row["SupplierId"].ToString());
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["ShortDescription"] != null)
                {
                    model.ShortDescription = row["ShortDescription"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Meta_Title"] != null)
                {
                    model.Meta_Title = row["Meta_Title"].ToString();
                }
                if (row["Meta_Description"] != null)
                {
                    model.Meta_Description = row["Meta_Description"].ToString();
                }
                if (row["Meta_Keywords"] != null)
                {
                    model.Meta_Keywords = row["Meta_Keywords"].ToString();
                }
                if (row["SaleStatus"] != null && row["SaleStatus"].ToString() != "")
                {
                    model.SaleStatus = int.Parse(row["SaleStatus"].ToString());
                }
                if (row["AddedDate"] != null && row["AddedDate"].ToString() != "")
                {
                    model.AddedDate = DateTime.Parse(row["AddedDate"].ToString());
                }
                if (row["VistiCounts"] != null && row["VistiCounts"].ToString() != "")
                {
                    model.VistiCounts = int.Parse(row["VistiCounts"].ToString());
                }
                if (row["SaleCounts"] != null && row["SaleCounts"].ToString() != "")
                {
                    model.SaleCounts = int.Parse(row["SaleCounts"].ToString());
                }
                if (row["Stock"] != null && row["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(row["Stock"].ToString());
                }
                if (row["DisplaySequence"] != null && row["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(row["DisplaySequence"].ToString());
                }
                if (row["LineId"] != null && row["LineId"].ToString() != "")
                {
                    model.LineId = int.Parse(row["LineId"].ToString());
                }
                if (row["MarketPrice"] != null && row["MarketPrice"].ToString() != "")
                {
                    model.MarketPrice = decimal.Parse(row["MarketPrice"].ToString());
                }
                if (row["LowestSalePrice"] != null && row["LowestSalePrice"].ToString() != "")
                {
                    model.LowestSalePrice = decimal.Parse(row["LowestSalePrice"].ToString());
                }
                if (row["PenetrationStatus"] != null && row["PenetrationStatus"].ToString() != "")
                {
                    model.PenetrationStatus = int.Parse(row["PenetrationStatus"].ToString());
                }
                if (row["MainCategoryPath"] != null)
                {
                    model.MainCategoryPath = row["MainCategoryPath"].ToString();
                }
                if (row["ExtendCategoryPath"] != null)
                {
                    model.ExtendCategoryPath = row["ExtendCategoryPath"].ToString();
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
                if (row["Points"] != null && row["Points"].ToString() != "")
                {
                    model.Points = decimal.Parse(row["Points"].ToString());
                }
                if (row["ImageUrl"] != null)
                {
                    model.ImageUrl = row["ImageUrl"].ToString();
                }
                if (row["ThumbnailUrl1"] != null)
                {
                    model.ThumbnailUrl1 = row["ThumbnailUrl1"].ToString();
                }
                if (row["ThumbnailUrl2"] != null)
                {
                    model.ThumbnailUrl2 = row["ThumbnailUrl2"].ToString();
                }
                if (row["ThumbnailUrl3"] != null)
                {
                    model.ThumbnailUrl3 = row["ThumbnailUrl3"].ToString();
                }
                if (row["ThumbnailUrl4"] != null)
                {
                    model.ThumbnailUrl4 = row["ThumbnailUrl4"].ToString();
                }
                if (row["ThumbnailUrl5"] != null)
                {
                    model.ThumbnailUrl5 = row["ThumbnailUrl5"].ToString();
                }
                if (row["ThumbnailUrl6"] != null)
                {
                    model.ThumbnailUrl6 = row["ThumbnailUrl6"].ToString();
                }
                if (row["ThumbnailUrl7"] != null)
                {
                    model.ThumbnailUrl7 = row["ThumbnailUrl7"].ToString();
                }
                if (row["ThumbnailUrl8"] != null)
                {
                    model.ThumbnailUrl8 = row["ThumbnailUrl8"].ToString();
                }
                if (row["MaxQuantity"] != null && row["MaxQuantity"].ToString() != "")
                {
                    model.MaxQuantity = int.Parse(row["MaxQuantity"].ToString());
                }
                if (row["MinQuantity"] != null && row["MinQuantity"].ToString() != "")
                {
                    model.MinQuantity = int.Parse(row["MinQuantity"].ToString());
                }
                if (row["Tags"] != null)
                {
                    model.Tags = row["Tags"].ToString();
                }
                if (row["SeoUrl"] != null)
                {
                    model.SeoUrl = row["SeoUrl"].ToString();
                }
                if (row["SeoImageAlt"] != null)
                {
                    model.SeoImageAlt = row["SeoImageAlt"].ToString();
                }
                if (row["SeoImageTitle"] != null)
                {
                    model.SeoImageTitle = row["SeoImageTitle"].ToString();
                }
                if (row["SalesType"] != null && row["SalesType"].ToString() != "")
                {
                    model.SalesType = int.Parse(row["SalesType"].ToString());
                }
                if (row["RestrictionCount"] != null && row["RestrictionCount"].ToString() != "")
                {
                    model.RestrictionCount = int.Parse(row["RestrictionCount"].ToString());
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
            strSql.Append(
                "select CategoryId,TypeId,ProductId,BrandId,ProductName,ProductCode,SupplierId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,SaleStatus,AddedDate,VistiCounts,SaleCounts,Stock,DisplaySequence,LineId,MarketPrice,LowestSalePrice,PenetrationStatus,MainCategoryPath,ExtendCategoryPath,HasSKU,Points,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle,SalesType,RestrictionCount ");
            strSql.Append(" FROM Shop_Products ");
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

            strSql.Append(
                " CategoryId,TypeId,ProductId,BrandId,ProductName,ProductCode,SupplierId,RegionId,ShortDescription,Unit,Description,Meta_Title,Meta_Description,Meta_Keywords,SaleStatus,AddedDate,VistiCounts,SaleCounts,Stock,DisplaySequence,LineId,MarketPrice,LowestSalePrice,PenetrationStatus,MainCategoryPath,ExtendCategoryPath,HasSKU,Points,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle,SalesType,RestrictionCount ");
            strSql.Append(" FROM Shop_Products ");
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
            strSql.Append("select count(1) FROM Shop_Products ");
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
            strSql.Append("SELECT T.* from Shop_Products T ");
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
                strSql.Append(" order by T.ProductId desc");
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
            parameters[0].Value = "Shop_Products";
            parameters[1].Value = "ProductId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region NewMethod

        /// <summary>
        /// 批量处理状态
        /// </summary>
        /// <param name="IDlist"></param>
        /// <param name="strSetValue"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, string strSetValue)
        {
            if (string.IsNullOrWhiteSpace(IDlist))
            {
                return false;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Products set " + strSetValue);
            strSql.Append(" where ProductId in(" + IDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows == IDlist.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCategoryIdSaleStatus(string strWhere, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.AppendFormat(" FROM  {0} ", TableName);
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" ORDER BY AddedDate DESC  ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 商品导出数据列表
        /// </summary>
        public DataSet GetListByExport(int SaleStatus, string ProductName, int CategoryId, string SKU, int BrandId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT P.*,S.SKU FROM Shop_SKUs S LEFT JOIN Shop_Products P on P.ProductId=S.ProductId  ");
            strSql.Append(" WHERE ");

            strSql.Append(" SaleStatus =" + SaleStatus);
            if (!string.IsNullOrWhiteSpace(ProductName.Trim()))
            {
                strSql.AppendFormat(" and ProductName like '%{0}%' ", Common.InjectionFilter.SqlFilter(ProductName));
            }
            strSql.Append(" and CategoryId =" + CategoryId);
            if (!string.IsNullOrWhiteSpace(SKU.Trim()))
            {
                strSql.AppendFormat(" and SKU like '%{0}%' ", Common.InjectionFilter.SqlFilter(SKU));
            }
            strSql.Append(BrandId == -1 ? string.Empty : " and BrandId =" + BrandId);

            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion NewMethod



        public DataSet GetProductListByCategoryId(int? categoryId, string strWhere, string orderBy, int startIndex,
            int endIndex, int SupplierId,
            out int dataCount)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }

            StringBuilder sqlBase = new StringBuilder(" from " + TableName + " P ");
            sqlBase.Append(" WHERE EXISTS ( SELECT 1 FROM Shop_ProductCategories PC ");
            sqlBase.Append(" WHERE P.ProductId = PC.ProductId ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                sqlBase.Append(strWhere);
            }
            sqlBase.Append(" ) ");

            object obj = DbHelperMySQL.GetSingle("select count(1) " + sqlBase);
            dataCount = obj == null ? 0 : Convert.ToInt32(obj);

            if (dataCount == 0) return null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT P.* ");
            strSql.Append(sqlBase);
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                strSql.Append(" order by " + orderBy);
            }
            else
            {
                strSql.Append(" order by P.ProductId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetProductListByCategoryIdEx(int? categoryId, string strWhere, string orderBy, int startIndex,
            int endIndex, int SupplierId,
            out int dataCount)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder sqlBase =
                new StringBuilder(" from " + TableName + " P JOIN Shop_SKUs SKU  ON  P.ProductId=SKU.ProductId");
            sqlBase.Append(" WHERE EXISTS ( SELECT 1 FROM Shop_ProductCategories PC ");
            sqlBase.Append(" WHERE P.ProductId = PC.ProductId ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                sqlBase.Append(strWhere);
            }
            sqlBase.Append(" ) ");

            object obj = DbHelperMySQL.GetSingle("select count(1) " + sqlBase);
            dataCount = obj == null ? 0 : Convert.ToInt32(obj);

            if (dataCount == 0) return null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT P.* ,SKU.SalePrice");
            strSql.Append(sqlBase);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                strSql.Append(" order by " + orderBy);
            }
            else
            {
                strSql.Append(" order by P.ProductId desc");
            }

            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #region 存储过程 

#warning 存储过程 未对应分销
        public DataSet GetProductListInfo(string strWhere, string orderBy, int startIndex, int endIndex,
            out int dataCount, long productId)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("_SqlWhere", MySqlDbType.VarChar),
                new MySqlParameter("_OrderBy", MySqlDbType.VarChar),
                new MySqlParameter("_StartIndex", MySqlDbType.Int32),
                new MySqlParameter("_EndIndex", MySqlDbType.Int32),
                new MySqlParameter("_ProductId", MySqlDbType.Int64),
                new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = strWhere;
            parameters[1].Value = orderBy;
            parameters[2].Value = startIndex;
            parameters[3].Value = endIndex;
            parameters[5].Direction = ParameterDirection.ReturnValue;
            return DbHelperMySQL.RunProcedure("sp_Shop_ProductInfo_Get", parameters, "ds", out dataCount);
        }


        /// <summary>
        /// 商品推荐列表信息
        /// </summary>
        public DataSet GetProductCommendListInfo(string strWhere, string orderBy, int startIndex, int endIndex,
            out int dataCount, long productId, int modeType)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("_SqlWhere", MySqlDbType.VarChar),
                new MySqlParameter("_OrderBy", MySqlDbType.VarChar),
                new MySqlParameter("_StartIndex", MySqlDbType.Int32),
                new MySqlParameter("_EndIndex", MySqlDbType.Int32),
                new MySqlParameter("_ProductId", MySqlDbType.Int64),
                new MySqlParameter("_ModeType", MySqlDbType.Int32),
                new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = strWhere;
            parameters[1].Value = orderBy;
            parameters[2].Value = startIndex;
            parameters[3].Value = endIndex;
            parameters[4].Value = productId;
            parameters[5].Value = modeType;
            parameters[6].Direction = ParameterDirection.ReturnValue;
            return DbHelperMySQL.RunProcedure("sp_Shop_ProductStationModesInfo", parameters, "ds", out dataCount);
        }

        public DataSet GetProductInfo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "SELECT DISTINCT P.CategoryId, TypeId, P.ProductId, BrandId, ProductName, ProductCode, SupplierId, RegionId, ShortDescription, Unit,  Meta_Title, Meta_Description, Meta_Keywords, SaleStatus, AddedDate, VistiCounts, SaleCounts, P.DisplaySequence, LineId, MarketPrice, LowestSalePrice, PenetrationStatus, MainCategoryPath, ExtendCategoryPath, HasSKU, Points, ImageUrl, ThumbnailUrl1, ThumbnailUrl2, ThumbnailUrl3, ThumbnailUrl4, ThumbnailUrl5, ThumbnailUrl6, ThumbnailUrl7, ThumbnailUrl8, MaxQuantity, MinQuantity, Tags, SeoUrl, SeoImageAlt, SeoImageTitle,RestrictionCount ");
            strSql.Append("FROM Shop_Products P ");
            strSql.Append("LEFT JOIN (SELECT * FROM Shop_ProductCategories )PC ON P.ProductId = PC.ProductId ");
            strSql.Append("LEFT JOIN Shop_SKUs SKU ON PC.ProductId = SKU.ProductId ");
            strSql.Append("LEFT JOIN Shop_ProductStationModes PSM ON SKU.ProductId = PSM.ProductId ");
            strSql.Append("WHERE 1=1 ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append(strWhere);
            }
            strSql.Append("ORDER BY AddedDate DESC ");
            return DbHelperMySQL.Query((strSql.ToString()));
        }

        public DataSet DeleteProducts(string Ids, out int Result)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("_ProductIds ", MySqlDbType.VarChar),
                new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = Ids;
            parameters[1].Direction = ParameterDirection.ReturnValue;
            DataSet ds = DbHelperMySQL.RunProcedure("sp_Shop_DeleteProducts", parameters, "tb", out Result);
            if (Result == 1)
            {
                return ds;
            }
            return null;
        }

        #region 未分类商品重新设置分类

        //TODO:一次性给未分类的商品指定多个分类
        /// <summary>
        /// 未分类商品重新设置分类 
        /// </summary>
        /// <param name="productIds"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool ChangeProductsCategory(string productIds, int categoryId)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("_ProductIds ", MySqlDbType.VarChar),
                new MySqlParameter("_CategoryId ", MySqlDbType.Int32),
                new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = productIds;
            parameters[1].Value = categoryId;
            parameters[2].Direction = ParameterDirection.ReturnValue;
            int rows = 0;
            DbHelperMySQL.RunProcedure("sp_Shop_ChangeProductsCategory", parameters, "ds", out rows);
            return rows > 0;
        }

        #endregion

        public DataSet SearchProducts(int cateId, Model.Shop.Products.ProductSearch model)
        {
            MySqlParameter[] parameters =
            {
                new MySqlParameter("_CategoryId", MySqlDbType.Int32),
                new MySqlParameter("_BrandId", MySqlDbType.Int32),
                new MySqlParameter("_ValueStr1", MySqlDbType.Int32),
                new MySqlParameter("_ValueStr2", MySqlDbType.Int32),
                new MySqlParameter("_ValueStr3", MySqlDbType.Int32),
                new MySqlParameter("_ValueStr4", MySqlDbType.Int32),
                new MySqlParameter("_ValueStr5", MySqlDbType.Int32),
                new MySqlParameter("_ValueStr6", MySqlDbType.Int32)
            };
            parameters[0].Value = cateId;
            parameters[1].Value = model.Parameter1;
            parameters[2].Value = model.Parameter2;
            parameters[3].Value = model.Parameter3;
            parameters[4].Value = model.Parameter4;
            parameters[5].Value = model.Parameter5;
            parameters[6].Value = model.Parameter6;
            parameters[7].Value = model.Parameter7;
            return DbHelperMySQL.RunProcedure("sp_SearchProducts", parameters, "ds");
        }

        #endregion


        public DataSet GetProductListInfo(string strProductIds, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM     " + TableName);
            strSql.Append("WHERE   SaleStatus = 1  ");
            strSql.AppendFormat("AND ProductId  IN ({0}) ", strProductIds);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public string GetProductName(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ProductName  ");
            strSql.Append("FROM Shop_Products ");
            strSql.AppendFormat("WHERE ProductId={0} ", productId);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());

            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsBrands(int BrandId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM Shop_Products");
            strSql.Append(" WHERE BrandId=?BrandId");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?BrandId", MySqlDbType.Int64)
            };
            parameters[0].Value = BrandId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        #region 得到表的结构信息

        /// <summary>
        /// 得到表的结构
        /// </summary>
        /// <returns></returns>
        public DataSet GetTableSchema()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from( ");
            strSql.Append("SELECT  * FROM     ");
            strSql.Append("INFORMATION_SCHEMA.COLUMNS ");
            strSql.Append("WHERE   TABLE_Name ='Shop_Products' ");
            strSql.Append("  ) as t");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetTableSchemaEx()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  	u.name + '.' + t.name AS table, ");
            strSql.Append("            td.value AS table_desc, ");
            strSql.Append("    		c.name AS column, ");
            strSql.Append("    		cd.value AS column_desc ");
            strSql.Append("FROM    	sysobjects t ");
            strSql.Append("INNER JOIN  sysusers u ");
            strSql.Append("    ON		u.uid = t.uid AND t.name='Shop_Products' ");
            strSql.Append("LEFT OUTER JOIN sys.extended_properties td ");
            strSql.Append("    ON		td.major_id = t.id ");
            strSql.Append("    AND 	td.minor_id = 0 ");
            strSql.Append("    AND		td.name = 'MS_Description'  ");
            strSql.Append("INNER JOIN  syscolumns c ");
            strSql.Append("    ON		c.id = t.id ");
            strSql.Append("LEFT OUTER JOIN sys.extended_properties cd ");
            strSql.Append("    ON		cd.major_id = c.id ");
            strSql.Append("    AND		cd.minor_id = c.colid ");
            strSql.Append("    AND		cd.name = 'MS_Description'  ");
            strSql.Append("WHERE t.type = 'u' ");
            strSql.Append("ORDER BY    t.name, c.colorder     ");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetTableHead()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT CategoryId as 类别ID
      ,TypeId as 类型ID
      ,ProductId as 商品ID
      ,BrandId as 品牌Id
      ,ProductName as 名称
      ,ProductCode as 编码
      ,SupplierId as 供应商Id
      ,RegionId as 地区Id
      ,ShortDescription as 介绍
      ,Unit as 单位
      ,Description as 描述
      ,Meta_Title as SEO_Title
      ,Meta_Description  as SEO_Description
      ,Meta_Keywords  as SEO_KeyWord
      ,SaleStatus  as 状态
      ,AddedDate  as 添加日期
      ,VistiCounts  as 访问次数
      ,SaleCounts  as 售出总数
      ,Stock  as 商品库存 
      ,DisplaySequence  as 显示顺序
      ,LineId  as 生产线
      ,MarketPrice  as 市场价
      ,LowestSalePrice  as 最低价
      ,PenetrationStatus  as 铺货状态
      ,MainCategoryPath  as 分类路径
      ,ExtendCategoryPath  as 扩展路径
      ,HasSKU  as 是否有SKU
      ,Points  as 积分
      ,ImageUrl  as  图片路径
      ,ThumbnailUrl1  as  图片路径1
      ,ThumbnailUrl2  as 图片路径2
      ,ThumbnailUrl3  as 图片路径3
      ,ThumbnailUrl4  as 图片路径4
      ,ThumbnailUrl5  as 图片路径5
      ,ThumbnailUrl6  as 图片路径6
      ,ThumbnailUrl7  as 图片路径7
      ,ThumbnailUrl8  as 图片路径8
      ,MaxQuantity  as 最大购买量
      ,MinQuantity  as 最小购买量
      ,Tags  as 标签
      ,SeoUrl  as  Url地址优化规则
      ,SeoImageAlt  as 图片Alt信息
      ,SeoImageTitle  as 图片Title信息
  FROM Shop_Products LIMIT 0
");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string Ids, string DataField, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT " + DataField + " ");
            strSql.Append(" FROM  " + TableName);
            if (!string.IsNullOrWhiteSpace(Ids.Trim()))
            {
                strSql.Append(" WHERE ProductId in(" + Ids + ")");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 获得回收站数据
        /// </summary>
        public DataSet GetRecycleList(string where, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM     " + TableName);
            strSql.Append("WHERE   SaleStatus =2  ");

            if (!string.IsNullOrWhiteSpace(where))
            {
                strSql.Append(" and " + where);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 还原所有回收站商品
        /// </summary>
        /// <returns></returns>
        public bool RevertAll(int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update     " + TableName);
            strSql.Append(" set SaleStatus=0 ");
            strSql.Append(" WHERE   SaleStatus =2  ");
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

        public bool UpdateStatus(long productId, int SaleStatus, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + TableName + " set  SaleStatus=?SaleStatus");
            strSql.Append(" where ProductId =?ProductId ");

            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64),
                new MySqlParameter("?SaleStatus", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = productId;
            parameters[1].Value = SaleStatus;
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





#warning 此方法需要重新全部对应，需要更新所有的分销商城
        public bool UpdateProductName(long productId, string strSetValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Products set  ProductName=?ProductName");
            strSql.Append(" where ProductId =?ProductId ");

            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64),
                new MySqlParameter("?ProductName", MySqlDbType.VarChar)
            };
            parameters[0].Value = productId;
            parameters[1].Value = strSetValue;
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

        public long StockNum(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(Stock) Stock FROM Shop_SKUs ");
            strSql.Append("WHERE ProductId=?ProductId ");

            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64)
            };
            parameters[0].Value = productId;
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


        public bool UpdateMarketPrice(long productId, decimal price, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + TableName + " set  MarketPrice=?MarketPrice");
            strSql.Append(" where ProductId =?ProductId ");

            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64),
                new MySqlParameter("?MarketPrice", MySqlDbType.Decimal, 8)
            };
            parameters[0].Value = productId;
            parameters[1].Value = price;
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

        public bool UpdateLowestSalePrice(long productId, decimal price, int SupplierId)
        {

            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + TableName + " set  LowestSalePrice=?LowestSalePrice");
            strSql.Append(" where ProductId =?ProductId ");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64),
                new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal, 8)
            };
            parameters[0].Value = productId;
            parameters[1].Value = price;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);
            if (new SKUInfo().skuCount(productId) == 1)
            {
                //未开启sku和只有一个sku 的商品最低价同步到sku数据中
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append(" UPDATE  Shop_SKUs SET SalePrice=?SalePrice ");
                strSql2.Append(" where ProductId =?ProductId ");
                MySqlParameter[] parameters2 =
                {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64),
                    new MySqlParameter("?SalePrice", MySqlDbType.Decimal, 8)
                };
                parameters2[0].Value = productId;
                parameters2[1].Value = price;
                cmd = new CommandInfo(strSql2.ToString(), parameters2, EffentNextType.ExcuteEffectRows);
                sqllist.Add(cmd);
            }
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


        /// <summary>
        /// 获取推荐产品信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
#warning 字段对应
        public DataSet GetProductRecList(ProductRecType type, int categoryId, int top, int SupplierId)
        {
            StringBuilder strSql = new StringBuilder();
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            strSql.Append("SELECT  ");

            strSql.Append(
                " P.ProductId,P.ShortDescription,P.ProductName,p.ThumbnailUrl1,p.ThumbnailUrl2,P.ProductCode ,P.LowestSalePrice, P.Points FROM    " +
                TableName + " P ");
            if (categoryId > 0)
            {
                strSql.Append(" INNER JOIN  ");
                strSql.Append("(SELECT DISTINCT ProductId FROM Shop_ProductCategories ");
                strSql.Append("WHERE  ( CategoryPath LIKE CONCAT((SELECT Path FROM Shop_Categories ");
                strSql.AppendFormat(
                    "WHERE CategoryId={0}),'|%')) or  CategoryPath='{0}' )C ON P.ProductId = C.ProductId ", categoryId);
            }
            strSql.Append(" INNER JOIN Shop_ProductStationModes PSM ON P.ProductId = PSM.ProductId ");
            strSql.Append(" WHERE PSM.Type=?Type And P.SaleStatus=1 ");
            strSql.Append(" ORDER BY PSM.StationId DESC,P.DisplaySequence ASC ");
            if (top > 0)
            {
                strSql.AppendFormat(" LIMIT {0} ", top);
            }
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?Type", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = (int) type;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        public int GetProductRecCount(ProductRecType type, int categoryId, int SupplierId)
        {
            StringBuilder strSql = new StringBuilder();
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            strSql.Append("SELECT  ");
            strSql.Append(" count(*) FROM    " + TableName + " P ");
            if (categoryId > 0)
            {
                strSql.Append(" INNER JOIN  ");
                strSql.Append("(SELECT DISTINCT ProductId FROM Shop_ProductCategories ");
                strSql.Append("WHERE  ( CategoryPath LIKE CONCAT((SELECT Path FROM Shop_Categories ");
                strSql.AppendFormat(
                    "WHERE CategoryId={0}),'|%')) or  CategoryPath='{0}' )C ON P.ProductId = C.ProductId ", categoryId);
            }
            strSql.Append(" INNER JOIN Shop_ProductStationModes PSM ON P.ProductId = PSM.ProductId ");
            strSql.Append(" WHERE PSM.Type=?Type And P.SaleStatus=1 ");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?Type", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = (int) type;
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
        /// 摇摇
        /// </summary>
        /// <param name="type"></param>
        /// <param name="categoryId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
#warning 字段需要对应
        public DataSet GetProductRanListByRec(ProductRecType type, int categoryId, int top, int SupplierId)
        {
            StringBuilder strSql = new StringBuilder();
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            strSql.Append("SELECT  ");

            strSql.Append(
                " P.ProductId,P.ShortDescription,P.ProductName,p.ThumbnailUrl1,p.ThumbnailUrl2,P.ProductCode ,P.LowestSalePrice , P.MarketPrice FROM    " +
                TableName + " P ");
            if (categoryId > 0)
            {
                strSql.Append(" INNER JOIN  ");
                strSql.Append("(SELECT DISTINCT ProductId FROM Shop_ProductCategories ");
                strSql.Append("WHERE  ( CategoryPath LIKE CONCAT((SELECT Path FROM Shop_Categories ");
                strSql.AppendFormat(
                    "WHERE CategoryId={0}),'|%')) or  CategoryPath='{0}' )C ON P.ProductId = C.ProductId ", categoryId);
            }
            strSql.Append(" INNER JOIN Shop_ProductStationModes PSM ON P.ProductId = PSM.ProductId ");
            strSql.Append(" WHERE PSM.Type=?Type And P.SaleStatus=1 ");
            strSql.Append(" ORDER BY NewID(), PSM.StationId DESC,P.DisplaySequence ASC ");
            if (top > 0)
            {
                strSql.AppendFormat(" LIMIT {0} ", top);
            }
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?Type", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = (int) type;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取随机产品
        /// </summary>
        /// <param name="type"></param>
        /// <param name="categoryId"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public DataSet GetProductRanList(int top, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ");

            strSql.Append(" P.*,sku.SalePrice From " + TableName +
                          " P JOIN Shop_SKUs sku  ON p.ProductId=sku.ProductId  where SaleStatus=1 order By NewID()  ");
            if (top > 0)
            {
                strSql.AppendFormat(" LIMIT {0} ", top);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }


        public DataSet RelatedProductSource(long productId, int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");

            strSql.Append("P.* FROM Shop_Products P ");
            strSql.Append("INNER JOIN (SELECT RelatedId FROM Shop_RelatedProducts ");
            strSql.Append("WHERE ProductId=?ProductId)RP ON P.ProductId = RP.RelatedId AND p.SaleStatus=1  ");
            if (top > 0)
            {
                strSql.AppendFormat(" LIMIT {0} ", top);
            }
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int32, 8)
            };
            parameters[0].Value = productId;
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            ///如果没有相关的产品，则从同类商品中提取相关的商品
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("SELECT  P.* ");
            strSql1.Append("FROM    Shop_Products P ");
            strSql1.Append("WHERE P.SaleStatus=1 and  ProductId IN ( SELECT  ");

            strSql1.Append("  ProductId ");
            strSql1.Append("  FROM     Shop_ProductCategories ");
            strSql1.Append("  WHERE    CategoryId IN ( SELECT  CategoryId ");
            strSql1.Append("  FROM    Shop_ProductCategories ");
            strSql1.Append("  WHERE   ProductId = " + productId + " )  AND ProductId NOT IN ( " + productId + ") ) ");
            if (top > 0)
            {
                strSql1.Append(" LIMIT " + top);
            }
            else
            {
                strSql1.Append(" LIMIT 3 ");
            }
            return DbHelperMySQL.Query(strSql1.ToString());
        }

        /// <summary>
        /// 根据条件获取商品
        /// </summary>
        /// <param name="Cid"></param>
        /// <param name="BrandId"></param>
        /// <param name="attrValues"></param>
        /// <param name="priceRange"></param>
        /// <param name="mod"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetProductsListEx(int Cid, int BrandId, string attrValues, string priceRange,
            string mod, int startIndex, int endIndex, int SupplierId)
        {

            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from " + TableName + " T ");

            strSql.AppendFormat(" WHERE   SaleStatus = 1 ");
            //品牌查询
            if (BrandId > 0)
            {
                strSql.AppendFormat("   AND BrandId = {0}", BrandId);
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "    AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE     CategoryId = {0}  ) , '|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            //循环属性
            if (!String.IsNullOrWhiteSpace(attrValues))
            {
                var attrValue_arry = attrValues.Split('-');
                foreach (var attr in attrValue_arry)
                {
                    int valueId = Common.Globals.SafeInt(attr, 0);
                    if (valueId > 0)
                    {
                        strSql.AppendFormat(
                            "  AND EXISTS ( SELECT * FROM   Shop_ProductAttributes WHERE  ProductId = T.ProductId AND ValueId = {0} )",
                            valueId);
                    }
                }
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
            }

            if (!string.IsNullOrEmpty(mod.Trim()))
            {
                strSql.Append(" order by T." + mod);
            }
            else
            {
                strSql.Append(" order by T.ProductId desc");
            }

            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取商品数量
        /// </summary>
        /// <param name="Cid"></param>
        /// <param name="BrandId"></param>
        /// <param name="attrValues"></param>
        /// <param name="priceRange"></param>
        /// <param name="mod"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetProductsCountEx(int Cid, int BrandId, string attrValues, string priceRange, int SupplierId)
        {
            StringBuilder strSql = new StringBuilder();
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            strSql.Append("SELECT  count(1) from " + TableName + " T ");
            strSql.AppendFormat(" WHERE   SaleStatus = 1 ");
            //品牌查询
            if (BrandId > 0)
            {
                strSql.AppendFormat("   AND BrandId = {0}", BrandId);
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ) , '|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            //循环属性
            if (!String.IsNullOrWhiteSpace(attrValues))
            {
                var attrValue_arry = attrValues.Split('-');
                foreach (var attr in attrValue_arry)
                {
                    int valueId = Common.Globals.SafeInt(attr, 0);
                    if (valueId > 0)
                    {
                        strSql.AppendFormat(
                            "  AND EXISTS ( SELECT * FROM   Shop_ProductAttributes WHERE  ProductId = T.ProductId AND ValueId = {0} )",
                            valueId);
                    }
                }
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
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

        public int MaxSequence()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(DisplaySequence) AS DisplaySequence FROM Shop_Products");
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
        /// 根据类别地址 得到该类别下最大顺序值  兼容一个商品属于多个分类的情况 
        /// </summary>
        /// <param name="CategoryPath"></param>
        /// <returns></returns>
        public int MaxSequence(string CategoryPath) //TODO 如果存在不传参数CategoryPath的情况请另作考虑
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "SELECT  MAX(DisplaySequence)  AS DisplaySequenceDisplaySequence FROM Shop_ProductCategories  AS prodcate  ");
            strSql.Append(" LEFT JOIN   Shop_Products  AS  prod ON prodcate.ProductId=prod.ProductId  ");
            if (!string.IsNullOrWhiteSpace(CategoryPath))
            {
                strSql.Append(" WHERE  prodcate.CategoryPath in ( ?CategoryPath )"); //因为一个商品可能属于多个分类，所以使用in
            }
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?CategoryPath", MySqlDbType.VarChar)
            };
            parameters[0].Value = CategoryPath;
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

        #region 搜索商品数据

        /// <summary>
        /// 根据条件获取商品
        /// </summary>
        /// <param name="Cid"></param>
        /// <param name="BrandId"></param>
        /// <param name="attrValues"></param>
        /// <param name="priceRange"></param>
        /// <param name="mod"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSearchListEx(int Cid, int BrandId, string keyword, string priceRange,
            string mod, int startIndex, int endIndex, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from " + TableName + " T ");

            strSql.AppendFormat(" WHERE   SaleStatus = 1 ");
            //品牌查询
            if (BrandId > 0)
            {
                strSql.AppendFormat("   AND BrandId = {0}", BrandId);
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ) , '|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            //关键字搜索
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                strSql.AppendFormat(" AND (ProductName like '%{0}%' or ShortDescription like '%{0}%') ",
                    Common.InjectionFilter.SqlFilter(keyword));
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
            }

            if (!string.IsNullOrEmpty(mod.Trim()))
            {
                strSql.Append("order by T." + mod);
            }
            else
            {
                strSql.Append("order by T.ProductId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取商品数量
        /// </summary>
        /// <param name="Cid"></param>
        /// <param name="BrandId"></param>
        /// <param name="attrValues"></param>
        /// <param name="priceRange"></param>
        /// <param name="mod"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public int GetSearchCountEx(int Cid, int BrandId, string keyword, string priceRange, int SupplierId)
        {
            StringBuilder strSql = new StringBuilder();
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            strSql.Append("SELECT  count(1) from " + TableName + " T ");
            strSql.AppendFormat(" WHERE   SaleStatus = 1 ");
            //品牌查询
            if (BrandId > 0)
            {
                strSql.AppendFormat("   AND BrandId = {0}", BrandId);
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ),'|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            //关键字搜索
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                strSql.AppendFormat(" AND (ProductName like '%{0}%' or ShortDescription like '%{0}%' )",
                    Common.InjectionFilter.SqlFilter(keyword));
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
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

        public int GetProductNoRecCount(int categoryId, string pName, int modeType, int supplierId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Shop_Products ");

            strSql.Append(" WHERE  SaleStatus = 1  ");
            if (categoryId > 0)
            {
                strSql.Append(" AND EXISTS (  SELECT DISTINCT  *  FROM   Shop_ProductCategories  ");
                strSql.AppendFormat(
                    "  WHERE  ( CategoryPath LIKE '{0}|%' OR CategoryId = {0}  )  AND ProductId = Shop_Products.ProductId ) ",
                    categoryId);
            }
            strSql.Append(" AND NOT EXISTS ( SELECT *  FROM   Shop_ProductStationModes ");
            strSql.AppendFormat("   WHERE  Type = {0} AND ProductId = Shop_Products.ProductId ) ", modeType);
            if (!String.IsNullOrWhiteSpace(pName))
            {
                strSql.AppendFormat(" AND ProductName LIKE '%{0}%' ", Common.InjectionFilter.SqlFilter(pName));
            }
            if (supplierId > 0)
            {
                strSql.AppendFormat(" AND SupplierId ={0} ", supplierId);
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

        public DataSet GetProductNoRecList(int categoryId, int supplierId, string pName, int modeType, int startIndex,
            int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from Shop_Products T ");

            strSql.Append(" WHERE  SaleStatus = 1  ");
            if (categoryId > 0)
            {
                strSql.Append(" AND EXISTS (  SELECT DISTINCT  *  FROM   Shop_ProductCategories  ");
                strSql.AppendFormat(
                    "  WHERE  ( CategoryPath LIKE '{0}|%' OR CategoryId = {0}  )  AND ProductId = T.ProductId ) ",
                    categoryId);
            }
            strSql.Append(" AND NOT EXISTS ( SELECT *  FROM   Shop_ProductStationModes ");
            strSql.AppendFormat("   WHERE  Type = {0} AND ProductId = T.ProductId ) ", modeType);
            if (!String.IsNullOrWhiteSpace(pName))
            {
                strSql.AppendFormat(" AND ProductName LIKE '%{0}%' ", Common.InjectionFilter.SqlFilter(pName));
            }
            if (supplierId > 0)
            {
                strSql.AppendFormat(" AND SupplierId ={0} ", supplierId);
            }
            strSql.Append(" order by T.ProductId desc");

            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }




        #endregion

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string productCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Products");
            strSql.Append(" where ProductCode=?ProductCode");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductCode", MySqlDbType.VarChar, 50)
            };
            parameters[0].Value = productCode;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        public DataSet GetProductsByCid(int Cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from Shop_Products T ");
            strSql.AppendFormat(" WHERE   SaleStatus = 1 ");

            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE  CONCAT((SELECT Path FROM Shop_Categories WHERE CategoryId = {0} ),'|%')",
                    Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            strSql.Append("order by T.ProductId desc");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #region  限时抢购

        public int GetProSalesCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  COUNT(1) FROM    Shop_CountDown D  ");
            strSql.AppendFormat("  WHERE   Status = 1 AND EndDate>=now() ");
            strSql.AppendFormat(
                "   AND EXISTS ( SELECT ProductId FROM   Shop_Products P WHERE  SaleStatus = 1 AND D.ProductId = P.ProductId ) ");

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

        public DataSet GetProSalesList(int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "SELECT D.CountDownId,D.Price AS ProSalesPrice,D.EndDate AS ProSalesEndDate ,P.* FROM  Shop_CountDown D ,Shop_Products P ");
            strSql.Append("  WHERE   Status = 1 AND EndDate>=now()  ");
            strSql.Append(" AND P.ProductId=d.ProductId AND SaleStatus=1  ");
            strSql.Append(" order by D.Sequence Desc ");
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetProSalesList(int cid, int regionId, int startIndex, int endIndex, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            if (cid == 0)
            {
                if (regionId == 0) //
                {
                    strSql.Append(
                        @"SELECT  D.GroupBuyId,D.Sequence,D.FinePrice,D.StartDate,D.EndDate,D.MaxCount,D.GroupCount,D.BuyCount,D.Price,D.Status,D.Description AS BuyDesc,P.* FROM  Shop_GroupBuy D ,Shop_Products P ");
                    strSql.Append("  WHERE   Status = 1 AND EndDate>=now()   AND StartDate<=now()");
                    strSql.Append(" AND P.ProductId=D.ProductId AND SaleStatus=1  ");
                    strSql.Append(" order by D.Sequence Desc ");
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        strSql.Append("," + orderby);
                    }
                    strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
                }
                else
                {
                    strSql.Append(
                        @"SELECT  D.GroupBuyId,D.Sequence,D.FinePrice,D.StartDate,D.EndDate,D.MaxCount,D.GroupCount,D.BuyCount,D.Price,D.Status,D.Description AS BuyDesc,P.* FROM  Shop_GroupBuy D ,Shop_Products P ");
                    strSql.Append("  WHERE   Status = 1 AND EndDate>=now()   AND StartDate<=now()");
                    strSql.Append(" AND P.ProductId=D.ProductId AND SaleStatus=1   And D.RegionId=" + regionId);
                    strSql.Append(" order by D.Sequence Desc ");
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        strSql.Append("," + orderby);
                    }
                    strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
                }
            }
            else
            {
                if (regionId == 0) //
                {
                    // StringBuilder strSql = new StringBuilder();
                    strSql.Append(
                        "SELECT D.GroupBuyId,D.Sequence,D.FinePrice,D.StartDate,D.EndDate,D.MaxCount,D.GroupCount,D.BuyCount,D.Price,D.Status,D.Description AS BuyDesc,P.* FROM  Shop_GroupBuy D ,Shop_Products P,Shop_ProductCategories C ");
                    strSql.Append("  WHERE   Status = 1 AND EndDate>=now()   AND StartDate<=now()");
                    strSql.Append(
                        " AND P.ProductId=D.ProductId AND SaleStatus=1  AND P.ProductId=C.ProductId And C.CategoryId=" +
                        cid);
                    strSql.Append(" order by D.Sequence Desc ");
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        strSql.Append("," + orderby);
                    }
                    strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
                }
                else
                {
                    // StringBuilder strSql = new StringBuilder();
                    strSql.Append(
                        "SELECT D.GroupBuyId,D.Sequence,D.FinePrice,D.StartDate,D.EndDate,D.MaxCount,D.GroupCount,D.BuyCount,D.Price,D.Status,D.Description AS BuyDesc,P.* FROM  Shop_GroupBuy D ,Shop_Products P,Shop_ProductCategories C ");
                    strSql.Append("  WHERE   Status = 1 AND EndDate>=now()   AND StartDate<=now()");
                    strSql.Append(
                        " AND P.ProductId=D.ProductId AND SaleStatus=1  AND P.ProductId=C.ProductId And C.CategoryId=" +
                        cid);
                    strSql.Append(" AND D.RegionId=" + regionId);
                    strSql.Append(" order by D.Sequence Desc ");
                    if (!string.IsNullOrWhiteSpace(orderby))
                    {
                        strSql.Append("," + orderby);
                    }
                    strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
                }
            }

            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetProSaleModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "select D.CountDownId,D.Price AS ProSalesPrice,D.EndDate AS ProSalesEndDate ,P.* FROM Shop_CountDown D ,Shop_Products P  ");
            strSql.Append("  WHERE   Status = 1 and CountDownId=?CountDownId ");
            strSql.Append(" AND P.ProductId=d.ProductId AND SaleStatus=1  ");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?CountDownId", MySqlDbType.Int32)
            };
            strSql.Append(" LIMIT 1 ");
            parameters[0].Value = id;
            YSWL.MALL.Model.Shop.Products.ProductInfo model = new YSWL.MALL.Model.Shop.Products.ProductInfo();
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取团购数据 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetGroupBuyList(int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "SELECT  D.GroupBuyId,D.Sequence,D.FinePrice,D.StartDate,D.EndDate,D.MaxCount,D.GroupCount,D.BuyCount,D.Price,D.Status,D.Description AS BuyDesc,P.* FROM  Shop_GroupBuy D ,Shop_Products P ");
            strSql.Append("  WHERE   Status = 1 AND EndDate>=now()   AND StartDate<=now()");
            strSql.Append(" AND P.ProductId=D.ProductId AND SaleStatus=1  ");
            strSql.Append(" order by D.Sequence Desc ");
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取团购Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet GetGroupBuyModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "select D.GroupBuyId,D.Sequence,D.FinePrice,D.StartDate,D.EndDate,D.MaxCount,D.GroupCount,D.BuyCount,D.Price,D.Status,D.Description AS BuyDesc,P.* FROM Shop_GroupBuy D ,Shop_Products P  ");
            strSql.Append("  WHERE   Status = 1 and GroupBuyId=?GroupBuyId ");
            strSql.Append(" AND P.ProductId=d.ProductId AND SaleStatus=1  ");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?GroupBuyId", MySqlDbType.Int32)
            };
            strSql.Append(" LIMIT 1 ");
            parameters[0].Value = id;
            YSWL.MALL.Model.Shop.Products.ProductInfo model = new YSWL.MALL.Model.Shop.Products.ProductInfo();
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        public int GetGroupBuyCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  COUNT(1) FROM    Shop_GroupBuy D  ");
            strSql.AppendFormat("  WHERE   Status = 1 AND EndDate>=now()  AND StartDate<=now()");
            strSql.AppendFormat(
                "   AND EXISTS ( SELECT ProductId FROM   Shop_Products P WHERE  SaleStatus = 1 AND D.ProductId = P.ProductId ) ");

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

        public int GetGroupBuyCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  COUNT(1) FROM    Shop_GroupBuy D  ");
            strSql.AppendFormat("  WHERE   Status = 1 AND EndDate>=now()  AND StartDate<=now()");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.AppendFormat("And {0}", strWhere);
            }
            strSql.AppendFormat(
                "   AND EXISTS ( SELECT ProductId FROM   Shop_Products P WHERE  SaleStatus = 1 AND D.ProductId = P.ProductId ) ");
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


        public int GetProductStatus(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SaleStatus  ");
            strSql.Append("FROM Shop_Products ");
            strSql.AppendFormat("WHERE ProductId={0} ", productId);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            return Common.Globals.SafeInt(obj, -1);
        }

        #endregion




        public bool UpdateThumbnail(YSWL.MALL.Model.Shop.Products.ProductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Products set ");
            strSql.Append("ThumbnailUrl1=?ThumbnailUrl1 ");
            strSql.Append(" where ProductId=?ProductId AND ImageUrl=?ImageUrl");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ImageUrl", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar, 255),
                new MySqlParameter("?ProductId", MySqlDbType.Int64, 8)
            };
            parameters[0].Value = model.ImageUrl;
            parameters[1].Value = model.ThumbnailUrl1;
            parameters[2].Value = model.ProductId;

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

        public DataSet GetListToReGen(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ProductId from Shop_Products  ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append("WHERE  " + strWhere);
            }
            //  strSql.Append("ORDER BY AddedDate DESC ");
            return DbHelperMySQL.Query((strSql.ToString()));
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetProdRecordCount(string strWhere, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT  count(1) ");
            strSql.Append("FROM " + TableName + " P ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
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
        /// 商品数据分页列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetProdListByPage(string strWhere, string orderby, int startIndex, int endIndex, int SupplierId)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                "SELECT P.CategoryId, TypeId, P.ProductId, BrandId, ProductName, ProductCode, SaleStatus, AddedDate, VistiCounts, SaleCounts, MarketPrice, LowestSalePrice, PenetrationStatus, MainCategoryPath, ExtendCategoryPath,  ImageUrl, ThumbnailUrl1 ");
            strSql.Append("FROM " + TableName + " P ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by P." + orderby);
            }
            else
            {
                strSql.Append(" order by P.ProductId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query((strSql.ToString()));
        }

        /// <summary>
        /// 获取商家推荐的商品列表
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="type"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public DataSet GetSuppRecList(int supplierId, int type, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P.* From  Shop_SuppProductStatModes S, Shop_Products P ");
            strSql.AppendFormat(" WHERE S.SupplierId={0} AND S.ProductId = P.ProductId  and   SaleStatus = 1 ",
                supplierId);
            strSql.AppendFormat(" and S.Type = {0} ", type);
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                strSql.AppendFormat(" ORDER BY {0} ", orderby);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 获取商品类别下的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetProList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(
                @"select ShopCategories.CategoryId,ShopCategories.ProductId,ShopCategories.CategoryPath,ShopProduct.CategoryId,ShopProduct.TypeId,
            ShopProduct.ProductId, ShopProduct.BrandId, ShopProduct.ProductName, ShopProduct.ProductCode, ShopProduct.SupplierId, ShopProduct.RegionId, 
            ShopProduct.ShortDescription, ShopProduct.Unit, ShopProduct.Description, ShopProduct.Meta_Title, ShopProduct.Meta_Description, ShopProduct.Meta_Keywords,
            ShopProduct.SaleStatus, ShopProduct.AddedDate, ShopProduct.VistiCounts, ShopProduct.SaleCounts, ShopProduct.Stock, ShopProduct.DisplaySequence, ShopProduct.LineId, 
            ShopProduct.MarketPrice, ShopProduct.LowestSalePrice, ShopProduct.PenetrationStatus, ShopProduct.MainCategoryPath, ShopProduct.ExtendCategoryPath, ShopProduct.HasSKU, 
            ShopProduct.Points, ShopProduct.ImageUrl, ShopProduct.ThumbnailUrl1, ShopProduct.ThumbnailUrl2, ShopProduct.ThumbnailUrl3, ShopProduct.ThumbnailUrl4, 
            ShopProduct.ThumbnailUrl5, ShopProduct.ThumbnailUrl6, ShopProduct.ThumbnailUrl7, ShopProduct.ThumbnailUrl8, ShopProduct.MaxQuantity, ShopProduct.MinQuantity, 
            ShopProduct.Tags, ShopProduct.SeoUrl, ShopProduct.SeoImageAlt, ShopProduct.SeoImageTitle");
            strSql.Append(
                " from    Shop_ProductCategories as ShopCategories inner join    Shop_Products as ShopProduct ");
            strSql.Append(" on ShopProduct.ProductId = ShopCategories.ProductId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public int GetCount(int cid, int regionId)
        {
            if (cid == 0) //没有分类
            {
                if (regionId == 0) //没有地区
                {
                    return GetGroupBuyCount();
                }
                else //没有分类有地区
                {
                    string strWhere = string.Format("RegionId={0}", regionId);
                    return GetGroupBuyCount(strWhere);
                }
            }
            else
            {
                if (regionId == 0) //有分类没有地区
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(" SELECT  COUNT(1) FROM    [Shop_ProductCategories] p, [Shop_GroupBuy] g ");
                    strSql.AppendFormat(
                        "  WHERE p.ProductId=g.ProductId  And   g.Status = 1 AND g.EndDate>=now()  AND g.StartDate<=now()");
                    strSql.AppendFormat(
                        "   AND EXISTS ( SELECT ProductId FROM   Shop_Products P WHERE  SaleStatus = 1 AND g.ProductId = P.ProductId ) ");
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
                else //既有分类也有地区
                {
                    string strWhere = string.Format("RegionId={0}", regionId);
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(" SELECT  COUNT(1) FROM    [Shop_ProductCategories] p, [Shop_GroupBuy] g ");
                    strSql.AppendFormat(
                        "  WHERE p.ProductId=g.ProductId  And   g.Status = 1 AND g.EndDate>=now()  AND g.StartDate<=now()");
                    if (!string.IsNullOrWhiteSpace(strWhere))
                    {
                        strSql.AppendFormat("And {0}", strWhere);
                    }
                    strSql.AppendFormat(
                        "   AND EXISTS ( SELECT ProductId FROM   Shop_Products P WHERE  SaleStatus = 1 AND g.ProductId = P.ProductId ) ");
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
            }
        }


        #region 供应商商品方法

        /// <summary>
        /// 根据商家id获得是否存在该记录
        /// </summary>
        public bool Exists(int supplierId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Products");
            strSql.Append(" where SupplierId=?SupplierId");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?SupplierId", MySqlDbType.Int32)
            };
            parameters[0].Value = supplierId;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取供应商商品数量
        /// </summary>
        /// <param name="Cid">分类</param>
        /// <param name="supplierId">供应商ID</param>
        /// <param name="keyword">关键词</param>
        /// <param name="priceRange">价格区间</param>
        /// <returns></returns>
        public int GetSuppProductsCount(int Cid, int supplierId, string keyword, string priceRange)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  count(1) from Shop_Products T ");
            strSql.AppendFormat(" WHERE  SaleStatus = 1 and SupplierId={0} ", supplierId);
            //关键字搜索
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                strSql.AppendFormat(" AND (ProductName like '%{0}%' or ShortDescription like '%{0}%') ",
                    Common.InjectionFilter.SqlFilter(keyword));
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_SuppProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_SupplierCategories WHERE CategoryId = {0}  ) , '|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_SuppProductCategories.CategoryId = {0}))", Cid);
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
        /// 根据条件获取供应商商品
        /// </summary>
        /// <param name="Cid">类别ID</param>
        /// <param name="supplierId">供应商id</param>
        /// <param name="keyword">关键词</param>
        /// <param name="priceRange">价格区间</param>
        /// <param name="orderby">排序</param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSuppProductsList(int Cid, int supplierId, string keyword, string priceRange, string orderby,
            int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from Shop_Products T ");

            strSql.AppendFormat(" WHERE   SaleStatus = 1  and SupplierId={0} ", supplierId);
            //关键字搜索
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                strSql.AppendFormat(" AND (ProductName like '%{0}%' or ShortDescription like '%{0}%') ",
                    Common.InjectionFilter.SqlFilter(keyword));
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_SuppProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE  CONCAT(( SELECT Path FROM Shop_SupplierCategories WHERE CategoryId = {0}  ) , '|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_SuppProductCategories.CategoryId = {0}))", Cid);
            }
            if (!string.IsNullOrEmpty(orderby))
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

        /// <summary>
        /// 根据条件获取供应商商品
        /// </summary>
        /// <param name="top"></param>
        /// <param name="Cid"></param>
        /// <param name="supplierId"></param>
        /// <param name="orderby"></param>
        /// <param name="keyword"></param>
        /// <param name="priceRange"></param>
        /// <returns></returns>
        public DataSet GetSuppProductsList(int top, int Cid, int supplierId, string orderby, string keyword,
            string priceRange)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select   ");

            strSql.Append("   * from Shop_Products T ");
            strSql.AppendFormat(" WHERE   SaleStatus = 1  and SupplierId={0} ", supplierId);
            //关键字搜索
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                strSql.AppendFormat(" AND (ProductName like '%{0}%' or ShortDescription like '%{0}%') ",
                    Common.InjectionFilter.SqlFilter(keyword));
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_SuppProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE  CONCAT(( SELECT Path FROM Shop_SupplierCategories WHERE CategoryId = {0}  ) , '|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_SuppProductCategories.CategoryId = {0}))", Cid);
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.ProductId desc");
            }
            if (top > 0)
            {
                strSql.AppendFormat(" LIMIT  {0}  ", top);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 根据条件获取商品
        /// </summary>
        /// <param name="Cid"></param>
        /// <param name="BrandId"></param>
        /// <param name="attrValues"></param>
        /// <param name="priceRange"></param>
        /// <param name="mod"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetSearchListEx(int Cid, int BrandId, string keyword, string priceRange,
            string orderby, int startIndex, int endIndex, int SupplierId, int type, string strWhere)
        {
            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from " + TableName + " T ");
            if (type > 0)
            {
                strSql.Append(" INNER JOIN Shop_ProductStationModes PSM ON T.ProductId = PSM.ProductId ");
                strSql.Append(" WHERE PSM.Type=?Type And T.SaleStatus=1 ");

            }
            else
            {
                strSql.AppendFormat(" WHERE   SaleStatus = 1 ");
            }


            //品牌查询
            if (BrandId > 0)
            {
                strSql.AppendFormat("   AND BrandId = {0}", BrandId);
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    " AND ( CategoryPath LIKE  CONCAT(( SELECT Path FROM Shop_SupplierCategories WHERE CategoryId = {0}  ) , '|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            //关键字搜索
            if (!String.IsNullOrWhiteSpace(keyword))
            {
                strSql.AppendFormat(" AND (ProductName like '%{0}%' or ShortDescription like '%{0}%') ",
                    Common.InjectionFilter.SqlFilter(keyword));
            }
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.AppendFormat(" AND  {0}", strWhere);
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
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
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?Type", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = type;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 根据条件获取商品
        /// </summary>
        /// <param name="Cid"></param>
        /// <param name="BrandId"></param>
        /// <param name="attrValues"></param>
        /// <param name="priceRange"></param>
        /// <param name="mod"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetProductsListEx(int Cid, int BrandId, string attrValues, string priceRange,
            string mod, int startIndex, int endIndex, int SupplierId, int type)
        {

            string TableName = "Shop_Products";
            if (SupplierId > 0)
            {
                TableName = "Shop_SuppDistProduct_" + SupplierId;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  from " + TableName + " T ");
            if (type > 0)
            {
                strSql.Append(" INNER JOIN Shop_ProductStationModes PSM ON T.ProductId = PSM.ProductId ");
                strSql.Append(" WHERE PSM.Type=?Type And T.SaleStatus=1 ");

            }

            else
            {
                strSql.AppendFormat(" WHERE   SaleStatus = 1 ");
            }
            //品牌查询
            if (BrandId > 0)
            {
                strSql.AppendFormat("   AND BrandId = {0}", BrandId);
            }
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =T.ProductId  ");
                strSql.AppendFormat(
                    "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ),'|%') ",
                    Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            //循环属性
            if (!String.IsNullOrWhiteSpace(attrValues))
            {
                var attrValue_arry = attrValues.Split('-');
                foreach (var attr in attrValue_arry)
                {
                    int valueId = Common.Globals.SafeInt(attr, 0);
                    if (valueId > 0)
                    {
                        strSql.AppendFormat(
                            "  AND EXISTS ( SELECT * FROM   Shop_ProductAttributes WHERE  ProductId = T.ProductId AND ValueId = {0} )",
                            valueId);
                    }
                }
            }
            //价格区间
            if (!String.IsNullOrWhiteSpace(priceRange))
            {
                var price_arr = priceRange.Split('-');
                decimal startPrice = Common.Globals.SafeInt(price_arr[0], 0);
                strSql.AppendFormat("   AND LowestSalePrice >= {0} ", startPrice);
                if (price_arr.Length > 1 && Common.Globals.SafeInt(price_arr[1], 0) > 0)
                {
                    strSql.AppendFormat("   AND LowestSalePrice <= {0} ", price_arr[1]);
                }
            }

            if (!string.IsNullOrEmpty(mod.Trim()))
            {
                strSql.Append(" order by T." + mod);
            }
            else
            {
                strSql.Append(" order by T.ProductId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?Type", MySqlDbType.Int32, 4)
            };
            parameters[0].Value = type;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        #endregion



        public DataSet GetProducts(int supplierId)
        {
            string strSql = " select p.ProductId from Shop_Products p where  exists ";
            strSql += "( select * from Shop_SupplierBrands b where p.BrandId=b.BrandId and b.SupplierId=?SupplierId)";
            MySqlParameter[] parameters = {new MySqlParameter("?SupplierId", MySqlDbType.Int32, 4)};
            parameters[0].Value = supplierId;
            return DbHelperMySQL.Query(strSql, parameters);
        }

        /// <summary>
        /// 按品类统计商品数量
        /// </summary>
        /// <returns></returns>
        public DataSet GetCategoriesCount()
        {
            string strSql = @"if OBJECT_ID('tempdb..#Temp_Shop_Categories') is not null
drop table #Temp_Shop_Categories;

select * into #Temp_Shop_Categories
from(
select SC.CategoryId,SC.Name CategoryName,t.ProductCategoryId,t.CategoryPath,t.CName,t.ProductId,t.SaleStatus from Shop_Categories SC
right join(
select PC.CategoryId ProductCategoryId,C.Path CategoryPath,C.Name CName,P.ProductId,P.SaleStatus from Shop_Products P
left join Shop_ProductCategories PC
ON P.ProductId = PC.ProductId 
left join Shop_Categories C
on PC.CategoryId=C.CategoryId
)t on (t.ProductCategoryId=sc.CategoryId or t.CategoryPath  LIKE ''+CONVERT(varchar(20),SC.CategoryId)+'|%')
where SC.Depth=1
) tt;

select t0.CategoryId,t0.CategoryName,t1.count0,t2.count1 from
(select CategoryId, Name CategoryName from Shop_Categories SC where SC.Depth=1)t0 left join
(select CategoryId,count(CategoryId) count0 from #Temp_Shop_Categories where SaleStatus=0 group by CategoryId)t1 
on t0.CategoryId=t1.CategoryId
left join 
(select CategoryId,count(CategoryId) count1 from #Temp_Shop_Categories where SaleStatus=1 group by CategoryId)t2 
on t0.CategoryId=t2.CategoryId;

drop table #Temp_Shop_Categories;";

            return DbHelperMySQL.Query(strSql);
        }

        /// <summary>
        /// 获取限购数量
        /// </summary>
        public int GetRestrictionCount(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  RestrictionCount  FROM Shop_Products ");
            strSql.AppendFormat(" where  ProductId=?ProductId");
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?ProductId", MySqlDbType.Int64)
            };
            parameters[0].Value = productId;
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
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Shop.Products.ProductInfo> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Shop.Products.ProductInfo> modelList = new List<YSWL.MALL.Model.Shop.Products.ProductInfo>();
            int rowsCount = dt.Rows.Count;
            bool IsHasSalesType = dt.Columns.Contains("SalesType");
            bool IsHasRestCount = dt.Columns.Contains("RestrictionCount");
            bool IsHasDeliveryTip = dt.Columns.Contains("DeliveryTip");
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Shop.Products.ProductInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new YSWL.MALL.Model.Shop.Products.ProductInfo();
                    if (dt.Rows[n]["CategoryId"] != null && dt.Rows[n]["CategoryId"].ToString() != "")
                    {
                        model.CategoryId = int.Parse(dt.Rows[n]["CategoryId"].ToString());
                    }
                    if (dt.Rows[n]["TypeId"] != null && dt.Rows[n]["TypeId"].ToString() != "")
                    {
                        model.TypeId = int.Parse(dt.Rows[n]["TypeId"].ToString());
                    }
                    if (dt.Rows[n]["ProductId"] != null && dt.Rows[n]["ProductId"].ToString() != "")
                    {
                        model.ProductId = long.Parse(dt.Rows[n]["ProductId"].ToString());
                    }
                    if (dt.Rows[n]["BrandId"] != null && dt.Rows[n]["BrandId"].ToString() != "")
                    {
                        model.BrandId = int.Parse(dt.Rows[n]["BrandId"].ToString());
                    }
                    if (dt.Rows[n]["ProductName"] != null && dt.Rows[n]["ProductName"].ToString() != "")
                    {
                        model.ProductName = dt.Rows[n]["ProductName"].ToString();
                    }
                    if (dt.Rows[n]["ProductCode"] != null && dt.Rows[n]["ProductCode"].ToString() != "")
                    {
                        model.ProductCode = dt.Rows[n]["ProductCode"].ToString();
                    }
                    if (dt.Rows[n]["SupplierId"] != null && dt.Rows[n]["SupplierId"].ToString() != "")
                    {
                        model.SupplierId = int.Parse(dt.Rows[n]["SupplierId"].ToString());
                    }
                    if (dt.Rows[n]["RegionId"] != null && dt.Rows[n]["RegionId"].ToString() != "")
                    {
                        model.RegionId = int.Parse(dt.Rows[n]["RegionId"].ToString());
                    }
                    if (dt.Rows[n]["ShortDescription"] != null && dt.Rows[n]["ShortDescription"].ToString() != "")
                    {
                        model.ShortDescription = dt.Rows[n]["ShortDescription"].ToString();
                    }
                    if (dt.Rows[n]["Unit"] != null && dt.Rows[n]["Unit"].ToString() != "")
                    {
                        model.Unit = dt.Rows[n]["Unit"].ToString();
                    }
                    if (dt.Rows[n]["Description"] != null && dt.Rows[n]["Description"].ToString() != "")
                    {
                        model.Description = dt.Rows[n]["Description"].ToString();
                    }
                    if (dt.Rows[n]["Meta_Title"] != null && dt.Rows[n]["Meta_Title"].ToString() != "")
                    {
                        model.Meta_Title = dt.Rows[n]["Meta_Title"].ToString();
                    }
                    if (dt.Rows[n]["Meta_Description"] != null && dt.Rows[n]["Meta_Description"].ToString() != "")
                    {
                        model.Meta_Description = dt.Rows[n]["Meta_Description"].ToString();
                    }
                    if (dt.Rows[n]["Meta_Keywords"] != null && dt.Rows[n]["Meta_Keywords"].ToString() != "")
                    {
                        model.Meta_Keywords = dt.Rows[n]["Meta_Keywords"].ToString();
                    }
                    if (dt.Rows[n]["SaleStatus"] != null && dt.Rows[n]["SaleStatus"].ToString() != "")
                    {
                        model.SaleStatus = int.Parse(dt.Rows[n]["SaleStatus"].ToString());
                    }
                    if (dt.Rows[n]["AddedDate"] != null && dt.Rows[n]["AddedDate"].ToString() != "")
                    {
                        model.AddedDate = DateTime.Parse(dt.Rows[n]["AddedDate"].ToString());
                    }
                    if (dt.Rows[n]["VistiCounts"] != null && dt.Rows[n]["VistiCounts"].ToString() != "")
                    {
                        model.VistiCounts = int.Parse(dt.Rows[n]["VistiCounts"].ToString());
                    }
                    if (dt.Rows[n]["SaleCounts"] != null && dt.Rows[n]["SaleCounts"].ToString() != "")
                    {
                        model.SaleCounts = int.Parse(dt.Rows[n]["SaleCounts"].ToString());
                    }
                    if (dt.Rows[n]["DisplaySequence"] != null && dt.Rows[n]["DisplaySequence"].ToString() != "")
                    {
                        model.DisplaySequence = int.Parse(dt.Rows[n]["DisplaySequence"].ToString());
                    }
                    if (dt.Rows[n]["LineId"] != null && dt.Rows[n]["LineId"].ToString() != "")
                    {
                        model.LineId = int.Parse(dt.Rows[n]["LineId"].ToString());
                    }
                    if (dt.Rows[n]["MarketPrice"] != null && dt.Rows[n]["MarketPrice"].ToString() != "")
                    {
                        model.MarketPrice = decimal.Parse(dt.Rows[n]["MarketPrice"].ToString());
                    }
                    if (dt.Rows[n]["LowestSalePrice"] != null && dt.Rows[n]["LowestSalePrice"].ToString() != "")
                    {
                        model.LowestSalePrice = decimal.Parse(dt.Rows[n]["LowestSalePrice"].ToString());
                    }
                    if (dt.Rows[n]["PenetrationStatus"] != null && dt.Rows[n]["PenetrationStatus"].ToString() != "")
                    {
                        model.PenetrationStatus = int.Parse(dt.Rows[n]["PenetrationStatus"].ToString());
                    }
                    if (dt.Rows[n]["MainCategoryPath"] != null && dt.Rows[n]["MainCategoryPath"].ToString() != "")
                    {
                        model.MainCategoryPath = dt.Rows[n]["MainCategoryPath"].ToString();
                    }
                    if (dt.Rows[n]["ExtendCategoryPath"] != null && dt.Rows[n]["ExtendCategoryPath"].ToString() != "")
                    {
                        model.ExtendCategoryPath = dt.Rows[n]["ExtendCategoryPath"].ToString();
                    }
                    if (dt.Rows[n]["HasSKU"] != null && dt.Rows[n]["HasSKU"].ToString() != "")
                    {
                        if ((dt.Rows[n]["HasSKU"].ToString() == "1") ||
                            (dt.Rows[n]["HasSKU"].ToString().ToLower() == "true"))
                        {
                            model.HasSKU = true;
                        }
                        else
                        {
                            model.HasSKU = false;
                        }
                    }
                    if (dt.Rows[n]["Points"] != null && dt.Rows[n]["Points"].ToString() != "")
                    {
                        model.Points = decimal.Parse(dt.Rows[n]["Points"].ToString());
                    }
                    if (dt.Rows[n]["ImageUrl"] != null && dt.Rows[n]["ImageUrl"].ToString() != "")
                    {
                        model.ImageUrl = dt.Rows[n]["ImageUrl"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl1"] != null && dt.Rows[n]["ThumbnailUrl1"].ToString() != "")
                    {
                        model.ThumbnailUrl1 = dt.Rows[n]["ThumbnailUrl1"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl2"] != null && dt.Rows[n]["ThumbnailUrl2"].ToString() != "")
                    {
                        model.ThumbnailUrl2 = dt.Rows[n]["ThumbnailUrl2"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl3"] != null && dt.Rows[n]["ThumbnailUrl3"].ToString() != "")
                    {
                        model.ThumbnailUrl3 = dt.Rows[n]["ThumbnailUrl3"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl4"] != null && dt.Rows[n]["ThumbnailUrl4"].ToString() != "")
                    {
                        model.ThumbnailUrl4 = dt.Rows[n]["ThumbnailUrl4"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl5"] != null && dt.Rows[n]["ThumbnailUrl5"].ToString() != "")
                    {
                        model.ThumbnailUrl5 = dt.Rows[n]["ThumbnailUrl5"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl6"] != null && dt.Rows[n]["ThumbnailUrl6"].ToString() != "")
                    {
                        model.ThumbnailUrl6 = dt.Rows[n]["ThumbnailUrl6"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl7"] != null && dt.Rows[n]["ThumbnailUrl7"].ToString() != "")
                    {
                        model.ThumbnailUrl7 = dt.Rows[n]["ThumbnailUrl7"].ToString();
                    }
                    if (dt.Rows[n]["ThumbnailUrl8"] != null && dt.Rows[n]["ThumbnailUrl8"].ToString() != "")
                    {
                        model.ThumbnailUrl8 = dt.Rows[n]["ThumbnailUrl8"].ToString();
                    }
                    if (dt.Rows[n]["MaxQuantity"] != null && dt.Rows[n]["MaxQuantity"].ToString() != "")
                    {
                        model.MaxQuantity = int.Parse(dt.Rows[n]["MaxQuantity"].ToString());
                    }
                    if (dt.Rows[n]["MinQuantity"] != null && dt.Rows[n]["MinQuantity"].ToString() != "")
                    {
                        model.MinQuantity = int.Parse(dt.Rows[n]["MinQuantity"].ToString());
                    }
                    if (dt.Rows[n]["Tags"] != null && dt.Rows[n]["Tags"].ToString() != "")
                    {
                        model.Tags = dt.Rows[n]["Tags"].ToString();
                    }
                    if (dt.Rows[n]["SeoUrl"] != null && dt.Rows[n]["SeoUrl"].ToString() != "")
                    {
                        model.SeoUrl = dt.Rows[n]["SeoUrl"].ToString();
                    }
                    if (dt.Rows[n]["SeoImageAlt"] != null && dt.Rows[n]["SeoImageAlt"].ToString() != "")
                    {
                        model.SeoImageAlt = dt.Rows[n]["SeoImageAlt"].ToString();
                    }
                    if (dt.Rows[n]["SeoImageTitle"] != null && dt.Rows[n]["SeoImageTitle"].ToString() != "")
                    {
                        model.SeoImageTitle = dt.Rows[n]["SeoImageTitle"].ToString();
                    }
                    if (IsHasSalesType)
                    {
                        if (dt.Rows[n]["SalesType"] != null && dt.Rows[n]["SalesType"].ToString() != "")
                        {
                            model.SalesType = int.Parse(dt.Rows[n]["SalesType"].ToString());
                        }
                    }
                    if (IsHasRestCount)
                    {
                        if (dt.Rows[n]["RestrictionCount"] != null && dt.Rows[n]["RestrictionCount"].ToString() != "")
                        {
                            model.RestrictionCount = int.Parse(dt.Rows[n]["RestrictionCount"].ToString());
                        }
                    }
                    if (IsHasDeliveryTip)
                    {
                        if (dt.Rows[n]["DeliveryTip"] != null && dt.Rows[n]["DeliveryTip"].ToString() != "")
                        {
                            model.DeliveryTip = dt.Rows[n]["DeliveryTip"].ToString();
                        }
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        public DataSet GetGiftsByCid(int Cid)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.Exists(long ProductId)
        {
            throw new NotImplementedException();
        }

        long IProductInfo.Add(Model.Shop.Products.ProductInfo model)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.Update(Model.Shop.Products.ProductInfo model)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.Delete(long ProductId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.DeleteList(string ProductIdlist)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Products.ProductInfo IProductInfo.GetModel(long ProductId)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Products.ProductInfo IProductInfo.DataRowToModel(DataRow row)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetRecordCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.UpdateList(string IDlist, string strSetValue)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.UpdateProductName(long productId, string strSetValue)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetListByCategoryIdSaleStatus(string strWhere, int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetListByExport(int SaleStatus, string ProductName, int CategoryId, string SKU, int BrandId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.SearchProducts(int cateId, ProductSearch model)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductListByCategoryId(int? categoryId, string strWhere, string orderBy, int startIndex,
            int endIndex, int SupplierId, out int dataCount)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductListByCategoryIdEx(int? categoryId, string strWhere, string orderBy,
            int startIndex, int endIndex, int SupplierId, out int dataCount)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductListInfo(string strWhere, string orderBy, int startIndex, int endIndex,
            out int dataCount, long productId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductCommendListInfo(string strWhere, string orderBy, int startIndex, int endIndex,
            out int dataCount, long productId, int modeType)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductListInfo(string strProductIds, int SupplierId)
        {
            throw new NotImplementedException();
        }

        string IProductInfo.GetProductName(long productId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.ExistsBrands(int BrandId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetTableSchema()
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetTableSchemaEx()
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetList(string strWhere, string DataField, int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductInfo(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.DeleteProducts(string Ids, out int Result)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetRecycleList(string strWhere, int SupplierId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.RevertAll(int SupplierId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.UpdateStatus(long productId, int SaleStatus, int SupplierId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.ChangeProductsCategory(string productIds, int categoryId)
        {
            throw new NotImplementedException();
        }

        long IProductInfo.StockNum(long productId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.UpdateMarketPrice(long productId, decimal price, int SupplierId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.UpdateLowestSalePrice(long productId, decimal price, int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductRecList(ProductRecType type, int categoryId, int top, int SupplierId)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetProductRecCount(ProductRecType type, int categoryId, int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductRanList(int top, int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.RelatedProductSource(long productId, int top)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductsListEx(int Cid, int BrandId, string attrValues, string priceRange, string mod,
            int startIndex, int endIndex, int SupplierId)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetProductsCountEx(int Cid, int BrandId, string attrValues, string priceRange, int SupplierId)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.MaxSequence()
        {
            throw new NotImplementedException();
        }

        int IProductInfo.MaxSequence(string CategoryPath)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetSearchCountEx(int Cid, int BrandId, List<String> keyWord, string priceRange, int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetSearchListEx(int Cid, int BrandId, List<String> keyWord, string priceRange, string mod,
            int startIndex, int endIndex, int SupplierId)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetProductNoRecCount(int categoryId, string pName, int modeType, int supplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductNoRecList(int categoryId, int supplierId, string pName, int modeType,
            int startIdex, int endIndex)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.Exists(string productCode)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductsByCid(int cid)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetProSalesCount()
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetGroupBuyCount()
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProSalesList(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProSaleModel(int id)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetGroupBuyList(int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetGroupBuyModel(int id)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetProductStatus(long productId)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetSuppProductsCount(int Cid, int supplierId, string keyword, string priceRange)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetSuppProductsList(int Cid, int supplierId, string keyword, string priceRange,
            string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetSuppProductsList(int top, int Cid, int supplierId, string orderby, string keyword,
            string priceRange)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.UpdateThumbnail(Model.Shop.Products.ProductInfo model)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetListToReGen(string strWhere)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetProdRecordCount(string strWhere, int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProdListByPage(string strWhere, string orderby, int startIndex, int endIndex,
            int SupplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetSuppRecList(int supplierId, int strType, string orderby)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProList(string strWhere)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetCount(int cid, int regionId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProSalesList(int cid, int regionId, int startIndex, int endIndex, string orderby)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetTableHead()
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductRanListByRec(ProductRecType type, int categoryId, int top, int SupplierId)
        {
            throw new NotImplementedException();
        }

        bool IProductInfo.Exists(int supplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetSearchListEx(int Cid, int BrandId, string keyWord, string priceRange, string orderby,
            int startIndex, int endIndex, int SupplierId, int type, string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProductsListEx(int Cid, int BrandId, string attrValues, string priceRange, string mod,
            int startIndex, int endIndex, int SupplierId, int type)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProducts(int supplierId)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetCategoriesCount()
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetRestrictionCount(long productId)
        {
            throw new NotImplementedException();
        }

        List<Model.Shop.Products.ProductInfo> IProductInfo.DataTableToList(DataTable dt)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetGiftsByCid(int Cid)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetProSalesList(int top)
        {
            throw new NotImplementedException();
        }


        long IProductInfo.UpdatePV(long pId)
        {
            throw new NotImplementedException();
        }


        DataSet IProductInfo.GetProductsByCid(int Cid, bool storeIsInActivity)
        {
            throw new NotImplementedException();
        }

        public DataSet GetNoRuleProductList(string pName, string categoryId, int status, int ruleId, int startIndex,
            int endIndex)
        {
            throw new NotImplementedException();
        }

        public int GetNoRuleProductCount(string pName, string categoryId, int ruleId, int status = 1)
        {
            throw new NotImplementedException();
        }

        #region 预订商品

        public DataSet GetPreProductList()
        {
            throw new NotImplementedException();
        }

        #endregion


        DataSet IProductInfo.GetNoRuleProductList(string pName, string categoryId, int status, int ruleId,
            int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        int IProductInfo.GetNoRuleProductCount(string pName, string categoryId, int ruleId, int status)
        {
            throw new NotImplementedException();
        }

        DataSet IProductInfo.GetPreProductList()
        {
            throw new NotImplementedException();
        }

        public DataSet GetSalesRuleProductsList(int startIndex, int endIndex, string orderBy, int rankId)
        {
            throw new NotImplementedException();
        }

        public int GetSalesRuleProdCount(int rankId)
        {
            throw new NotImplementedException();
        }

        public DataSet GetOrderedProdList(int userId, DateTime startDate, DateTime endDate, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        public int GetOrderedProdCount(int userId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public DataSet GetListExport(string Ids, string DataField, int SupplierId)
        {
            throw new NotImplementedException();
        }

        public bool SubUpdateList(string depotIds, string IDlist, string strWhere)
        {
            throw new NotImplementedException();
        }
    }
}