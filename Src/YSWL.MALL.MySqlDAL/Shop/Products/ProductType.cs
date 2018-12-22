/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductTypes.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:30
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.DBUtility;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using YSWL.MALL.Model.Shop.Products;

namespace YSWL.MALL.MySqlDAL.Shop.Products
{
	/// <summary>
	/// 数据访问类:ProductType
	/// </summary>
	public partial class ProductType:IProductType
	{
		public ProductType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("TypeId", "Shop_ProductTypes"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TypeId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT COUNT(1) FROM Shop_ProductTypes");
			strSql.Append(" WHERE TypeId=?TypeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TypeId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Products.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("INSERT INTO Shop_ProductTypes(");
			strSql.Append("TypeName,Remark)");
			strSql.Append(" VALUES (");
			strSql.Append("?TypeName,?Remark)");
			strSql.Append(";SELECT last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.TypeName;
			parameters[1].Value = model.Remark;

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
		public bool Update(YSWL.MALL.Model.Shop.Products.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("UPDATE Shop_ProductTypes SET ");
			strSql.Append("TypeName=?TypeName,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" WHERE TypeId=?TypeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TypeName;
			parameters[1].Value = model.Remark;
			parameters[2].Value = model.TypeId;

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
		public bool Delete(int TypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_ProductTypes ");
			strSql.Append(" WHERE TypeId=?TypeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TypeId;

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
		public bool DeleteList(string TypeIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("DELETE FROM Shop_ProductTypes ");
			strSql.Append(" WHERE TypeId in ("+TypeIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Products.ProductType GetModel(int TypeId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT TypeId,TypeName,Remark FROM Shop_ProductTypes ");
			strSql.Append(" WHERE TypeId=?TypeId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TypeId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Products.ProductType model=new YSWL.MALL.Model.Shop.Products.ProductType();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TypeId"]!=null && ds.Tables[0].Rows[0]["TypeId"].ToString()!="")
				{
					model.TypeId=int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TypeName"]!=null && ds.Tables[0].Rows[0]["TypeName"].ToString()!="")
				{
					model.TypeName=ds.Tables[0].Rows[0]["TypeName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT TypeId,TypeName,Remark ");
			strSql.Append(" FROM Shop_ProductTypes ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ");
			
			strSql.Append(" TypeId,TypeName,Remark ");
			strSql.Append(" FROM Shop_ProductTypes ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
			}
			strSql.Append(" ORDER BY " + filedOrder);
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
			strSql.Append("SELECT COUNT(1) FROM Shop_ProductTypes ");
			if(!string.IsNullOrWhiteSpace(strWhere.Trim()))
			{
				strSql.Append(" WHERE "+strWhere);
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
            strSql.Append("SELECT T.* from Shop_ProductTypes T ");
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
                strSql.Append(" order by T.TypeId desc");
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
			parameters[0].Value = "Shop_ProductTypes";
			parameters[1].Value = "TypeId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        #region NewMethod
        public List<YSWL.MALL.Model.Shop.Products.ProductType> GetProductTypes()
        {
            List<YSWL.MALL.Model.Shop.Products.ProductType> list = new List<YSWL.MALL.Model.Shop.Products.ProductType>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Shop_ProductTypes");
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    YSWL.MALL.Model.Shop.Products.ProductType model = new YSWL.MALL.Model.Shop.Products.ProductType();
                    LoadEntityData(ref model, dr);
                    list.Add(model);
                }
            }
            return list;
        }

        #region 将行数据 转成 实体对象
        /// <summary>
        /// 将行数据 转成 实体对象
        /// </summary>
        /// <param name="model">Entity</param>
        /// <param name="dr">DataRow</param>
        private void LoadEntityData(ref YSWL.MALL.Model.Shop.Products.ProductType model, DataRow dr)
        {
            if (dr["TypeId"] != null && dr["TypeId"].ToString() != "")
            {
                model.TypeId = int.Parse(dr["TypeId"].ToString());
            }
            if (dr["TypeName"] != null && dr["TypeName"].ToString() != "")
            {
                model.TypeName = dr["TypeName"].ToString();
            }
            if (dr["Remark"] != null && dr["Remark"].ToString() != "")
            {
                model.Remark = dr["Remark"].ToString();
            }
        }
        #endregion 

        public bool ProductTypeManage(Model.Shop.Products.ProductType model,Model.Shop.Products.DataProviderAction Action,out int Typeid)
        {
            int rows = 0;
            MySqlParameter[] param ={
                                 new MySqlParameter("_TypeId",MySqlDbType.Int32),
                                 new MySqlParameter("_TypeName",MySqlDbType.VarChar),
                                 new MySqlParameter("_Remark",MySqlDbType.VarChar),
                                 new MySqlParameter("_Action",MySqlDbType.Int32),
                                 new MySqlParameter("_TypeIdOut",MySqlDbType.Int32)
                                 };
            param[0].Value = model.TypeId;
            param[1].Value = model.TypeName;
            param[2].Value = model.Remark;
            param[3].Value = (int)Action;
            param[4].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("sp_Show_Shop_ProductTypesCreateUpdateDelete", param, out rows);
            int typeId = 0;
            if (Action == Model.Shop.Products.DataProviderAction.Create)
            {
                typeId = Convert.ToInt32(param[4].Value);
            }
            else
            {
                typeId = model.TypeId;
            }
            if (rows > 0 && typeId > 0)
            {
                ProductTypeBrand productTypeBrands = new ProductTypeBrand();
                if (Action == Model.Shop.Products.DataProviderAction.Update)
                {
                //TODO: 级联删除/更新 没考虑
                    productTypeBrands.Delete(typeId, null);
                }
                foreach (int bid in model.BrandsTypes)
                {
                    productTypeBrands.Add(typeId, bid);
                }
                Typeid = typeId;
                return true;
            }
            else
            {
                Typeid = 0;
                return false;
            }
        }


        public bool DeleteManage(int? TypeId,long? AttributeId,long? ValueId)
        {
            int rowsAffected=0;
            MySqlParameter[] parameter = { 
                                       new MySqlParameter("_TypeId",MySqlDbType.Int32),
                                       new MySqlParameter("_AttributeId",MySqlDbType.Int64),
                                       new MySqlParameter("_ValueId",MySqlDbType.Int64)
                                       };
            parameter[0].Value = TypeId;
            parameter[1].Value = AttributeId;
            parameter[2].Value = ValueId;

            DbHelperMySQL.RunProcedure("sp_Shop_DeleteManage", parameter, out rowsAffected);
            return rowsAffected > 0;
        }

        public bool SwapSeqManage(int? TypeId, long? AttributeId, long? ValueId, Model.Shop.Products.SwapSequenceIndex zIndex, bool UsageMode)
        {
            int rowsAffected = 0;
            MySqlParameter[] parameter = { 
                                       new MySqlParameter("_TypeId",MySqlDbType.Int32),
                                       new MySqlParameter("_AttributeId",MySqlDbType.Int64),
                                       new MySqlParameter("_ValueId",MySqlDbType.Int64),
                                       new MySqlParameter("_ZIndex",MySqlDbType.Int32),
                                       new MySqlParameter("_UsageMode",MySqlDbType.Bit)
                                       };
            parameter[0].Value = TypeId;
            parameter[1].Value = AttributeId;
            parameter[2].Value = ValueId;
            parameter[3].Value = (int)zIndex;
            parameter[4].Value = UsageMode;

            DbHelperMySQL.RunProcedure("sp_Shop_SwapManage", parameter, out rowsAffected);
            return rowsAffected > 0;
        }

        public bool ResetTable()
        {
            throw new NotImplementedException();
        }

        public bool ProductTypeManage(Model.Shop.Products.ProductType model)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

