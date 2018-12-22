/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：Brands.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/12 10:02:40
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
    /// 数据访问类:BrandInfo
    /// </summary>
    public partial class BrandInfo : IBrandInfo
    {
        public BrandInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("BrandId", "Shop_Brands");
        }

        /// <summary>
        /// 得到最大顺序
        /// </summary>
        public int GetMaxDisplaySequence()
        {
            return DbHelperMySQL.GetMaxID("DisplaySequence", "Shop_Brands");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BrandId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_Brands");
            strSql.Append(" WHERE BrandId=?BrandId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = BrandId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Products.BrandInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_Brands(");
            strSql.Append("BrandName,BrandSpell,Meta_Description,Meta_Keywords,Logo,CompanyUrl,Description,DisplaySequence,Theme)");
            strSql.Append(" VALUES (");
            strSql.Append("?BrandName,?BrandSpell,?Meta_Description,?Meta_Keywords,?Logo,?CompanyUrl,?Description,?DisplaySequence,?Theme)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BrandName", MySqlDbType.VarChar,50),
					new MySqlParameter("?BrandSpell", MySqlDbType.VarChar,200),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Logo", MySqlDbType.VarChar,255),
					new MySqlParameter("?CompanyUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Theme", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.BrandName;
            parameters[1].Value = model.BrandSpell;
            parameters[2].Value = model.Meta_Description;
            parameters[3].Value = model.Meta_Keywords;
            parameters[4].Value = model.Logo;
            parameters[5].Value = model.CompanyUrl;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.DisplaySequence;
            parameters[8].Value = model.Theme;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.BrandInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_Brands SET ");
            strSql.Append("BrandName=?BrandName,");
            strSql.Append("BrandSpell=?BrandSpell,");
            strSql.Append("Meta_Description=?Meta_Description,");
            strSql.Append("Meta_Keywords=?Meta_Keywords,");
            strSql.Append("Logo=?Logo,");
            strSql.Append("CompanyUrl=?CompanyUrl,");
            strSql.Append("Description=?Description,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("Theme=?Theme");
            strSql.Append(" WHERE BrandId=?BrandId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BrandName", MySqlDbType.VarChar,50),
					new MySqlParameter("?BrandSpell", MySqlDbType.VarChar,200),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Logo", MySqlDbType.VarChar,255),
					new MySqlParameter("?CompanyUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Theme", MySqlDbType.VarChar,100),
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.BrandName;
            parameters[1].Value = model.BrandSpell;
            parameters[2].Value = model.Meta_Description;
            parameters[3].Value = model.Meta_Keywords;
            parameters[4].Value = model.Logo;
            parameters[5].Value = model.CompanyUrl;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.DisplaySequence;
            parameters[8].Value = model.Theme;
            parameters[9].Value = model.BrandId;

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
        public bool Delete(int BrandId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_Brands ");
            strSql.Append(" WHERE BrandId=?BrandId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = BrandId;

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
        public bool DeleteList(string BrandIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_Brands ");
            strSql.Append(" WHERE BrandId in (" + BrandIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.BrandInfo GetModel(int BrandId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT BrandId,BrandName,BrandSpell,Meta_Description,Meta_Keywords,Logo,CompanyUrl,Description,DisplaySequence,Theme FROM Shop_Brands ");
            strSql.Append(" WHERE BrandId=?BrandId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?BrandId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = BrandId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.BrandInfo model = new YSWL.MALL.Model.Shop.Products.BrandInfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BrandId"] != null && ds.Tables[0].Rows[0]["BrandId"].ToString() != "")
                {
                    model.BrandId = int.Parse(ds.Tables[0].Rows[0]["BrandId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BrandName"] != null && ds.Tables[0].Rows[0]["BrandName"].ToString() != "")
                {
                    model.BrandName = ds.Tables[0].Rows[0]["BrandName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BrandSpell"] != null && ds.Tables[0].Rows[0]["BrandSpell"].ToString() != "")
                {
                    model.BrandSpell = ds.Tables[0].Rows[0]["BrandSpell"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Meta_Description"] != null && ds.Tables[0].Rows[0]["Meta_Description"].ToString() != "")
                {
                    model.Meta_Description = ds.Tables[0].Rows[0]["Meta_Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Meta_Keywords"] != null && ds.Tables[0].Rows[0]["Meta_Keywords"].ToString() != "")
                {
                    model.Meta_Keywords = ds.Tables[0].Rows[0]["Meta_Keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Logo"] != null && ds.Tables[0].Rows[0]["Logo"].ToString() != "")
                {
                    model.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CompanyUrl"] != null && ds.Tables[0].Rows[0]["CompanyUrl"].ToString() != "")
                {
                    model.CompanyUrl = ds.Tables[0].Rows[0]["CompanyUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DisplaySequence"] != null && ds.Tables[0].Rows[0]["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(ds.Tables[0].Rows[0]["DisplaySequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Theme"] != null && ds.Tables[0].Rows[0]["Theme"].ToString() != "")
                {
                    model.Theme = ds.Tables[0].Rows[0]["Theme"].ToString();
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
            strSql.Append("SELECT BrandId,BrandName,BrandSpell,Meta_Description,Meta_Keywords,Logo,CompanyUrl,Description,DisplaySequence,Theme ");
            strSql.Append(" FROM Shop_Brands ");
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
            
            strSql.Append(" BrandId,BrandName,BrandSpell,Meta_Description,Meta_Keywords,Logo,CompanyUrl,Description,DisplaySequence,Theme ");
            strSql.Append(" FROM Shop_Brands ");
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
            strSql.Append("SELECT COUNT(1) FROM Shop_Brands ");
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
            strSql.Append("SELECT T.* from Shop_Brands T ");
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
                strSql.Append(" order by T.BrandId desc");
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
            parameters[0].Value = "Shop_Brands";
            parameters[1].Value = "BrandId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        public bool CreateBrandsAndTypes(Model.Shop.Products.BrandInfo model, Model.Shop.Products.DataProviderAction action)
        {
            int rows = 0;
            MySqlParameter[] parameters = {
					new MySqlParameter("_BrandName", MySqlDbType.VarChar,50),
					new MySqlParameter("_BrandSpell", MySqlDbType.VarChar,200),
					new MySqlParameter("_Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("_Meta_Keywords", MySqlDbType.VarChar,1000),
					new MySqlParameter("_Logo", MySqlDbType.VarChar,255),
					new MySqlParameter("_CompanyUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("_Description", MySqlDbType.Text),
					new MySqlParameter("_DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("_Theme", MySqlDbType.VarChar,100),
					new MySqlParameter("_BrandId", MySqlDbType.Int32,4),
					new MySqlParameter("_Action", MySqlDbType.Int32,4),
					new MySqlParameter("_BrandIdOutPut", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = model.BrandName;
            parameters[1].Value = model.BrandSpell;
            parameters[2].Value = model.Meta_Description;
            parameters[3].Value = model.Meta_Keywords;
            parameters[4].Value = model.Logo;
            parameters[5].Value = model.CompanyUrl;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.DisplaySequence;
            parameters[8].Value = model.Theme;
            parameters[9].Value = model.BrandId;
            parameters[10].Value = (int)action;
            parameters[11].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("sp_Shop_BrandsCreateUpdateDelete", parameters, out  rows);
            int bid = 0;
            if (action == Model.Shop.Products.DataProviderAction.Create)
            {
                bid = Convert.ToInt32(parameters[11].Value);
            }
            else
            {
                bid = model.BrandId;
            }
            if (rows > 0 && bid > 0)
            {
                ProductTypeBrand productTypeBrands = new ProductTypeBrand();
                if (action == Model.Shop.Products.DataProviderAction.Update)
                {
                    productTypeBrands.Delete(null, bid);
                }
                foreach (int ProductTypeId in model.ProductTypes)
                {
                    productTypeBrands.Add(ProductTypeId, bid);
                }
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
        public DataSet GetListByProductTypeId(int ProductTypeId,int Top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT    ");
            
            strSql.Append(" B.*  ");
            strSql.Append("FROM Shop_Brands B  ");
            strSql.Append(" where exists( select * from  Shop_ProductTypeBrands A where  A.BrandId=B.BrandId ");
            if (ProductTypeId != 0)
            {
                strSql.AppendFormat(" and  A.ProductTypeId={0}  ", ProductTypeId);
            }
            strSql.Append(" ) ");
            strSql.Append(" ORDER BY DisplaySequence ASC ");
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByProductTypeId(out int rowCount, out int pageCount, int ProductTypeId, int PageIndex, int PageSize, int action)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("_ProductTypeId", MySqlDbType.Int32),
                    new MySqlParameter("_PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("_PageSize", MySqlDbType.Int32),
                    new MySqlParameter("_RowsCount", MySqlDbType.Float),
                    new MySqlParameter("_PageCount", MySqlDbType.Float),
                    new MySqlParameter("_Action", MySqlDbType.Int32)
                    };
            parameters[0].Value = ProductTypeId;
            parameters[1].Value = PageIndex;
            parameters[2].Value = PageSize;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Value = action;
            DataSet ds = DbHelperMySQL.RunProcedure("sp_Shop_BrandsPageInfo", parameters, "ds");
            rowCount = Convert.ToInt32(parameters[3].Value);
            pageCount = Convert.ToInt32(parameters[4].Value);
            return ds;
        }

        public Model.Shop.Products.BrandInfo GetRelatedProduct(int brandsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Shop_ProductTypeBrands ");
            strSql.AppendFormat(" WHERE BrandId={0}", brandsId);
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());

            IList<int> list = new List<int>();
            Model.Shop.Products.BrandInfo model = new Model.Shop.Products.BrandInfo();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["ProductTypeId"] != null && dr["ProductTypeId"].ToString() != "")
                    {
                        list.Add((int)dr["ProductTypeId"]);
                    }
                }
            }
            model.ProductTypes = list;
            return model;
        }

        public Model.Shop.Products.BrandInfo GetRelatedProduct(int? brandsId, int? ProductTypeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Shop_ProductTypeBrands ");
            strSql.Append(" WHERE 1=1 ");
            if (brandsId.HasValue)
            {
                strSql.AppendFormat(" AND BrandId={0}", brandsId);
            }
            if (ProductTypeId.HasValue)
            {
                strSql.AppendFormat(" AND ProductTypeId={0}", ProductTypeId);
            }
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());

            IList<int> list = new List<int>();
            Model.Shop.Products.BrandInfo model = new Model.Shop.Products.BrandInfo();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (brandsId.HasValue)
                    {
                        if (dr["ProductTypeId"] != null && dr["ProductTypeId"].ToString() != "")
                        {
                            list.Add((int)dr["ProductTypeId"]);
                        }
                    }
                    if (ProductTypeId.HasValue)
                    {
                        if (dr["BrandId"] != null && dr["BrandId"].ToString() != "")
                        {
                            list.Add((int)dr["BrandId"]);
                        }
                    }
                }
            }
            model.ProductTypeIdOrBrandsId = list;
            return model;
        }

        /// <summary>
        /// 根据分类ID获取品牌信息
        /// </summary>
        public DataSet GetBrandsListByCateId(int? cateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Shop_Brands ");
            strSql.Append("WHERE BrandId IN(SELECT DISTINCT BrandId FROM Shop_Products ");
            if (cateId.HasValue)
            {
                strSql.AppendFormat("WHERE CategoryId={0} ", cateId.Value);
            }
            strSql.Append(")");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetBrandsByCateId(int cateId, bool IsChild,int Top)
        {
            StringBuilder strSql = new StringBuilder();
                     strSql.Append("SELECT   ");
            
            strSql.Append("   * FROM    Shop_Brands ");
            if (cateId > 0)
            {
                strSql.Append(" WHERE   EXISTS ( SELECT * FROM   Shop_Products ");
                strSql.Append("  WHERE  SaleStatus=1 and  BrandId = Shop_Brands.BrandId ");
                strSql.Append(" AND EXISTS ( SELECT * FROM   Shop_ProductCategories  ");
                strSql.Append(" WHERE  ProductId = Shop_Products.ProductId  ");
                if (IsChild)
                {
                    strSql.AppendFormat(
                        "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ), '|%') ",
                        cateId);
                    strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0})", cateId);
                }
                else
                {
                    strSql.AppendFormat("  Shop_ProductCategories.CategoryId = {0}", cateId);
                }
                strSql.Append(")) ");
            }
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }


        public Model.Shop.Products.BrandInfo GetRelatedSupplier(int? brandsId, int? supplierId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Shop_SupplierBrands ");
            strSql.Append(" WHERE 1=1 ");
            if (brandsId.HasValue)
            {
                strSql.AppendFormat(" AND BrandId={0}", brandsId.Value);
            }
            if (supplierId.HasValue)
            {
                strSql.AppendFormat(" AND SupplierId={0}", supplierId.Value);
            }
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());

            IList<int> list = new List<int>();
            Model.Shop.Products.BrandInfo model = new Model.Shop.Products.BrandInfo();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (brandsId.HasValue)
                    {
                        if (dr["SupplierId"] != null && dr["SupplierId"].ToString() != "")
                        {
                            list.Add((int)dr["SupplierId"]);
                        }
                    }
                    if (supplierId.HasValue)
                    {
                        if (dr["BrandId"] != null && dr["BrandId"].ToString() != "")
                        {
                            list.Add((int)dr["BrandId"]);
                        }
                    }
                }
            }
            model.ProductTypeIdOrBrandsId = list;
            return model;
        }

        public bool UpdatePMSBrands(Model.Shop.Products.BrandInfo model)
        {
            throw new NotImplementedException();
        }

        public bool ResetTable()
        {
            throw new NotImplementedException();
        }

        public bool CreateBrandsAndTypes(Model.Shop.Products.BrandInfo model)
        {
            throw new NotImplementedException();
        }
    }
}

