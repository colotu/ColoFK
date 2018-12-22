/** 
* salepackingbillgoodsdetail.cs
*
* 功 能： N/A
* 类 名： salepackingbillgoodsdetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/14 16:03:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using YSWL.IDAL.ERP.SalePackingBill;
using MySql.Data.MySqlClient;
using YSWL.IDAL;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.SalePackingBill
{
	/// <summary>
	/// 数据访问类:salepackingbillgoodsdetail
	/// </summary>
    public partial class SalePackingBillGoodsDetail : ISalePackingBillGoodsDetail
	{
		public SalePackingBillGoodsDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from salepackingbillgoodsdetail");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into salepackingbillgoodsdetail(");
			strSql.Append("billCode,money,ordinal,pieceQty,profit,qty,qtyOfPackage,scatteredQty,bill_id,goods_id,store_id)");
			strSql.Append(" values (");
			strSql.Append("?billCode,?money,?ordinal,?pieceQty,?profit,?qty,?qtyOfPackage,?scatteredQty,?bill_id,?goods_id,?store_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?money", MySqlDbType.Double),
					new MySqlParameter("?ordinal", MySqlDbType.Int32,11),
					new MySqlParameter("?pieceQty", MySqlDbType.Int64,20),
					new MySqlParameter("?profit", MySqlDbType.Double),
					new MySqlParameter("?qty", MySqlDbType.Double),
					new MySqlParameter("?qtyOfPackage", MySqlDbType.Int32,11),
					new MySqlParameter("?scatteredQty", MySqlDbType.Int64,20),
					new MySqlParameter("?bill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?goods_id", MySqlDbType.Int64,20),
					new MySqlParameter("?store_id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.billCode;
			parameters[1].Value = model.money;
			parameters[2].Value = model.ordinal;
			parameters[3].Value = model.pieceQty;
			parameters[4].Value = model.profit;
			parameters[5].Value = model.qty;
			parameters[6].Value = model.qtyOfPackage;
			parameters[7].Value = model.scatteredQty;
			parameters[8].Value = model.bill_id;
			parameters[9].Value = model.goods_id;
			parameters[10].Value = model.store_id;

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
		/// 更新一条数据
		/// </summary>
        public bool Update(YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update salepackingbillgoodsdetail set ");
			strSql.Append("billCode=?billCode,");
			strSql.Append("money=?money,");
			strSql.Append("ordinal=?ordinal,");
			strSql.Append("pieceQty=?pieceQty,");
			strSql.Append("profit=?profit,");
			strSql.Append("qty=?qty,");
			strSql.Append("qtyOfPackage=?qtyOfPackage,");
			strSql.Append("scatteredQty=?scatteredQty,");
			strSql.Append("bill_id=?bill_id,");
			strSql.Append("goods_id=?goods_id,");
			strSql.Append("store_id=?store_id");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?money", MySqlDbType.Double),
					new MySqlParameter("?ordinal", MySqlDbType.Int32,11),
					new MySqlParameter("?pieceQty", MySqlDbType.Int64,20),
					new MySqlParameter("?profit", MySqlDbType.Double),
					new MySqlParameter("?qty", MySqlDbType.Double),
					new MySqlParameter("?qtyOfPackage", MySqlDbType.Int32,11),
					new MySqlParameter("?scatteredQty", MySqlDbType.Int64,20),
					new MySqlParameter("?bill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?goods_id", MySqlDbType.Int64,20),
					new MySqlParameter("?store_id", MySqlDbType.Int64,20),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.billCode;
			parameters[1].Value = model.money;
			parameters[2].Value = model.ordinal;
			parameters[3].Value = model.pieceQty;
			parameters[4].Value = model.profit;
			parameters[5].Value = model.qty;
			parameters[6].Value = model.qtyOfPackage;
			parameters[7].Value = model.scatteredQty;
			parameters[8].Value = model.bill_id;
			parameters[9].Value = model.goods_id;
			parameters[10].Value = model.store_id;
			parameters[11].Value = model.id;

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
		public bool Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from salepackingbillgoodsdetail ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from salepackingbillgoodsdetail ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
        public YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,billCode,money,ordinal,pieceQty,profit,qty,qtyOfPackage,scatteredQty,bill_id,goods_id,store_id from salepackingbillgoodsdetail ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

            YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail model = new YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail();
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
        public YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail DataRowToModel(DataRow row)
		{
            YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail model = new YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
				if(row["billCode"]!=null)
				{
					model.billCode=row["billCode"].ToString();
				}
					//model.money=row["money"].ToString();
				if(row["ordinal"]!=null && row["ordinal"].ToString()!="")
				{
					model.ordinal=int.Parse(row["ordinal"].ToString());
				}
				if(row["pieceQty"]!=null && row["pieceQty"].ToString()!="")
				{
					model.pieceQty=long.Parse(row["pieceQty"].ToString());
				}
					//model.profit=row["profit"].ToString();
					//model.qty=row["qty"].ToString();
				if(row["qtyOfPackage"]!=null && row["qtyOfPackage"].ToString()!="")
				{
					model.qtyOfPackage=int.Parse(row["qtyOfPackage"].ToString());
				}
				if(row["scatteredQty"]!=null && row["scatteredQty"].ToString()!="")
				{
					model.scatteredQty=long.Parse(row["scatteredQty"].ToString());
				}
				if(row["bill_id"]!=null && row["bill_id"].ToString()!="")
				{
					model.bill_id=long.Parse(row["bill_id"].ToString());
				}
				if(row["goods_id"]!=null && row["goods_id"].ToString()!="")
				{
					model.goods_id=long.Parse(row["goods_id"].ToString());
				}
				if(row["store_id"]!=null && row["store_id"].ToString()!="")
				{
					model.store_id=long.Parse(row["store_id"].ToString());
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
			strSql.Append("select id,billCode,money,ordinal,pieceQty,profit,qty,qtyOfPackage,scatteredQty,bill_id,goods_id,store_id ");
			strSql.Append(" FROM salepackingbillgoodsdetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM salepackingbillgoodsdetail ");
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from salepackingbillgoodsdetail T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "salepackingbillgoodsdetail";
			parameters[1].Value = "id";
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

