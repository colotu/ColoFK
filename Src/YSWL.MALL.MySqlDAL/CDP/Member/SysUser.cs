/**  版本信息模板在安装目录下，可自行修改。
* SysUser.cs
*
* 功 能： N/A
* 类 名： SysUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/17 14:28:39   N/A    初版
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
using YSWL.IDAL;
using YSWL.DBUtility;
using YSWL.IDAL.ERP.Member;//Please add references
namespace YSWL.MySqlDAL.ERP.Member
{
	/// <summary>
    /// 数据访问类:SysUser
	/// </summary>
	public partial class SysUser:ISysUser
	{
        public SysUser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_user");
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
		public bool Add(YSWL.Model.ERP.Member.SysUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_user(");
			strSql.Append("active,address,blAdmin,blDeliver,blOperator,createdDate,degree,email,helpCode,hometown,imagePah,loginName,mobile,password,phone,qq,realName,remark,school,sex,zip,Kokura_id,department_id,role_id,sys_user_card_id,joinDate,blDriver,blSalesman,ownerkokura_id,userType,stock_ent_id,createTime,level,parentId,parentName)");
			strSql.Append(" values (");
			strSql.Append("?active,?address,?blAdmin,?blDeliver,?blOperator,?createdDate,?degree,?email,?helpCode,?hometown,?imagePah,?loginName,?mobile,?password,?phone,?qq,?realName,?remark,?school,?sex,?zip,?Kokura_id,?department_id,?role_id,?sys_user_card_id,?joinDate,?blDriver,?blSalesman,?ownerkokura_id,?userType,?stock_ent_id,?createTime,?level,?parentId,?parentName)");
			MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?address", MySqlDbType.VarChar,100),
					new MySqlParameter("?blAdmin", MySqlDbType.Bit),
					new MySqlParameter("?blDeliver", MySqlDbType.Bit),
					new MySqlParameter("?blOperator", MySqlDbType.Bit),
					new MySqlParameter("?createdDate", MySqlDbType.DateTime),
					new MySqlParameter("?degree", MySqlDbType.VarChar,50),
					new MySqlParameter("?email", MySqlDbType.VarChar,50),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,60),
					new MySqlParameter("?hometown", MySqlDbType.VarChar,100),
					new MySqlParameter("?imagePah", MySqlDbType.VarChar,100),
					new MySqlParameter("?loginName", MySqlDbType.VarChar,30),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,30),
					new MySqlParameter("?password", MySqlDbType.VarChar,100),
					new MySqlParameter("?phone", MySqlDbType.VarChar,30),
					new MySqlParameter("?qq", MySqlDbType.VarChar,20),
					new MySqlParameter("?realName", MySqlDbType.VarChar,30),
					new MySqlParameter("?remark", MySqlDbType.VarChar,100),
					new MySqlParameter("?school", MySqlDbType.VarChar,50),
					new MySqlParameter("?sex", MySqlDbType.VarChar,2),
					new MySqlParameter("?zip", MySqlDbType.VarChar,10),
					new MySqlParameter("?Kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?department_id", MySqlDbType.Int64,20),
					new MySqlParameter("?role_id", MySqlDbType.Int64,20),
					new MySqlParameter("?sys_user_card_id", MySqlDbType.Int64,20),
					new MySqlParameter("?joinDate", MySqlDbType.Date),
					new MySqlParameter("?blDriver", MySqlDbType.Bit),
					new MySqlParameter("?blSalesman", MySqlDbType.Bit),
					new MySqlParameter("?ownerkokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?userType", MySqlDbType.Int32,11),
					new MySqlParameter("?stock_ent_id", MySqlDbType.Int64,20),
					new MySqlParameter("?createTime", MySqlDbType.DateTime),
					new MySqlParameter("?level", MySqlDbType.Int32,11),
					new MySqlParameter("?parentId", MySqlDbType.Int64,20),
					new MySqlParameter("?parentName", MySqlDbType.VarChar,30)};
			parameters[0].Value = model.active;
			parameters[1].Value = model.address;
			parameters[2].Value = model.blAdmin;
			parameters[3].Value = model.blDeliver;
			parameters[4].Value = model.blOperator;
			parameters[5].Value = model.createdDate;
			parameters[6].Value = model.degree;
			parameters[7].Value = model.email;
			parameters[8].Value = model.helpCode;
			parameters[9].Value = model.hometown;
			parameters[10].Value = model.imagePah;
			parameters[11].Value = model.loginName;
			parameters[12].Value = model.mobile;
			parameters[13].Value = model.password;
			parameters[14].Value = model.phone;
			parameters[15].Value = model.qq;
			parameters[16].Value = model.realName;
			parameters[17].Value = model.remark;
			parameters[18].Value = model.school;
			parameters[19].Value = model.sex;
			parameters[20].Value = model.zip;
			parameters[21].Value = model.Kokura_id;
			parameters[22].Value = model.department_id;
			parameters[23].Value = model.role_id;
			parameters[24].Value = model.sys_user_card_id;
			parameters[25].Value = model.joinDate;
			parameters[26].Value = model.blDriver;
			parameters[27].Value = model.blSalesman;
			parameters[28].Value = model.ownerkokura_id;
			parameters[29].Value = model.userType;
			parameters[30].Value = model.stock_ent_id;
			parameters[31].Value = model.createTime;
			parameters[32].Value = model.level;
			parameters[33].Value = model.parentId;
			parameters[34].Value = model.parentName;

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
		public bool Update(YSWL.Model.ERP.Member.SysUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_user set ");
			strSql.Append("active=?active,");
			strSql.Append("address=?address,");
			strSql.Append("blAdmin=?blAdmin,");
			strSql.Append("blDeliver=?blDeliver,");
			strSql.Append("blOperator=?blOperator,");
			strSql.Append("createdDate=?createdDate,");
			strSql.Append("degree=?degree,");
			strSql.Append("email=?email,");
			strSql.Append("helpCode=?helpCode,");
			strSql.Append("hometown=?hometown,");
			strSql.Append("imagePah=?imagePah,");
			strSql.Append("loginName=?loginName,");
			strSql.Append("mobile=?mobile,");
			strSql.Append("password=?password,");
			strSql.Append("phone=?phone,");
			strSql.Append("qq=?qq,");
			strSql.Append("realName=?realName,");
			strSql.Append("remark=?remark,");
			strSql.Append("school=?school,");
			strSql.Append("sex=?sex,");
			strSql.Append("zip=?zip,");
			strSql.Append("Kokura_id=?Kokura_id,");
			strSql.Append("department_id=?department_id,");
			strSql.Append("role_id=?role_id,");
			strSql.Append("sys_user_card_id=?sys_user_card_id,");
			strSql.Append("joinDate=?joinDate,");
			strSql.Append("blDriver=?blDriver,");
			strSql.Append("blSalesman=?blSalesman,");
			strSql.Append("ownerkokura_id=?ownerkokura_id,");
			strSql.Append("userType=?userType,");
			strSql.Append("stock_ent_id=?stock_ent_id,");
			strSql.Append("createTime=?createTime,");
			strSql.Append("level=?level,");
			strSql.Append("parentId=?parentId,");
			strSql.Append("parentName=?parentName");
			strSql.Append(" where id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?address", MySqlDbType.VarChar,100),
					new MySqlParameter("?blAdmin", MySqlDbType.Bit),
					new MySqlParameter("?blDeliver", MySqlDbType.Bit),
					new MySqlParameter("?blOperator", MySqlDbType.Bit),
					new MySqlParameter("?createdDate", MySqlDbType.DateTime),
					new MySqlParameter("?degree", MySqlDbType.VarChar,50),
					new MySqlParameter("?email", MySqlDbType.VarChar,50),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,60),
					new MySqlParameter("?hometown", MySqlDbType.VarChar,100),
					new MySqlParameter("?imagePah", MySqlDbType.VarChar,100),
					new MySqlParameter("?loginName", MySqlDbType.VarChar,30),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,30),
					new MySqlParameter("?password", MySqlDbType.VarChar,100),
					new MySqlParameter("?phone", MySqlDbType.VarChar,30),
					new MySqlParameter("?qq", MySqlDbType.VarChar,20),
					new MySqlParameter("?realName", MySqlDbType.VarChar,30),
					new MySqlParameter("?remark", MySqlDbType.VarChar,100),
					new MySqlParameter("?school", MySqlDbType.VarChar,50),
					new MySqlParameter("?sex", MySqlDbType.VarChar,2),
					new MySqlParameter("?zip", MySqlDbType.VarChar,10),
					new MySqlParameter("?Kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?department_id", MySqlDbType.Int64,20),
					new MySqlParameter("?role_id", MySqlDbType.Int64,20),
					new MySqlParameter("?sys_user_card_id", MySqlDbType.Int64,20),
					new MySqlParameter("?joinDate", MySqlDbType.Date),
					new MySqlParameter("?blDriver", MySqlDbType.Bit),
					new MySqlParameter("?blSalesman", MySqlDbType.Bit),
					new MySqlParameter("?ownerkokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?userType", MySqlDbType.Int32,11),
					new MySqlParameter("?stock_ent_id", MySqlDbType.Int64,20),
					new MySqlParameter("?createTime", MySqlDbType.DateTime),
					new MySqlParameter("?level", MySqlDbType.Int32,11),
					new MySqlParameter("?parentId", MySqlDbType.Int64,20),
					new MySqlParameter("?parentName", MySqlDbType.VarChar,30),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
			parameters[0].Value = model.active;
			parameters[1].Value = model.address;
			parameters[2].Value = model.blAdmin;
			parameters[3].Value = model.blDeliver;
			parameters[4].Value = model.blOperator;
			parameters[5].Value = model.createdDate;
			parameters[6].Value = model.degree;
			parameters[7].Value = model.email;
			parameters[8].Value = model.helpCode;
			parameters[9].Value = model.hometown;
			parameters[10].Value = model.imagePah;
			parameters[11].Value = model.loginName;
			parameters[12].Value = model.mobile;
			parameters[13].Value = model.password;
			parameters[14].Value = model.phone;
			parameters[15].Value = model.qq;
			parameters[16].Value = model.realName;
			parameters[17].Value = model.remark;
			parameters[18].Value = model.school;
			parameters[19].Value = model.sex;
			parameters[20].Value = model.zip;
			parameters[21].Value = model.Kokura_id;
			parameters[22].Value = model.department_id;
			parameters[23].Value = model.role_id;
			parameters[24].Value = model.sys_user_card_id;
			parameters[25].Value = model.joinDate;
			parameters[26].Value = model.blDriver;
			parameters[27].Value = model.blSalesman;
			parameters[28].Value = model.ownerkokura_id;
			parameters[29].Value = model.userType;
			parameters[30].Value = model.stock_ent_id;
			parameters[31].Value = model.createTime;
			parameters[32].Value = model.level;
			parameters[33].Value = model.parentId;
			parameters[34].Value = model.parentName;
			parameters[35].Value = model.id;

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
			strSql.Append("delete from sys_user ");
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
			strSql.Append("delete from sys_user ");
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
		public YSWL.Model.ERP.Member.SysUser GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select u.id,u.active,u.address,u.blAdmin,u.blDeliver,u.blOperator,u.createdDate,u.degree,u.email,u.helpCode,u.hometown,u.imagePah,u.loginName,u.mobile,u.password,u.phone,u.qq,u.realName,u.remark,u.school,u.sex,u.zip,u.Kokura_id,u.department_id,u.role_id,u.sys_user_card_id,u.joinDate,u.blDriver,u.blSalesman,u.ownerkokura_id,u.userType,u.stock_ent_id,u.createTime,u.level,u.parentId,u.parentName,k.`name` ownerkokura_name  FROM sys_user u,kokura k  ");
            strSql.Append(" where  u.ownerkokura_id=k.id and u.id=?id");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
			parameters[0].Value = id;

			YSWL.Model.ERP.Member.SysUser model=new YSWL.Model.ERP.Member.SysUser();
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
		public YSWL.Model.ERP.Member.SysUser DataRowToModel(DataRow row)
		{
			YSWL.Model.ERP.Member.SysUser model=new YSWL.Model.ERP.Member.SysUser();
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
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["blAdmin"]!=null && row["blAdmin"].ToString()!="")
				{
					if((row["blAdmin"].ToString()=="1")||(row["blAdmin"].ToString().ToLower()=="true"))
					{
						model.blAdmin=true;
					}
					else
					{
						model.blAdmin=false;
					}
				}
				if(row["blDeliver"]!=null && row["blDeliver"].ToString()!="")
				{
					if((row["blDeliver"].ToString()=="1")||(row["blDeliver"].ToString().ToLower()=="true"))
					{
						model.blDeliver=true;
					}
					else
					{
						model.blDeliver=false;
					}
				}
				if(row["blOperator"]!=null && row["blOperator"].ToString()!="")
				{
					if((row["blOperator"].ToString()=="1")||(row["blOperator"].ToString().ToLower()=="true"))
					{
						model.blOperator=true;
					}
					else
					{
						model.blOperator=false;
					}
				}
				if(row["createdDate"]!=null && row["createdDate"].ToString()!="")
				{
					model.createdDate=DateTime.Parse(row["createdDate"].ToString());
				}
				if(row["degree"]!=null)
				{
					model.degree=row["degree"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["helpCode"]!=null)
				{
					model.helpCode=row["helpCode"].ToString();
				}
				if(row["hometown"]!=null)
				{
					model.hometown=row["hometown"].ToString();
				}
				if(row["imagePah"]!=null)
				{
					model.imagePah=row["imagePah"].ToString();
				}
				if(row["loginName"]!=null)
				{
					model.loginName=row["loginName"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["qq"]!=null)
				{
					model.qq=row["qq"].ToString();
				}
				if(row["realName"]!=null)
				{
					model.realName=row["realName"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["school"]!=null)
				{
					model.school=row["school"].ToString();
				}
				if(row["sex"]!=null)
				{
					model.sex=row["sex"].ToString();
				}
				if(row["zip"]!=null)
				{
					model.zip=row["zip"].ToString();
				}
				if(row["Kokura_id"]!=null && row["Kokura_id"].ToString()!="")
				{
					model.Kokura_id=long.Parse(row["Kokura_id"].ToString());
				}
				if(row["department_id"]!=null && row["department_id"].ToString()!="")
				{
					model.department_id=long.Parse(row["department_id"].ToString());
				}
				if(row["role_id"]!=null && row["role_id"].ToString()!="")
				{
					model.role_id=long.Parse(row["role_id"].ToString());
				}
				if(row["sys_user_card_id"]!=null && row["sys_user_card_id"].ToString()!="")
				{
					model.sys_user_card_id=long.Parse(row["sys_user_card_id"].ToString());
				}
				if(row["joinDate"]!=null && row["joinDate"].ToString()!="")
				{
					model.joinDate=DateTime.Parse(row["joinDate"].ToString());
				}
				if(row["blDriver"]!=null && row["blDriver"].ToString()!="")
				{
					if((row["blDriver"].ToString()=="1")||(row["blDriver"].ToString().ToLower()=="true"))
					{
						model.blDriver=true;
					}
					else
					{
						model.blDriver=false;
					}
				}
				if(row["blSalesman"]!=null && row["blSalesman"].ToString()!="")
				{
					if((row["blSalesman"].ToString()=="1")||(row["blSalesman"].ToString().ToLower()=="true"))
					{
						model.blSalesman=true;
					}
					else
					{
						model.blSalesman=false;
					}
				}
				if(row["ownerkokura_id"]!=null && row["ownerkokura_id"].ToString()!="")
				{
					model.ownerkokura_id=long.Parse(row["ownerkokura_id"].ToString());
				}
				if(row["userType"]!=null && row["userType"].ToString()!="")
				{
					model.userType=int.Parse(row["userType"].ToString());
				}
				if(row["stock_ent_id"]!=null && row["stock_ent_id"].ToString()!="")
				{
					model.stock_ent_id=long.Parse(row["stock_ent_id"].ToString());
				}
				if(row["createTime"]!=null && row["createTime"].ToString()!="")
				{
					model.createTime=DateTime.Parse(row["createTime"].ToString());
				}
				if(row["level"]!=null && row["level"].ToString()!="")
				{
					model.level=int.Parse(row["level"].ToString());
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=long.Parse(row["parentId"].ToString());
				}
				if(row["parentName"]!=null)
				{
					model.parentName=row["parentName"].ToString();
				}
                if (row["ownerkokura_name"] != null)
                {
                    model.ownerkokura_name = row["ownerkokura_name"].ToString();
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
            strSql.Append(" select u.id,u.active,u.address,u.blAdmin,u.blDeliver,u.blOperator,u.createdDate,u.degree,u.email,u.helpCode,u.hometown,u.imagePah,u.loginName,u.mobile,u.password,u.phone,u.qq,u.realName,u.remark,u.school,u.sex,u.zip,u.Kokura_id,u.department_id,u.role_id,u.sys_user_card_id,u.joinDate,u.blDriver,u.blSalesman,u.ownerkokura_id,u.userType,u.stock_ent_id,u.createTime,u.level,u.parentId,u.parentName,k.`name` ownerkokura_name  ");
            strSql.Append(" FROM sys_user u,kokura k  where u.ownerkokura_id=k.id  ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM sys_user ");
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
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from sys_user T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "sys_user";
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
      /// <summary>
      /// 根据新系统中的userid获取老系统中的用户姓名
      /// </summary>
        /// <param name="zip">新系统中的userid</param>
      /// <returns></returns>
        public string  GetRealName(string zip)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select realName  from sys_user ");
            strSql.AppendFormat(" where zip={0}",zip);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
             if (obj == null)
             {
                 return "";
             }
             else
             {
                 return obj.ToString();
             }
        }

		#endregion  ExtensionMethod
	}
}

