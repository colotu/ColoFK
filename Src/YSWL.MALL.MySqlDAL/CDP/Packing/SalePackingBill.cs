/**  
* salepackingbill.cs
*
* 功 能： N/A
* 类 名： salepackingbill
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/14 14:54:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.IDAL.ERP.SalePackingBill;
using MySql.Data.MySqlClient;
using YSWL.IDAL;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.SalePackingBill
{
	/// <summary>
	/// 数据访问类:salepackingbill
	/// </summary>
    public partial class SalePackingBill : ISalePackingBill
	{
        public SalePackingBill()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from salepackingbill");
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
		public bool Add(YSWL.Model.ERP.SalePackingBill.SalePackingBill  model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into salepackingbill(");
			strSql.Append("auditDate,billCode,billMoney,deliver,flowFlag,governor,oldBillCode,operator,packingDate,remarks,vehCode,kokura_id,auditTime,packingTime,deliverPerCount,outInMoneyTotal,receiveMoneyTotal,returnMoneyTotal,saleMoneyTotal,volumeTotal,weightTotal)");
			strSql.Append(" values (");
			strSql.Append("?auditDate,?billCode,?billMoney,?deliver,?flowFlag,?governor,?oldBillCode,?operator,?packingDate,?remarks,?vehCode,?kokura_id,?auditTime,?packingTime,?deliverPerCount,?outInMoneyTotal,?receiveMoneyTotal,?returnMoneyTotal,?saleMoneyTotal,?volumeTotal,?weightTotal)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?auditDate", MySqlDbType.Date),
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?billMoney", MySqlDbType.Double),
					new MySqlParameter("?deliver", MySqlDbType.VarChar,100),
					new MySqlParameter("?flowFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?governor", MySqlDbType.VarChar,30),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?operator", MySqlDbType.VarChar,30),
					new MySqlParameter("?packingDate", MySqlDbType.Date),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					new MySqlParameter("?vehCode", MySqlDbType.VarChar,60),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?auditTime", MySqlDbType.Time),
					new MySqlParameter("?packingTime", MySqlDbType.Time),
					new MySqlParameter("?deliverPerCount", MySqlDbType.Int32,11),
					new MySqlParameter("?outInMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?receiveMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?returnMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?saleMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?volumeTotal", MySqlDbType.Double),
					new MySqlParameter("?weightTotal", MySqlDbType.Int32,11)};
			parameters[0].Value = model.auditDate;
			parameters[1].Value = model.billCode;
			parameters[2].Value = model.billMoney;
			parameters[3].Value = model.deliver;
			parameters[4].Value = model.flowFlag;
			parameters[5].Value = model.governor;
			parameters[6].Value = model.oldBillCode;
			parameters[7].Value = model.operators;
			parameters[8].Value = model.packingDate;
			parameters[9].Value = model.remarks;
			parameters[10].Value = model.vehCode;
			parameters[11].Value = model.kokura_id;
			parameters[12].Value = model.auditTime;
			parameters[13].Value = model.packingTime;
			parameters[14].Value = model.deliverPerCount;
			parameters[15].Value = model.outInMoneyTotal;
			parameters[16].Value = model.receiveMoneyTotal;
			parameters[17].Value = model.returnMoneyTotal;
			parameters[18].Value = model.saleMoneyTotal;
			parameters[19].Value = model.volumeTotal;
			parameters[20].Value = model.weightTotal;

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
        public bool Update(YSWL.Model.ERP.SalePackingBill.SalePackingBill model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update salepackingbill set ");
			strSql.Append("auditDate=?auditDate,");
			strSql.Append("billCode=?billCode,");
			strSql.Append("billMoney=?billMoney,");
			strSql.Append("deliver=?deliver,");
			strSql.Append("flowFlag=?flowFlag,");
			strSql.Append("governor=?governor,");
			strSql.Append("oldBillCode=?oldBillCode,");
			strSql.Append("operator=?operator,");
			strSql.Append("packingDate=?packingDate,");
			strSql.Append("remarks=?remarks,");
			strSql.Append("vehCode=?vehCode,");
			strSql.Append("kokura_id=?kokura_id,");
			strSql.Append("auditTime=?auditTime,");
			strSql.Append("packingTime=?packingTime,");
			strSql.Append("deliverPerCount=?deliverPerCount,");
			strSql.Append("outInMoneyTotal=?outInMoneyTotal,");
			strSql.Append("receiveMoneyTotal=?receiveMoneyTotal,");
			strSql.Append("returnMoneyTotal=?returnMoneyTotal,");
			strSql.Append("saleMoneyTotal=?saleMoneyTotal,");
			strSql.Append("volumeTotal=?volumeTotal,");
			strSql.Append("weightTotal=?weightTotal");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?auditDate", MySqlDbType.Date),
					new MySqlParameter("?billCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?billMoney", MySqlDbType.Double),
					new MySqlParameter("?deliver", MySqlDbType.VarChar,100),
					new MySqlParameter("?flowFlag", MySqlDbType.Int32,11),
					new MySqlParameter("?governor", MySqlDbType.VarChar,30),
					new MySqlParameter("?oldBillCode", MySqlDbType.VarChar,255),
					new MySqlParameter("?operator", MySqlDbType.VarChar,30),
					new MySqlParameter("?packingDate", MySqlDbType.Date),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					new MySqlParameter("?vehCode", MySqlDbType.VarChar,60),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?auditTime", MySqlDbType.Time),
					new MySqlParameter("?packingTime", MySqlDbType.Time),
					new MySqlParameter("?deliverPerCount", MySqlDbType.Int32,11),
					new MySqlParameter("?outInMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?receiveMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?returnMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?saleMoneyTotal", MySqlDbType.Double),
					new MySqlParameter("?volumeTotal", MySqlDbType.Double),
					new MySqlParameter("?weightTotal", MySqlDbType.Int32,11),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.auditDate;
			parameters[1].Value = model.billCode;
			parameters[2].Value = model.billMoney;
			parameters[3].Value = model.deliver;
			parameters[4].Value = model.flowFlag;
			parameters[5].Value = model.governor;
			parameters[6].Value = model.oldBillCode;
			parameters[7].Value = model.operators;
			parameters[8].Value = model.packingDate;
			parameters[9].Value = model.remarks;
			parameters[10].Value = model.vehCode;
			parameters[11].Value = model.kokura_id;
			parameters[12].Value = model.auditTime;
			parameters[13].Value = model.packingTime;
			parameters[14].Value = model.deliverPerCount;
			parameters[15].Value = model.outInMoneyTotal;
			parameters[16].Value = model.receiveMoneyTotal;
			parameters[17].Value = model.returnMoneyTotal;
			parameters[18].Value = model.saleMoneyTotal;
			parameters[19].Value = model.volumeTotal;
			parameters[20].Value = model.weightTotal;
			parameters[21].Value = model.id;

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
		/// 得到一个对象实体
		/// </summary>
        public YSWL.Model.ERP.SalePackingBill.SalePackingBill GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,auditDate,billCode,billMoney,deliver,flowFlag,governor,oldBillCode,operator,packingDate,remarks,vehCode,kokura_id,auditTime,packingTime,deliverPerCount,outInMoneyTotal,receiveMoneyTotal,returnMoneyTotal,saleMoneyTotal,volumeTotal,weightTotal from salepackingbill ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

            YSWL.Model.ERP.SalePackingBill.SalePackingBill model = new YSWL.Model.ERP.SalePackingBill.SalePackingBill();
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
        public YSWL.Model.ERP.SalePackingBill.SalePackingBill DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.SalePackingBill.SalePackingBill model=new YSWL.Model.ERP.SalePackingBill.SalePackingBill();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
				if(row["auditDate"]!=null && row["auditDate"].ToString()!="")
				{
					model.auditDate=DateTime.Parse(row["auditDate"].ToString());
				}
				if(row["billCode"]!=null)
				{
					model.billCode=row["billCode"].ToString();
				}
                if (row["billMoney"] != null && row["billMoney"].ToString() != "")
                {
                    model.billMoney = double.Parse(row["billMoney"].ToString());
                }
				if(row["deliver"]!=null)
				{
					model.deliver=row["deliver"].ToString();
				}
				if(row["flowFlag"]!=null && row["flowFlag"].ToString()!="")
				{
					model.flowFlag=int.Parse(row["flowFlag"].ToString());
				}
				if(row["governor"]!=null)
				{
					model.governor=row["governor"].ToString();
				}
				if(row["oldBillCode"]!=null)
				{
					model.oldBillCode=row["oldBillCode"].ToString();
				}
				if(row["operator"]!=null)
				{
					model.operators=row["operator"].ToString();
				}
				if(row["packingDate"]!=null && row["packingDate"].ToString()!="")
				{
					model.packingDate=DateTime.Parse(row["packingDate"].ToString());
				}
				if(row["remarks"]!=null)
				{
					model.remarks=row["remarks"].ToString();
				}
				if(row["vehCode"]!=null)
				{
					model.vehCode=row["vehCode"].ToString();
				}
				if(row["kokura_id"]!=null && row["kokura_id"].ToString()!="")
				{
					model.kokura_id=long.Parse(row["kokura_id"].ToString());
				}
				if(row["auditTime"]!=null && row["auditTime"].ToString()!="")
				{
					model.auditTime=DateTime.Parse(row["auditTime"].ToString());
				}
				if(row["packingTime"]!=null && row["packingTime"].ToString()!="")
				{
					model.packingTime=DateTime.Parse(row["packingTime"].ToString());
				}
				if(row["deliverPerCount"]!=null && row["deliverPerCount"].ToString()!="")
				{
					model.deliverPerCount=int.Parse(row["deliverPerCount"].ToString());
				}
                if (row["outInMoneyTotal"] != null && row["outInMoneyTotal"].ToString() != "")
                {
                    model.outInMoneyTotal = double.Parse(row["outInMoneyTotal"].ToString());
                }
                if (row["receiveMoneyTotal"] != null && row["receiveMoneyTotal"].ToString() != "")
                {
                    model.receiveMoneyTotal = double.Parse(row["receiveMoneyTotal"].ToString());
                }
                if (row["returnMoneyTotal"] != null && row["returnMoneyTotal"].ToString() != "")
                {
                    model.returnMoneyTotal = double.Parse(row["returnMoneyTotal"].ToString());
                }
                if (row["saleMoneyTotal"] != null && row["saleMoneyTotal"].ToString() != "")
                {
                    model.saleMoneyTotal = double.Parse(row["saleMoneyTotal"].ToString());
                }
                if (row["volumeTotal"] != null && row["volumeTotal"].ToString() != "")
                {
                    model.volumeTotal = double.Parse(row["volumeTotal"].ToString());
                }
				if(row["weightTotal"]!=null && row["weightTotal"].ToString()!="")
				{
					model.weightTotal=int.Parse(row["weightTotal"].ToString());
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
			strSql.Append("select id,auditDate,billCode,billMoney,deliver,flowFlag,governor,oldBillCode,operator,packingDate,remarks,vehCode,kokura_id,auditTime,packingTime,deliverPerCount,outInMoneyTotal,receiveMoneyTotal,returnMoneyTotal,saleMoneyTotal,volumeTotal,weightTotal ");
			strSql.Append(" FROM salepackingbill ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}
 

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM salepackingbill ");
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
        ///  分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="skipsCount">跳过条数</param>
        /// <param name="pageSize">个数</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int skipsCount, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select * from salepackingbill ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.AppendFormat(" where {0} ", strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby);
            }
            strSql.AppendFormat("  limit {0}, {1}  ", skipsCount, pageSize);
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select spb.id,auditDate,billCode,billMoney,deliver,flowFlag,governor,oldBillCode,operator,packingDate,remarks,vehCode,kokura_id,auditTime,packingTime,deliverPerCount,outInMoneyTotal,receiveMoneyTotal,returnMoneyTotal,saleMoneyTotal,volumeTotal,weightTotal,kokura.name kokuraName ");
            strSql.Append(" FROM salepackingbill spb,kokura ");
            strSql.Append(" where spb.kokura_id=kokura.id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            if (orderby.Trim() != "")
            {
                strSql.Append(" ORDER BY " + orderby);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }


      /// <summary>
      /// 删除一条数据 事物(删除单据三张表中的数据、更新订单表中的状态为1)
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public bool Delete(long id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql1 = new StringBuilder();
            strSql1.AppendFormat("update saleorderbill  set flowFlag=1 ,packingDetail_id=null where id in ( select orderBId from  salepackingbilldetail where  bill_id=?bill_id);");
            MySqlParameter[] parameters1 = {
					new MySqlParameter("?bill_id", MySqlDbType.Int64)
			};
            parameters1[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1,EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            StringBuilder strSql2= new StringBuilder();
            strSql2.AppendFormat("  DELETE   from   salepackingbillgoodsdetail    where  bill_id=?bill_id ;");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?bill_id", MySqlDbType.Int64)
			};
            parameters2[0].Value = id;
            sqllist.Add(new CommandInfo(strSql2.ToString(), parameters2,EffentNextType.ExcuteEffectRows));

            StringBuilder strSql3 = new StringBuilder();
            strSql3.AppendFormat(" DELETE  from  salepackingbilldetail  where  bill_id=?bill_id ;");
            MySqlParameter[] parameters3 = {
					new MySqlParameter("?bill_id", MySqlDbType.Int64)
			};
            parameters3[0].Value = id;
            sqllist.Add(new CommandInfo(strSql3.ToString(), parameters3, EffentNextType.ExcuteEffectRows));

            StringBuilder strSql4 = new StringBuilder();
            strSql4.AppendFormat(" DELETE  from salepackingbill where id=?id ;");
            MySqlParameter[] parameters4 = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
            parameters4[0].Value = id;
            sqllist.Add(new CommandInfo(strSql4.ToString(), parameters4, EffentNextType.ExcuteEffectRows));
            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0;
        }
        /// <summary>
        /// 批量删除数据 事物(删除单据三张表中的数据、更新订单表中的状态为1)
        /// </summary>
        public bool DeleteList(string idlist)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql1 = new StringBuilder();
            strSql1.AppendFormat("update saleorderbill  set flowFlag=1 ,packingDetail_id=null where id in ( select orderBId from  salepackingbilldetail where  bill_id in (" + idlist + ") );");
            MySqlParameter[] parameters1 = {				
			}; 
            CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.AppendFormat("  DELETE   from   salepackingbillgoodsdetail    where  bill_id in (" + idlist + ")  ;");
            MySqlParameter[] parameters2 = {
			};
            sqllist.Add(new CommandInfo(strSql2.ToString(), parameters2, EffentNextType.ExcuteEffectRows));

            StringBuilder strSql3 = new StringBuilder();
            strSql3.AppendFormat(" DELETE   from  salepackingbilldetail  where  bill_id in (" + idlist + ") ;");
            MySqlParameter[] parameters3 = {
			};
            sqllist.Add(new CommandInfo(strSql3.ToString(), parameters3, EffentNextType.ExcuteEffectRows));

            StringBuilder strSql4 = new StringBuilder();
            strSql4.AppendFormat(" DELETE  from salepackingbill where id  in (" + idlist + ")  ;");
            MySqlParameter[] parameters4 = {
			};
            sqllist.Add(new CommandInfo(strSql4.ToString(), parameters4, EffentNextType.ExcuteEffectRows));
            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0;
        }


        /// <summary>
        /// 在途审核
        /// </summary>
        /// <param name="id">装箱单Id</param>
        /// <param name="billCode">装箱单编号</param>
        /// <param name="deliver">配送员</param>
        /// <param name="remarks">备注</param>
        /// <returns></returns>
        public bool AuditInTheWay(long id,string billCode, string deliver, string remarks)
        {
            List<string> sqlStrList = new List<string>();
            sqlStrList.Add(string.Format("update salepackingbill set deliver='{0}',remarks='{1}',flowFlag=1,auditDate=CURDATE() where id={2} ", deliver, remarks, id));
            sqlStrList.Add(string.Format("update saleorderbill set deliver='{0}',flowFlag=3 where billCode='{1}'",deliver,billCode));
            return DbHelperMySQL.ExecuteSqlTran(sqlStrList)>0;
        }

		#endregion  ExtensionMethod
	}
}

