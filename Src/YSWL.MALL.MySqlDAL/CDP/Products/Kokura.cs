/**  
* kokura.cs
*
* 功 能： N/A
* 类 名： kokura
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/15 13:59:10   N/A    初版
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
using MySql.Data.MySqlClient;
using YSWL.IDAL.ERP.Kokura;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.Kokura
{
	/// <summary>
	/// 数据访问类:kokura
	/// </summary>
	public partial class Kokura:IKokura
	{
        public Kokura()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from kokura");
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
		public bool Add(YSWL.Model.ERP.Kokura.Kokura model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into kokura(");
			strSql.Append("code,name,address,contactName,email,phone,mobile,visible,BVisible,active,helpCode,joinDate,flag,region_id,lat,lng,type)");
			strSql.Append(" values (");
			strSql.Append("?code,?name,?address,?contactName,?email,?phone,?mobile,?visible,?BVisible,?active,?helpCode,?joinDate,?flag,?region_id,?lat,?lng,?type)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?code", MySqlDbType.VarChar,50),
					new MySqlParameter("?name", MySqlDbType.VarChar,30),
					new MySqlParameter("?address", MySqlDbType.VarChar,200),
					new MySqlParameter("?contactName", MySqlDbType.VarChar,10),
					new MySqlParameter("?email", MySqlDbType.VarChar,20),
					new MySqlParameter("?phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,20),
					new MySqlParameter("?visible", MySqlDbType.Bit),
					new MySqlParameter("?BVisible", MySqlDbType.Bit),
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,30),
					new MySqlParameter("?joinDate", MySqlDbType.DateTime),
					new MySqlParameter("?flag", MySqlDbType.Int32,11),
					new MySqlParameter("?region_id", MySqlDbType.Int64,20),
					new MySqlParameter("?lat", MySqlDbType.Double),
					new MySqlParameter("?lng", MySqlDbType.Double),
					new MySqlParameter("?type", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.name;
			parameters[2].Value = model.address;
			parameters[3].Value = model.contactName;
			parameters[4].Value = model.email;
			parameters[5].Value = model.phone;
			parameters[6].Value = model.mobile;
			parameters[7].Value = model.visible;
			parameters[8].Value = model.BVisible;
			parameters[9].Value = model.active;
			parameters[10].Value = model.helpCode;
			parameters[11].Value = model.joinDate;
			parameters[12].Value = model.flag;
			parameters[13].Value = model.region_id;
			parameters[14].Value = model.lat;
			parameters[15].Value = model.lng;
			parameters[16].Value = model.type;

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
		public bool Update(YSWL.Model.ERP.Kokura.Kokura model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update kokura set ");
			strSql.Append("code=?code,");
			strSql.Append("name=?name,");
			strSql.Append("address=?address,");
			strSql.Append("contactName=?contactName,");
			strSql.Append("email=?email,");
			strSql.Append("phone=?phone,");
			strSql.Append("mobile=?mobile,");
			strSql.Append("visible=?visible,");
			strSql.Append("BVisible=?BVisible,");
			strSql.Append("active=?active,");
			strSql.Append("helpCode=?helpCode,");
			strSql.Append("joinDate=?joinDate,");
			strSql.Append("flag=?flag,");
			strSql.Append("region_id=?region_id,");
			strSql.Append("lat=?lat,");
			strSql.Append("lng=?lng,");
			strSql.Append("type=?type");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?code", MySqlDbType.VarChar,50),
					new MySqlParameter("?name", MySqlDbType.VarChar,30),
					new MySqlParameter("?address", MySqlDbType.VarChar,200),
					new MySqlParameter("?contactName", MySqlDbType.VarChar,10),
					new MySqlParameter("?email", MySqlDbType.VarChar,20),
					new MySqlParameter("?phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,20),
					new MySqlParameter("?visible", MySqlDbType.Bit),
					new MySqlParameter("?BVisible", MySqlDbType.Bit),
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,30),
					new MySqlParameter("?joinDate", MySqlDbType.DateTime),
					new MySqlParameter("?flag", MySqlDbType.Int32,11),
					new MySqlParameter("?region_id", MySqlDbType.Int64,20),
					new MySqlParameter("?lat", MySqlDbType.Double),
					new MySqlParameter("?lng", MySqlDbType.Double),
					new MySqlParameter("?type", MySqlDbType.Int32,11),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.name;
			parameters[2].Value = model.address;
			parameters[3].Value = model.contactName;
			parameters[4].Value = model.email;
			parameters[5].Value = model.phone;
			parameters[6].Value = model.mobile;
			parameters[7].Value = model.visible;
			parameters[8].Value = model.BVisible;
			parameters[9].Value = model.active;
			parameters[10].Value = model.helpCode;
			parameters[11].Value = model.joinDate;
			parameters[12].Value = model.flag;
			parameters[13].Value = model.region_id;
			parameters[14].Value = model.lat;
			parameters[15].Value = model.lng;
			parameters[16].Value = model.type;
			parameters[17].Value = model.id;

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
			strSql.Append("delete from kokura ");
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
			strSql.Append("delete from kokura ");
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
		public YSWL.Model.ERP.Kokura.Kokura GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,code,name,address,contactName,email,phone,mobile,visible,BVisible,active,helpCode,joinDate,flag,region_id,lat,lng,type from kokura ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

			YSWL.Model.ERP.Kokura.Kokura model=new YSWL.Model.ERP.Kokura.Kokura();
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
		public YSWL.Model.ERP.Kokura.Kokura DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Kokura.Kokura model=new YSWL.Model.ERP.Kokura.Kokura();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["contactName"]!=null)
				{
					model.contactName=row["contactName"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
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
				if(row["BVisible"]!=null && row["BVisible"].ToString()!="")
				{
					if((row["BVisible"].ToString()=="1")||(row["BVisible"].ToString().ToLower()=="true"))
					{
						model.BVisible=true;
					}
					else
					{
						model.BVisible=false;
					}
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
				if(row["helpCode"]!=null)
				{
					model.helpCode=row["helpCode"].ToString();
				}
				if(row["joinDate"]!=null && row["joinDate"].ToString()!="")
				{
					model.joinDate=DateTime.Parse(row["joinDate"].ToString());
				}
				if(row["flag"]!=null && row["flag"].ToString()!="")
				{
					model.flag=int.Parse(row["flag"].ToString());
				}
				if(row["region_id"]!=null && row["region_id"].ToString()!="")
				{
					model.region_id=long.Parse(row["region_id"].ToString());
				}
					//model.lat=row["lat"].ToString();
					//model.lng=row["lng"].ToString();
				if(row["type"]!=null && row["type"].ToString()!="")
				{
					model.type=int.Parse(row["type"].ToString());
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
			strSql.Append("select id,code,name,address,contactName,email,phone,mobile,visible,BVisible,active,helpCode,joinDate,flag,region_id,lat,lng,type ");
			strSql.Append(" FROM kokura ");
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
			strSql.Append("select count(1) FROM kokura ");
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
			parameters[0].Value = "kokura";
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

