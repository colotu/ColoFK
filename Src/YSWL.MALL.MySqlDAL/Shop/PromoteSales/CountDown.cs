/**
* CountDown.cs
*
* 功 能： N/A
* 类 名： CountDown
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/9/11 18:45:37   N/A    初版
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
using YSWL.MALL.IDAL.Shop.PromoteSales;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.PromoteSales
{
	/// <summary>
	/// 数据访问类:CountDown
	/// </summary>
	public partial class CountDown:ICountDown
	{
		public CountDown()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("CountDownId", "Shop_CountDown"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CountDownId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_CountDown");
			strSql.Append(" where CountDownId=?CountDownId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CountDownId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = CountDownId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.PromoteSales.CountDown model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_CountDown(");
            strSql.Append("ProductId,EndDate,Description,Sequence,Price,Status,LimitQty)");
			strSql.Append(" values (");
            strSql.Append("?ProductId,?EndDate,?Description,?Sequence,?Price,?Status,?LimitQty)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Price", MySqlDbType.Decimal,8),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?LimitQty", MySqlDbType.Int32,4)                    
                                        };
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.EndDate;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.Sequence;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Status;
		    parameters[6].Value = model.LimitQty;
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
		public bool Update(YSWL.MALL.Model.Shop.PromoteSales.CountDown model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_CountDown set ");
			strSql.Append("ProductId=?ProductId,");
			strSql.Append("EndDate=?EndDate,");
			strSql.Append("Description=?Description,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Price=?Price,");
			strSql.Append("Status=?Status,");
            strSql.Append("LimitQty=?LimitQty"); 
			strSql.Append(" where CountDownId=?CountDownId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?EndDate", MySqlDbType.DateTime),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Price", MySqlDbType.Decimal,8),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CountDownId", MySqlDbType.Int32,4),
                    new MySqlParameter("?LimitQty", MySqlDbType.Int32,4)                   
                                        };
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.EndDate;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.Sequence;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CountDownId;
            parameters[7].Value = model.LimitQty;
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
		public bool Delete(int CountDownId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_CountDown ");
			strSql.Append(" where CountDownId=?CountDownId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CountDownId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = CountDownId;

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
		public bool DeleteList(string CountDownIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_CountDown ");
			strSql.Append(" where CountDownId in ("+CountDownIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.PromoteSales.CountDown GetModel(int CountDownId)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select CountDownId,ProductId,EndDate,Description,Sequence,Price,Status,LimitQty  from Shop_CountDown ");
			strSql.Append(" where CountDownId=?CountDownId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CountDownId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = CountDownId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.PromoteSales.CountDown model=new YSWL.MALL.Model.Shop.PromoteSales.CountDown();
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
		public YSWL.MALL.Model.Shop.PromoteSales.CountDown DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.PromoteSales.CountDown model=new YSWL.MALL.Model.Shop.PromoteSales.CountDown();
			if (row != null)
			{
				if(row["CountDownId"]!=null && row["CountDownId"].ToString()!="")
				{
					model.CountDownId=int.Parse(row["CountDownId"].ToString());
				}
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=long.Parse(row["ProductId"].ToString());
				}
				if(row["EndDate"]!=null && row["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(row["EndDate"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
                if (row["LimitQty"] != null && row["LimitQty"].ToString() != "")
				{
                    model.LimitQty = int.Parse(row["LimitQty"].ToString());
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
            strSql.Append("select CountDownId,ProductId,EndDate,Description,Sequence,Price,Status,LimitQty  ");
			strSql.Append(" FROM Shop_CountDown ");
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

            strSql.Append(" CountDownId,ProductId,EndDate,Description,Sequence,Price,Status,LimitQty  ");
			strSql.Append(" FROM Shop_CountDown ");
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
			strSql.Append("select count(1) FROM Shop_CountDown ");
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
            strSql.Append("SELECT T.* from Shop_CountDown T ");
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
                strSql.Append(" order by T.CountDownId desc");
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
			parameters[0].Value = "Shop_CountDown";
			parameters[1].Value = "CountDownId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

	    public int MaxSequence()
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(Sequence) AS Sequence FROM Shop_CountDown");
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

        public bool IsExists(long ProductId)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_CountDown");
            strSql.Append(" where ProductId=?ProductId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int64)
			};
            parameters[0].Value = ProductId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
	    }

        public bool UpdateStatus(string ids, int status)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_CountDown set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where CountDownId in (" + ids + ")  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = status;

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

        public YSWL.MALL.Model.Shop.PromoteSales.CountDown GetActModel(long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CountDownId,ProductId,EndDate,Description,Sequence,Price,Status,LimitQty  from Shop_CountDown ");
            strSql.Append(" where ProductId=?ProductId and  Status=1  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ProductId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.PromoteSales.CountDown model = new YSWL.MALL.Model.Shop.PromoteSales.CountDown();
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

	    #endregion  ExtensionMethod
	}
}

