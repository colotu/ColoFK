/**
* ShippingType.cs
*
* 功 能： N/A
* 类 名： ShippingType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/27 10:24:45   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Shipping;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Shipping
{
	/// <summary>
	/// 数据访问类:ShippingType
	/// </summary>
	public partial class ShippingType:IShippingType
	{
		public ShippingType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ModeId", "Shop_ShippingType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ModeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_ShippingType");
			strSql.Append(" where ModeId=?ModeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ModeId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Shipping.ShippingType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_ShippingType(");
            strSql.Append("Name,Weight,AddWeight,Price,AddPrice,Description,DisplaySequence,ExpressCompanyName,ExpressCompanyEn,SupplierId)");
			strSql.Append(" values (");
			strSql.Append("?Name,?Weight,?AddWeight,?Price,?AddPrice,?Description,?DisplaySequence,?ExpressCompanyName,?ExpressCompanyEn,?SupplierId)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?AddWeight", MySqlDbType.Int32,4),
					new MySqlParameter("?Price", MySqlDbType.Decimal,8),
					new MySqlParameter("?AddPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Description", MySqlDbType.VarChar,4000),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?ExpressCompanyName", MySqlDbType.VarChar,500),
					new MySqlParameter("?ExpressCompanyEn", MySqlDbType.VarChar,500),
                                        new MySqlParameter("?SupplierId",MySqlDbType.Int32) };
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Weight;
			parameters[2].Value = model.AddWeight;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.AddPrice;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.DisplaySequence;
			parameters[7].Value = model.ExpressCompanyName;
			parameters[8].Value = model.ExpressCompanyEn;
		    parameters[9].Value = model.SupplierId;
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
		public bool Update(YSWL.MALL.Model.Shop.Shipping.ShippingType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_ShippingType set ");
			strSql.Append("Name=?Name,");
			strSql.Append("Weight=?Weight,");
			strSql.Append("AddWeight=?AddWeight,");
			strSql.Append("Price=?Price,");
			strSql.Append("AddPrice=?AddPrice,");
			strSql.Append("Description=?Description,");
			strSql.Append("DisplaySequence=?DisplaySequence,");
			strSql.Append("ExpressCompanyName=?ExpressCompanyName,");
			strSql.Append("ExpressCompanyEn=?ExpressCompanyEn,");
            strSql.Append("SupplierId=?SupplierId");
			strSql.Append(" where ModeId=?ModeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?Weight", MySqlDbType.Int32,4),
					new MySqlParameter("?AddWeight", MySqlDbType.Int32,4),
					new MySqlParameter("?Price", MySqlDbType.Decimal,8),
					new MySqlParameter("?AddPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Description", MySqlDbType.VarChar,4000),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?ExpressCompanyName", MySqlDbType.VarChar,500),
					new MySqlParameter("?ExpressCompanyEn", MySqlDbType.VarChar,500),
                    new MySqlParameter("?SupplierId", MySqlDbType.Int32),
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Weight;
			parameters[2].Value = model.AddWeight;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.AddPrice;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.DisplaySequence;
			parameters[7].Value = model.ExpressCompanyName;
			parameters[8].Value = model.ExpressCompanyEn;
            parameters[9].Value = model.SupplierId;
			parameters[10].Value = model.ModeId;

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
		public bool Delete(int ModeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_ShippingType ");
			strSql.Append(" where ModeId=?ModeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ModeId;

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
		public bool DeleteList(string ModeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_ShippingType ");
			strSql.Append(" where ModeId in ("+ModeIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Shipping.ShippingType GetModel(int ModeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ModeId,Name,Weight,AddWeight,Price,AddPrice,Description,DisplaySequence,ExpressCompanyName,ExpressCompanyEn,SupplierId from Shop_ShippingType ");
			strSql.Append(" where ModeId=?ModeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ModeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ModeId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Shipping.ShippingType model=new YSWL.MALL.Model.Shop.Shipping.ShippingType();
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
		public YSWL.MALL.Model.Shop.Shipping.ShippingType DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Shipping.ShippingType model=new YSWL.MALL.Model.Shop.Shipping.ShippingType();
			if (row != null)
			{
				if(row["ModeId"]!=null && row["ModeId"].ToString()!="")
				{
					model.ModeId=int.Parse(row["ModeId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Weight"]!=null && row["Weight"].ToString()!="")
				{
					model.Weight=int.Parse(row["Weight"].ToString());
				}
				if(row["AddWeight"]!=null && row["AddWeight"].ToString()!="")
				{
					model.AddWeight=int.Parse(row["AddWeight"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["AddPrice"]!=null && row["AddPrice"].ToString()!="")
				{
					model.AddPrice=decimal.Parse(row["AddPrice"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["DisplaySequence"]!=null && row["DisplaySequence"].ToString()!="")
				{
					model.DisplaySequence=int.Parse(row["DisplaySequence"].ToString());
				}
				if(row["ExpressCompanyName"]!=null)
				{
					model.ExpressCompanyName=row["ExpressCompanyName"].ToString();
				}
				if(row["ExpressCompanyEn"]!=null)
				{
					model.ExpressCompanyEn=row["ExpressCompanyEn"].ToString();
				}
                if (row["SupplierId"] != null)
                {
                    model.SupplierId = int.Parse(row["SupplierId"].ToString());
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
			strSql.Append("select ModeId,Name,Weight,AddWeight,Price,AddPrice,Description,DisplaySequence,ExpressCompanyName,ExpressCompanyEn,SupplierId ");
			strSql.Append(" FROM Shop_ShippingType ");
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
            strSql.Append(" ModeId,Name,Weight,AddWeight,Price,AddPrice,Description,DisplaySequence,ExpressCompanyName,ExpressCompanyEn,SupplierId ");
			strSql.Append(" FROM Shop_ShippingType ");
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
			strSql.Append("select count(1) FROM Shop_ShippingType ");
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
            strSql.Append("SELECT T.* from Shop_ShippingType T ");
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
                strSql.Append(" order by T.ModeId desc");
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
			parameters[0].Value = "Shop_ShippingType";
			parameters[1].Value = "ModeId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod



        public Model.Shop.Shipping.ShippingType GetShippingTypeByAddress(int shippingId)
        {
            throw new NotImplementedException();
        }

        public YSWL.MALL.Model.Shop.Shipping.ShippingType GetModelByUser(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion  ExtensionMethod

    }
}

