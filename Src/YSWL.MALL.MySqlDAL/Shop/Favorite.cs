/**
* Favorite.cs
*
* 功 能： N/A
* 类 名： Favorite
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/6/23 14:47:11   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop
{
    /// <summary>
    /// 数据访问类:Favorite
    /// </summary>
    public partial class Favorite : IFavorite
    {
        public Favorite()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("FavoriteId", "Shop_Favorite");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FavoriteId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Favorite");
            strSql.Append(" where FavoriteId=?FavoriteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FavoriteId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = FavoriteId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Favorite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_Favorite(");
            strSql.Append("Type,TargetId,UserId,Tags,Remark,CreatedDate)");
            strSql.Append(" values (");
            strSql.Append("?Type,?TargetId,?UserId,?Tags,?Remark,?CreatedDate)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?TargetId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.TargetId;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.Tags;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.CreatedDate;

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
        public bool Update(YSWL.MALL.Model.Shop.Favorite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Favorite set ");
            strSql.Append("Type=?Type,");
            strSql.Append("TargetId=?TargetId,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("Tags=?Tags,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("CreatedDate=?CreatedDate");
            strSql.Append(" where FavoriteId=?FavoriteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?TargetId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,500),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?FavoriteId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.TargetId;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.Tags;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.FavoriteId;

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
        public bool Delete(int FavoriteId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Favorite ");
            strSql.Append(" where FavoriteId=?FavoriteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FavoriteId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = FavoriteId;

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
        public bool DeleteList(string FavoriteIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Favorite ");
            strSql.Append(" where FavoriteId in (" + FavoriteIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Favorite GetModel(int FavoriteId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  FavoriteId,Type,TargetId,UserId,Tags,Remark,CreatedDate from Shop_Favorite ");
            strSql.Append(" where FavoriteId=?FavoriteId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FavoriteId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = FavoriteId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Favorite model = new YSWL.MALL.Model.Shop.Favorite();
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
        public YSWL.MALL.Model.Shop.Favorite DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Favorite model = new YSWL.MALL.Model.Shop.Favorite();
            if (row != null)
            {
                if (row["FavoriteId"] != null && row["FavoriteId"].ToString() != "")
                {
                    model.FavoriteId = int.Parse(row["FavoriteId"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["TargetId"] != null && row["TargetId"].ToString() != "")
                {
                    model.TargetId = long.Parse(row["TargetId"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Tags"] != null)
                {
                    model.Tags = row["Tags"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
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
            strSql.Append("select FavoriteId,Type,TargetId,UserId,Tags,Remark,CreatedDate ");
            strSql.Append(" FROM Shop_Favorite ");
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
            
            strSql.Append(" FavoriteId,Type,TargetId,UserId,Tags,Remark,CreatedDate ");
            strSql.Append(" FROM Shop_Favorite ");
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
            strSql.Append("select count(1) FROM Shop_Favorite ");
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
            strSql.Append("SELECT T.* from Shop_Favorite T ");
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
                strSql.Append(" order by T.FavoriteId desc");
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
            parameters[0].Value = "Shop_Favorite";
            parameters[1].Value = "FavoriteId";
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long targetId, int UserId,int Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Favorite");
            strSql.Append(" where TargetId=?TargetId and UserId=?UserId and Type=?Type ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TargetId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),	
                                        	new MySqlParameter("?Type", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = targetId;
            parameters[1].Value = UserId;
            parameters[2].Value = Type;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 分页获取收藏商品列表 
        /// </summary>
        public DataSet GetProductListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
//            SELECT * FROM (  SELECT ROW_NUMBER() OVER (
            //    ORDER BY favo.CreatedDate DESC) AS ROW ,favo.FavoriteId AS FavoriteId, favo.CreatedDate AS CreatedDate ,prod.ProductId , prod.ProductName AS ProductName,prod.SaleStatus AS SaleStatus , prod.ThumbnailUrl1 AS ThumbnailUrl1
//        FROM  Shop_Favorite AS favo LEFT JOIN  Shop_Products AS prod ON  favo.TargetId=prod.ProductId	
//             WHERE favo.UserId=189 AND favo.Typeid=1 
//) AS tab WHERE tab.ROW BETWEEN 1 AND 3

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT favo.FavoriteId AS FavoriteId, favo.CreatedDate AS CreatedDate ,prod.ProductId as ProductId , prod.ProductName AS ProductName,prod.SaleStatus AS SaleStatus , prod.ThumbnailUrl1 AS ThumbnailUrl1");
            strSql.Append(" from Shop_Favorite AS favo LEFT JOIN  Shop_Products AS prod ON  favo.TargetId=prod.ProductId ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by favo." + orderby);
            }
            else
            {
                strSql.Append(" order by favo.FavoriteId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }




        /// <summary>
        /// 分页获取收藏商品列表(可直接购买) 
        /// </summary>
        public DataSet GetBuyListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT favo.FavoriteId AS FavoriteId, favo.CreatedDate AS CreatedDate ,prod.ProductId as ProductId , prod.ProductName AS ProductName,prod.SaleStatus AS SaleStatus , prod.ThumbnailUrl1 AS ThumbnailUrl1, prod.ProductCode AS ProductCode ");
            strSql.Append(" from Shop_Favorite AS favo LEFT JOIN  Shop_Products AS prod ON  favo.TargetId=prod.ProductId ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by favo." + orderby);
            }
            else
            {
                strSql.Append(" order by favo.FavoriteId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public int GetFavoriteId(long targetId, int UserId, int Type)
        {
            throw new NotImplementedException();
        }

        #endregion  ExtensionMethod
    }
}



