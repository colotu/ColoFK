/**
* ProductService.cs
*
* 功 能： Shop模块-产品相关 多表事务操作类
* 类 名： ProductService
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/6/22 10:46:33  Ben    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using YSWL.Common;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.MALL.Model.Shop.Products;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// Shop模块-产品相关 多表事务操作类
    /// </summary>
    public class ProductService : IProductService
    {
        #region IProductService 成员

        #region 新增产品
        public bool AddProduct(Model.Shop.Products.ProductInfo productInfo, out long ProductId)
        {
            ProductId = 0;
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object result;
                    try
                    {
                        //添加商品
                        result = DbHelperMySQL.GetSingle4Trans(GenerateProductInfo(productInfo), transaction);
                        //获取新增的商品主键
                        productInfo.ProductId = Globals.SafeLong(result.ToString(), -1);

                        ProductId = productInfo.ProductId;

                        //添加产品分类
                        DbHelperMySQL.ExecuteSqlTran4Indentity(SaveProductCategories(productInfo), transaction);

                        //添加属性
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateAttributeInfo(productInfo, transaction), transaction);

                        //添加SKU
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateSKUs(productInfo, transaction), transaction);

                        //添加相关商品
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateRelatedProduct(productInfo), transaction);

                        //添加图片
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateImages(productInfo), transaction);

                        //推荐商品
                        if (productInfo.isRec)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 0), transaction);
                        }
                        //最新商品
                        if (productInfo.isNow)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 3), transaction);
                        }
                        //最热商品
                        if (productInfo.isHot)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 1), transaction);
                        }
                        //特价商品
                        if (productInfo.isLowPrice)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 2), transaction);
                        }

                        //添加包装
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GeneratePackage(productInfo), transaction);
                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region 修改产品
        public bool ModifyProduct(Model.Shop.Products.ProductInfo productInfo)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        //TODO：删除原有信息
                        DeleteOldProductInfo(productInfo);

                        //TODO：更新商品基本信息
                        DbHelperMySQL.GetSingle4Trans(UpdateProductInfo(productInfo), transaction);

                        //添加产品分类
                        DbHelperMySQL.ExecuteSqlTran4Indentity(SaveProductCategories(productInfo), transaction);

                        //添加属性
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateAttributeInfo(productInfo, transaction), transaction);

                        //添加SKU
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateSKUs(productInfo, transaction), transaction);
 
                        //添加相关商品
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateRelatedProduct(productInfo), transaction);

                        //添加图片
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateImages(productInfo), transaction);

                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #endregion IProductService 成员

          #region 新增供应商产品
        public bool AddSuppProduct(Model.Shop.Products.ProductInfo productInfo, out long ProductId)
        {
            ProductId = 0;
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    object result;
                    try
                    {
                        //添加商品
                        result = DbHelperMySQL.GetSingle4Trans(GenerateProductInfo(productInfo), transaction);
                        //获取新增的商品主键
                        productInfo.ProductId = Globals.SafeLong(result.ToString(), -1);

                        ProductId = productInfo.ProductId;

                        //添加产品分类
                        DbHelperMySQL.ExecuteSqlTran4Indentity(SaveProductCategories(productInfo), transaction);

                        //添加店铺产品分类
                        DbHelperMySQL.ExecuteSqlTran4Indentity(SaveSuppProductCategories(productInfo), transaction);

                        //添加属性
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateAttributeInfo(productInfo, transaction), transaction);

                        //添加SKU
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateSKUs(productInfo, transaction), transaction);
 
                        //添加相关商品
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateRelatedProduct(productInfo), transaction);

                        //添加图片
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateImages(productInfo), transaction);

                        //推荐商品
                        if (productInfo.isRec)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 0), transaction);
                        }
                        //最新商品
                        if (productInfo.isNow)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 3), transaction);
                        }
                        //最热商品
                        if (productInfo.isHot)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 1), transaction);
                        }
                        //特价商品
                        if (productInfo.isLowPrice)
                        {
                            DbHelperMySQL.GetSingle4Trans(GenerateProductStationModes(productInfo, 2), transaction);
                        }

                        //添加包装
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GeneratePackage(productInfo), transaction);
                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region 修改供应商产品
        public bool ModifySuppProduct(Model.Shop.Products.ProductInfo productInfo)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        //TODO：删除原有信息
                        DeleteOldProductInfo(productInfo);
                        DeleteOldSuppProductCate(productInfo);//删除原有分类

                        //TODO：更新商品基本信息
                        DbHelperMySQL.GetSingle4Trans(UpdateProductInfo(productInfo), transaction);

                        //添加产品分类
                        DbHelperMySQL.ExecuteSqlTran4Indentity(SaveProductCategories(productInfo), transaction);
                        //添加店铺产品分类

                        DbHelperMySQL.ExecuteSqlTran4Indentity(SaveSuppProductCategories(productInfo), transaction);

                        //添加属性
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateAttributeInfo(productInfo, transaction), transaction);

                        //添加SKU
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateSKUs(productInfo, transaction), transaction);
 
                        //添加相关商品
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateRelatedProduct(productInfo), transaction);

                        //添加图片
                        DbHelperMySQL.ExecuteSqlTran4Indentity(GenerateImages(productInfo), transaction);

                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

       

        #region 产品重新编辑保存前，删除产品相关联信息
        private void DeleteOldProductInfo(Model.Shop.Products.ProductInfo productInfo)
        {
            MySqlParameter[] parameter = {
                                       new MySqlParameter("_ProductId",MySqlDbType.Int64,8)
                                       };
            parameter[0].Value = productInfo.ProductId;

            DbHelperMySQL.RunProcedure("sp_Shop_DeleteBeforeUpdate", parameter);
        }
        private void DeleteOldSuppProductCate(Model.Shop.Products.ProductInfo productInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_SuppProductCategories ");
            strSql.Append(" where ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)			};
            parameters[0].Value = productInfo.ProductId;
            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 产品信息

        private CommandInfo UpdateProductInfo(Model.Shop.Products.ProductInfo productInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_Products SET ");
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
            strSql.Append("Meta_Title=?Title,");
            strSql.Append("Meta_Description=?Meta_Description,");
            strSql.Append("Meta_Keywords=?Meta_Keywords,");
            strSql.Append("SaleStatus=?SaleStatus,");
            strSql.Append("VistiCounts=?VistiCounts,");
            strSql.Append("SaleCounts=?SaleCounts,");
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
            strSql.Append(" WHERE ProductId=?ProductId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
                    new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?BrandId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ProductName", MySqlDbType.VarChar,200),
                    new MySqlParameter("?ProductCode", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
                    new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ShortDescription", MySqlDbType.VarChar,2000),
                    new MySqlParameter("?Unit", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Description", MySqlDbType.Text),
                    new MySqlParameter("?Title", MySqlDbType.VarChar,100),
                    new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
                    new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar,1000),
                    new MySqlParameter("?SaleStatus", MySqlDbType.Int32,4),
                    new MySqlParameter("?VistiCounts", MySqlDbType.Int32,4),
                    new MySqlParameter("?SaleCounts", MySqlDbType.Int32,4),
                    new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?LineId", MySqlDbType.Int32,4),
                    new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?LowestSalePrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?PenetrationStatus", MySqlDbType.Int16,2),
                    new MySqlParameter("?MainCategoryPath", MySqlDbType.VarChar,256),
                    new MySqlParameter("?ExtendCategoryPath", MySqlDbType.VarChar,256),
                    new MySqlParameter("?HasSKU", MySqlDbType.Bit,1),
                    new MySqlParameter("?Points", MySqlDbType.Decimal,9),
                    new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl2", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl3", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl4", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl5", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl6", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl7", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl8", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MaxQuantity", MySqlDbType.Int32,4),
                    new MySqlParameter("?MinQuantity", MySqlDbType.Int32,4),
                    new MySqlParameter("?Tags", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SeoUrl", MySqlDbType.VarChar,300),
                    new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar,300),
                    new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar,300),
                    new MySqlParameter("?SalesType", MySqlDbType.Int16,2),
                    new MySqlParameter("?RestrictionCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
            parameters[0].Value = productInfo.CategoryId;
            parameters[1].Value = productInfo.TypeId;
            parameters[2].Value = productInfo.BrandId;
            parameters[3].Value = productInfo.ProductName;
            parameters[4].Value = productInfo.ProductCode;
            parameters[5].Value = productInfo.SupplierId;
            parameters[6].Value = productInfo.RegionId;
            parameters[7].Value = productInfo.ShortDescription;
            parameters[8].Value = productInfo.Unit;
            parameters[9].Value = productInfo.Description;
            parameters[10].Value = productInfo.Meta_Title;
            parameters[11].Value = productInfo.Meta_Description;
            parameters[12].Value = productInfo.Meta_Keywords;
            parameters[13].Value = productInfo.SaleStatus;
            parameters[14].Value = productInfo.VistiCounts;
            parameters[15].Value = productInfo.SaleCounts;
            parameters[16].Value = productInfo.DisplaySequence;
            parameters[17].Value = productInfo.LineId;
            parameters[18].Value = productInfo.MarketPrice;
            parameters[19].Value = productInfo.LowestSalePrice;
            parameters[20].Value = productInfo.PenetrationStatus;
            parameters[21].Value = productInfo.MainCategoryPath;
            parameters[22].Value = productInfo.ExtendCategoryPath;
            parameters[23].Value = productInfo.HasSKU;
            parameters[24].Value = productInfo.Points;
            parameters[25].Value = productInfo.ImageUrl;
            parameters[26].Value = productInfo.ThumbnailUrl1;
            parameters[27].Value = productInfo.ThumbnailUrl2;
            parameters[28].Value = productInfo.ThumbnailUrl3;
            parameters[29].Value = productInfo.ThumbnailUrl4;
            parameters[30].Value = productInfo.ThumbnailUrl5;
            parameters[31].Value = productInfo.ThumbnailUrl6;
            parameters[32].Value = productInfo.ThumbnailUrl7;
            parameters[33].Value = productInfo.ThumbnailUrl8;
            parameters[34].Value = productInfo.MaxQuantity;
            parameters[35].Value = productInfo.MinQuantity;
            parameters[36].Value = productInfo.Tags;
            parameters[37].Value = productInfo.SeoUrl;
            parameters[38].Value = productInfo.SeoImageAlt;
            parameters[39].Value = productInfo.SeoImageTitle;
            parameters[40].Value = productInfo.SalesType;
            parameters[41].Value = productInfo.RestrictionCount;
            parameters[42].Value = productInfo.ProductId;

            return new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows);
        }

        private CommandInfo GenerateProductInfo(Model.Shop.Products.ProductInfo productInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_Products(");
            strSql.Append("CategoryId,TypeId,BrandId,ProductName,ProductCode,SupplierId,RegionId,ShortDescription,Unit,");
            strSql.Append("Description,Meta_Title,Meta_Description,Meta_Keywords,SaleStatus,AddedDate,VistiCounts,SaleCounts,");
            strSql.Append("DisplaySequence,LineId,MarketPrice,LowestSalePrice,PenetrationStatus,MainCategoryPath,");
            strSql.Append("ExtendCategoryPath,HasSKU,Points,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,");
            strSql.Append("ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8,MaxQuantity,MinQuantity,Tags,SeoUrl,SeoImageAlt,SeoImageTitle,SalesType,RestrictionCount)");
            strSql.Append(" VALUES (");
            strSql.Append("?CategoryId,?TypeId,?BrandId,?ProductName,?ProductCode,?SupplierId,?RegionId,");
            strSql.Append("?ShortDescription,?Unit,?Description,?Title,?Meta_Description,?Meta_Keywords,");
            strSql.Append("?SaleStatus,?AddedDate,?VistiCounts,?SaleCounts,?DisplaySequence,?LineId,?MarketPrice,");
            strSql.Append("?LowestSalePrice,?PenetrationStatus,?MainCategoryPath,?ExtendCategoryPath,?HasSKU,");
            strSql.Append("?Points,?ImageUrl,?ThumbnailUrl1,?ThumbnailUrl2,?ThumbnailUrl3,?ThumbnailUrl4,");
            strSql.Append("?ThumbnailUrl5,?ThumbnailUrl6,?ThumbnailUrl7,?ThumbnailUrl8,?MaxQuantity,?MinQuantity,?Tags,?SeoUrl,?SeoImageAlt,?SeoImageTitle,?SalesType,?RestrictionCount)");
            strSql.Append(";SELECT last_insert_id()");
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
                                new MySqlParameter("?Title", MySqlDbType.VarChar, 100),
                                new MySqlParameter("?Meta_Description", MySqlDbType.VarChar, 1000),
                                new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar, 1000),
                                new MySqlParameter("?SaleStatus", MySqlDbType.Int32, 4),
                                new MySqlParameter("?AddedDate", MySqlDbType.DateTime),
                                new MySqlParameter("?VistiCounts", MySqlDbType.Int32, 4),
                                new MySqlParameter("?SaleCounts", MySqlDbType.Int32, 4),
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
                                new MySqlParameter("?Tags", MySqlDbType.VarChar,50),
                                new MySqlParameter("?SeoUrl", MySqlDbType.VarChar,300),
                                new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar,300),
                                new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar,300),
                              new MySqlParameter("?SalesType", MySqlDbType.Int16,2),
                              new MySqlParameter("?RestrictionCount", MySqlDbType.Int32,4)
                            };
            parameters[0].Value = productInfo.CategoryId;
            parameters[1].Value = productInfo.TypeId;
            parameters[2].Value = productInfo.BrandId;
            parameters[3].Value = productInfo.ProductName;
            parameters[4].Value = productInfo.ProductCode;
            parameters[5].Value = productInfo.SupplierId;
            parameters[6].Value = productInfo.RegionId;
            parameters[7].Value = productInfo.ShortDescription;
            parameters[8].Value = productInfo.Unit;
            parameters[9].Value = productInfo.Description;
            parameters[10].Value = productInfo.Meta_Title;
            parameters[11].Value = productInfo.Meta_Description;
            parameters[12].Value = productInfo.Meta_Keywords;
            parameters[13].Value = productInfo.SaleStatus;
            parameters[14].Value = productInfo.AddedDate;
            parameters[15].Value = productInfo.VistiCounts;
            parameters[16].Value = productInfo.SaleCounts;
            parameters[17].Value = productInfo.DisplaySequence;
            parameters[18].Value = productInfo.LineId;
            parameters[19].Value = productInfo.MarketPrice;
            parameters[20].Value = productInfo.LowestSalePrice;
            parameters[21].Value = productInfo.PenetrationStatus;
            parameters[22].Value = productInfo.MainCategoryPath;
            parameters[23].Value = productInfo.ExtendCategoryPath;
            parameters[24].Value = productInfo.HasSKU;
            parameters[25].Value = productInfo.Points;
            parameters[26].Value = productInfo.ImageUrl;
            parameters[27].Value = productInfo.ThumbnailUrl1;
            parameters[28].Value = productInfo.ThumbnailUrl2;
            parameters[29].Value = productInfo.ThumbnailUrl3;
            parameters[30].Value = productInfo.ThumbnailUrl4;
            parameters[31].Value = productInfo.ThumbnailUrl5;
            parameters[32].Value = productInfo.ThumbnailUrl6;
            parameters[33].Value = productInfo.ThumbnailUrl7;
            parameters[34].Value = productInfo.ThumbnailUrl8;
            parameters[35].Value = productInfo.MaxQuantity;
            parameters[36].Value = productInfo.MinQuantity;
            parameters[37].Value = productInfo.Tags;
            parameters[38].Value = productInfo.SeoUrl;
            parameters[39].Value = productInfo.SeoImageAlt;
            parameters[40].Value = productInfo.SeoImageTitle;
            parameters[41].Value = productInfo.SalesType;
            parameters[42].Value = productInfo.RestrictionCount;
            return new CommandInfo(strSql.ToString(),parameters, EffentNextType.ExcuteEffectRows);
        }

        #endregion 产品信息

        #region 属性

        private List<CommandInfo> GenerateAttributeInfo(Model.Shop.Products.ProductInfo productInfo, MySqlTransaction transaction)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            foreach (Model.Shop.Products.AttributeInfo attributeInfo in productInfo.AttributeInfos)
            {
                switch (Globals.SafeEnum<ProductAttributeModel>(
                    attributeInfo.UsageMode.ToString(CultureInfo.InvariantCulture),
                    ProductAttributeModel.None))
                {
                    case ProductAttributeModel.One:
                        list.Add(GenerateAttribute4One(attributeInfo.AttributeValues[0], productInfo.ProductId));
                        break;

                    case ProductAttributeModel.Input:
                        list.Add(GenerateAttribute4Input(attributeInfo.AttributeValues[0], productInfo.ProductId, transaction));
                        break;

                    case ProductAttributeModel.Any:
                        foreach (Model.Shop.Products.AttributeValue attributeValue in attributeInfo.AttributeValues)
                        {
                            list.Add(GenerateAttribute4One(attributeValue, productInfo.ProductId));
                        }
                        break;
                    default:
                        break;
                }
            }
            return list;
        }

        private CommandInfo GenerateAttribute4Input(Model.Shop.Products.AttributeValue attributeValue, long productId, MySqlTransaction transaction)
        {
            // Insert Input Value
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_AttributeValues(");
            strSql.Append("AttributeId,DisplaySequence,ValueStr,ImageUrl)");
            strSql.Append(" VALUES (");
            strSql.Append("?AttributeId,?DisplaySequence,?ValueStr,?ImageUrl)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
                                            new MySqlParameter("?AttributeId", MySqlDbType.Int64, 8),
                                            new MySqlParameter("?DisplaySequence", MySqlDbType.Int32, 4),
                                            new MySqlParameter("?ValueStr", MySqlDbType.VarChar, 200),
                                            new MySqlParameter("?ImageUrl", MySqlDbType.VarChar, 255)
                                        };
            parameters[0].Value = attributeValue.AttributeId;
            parameters[1].Value = -1;
            parameters[2].Value = attributeValue.ValueStr;
            parameters[3].Value = attributeValue.ImageUrl;

            object obj = DbHelperMySQL.GetSingle4Trans(new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows), transaction);
            attributeValue.ValueId = Globals.SafeInt(obj.ToString(), -1);

            return GenerateAttribute4One(attributeValue, productId);
        }

        private CommandInfo GenerateAttribute4One(Model.Shop.Products.AttributeValue attributeValue, long productId)
        {
            // Insert ValueId
            StringBuilder strSql;
            strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_ProductAttributes(");
            strSql.Append("ProductId,AttributeId,ValueId)");
            strSql.Append(" VALUES (");
            strSql.Append("?ProductId,?AttributeId,?ValueId)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?ValueId", MySqlDbType.Int32, 4)};
            parameters[0].Value = productId;
            parameters[1].Value = attributeValue.AttributeId;
            parameters[2].Value = attributeValue.ValueId;
            return new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows);
        }

        #endregion 属性

        #region SKU

        private List<CommandInfo> GenerateSKUs(Model.Shop.Products.ProductInfo productInfo, MySqlTransaction transaction)
        {
            Dictionary<long, long> specValues = new Dictionary<long, long>();   //Key:ValueId , Value:specId
            List<CommandInfo> list = new List<CommandInfo>();
            foreach (Model.Shop.Products.SKUInfo skuInfo in productInfo.SkuInfos)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO Shop_SKUs(");
                strSql.Append("ProductId,SKU,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling)");
                strSql.Append(" VALUES (");
                strSql.Append("?ProductId,?SKU,?Weight,?Stock,?AlertStock,?CostPrice,?SalePrice,?Upselling)");
                //strSql.Append(";SELECT ?RESULT:=@@IDENTITY;");
                DbParameter[] parameters = {
                                                new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                                                new MySqlParameter("?SKU", MySqlDbType.VarChar, 50),
                                                new MySqlParameter("?Weight", MySqlDbType.Int32, 4),
                                                new MySqlParameter("?Stock", MySqlDbType.Int32, 4),
                                                new MySqlParameter("?AlertStock", MySqlDbType.Int32, 4),
                                                new MySqlParameter("?CostPrice", MySqlDbType.Decimal, 8),
                                                new MySqlParameter("?SalePrice", MySqlDbType.Decimal, 8),
                                                new MySqlParameter("?Upselling", MySqlDbType.Bit, 1)
                                                //,
                                                //DbHelperMySQL.CreateOutParam("?RESULT", MySqlDbType.Int64, 8)//输出主键
                                            };
                parameters[0].Value = productInfo.ProductId;
                parameters[1].Value = skuInfo.SKU;
                parameters[2].Value = skuInfo.Weight;
                parameters[3].Value = skuInfo.Stock;
                parameters[4].Value = skuInfo.AlertStock;
                parameters[5].Value = skuInfo.CostPrice;
                parameters[6].Value = skuInfo.SalePrice;
                parameters[7].Value = skuInfo.Upselling;
                list.Add(new CommandInfo(strSql.ToString(),
                                         parameters, EffentNextType.ExcuteEffectRows));

                foreach (Model.Shop.Products.SKUItem skuItem in skuInfo.SkuItems)
                {
                    if (!specValues.ContainsKey(skuItem.ValueId))
                    {
                        object result = DbHelperMySQL.GetSingle4Trans(GenerateSKUItems(skuItem, productInfo), transaction);
                        long specId = Globals.SafeLong(result.ToString(), -1);

                        specValues.Add(skuItem.ValueId, specId);
                    }

                    strSql = new StringBuilder();
                    strSql.Append("INSERT INTO Shop_SKURelation(");
                    strSql.Append("SkuId,SpecId,ProductId)");
                    strSql.Append(" VALUES (");
                    strSql.Append("(select max(skuid) from shop_skus),?SpecId,?ProductId)");
                    parameters = new[]{
                           // DbHelperMySQL.CreateInputOutParam("?SkuId", MySqlDbType.Int64, 8, null), //输入主键
                            new MySqlParameter("?SpecId", MySqlDbType.Int64,8),
                            new MySqlParameter("?ProductId", MySqlDbType.Int64,8)
                        };
                    //parameters[0].Direction = ParameterDirection.InputOutput;
                    parameters[0].Value = specValues[skuItem.ValueId];
                    parameters[1].Value = productInfo.ProductId;

                    list.Add(new CommandInfo(strSql.ToString(),
                                         parameters, EffentNextType.ExcuteEffectRows));
                }
            }
            return list;
        }

        //TODO: 说明代码
        private CommandInfo CheckSkuItems(Model.Shop.Products.ProductInfo oldProductInfo, Model.Shop.Products.ProductInfo newProductInfo)
        {
            DataTable oldSKUItem = new DataTable(); //DB
            List<Model.Shop.Products.SKUItem> newSKUItem = new List<Model.Shop.Products.SKUItem>(); //页面

            foreach (DataRow row in oldSKUItem.Rows)
            {
                //NULL
                string imgURL = row["ImageUrl"].ToString();
                if (!newSKUItem.Exists(xx => xx.ImageUrl == imgURL))
                {
                    //DEL File 物理删除
                }
            }

            return null;
        }

        private CommandInfo GenerateSKUItems(Model.Shop.Products.SKUItem skuItem, Model.Shop.Products.ProductInfo productInfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_SKUItems(");
            strSql.Append("AttributeId,ValueId,ImageUrl,ValueStr,ProductId)");
            strSql.Append(" VALUES (");
            strSql.Append("?AttributeId,?ValueId,?ImageUrl,?ValueStr,?ProductId)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = new[]{
                            new MySqlParameter("?AttributeId", MySqlDbType.Int64,8),
                            new MySqlParameter("?ValueId", MySqlDbType.Int64,8),
                            new MySqlParameter("?ImageUrl", MySqlDbType.VarChar),
                            new MySqlParameter("?ValueStr", MySqlDbType.VarChar),
                            new MySqlParameter("?ProductId", MySqlDbType.Int64,8)
                        };
            parameters[0].Value = skuItem.AttributeId;
            parameters[1].Value = skuItem.ValueId;
            parameters[2].Value = skuItem.ImageUrl;
            parameters[3].Value = skuItem.ValueStr;
            parameters[4].Value = productInfo.ProductId;
            return new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows);
        }

        #endregion SKU

        #region Package

        private List<CommandInfo> GeneratePackage(Model.Shop.Products.ProductInfo productInfo)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            if (productInfo.PackageId != null)
            {
                foreach (int PackageId in productInfo.PackageId)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into Shop_ProductPackage(");
                    strSql.Append("ProductId,PackageId)");
                    strSql.Append(" values (");
                    strSql.Append("?ProductId,?PackageId)");
                    MySqlParameter[] parameters =
                        {
                            new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                            new MySqlParameter("?PackageId", MySqlDbType.Int32, 4)
                        };
                    parameters[0].Value = productInfo.ProductId;
                    parameters[1].Value = PackageId;
                    list.Add(new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows));
                }
            }
            return list;
        }
        #endregion

        #region 图片

        private List<CommandInfo> GenerateImages(Model.Shop.Products.ProductInfo productInfo)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            foreach (Model.Shop.Products.ProductImage productImage in productInfo.ProductImages)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO Shop_ProductImages(");
                strSql.Append("ProductId,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8)");
                strSql.Append(" VALUES (");
                strSql.Append("?ProductId,?ImageUrl,?ThumbnailUrl1,?ThumbnailUrl2,?ThumbnailUrl3,?ThumbnailUrl4,?ThumbnailUrl5,?ThumbnailUrl6,?ThumbnailUrl7,?ThumbnailUrl8)");
                strSql.Append(";SELECT last_insert_id()");
                MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
                    new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl2", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl3", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl4", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl5", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl6", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl7", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ThumbnailUrl8", MySqlDbType.VarChar,255)};
                parameters[0].Value = productInfo.ProductId;    //产品主键
                parameters[1].Value = productImage.ImageUrl;
                parameters[2].Value = productImage.ThumbnailUrl1;
                parameters[3].Value = productImage.ThumbnailUrl2;
                parameters[4].Value = productImage.ThumbnailUrl3;
                parameters[5].Value = productImage.ThumbnailUrl4;
                parameters[6].Value = productImage.ThumbnailUrl5;
                parameters[7].Value = productImage.ThumbnailUrl6;
                parameters[8].Value = productImage.ThumbnailUrl7;
                parameters[9].Value = productImage.ThumbnailUrl8;

                list.Add(new CommandInfo(strSql.ToString(),
                                         parameters, EffentNextType.ExcuteEffectRows));
            }
            return list;
        }

        #endregion 图片

       
        //#region 添加配件  
        //private List<CommandInfo> GenerateAccessories(Model.Shop.Products.ProductInfo productInfo)
        //{
        //    List<CommandInfo> list = new List<CommandInfo>();
        //    foreach (Model.Shop.Products.ProductAccessorie productAccess in productInfo.ProductAccessories)
        //    {
        //        StringBuilder strSql = new StringBuilder();
        //        strSql.Append("INSERT INTO Shop_AccessoriesValues (");
        //        strSql.Append(" ProductAccessoriesId ,ProductAccessoriesSKU)");
        //        strSql.Append(" VALUES  ((SELECT ProductId FROM Shop_SKUs WHERE SkuId=?ProductAccessoriesSKU),?ProductAccessoriesSKU)");
        //        strSql.Append(";SELECT ?RESULT = last_insert_id()");
        //        MySqlParameter[] parameters ={
        //                                  new MySqlParameter("?ProductAccessoriesSKU",MySqlDbType.VarChar),
        //                                        DbHelperMySQL.CreateOutParam("?RESULT", MySqlDbType.Int64, 8)//输出主键
        //                                  };
        //        parameters[0].Value = productAccess.SkuId;

        //        list.Add(new CommandInfo(strSql.ToString(),
        //                                 parameters, EffentNextType.ExcuteEffectRows));

        //        strSql = new StringBuilder();
        //        strSql.Append("INSERT INTO Shop_ProductAccessories(");
        //        strSql.Append("ProductId ,AccessoriesValueId ,Name ,MaxQuantity ,MinQuantity ,DiscountType ,DiscountAmount)");
        //        strSql.Append(" VALUES (");
        //        strSql.Append("?ProductId ,?AccessoriesValueId ,?AccessoriesName ,?MaxQuantity ,?MinQuantity ,?DiscountType ,?DiscountAmount)");
        //        MySqlParameter[] param ={
        //                             new MySqlParameter("?ProductId",MySqlDbType.Int64,8),
        //                            DbHelperMySQL.CreateInputOutParam("?AccessoriesValueId", MySqlDbType.Int64, 8, null), //输入主键
        //                             new MySqlParameter("?Name",MySqlDbType.VarChar),
        //                             new MySqlParameter("?MaxQuantity",MySqlDbType.Int32),
        //                             new MySqlParameter("?MinQuantity",MySqlDbType.Int32),
        //                             new MySqlParameter("?DiscountType",MySqlDbType.Int32),
        //                             new MySqlParameter("?DiscountAmount",MySqlDbType.Int32)
        //                             };
        //        param[0].Value = productInfo.ProductId;
        //        param[2].Value = productAccess.Name;
        //        param[3].Value = productAccess.MaxQuantity;
        //        param[4].Value = productAccess.MinQuantity;
        //        param[5].Value = productAccess.DiscountType;
        //        param[6].Value = productAccess.DiscountAmount;
        //        list.Add(new CommandInfo(strSql.ToString(), param, EffentNextType.ExcuteEffectRows));
        //    }
        //    return list;
        //}
 
     //   #endregion 添加配件

        #region 相关商品

        private List<CommandInfo> GenerateRelatedProduct(Model.Shop.Products.ProductInfo productInfo)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            if (productInfo.RelatedProductId==null||productInfo.RelatedProductId.Length == 0) return list;
            foreach (string item in productInfo.RelatedProductId)
            {
                string[] relatedPid = item.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                if (Globals.SafeInt(relatedPid[1], 0) == 0)
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("INSERT INTO Shop_RelatedProducts(");
                    strSql.Append(" RelatedId, ProductId )");
                    strSql.Append("VALUES  (");
                    strSql.Append("?RelatedId,?ProductId)");
                    MySqlParameter[] parameters = {
                                                        new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                                                        new MySqlParameter("?RelatedId", MySqlDbType.Int64, 8)
                                                    };
                    parameters[0].Value = productInfo.ProductId;
                    parameters[1].Value = Globals.SafeLong(relatedPid[0], -1);

                    list.Add(new CommandInfo(strSql.ToString(),
                                             parameters, EffentNextType.ExcuteEffectRows));
                }
                else
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("INSERT INTO Shop_RelatedProducts(");
                    strSql.Append(" RelatedId, ProductId )");
                    strSql.Append("VALUES  (");
                    strSql.Append("?RelatedId,?ProductId)");
                    MySqlParameter[] parameters = {
                                                        new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                                                        new MySqlParameter("?RelatedId", MySqlDbType.Int64, 8)
                                                    };
                    parameters[0].Value = productInfo.ProductId;
                    parameters[1].Value = Globals.SafeLong(relatedPid[0], -1);

                    list.Add(new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows));

                    StringBuilder strSqlRe = new StringBuilder();
                    strSqlRe.Append("INSERT INTO Shop_RelatedProducts(");
                    strSqlRe.Append(" RelatedId, ProductId )");
                    strSqlRe.Append("VALUES  (");
                    strSqlRe.Append("?RelatedId,?ProductId)");
                    MySqlParameter[] para = {
                                                        new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                                                        new MySqlParameter("?RelatedId", MySqlDbType.Int64, 8)
                                                    };
                    para[0].Value = Globals.SafeLong(relatedPid[0], -1);
                    para[1].Value = productInfo.ProductId;

                    list.Add(new CommandInfo(strSqlRe.ToString(), para, EffentNextType.ExcuteEffectRows));
                }
            }
            return list;
        }

        #endregion 相关商品

        #region 添加产品分类

        private List<CommandInfo> SaveProductCategories(Model.Shop.Products.ProductInfo productInfo)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            foreach (string productCategory in productInfo.Product_Categories)
            {
                if (!string.IsNullOrWhiteSpace(productCategory))
                {
                    string[] categoryArray = productCategory.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    int categoryId = Globals.SafeInt(categoryArray[0], 0);
                    list.Add(GeneratePaoductCategoriesOne(categoryId, productInfo.ProductId, categoryArray[1]));
                }
            }
            return list;
        }

        private CommandInfo GeneratePaoductCategoriesOne(int categoriesId, long productId, string path)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_ProductCategories ( CategoryId, ProductId,CategoryPath ) ");
            strSql.Append(" VALUES (");
            strSql.Append("?CategoryId,?ProductId,?CategoryPath)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?CategoryId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?CategoryPath", MySqlDbType.VarChar)
                                        };
            parameters[0].Value = productId;
            parameters[1].Value = categoriesId;
            parameters[2].Value = path;
            return new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows);
        }

        #endregion 添加产品分类

        #region 添加店铺产品分类

        private List<CommandInfo> SaveSuppProductCategories(Model.Shop.Products.ProductInfo productInfo)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_SuppProductCategories ( CategoryId, ProductId,CategoryPath ) ");
            strSql.Append(" VALUES (");
            strSql.Append("?CategoryId,?ProductId,?CategoryPath)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64, 8),
                    new MySqlParameter("?CategoryId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?CategoryPath", MySqlDbType.VarChar)
                                        };
            parameters[0].Value = productInfo.ProductId;
            parameters[1].Value = productInfo.SuppCategoryId;
            parameters[2].Value = productInfo.SuppCategoryPath;
            list.Add(new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows));
            return list;
        }
        private List<CommandInfo> UpdateSuppProductCategories(Model.Shop.Products.ProductInfo productInfo)
        {
            List<CommandInfo> list = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_SuppProductCategories set ");
            strSql.Append("CategoryPath=?CategoryPath ,");
            strSql.Append(" CategoryId=?CategoryId");
            strSql.Append(" where and ProductId=?ProductId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CategoryPath", MySqlDbType.VarChar,4000),
                    new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
            parameters[0].Value = productInfo.SuppCategoryPath;
            parameters[1].Value = productInfo.SuppCategoryId;
            parameters[2].Value = productInfo.SuppCategoryPath;
            list.Add(new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows));
            return list;
        }

        #endregion 添加产品分类

        #region 产品对比
        public DataSet GetCompareProudctInfo(string ids)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("_ProductIDs", MySqlDbType.VarChar)
                    };
            parameters[0].Value = ids;
            return DbHelperMySQL.RunProcedure("sp_Shop_CompareProduct", parameters, "ds");
        }

        public DataSet GetCompareProudctBasicInfo(string ids)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("_ProductIDs", MySqlDbType.VarChar)
                    };
            parameters[0].Value = ids;
            return DbHelperMySQL.RunProcedure("sp_Shop_CompareProductBasicInfo", parameters, "ds");
        }
        #endregion

        #region 产品推荐
        private CommandInfo GenerateProductStationModes(Model.Shop.Products.ProductInfo productInfo, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE Shop_ProductStationModes WHERE ProductId = ?ProductId AND Type = ?Type; ");
            strSql.Append("INSERT INTO Shop_ProductStationModes(");
            strSql.Append("ProductId,DisplaySequence,Type)");
            strSql.Append(" VALUES (");
            strSql.Append("?ProductId,?DisplaySequence,?Type)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("?ProductId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?DisplaySequence", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Type", MySqlDbType.Int32, 4)
                };
            parameters[0].Value = productInfo.ProductId;
            parameters[1].Value = productInfo.ProductId;
            parameters[2].Value = type;
            return new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows);
        }
        private CommandInfo DelProductStationModes(Model.Shop.Products.ProductInfo productInfo, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE Shop_ProductStationModes WHERE ProductId = ?ProductId AND Type = ?Type; ");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("?ProductId", MySqlDbType.Int32, 4),
                    new MySqlParameter("?Type", MySqlDbType.Int32, 4)
                };
            parameters[0].Value = productInfo.ProductId;
            parameters[1].Value = type;
            return new CommandInfo(strSql.ToString(),
                                    parameters, EffentNextType.ExcuteEffectRows);
        }
        #endregion

        public bool ModifyPMSProduct(Model.Shop.Products.ProductInfo productInfo)
        {
            throw new NotImplementedException();
        }
        public bool ModifyStock(string sku, int stock)
        {
            throw new NotImplementedException();
        }

        public bool AddPMSProduct(Model.Shop.Products.ProductInfo productInfo)
        {
            throw new NotImplementedException();
        }

        public bool ImportModifyProduct(Model.Shop.Products.ProductInfo productInfo)
        {
            throw new NotImplementedException();
        }
    }
}