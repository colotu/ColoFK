/**  版本信息模板在安装目录下，可自行修改。
* ERP_Lines.cs
*
* 功 能： N/A
* 类 名： ERP_Lines
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/21 14:32:01   N/A    初版
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
using YSWL.IDAL.ERP.Packing;
using MySql.Data.MySqlClient;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.Packing
{
	/// <summary>
	/// 数据访问类:ERP_Lines
	/// </summary>
	public partial class Lines:ILines
	{
		public Lines()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("LineId", "ERP_Lines"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LineId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ERP_Lines");
			strSql.Append(" where LineId=?LineId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?LineId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = LineId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.Model.ERP.Packing.Lines model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ERP_Lines(");
			strSql.Append("DepotId,LineName,Sequence,RegionId,Address,Status,CreatedUserId,CreatedDate,Remark,SupplierId)");
			strSql.Append("  values (");
            strSql.Append("?DepotId,?LineName,?Sequence,?RegionId,?Address,?Status,?CreatedUserId,?CreatedDate,?Remark,?SupplierId)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4),
					new MySqlParameter("?LineName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?SupplierId", MySqlDbType.Int32,4)                
                                        };
			parameters[0].Value = model.DepotId;
			parameters[1].Value = model.LineName;
			parameters[2].Value = model.Sequence;
			parameters[3].Value = model.RegionId;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CreatedUserId;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.Remark;
            parameters[9].Value = model.SupplierId;
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
		public bool Update(YSWL.Model.ERP.Packing.Lines model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ERP_Lines set ");
			strSql.Append("DepotId=?DepotId,");
			strSql.Append("LineName=?LineName,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("RegionId=?RegionId,");
			strSql.Append("Address=?Address,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedUserId=?CreatedUserId,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Remark=?Remark,");
            strSql.Append("SupplierId=?SupplierId");
			strSql.Append("  where LineId=?LineId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?DepotId", MySqlDbType.Int32,4),
					new MySqlParameter("?LineName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
                    new MySqlParameter("?SupplierId", MySqlDbType.Int32,4),
					new MySqlParameter("?LineId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.DepotId;
			parameters[1].Value = model.LineName;
			parameters[2].Value = model.Sequence;
			parameters[3].Value = model.RegionId;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CreatedUserId;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.Remark;
            parameters[9].Value = model.SupplierId;
			parameters[10].Value = model.LineId;

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
		public bool Delete(int LineId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Lines ");
			strSql.Append(" where LineId=?LineId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?LineId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = LineId;

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
		public bool DeleteList(string LineIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ERP_Lines ");
			strSql.Append(" where LineId in ("+LineIdlist + ")  ");
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
		public YSWL.Model.ERP.Packing.Lines GetModel(int LineId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LineId,DepotId,LineName,Sequence,RegionId,Address,Status,CreatedUserId,CreatedDate,Remark,SupplierId from ERP_Lines ");
            strSql.Append(" where LineId=?LineId LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?LineId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = LineId;

			YSWL.Model.ERP.Packing.Lines model=new YSWL.Model.ERP.Packing.Lines();
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
		public YSWL.Model.ERP.Packing.Lines DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Packing.Lines model=new YSWL.Model.ERP.Packing.Lines();
			if (row != null)
			{
				if(row["LineId"]!=null && row["LineId"].ToString()!="")
				{
					model.LineId=int.Parse(row["LineId"].ToString());
				}
				if(row["DepotId"]!=null && row["DepotId"].ToString()!="")
				{
					model.DepotId=int.Parse(row["DepotId"].ToString());
				}
				if(row["LineName"]!=null)
				{
					model.LineName=row["LineName"].ToString();
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["RegionId"]!=null && row["RegionId"].ToString()!="")
				{
					model.RegionId=int.Parse(row["RegionId"].ToString());
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
                if (row["SupplierId"] != null)
                {
                    model.SupplierId = Convert.ToInt32(row["SupplierId"].ToString());
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
			strSql.Append("select LineId,DepotId,LineName,Sequence,RegionId,Address,Status,CreatedUserId,CreatedDate,Remark,SupplierId  ");
			strSql.Append(" FROM ERP_Lines ");
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
			
            strSql.Append(" LineId,DepotId,LineName,Sequence,RegionId,Address,Status,CreatedUserId,CreatedDate,Remark,SupplierId  ");
			strSql.Append(" FROM ERP_Lines ");
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
			strSql.Append("select count(1) FROM ERP_Lines ");
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
			strSql.Append("SELECT T.*  from ERP_Lines T ");
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
                strSql.Append(" order by T.LineId desc");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
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
			parameters[0].Value = "ERP_Lines";
			parameters[1].Value = "LineId";
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

