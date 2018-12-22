/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductImages.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:26
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
	/// 数据访问类:ProductImage
	/// </summary>
	public partial class ProductImage:IProductImage
	{
		public ProductImage()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ProductImageId", "Shop_ProductImages"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ProductId,int ProductImageId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM Shop_ProductImages");
			strSql.Append(" WHERE ProductId=?ProductId and ProductImageId=?ProductImageId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductImageId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ProductId;
			parameters[1].Value = ProductImageId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Products.ProductImage model)
		{
			StringBuilder strSql=new StringBuilder();
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
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.ImageUrl;
			parameters[2].Value = model.ThumbnailUrl1;
			parameters[3].Value = model.ThumbnailUrl2;
			parameters[4].Value = model.ThumbnailUrl3;
			parameters[5].Value = model.ThumbnailUrl4;
			parameters[6].Value = model.ThumbnailUrl5;
			parameters[7].Value = model.ThumbnailUrl6;
			parameters[8].Value = model.ThumbnailUrl7;
			parameters[9].Value = model.ThumbnailUrl8;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.Shop.Products.ProductImage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("UPDATE Shop_ProductImages SET ");
			strSql.Append("ImageUrl=?ImageUrl,");
			strSql.Append("ThumbnailUrl1=?ThumbnailUrl1,");
			strSql.Append("ThumbnailUrl2=?ThumbnailUrl2,");
			strSql.Append("ThumbnailUrl3=?ThumbnailUrl3,");
			strSql.Append("ThumbnailUrl4=?ThumbnailUrl4,");
			strSql.Append("ThumbnailUrl5=?ThumbnailUrl5,");
			strSql.Append("ThumbnailUrl6=?ThumbnailUrl6,");
			strSql.Append("ThumbnailUrl7=?ThumbnailUrl7,");
			strSql.Append("ThumbnailUrl8=?ThumbnailUrl8");
			strSql.Append(" WHERE ProductImageId=?ProductImageId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl2", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl3", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl4", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl5", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl6", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl7", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl8", MySqlDbType.VarChar,255),
					new MySqlParameter("?ProductImageId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
			parameters[0].Value = model.ImageUrl;
			parameters[1].Value = model.ThumbnailUrl1;
			parameters[2].Value = model.ThumbnailUrl2;
			parameters[3].Value = model.ThumbnailUrl3;
			parameters[4].Value = model.ThumbnailUrl4;
			parameters[5].Value = model.ThumbnailUrl5;
			parameters[6].Value = model.ThumbnailUrl6;
			parameters[7].Value = model.ThumbnailUrl7;
			parameters[8].Value = model.ThumbnailUrl8;
			parameters[9].Value = model.ProductImageId;
			parameters[10].Value = model.ProductId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int ProductImageId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_ProductImages ");
			strSql.Append(" WHERE ProductImageId=?ProductImageId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductImageId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ProductImageId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(long ProductId,int ProductImageId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_ProductImages ");
			strSql.Append(" WHERE ProductId=?ProductId and ProductImageId=?ProductImageId ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?ProductImageId", MySqlDbType.Int32,4)			};
			parameters[0].Value = ProductId;
			parameters[1].Value = ProductImageId;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string ProductImageIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_ProductImages ");
			strSql.Append(" WHERE ProductImageId in ("+ProductImageIdlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public YSWL.MALL.Model.Shop.Products.ProductImage GetModel(int ProductImageId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ProductImageId,ProductId,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8 FROM Shop_ProductImages ");
			strSql.Append(" WHERE ProductImageId=?ProductImageId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductImageId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ProductImageId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Products.ProductImage model=new YSWL.MALL.Model.Shop.Products.ProductImage();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductImageId"]!=null && ds.Tables[0].Rows[0]["ProductImageId"].ToString()!="")
				{
					model.ProductImageId=int.Parse(ds.Tables[0].Rows[0]["ProductImageId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductId"]!=null && ds.Tables[0].Rows[0]["ProductId"].ToString()!="")
				{
					model.ProductId=long.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImageUrl"]!=null && ds.Tables[0].Rows[0]["ImageUrl"].ToString()!="")
				{
					model.ImageUrl=ds.Tables[0].Rows[0]["ImageUrl"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl1"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl1"].ToString()!="")
				{
					model.ThumbnailUrl1=ds.Tables[0].Rows[0]["ThumbnailUrl1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl2"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl2"].ToString()!="")
				{
					model.ThumbnailUrl2=ds.Tables[0].Rows[0]["ThumbnailUrl2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl3"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl3"].ToString()!="")
				{
					model.ThumbnailUrl3=ds.Tables[0].Rows[0]["ThumbnailUrl3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl4"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl4"].ToString()!="")
				{
					model.ThumbnailUrl4=ds.Tables[0].Rows[0]["ThumbnailUrl4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl5"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl5"].ToString()!="")
				{
					model.ThumbnailUrl5=ds.Tables[0].Rows[0]["ThumbnailUrl5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl6"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl6"].ToString()!="")
				{
					model.ThumbnailUrl6=ds.Tables[0].Rows[0]["ThumbnailUrl6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl7"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl7"].ToString()!="")
				{
					model.ThumbnailUrl7=ds.Tables[0].Rows[0]["ThumbnailUrl7"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ThumbnailUrl8"]!=null && ds.Tables[0].Rows[0]["ThumbnailUrl8"].ToString()!="")
				{
					model.ThumbnailUrl8=ds.Tables[0].Rows[0]["ThumbnailUrl8"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ProductImageId,ProductId,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8 ");
			strSql.Append(" FROM Shop_ProductImages ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ");
			
			strSql.Append(" ProductImageId,ProductId,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3,ThumbnailUrl4,ThumbnailUrl5,ThumbnailUrl6,ThumbnailUrl7,ThumbnailUrl8 ");
			strSql.Append(" FROM Shop_ProductImages ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM Shop_ProductImages ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
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
            strSql.Append("SELECT T.* from Shop_ProductImages T ");
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
                strSql.Append(" order by T.ProductImageId desc");
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
			parameters[0].Value = "Shop_ProductImages";
			parameters[1].Value = "ProductImageId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        #region 扩展方法
        /// <summary>
        /// 产品图片数据源
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public DataSet ProductImagesList(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append("SELECT ProductId,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3 FROM Shop_Products P ");
            strSql.Append("UNION ALL  ");
            strSql.Append("SELECT ProductId,ImageUrl,ThumbnailUrl1,ThumbnailUrl2,ThumbnailUrl3 FROM Shop_ProductImages PIM)A ");
            strSql.Append("WHERE A.ProductId=?ProductId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
            parameters[0].Value = productId;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateThumbnail(YSWL.MALL.Model.Shop.Products.ProductImage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_ProductImages SET ");
            strSql.Append("ThumbnailUrl1=?ThumbnailUrl1 ");
            strSql.Append(" WHERE ProductId=?ProductId AND ImageUrl=?ImageUrl");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,255),
					new MySqlParameter("?ThumbnailUrl1", MySqlDbType.VarChar,255),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8)};
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
        #endregion 
    }
}

