/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：SKUs.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:34
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.DBUtility;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using YSWL.MALL.Model.Shop.Products;

namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// 数据访问类:SKUInfo
    /// </summary>
    public partial class SKUInfo : ISKUInfo
    {
        public SKUInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long SkuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_SKUs");
            strSql.Append(" WHERE SkuId=?SkuId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64)
            };
            parameters[0].Value = SkuId;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Products.SKUInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_SKUs(");
            strSql.Append("ProductId,SKU,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling)");
            strSql.Append(" VALUES (");
            strSql.Append("?ProductId,?SKU,?Weight,?Stock,?AlertStock,?CostPrice,?SalePrice,?Upselling)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
                    new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Weight", MySqlDbType.Int32,4),
                    new MySqlParameter("?Stock", MySqlDbType.Int32,4),
                    new MySqlParameter("?AlertStock", MySqlDbType.Int32,4),
                    new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?SalePrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Upselling", MySqlDbType.Bit,1)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.SKU;
            parameters[2].Value = model.Weight;
            parameters[3].Value = model.Stock;
            parameters[4].Value = model.AlertStock;
            parameters[5].Value = model.CostPrice;
            parameters[6].Value = model.SalePrice;
            parameters[7].Value = model.Upselling;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.SKUInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_SKUs SET ");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("SKU=?SKU,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("Stock=?Stock,");
            strSql.Append("AlertStock=?AlertStock,");
            strSql.Append("CostPrice=?CostPrice,");
            strSql.Append("SalePrice=?SalePrice,");
            strSql.Append("Upselling=?Upselling");
            strSql.Append(" WHERE SkuId=?SkuId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
                    new MySqlParameter("?SKU", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Weight", MySqlDbType.Int32,4),
                    new MySqlParameter("?Stock", MySqlDbType.Int32,4),
                    new MySqlParameter("?AlertStock", MySqlDbType.Int32,4),
                    new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?SalePrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Upselling", MySqlDbType.Bit,1),
                    new MySqlParameter("?SkuId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.SKU;
            parameters[2].Value = model.Weight;
            parameters[3].Value = model.Stock;
            parameters[4].Value = model.AlertStock;
            parameters[5].Value = model.CostPrice;
            parameters[6].Value = model.SalePrice;
            parameters[7].Value = model.Upselling;
            parameters[8].Value = model.SkuId;

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
        public bool Delete(long SkuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_SKUs ");
            strSql.Append(" WHERE SkuId=?SkuId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64)
            };
            parameters[0].Value = SkuId;

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
        public bool DeleteList(string SkuIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_SKUs ");
            strSql.Append(" WHERE SkuId in (" + SkuIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.SKUInfo GetModel(long SkuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SkuId,ProductId,SKU,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling FROM Shop_SKUs ");
            strSql.Append(" WHERE SkuId=?SkuId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuId", MySqlDbType.Int64)
            };
            parameters[0].Value = SkuId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.SKUInfo model = new YSWL.MALL.Model.Shop.Products.SKUInfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SkuId"] != null && ds.Tables[0].Rows[0]["SkuId"].ToString() != "")
                {
                    model.SkuId = long.Parse(ds.Tables[0].Rows[0]["SkuId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"] != null && ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SKU"] != null && ds.Tables[0].Rows[0]["SKU"].ToString() != "")
                {
                    model.SKU = ds.Tables[0].Rows[0]["SKU"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Weight"] != null && ds.Tables[0].Rows[0]["Weight"].ToString() != "")
                {
                    model.Weight = int.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Stock"] != null && ds.Tables[0].Rows[0]["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(ds.Tables[0].Rows[0]["Stock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlertStock"] != null && ds.Tables[0].Rows[0]["AlertStock"].ToString() != "")
                {
                    model.AlertStock = int.Parse(ds.Tables[0].Rows[0]["AlertStock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CostPrice"] != null && ds.Tables[0].Rows[0]["CostPrice"].ToString() != "")
                {
                    model.CostPrice = decimal.Parse(ds.Tables[0].Rows[0]["CostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SalePrice"] != null && ds.Tables[0].Rows[0]["SalePrice"].ToString() != "")
                {
                    model.SalePrice = decimal.Parse(ds.Tables[0].Rows[0]["SalePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Upselling"] != null && ds.Tables[0].Rows[0]["Upselling"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Upselling"].ToString() == "1") || (ds.Tables[0].Rows[0]["Upselling"].ToString().ToLower() == "true"))
                    {
                        model.Upselling = true;
                    }
                    else
                    {
                        model.Upselling = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SkuId,ProductId,SKU,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling ");
            strSql.Append(" FROM Shop_SKUs ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            
            strSql.Append(" SkuId,ProductId,SKU,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling ");
            strSql.Append(" FROM Shop_SKUs ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
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
            strSql.Append("SELECT COUNT(1) FROM Shop_SKUs ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
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
            strSql.Append("SELECT T.* from Shop_SKUs T ");
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
                strSql.Append(" order by T.SkuId desc");
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
            parameters[0].Value = "Shop_SKUs";
            parameters[1].Value = "SkuId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        #region NewMethod
        /// <summary>
        /// 分页获取SKU胶塑列表
        /// </summary>
        public DataSet GetSKUListByPage(string strWhere, string orderby, int startIndex, int endIndex, out int dataCount,long productId)
        {
            //            StringBuilder strSql = new StringBuilder();
            //            strSql.Append("SELECT * FROM ( ");
            //            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //            if (!string.IsNullOrWhiteSpace(orderby))
            //            {
            //                strSql.Append("ORDER BY T." + orderby);
            //            }
            //            else
            //            {
            //                strSql.Append("ORDER BY T.SkuId desc");
            //            }
            //            strSql.Append(")AS Row, T.*  FROM " +
            //                          @"(SELECT SP.* ,
            //                                    SI.AttributeId ,
            //                                    SI.ValueId ,
            //                                    AV.ValueStr
            //                            FROM    ( SELECT    S.* ,
            //                                                P.ProductName
            //                                        FROM      Shop_SKUs S
            //                                                LEFT JOIN Shop_Products P ON S.ProductId = P.ProductId");
            //            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //            {
            //                strSql.Append(" WHERE " + strWhere);
            //            }
            //            strSql.Append(@" ) SP ,
            //                                    Shop_SKUItems SI ,
            //                                    Shop_AttributeValues AV
            //                            WHERE   SP.SkuId = SI.SkuId AND AV.AttributeId = SI.AttributeId
            //                            AND AV.ValueId = SI.ValueId) T ");
            //            strSql.Append(" ) TT");
            //            strSql.AppendFormat(" WHERE TT.Row BETWEEN {0} AND {1}", startIndex, endIndex);
            //            return DbHelperMySQL.Query(strSql.ToString());
            //if (!string.IsNullOrWhiteSpace(strWhere))
            //{
            //    strWhere = strWhere.Insert(0, " AND ");
            //}
            MySqlParameter[] parameters = {
                                            new MySqlParameter("_SqlWhere", MySqlDbType.VarChar, 4000),
                                            new MySqlParameter("_OrderBy", MySqlDbType.VarChar, 1000),
                                            new MySqlParameter("_StartIndex", MySqlDbType.Int32, 4),
                                            new MySqlParameter("_EndIndex", MySqlDbType.Int32, 4),
                                            new MySqlParameter("_ProductId", MySqlDbType.Int64, 8),
                                            new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4)
                                        };
            parameters[0].Value = strWhere;
            parameters[1].Value = orderby;
            parameters[2].Value = startIndex;
            parameters[3].Value = endIndex;
            parameters[4].Value = productId;
            parameters[5].Direction = ParameterDirection.ReturnValue;
            return DbHelperMySQL.RunProcedure("sp_Shop_ProductSkuInfo_Get", parameters, "ProductSkuInfo", out dataCount);
        }


        public DataSet PrductsSkuInfo(long prductId)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT A.*,B.SpecId,AttributeId,B.ValueId,ValueStr  ");
            //strSql.Append("FROM Shop_SKUs A ");
            //strSql.Append("LEFT JOIN (SELECT C.SpecId,AttributeId,c.ValueId,ValueStr,SkuId FROM Shop_SKUItems C ");
            //strSql.Append("LEFT  JOIN Shop_SKURelation D ON  C.SpecId = D.SpecId)B ON A.SkuId = B.SkuId ");
            strSql.Append("SELECT * FROM  Shop_SKUs ");
            strSql.Append("WHERE ProductId=?ProducId ");
            MySqlParameter[] parameters = { 
                                        new MySqlParameter("?ProducId",MySqlDbType.Int64,8)
                                        };
            parameters[0].Value = prductId;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <remarks>prductId 编辑时使用, 排除自己</remarks>
        public bool Exists(string skuCode, long prductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_SKUs");
            strSql.Append(" WHERE SKU=?SkuCode");
            if (prductId > 0)
            {
                strSql.Append(" AND ProductId<>" + prductId);
            }
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SkuCode", MySqlDbType.VarChar)
            };
            parameters[0].Value = skuCode;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        public int GetStockById(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(Stock)Stock FROM Shop_SKUs ");
            strSql.Append("WHERE ProductId=?ProductId ");

            MySqlParameter[] parameters = {
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

        public int GetStockBySKU(string SKU,bool IsOpenAS)
        {

            StringBuilder strSql = new StringBuilder();
            if (IsOpenAS)
            {
                strSql.Append("SELECT SUM(Stock-AlertStock)AlertStock FROM Shop_SKUs ");
            }
            else
            {
                strSql.Append("SELECT SUM(Stock)Stock FROM Shop_SKUs ");
            }
         
            strSql.Append("WHERE SKU=?SKU ");

            MySqlParameter[] parameters = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = SKU;
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
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Products.SKUInfo GetModelBySKU(string sku)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SkuId,ProductId,SKU,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling FROM Shop_SKUs ");
            strSql.Append(" WHERE SKU=?SKU");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SKU", MySqlDbType.VarChar,50)
            };
            parameters[0].Value = sku;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.SKUInfo model = new YSWL.MALL.Model.Shop.Products.SKUInfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SkuId"] != null && ds.Tables[0].Rows[0]["SkuId"].ToString() != "")
                {
                    model.SkuId = long.Parse(ds.Tables[0].Rows[0]["SkuId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"] != null && ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SKU"] != null && ds.Tables[0].Rows[0]["SKU"].ToString() != "")
                {
                    model.SKU = ds.Tables[0].Rows[0]["SKU"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Weight"] != null && ds.Tables[0].Rows[0]["Weight"].ToString() != "")
                {
                    model.Weight = int.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Stock"] != null && ds.Tables[0].Rows[0]["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(ds.Tables[0].Rows[0]["Stock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlertStock"] != null && ds.Tables[0].Rows[0]["AlertStock"].ToString() != "")
                {
                    model.AlertStock = int.Parse(ds.Tables[0].Rows[0]["AlertStock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CostPrice"] != null && ds.Tables[0].Rows[0]["CostPrice"].ToString() != "")
                {
                    model.CostPrice = decimal.Parse(ds.Tables[0].Rows[0]["CostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SalePrice"] != null && ds.Tables[0].Rows[0]["SalePrice"].ToString() != "")
                {
                    model.SalePrice = decimal.Parse(ds.Tables[0].Rows[0]["SalePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Upselling"] != null && ds.Tables[0].Rows[0]["Upselling"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Upselling"].ToString() == "1") || (ds.Tables[0].Rows[0]["Upselling"].ToString().ToLower() == "true"))
                    {
                        model.Upselling = true;
                    }
                    else
                    {
                        model.Upselling = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }


       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <remarks>添加组合商品时，判断这个sku是否是自己的</remarks>
        public bool ExistsEx(string SKU, long prductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_SKUs");
            strSql.Append(" WHERE SKU=?SKU");
            strSql.Append(" AND ProductId=" + prductId);
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SKU", MySqlDbType.VarChar)
            };
            parameters[0].Value = SKU;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListInnerJoinProd(string strWhere)
        {
            //SELECT s.*,p.ProductName AS  Shop_Products,p.ThumbnailUrl1 AS ThumbnailUrl1   FROM Shop_SKUs s INNER JOIN     Shop_Products p ON  s.ProductId=p.ProductId

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT s.*,p.ProductName AS  ProductName ,p.ThumbnailUrl1 AS ThumbnailUrl1   ");
            strSql.Append(" FROM Shop_SKUs s");
            strSql.Append(" INNER JOIN  Shop_Products p ON  s.ProductId=p.ProductId ");   
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取SKU数据列表
        /// </summary>
        public DataSet GetSKUList(string strWhere,int AccessoriesId ,  string orderby , long productId)
        { 
            MySqlParameter[] parameters = {
                                            new MySqlParameter("_SqlWhere", MySqlDbType.VarChar, 4000),
                                            new MySqlParameter("_OrderBy", MySqlDbType.VarChar, 1000), 
                                            new MySqlParameter("_AccessoriesId", MySqlDbType.Int32), 
                                            new MySqlParameter("_ProductId", MySqlDbType.Int64, 8)
                                        };
            parameters[0].Value = strWhere;
            parameters[1].Value = orderby;
            parameters[2].Value = AccessoriesId;
            parameters[3].Value = productId;
            return DbHelperMySQL.RunProcedure("sp_Shop_ProductSkuInfo_NotPage_GetProdAcce", parameters, "ProductSkuInfoGetProdAcce");
        }

        /// <summary>
        /// 根据商品分类 获取SKU
        /// </summary>
        /// <param name="Cid"></param>
        /// <returns></returns>
        public DataSet GetSKUListByCid(int Cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * ");
            strSql.Append(" FROM Shop_SKUs K ");
            strSql.Append(" WHERE   EXISTS ( SELECT ProductId FROM   Shop_Products P WHERE  P.SaleStatus = 1  ");
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =P.ProductId  ");
                strSql.AppendFormat(
              "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ) , '|%') ",
              Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            strSql.Append("   AND P.ProductId = K.ProductId ) ");
            return DbHelperMySQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 根据商品分类 获取SKU
        /// </summary>
        /// <param name="Cid"></param>
        /// <returns></returns>
        public DataSet GetSKUListEx(int Cid, int supplierId, string productName, string productNum, bool showAlert=false)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * ");
            strSql.Append(" FROM Shop_SKUs K ");
            strSql.Append(" WHERE   EXISTS ( SELECT ProductId FROM   Shop_Products P WHERE  P.SaleStatus = 1  ");
            //查询分类
            if (Cid > 0)
            {
                strSql.AppendFormat(
                    " AND EXISTS ( SELECT *  FROM   Shop_ProductCategories WHERE  ProductId =P.ProductId  ");
                strSql.AppendFormat(
              "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ) , '|%') ",
              Cid);
                strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0}))", Cid);
            }
            if (supplierId !=0)
            {
                strSql.AppendFormat(
                    " AND  P.SupplierId={0} ",supplierId);
            }
            if (!string.IsNullOrWhiteSpace(productName))
            {
                strSql.AppendFormat(
                   " AND   P.ProductName LIKE '%{0}%' ", Common.InjectionFilter.SqlFilter(productName));
            }
            if (!string.IsNullOrWhiteSpace(productNum))
            {
                strSql.AppendFormat(
                   " AND  P.ProductCode LIKE '%{0}%' ", Common.InjectionFilter.SqlFilter(productNum));
            }
            if (showAlert)
            {
                strSql.Append("  AND  K.Stock<=K.AlertStock  ");
            }
            strSql.Append("   AND P.ProductId = K.ProductId ) ");
            return DbHelperMySQL.Query(strSql.ToString());
        }






        /// <summary>
        /// 获取分销商库存
        /// </summary>
        /// <param name="SkuInfo"></param>
        /// <param name="Stock"></param>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public bool UpdateSuppStock(YSWL.MALL.Model.Shop.Products.SKUInfo SkuInfo, int Stock,int supplierId)
        {
            #region 事务处理数据
            YSWL.MALL.MySqlDAL.Shop.Distribution.SuppDistProduct distProductBll = new Distribution.SuppDistProduct();
            YSWL.MALL.MySqlDAL.Shop.Distribution.SuppDistSKU distSkuBll = new Distribution.SuppDistSKU();
            // 首先 获取商品
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo();
            string ProductTable = "Shop_SuppDistProduct_" + supplierId;
            if (!distProductBll.Exists(supplierId, SkuInfo.ProductId))
            {
                StringBuilder strSql = new StringBuilder();
                distProductBll.CreateTab(supplierId);
                strSql.Append("insert into " + ProductTable + " (");
                strSql.Append("ProductId,TypeId,BrandId,ProductName,SaleStatus,AddedDate,SaleCounts,MarketPrice,Stock,LowestSalePrice,HasSKU,DisplaySequence,ImageUrl,ThumbnailUrl1)");
                strSql.Append(" Select ProductId,TypeId,BrandId,ProductName,SaleStatus,AddedDate,SaleCounts,MarketPrice,0,LowestSalePrice,HasSKU,DisplaySequence,ImageUrl,ThumbnailUrl1 ");
                strSql.Append(" from Shop_Products where productId=?ProductId ");
                MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)
                                            };
                parameters[0].Value = SkuInfo.ProductId;
                cmd = new CommandInfo(strSql.ToString(), parameters);
                sqllist.Add(cmd);
            }
            
            //更新分销商库存
            if (distProductBll.TabExists(supplierId))
            {
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("update " + ProductTable + " set ");
                strSql2.Append("Stock=Stock+?Stock");
                strSql2.Append(" where ProductId=?ProductId ");
                MySqlParameter[] parameters2 = {
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
                parameters2[0].Value = Stock;
                parameters2[1].Value = SkuInfo.ProductId;
                cmd = new CommandInfo(strSql2.ToString(), parameters2);
                sqllist.Add(cmd);
            }
           //更新商品SKU的库存
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("UPDATE Shop_SKUs SET ");
            strSql3.Append("Stock=Stock-?Stock");
            strSql3.Append(" WHERE SkuId=?SkuId");
            MySqlParameter[] parameters3 = {
                    new MySqlParameter("?Stock", MySqlDbType.Int32,4),
                    new MySqlParameter("?SkuId", MySqlDbType.Int64,8)};
            parameters3[0].Value = Stock;
            parameters3[1].Value = SkuInfo.SkuId;
            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //添加分销商SKU
            string SkuTable = "Shop_SuppDistSKU_" + supplierId;
            if (!distSkuBll.Exists(supplierId, SkuInfo.SKU))
            {
                StringBuilder strSql4 = new StringBuilder();
                distSkuBll.CreateTab(supplierId);
                strSql4.Append("insert into " + SkuTable + "(");
                strSql4.Append("SKU,ProductId,Weight,Stock,AlertStock,CostPrice,SalePrice,Upselling)");
                strSql4.Append(" Select SKU,ProductId,Weight,0,AlertStock,CostPrice,SalePrice,Upselling ");
                strSql4.Append(" from Shop_SKUs where SKU=?SKU  ");
                MySqlParameter[] parameters4 = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)
                                            };
                parameters4[0].Value = SkuInfo.SKU;
                cmd = new CommandInfo(strSql4.ToString(), parameters4);
                sqllist.Add(cmd);
            }
            //更新分销商库存
            if (distSkuBll.TabExists(supplierId))
            {
                StringBuilder strSql5 = new StringBuilder();
                strSql5.Append("update " + SkuTable + " set ");
                strSql5.Append("Stock=Stock+?Stock");
                strSql5.Append(" where  SKU=?SKU ");
                MySqlParameter[] parameters5 = {
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)};
                parameters5[0].Value = Stock;
                parameters5[1].Value = SkuInfo.SKU;
                cmd = new CommandInfo(strSql5.ToString(), parameters5);
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
            #endregion 
        }
        /// <summary>
        /// 根据商品id获取该商品的sku数
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int skuCount(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT COUNT(*)  FROM  Shop_SKUs ");
            strSql.Append(" where ProductId =?ProductId ");
            MySqlParameter[] parameters = {
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

        bool ISKUInfo.Exists(long SkuId)
        {
            throw new NotImplementedException();
        }

        long ISKUInfo.Add(Model.Shop.Products.SKUInfo model)
        {
            throw new NotImplementedException();
        }

        bool ISKUInfo.Update(Model.Shop.Products.SKUInfo model)
        {
            throw new NotImplementedException();
        }

        bool ISKUInfo.Delete(long SkuId)
        {
            throw new NotImplementedException();
        }

        bool ISKUInfo.DeleteList(string SkuIdlist)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Products.SKUInfo ISKUInfo.GetModel(long SkuId)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        int ISKUInfo.GetRecordCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetSKUListByPage(string strWhere, string orderby, int startIndex, int endIndex, out int dataCount, long productId)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.PrductsSkuInfo(long prductId)
        {
            throw new NotImplementedException();
        }

        bool ISKUInfo.Exists(string skuCode, long prductId)
        {
            throw new NotImplementedException();
        }

        int ISKUInfo.GetStockById(long productId)
        {
            throw new NotImplementedException();
        }

        int ISKUInfo.GetStockBySKU(string SKU, bool IsOpenAS)
        {
            throw new NotImplementedException();
        }

        Model.Shop.Products.SKUInfo ISKUInfo.GetModelBySKU(string sku)
        {
            throw new NotImplementedException();
        }

        bool ISKUInfo.ExistsEx(string SKU, long prductId)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetListInnerJoinProd(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetSKUList(string strWhere, int AccessoriesId, string orderby, long productId)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetSKUListByCid(int cid)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetSKUListEx(int Cid, int supplierId, string productName, string productNum, bool showAlert)
        {
            throw new NotImplementedException();
        }

        bool ISKUInfo.UpdateSuppStock(Model.Shop.Products.SKUInfo SkuInfo, int Stock, int supplierId)
        {
            throw new NotImplementedException();
        }

        DataSet ISKUInfo.GetSKUListByPage(string keyw, int startIndex, int endIndex, string orderby)
        {
            throw new NotImplementedException();
        }

        int ISKUInfo.GetSKURecordCount(string keyw)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

