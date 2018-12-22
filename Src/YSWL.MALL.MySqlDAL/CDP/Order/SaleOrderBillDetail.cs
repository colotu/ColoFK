/**  版本信息模板在安装目录下，可自行修改。
* saleorderbilldetail.cs
*
* 功 能： N/A
* 类 名： saleorderbilldetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/15 11:30:17   N/A    初版
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
using YSWL.IDAL.ERP.Order;
using MySql.Data.MySqlClient;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.Order
{
	/// <summary>
	/// 数据访问类:saleorderbilldetail
	/// </summary>
	public partial class SaleOrderBillDetail:ISaleOrderBillDetail
	{
        public SaleOrderBillDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from saleorderbilldetail");
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
        public bool Add(YSWL.Model.ERP.Order.SaleOrderBillDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into saleorderbilldetail(");
			strSql.Append("batchMoney,batchNum,batchPrice,billCode,blGift,blProxy,costMoney,costOperateWay,costPrice,expiryDate,jwh,money,oldBillCode,oldBillOrdinal,ordinal,pieceCostPrice,piecePrice,pieceQty,price,profit,qty,qtyOfPackage,rates,retailMoney,retailPrice,returnCause,scatteredQty,specification,tradePrice,unit,bill_id,goods_id,store_id,saleType,blSolutionGroupFirst,promotionalSolution,solutionGroupId,solutionMultiple,solutionPieceQty,solutionQty,solutionScatteredQty,promotional_Solution_id,defTotalPieceQty,solutionType,orderItemOrdinal,deliverFee,pieceDeliverFee,blBorrow)");
			strSql.Append(" values (");
			strSql.Append("?batchMoney,?batchNum,?batchPrice,?billCode,?blGift,?blProxy,?costMoney,?costOperateWay,?costPrice,?expiryDate,?jwh,?money,?oldBillCode,?oldBillOrdinal,?ordinal,?pieceCostPrice,?piecePrice,?pieceQty,?price,?profit,?qty,?qtyOfPackage,?rates,?retailMoney,?retailPrice,?returnCause,?scatteredQty,?specification,?tradePrice,?unit,?bill_id,?goods_id,?store_id,?saleType,?blSolutionGroupFirst,?promotionalSolution,?solutionGroupId,?solutionMultiple,?solutionPieceQty,?solutionQty,?solutionScatteredQty,?promotional_Solution_id,?defTotalPieceQty,?solutionType,?orderItemOrdinal,?deliverFee,?pieceDeliverFee,?blBorrow)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?batchMoney", MySqlDbType.Double),
					new MySqlParameter("?batchNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?batchPrice", MySqlDbType.Double),
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?blGift", MySqlDbType.Bit),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?costMoney", MySqlDbType.Double),
					new MySqlParameter("?costOperateWay", MySqlDbType.VarChar,30),
					new MySqlParameter("?costPrice", MySqlDbType.Double),
					new MySqlParameter("?expiryDate", MySqlDbType.Date),
					new MySqlParameter("?jwh", MySqlDbType.VarChar,60),
					new MySqlParameter("?money", MySqlDbType.Double),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?oldBillOrdinal", MySqlDbType.Int32,11),
					new MySqlParameter("?ordinal", MySqlDbType.Int32,11),
					new MySqlParameter("?pieceCostPrice", MySqlDbType.Double),
					new MySqlParameter("?piecePrice", MySqlDbType.Double),
					new MySqlParameter("?pieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?price", MySqlDbType.Double),
					new MySqlParameter("?profit", MySqlDbType.Double),
					new MySqlParameter("?qty", MySqlDbType.Double),
					new MySqlParameter("?qtyOfPackage", MySqlDbType.Int32,11),
					new MySqlParameter("?rates", MySqlDbType.Double),
					new MySqlParameter("?retailMoney", MySqlDbType.Double),
					new MySqlParameter("?retailPrice", MySqlDbType.Double),
					new MySqlParameter("?returnCause", MySqlDbType.VarChar,100),
					new MySqlParameter("?scatteredQty", MySqlDbType.Int32,11),
					new MySqlParameter("?specification", MySqlDbType.VarChar,60),
					new MySqlParameter("?tradePrice", MySqlDbType.Double),
					new MySqlParameter("?unit", MySqlDbType.VarChar,30),
					new MySqlParameter("?bill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?goods_id", MySqlDbType.Int64,20),
					new MySqlParameter("?store_id", MySqlDbType.Int64,20),
					new MySqlParameter("?saleType", MySqlDbType.Int32,11),
					new MySqlParameter("?blSolutionGroupFirst", MySqlDbType.Bit),
					new MySqlParameter("?promotionalSolution", MySqlDbType.TinyBlob),
					new MySqlParameter("?solutionGroupId", MySqlDbType.VarChar,80),
					new MySqlParameter("?solutionMultiple", MySqlDbType.Int32,11),
					new MySqlParameter("?solutionPieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?solutionQty", MySqlDbType.Double),
					new MySqlParameter("?solutionScatteredQty", MySqlDbType.Int32,11),
					new MySqlParameter("?promotional_Solution_id", MySqlDbType.Int64,20),
					new MySqlParameter("?defTotalPieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?solutionType", MySqlDbType.VarChar,1),
					new MySqlParameter("?orderItemOrdinal", MySqlDbType.Int32,11),
					new MySqlParameter("?deliverFee", MySqlDbType.Double),
					new MySqlParameter("?pieceDeliverFee", MySqlDbType.Double),
					new MySqlParameter("?blBorrow", MySqlDbType.Bit)};
			parameters[0].Value = model.batchMoney;
			parameters[1].Value = model.batchNum;
			parameters[2].Value = model.batchPrice;
			parameters[3].Value = model.billCode;
			parameters[4].Value = model.blGift;
			parameters[5].Value = model.blProxy;
			parameters[6].Value = model.costMoney;
			parameters[7].Value = model.costOperateWay;
			parameters[8].Value = model.costPrice;
			parameters[9].Value = model.expiryDate;
			parameters[10].Value = model.jwh;
			parameters[11].Value = model.money;
			parameters[12].Value = model.oldBillCode;
			parameters[13].Value = model.oldBillOrdinal;
			parameters[14].Value = model.ordinal;
			parameters[15].Value = model.pieceCostPrice;
			parameters[16].Value = model.piecePrice;
			parameters[17].Value = model.pieceQty;
			parameters[18].Value = model.price;
			parameters[19].Value = model.profit;
			parameters[20].Value = model.qty;
			parameters[21].Value = model.qtyOfPackage;
			parameters[22].Value = model.rates;
			parameters[23].Value = model.retailMoney;
			parameters[24].Value = model.retailPrice;
			parameters[25].Value = model.returnCause;
			parameters[26].Value = model.scatteredQty;
			parameters[27].Value = model.specification;
			parameters[28].Value = model.tradePrice;
			parameters[29].Value = model.unit;
			parameters[30].Value = model.bill_id;
			parameters[31].Value = model.goods_id;
			parameters[32].Value = model.store_id;
			parameters[33].Value = model.saleType;
			parameters[34].Value = model.blSolutionGroupFirst;
			parameters[35].Value = model.promotionalSolution;
			parameters[36].Value = model.solutionGroupId;
			parameters[37].Value = model.solutionMultiple;
			parameters[38].Value = model.solutionPieceQty;
			parameters[39].Value = model.solutionQty;
			parameters[40].Value = model.solutionScatteredQty;
			parameters[41].Value = model.promotional_Solution_id;
			parameters[42].Value = model.defTotalPieceQty;
			parameters[43].Value = model.solutionType;
			parameters[44].Value = model.orderItemOrdinal;
			parameters[45].Value = model.deliverFee;
			parameters[46].Value = model.pieceDeliverFee;
			parameters[47].Value = model.blBorrow;

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
        public bool Update(YSWL.Model.ERP.Order.SaleOrderBillDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update saleorderbilldetail set ");
			strSql.Append("batchMoney=?batchMoney,");
			strSql.Append("batchNum=?batchNum,");
			strSql.Append("batchPrice=?batchPrice,");
			strSql.Append("billCode=?billCode,");
			strSql.Append("blGift=?blGift,");
			strSql.Append("blProxy=?blProxy,");
			strSql.Append("costMoney=?costMoney,");
			strSql.Append("costOperateWay=?costOperateWay,");
			strSql.Append("costPrice=?costPrice,");
			strSql.Append("expiryDate=?expiryDate,");
			strSql.Append("jwh=?jwh,");
			strSql.Append("money=?money,");
			strSql.Append("oldBillCode=?oldBillCode,");
			strSql.Append("oldBillOrdinal=?oldBillOrdinal,");
			strSql.Append("ordinal=?ordinal,");
			strSql.Append("pieceCostPrice=?pieceCostPrice,");
			strSql.Append("piecePrice=?piecePrice,");
			strSql.Append("pieceQty=?pieceQty,");
			strSql.Append("price=?price,");
			strSql.Append("profit=?profit,");
			strSql.Append("qty=?qty,");
			strSql.Append("qtyOfPackage=?qtyOfPackage,");
			strSql.Append("rates=?rates,");
			strSql.Append("retailMoney=?retailMoney,");
			strSql.Append("retailPrice=?retailPrice,");
			strSql.Append("returnCause=?returnCause,");
			strSql.Append("scatteredQty=?scatteredQty,");
			strSql.Append("specification=?specification,");
			strSql.Append("tradePrice=?tradePrice,");
			strSql.Append("unit=?unit,");
			strSql.Append("bill_id=?bill_id,");
			strSql.Append("goods_id=?goods_id,");
			strSql.Append("store_id=?store_id,");
			strSql.Append("saleType=?saleType,");
			strSql.Append("blSolutionGroupFirst=?blSolutionGroupFirst,");
			strSql.Append("promotionalSolution=?promotionalSolution,");
			strSql.Append("solutionGroupId=?solutionGroupId,");
			strSql.Append("solutionMultiple=?solutionMultiple,");
			strSql.Append("solutionPieceQty=?solutionPieceQty,");
			strSql.Append("solutionQty=?solutionQty,");
			strSql.Append("solutionScatteredQty=?solutionScatteredQty,");
			strSql.Append("promotional_Solution_id=?promotional_Solution_id,");
			strSql.Append("defTotalPieceQty=?defTotalPieceQty,");
			strSql.Append("solutionType=?solutionType,");
			strSql.Append("orderItemOrdinal=?orderItemOrdinal,");
			strSql.Append("deliverFee=?deliverFee,");
			strSql.Append("pieceDeliverFee=?pieceDeliverFee,");
			strSql.Append("blBorrow=?blBorrow");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?batchMoney", MySqlDbType.Double),
					new MySqlParameter("?batchNum", MySqlDbType.VarChar,80),
					new MySqlParameter("?batchPrice", MySqlDbType.Double),
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?blGift", MySqlDbType.Bit),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?costMoney", MySqlDbType.Double),
					new MySqlParameter("?costOperateWay", MySqlDbType.VarChar,30),
					new MySqlParameter("?costPrice", MySqlDbType.Double),
					new MySqlParameter("?expiryDate", MySqlDbType.Date),
					new MySqlParameter("?jwh", MySqlDbType.VarChar,60),
					new MySqlParameter("?money", MySqlDbType.Double),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?oldBillOrdinal", MySqlDbType.Int32,11),
					new MySqlParameter("?ordinal", MySqlDbType.Int32,11),
					new MySqlParameter("?pieceCostPrice", MySqlDbType.Double),
					new MySqlParameter("?piecePrice", MySqlDbType.Double),
					new MySqlParameter("?pieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?price", MySqlDbType.Double),
					new MySqlParameter("?profit", MySqlDbType.Double),
					new MySqlParameter("?qty", MySqlDbType.Double),
					new MySqlParameter("?qtyOfPackage", MySqlDbType.Int32,11),
					new MySqlParameter("?rates", MySqlDbType.Double),
					new MySqlParameter("?retailMoney", MySqlDbType.Double),
					new MySqlParameter("?retailPrice", MySqlDbType.Double),
					new MySqlParameter("?returnCause", MySqlDbType.VarChar,100),
					new MySqlParameter("?scatteredQty", MySqlDbType.Int32,11),
					new MySqlParameter("?specification", MySqlDbType.VarChar,60),
					new MySqlParameter("?tradePrice", MySqlDbType.Double),
					new MySqlParameter("?unit", MySqlDbType.VarChar,30),
					new MySqlParameter("?bill_id", MySqlDbType.Int64,20),
					new MySqlParameter("?goods_id", MySqlDbType.Int64,20),
					new MySqlParameter("?store_id", MySqlDbType.Int64,20),
					new MySqlParameter("?saleType", MySqlDbType.Int32,11),
					new MySqlParameter("?blSolutionGroupFirst", MySqlDbType.Bit),
					new MySqlParameter("?promotionalSolution", MySqlDbType.TinyBlob),
					new MySqlParameter("?solutionGroupId", MySqlDbType.VarChar,80),
					new MySqlParameter("?solutionMultiple", MySqlDbType.Int32,11),
					new MySqlParameter("?solutionPieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?solutionQty", MySqlDbType.Double),
					new MySqlParameter("?solutionScatteredQty", MySqlDbType.Int32,11),
					new MySqlParameter("?promotional_Solution_id", MySqlDbType.Int64,20),
					new MySqlParameter("?defTotalPieceQty", MySqlDbType.Int32,11),
					new MySqlParameter("?solutionType", MySqlDbType.VarChar,1),
					new MySqlParameter("?orderItemOrdinal", MySqlDbType.Int32,11),
					new MySqlParameter("?deliverFee", MySqlDbType.Double),
					new MySqlParameter("?pieceDeliverFee", MySqlDbType.Double),
					new MySqlParameter("?blBorrow", MySqlDbType.Bit),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.batchMoney;
			parameters[1].Value = model.batchNum;
			parameters[2].Value = model.batchPrice;
			parameters[3].Value = model.billCode;
			parameters[4].Value = model.blGift;
			parameters[5].Value = model.blProxy;
			parameters[6].Value = model.costMoney;
			parameters[7].Value = model.costOperateWay;
			parameters[8].Value = model.costPrice;
			parameters[9].Value = model.expiryDate;
			parameters[10].Value = model.jwh;
			parameters[11].Value = model.money;
			parameters[12].Value = model.oldBillCode;
			parameters[13].Value = model.oldBillOrdinal;
			parameters[14].Value = model.ordinal;
			parameters[15].Value = model.pieceCostPrice;
			parameters[16].Value = model.piecePrice;
			parameters[17].Value = model.pieceQty;
			parameters[18].Value = model.price;
			parameters[19].Value = model.profit;
			parameters[20].Value = model.qty;
			parameters[21].Value = model.qtyOfPackage;
			parameters[22].Value = model.rates;
			parameters[23].Value = model.retailMoney;
			parameters[24].Value = model.retailPrice;
			parameters[25].Value = model.returnCause;
			parameters[26].Value = model.scatteredQty;
			parameters[27].Value = model.specification;
			parameters[28].Value = model.tradePrice;
			parameters[29].Value = model.unit;
			parameters[30].Value = model.bill_id;
			parameters[31].Value = model.goods_id;
			parameters[32].Value = model.store_id;
			parameters[33].Value = model.saleType;
			parameters[34].Value = model.blSolutionGroupFirst;
			parameters[35].Value = model.promotionalSolution;
			parameters[36].Value = model.solutionGroupId;
			parameters[37].Value = model.solutionMultiple;
			parameters[38].Value = model.solutionPieceQty;
			parameters[39].Value = model.solutionQty;
			parameters[40].Value = model.solutionScatteredQty;
			parameters[41].Value = model.promotional_Solution_id;
			parameters[42].Value = model.defTotalPieceQty;
			parameters[43].Value = model.solutionType;
			parameters[44].Value = model.orderItemOrdinal;
			parameters[45].Value = model.deliverFee;
			parameters[46].Value = model.pieceDeliverFee;
			parameters[47].Value = model.blBorrow;
			parameters[48].Value = model.id;

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
			strSql.Append("delete from saleorderbilldetail ");
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
			strSql.Append("delete from saleorderbilldetail ");
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
        public YSWL.Model.ERP.Order.SaleOrderBillDetail GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,batchMoney,batchNum,batchPrice,billCode,blGift,blProxy,costMoney,costOperateWay,costPrice,expiryDate,jwh,money,oldBillCode,oldBillOrdinal,ordinal,pieceCostPrice,piecePrice,pieceQty,price,profit,qty,qtyOfPackage,rates,retailMoney,retailPrice,returnCause,scatteredQty,specification,tradePrice,unit,bill_id,goods_id,store_id,saleType,blSolutionGroupFirst,promotionalSolution,solutionGroupId,solutionMultiple,solutionPieceQty,solutionQty,solutionScatteredQty,promotional_Solution_id,defTotalPieceQty,solutionType,orderItemOrdinal,deliverFee,pieceDeliverFee,blBorrow from saleorderbilldetail ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

            YSWL.Model.ERP.Order.SaleOrderBillDetail model = new YSWL.Model.ERP.Order.SaleOrderBillDetail();
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
        public YSWL.Model.ERP.Order.SaleOrderBillDetail DataRowToModel(DataRow row)
		{
            YSWL.Model.ERP.Order.SaleOrderBillDetail model = new YSWL.Model.ERP.Order.SaleOrderBillDetail();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
					//model.batchMoney=row["batchMoney"].ToString();
				if(row["batchNum"]!=null)
				{
					model.batchNum=row["batchNum"].ToString();
				}
					//model.batchPrice=row["batchPrice"].ToString();
				if(row["billCode"]!=null)
				{
					model.billCode=row["billCode"].ToString();
				}
				if(row["blGift"]!=null && row["blGift"].ToString()!="")
				{
					if((row["blGift"].ToString()=="1")||(row["blGift"].ToString().ToLower()=="true"))
					{
						model.blGift=true;
					}
					else
					{
						model.blGift=false;
					}
				}
				if(row["blProxy"]!=null && row["blProxy"].ToString()!="")
				{
					if((row["blProxy"].ToString()=="1")||(row["blProxy"].ToString().ToLower()=="true"))
					{
						model.blProxy=true;
					}
					else
					{
						model.blProxy=false;
					}
				}
					//model.costMoney=row["costMoney"].ToString();
				if(row["costOperateWay"]!=null)
				{
					model.costOperateWay=row["costOperateWay"].ToString();
				}
					//model.costPrice=row["costPrice"].ToString();
				if(row["expiryDate"]!=null && row["expiryDate"].ToString()!="")
				{
					model.expiryDate=DateTime.Parse(row["expiryDate"].ToString());
				}
				if(row["jwh"]!=null)
				{
					model.jwh=row["jwh"].ToString();
				}
					//model.money=row["money"].ToString();
				if(row["oldBillCode"]!=null)
				{
					model.oldBillCode=row["oldBillCode"].ToString();
				}
				if(row["oldBillOrdinal"]!=null && row["oldBillOrdinal"].ToString()!="")
				{
					model.oldBillOrdinal=int.Parse(row["oldBillOrdinal"].ToString());
				}
				if(row["ordinal"]!=null && row["ordinal"].ToString()!="")
				{
					model.ordinal=int.Parse(row["ordinal"].ToString());
				}
					//model.pieceCostPrice=row["pieceCostPrice"].ToString();
					//model.piecePrice=row["piecePrice"].ToString();
				if(row["pieceQty"]!=null && row["pieceQty"].ToString()!="")
				{
					model.pieceQty=int.Parse(row["pieceQty"].ToString());
				}
					//model.price=row["price"].ToString();
					//model.profit=row["profit"].ToString();
					//model.qty=row["qty"].ToString();
				if(row["qtyOfPackage"]!=null && row["qtyOfPackage"].ToString()!="")
				{
					model.qtyOfPackage=int.Parse(row["qtyOfPackage"].ToString());
				}
					//model.rates=row["rates"].ToString();
					//model.retailMoney=row["retailMoney"].ToString();
					//model.retailPrice=row["retailPrice"].ToString();
				if(row["returnCause"]!=null)
				{
					model.returnCause=row["returnCause"].ToString();
				}
				if(row["scatteredQty"]!=null && row["scatteredQty"].ToString()!="")
				{
					model.scatteredQty=int.Parse(row["scatteredQty"].ToString());
				}
				if(row["specification"]!=null)
				{
					model.specification=row["specification"].ToString();
				}
					//model.tradePrice=row["tradePrice"].ToString();
				if(row["unit"]!=null)
				{
					model.unit=row["unit"].ToString();
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
				if(row["saleType"]!=null && row["saleType"].ToString()!="")
				{
					model.saleType=int.Parse(row["saleType"].ToString());
				}
				if(row["blSolutionGroupFirst"]!=null && row["blSolutionGroupFirst"].ToString()!="")
				{
					if((row["blSolutionGroupFirst"].ToString()=="1")||(row["blSolutionGroupFirst"].ToString().ToLower()=="true"))
					{
						model.blSolutionGroupFirst=true;
					}
					else
					{
						model.blSolutionGroupFirst=false;
					}
				}
					//model.promotionalSolution=row["promotionalSolution"].ToString();
				if(row["solutionGroupId"]!=null)
				{
					model.solutionGroupId=row["solutionGroupId"].ToString();
				}
				if(row["solutionMultiple"]!=null && row["solutionMultiple"].ToString()!="")
				{
					model.solutionMultiple=int.Parse(row["solutionMultiple"].ToString());
				}
				if(row["solutionPieceQty"]!=null && row["solutionPieceQty"].ToString()!="")
				{
					model.solutionPieceQty=int.Parse(row["solutionPieceQty"].ToString());
				}
					//model.solutionQty=row["solutionQty"].ToString();
				if(row["solutionScatteredQty"]!=null && row["solutionScatteredQty"].ToString()!="")
				{
					model.solutionScatteredQty=int.Parse(row["solutionScatteredQty"].ToString());
				}
				if(row["promotional_Solution_id"]!=null && row["promotional_Solution_id"].ToString()!="")
				{
					model.promotional_Solution_id=long.Parse(row["promotional_Solution_id"].ToString());
				}
				if(row["defTotalPieceQty"]!=null && row["defTotalPieceQty"].ToString()!="")
				{
					model.defTotalPieceQty=int.Parse(row["defTotalPieceQty"].ToString());
				}
				if(row["solutionType"]!=null)
				{
					model.solutionType=row["solutionType"].ToString();
				}
				if(row["orderItemOrdinal"]!=null && row["orderItemOrdinal"].ToString()!="")
				{
					model.orderItemOrdinal=int.Parse(row["orderItemOrdinal"].ToString());
				}
					//model.deliverFee=row["deliverFee"].ToString();
					//model.pieceDeliverFee=row["pieceDeliverFee"].ToString();
				if(row["blBorrow"]!=null && row["blBorrow"].ToString()!="")
				{
					if((row["blBorrow"].ToString()=="1")||(row["blBorrow"].ToString().ToLower()=="true"))
					{
						model.blBorrow=true;
					}
					else
					{
						model.blBorrow=false;
					}
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
			strSql.Append("select id,batchMoney,batchNum,batchPrice,billCode,blGift,blProxy,costMoney,costOperateWay,costPrice,expiryDate,jwh,money,oldBillCode,oldBillOrdinal,ordinal,pieceCostPrice,piecePrice,pieceQty,price,profit,qty,qtyOfPackage,rates,retailMoney,retailPrice,returnCause,scatteredQty,specification,tradePrice,unit,bill_id,goods_id,store_id,saleType,blSolutionGroupFirst,promotionalSolution,solutionGroupId,solutionMultiple,solutionPieceQty,solutionQty,solutionScatteredQty,promotional_Solution_id,defTotalPieceQty,solutionType,orderItemOrdinal,deliverFee,pieceDeliverFee,blBorrow ");
			strSql.Append(" FROM saleorderbilldetail ");
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
			strSql.Append("select count(1) FROM saleorderbilldetail ");
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
			strSql.Append(")AS Row, T.*  from saleorderbilldetail T ");
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
			parameters[0].Value = "saleorderbilldetail";
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

