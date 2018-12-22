/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductStationModes.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:28
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
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// 数据访问类:ProductStationMode
    /// </summary>
    public partial class ProductStationMode : IProductStationMode
    {
        public ProductStationMode()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("StationId", "Shop_ProductStationModes");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_ProductStationModes");
            strSql.Append(" WHERE StationId=?StationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?StationId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = StationId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Products.ProductStationMode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_ProductStationModes(");
            strSql.Append("ProductId,DisplaySequence,Type)");
            strSql.Append(" VALUES (");
            strSql.Append("?ProductId,?DisplaySequence,?Type)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int16,2)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.DisplaySequence;
            parameters[2].Value = model.Type;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.ProductStationMode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_ProductStationModes SET ");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("Type=?Type");
            strSql.Append(" WHERE StationId=?StationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?StationId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.DisplaySequence;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.StationId;

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
        public bool Delete(int StationId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_ProductStationModes ");
            strSql.Append(" WHERE StationId=?StationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?StationId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = StationId;

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
        public bool DeleteList(string StationIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_ProductStationModes ");
            strSql.Append(" WHERE StationId in (" + StationIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.ProductStationMode GetModel(int StationId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT StationId,ProductId,DisplaySequence,Type FROM Shop_ProductStationModes ");
            strSql.Append(" WHERE StationId=?StationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?StationId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = StationId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.ProductStationMode model = new YSWL.MALL.Model.Shop.Products.ProductStationMode();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StationId"] != null && ds.Tables[0].Rows[0]["StationId"].ToString() != "")
                {
                    model.StationId = int.Parse(ds.Tables[0].Rows[0]["StationId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"] != null && ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DisplaySequence"] != null && ds.Tables[0].Rows[0]["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(ds.Tables[0].Rows[0]["DisplaySequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"] != null && ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
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
            strSql.Append("SELECT StationId,ProductId,DisplaySequence,Type ");
            strSql.Append(" FROM Shop_ProductStationModes ");
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
            
            strSql.Append(" StationId,ProductId,DisplaySequence,Type ");
            strSql.Append(" FROM Shop_ProductStationModes ");
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
            strSql.Append("SELECT COUNT(1) FROM Shop_ProductStationModes ");
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
            strSql.Append("SELECT T.* from Shop_ProductStationModes T ");
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
                strSql.Append(" order by T.StationId desc");
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
            parameters[0].Value = "Shop_ProductStationModes";
            parameters[1].Value = "StationId";
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
        /// 根据type获得数据列表
        /// </summary>
        public DataSet GetListByType(string strType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select P.* From Shop_ProductStationModes S, Shop_Products P ");
            strSql.Append(" WHERE S.ProductId = P.ProductId ");
            if (!string.IsNullOrWhiteSpace(strType.Trim()))
            {
                strSql.Append(" and S.Type =" + strType);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int productId, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_ProductStationModes");
            strSql.Append(" WHERE ProductId=?ProductId and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4)
			};
            parameters[0].Value = productId;
            parameters[1].Value = type;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int productId, int type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_ProductStationModes ");
            strSql.Append(" WHERE ProductId=?ProductId and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?Type", MySqlDbType.Int32,4)
			};
            parameters[0].Value = productId;
            parameters[1].Value = type;

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
        /// 清空type下所有商品
        /// </summary>
        public bool DeleteByType(int type,int categoryId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_ProductStationModes ");
            strSql.Append(" WHERE Type=?Type ");
            if (categoryId > 0)
            {
                strSql.Append(" AND EXISTS ( SELECT DISTINCT *   FROM   Shop_ProductCategories ");
                strSql.AppendFormat(
                    " WHERE  ( CategoryPath LIKE '{0}|%' OR CategoryId = {0} ) AND ProductId = Shop_ProductStationModes.ProductId ) ",
                    categoryId);
            }
            MySqlParameter[] parameters = {
					new MySqlParameter("?Type", MySqlDbType.Int32,4)
			};
            parameters[0].Value = type;

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
        /// 推荐商品中已经添加到热卖、最新、特价中去的商品信息
        /// </summary>
        public DataSet GetStationMode(int modeType, int categoryId, string pName,int supplierId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PSM.ProductId ");
            strSql.Append("FROM Shop_ProductStationModes PSM ");
            strSql.Append(" WHERE Type=?Type ");
            if (categoryId > 0)
            {
                strSql.Append(" AND EXISTS ( SELECT DISTINCT *   FROM   Shop_ProductCategories ");
                strSql.AppendFormat(
                    " WHERE  ( CategoryPath LIKE '{0}|%' OR CategoryId = {0} ) AND ProductId = PSM.ProductId ) ",
                    categoryId);
            }
            strSql.Append(" AND EXISTS ( SELECT *  FROM      Shop_Products WHERE  SaleStatus = 1   ");
            if (!String.IsNullOrWhiteSpace(pName))
            {
             
                strSql.AppendFormat(
                    "  AND ProductName LIKE '%{0}%'  ", Common.InjectionFilter.SqlFilter(pName));
            }
            if (supplierId > 0)
            {
                strSql.AppendFormat(
                                "  AND SupplierId = {0}  ", supplierId);
            }
            strSql.Append(" AND ProductId = PSM.ProductId )  ");
            MySqlParameter[] parameters =
                {
                    new MySqlParameter("?Type", MySqlDbType.Int32, 4)
                };
            parameters[0].Value = modeType;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }
        #endregion
    }
}

