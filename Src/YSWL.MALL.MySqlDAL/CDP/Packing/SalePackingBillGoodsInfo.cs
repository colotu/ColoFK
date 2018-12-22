/** 
* SalePackingBillGoodsInfo.cs
*
* 功 能： N/A
* 类 名： SalePackingBillGoodsInfo
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
    /// 数据访问类:SalePackingBillGoodsInfo
    /// </summary>
    public partial class SalePackingBillGoodsInfo : ISalePackingBillGoodsInfo
    {
        public SalePackingBillGoodsInfo()
        { }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="billcode">装箱单编号</param>
        /// <returns></returns>
        public int GetRecordCount(string strWhere, string billcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from salepackingbillgoodsdetail");
            strSql.Append(" where billcode=?billcode");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }

            MySqlParameter[] parameters = {
					new MySqlParameter("?billcode", MySqlDbType.String)
			};
            parameters[0].Value = billcode;

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
        /// 获取金额总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="billcode">装箱单编号</param>
        /// <returns></returns>
        public decimal GetTotalMoney(string strWhere, string billcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(money) from  goods g,store s,salepackingbillgoodsdetail d");
            strSql.Append(" where g.id=d.goods_id and s.id=d.store_id and d.billcode=?billcode");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }

            MySqlParameter[] parameters = {
					new MySqlParameter("?billcode", MySqlDbType.String)
			};
            parameters[0].Value = billcode;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="billcode">装箱单编号</param>
        /// <returns></returns>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, string billcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (select d.*, g.code as goods_Code ,g.name as goods_Name ,g.barcode as goods_Barcode ,s.name as store_Name from goods g,store s,salepackingbillgoodsdetail d where g.id=d.goods_id and s.id=d.store_id and d.billcode=?billcode");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }

            MySqlParameter[] parameters = {
					new MySqlParameter("?billcode", MySqlDbType.String)
			};
            parameters[0].Value = billcode;

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by " + orderby);
            }
            else
            {
                strSql.Append(" order by  g.brand_id,g.specification");
            }
            strSql.AppendFormat(")t limit {0},{1}", startIndex, endIndex-startIndex+1);

            return DbHelperMySQL.Query(strSql.ToString(),parameters);
        }

        /// <summary>
        /// 获取分页金额
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="billcode">装箱单编号</param>
        /// <returns></returns>
        public decimal GetTotalMoneyByPage(string strWhere, string orderby, int startIndex, int endIndex, string billcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(money) from(select * from (select d.*, g.code as goods_Code ,g.name as goods_Name ,g.barcode as goods_Barcode ,s.name as store_Name from goods g,store s,salepackingbillgoodsdetail d where g.id=d.goods_id and s.id=d.store_id and d.billcode=?billcode");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }

            MySqlParameter[] parameters = {
					new MySqlParameter("?billcode", MySqlDbType.String)
			};
            parameters[0].Value = billcode;

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by " + orderby);
            }
            else
            {
                strSql.Append(" order by  g.brand_id,g.specification");
            }
            strSql.AppendFormat(")t limit {0},{1})t2", startIndex, endIndex - startIndex + 1);

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsInfo DataRowToModel(DataRow row)
        {
            YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsInfo model = new YSWL.Model.ERP.SalePackingBill.SalePackingBillGoodsInfo();

            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = long.Parse(row["id"].ToString());
                }
                if (row["billCode"] != null)
                {
                    model.billCode = row["billCode"].ToString();
                }
                if (row["money"] != null && row["money"].ToString() != "")
                {
                    model.money = double.Parse(row["money"].ToString());
                }
                if (row["ordinal"] != null && row["ordinal"].ToString() != "")
                {
                    model.ordinal = int.Parse(row["ordinal"].ToString());
                }
                if (row["pieceQty"] != null && row["pieceQty"].ToString() != "")
                {
                    model.pieceQty = long.Parse(row["pieceQty"].ToString());
                }
                if (row["profit"] != null && row["profit"].ToString() != "")
                {
                    model.profit = double.Parse(row["profit"].ToString());
                }
                if (row["qty"] != null && row["qty"].ToString() != "")
                {
                    model.qty = double.Parse(row["qty"].ToString());
                }
                if (row["qtyOfPackage"] != null && row["qtyOfPackage"].ToString() != "")
                {
                    model.qtyOfPackage = int.Parse(row["qtyOfPackage"].ToString());
                }
                if (row["scatteredQty"] != null && row["scatteredQty"].ToString() != "")
                {
                    model.scatteredQty = long.Parse(row["scatteredQty"].ToString());
                }
                if (row["bill_id"] != null && row["bill_id"].ToString() != "")
                {
                    model.bill_id = long.Parse(row["bill_id"].ToString());
                }
                if (row["goods_id"] != null && row["goods_id"].ToString() != "")
                {
                    model.goods_id = long.Parse(row["goods_id"].ToString());
                }
                if (row["store_id"] != null && row["store_id"].ToString() != "")
                {
                    model.store_id = long.Parse(row["store_id"].ToString());
                }

                if (row["store_Name"] != null)
                {
                    model.store_Name = row["store_Name"].ToString();
                }
                if (row["goods_Name"] != null)
                {
                    model.goods_Name = row["goods_Name"].ToString();
                }
                if (row["goods_Code"] != null)
                {
                    model.goods_Code = row["goods_Code"].ToString();
                }
                if (row["goods_Barcode"] != null)
                {
                    model.goods_Barcode = row["goods_Barcode"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获取数量合计
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="billcode">装箱单编号</param>
        /// <returns></returns>
        public double GetTotalQty(string strWhere, string billcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(qty) from salepackingbillgoodsdetail");
            strSql.Append(" where billcode=?billcode");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }

            MySqlParameter[] parameters = {
					new MySqlParameter("?billcode", MySqlDbType.String)
			};
            parameters[0].Value = billcode;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }
    }
}

