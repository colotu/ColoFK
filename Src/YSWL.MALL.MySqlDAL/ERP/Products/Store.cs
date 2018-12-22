/**  版本信息模板在安装目录下，可自行修改。
* Store.cs
*
* 功 能： N/A
* 类 名： Store
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/22 16:11:56   N/A    初版
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
using System.Data.SqlClient;
using YSWL.IDAL.ERP.Products;
using YSWL.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace YSWL.MySqlDAL.ERP.Products
{
	/// <summary>
	/// 数据访问类:Store
	/// </summary>
	public partial class Store:IStore
	{
		public Store()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("StoreId", "ERP_Store"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoreId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ERP_Store");
			strSql.Append(" where StoreId=?StoreId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?StoreId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = StoreId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.Model.ERP.Products.Store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ERP_Store(");
			strSql.Append("DepotId,StoreName,Area,IsDeliver,IsRetail,Code,ContactName,Phone,Email,Status,HelpCode,CreatedDate,IsBorrow,IsDefective,Remark)");
			strSql.Append(" values (");
			strSql.Append("?DepotId,?StoreName,?Area,?IsDeliver,?IsRetail,?Code,?ContactName,?Phone,?Email,?Status,?HelpCode,?CreatedDate,?IsBorrow,?IsDefective,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4),
					new MySqlParameter("?StoreName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Area", MySqlDbType.Float,8),
					new MySqlParameter("?IsDeliver", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRetail", MySqlDbType.Bit,1),
					new MySqlParameter("?Code", MySqlDbType.VarChar,60),
					new MySqlParameter("?ContactName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,200),
					new MySqlParameter("?Email", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?HelpCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsBorrow", MySqlDbType.Bit,1),
					new MySqlParameter("?IsDefective", MySqlDbType.Bit,1),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1)};
			parameters[0].Value = model.DepotId;
			parameters[1].Value = model.StoreName;
			parameters[2].Value = model.Area;
			parameters[3].Value = model.IsDeliver;
			parameters[4].Value = model.IsRetail;
			parameters[5].Value = model.Code;
			parameters[6].Value = model.ContactName;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.HelpCode;
			parameters[11].Value = model.CreatedDate;
			parameters[12].Value = model.IsBorrow;
			parameters[13].Value = model.IsDefective;
			parameters[14].Value = model.Remark;

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
		public bool Update(YSWL.Model.ERP.Products.Store model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ERP_Store set ");
			strSql.Append("DepotId=?DepotId,");
			strSql.Append("StoreName=?StoreName,");
			strSql.Append("Area=?Area,");
			strSql.Append("IsDeliver=?IsDeliver,");
			strSql.Append("IsRetail=?IsRetail,");
			strSql.Append("Code=?Code,");
			strSql.Append("ContactName=?ContactName,");
			strSql.Append("Phone=?Phone,");
			strSql.Append("Email=?Email,");
			strSql.Append("Status=?Status,");
			strSql.Append("HelpCode=?HelpCode,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("IsBorrow=?IsBorrow,");
			strSql.Append("IsDefective=?IsDefective,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where StoreId=?StoreId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4),
					new MySqlParameter("?StoreName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Area", MySqlDbType.Float,8),
					new MySqlParameter("?IsDeliver", MySqlDbType.Bit,1),
					new MySqlParameter("?IsRetail", MySqlDbType.Bit,1),
					new MySqlParameter("?Code", MySqlDbType.VarChar,60),
					new MySqlParameter("?ContactName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,200),
					new MySqlParameter("?Email", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?HelpCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsBorrow", MySqlDbType.Bit,1),
					new MySqlParameter("?IsDefective", MySqlDbType.Bit,1),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?StoreId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.DepotId;
			parameters[1].Value = model.StoreName;
			parameters[2].Value = model.Area;
			parameters[3].Value = model.IsDeliver;
			parameters[4].Value = model.IsRetail;
			parameters[5].Value = model.Code;
			parameters[6].Value = model.ContactName;
			parameters[7].Value = model.Phone;
			parameters[8].Value = model.Email;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.HelpCode;
			parameters[11].Value = model.CreatedDate;
			parameters[12].Value = model.IsBorrow;
			parameters[13].Value = model.IsDefective;
			parameters[14].Value = model.Remark;
			parameters[15].Value = model.StoreId;

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
		public bool Delete(int StoreId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Store ");
			strSql.Append(" where StoreId=?StoreId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?StoreId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = StoreId;

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
		public bool DeleteList(string StoreIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Store ");
			strSql.Append(" where StoreId in ("+StoreIdlist + ")  ");
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
		public YSWL.Model.ERP.Products.Store GetModel(int StoreId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select StoreId,DepotId,StoreName,Area,IsDeliver,IsRetail,Code,ContactName,Phone,Email,Status,HelpCode,CreatedDate,IsBorrow,IsDefective,Remark from ERP_Store ");
            strSql.Append(" where StoreId=?StoreId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?StoreId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = StoreId;

			YSWL.Model.ERP.Products.Store model=new YSWL.Model.ERP.Products.Store();
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
		public YSWL.Model.ERP.Products.Store DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Products.Store model=new YSWL.Model.ERP.Products.Store();
			if (row != null)
			{
				if(row["StoreId"]!=null && row["StoreId"].ToString()!="")
				{
					model.StoreId=int.Parse(row["StoreId"].ToString());
				}
				if(row["DepotId"]!=null && row["DepotId"].ToString()!="")
				{
					model.DepotId=int.Parse(row["DepotId"].ToString());
				}
				if(row["StoreName"]!=null)
				{
					model.StoreName=row["StoreName"].ToString();
				}
				if(row["Area"]!=null && row["Area"].ToString()!="")
				{
					model.Area=decimal.Parse(row["Area"].ToString());
				}
				if(row["IsDeliver"]!=null && row["IsDeliver"].ToString()!="")
				{
					if((row["IsDeliver"].ToString()=="1")||(row["IsDeliver"].ToString().ToLower()=="true"))
					{
						model.IsDeliver=true;
					}
					else
					{
						model.IsDeliver=false;
					}
				}
				if(row["IsRetail"]!=null && row["IsRetail"].ToString()!="")
				{
					if((row["IsRetail"].ToString()=="1")||(row["IsRetail"].ToString().ToLower()=="true"))
					{
						model.IsRetail=true;
					}
					else
					{
						model.IsRetail=false;
					}
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["ContactName"]!=null)
				{
					model.ContactName=row["ContactName"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["HelpCode"]!=null)
				{
					model.HelpCode=row["HelpCode"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["IsBorrow"]!=null && row["IsBorrow"].ToString()!="")
				{
					if((row["IsBorrow"].ToString()=="1")||(row["IsBorrow"].ToString().ToLower()=="true"))
					{
						model.IsBorrow=true;
					}
					else
					{
						model.IsBorrow=false;
					}
				}
				if(row["IsDefective"]!=null && row["IsDefective"].ToString()!="")
				{
					if((row["IsDefective"].ToString()=="1")||(row["IsDefective"].ToString().ToLower()=="true"))
					{
						model.IsDefective=true;
					}
					else
					{
						model.IsDefective=false;
					}
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select StoreId,DepotId,StoreName,Area,IsDeliver,IsRetail,Code,ContactName,Phone,Email,Status,HelpCode,CreatedDate,IsBorrow,IsDefective,Remark ");
			strSql.Append(" FROM ERP_Store ");
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
			
			strSql.Append(" StoreId,DepotId,StoreName,Area,IsDeliver,IsRetail,Code,ContactName,Phone,Email,Status,HelpCode,CreatedDate,IsBorrow,IsDefective,Remark ");
			strSql.Append(" FROM ERP_Store ");
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
			strSql.Append("select count(1) FROM ERP_Store ");
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
			strSql.Append("SELECT T.*  from ERP_Store T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.StoreId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
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
			parameters[0].Value = "ERP_Store";
			parameters[1].Value = "StoreId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s.StoreId,s.DepotId,s.StoreName,s.Area,s.IsDeliver,s.IsRetail,s.Code,s.ContactName,s.Phone,s.Email,s.Status,s.HelpCode,s.CreatedDate,s.IsBorrow,s.IsDefective,s.Remark,d.Name DepotName ");
            strSql.Append(" FROM ERP_Store s inner join ERP_Depot d on s.DepotId=d.DepotId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

