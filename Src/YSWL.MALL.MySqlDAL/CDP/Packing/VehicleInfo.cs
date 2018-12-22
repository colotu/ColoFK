/**  
* vehicleinfo.cs
*
* 功 能： N/A
* 类 名： vehicleinfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/17 15:57:54   N/A    初版
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
using YSWL.IDAL.ERP.Vehicle;
using YSWL.DBUtility;//Please add references
namespace YSWL.MySqlDAL.ERP.Vehicle
{
	/// <summary>
	/// 数据访问类:vehicleinfo
	/// </summary>
	public partial class VehicleInfo:IVehicleInfo
	{
        public VehicleInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from vehicleinfo");
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
		public bool Add(YSWL.Model.ERP.Vehicle.VehicleInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vehicleinfo(");
			strSql.Append("active,buyDate,buyPrice,code,color,driver,enableDate,engineNum,initMileage,policyCompany,regDate,remarks,scrapDate,specification,type,sys_dep_Id,kokura_id,visible,endMileage,gasCard_id)");
			strSql.Append(" values (");
			strSql.Append("?active,?buyDate,?buyPrice,?code,?color,?driver,?enableDate,?engineNum,?initMileage,?policyCompany,?regDate,?remarks,?scrapDate,?specification,?type,?sys_dep_Id,?kokura_id,?visible,?endMileage,?gasCard_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?buyDate", MySqlDbType.DateTime),
					new MySqlParameter("?buyPrice", MySqlDbType.Double),
					new MySqlParameter("?code", MySqlDbType.VarChar,80),
					new MySqlParameter("?color", MySqlDbType.VarChar,60),
					new MySqlParameter("?driver", MySqlDbType.VarChar,60),
					new MySqlParameter("?enableDate", MySqlDbType.DateTime),
					new MySqlParameter("?engineNum", MySqlDbType.VarChar,60),
					new MySqlParameter("?initMileage", MySqlDbType.Double),
					new MySqlParameter("?policyCompany", MySqlDbType.VarChar,60),
					new MySqlParameter("?regDate", MySqlDbType.DateTime),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					new MySqlParameter("?scrapDate", MySqlDbType.DateTime),
					new MySqlParameter("?specification", MySqlDbType.VarChar,255),
					new MySqlParameter("?type", MySqlDbType.VarChar,80),
					new MySqlParameter("?sys_dep_Id", MySqlDbType.Int64,20),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?visible", MySqlDbType.Bit),
					new MySqlParameter("?endMileage", MySqlDbType.Double),
					new MySqlParameter("?gasCard_id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.active;
			parameters[1].Value = model.buyDate;
			parameters[2].Value = model.buyPrice;
			parameters[3].Value = model.code;
			parameters[4].Value = model.color;
			parameters[5].Value = model.driver;
			parameters[6].Value = model.enableDate;
			parameters[7].Value = model.engineNum;
			parameters[8].Value = model.initMileage;
			parameters[9].Value = model.policyCompany;
			parameters[10].Value = model.regDate;
			parameters[11].Value = model.remarks;
			parameters[12].Value = model.scrapDate;
			parameters[13].Value = model.specification;
			parameters[14].Value = model.type;
			parameters[15].Value = model.sys_dep_Id;
			parameters[16].Value = model.kokura_id;
			parameters[17].Value = model.visible;
			parameters[18].Value = model.endMileage;
			parameters[19].Value = model.gasCard_id;

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
		public bool Update(YSWL.Model.ERP.Vehicle.VehicleInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vehicleinfo set ");
			strSql.Append("active=?active,");
			strSql.Append("buyDate=?buyDate,");
			strSql.Append("buyPrice=?buyPrice,");
			strSql.Append("code=?code,");
			strSql.Append("color=?color,");
			strSql.Append("driver=?driver,");
			strSql.Append("enableDate=?enableDate,");
			strSql.Append("engineNum=?engineNum,");
			strSql.Append("initMileage=?initMileage,");
			strSql.Append("policyCompany=?policyCompany,");
			strSql.Append("regDate=?regDate,");
			strSql.Append("remarks=?remarks,");
			strSql.Append("scrapDate=?scrapDate,");
			strSql.Append("specification=?specification,");
			strSql.Append("type=?type,");
			strSql.Append("sys_dep_Id=?sys_dep_Id,");
			strSql.Append("kokura_id=?kokura_id,");
			strSql.Append("visible=?visible,");
			strSql.Append("endMileage=?endMileage,");
			strSql.Append("gasCard_id=?gasCard_id");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?buyDate", MySqlDbType.DateTime),
					new MySqlParameter("?buyPrice", MySqlDbType.Double),
					new MySqlParameter("?code", MySqlDbType.VarChar,80),
					new MySqlParameter("?color", MySqlDbType.VarChar,60),
					new MySqlParameter("?driver", MySqlDbType.VarChar,60),
					new MySqlParameter("?enableDate", MySqlDbType.DateTime),
					new MySqlParameter("?engineNum", MySqlDbType.VarChar,60),
					new MySqlParameter("?initMileage", MySqlDbType.Double),
					new MySqlParameter("?policyCompany", MySqlDbType.VarChar,60),
					new MySqlParameter("?regDate", MySqlDbType.DateTime),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					new MySqlParameter("?scrapDate", MySqlDbType.DateTime),
					new MySqlParameter("?specification", MySqlDbType.VarChar,255),
					new MySqlParameter("?type", MySqlDbType.VarChar,80),
					new MySqlParameter("?sys_dep_Id", MySqlDbType.Int64,20),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?visible", MySqlDbType.Bit),
					new MySqlParameter("?endMileage", MySqlDbType.Double),
					new MySqlParameter("?gasCard_id", MySqlDbType.Int64,20),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.active;
			parameters[1].Value = model.buyDate;
			parameters[2].Value = model.buyPrice;
			parameters[3].Value = model.code;
			parameters[4].Value = model.color;
			parameters[5].Value = model.driver;
			parameters[6].Value = model.enableDate;
			parameters[7].Value = model.engineNum;
			parameters[8].Value = model.initMileage;
			parameters[9].Value = model.policyCompany;
			parameters[10].Value = model.regDate;
			parameters[11].Value = model.remarks;
			parameters[12].Value = model.scrapDate;
			parameters[13].Value = model.specification;
			parameters[14].Value = model.type;
			parameters[15].Value = model.sys_dep_Id;
			parameters[16].Value = model.kokura_id;
			parameters[17].Value = model.visible;
			parameters[18].Value = model.endMileage;
			parameters[19].Value = model.gasCard_id;
			parameters[20].Value = model.id;

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
			strSql.Append("delete from vehicleinfo ");
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
			strSql.Append("delete from vehicleinfo ");
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
        public YSWL.Model.ERP.Vehicle.VehicleInfo GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,active,buyDate,buyPrice,code,color,driver,enableDate,engineNum,initMileage,policyCompany,regDate,remarks,scrapDate,specification,type,sys_dep_Id,kokura_id,visible,endMileage,gasCard_id from vehicleinfo ");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

            YSWL.Model.ERP.Vehicle.VehicleInfo model = new YSWL.Model.ERP.Vehicle.VehicleInfo();
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
        public YSWL.Model.ERP.Vehicle.VehicleInfo DataRowToModel(DataRow row)
		{
            YSWL.Model.ERP.Vehicle.VehicleInfo model = new YSWL.Model.ERP.Vehicle.VehicleInfo();
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
				if(row["buyDate"]!=null && row["buyDate"].ToString()!="")
				{
					model.buyDate=DateTime.Parse(row["buyDate"].ToString());
				}
					//model.buyPrice=row["buyPrice"].ToString();
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["color"]!=null)
				{
					model.color=row["color"].ToString();
				}
				if(row["driver"]!=null)
				{
					model.driver=row["driver"].ToString();
				}
				if(row["enableDate"]!=null && row["enableDate"].ToString()!="")
				{
					model.enableDate=DateTime.Parse(row["enableDate"].ToString());
				}
				if(row["engineNum"]!=null)
				{
					model.engineNum=row["engineNum"].ToString();
				}
					//model.initMileage=row["initMileage"].ToString();
				if(row["policyCompany"]!=null)
				{
					model.policyCompany=row["policyCompany"].ToString();
				}
				if(row["regDate"]!=null && row["regDate"].ToString()!="")
				{
					model.regDate=DateTime.Parse(row["regDate"].ToString());
				}
				if(row["remarks"]!=null)
				{
					model.remarks=row["remarks"].ToString();
				}
				if(row["scrapDate"]!=null && row["scrapDate"].ToString()!="")
				{
					model.scrapDate=DateTime.Parse(row["scrapDate"].ToString());
				}
				if(row["specification"]!=null)
				{
					model.specification=row["specification"].ToString();
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["sys_dep_Id"]!=null && row["sys_dep_Id"].ToString()!="")
				{
					model.sys_dep_Id=long.Parse(row["sys_dep_Id"].ToString());
				}
				if(row["kokura_id"]!=null && row["kokura_id"].ToString()!="")
				{
					model.kokura_id=long.Parse(row["kokura_id"].ToString());
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
					//model.endMileage=row["endMileage"].ToString();
				if(row["gasCard_id"]!=null && row["gasCard_id"].ToString()!="")
				{
					model.gasCard_id=long.Parse(row["gasCard_id"].ToString());
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
			strSql.Append("select id,active,buyDate,buyPrice,code,color,driver,enableDate,engineNum,initMileage,policyCompany,regDate,remarks,scrapDate,specification,type,sys_dep_Id,kokura_id,visible,endMileage,gasCard_id ");
			strSql.Append(" FROM vehicleinfo ");
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
			strSql.Append("select count(1) FROM vehicleinfo ");
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
			parameters[0].Value = "vehicleinfo";
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

