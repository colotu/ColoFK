/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductReviews.cs
// 文件功能描述：
// 
// 创建标识： [Name]  2012/08/27 14:50:43
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
	/// 数据访问类:ProductReviews
	/// </summary>
	public partial class ProductReviews:IProductReviews
	{
		public ProductReviews()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ReviewId", "Shop_ProductReviews");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ReviewId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_ProductReviews");
            strSql.Append(" where ReviewId=?ReviewId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ReviewId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ReviewId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Products.ProductReviews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_ProductReviews(");
            strSql.Append("ProductId,UserId,ReviewText,UserName,UserEmail,CreatedDate,ParentId,Status,OrderId,SKU,Attribute,ImagesPath,ImagesNames)");
            strSql.Append(" values (");
            strSql.Append("?ProductId,?UserId,?ReviewText,?UserName,?UserEmail,?CreatedDate,?ParentId,?Status,?OrderId,?SKU,?Attribute,?ImagesPath,?ImagesNames)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewText", MySqlDbType.VarChar,-1),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,200),
					new MySqlParameter("?Attribute", MySqlDbType.Text),
					new MySqlParameter("?ImagesPath", MySqlDbType.VarChar,300),
					new MySqlParameter("?ImagesNames", MySqlDbType.VarChar,500)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.ReviewText;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.ParentId;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.OrderId;
            parameters[9].Value = model.SKU;
            parameters[10].Value = model.Attribute;
            parameters[11].Value = model.ImagesPath;
            parameters[12].Value = model.ImagesNames;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.ProductReviews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ProductReviews set ");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("ReviewText=?ReviewText,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserEmail=?UserEmail,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("ParentId=?ParentId,");
            strSql.Append("Status=?Status,");
            strSql.Append("OrderId=?OrderId,");
            strSql.Append("SKU=?SKU,");
            strSql.Append("Attribute=?Attribute,");
            strSql.Append("ImagesPath=?ImagesPath,");
            strSql.Append("ImagesNames=?ImagesNames");
            strSql.Append(" where ReviewId=?ReviewId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewText", MySqlDbType.VarChar,-1),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,200),
					new MySqlParameter("?Attribute", MySqlDbType.Text),
					new MySqlParameter("?ImagesPath", MySqlDbType.VarChar,300),
					new MySqlParameter("?ImagesNames", MySqlDbType.VarChar,500),
					new MySqlParameter("?ReviewId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.ReviewText;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.ParentId;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.OrderId;
            parameters[9].Value = model.SKU;
            parameters[10].Value = model.Attribute;
            parameters[11].Value = model.ImagesPath;
            parameters[12].Value = model.ImagesNames;
            parameters[13].Value = model.ReviewId;

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
        public bool Delete(int ReviewId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ProductReviews ");
            strSql.Append(" where ReviewId=?ReviewId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ReviewId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ReviewId;

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
        public bool DeleteList(string ReviewIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ProductReviews ");
            strSql.Append(" where ReviewId in (" + ReviewIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.ProductReviews GetModel(int ReviewId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ReviewId,ProductId,UserId,ReviewText,UserName,UserEmail,CreatedDate,ParentId,Status,OrderId,SKU,Attribute,ImagesPath,ImagesNames from Shop_ProductReviews ");
            strSql.Append(" where ReviewId=?ReviewId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ReviewId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ReviewId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.ProductReviews model = new YSWL.MALL.Model.Shop.Products.ProductReviews();
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
        public YSWL.MALL.Model.Shop.Products.ProductReviews DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Products.ProductReviews model = new YSWL.MALL.Model.Shop.Products.ProductReviews();
            if (row != null)
            {
                if (row["ReviewId"] != null && row["ReviewId"].ToString() != "")
                {
                    model.ReviewId = int.Parse(row["ReviewId"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["ReviewText"] != null)
                {
                    model.ReviewText = row["ReviewText"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserEmail"] != null)
                {
                    model.UserEmail = row["UserEmail"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["OrderId"] != null && row["OrderId"].ToString() != "")
                {
                    model.OrderId = long.Parse(row["OrderId"].ToString());
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["Attribute"] != null)
                {
                    model.Attribute = row["Attribute"].ToString();
                }
                if (row["ImagesPath"] != null)
                {
                    model.ImagesPath = row["ImagesPath"].ToString();
                }
                if (row["ImagesNames"] != null)
                {
                    model.ImagesNames = row["ImagesNames"].ToString();
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
            strSql.Append("select ReviewId,ProductId,UserId,ReviewText,UserName,UserEmail,CreatedDate,ParentId,Status,OrderId,SKU,Attribute,ImagesPath,ImagesNames ");
            strSql.Append(" FROM Shop_ProductReviews ");
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
            
            strSql.Append(" ReviewId,ProductId,UserId,ReviewText,UserName,UserEmail,CreatedDate,ParentId,Status,OrderId,SKU,Attribute,ImagesPath,ImagesNames ");
            strSql.Append(" FROM Shop_ProductReviews ");
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
            strSql.Append("select count(1) FROM Shop_ProductReviews ");
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
            strSql.Append("SELECT T.* from Shop_ProductReviews T ");
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
                strSql.Append(" order by T.ReviewId desc");
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
            parameters[0].Value = "Shop_ProductReviews";
            parameters[1].Value = "ReviewId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        public DataSet GetList(int? Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*,b.Score FROM Shop_ProductReviews A ");
            strSql.Append("LEFT JOIN Shop_ScoreDetails B ON A.ReviewId = B.ReviewId ");
            if (Status.HasValue)
            {
                strSql.AppendFormat("WHERE Status ={0} ", Status.Value);
            }
            return DbHelperMySQL.Query(strSql.ToString());

        }
         /// <summary>
         /// 获得商品评论列表
         /// </summary>
         /// <param name="Status"></param>
         /// <returns></returns>
        public DataSet GetListsProdRev(int? Status)
        {
            //SELECT prorev.*,orderitems.ThumbnailsUrl , orderitems.Name  FROM  Shop_ProductReviews  AS  prorev   LEFT JOIN    Shop_OrderItems  AS  orderitems   ON prorev.OrderId = orderitems.OrderId  
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT prorev.*,orderitems.ThumbnailsUrl as ThumbnailsUrl, orderitems.Name as ProductName  FROM  Shop_ProductReviews  AS  prorev    ");
            strSql.Append(" inner JOIN  Shop_OrderItems  AS  orderitems   ON prorev.SKU = orderitems.SKU  and  prorev.OrderId = orderitems.OrderId ");
            if (Status.HasValue)
            {
                strSql.AppendFormat("WHERE Status ={0} ", Status.Value);
            }
            strSql.AppendFormat(" ORDER BY prorev.ReviewId DESC  ");
            return DbHelperMySQL.Query(strSql.ToString());
        }
        
        public  bool AuditComment(string ids,int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_ProductReviews ");
            strSql.AppendFormat("SET Status ={0}  ", status);
            strSql.AppendFormat("WHERE ReviewId IN({0}) ", ids);
            return DbHelperMySQL.ExecuteSql(strSql.ToString()) > 0;
        }

	    /// <summary>
	    /// 增加多条数据
	    /// </summary>
        public bool AddEx(List<Model.Shop.Products.ProductReviews> modelList, long OrderId)
	    {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            Model.Shop.Products.ProductReviews model;
            for (int i = 0; i < modelList.Count; i++)
            {
                model = modelList[i];
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Shop_ProductReviews(");
                strSql.Append("ProductId,UserId,ReviewText,UserName,UserEmail,CreatedDate,ParentId,Status,OrderId,SKU,Attribute,ImagesPath,ImagesNames)");
                strSql.Append(" values (");
                strSql.Append("?ProductId,?UserId,?ReviewText,?UserName,?UserEmail,?CreatedDate,?ParentId,?Status,?OrderId,?SKU,?Attribute,?ImagesPath,?ImagesNames)");
                strSql.Append(";select last_insert_id()");
                MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReviewText", MySqlDbType.VarChar,-1),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,200),
					new MySqlParameter("?Attribute", MySqlDbType.Text),
					new MySqlParameter("?ImagesPath", MySqlDbType.VarChar,300),
					new MySqlParameter("?ImagesNames", MySqlDbType.VarChar,500)};
                parameters[0].Value = model.ProductId;
                parameters[1].Value = model.UserId;
                parameters[2].Value = model.ReviewText;
                parameters[3].Value = model.UserName;
                parameters[4].Value = model.UserEmail;
                parameters[5].Value = model.CreatedDate;
                parameters[6].Value = model.ParentId;
                parameters[7].Value = model.Status;
                parameters[8].Value = model.OrderId;
                parameters[9].Value = model.SKU;
                parameters[10].Value = model.Attribute;
                parameters[11].Value = model.ImagesPath;
                parameters[12].Value = model.ImagesNames;
                sqllist.Add(new CommandInfo(strSql.ToString(), parameters));
            }
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update Shop_Orders set ");
            strSql2.Append("IsReviews=?IsReviews");
            strSql2.Append(" where OrderId=?OrderId");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?IsReviews", MySqlDbType.Bit,1),
					new MySqlParameter("?OrderId", MySqlDbType.Int64,8)};
     
            parameters2[0].Value = true;
            parameters2[1].Value = OrderId;
            sqllist.Add(new CommandInfo(strSql2.ToString(), parameters2));

            int rows = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}

