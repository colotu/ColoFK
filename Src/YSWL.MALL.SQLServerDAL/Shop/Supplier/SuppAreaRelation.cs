/**  版本信息模板在安装目录下，可自行修改。
* SuppAreaRelation.cs
*
* 功 能： N/A
* 类 名： SuppAreaRelation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/1 11:13:51   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Shop.Supplier;

namespace YSWL.MALL.SQLServerDAL.Shop.Supplier
{
	/// <summary>
	/// 数据访问类:SuppAreaRelation
	/// </summary>
	public partial class SuppAreaRelation:ISuppAreaRelation
	{
		public SuppAreaRelation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelper.DefaultDBHelper.GetMaxID("AreaId", "Shop_SuppAreaRelation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AreaId,int SupplierId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_SuppAreaRelation");
			strSql.Append(" where AreaId=@AreaId and SupplierId=@SupplierId ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4),
					new SqlParameter("@SupplierId", SqlDbType.Int,4)			};
			parameters[0].Value = AreaId;
			parameters[1].Value = SupplierId;

			return DBHelper.DefaultDBHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_SuppAreaRelation(");
			strSql.Append("AreaId,SupplierId,AreaPath)");
			strSql.Append(" values (");
			strSql.Append("@AreaId,@SupplierId,@AreaPath)");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4),
					new SqlParameter("@SupplierId", SqlDbType.Int,4),
					new SqlParameter("@AreaPath", SqlDbType.NVarChar,4000)};
			parameters[0].Value = model.AreaId;
			parameters[1].Value = model.SupplierId;
			parameters[2].Value = model.AreaPath;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_SuppAreaRelation set ");
			strSql.Append("AreaPath=@AreaPath");
			strSql.Append(" where AreaId=@AreaId and SupplierId=@SupplierId ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaPath", SqlDbType.NVarChar,4000),
					new SqlParameter("@AreaId", SqlDbType.Int,4),
					new SqlParameter("@SupplierId", SqlDbType.Int,4)};
			parameters[0].Value = model.AreaPath;
			parameters[1].Value = model.AreaId;
			parameters[2].Value = model.SupplierId;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int AreaId,int SupplierId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SuppAreaRelation ");
			strSql.Append(" where AreaId=@AreaId and SupplierId=@SupplierId ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4),
					new SqlParameter("@SupplierId", SqlDbType.Int,4)			};
			parameters[0].Value = AreaId;
			parameters[1].Value = SupplierId;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation GetModel(int AreaId,int SupplierId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AreaId,SupplierId,AreaPath from Shop_SuppAreaRelation ");
			strSql.Append(" where AreaId=@AreaId and SupplierId=@SupplierId ");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4),
					new SqlParameter("@SupplierId", SqlDbType.Int,4)			};
			parameters[0].Value = AreaId;
			parameters[1].Value = SupplierId;

			YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation model=new YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation();
			DataSet ds=DBHelper.DefaultDBHelper.Query(strSql.ToString(),parameters);
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
		public YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation model=new YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation();
			if (row != null)
			{
				if(row["AreaId"]!=null && row["AreaId"].ToString()!="")
				{
					model.AreaId=int.Parse(row["AreaId"].ToString());
				}
				if(row["SupplierId"]!=null && row["SupplierId"].ToString()!="")
				{
					model.SupplierId=int.Parse(row["SupplierId"].ToString());
				}
				if(row["AreaPath"]!=null)
				{
					model.AreaPath=row["AreaPath"].ToString();
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
			strSql.Append("select AreaId,SupplierId,AreaPath ");
			strSql.Append(" FROM Shop_SuppAreaRelation ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" AreaId,SupplierId,AreaPath ");
			strSql.Append(" FROM Shop_SuppAreaRelation ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Shop_SuppAreaRelation ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.SupplierId desc");
			}
			strSql.Append(")AS Row, T.*  from Shop_SuppAreaRelation T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Shop_SuppAreaRelation";
			parameters[1].Value = "SupplierId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.DefaultDBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Shop.Supplier.SuppAreaRelation GetModelBySupplerId(int SupplierId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 AreaId,SupplierId,AreaPath from Shop_SuppAreaRelation ");
            strSql.Append(" where SupplierId=@SupplierId ");
            SqlParameter[] parameters = { new SqlParameter("@SupplierId", SqlDbType.Int,4)};
            parameters[0].Value = SupplierId;
            DataSet ds = DBHelper.DefaultDBHelper.Query(strSql.ToString(), parameters);
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

