/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductAccessories.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:24
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Products
{
	/// <summary>
	/// 数据访问类:ProductAccessories
	/// </summary>
	public partial class ProductAccessorie:IProductAccessorie
	{
		public ProductAccessorie()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("AccessoriesId", "Shop_ProductAccessories");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ProductId, int AccessoriesId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_ProductAccessories");
            strSql.Append(" where ProductId=?ProductId and AccessoriesId=?AccessoriesId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)			};
            parameters[0].Value = ProductId;
            parameters[1].Value = AccessoriesId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Products.ProductAccessorie model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_ProductAccessories(");
            strSql.Append("ProductId,Name,MaxQuantity,MinQuantity,DiscountType,DiscountAmount,Type,Stock)");
            strSql.Append(" values (");
            strSql.Append("?ProductId,?Name,?MaxQuantity,?MinQuantity,?DiscountType,?DiscountAmount,?Type,?Stock)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?MaxQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?MinQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?DiscountType", MySqlDbType.Int16,2),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?Stock", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.MaxQuantity;
            parameters[3].Value = model.MinQuantity;
            parameters[4].Value = model.DiscountType;
            parameters[5].Value = model.DiscountAmount;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.Stock;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.ProductAccessorie model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ProductAccessories set ");
            strSql.Append("Name=?Name,");
            strSql.Append("MaxQuantity=?MaxQuantity,");
            strSql.Append("MinQuantity=?MinQuantity,");
            strSql.Append("DiscountType=?DiscountType,");
            strSql.Append("DiscountAmount=?DiscountAmount,");
            strSql.Append("Type=?Type,");
            strSql.Append("Stock=?Stock");
            strSql.Append(" where AccessoriesId=?AccessoriesId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?MaxQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?MinQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?DiscountType", MySqlDbType.Int16,2),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.MaxQuantity;
            parameters[2].Value = model.MinQuantity;
            parameters[3].Value = model.DiscountType;
            parameters[4].Value = model.DiscountAmount;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Stock;
            parameters[7].Value = model.AccessoriesId;
            parameters[8].Value = model.ProductId;

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
        public bool Delete(int AccessoriesId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ProductAccessories ");
            strSql.Append(" where AccessoriesId=?AccessoriesId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AccessoriesId;

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
        public bool Delete(long ProductId, int AccessoriesId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ProductAccessories ");
            strSql.Append(" where ProductId=?ProductId and AccessoriesId=?AccessoriesId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)			};
            parameters[0].Value = ProductId;
            parameters[1].Value = AccessoriesId;

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
        public bool DeleteList(string AccessoriesIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ProductAccessories ");
            strSql.Append(" where AccessoriesId in (" + AccessoriesIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.ProductAccessorie GetModel(int AccessoriesId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccessoriesId,ProductId,Name,MaxQuantity,MinQuantity,DiscountType,DiscountAmount,Type,Stock from Shop_ProductAccessories ");
            strSql.Append(" where AccessoriesId=?AccessoriesId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AccessoriesId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.ProductAccessorie model = new YSWL.MALL.Model.Shop.Products.ProductAccessorie();
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
        public YSWL.MALL.Model.Shop.Products.ProductAccessorie DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Products.ProductAccessorie model = new YSWL.MALL.Model.Shop.Products.ProductAccessorie();
            if (row != null)
            {
                if (row["AccessoriesId"] != null && row["AccessoriesId"].ToString() != "")
                {
                    model.AccessoriesId = int.Parse(row["AccessoriesId"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["MaxQuantity"] != null && row["MaxQuantity"].ToString() != "")
                {
                    model.MaxQuantity = int.Parse(row["MaxQuantity"].ToString());
                }
                if (row["MinQuantity"] != null && row["MinQuantity"].ToString() != "")
                {
                    model.MinQuantity = int.Parse(row["MinQuantity"].ToString());
                }
                if (row["DiscountType"] != null && row["DiscountType"].ToString() != "")
                {
                    model.DiscountType = int.Parse(row["DiscountType"].ToString());
                }
                if (row["DiscountAmount"] != null && row["DiscountAmount"].ToString() != "")
                {
                    model.DiscountAmount = decimal.Parse(row["DiscountAmount"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Stock"] != null && row["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(row["Stock"].ToString());
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
            strSql.Append("select AccessoriesId,ProductId,Name,MaxQuantity,MinQuantity,DiscountType,DiscountAmount,Type,Stock ");
            strSql.Append(" FROM Shop_ProductAccessories ");
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
            
            strSql.Append(" AccessoriesId,ProductId,Name,MaxQuantity,MinQuantity,DiscountType,DiscountAmount,Type,Stock ");
            strSql.Append(" FROM Shop_ProductAccessories ");
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
            strSql.Append("select count(1) FROM Shop_ProductAccessories ");
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
            strSql.Append("SELECT T.* from Shop_ProductAccessories T ");
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
                strSql.Append(" order by T.AccessoriesId desc");
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
            parameters[0].Value = "Shop_ProductAccessories";
            parameters[1].Value = "AccessoriesId";
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
        /// 得到一个对象实体
        /// </summary>
        /// <param name="accessoriesId">组合id</param>
        /// <param name="productid">商品id</param>
        /// <returns></returns>
        public Model.Shop.Products.ProductAccessorie GetModel(int accessoriesId, long productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccessoriesId,ProductId,Name,MaxQuantity,MinQuantity,DiscountType,DiscountAmount,Type,Stock from Shop_ProductAccessories ");
            strSql.Append(" where AccessoriesId=?AccessoriesId and ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8)
			};
            strSql.Append(" LIMIT 1 ");
            parameters[0].Value = accessoriesId;
            parameters[1].Value = productid;
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
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Shop.Products.ProductAccessorie model,string sku)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_ProductAccessories(");
            strSql.Append("ProductId,Name,MaxQuantity,MinQuantity,DiscountType,DiscountAmount,Type,Stock)");
            strSql.Append(" values (");
            strSql.Append("?ProductId,?Name,?MaxQuantity,?MinQuantity,?DiscountType,?DiscountAmount,?Type,?Stock)");
            strSql.Append("; set ?AccessoriesId= last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?MaxQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?MinQuantity", MySqlDbType.Int32,4),
					new MySqlParameter("?DiscountType", MySqlDbType.Int16,2),
					new MySqlParameter("?DiscountAmount", MySqlDbType.Decimal,8),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?Stock", MySqlDbType.Int32,4),
                              new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)          };
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.MaxQuantity;
            parameters[3].Value = model.MinQuantity;
            parameters[4].Value = model.DiscountType;
            parameters[5].Value = model.DiscountAmount;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.Stock;
            parameters[8].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("insert into Shop_AccessoriesValues(");
            strSql1.Append("AccessoriesId,SKU)");
            strSql1.Append(" values (");
            strSql1.Append(" last_insert_id(),?SKU)");
            MySqlParameter[] parameters1 = {
					new MySqlParameter("?SKU", MySqlDbType.VarChar,50)};
            parameters1[0].Value =sku;
            cmd = new CommandInfo(strSql1.ToString(), parameters1,  EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);
            int rows= DbHelperMySQL.ExecuteSqlTran(sqllist);
            return  rows > 0 ;
        }

        /// <summary>
        /// 删除一条数据同时删除该组合下的sku
        /// </summary>
        public bool DeleteEx(int AccessoriesId)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd;
            //删除组合下的sku
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_AccessoriesValues ");
            strSql.Append(" where AccessoriesId=?AccessoriesId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AccessoriesId;
            cmd = new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            //删除组合
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from Shop_ProductAccessories ");
            strSql1.Append(" where AccessoriesId=?AccessoriesId");
            MySqlParameter[] parameters1 = {
					new MySqlParameter("?AccessoriesId", MySqlDbType.Int32,4)
			};
            parameters1[0].Value = AccessoriesId;
            cmd = new CommandInfo(strSql1.ToString(), parameters1, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            int rows = DbHelperMySQL.ExecuteSqlTran(sqllist);
            return rows > 0; 
        }
        /// <summary>
        /// 批量删除数据 同时删除该组合下的sku
        /// </summary>
        public bool DeleteListEx(string AccessoriesIdlist)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_AccessoriesValues ");
            strSql.Append(" where AccessoriesId in (" + AccessoriesIdlist + ")  ");
            MySqlParameter[] parameters = {};
            cmd = new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from Shop_ProductAccessories ");
            strSql1.Append(" where AccessoriesId in (" + AccessoriesIdlist + ")  ");
            MySqlParameter[] parameters1 = { };
            cmd = new CommandInfo(strSql1.ToString(), parameters1, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);
            int rows = DbHelperMySQL.ExecuteSqlTran(sqllist);
            return rows > 0; 
        }
	    #endregion





    }
}

