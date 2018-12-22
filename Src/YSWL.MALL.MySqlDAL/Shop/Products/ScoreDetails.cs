/*----------------------------------------------------------------

// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ScoreDetails.cs
// 文件功能描述：
//
// 创建标识： [Name]  2012/08/27 14:50:44
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Products;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Admin.Shop.Products
{
    /// <summary>/
    /// 数据访问类:ScoreDetails
    /// </summary>
    public partial class ScoreDetails : IScoreDetails
    {
        public ScoreDetails()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ScoreId", "Shop_ScoreDetails");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ScoreId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_ScoreDetails");
            strSql.Append(" WHERE ScoreId=?ScoreId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ScoreId", MySqlDbType.Int32,4)			};
            parameters[0].Value = ScoreId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Shop.Products.ScoreDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_ScoreDetails(");
            strSql.Append("ScoreId,ReviewId,UserId,ProductId,Score,CreatedDate)");
            strSql.Append(" VALUES (");
            strSql.Append("?ScoreId,?ReviewId,?UserId,?ProductId,?Score,?CreatedDate)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ScoreId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime)};
            parameters[0].Value = model.ScoreId;
            parameters[1].Value = model.ReviewId;
            parameters[2].Value = model.UserId;
            parameters[3].Value = model.ProductId;
            parameters[4].Value = model.Score;
            parameters[5].Value = model.CreatedDate;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.ScoreDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_ScoreDetails SET ");
            strSql.Append("ReviewId=?ReviewId,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("Score=?Score,");
            strSql.Append("CreatedDate=?CreatedDate");
            strSql.Append(" WHERE ScoreId=?ScoreId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ReviewId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?Score", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ScoreId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ReviewId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.ProductId;
            parameters[3].Value = model.Score;
            parameters[4].Value = model.CreatedDate;
            parameters[5].Value = model.ScoreId;

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
        public bool Delete(int ScoreId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_ScoreDetails ");
            strSql.Append(" WHERE ScoreId=?ScoreId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ScoreId", MySqlDbType.Int32,4)			};
            parameters[0].Value = ScoreId;

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
        public bool DeleteList(string ScoreIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_ScoreDetails ");
            strSql.Append(" WHERE ScoreId in (" + ScoreIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.ScoreDetails GetModel(int ScoreId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ScoreId,ReviewId,UserId,ProductId,Score,CreatedDate FROM Shop_ScoreDetails ");
            strSql.Append(" WHERE ScoreId=?ScoreId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ScoreId", MySqlDbType.Int32,4)			};
            parameters[0].Value = ScoreId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.ScoreDetails model = new YSWL.MALL.Model.Shop.Products.ScoreDetails();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ScoreId"] != null && ds.Tables[0].Rows[0]["ScoreId"].ToString() != "")
                {
                    model.ScoreId = int.Parse(ds.Tables[0].Rows[0]["ScoreId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReviewId"] != null && ds.Tables[0].Rows[0]["ReviewId"].ToString() != "")
                {
                    model.ReviewId = int.Parse(ds.Tables[0].Rows[0]["ReviewId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserId"] != null && ds.Tables[0].Rows[0]["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"] != null && ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Score"] != null && ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
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
            strSql.Append("SELECT ScoreId,ReviewId,UserId,ProductId,Score,CreatedDate ");
            strSql.Append(" FROM Shop_ScoreDetails ");
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

            strSql.Append(" ScoreId,ReviewId,UserId,ProductId,Score,CreatedDate ");
            strSql.Append(" FROM Shop_ScoreDetails ");
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
            strSql.Append("SELECT COUNT(1) FROM Shop_ScoreDetails ");
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
            strSql.Append("SELECT T.* from Shop_Shippers T ");
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
                strSql.Append(" order by T.ScoreId desc");
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
            parameters[0].Value = "Shop_ScoreDetails";
            parameters[1].Value = "ScoreId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        public int GetScore(int? ReviewId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Score FROM Shop_ScoreDetails ");
            strSql.AppendFormat("WHERE ReviewId={0} ", ReviewId.Value);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取商品的评分等级和总评论数
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.ProductId,ScoreCount,Score,Score/SCoreCount AS AVE FROM( ");
            strSql.Append("SELECT COUNT(*)AS ScoreCount,ProductId ");
            strSql.Append("FROM Shop_ScoreDetails ");
            strSql.Append("GROUP BY ProductId)A  ");
            strSql.Append("LEFT JOIN (SELECT SUM(Score) AS Score,ProductId ");
            strSql.Append("FROM Shop_ScoreDetails ");
            strSql.Append("GROUP BY ProductId)B ON A.ProductId = B.ProductId ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取商品评分的详细信息 差评  中评 好评 各占比例
        /// </summary>
        public DataSet GetScoreDetailInfo(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.ProductId,Poor,Rating,HeightScore FROM ( ");
            strSql.Append("SELECT (COUNT( Score)+0.0)/(SELECT COUNT(*) FROM  Shop_ScoreDetails ");
            strSql.Append("WHERE ProductId=?ProductId)*100 AS Poor,ProductId FROM Shop_ScoreDetails ");
            strSql.Append("WHERE Score<3  AND ProductId=?ProductId GROUP BY ProductId)A ");
            strSql.Append("LEFT JOIN ( ");
            strSql.Append("SELECT (COUNT( Score)+0.0)/(SELECT COUNT(*) FROM  Shop_ScoreDetails ");
            strSql.Append("WHERE ProductId=?ProductId)*100 AS Rating,ProductId FROM Shop_ScoreDetails ");
            strSql.Append("WHERE Score=3  AND ProductId=?ProductId  GROUP BY ProductId)B ON A.ProductId = B.ProductId ");
            strSql.Append("LEFT JOIN ( ");
            strSql.Append("SELECT (COUNT( Score)+0.0)/(SELECT COUNT(*) FROM  Shop_ScoreDetails ");
            strSql.Append("WHERE ProductId=?ProductId)*100 AS HeightScore,ProductId FROM Shop_ScoreDetails ");
            strSql.Append("WHERE Score>3  AND ProductId=?ProductId GROUP BY ProductId)C  ON A.ProductId = C.ProductId ");
            MySqlParameter[] parameter = {
                                       new MySqlParameter("?ProductId",MySqlDbType.Int64)
                                       };
            parameter[0].Value = productId;
            return DbHelperMySQL.Query(strSql.ToString(), parameter);
        }
    }
}