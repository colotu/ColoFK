/** 
* goods.cs
*
* 功 能： N/A
* 类 名： goods
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/14 16:03:35   N/A    初版
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
using YSWL.IDAL.ERP.Products;
using MySql.Data.MySqlClient;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.Products
{
	/// <summary>
	/// 数据访问类:goods
	/// </summary>
	public partial class Goods:IGoods
	{
		public Goods()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from goods");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,20)			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(YSWL.Model.ERP.Products.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into goods(");
			strSql.Append("id,active,approvalCertificate,bakName,barCode,baseQty,baseprice,blCommend,blGift,blMember,blSpecial,buyexplain,clickcount,code,createdate,description,discount,helpCode,lastModifyTime,lowestLimitSellPrice,manufacturer,marketprice,memberPrice,model,name,oldCode,qtyOfPackage,rate,rating,ratingCount,retailPrice,sellcount,sellprice,specification,stockPrice,tradePrice,unit,visible,weight,brand_id,categoryid,guaranteePeriod,addedTime,blHot,blSecKill,createTime,onLinePrice,specialEndTime,specialPrice,feature,goodsTag,keywords,orign,packingDeliver,deliverFee,pieceDeliverFee,goodsType,highestLimitSellPrice,volume,salesvalue)");
			strSql.Append(" values (");
			strSql.Append("?id,?active,?approvalCertificate,?bakName,?barCode,?baseQty,?baseprice,?blCommend,?blGift,?blMember,?blSpecial,?buyexplain,?clickcount,?code,?createdate,?description,?discount,?helpCode,?lastModifyTime,?lowestLimitSellPrice,?manufacturer,?marketprice,?memberPrice,?model,?name,?oldCode,?qtyOfPackage,?rate,?rating,?ratingCount,?retailPrice,?sellcount,?sellprice,?specification,?stockPrice,?tradePrice,?unit,?visible,?weight,?brand_id,?categoryid,?guaranteePeriod,?addedTime,?blHot,?blSecKill,?createTime,?onLinePrice,?specialEndTime,?specialPrice,?feature,?goodsTag,?keywords,?orign,?packingDeliver,?deliverFee,?pieceDeliverFee,?goodsType,?highestLimitSellPrice,?volume,?salesvalue)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,20),
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?approvalCertificate", MySqlDbType.VarChar,60),
					new MySqlParameter("?bakName", MySqlDbType.VarChar,80),
					new MySqlParameter("?barCode", MySqlDbType.VarChar,30),
					new MySqlParameter("?baseQty", MySqlDbType.Double),
					new MySqlParameter("?baseprice", MySqlDbType.Double),
					new MySqlParameter("?blCommend", MySqlDbType.Bit),
					new MySqlParameter("?blGift", MySqlDbType.Bit),
					new MySqlParameter("?blMember", MySqlDbType.Bit),
					new MySqlParameter("?blSpecial", MySqlDbType.Bit),
					new MySqlParameter("?buyexplain", MySqlDbType.VarChar,2000),
					new MySqlParameter("?clickcount", MySqlDbType.Int32,11),
					new MySqlParameter("?code", MySqlDbType.VarChar,80),
					new MySqlParameter("?createdate", MySqlDbType.DateTime),
					new MySqlParameter("?description", MySqlDbType.VarChar,2000),
					new MySqlParameter("?discount", MySqlDbType.Int32,11),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?lastModifyTime", MySqlDbType.DateTime),
					new MySqlParameter("?lowestLimitSellPrice", MySqlDbType.Double),
					new MySqlParameter("?manufacturer", MySqlDbType.VarChar,80),
					new MySqlParameter("?marketprice", MySqlDbType.Double),
					new MySqlParameter("?memberPrice", MySqlDbType.Double),
					new MySqlParameter("?model", MySqlDbType.VarChar,20),
					new MySqlParameter("?name", MySqlDbType.VarChar,80),
					new MySqlParameter("?oldCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?qtyOfPackage", MySqlDbType.Int32,11),
					new MySqlParameter("?rate", MySqlDbType.Double),
					new MySqlParameter("?rating", MySqlDbType.Int32,11),
					new MySqlParameter("?ratingCount", MySqlDbType.Int32,11),
					new MySqlParameter("?retailPrice", MySqlDbType.Double),
					new MySqlParameter("?sellcount", MySqlDbType.Double),
					new MySqlParameter("?sellprice", MySqlDbType.Double),
					new MySqlParameter("?specification", MySqlDbType.VarChar,60),
					new MySqlParameter("?stockPrice", MySqlDbType.Double),
					new MySqlParameter("?tradePrice", MySqlDbType.Double),
					new MySqlParameter("?unit", MySqlDbType.VarChar,10),
					new MySqlParameter("?visible", MySqlDbType.Bit),
					new MySqlParameter("?weight", MySqlDbType.Int32,11),
					new MySqlParameter("?brand_id", MySqlDbType.Int64,20),
					new MySqlParameter("?categoryid", MySqlDbType.Int64,20),
					new MySqlParameter("?guaranteePeriod", MySqlDbType.Int32,11),
					new MySqlParameter("?addedTime", MySqlDbType.DateTime),
					new MySqlParameter("?blHot", MySqlDbType.Bit),
					new MySqlParameter("?blSecKill", MySqlDbType.Bit),
					new MySqlParameter("?createTime", MySqlDbType.DateTime),
					new MySqlParameter("?onLinePrice", MySqlDbType.Double),
					new MySqlParameter("?specialEndTime", MySqlDbType.DateTime),
					new MySqlParameter("?specialPrice", MySqlDbType.Double),
					new MySqlParameter("?feature", MySqlDbType.LongText),
					new MySqlParameter("?goodsTag", MySqlDbType.VarChar,150),
					new MySqlParameter("?keywords", MySqlDbType.VarChar,100),
					new MySqlParameter("?orign", MySqlDbType.VarChar,100),
					new MySqlParameter("?packingDeliver", MySqlDbType.VarChar,1000),
					new MySqlParameter("?deliverFee", MySqlDbType.Double),
					new MySqlParameter("?pieceDeliverFee", MySqlDbType.Double),
					new MySqlParameter("?goodsType", MySqlDbType.Int32,11),
					new MySqlParameter("?highestLimitSellPrice", MySqlDbType.Double),
					new MySqlParameter("?volume", MySqlDbType.Double),
					new MySqlParameter("?salesvalue", MySqlDbType.Int32,15)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.active;
			parameters[2].Value = model.approvalCertificate;
			parameters[3].Value = model.bakName;
			parameters[4].Value = model.barCode;
			parameters[5].Value = model.baseQty;
			parameters[6].Value = model.baseprice;
			parameters[7].Value = model.blCommend;
			parameters[8].Value = model.blGift;
			parameters[9].Value = model.blMember;
			parameters[10].Value = model.blSpecial;
			parameters[11].Value = model.buyexplain;
			parameters[12].Value = model.clickcount;
			parameters[13].Value = model.code;
			parameters[14].Value = model.createdate;
			parameters[15].Value = model.description;
			parameters[16].Value = model.discount;
			parameters[17].Value = model.helpCode;
			parameters[18].Value = model.lastModifyTime;
			parameters[19].Value = model.lowestLimitSellPrice;
			parameters[20].Value = model.manufacturer;
			parameters[21].Value = model.marketprice;
			parameters[22].Value = model.memberPrice;
			parameters[23].Value = model.model;
			parameters[24].Value = model.name;
			parameters[25].Value = model.oldCode;
			parameters[26].Value = model.qtyOfPackage;
			parameters[27].Value = model.rate;
			parameters[28].Value = model.rating;
			parameters[29].Value = model.ratingCount;
			parameters[30].Value = model.retailPrice;
			parameters[31].Value = model.sellcount;
			parameters[32].Value = model.sellprice;
			parameters[33].Value = model.specification;
			parameters[34].Value = model.stockPrice;
			parameters[35].Value = model.tradePrice;
			parameters[36].Value = model.unit;
			parameters[37].Value = model.visible;
			parameters[38].Value = model.weight;
			parameters[39].Value = model.brand_id;
			parameters[40].Value = model.categoryid;
			parameters[41].Value = model.guaranteePeriod;
			parameters[42].Value = model.addedTime;
			parameters[43].Value = model.blHot;
			parameters[44].Value = model.blSecKill;
			parameters[45].Value = model.createTime;
			parameters[46].Value = model.onLinePrice;
			parameters[47].Value = model.specialEndTime;
			parameters[48].Value = model.specialPrice;
			parameters[49].Value = model.feature;
			parameters[50].Value = model.goodsTag;
			parameters[51].Value = model.keywords;
			parameters[52].Value = model.orign;
			parameters[53].Value = model.packingDeliver;
			parameters[54].Value = model.deliverFee;
			parameters[55].Value = model.pieceDeliverFee;
			parameters[56].Value = model.goodsType;
			parameters[57].Value = model.highestLimitSellPrice;
			parameters[58].Value = model.volume;
			parameters[59].Value = model.salesvalue;

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
        public bool Update(YSWL.Model.ERP.Products.Goods model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update goods set ");
			strSql.Append("active=?active,");
			strSql.Append("approvalCertificate=?approvalCertificate,");
			strSql.Append("bakName=?bakName,");
			strSql.Append("barCode=?barCode,");
			strSql.Append("baseQty=?baseQty,");
			strSql.Append("baseprice=?baseprice,");
			strSql.Append("blCommend=?blCommend,");
			strSql.Append("blGift=?blGift,");
			strSql.Append("blMember=?blMember,");
			strSql.Append("blSpecial=?blSpecial,");
			strSql.Append("buyexplain=?buyexplain,");
			strSql.Append("clickcount=?clickcount,");
			strSql.Append("code=?code,");
			strSql.Append("createdate=?createdate,");
			strSql.Append("description=?description,");
			strSql.Append("discount=?discount,");
			strSql.Append("helpCode=?helpCode,");
			strSql.Append("lastModifyTime=?lastModifyTime,");
			strSql.Append("lowestLimitSellPrice=?lowestLimitSellPrice,");
			strSql.Append("manufacturer=?manufacturer,");
			strSql.Append("marketprice=?marketprice,");
			strSql.Append("memberPrice=?memberPrice,");
			strSql.Append("model=?model,");
			strSql.Append("name=?name,");
			strSql.Append("oldCode=?oldCode,");
			strSql.Append("qtyOfPackage=?qtyOfPackage,");
			strSql.Append("rate=?rate,");
			strSql.Append("rating=?rating,");
			strSql.Append("ratingCount=?ratingCount,");
			strSql.Append("retailPrice=?retailPrice,");
			strSql.Append("sellcount=?sellcount,");
			strSql.Append("sellprice=?sellprice,");
			strSql.Append("specification=?specification,");
			strSql.Append("stockPrice=?stockPrice,");
			strSql.Append("tradePrice=?tradePrice,");
			strSql.Append("unit=?unit,");
			strSql.Append("visible=?visible,");
			strSql.Append("weight=?weight,");
			strSql.Append("brand_id=?brand_id,");
			strSql.Append("categoryid=?categoryid,");
			strSql.Append("guaranteePeriod=?guaranteePeriod,");
			strSql.Append("addedTime=?addedTime,");
			strSql.Append("blHot=?blHot,");
			strSql.Append("blSecKill=?blSecKill,");
			strSql.Append("createTime=?createTime,");
			strSql.Append("onLinePrice=?onLinePrice,");
			strSql.Append("specialEndTime=?specialEndTime,");
			strSql.Append("specialPrice=?specialPrice,");
			strSql.Append("feature=?feature,");
			strSql.Append("goodsTag=?goodsTag,");
			strSql.Append("keywords=?keywords,");
			strSql.Append("orign=?orign,");
			strSql.Append("packingDeliver=?packingDeliver,");
			strSql.Append("deliverFee=?deliverFee,");
			strSql.Append("pieceDeliverFee=?pieceDeliverFee,");
			strSql.Append("goodsType=?goodsType,");
			strSql.Append("highestLimitSellPrice=?highestLimitSellPrice,");
			strSql.Append("volume=?volume,");
			strSql.Append("salesvalue=?salesvalue");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?approvalCertificate", MySqlDbType.VarChar,60),
					new MySqlParameter("?bakName", MySqlDbType.VarChar,80),
					new MySqlParameter("?barCode", MySqlDbType.VarChar,30),
					new MySqlParameter("?baseQty", MySqlDbType.Double),
					new MySqlParameter("?baseprice", MySqlDbType.Double),
					new MySqlParameter("?blCommend", MySqlDbType.Bit),
					new MySqlParameter("?blGift", MySqlDbType.Bit),
					new MySqlParameter("?blMember", MySqlDbType.Bit),
					new MySqlParameter("?blSpecial", MySqlDbType.Bit),
					new MySqlParameter("?buyexplain", MySqlDbType.VarChar,2000),
					new MySqlParameter("?clickcount", MySqlDbType.Int32,11),
					new MySqlParameter("?code", MySqlDbType.VarChar,80),
					new MySqlParameter("?createdate", MySqlDbType.DateTime),
					new MySqlParameter("?description", MySqlDbType.VarChar,2000),
					new MySqlParameter("?discount", MySqlDbType.Int32,11),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?lastModifyTime", MySqlDbType.DateTime),
					new MySqlParameter("?lowestLimitSellPrice", MySqlDbType.Double),
					new MySqlParameter("?manufacturer", MySqlDbType.VarChar,80),
					new MySqlParameter("?marketprice", MySqlDbType.Double),
					new MySqlParameter("?memberPrice", MySqlDbType.Double),
					new MySqlParameter("?model", MySqlDbType.VarChar,20),
					new MySqlParameter("?name", MySqlDbType.VarChar,80),
					new MySqlParameter("?oldCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?qtyOfPackage", MySqlDbType.Int32,11),
					new MySqlParameter("?rate", MySqlDbType.Double),
					new MySqlParameter("?rating", MySqlDbType.Int32,11),
					new MySqlParameter("?ratingCount", MySqlDbType.Int32,11),
					new MySqlParameter("?retailPrice", MySqlDbType.Double),
					new MySqlParameter("?sellcount", MySqlDbType.Double),
					new MySqlParameter("?sellprice", MySqlDbType.Double),
					new MySqlParameter("?specification", MySqlDbType.VarChar,60),
					new MySqlParameter("?stockPrice", MySqlDbType.Double),
					new MySqlParameter("?tradePrice", MySqlDbType.Double),
					new MySqlParameter("?unit", MySqlDbType.VarChar,10),
					new MySqlParameter("?visible", MySqlDbType.Bit),
					new MySqlParameter("?weight", MySqlDbType.Int32,11),
					new MySqlParameter("?brand_id", MySqlDbType.Int64,20),
					new MySqlParameter("?categoryid", MySqlDbType.Int64,20),
					new MySqlParameter("?guaranteePeriod", MySqlDbType.Int32,11),
					new MySqlParameter("?addedTime", MySqlDbType.DateTime),
					new MySqlParameter("?blHot", MySqlDbType.Bit),
					new MySqlParameter("?blSecKill", MySqlDbType.Bit),
					new MySqlParameter("?createTime", MySqlDbType.DateTime),
					new MySqlParameter("?onLinePrice", MySqlDbType.Double),
					new MySqlParameter("?specialEndTime", MySqlDbType.DateTime),
					new MySqlParameter("?specialPrice", MySqlDbType.Double),
					new MySqlParameter("?feature", MySqlDbType.LongText),
					new MySqlParameter("?goodsTag", MySqlDbType.VarChar,150),
					new MySqlParameter("?keywords", MySqlDbType.VarChar,100),
					new MySqlParameter("?orign", MySqlDbType.VarChar,100),
					new MySqlParameter("?packingDeliver", MySqlDbType.VarChar,1000),
					new MySqlParameter("?deliverFee", MySqlDbType.Double),
					new MySqlParameter("?pieceDeliverFee", MySqlDbType.Double),
					new MySqlParameter("?goodsType", MySqlDbType.Int32,11),
					new MySqlParameter("?highestLimitSellPrice", MySqlDbType.Double),
					new MySqlParameter("?volume", MySqlDbType.Double),
					new MySqlParameter("?salesvalue", MySqlDbType.Int32,15),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.active;
			parameters[1].Value = model.approvalCertificate;
			parameters[2].Value = model.bakName;
			parameters[3].Value = model.barCode;
			parameters[4].Value = model.baseQty;
			parameters[5].Value = model.baseprice;
			parameters[6].Value = model.blCommend;
			parameters[7].Value = model.blGift;
			parameters[8].Value = model.blMember;
			parameters[9].Value = model.blSpecial;
			parameters[10].Value = model.buyexplain;
			parameters[11].Value = model.clickcount;
			parameters[12].Value = model.code;
			parameters[13].Value = model.createdate;
			parameters[14].Value = model.description;
			parameters[15].Value = model.discount;
			parameters[16].Value = model.helpCode;
			parameters[17].Value = model.lastModifyTime;
			parameters[18].Value = model.lowestLimitSellPrice;
			parameters[19].Value = model.manufacturer;
			parameters[20].Value = model.marketprice;
			parameters[21].Value = model.memberPrice;
			parameters[22].Value = model.model;
			parameters[23].Value = model.name;
			parameters[24].Value = model.oldCode;
			parameters[25].Value = model.qtyOfPackage;
			parameters[26].Value = model.rate;
			parameters[27].Value = model.rating;
			parameters[28].Value = model.ratingCount;
			parameters[29].Value = model.retailPrice;
			parameters[30].Value = model.sellcount;
			parameters[31].Value = model.sellprice;
			parameters[32].Value = model.specification;
			parameters[33].Value = model.stockPrice;
			parameters[34].Value = model.tradePrice;
			parameters[35].Value = model.unit;
			parameters[36].Value = model.visible;
			parameters[37].Value = model.weight;
			parameters[38].Value = model.brand_id;
			parameters[39].Value = model.categoryid;
			parameters[40].Value = model.guaranteePeriod;
			parameters[41].Value = model.addedTime;
			parameters[42].Value = model.blHot;
			parameters[43].Value = model.blSecKill;
			parameters[44].Value = model.createTime;
			parameters[45].Value = model.onLinePrice;
			parameters[46].Value = model.specialEndTime;
			parameters[47].Value = model.specialPrice;
			parameters[48].Value = model.feature;
			parameters[49].Value = model.goodsTag;
			parameters[50].Value = model.keywords;
			parameters[51].Value = model.orign;
			parameters[52].Value = model.packingDeliver;
			parameters[53].Value = model.deliverFee;
			parameters[54].Value = model.pieceDeliverFee;
			parameters[55].Value = model.goodsType;
			parameters[56].Value = model.highestLimitSellPrice;
			parameters[57].Value = model.volume;
			parameters[58].Value = model.salesvalue;
			parameters[59].Value = model.id;

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
			strSql.Append("delete from goods ");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,20)			};
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
			strSql.Append("delete from goods ");
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
        public YSWL.Model.ERP.Products.Goods GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,active,approvalCertificate,bakName,barCode,baseQty,baseprice,blCommend,blGift,blMember,blSpecial,buyexplain,clickcount,code,createdate,description,discount,helpCode,lastModifyTime,lowestLimitSellPrice,manufacturer,marketprice,memberPrice,model,name,oldCode,qtyOfPackage,rate,rating,ratingCount,retailPrice,sellcount,sellprice,specification,stockPrice,tradePrice,unit,visible,weight,brand_id,categoryid,guaranteePeriod,addedTime,blHot,blSecKill,createTime,onLinePrice,specialEndTime,specialPrice,feature,goodsTag,keywords,orign,packingDeliver,deliverFee,pieceDeliverFee,goodsType,highestLimitSellPrice,volume,salesvalue from goods ");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64,20)			};
			parameters[0].Value = id;

            YSWL.Model.ERP.Products.Goods model = new YSWL.Model.ERP.Products.Goods();
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
        public YSWL.Model.ERP.Products.Goods DataRowToModel(DataRow row)
		{
            YSWL.Model.ERP.Products.Goods model = new YSWL.Model.ERP.Products.Goods();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
				if(row["active"]!=null && row["active"].ToString()!="")
				{
					if((row["active"].ToString()=="1")||(row["active"].ToString().ToLower()=="true"))
					{
						model.active=true;
					}
					else
					{
						model.active=false;
					}
				}
				if(row["approvalCertificate"]!=null)
				{
					model.approvalCertificate=row["approvalCertificate"].ToString();
				}
				if(row["bakName"]!=null)
				{
					model.bakName=row["bakName"].ToString();
				}
				if(row["barCode"]!=null)
				{
					model.barCode=row["barCode"].ToString();
				}
					//model.baseQty=row["baseQty"].ToString();
					//model.baseprice=row["baseprice"].ToString();
				if(row["blCommend"]!=null && row["blCommend"].ToString()!="")
				{
					if((row["blCommend"].ToString()=="1")||(row["blCommend"].ToString().ToLower()=="true"))
					{
						model.blCommend=true;
					}
					else
					{
						model.blCommend=false;
					}
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
				if(row["blMember"]!=null && row["blMember"].ToString()!="")
				{
					if((row["blMember"].ToString()=="1")||(row["blMember"].ToString().ToLower()=="true"))
					{
						model.blMember=true;
					}
					else
					{
						model.blMember=false;
					}
				}
				if(row["blSpecial"]!=null && row["blSpecial"].ToString()!="")
				{
					if((row["blSpecial"].ToString()=="1")||(row["blSpecial"].ToString().ToLower()=="true"))
					{
						model.blSpecial=true;
					}
					else
					{
						model.blSpecial=false;
					}
				}
				if(row["buyexplain"]!=null)
				{
					model.buyexplain=row["buyexplain"].ToString();
				}
				if(row["clickcount"]!=null && row["clickcount"].ToString()!="")
				{
					model.clickcount=int.Parse(row["clickcount"].ToString());
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["createdate"]!=null && row["createdate"].ToString()!="")
				{
					model.createdate=DateTime.Parse(row["createdate"].ToString());
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
				}
				if(row["discount"]!=null && row["discount"].ToString()!="")
				{
					model.discount=int.Parse(row["discount"].ToString());
				}
				if(row["helpCode"]!=null)
				{
					model.helpCode=row["helpCode"].ToString();
				}
				if(row["lastModifyTime"]!=null && row["lastModifyTime"].ToString()!="")
				{
					model.lastModifyTime=DateTime.Parse(row["lastModifyTime"].ToString());
				}
					//model.lowestLimitSellPrice=row["lowestLimitSellPrice"].ToString();
				if(row["manufacturer"]!=null)
				{
					model.manufacturer=row["manufacturer"].ToString();
				}
					//model.marketprice=row["marketprice"].ToString();
					//model.memberPrice=row["memberPrice"].ToString();
				if(row["model"]!=null)
				{
					model.model=row["model"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["oldCode"]!=null)
				{
					model.oldCode=row["oldCode"].ToString();
				}
				if(row["qtyOfPackage"]!=null && row["qtyOfPackage"].ToString()!="")
				{
					model.qtyOfPackage=int.Parse(row["qtyOfPackage"].ToString());
				}
					//model.rate=row["rate"].ToString();
				if(row["rating"]!=null && row["rating"].ToString()!="")
				{
					model.rating=int.Parse(row["rating"].ToString());
				}
				if(row["ratingCount"]!=null && row["ratingCount"].ToString()!="")
				{
					model.ratingCount=int.Parse(row["ratingCount"].ToString());
				}
					//model.retailPrice=row["retailPrice"].ToString();
					//model.sellcount=row["sellcount"].ToString();
					//model.sellprice=row["sellprice"].ToString();
				if(row["specification"]!=null)
				{
					model.specification=row["specification"].ToString();
				}
					//model.stockPrice=row["stockPrice"].ToString();
					//model.tradePrice=row["tradePrice"].ToString();
				if(row["unit"]!=null)
				{
					model.unit=row["unit"].ToString();
				}
				if(row["visible"]!=null && row["visible"].ToString()!="")
				{
					if((row["visible"].ToString()=="1")||(row["visible"].ToString().ToLower()=="true"))
					{
						model.visible=true;
					}
					else
					{
						model.visible=false;
					}
				}
				if(row["weight"]!=null && row["weight"].ToString()!="")
				{
					model.weight=int.Parse(row["weight"].ToString());
				}
				if(row["brand_id"]!=null && row["brand_id"].ToString()!="")
				{
					model.brand_id=long.Parse(row["brand_id"].ToString());
				}
				if(row["categoryid"]!=null && row["categoryid"].ToString()!="")
				{
					model.categoryid=long.Parse(row["categoryid"].ToString());
				}
				if(row["guaranteePeriod"]!=null && row["guaranteePeriod"].ToString()!="")
				{
					model.guaranteePeriod=int.Parse(row["guaranteePeriod"].ToString());
				}
				if(row["addedTime"]!=null && row["addedTime"].ToString()!="")
				{
					model.addedTime=DateTime.Parse(row["addedTime"].ToString());
				}
				if(row["blHot"]!=null && row["blHot"].ToString()!="")
				{
					if((row["blHot"].ToString()=="1")||(row["blHot"].ToString().ToLower()=="true"))
					{
						model.blHot=true;
					}
					else
					{
						model.blHot=false;
					}
				}
				if(row["blSecKill"]!=null && row["blSecKill"].ToString()!="")
				{
					if((row["blSecKill"].ToString()=="1")||(row["blSecKill"].ToString().ToLower()=="true"))
					{
						model.blSecKill=true;
					}
					else
					{
						model.blSecKill=false;
					}
				}
				if(row["createTime"]!=null && row["createTime"].ToString()!="")
				{
					model.createTime=DateTime.Parse(row["createTime"].ToString());
				}
					//model.onLinePrice=row["onLinePrice"].ToString();
				if(row["specialEndTime"]!=null && row["specialEndTime"].ToString()!="")
				{
					model.specialEndTime=DateTime.Parse(row["specialEndTime"].ToString());
				}
					//model.specialPrice=row["specialPrice"].ToString();
				if(row["feature"]!=null)
				{
					model.feature=row["feature"].ToString();
				}
				if(row["goodsTag"]!=null)
				{
					model.goodsTag=row["goodsTag"].ToString();
				}
				if(row["keywords"]!=null)
				{
					model.keywords=row["keywords"].ToString();
				}
				if(row["orign"]!=null)
				{
					model.orign=row["orign"].ToString();
				}
				if(row["packingDeliver"]!=null)
				{
					model.packingDeliver=row["packingDeliver"].ToString();
				}
					//model.deliverFee=row["deliverFee"].ToString();
					//model.pieceDeliverFee=row["pieceDeliverFee"].ToString();
				if(row["goodsType"]!=null && row["goodsType"].ToString()!="")
				{
					model.goodsType=int.Parse(row["goodsType"].ToString());
				}
					//model.highestLimitSellPrice=row["highestLimitSellPrice"].ToString();
					//model.volume=row["volume"].ToString();
				if(row["salesvalue"]!=null && row["salesvalue"].ToString()!="")
				{
					model.salesvalue=int.Parse(row["salesvalue"].ToString());
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
			strSql.Append("select id,active,approvalCertificate,bakName,barCode,baseQty,baseprice,blCommend,blGift,blMember,blSpecial,buyexplain,clickcount,code,createdate,description,discount,helpCode,lastModifyTime,lowestLimitSellPrice,manufacturer,marketprice,memberPrice,model,name,oldCode,qtyOfPackage,rate,rating,ratingCount,retailPrice,sellcount,sellprice,specification,stockPrice,tradePrice,unit,visible,weight,brand_id,categoryid,guaranteePeriod,addedTime,blHot,blSecKill,createTime,onLinePrice,specialEndTime,specialPrice,feature,goodsTag,keywords,orign,packingDeliver,deliverFee,pieceDeliverFee,goodsType,highestLimitSellPrice,volume,salesvalue ");
			strSql.Append(" FROM goods ");
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
			strSql.Append("select count(1) FROM goods ");
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
			strSql.Append(")AS Row, T.*  from goods T ");
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
			parameters[0].Value = "goods";
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

