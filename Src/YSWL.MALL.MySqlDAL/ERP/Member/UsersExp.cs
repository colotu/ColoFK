/**  
* UsersExp.cs
*
* 功 能： N/A
* 类 名： UsersExp
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/21 15:56:52   N/A    初版
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
using YSWL.IDAL.ERP;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
using YSWL.IDAL.ERP.Member;
namespace YSWL.MySqlDAL.ERP.Member
{
	/// <summary>
	/// 数据访问类:UsersExp
	/// </summary>
	public partial class UsersExp:IUsersExp
	{
		public UsersExp()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("UserID", "ERP_UsersExp");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ERP_UsersExp");
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)			};
            parameters[0].Value = UserID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.Model.ERP.Member.UsersExp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ERP_UsersExp(");
            strSql.Append("UserID,UserCode,HelpCode,ShopPhone,Fax,Turnover,Area,ClassId,BusinessScope,ContactPersonName,ContactPersonPhone,AccountantName,AccountantPhone,ShopPhoto)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?UserCode,?HelpCode,?ShopPhone,?Fax,?Turnover,?Area,?ClassId,?BusinessScope,?ContactPersonName,?ContactPersonPhone,?AccountantName,?AccountantPhone,?ShopPhoto)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserCode", MySqlDbType.VarChar,60),
					new MySqlParameter("?HelpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ShopPhone", MySqlDbType.VarChar,30),
					new MySqlParameter("?Fax", MySqlDbType.VarChar,30),
					new MySqlParameter("?Turnover", MySqlDbType.Decimal,8),
					new MySqlParameter("?Area", MySqlDbType.Float,8),
					new MySqlParameter("?ClassId", MySqlDbType.Int16,2),
					new MySqlParameter("?BusinessScope", MySqlDbType.VarChar,50),
					new MySqlParameter("?ContactPersonName", MySqlDbType.VarChar,30),
					new MySqlParameter("?ContactPersonPhone", MySqlDbType.VarChar,30),
					new MySqlParameter("?AccountantName", MySqlDbType.VarChar,30),
					new MySqlParameter("?AccountantPhone", MySqlDbType.VarChar,30),
					new MySqlParameter("?ShopPhoto", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserCode;
            parameters[2].Value = model.HelpCode;
            parameters[3].Value = model.ShopPhone;
            parameters[4].Value = model.Fax;
            parameters[5].Value = model.Turnover;
            parameters[6].Value = model.Area;
            parameters[7].Value = model.ClassId;
            parameters[8].Value = model.BusinessScope;
            parameters[9].Value = model.ContactPersonName;
            parameters[10].Value = model.ContactPersonPhone;
            parameters[11].Value = model.AccountantName;
            parameters[12].Value = model.AccountantPhone;
            parameters[13].Value = model.ShopPhoto;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.Model.ERP.Member.UsersExp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ERP_UsersExp set ");
            strSql.Append("UserCode=?UserCode,");
            strSql.Append("HelpCode=?HelpCode,");
            strSql.Append("ShopPhone=?ShopPhone,");
            strSql.Append("Fax=?Fax,");
            strSql.Append("Turnover=?Turnover,");
            strSql.Append("Area=?Area,");
            strSql.Append("ClassId=?ClassId,");
            strSql.Append("BusinessScope=?BusinessScope,");
            strSql.Append("ContactPersonName=?ContactPersonName,");
            strSql.Append("ContactPersonPhone=?ContactPersonPhone,");
            strSql.Append("AccountantName=?AccountantName,");
            strSql.Append("AccountantPhone=?AccountantPhone,");
            strSql.Append("ShopPhoto=?ShopPhoto");
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserCode", MySqlDbType.VarChar,60),
					new MySqlParameter("?HelpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?ShopPhone", MySqlDbType.VarChar,30),
					new MySqlParameter("?Fax", MySqlDbType.VarChar,30),
					new MySqlParameter("?Turnover", MySqlDbType.Decimal,8),
					new MySqlParameter("?Area", MySqlDbType.Float,8),
					new MySqlParameter("?ClassId", MySqlDbType.Int16,2),
					new MySqlParameter("?BusinessScope", MySqlDbType.VarChar,50),
					new MySqlParameter("?ContactPersonName", MySqlDbType.VarChar,30),
					new MySqlParameter("?ContactPersonPhone", MySqlDbType.VarChar,30),
					new MySqlParameter("?AccountantName", MySqlDbType.VarChar,30),
					new MySqlParameter("?AccountantPhone", MySqlDbType.VarChar,30),
					new MySqlParameter("?ShopPhoto", MySqlDbType.VarChar,100),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserCode;
            parameters[1].Value = model.HelpCode;
            parameters[2].Value = model.ShopPhone;
            parameters[3].Value = model.Fax;
            parameters[4].Value = model.Turnover;
            parameters[5].Value = model.Area;
            parameters[6].Value = model.ClassId;
            parameters[7].Value = model.BusinessScope;
            parameters[8].Value = model.ContactPersonName;
            parameters[9].Value = model.ContactPersonPhone;
            parameters[10].Value = model.AccountantName;
            parameters[11].Value = model.AccountantPhone;
            parameters[12].Value = model.ShopPhoto;
            parameters[13].Value = model.UserID;

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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ERP_UsersExp ");
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)			};
            parameters[0].Value = UserID;

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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ERP_UsersExp ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public YSWL.Model.ERP.Member.UsersExp GetModel(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserCode,HelpCode,ShopPhone,Fax,Turnover,Area,ClassId,BusinessScope,ContactPersonName,ContactPersonPhone,AccountantName,AccountantPhone,ShopPhoto from ERP_UsersExp ");
            strSql.Append(" where UserID=?UserID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)			};
            parameters[0].Value = UserID;

            YSWL.Model.ERP.Member.UsersExp model = new YSWL.Model.ERP.Member.UsersExp();
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.Model.ERP.Member.UsersExp DataRowToModel(DataRow row)
        {
            YSWL.Model.ERP.Member.UsersExp model = new YSWL.Model.ERP.Member.UsersExp();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserCode"] != null)
                {
                    model.UserCode = row["UserCode"].ToString();
                }
                if (row["HelpCode"] != null)
                {
                    model.HelpCode = row["HelpCode"].ToString();
                }
                if (row["ShopPhone"] != null)
                {
                    model.ShopPhone = row["ShopPhone"].ToString();
                }
                if (row["Fax"] != null)
                {
                    model.Fax = row["Fax"].ToString();
                }
                if (row["Turnover"] != null && row["Turnover"].ToString() != "")
                {
                    model.Turnover = decimal.Parse(row["Turnover"].ToString());
                }
                if (row["Area"] != null && row["Area"].ToString() != "")
                {
                    model.Area = decimal.Parse(row["Area"].ToString());
                }
                if (row["ClassId"] != null && row["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(row["ClassId"].ToString());
                }
                if (row["BusinessScope"] != null)
                {
                    model.BusinessScope = row["BusinessScope"].ToString();
                }
                if (row["ContactPersonName"] != null)
                {
                    model.ContactPersonName = row["ContactPersonName"].ToString();
                }
                if (row["ContactPersonPhone"] != null)
                {
                    model.ContactPersonPhone = row["ContactPersonPhone"].ToString();
                }
                if (row["AccountantName"] != null)
                {
                    model.AccountantName = row["AccountantName"].ToString();
                }
                if (row["AccountantPhone"] != null)
                {
                    model.AccountantPhone = row["AccountantPhone"].ToString();
                }
                if (row["ShopPhoto"] != null)
                {
                    model.ShopPhoto = row["ShopPhoto"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserCode,HelpCode,ShopPhone,Fax,Turnover,Area,ClassId,BusinessScope,ContactPersonName,ContactPersonPhone,AccountantName,AccountantPhone,ShopPhoto ");
            strSql.Append(" FROM ERP_UsersExp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            
            strSql.Append(" UserID,UserCode,HelpCode,ShopPhone,Fax,Turnover,Area,ClassId,BusinessScope,ContactPersonName,ContactPersonPhone,AccountantName,AccountantPhone,ShopPhoto ");
            strSql.Append(" FROM ERP_UsersExp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ERP_UsersExp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            strSql.Append("SELECT T.*  from ERP_UsersExp T ");
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
                strSql.Append(" order by T.UserID desc");
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
            parameters[0].Value = "ERP_UsersExp";
            parameters[1].Value = "UserID";
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
        /// 是否已经更新到CDP，更新状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isUpdateToCDP"></param>
        /// <returns></returns>
        public bool UpdatePersonalStatusIndexVisible(long userId, bool isUpdateToCDP)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Accounts_UsersExp set PersonalStatusIndexVisible=?PersonalStatusIndexVisible ");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					 new MySqlParameter("?UserID", MySqlDbType.Int32,4),
                     new MySqlParameter("?PersonalStatusIndexVisible",MySqlDbType.Bit,1)
                                         };
            parameters[0].Value = userId;
            parameters[1].Value = isUpdateToCDP;
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

