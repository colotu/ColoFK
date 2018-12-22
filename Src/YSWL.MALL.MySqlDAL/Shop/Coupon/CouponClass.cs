/**
* CouponClass.cs
*
* 功 能： N/A
* 类 名： CouponClass
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/8/26 17:20:56   N/A    初版
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
using YSWL.MALL.IDAL.Shop.Coupon;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Coupon
{
	/// <summary>
	/// 数据访问类:CouponClass
	/// </summary>
	public partial class CouponClass:ICouponClass
	{
		public CouponClass()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ClassId", "Shop_CouponClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ClassId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_CouponClass");
			strSql.Append(" where ClassId=?ClassId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ClassId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Coupon.CouponClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_CouponClass(");
			strSql.Append("Name,Sequence,Status)");
			strSql.Append(" values (");
			strSql.Append("?Name,?Sequence,?Status)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Sequence;
			parameters[2].Value = model.Status;

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
		public bool Update(YSWL.MALL.Model.Shop.Coupon.CouponClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_CouponClass set ");
			strSql.Append("Name=?Name,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Status=?Status");
			strSql.Append(" where ClassId=?ClassId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Sequence;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.ClassId;

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
		public bool Delete(int ClassId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_CouponClass ");
			strSql.Append(" where ClassId=?ClassId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ClassId;

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
		public bool DeleteList(string ClassIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_CouponClass ");
			strSql.Append(" where ClassId in ("+ClassIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Coupon.CouponClass GetModel(int ClassId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ClassId,Name,Sequence,Status from Shop_CouponClass ");
			strSql.Append(" where ClassId=?ClassId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ClassId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Coupon.CouponClass model=new YSWL.MALL.Model.Shop.Coupon.CouponClass();
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
		public YSWL.MALL.Model.Shop.Coupon.CouponClass DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Coupon.CouponClass model=new YSWL.MALL.Model.Shop.Coupon.CouponClass();
			if (row != null)
			{
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
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
			strSql.Append("select ClassId,Name,Sequence,Status ");
			strSql.Append(" FROM Shop_CouponClass ");
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
			
			strSql.Append(" ClassId,Name,Sequence,Status ");
			strSql.Append(" FROM Shop_CouponClass ");
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
			strSql.Append("select count(1) FROM Shop_CouponClass ");
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
            strSql.Append("SELECT T.* from Shop_CouponClass T ");
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
                strSql.Append(" order by T.ClassId desc");
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
			parameters[0].Value = "Shop_CouponClass";
			parameters[1].Value = "ClassId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

	    public int GetSequence()
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT MAX(Sequence) FROM Shop_CouponClass ");
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

        public bool UpdateSeqByCid(int Cid, int seq)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_CouponClass set ");
            strSql.Append("Sequence=?Sequence");
            strSql.Append(" where ClassId=?ClassId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)};
            parameters[0].Value = seq;
            parameters[1].Value = Cid;

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

        public bool UpdateStatus(int Cid, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_CouponClass set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where ClassId=?ClassId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?ClassId", MySqlDbType.Int32,4)};
            parameters[0].Value = status;
            parameters[1].Value = Cid;

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
     
	    #endregion  ExtensionMethod
	}
}

