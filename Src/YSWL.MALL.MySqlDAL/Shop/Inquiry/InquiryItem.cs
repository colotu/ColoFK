/**
* InquiryItem.cs
*
* 功 能： N/A
* 类 名： InquiryItem
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/9/4 19:23:30   N/A    初版
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
using YSWL.MALL.IDAL.Shop.Inquiry;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Inquiry
{
	/// <summary>
	/// 数据访问类:InquiryItem
	/// </summary>
	public partial class InquiryItem:IInquiryItem
	{
		public InquiryItem()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ItemId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_InquiryItem");
			strSql.Append(" where ItemId=?ItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ItemId", MySqlDbType.Int64)
			};
			parameters[0].Value = ItemId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(YSWL.MALL.Model.Shop.Inquiry.InquiryItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_InquiryItem(");
			strSql.Append("InquiryId,TargetId,Type,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName)");
			strSql.Append(" values (");
			strSql.Append("?InquiryId,?TargetId,?Type,?ProductCode,?SKU,?Name,?ThumbnailsUrl,?Description,?Quantity,?CostPrice,?SellPrice,?AdjustedPrice,?Attribute,?Remark,?Weight,?Deduct,?Points,?ProductLineId,?SupplierId,?SupplierName)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?InquiryId", MySqlDbType.Int64,8),
					new MySqlParameter("?TargetId", MySqlDbType.Int64,8),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?ProductCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,200),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SellPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?AdjustedPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Attribute", MySqlDbType.Text),
					new MySqlParameter("?Remark", MySqlDbType.Text),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?Deduct", MySqlDbType.Decimal,8),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductLineId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.InquiryId;
			parameters[1].Value = model.TargetId;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.ProductCode;
			parameters[4].Value = model.SKU;
			parameters[5].Value = model.Name;
			parameters[6].Value = model.ThumbnailsUrl;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.Quantity;
			parameters[9].Value = model.CostPrice;
			parameters[10].Value = model.SellPrice;
			parameters[11].Value = model.AdjustedPrice;
			parameters[12].Value = model.Attribute;
			parameters[13].Value = model.Remark;
			parameters[14].Value = model.Weight;
			parameters[15].Value = model.Deduct;
			parameters[16].Value = model.Points;
			parameters[17].Value = model.ProductLineId;
			parameters[18].Value = model.SupplierId;
			parameters[19].Value = model.SupplierName;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.Shop.Inquiry.InquiryItem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_InquiryItem set ");
			strSql.Append("InquiryId=?InquiryId,");
			strSql.Append("TargetId=?TargetId,");
			strSql.Append("Type=?Type,");
			strSql.Append("ProductCode=?ProductCode,");
			strSql.Append("SKU=?SKU,");
			strSql.Append("Name=?Name,");
			strSql.Append("ThumbnailsUrl=?ThumbnailsUrl,");
			strSql.Append("Description=?Description,");
			strSql.Append("Quantity=?Quantity,");
			strSql.Append("CostPrice=?CostPrice,");
			strSql.Append("SellPrice=?SellPrice,");
			strSql.Append("AdjustedPrice=?AdjustedPrice,");
			strSql.Append("Attribute=?Attribute,");
			strSql.Append("Remark=?Remark,");
			strSql.Append("Weight=?Weight,");
			strSql.Append("Deduct=?Deduct,");
			strSql.Append("Points=?Points,");
			strSql.Append("ProductLineId=?ProductLineId,");
			strSql.Append("SupplierId=?SupplierId,");
			strSql.Append("SupplierName=?SupplierName");
			strSql.Append(" where ItemId=?ItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?InquiryId", MySqlDbType.Int64,8),
					new MySqlParameter("?TargetId", MySqlDbType.Int64,8),
					new MySqlParameter("?Type", MySqlDbType.Int16,2),
					new MySqlParameter("?ProductCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?SKU", MySqlDbType.VarChar,200),
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?Quantity", MySqlDbType.Int32,4),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SellPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?AdjustedPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Attribute", MySqlDbType.Text),
					new MySqlParameter("?Remark", MySqlDbType.Text),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?Deduct", MySqlDbType.Decimal,8),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductLineId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?SupplierName", MySqlDbType.VarChar,100),
					new MySqlParameter("?ItemId", MySqlDbType.Int64,8)};
			parameters[0].Value = model.InquiryId;
			parameters[1].Value = model.TargetId;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.ProductCode;
			parameters[4].Value = model.SKU;
			parameters[5].Value = model.Name;
			parameters[6].Value = model.ThumbnailsUrl;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.Quantity;
			parameters[9].Value = model.CostPrice;
			parameters[10].Value = model.SellPrice;
			parameters[11].Value = model.AdjustedPrice;
			parameters[12].Value = model.Attribute;
			parameters[13].Value = model.Remark;
			parameters[14].Value = model.Weight;
			parameters[15].Value = model.Deduct;
			parameters[16].Value = model.Points;
			parameters[17].Value = model.ProductLineId;
			parameters[18].Value = model.SupplierId;
			parameters[19].Value = model.SupplierName;
			parameters[20].Value = model.ItemId;

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
		public bool Delete(long ItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_InquiryItem ");
			strSql.Append(" where ItemId=?ItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ItemId", MySqlDbType.Int64)
			};
			parameters[0].Value = ItemId;

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
		public bool DeleteList(string ItemIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_InquiryItem ");
			strSql.Append(" where ItemId in ("+ItemIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Inquiry.InquiryItem GetModel(long ItemId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ItemId,InquiryId,TargetId,Type,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName from Shop_InquiryItem ");
			strSql.Append(" where ItemId=?ItemId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ItemId", MySqlDbType.Int64)
			};
			parameters[0].Value = ItemId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Inquiry.InquiryItem model=new YSWL.MALL.Model.Shop.Inquiry.InquiryItem();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public YSWL.MALL.Model.Shop.Inquiry.InquiryItem DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Inquiry.InquiryItem model=new YSWL.MALL.Model.Shop.Inquiry.InquiryItem();
			if (row != null)
			{
				if(row["ItemId"]!=null && row["ItemId"].ToString()!="")
				{
					model.ItemId=long.Parse(row["ItemId"].ToString());
				}
				if(row["InquiryId"]!=null && row["InquiryId"].ToString()!="")
				{
					model.InquiryId=long.Parse(row["InquiryId"].ToString());
				}
				if(row["TargetId"]!=null && row["TargetId"].ToString()!="")
				{
					model.TargetId=long.Parse(row["TargetId"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["ProductCode"]!=null)
				{
					model.ProductCode=row["ProductCode"].ToString();
				}
				if(row["SKU"]!=null)
				{
					model.SKU=row["SKU"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["ThumbnailsUrl"]!=null)
				{
					model.ThumbnailsUrl=row["ThumbnailsUrl"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Quantity"]!=null && row["Quantity"].ToString()!="")
				{
					model.Quantity=int.Parse(row["Quantity"].ToString());
				}
				if(row["CostPrice"]!=null && row["CostPrice"].ToString()!="")
				{
					model.CostPrice=decimal.Parse(row["CostPrice"].ToString());
				}
				if(row["SellPrice"]!=null && row["SellPrice"].ToString()!="")
				{
					model.SellPrice=decimal.Parse(row["SellPrice"].ToString());
				}
				if(row["AdjustedPrice"]!=null && row["AdjustedPrice"].ToString()!="")
				{
					model.AdjustedPrice=decimal.Parse(row["AdjustedPrice"].ToString());
				}
				if(row["Attribute"]!=null)
				{
					model.Attribute=row["Attribute"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["Weight"]!=null && row["Weight"].ToString()!="")
				{
					model.Weight=int.Parse(row["Weight"].ToString());
				}
				if(row["Deduct"]!=null && row["Deduct"].ToString()!="")
				{
					model.Deduct=decimal.Parse(row["Deduct"].ToString());
				}
				if(row["Points"]!=null && row["Points"].ToString()!="")
				{
					model.Points=int.Parse(row["Points"].ToString());
				}
				if(row["ProductLineId"]!=null && row["ProductLineId"].ToString()!="")
				{
					model.ProductLineId=int.Parse(row["ProductLineId"].ToString());
				}
				if(row["SupplierId"]!=null && row["SupplierId"].ToString()!="")
				{
					model.SupplierId=int.Parse(row["SupplierId"].ToString());
				}
				if(row["SupplierName"]!=null)
				{
					model.SupplierName=row["SupplierName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ItemId,InquiryId,TargetId,Type,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName ");
			strSql.Append(" FROM Shop_InquiryItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(" ItemId,InquiryId,TargetId,Type,ProductCode,SKU,Name,ThumbnailsUrl,Description,Quantity,CostPrice,SellPrice,AdjustedPrice,Attribute,Remark,Weight,Deduct,Points,ProductLineId,SupplierId,SupplierName ");
			strSql.Append(" FROM Shop_InquiryItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Shop_InquiryItem ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
            strSql.Append("SELECT T.* from Shop_InquiryItem T ");
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
                strSql.Append(" order by T.ItemId desc");
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
			parameters[0].Value = "Shop_InquiryItem";
			parameters[1].Value = "ItemId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

