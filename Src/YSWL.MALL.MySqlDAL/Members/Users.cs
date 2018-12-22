using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using YSWL.MALL.Model.Shop.Order;
using YSWL.MALL.ViewModel.SAAS;
using YSWL.MALL.Model.Members;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:Users
    /// </summary>
    public partial class Users : IUsers
    {
        public Users()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("UserID", "Accounts_Users");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = UserID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_Users(");
            strSql.Append("UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang)");
            strSql.Append(" values (");
            strSql.Append("?UserName,?Password,?TrueName,?Sex,?Phone,?Email,?EmployeeID,?DepartmentID,?Activity,?UserType,?Style,?User_iCreator,?User_dateCreate,?User_dateValid,?User_dateExpire,?User_iApprover,?User_dateApprove,?User_iApproveState,?User_cLang)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Password", MySqlDbType.Binary,20),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Sex", MySqlDbType.VarChar,10),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
					new MySqlParameter("?EmployeeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?DepartmentID", MySqlDbType.VarChar,15),
					new MySqlParameter("?Activity", MySqlDbType.Bit,1),
					new MySqlParameter("?UserType", MySqlDbType.VarChar,2),
					new MySqlParameter("?Style",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_iCreator",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_dateCreate", MySqlDbType.DateTime),
					new MySqlParameter("?User_dateValid", MySqlDbType.DateTime),
					new MySqlParameter("?User_dateExpire", MySqlDbType.DateTime),
					new MySqlParameter("?User_iApprover",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_dateApprove", MySqlDbType.DateTime),
					new MySqlParameter("?User_iApproveState",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_cLang", MySqlDbType.VarChar,10)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.EmployeeID;
            parameters[7].Value = model.DepartmentID;
            parameters[8].Value = model.Activity;
            parameters[9].Value = model.UserType;
            parameters[10].Value = model.Style;
            parameters[11].Value = model.User_iCreator;
            parameters[12].Value = model.User_dateCreate;
            parameters[13].Value = model.User_dateValid;
            parameters[14].Value = model.User_dateExpire;
            parameters[15].Value = model.User_iApprover;
            parameters[16].Value = model.User_dateApprove;
            parameters[17].Value = model.User_iApproveState;
            parameters[18].Value = model.User_cLang;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(YSWL.MALL.Model.Members.Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_Users set ");
            strSql.Append("UserName=?UserName,");
            strSql.Append("Password=?Password,");
            strSql.Append("TrueName=?TrueName,");
            strSql.Append("Sex=?Sex,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("Email=?Email,");
            strSql.Append("EmployeeID=?EmployeeID,");
            strSql.Append("DepartmentID=?DepartmentID,");
            strSql.Append("Activity=?Activity,");
            strSql.Append("UserType=?UserType,");
            strSql.Append("Style=?Style,");
            strSql.Append("User_iCreator=?User_iCreator,");
            strSql.Append("User_dateCreate=?User_dateCreate,");
            strSql.Append("User_dateValid=?User_dateValid,");
            strSql.Append("User_dateExpire=?User_dateExpire,");
            strSql.Append("User_iApprover=?User_iApprover,");
            strSql.Append("User_dateApprove=?User_dateApprove,");
            strSql.Append("User_iApproveState=?User_iApproveState,");
            strSql.Append("User_cLang=?User_cLang");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Password", MySqlDbType.Binary,20),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Sex", MySqlDbType.VarChar,10),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
					new MySqlParameter("?EmployeeID",  MySqlDbType.Int32,4),
					new MySqlParameter("?DepartmentID", MySqlDbType.VarChar,15),
					new MySqlParameter("?Activity", MySqlDbType.Bit,1),
					new MySqlParameter("?UserType", MySqlDbType.VarChar,2),
					new MySqlParameter("?Style",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_iCreator",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_dateCreate", MySqlDbType.DateTime),
					new MySqlParameter("?User_dateValid", MySqlDbType.DateTime),
					new MySqlParameter("?User_dateExpire", MySqlDbType.DateTime),
					new MySqlParameter("?User_iApprover",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_dateApprove", MySqlDbType.DateTime),
					new MySqlParameter("?User_iApproveState",  MySqlDbType.Int32,4),
					new MySqlParameter("?User_cLang", MySqlDbType.VarChar,10),
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.EmployeeID;
            parameters[7].Value = model.DepartmentID;
            parameters[8].Value = model.Activity;
            parameters[9].Value = model.UserType;
            parameters[10].Value = model.Style;
            parameters[11].Value = model.User_iCreator;
            parameters[12].Value = model.User_dateCreate;
            parameters[13].Value = model.User_dateValid;
            parameters[14].Value = model.User_dateExpire;
            parameters[15].Value = model.User_iApprover;
            parameters[16].Value = model.User_dateApprove;
            parameters[17].Value = model.User_iApproveState;
            parameters[18].Value = model.User_cLang;
            parameters[19].Value = model.UserID;

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
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4)
			};
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
            strSql.Append("delete from Accounts_Users ");
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
        public YSWL.MALL.Model.Members.Users GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   UserID,UserName,NickName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang from Accounts_Users ");
            strSql.Append(" where UserID=?UserID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = UserID;

            YSWL.MALL.Model.Members.Users model = new YSWL.MALL.Model.Members.Users();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = (byte[])ds.Tables[0].Rows[0]["Password"];
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NickName"] != null && ds.Tables[0].Rows[0]["NickName"].ToString() != "")
                {
                    model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EmployeeID"] != null && ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentID"] != null && ds.Tables[0].Rows[0]["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Activity"] != null && ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UserType"] != null && ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Style"] != null && ds.Tables[0].Rows[0]["Style"].ToString() != "")
                {
                    model.Style = int.Parse(ds.Tables[0].Rows[0]["Style"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iCreator"] != null && ds.Tables[0].Rows[0]["User_iCreator"].ToString() != "")
                {
                    model.User_iCreator = int.Parse(ds.Tables[0].Rows[0]["User_iCreator"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateCreate"] != null && ds.Tables[0].Rows[0]["User_dateCreate"].ToString() != "")
                {
                    model.User_dateCreate = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateCreate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateValid"] != null && ds.Tables[0].Rows[0]["User_dateValid"].ToString() != "")
                {
                    model.User_dateValid = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateExpire"] != null && ds.Tables[0].Rows[0]["User_dateExpire"].ToString() != "")
                {
                    model.User_dateExpire = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateExpire"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApprover"] != null && ds.Tables[0].Rows[0]["User_iApprover"].ToString() != "")
                {
                    model.User_iApprover = int.Parse(ds.Tables[0].Rows[0]["User_iApprover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateApprove"] != null && ds.Tables[0].Rows[0]["User_dateApprove"].ToString() != "")
                {
                    model.User_dateApprove = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateApprove"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApproveState"] != null && ds.Tables[0].Rows[0]["User_iApproveState"].ToString() != "")
                {
                    model.User_iApproveState = int.Parse(ds.Tables[0].Rows[0]["User_iApproveState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_cLang"] != null && ds.Tables[0].Rows[0]["User_cLang"].ToString() != "")
                {
                    model.User_cLang = ds.Tables[0].Rows[0]["User_cLang"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Accounts_Users ");
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
            strSql.Append(" UserID,UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang ");
            strSql.Append(" FROM Accounts_Users ");
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
            strSql.Append("select count(1) FROM Accounts_Users ");
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
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            //{
            //    strSql.Append(" order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append(" order by T.UserID desc");
            //}
            //strSql.Append(")AS Row, T.*  from Accounts_Users T ");
            //if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*  from Accounts_Users T ");
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
                strSql.Append(" order by T.UserID desc");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
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
                    new MySqlParameter("?PageSize",  MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex",  MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Accounts_Users";
            parameters[1].Value = "UserID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region MethodEx

        /// <summary>
        /// 根据DepartmentID删除一条数据
        /// </summary>
        public bool DeleteByDepartmentID(int DepartmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where DepartmentID=?DepartmentID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DepartmentID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = DepartmentID;

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
        /// 根据DepartmentID批量删除数据
        /// </summary>
        public bool DeleteListByDepartmentID(string DepartmentIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where DepartmentID in (" + DepartmentIDlist + ")  ");
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
        /// 判断电话是否一件存在
        /// </summary>
        public bool ExistByPhone(string Phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    * from Accounts_Users ");
            strSql.Append(" where Phone=?Phone LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Phone", MySqlDbType.VarChar)
			};
            parameters[0].Value = Phone;

            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据用户邮箱判断是否存在该记录
        /// </summary>
        public bool ExistsByEmail(string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   *  from Accounts_Users ");
            strSql.Append(" where Email=?Email LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Email", MySqlDbType.VarChar)
			};
            parameters[0].Value = Email;
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///根据用户输入的昵称是否存在
        /// </summary>
        public bool ExistsNickName(string nickname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where NickName=?NickName");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?NickName", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = nickname;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        #endregion MethodEx

        /// <summary>
        ///根据用户ID判断昵称是否已被其他用户使用
        /// </summary>
        public bool ExistsNickName(int userid, string nickname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where UserID<>?UserID AND NickName=?NickName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID",  MySqlDbType.Int32,4),
                    new MySqlParameter("?NickName", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = userid;
            parameters[1].Value = nickname;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetList(string type, string keyWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM Accounts_Users ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrWhiteSpace(type))
            {
                strSql.Append(" AND UserType=" + type);
            }
            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                strSql.AppendFormat(" AND UserName LIKE '%{0}%' ", Common.InjectionFilter.SqlFilter(keyWord));
            }
            strSql.Append(" AND Activity=1 ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        //联合查询用户表和用户附件表(普通用户)
        public DataSet GetListEX(string keyWord = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users inner join Accounts_UsersExp on Accounts_UsersExp.UserID=Accounts_Users.UserID");
            strSql.Append(" WHERE UserType='UU'");
            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                strSql.AppendFormat(" AND UserName LIKE '%{0}%' ", Common.InjectionFilter.SqlFilter(keyWord));
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        //联合查询用户表和用户附件表
        public DataSet GetListEXByType(string type, string keyWord = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users inner join Accounts_UsersExp on Accounts_UsersExp.UserID=Accounts_Users.UserID");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append(" AND UserType='" + Common.InjectionFilter.SqlFilter(type) + "'");
            }
            if (!string.IsNullOrEmpty(keyWord))
            {
                strSql.AppendFormat(" AND UserName LIKE '%{0}%' ", Common.InjectionFilter.SqlFilter(keyWord));
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        //联合查询用户表和用户附件表
        public DataSet GetSearchList(string type, string StrWhere = "", string Field = "")
        {
            StringBuilder strSql = new StringBuilder();
            string FieldStr = "*";
            if (!string.IsNullOrEmpty(Field))
            {
                FieldStr = Field;
            }
            strSql.Append("select " + FieldStr + " from Accounts_Users au inner join Accounts_UsersExp ue on ue.UserID=au.UserID");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append(" AND UserType='" + Common.InjectionFilter.SqlFilter(type) + "'");
            }
            if (!string.IsNullOrEmpty(StrWhere))
            {
                strSql.Append(" and " + StrWhere);
            }
            strSql.Append(" order by  User_dateCreate desc");
            return DbHelperMySQL.Query(strSql.ToString());
        }
        //联合查询用户表和用户附件表
        public DataSet GetSearchList(string type, string StrWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users inner join Accounts_UsersExp on Accounts_UsersExp.UserID=Accounts_Users.UserID");
            StringBuilder strWhere2 = new StringBuilder();
            if (!string.IsNullOrEmpty(type))
            {
                if (!String.IsNullOrWhiteSpace(strWhere2.ToString()))
                {
                    strWhere2.Append(" AND ");
                }
                strWhere2.Append("  UserType='" + Common.InjectionFilter.SqlFilter(type) + "'");
            }
            if (!string.IsNullOrEmpty(StrWhere))
            {
                if (!String.IsNullOrWhiteSpace(strWhere2.ToString()))
                {
                    strWhere2.Append(" AND ");
                }
                strWhere2.Append(StrWhere);
            }
            strSql.Append(" WHERE   " + strWhere2.ToString());
            strSql.Append(" order by  User_dateCreate desc");
            return DbHelperMySQL.Query(strSql.ToString());
        }
        public int GetUserIdByNickName(string NickName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID FROM Accounts_Users ");
            if (NickName.Trim() != "")
            {
                strSql.Append(" where NickName='" + Common.InjectionFilter.SqlFilter(NickName) + "'");
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

        public string GetUserName(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName FROM Accounts_Users ");
            strSql.Append(" where UserId=" + UserId);
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

        /// <summary>
        /// 一键更新用户的粉丝数和关注数
        /// </summary>
        /// <returns></returns>
        public bool UpdateFansAndFellowCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_UsersExp SET FansCount=(SELECT COUNT(1) FROM SNS_UserShip us WHERE Accounts_UsersExp.UserID=us.PassiveUserID),FellowCount=(SELECT COUNT(1) FROM SNS_UserShip us WHERE Accounts_UsersExp.UserID=us.ActiveUserID)");
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
        /// 对用户进行批量冻结和解冻
        /// </summary>
        /// <param name="Ids">用户的id集合</param>
        /// <param name="ActiveType">冻结或冻结</param>
        /// <returns></returns>
        public bool UpdateActiveStatus(string Ids, int ActiveType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_Users SET Activity=" + ActiveType + " Where UserID in(" + Ids + ")");
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

        public int GetUserIdByDepartmentID(string DepartmentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID FROM Accounts_Users ");
            strSql.Append(" where DepartmentID=?DepartmentID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?DepartmentID", MySqlDbType.VarChar,15),
			};
            parameters[0].Value = DepartmentID;
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        
        public int GetDefaultUserId()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MIN(UserID) from Accounts_Users   where  Activity=1 and UserType='UU'");
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }



        public string GetNickName(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NickName FROM Accounts_Users ");
            strSql.Append(" where UserId=" + UserId);
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


        public bool DeleteEx(int userId)
        {

            //事务处理
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from Accounts_UserRoles ");
            strSql2.Append(" where UserID=?UserID  ");
            MySqlParameter[] parameters2 = {
						new MySqlParameter("?UserID", MySqlDbType.Int32,4)
                                         };
            parameters2[0].Value = userId;
            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Accounts_Users ");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = userId;
             cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

         

            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from Accounts_UsersExp ");
            strSql1.Append(" where UserID=?UserID  ");
            MySqlParameter[] parameters1 = {
						new MySqlParameter("?UserID", MySqlDbType.Int32,4)
                                         };
            parameters1[0].Value = userId;
            cmd= new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd);

     

            //StringBuilder strSql3 = new StringBuilder();
            //strSql3.Append("alter table test2 drop constraint FK__test2__id__08EA5793 ");
            //strSql3.Append(" where UserID=?UserID  ");
         
            //cmd = new CommandInfo(strSql2.ToString(), parameters2);
            //sqllist.Add(cmd);
            

            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;


        }

        public YSWL.MALL.Model.Members.Users GetModel(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  UserID,UserName,NickName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_iCreator,User_dateCreate,User_dateValid,User_dateExpire,User_iApprover,User_dateApprove,User_iApproveState,User_cLang from Accounts_Users ");
            strSql.Append(" where UserName=?UserName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200)
			};
            parameters[0].Value = userName;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Members.Users model = new YSWL.MALL.Model.Members.Users();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"] != null && ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Password"] != null && ds.Tables[0].Rows[0]["Password"].ToString() != "")
                {
                    model.Password = (byte[])ds.Tables[0].Rows[0]["Password"];
                }
                if (ds.Tables[0].Rows[0]["TrueName"] != null && ds.Tables[0].Rows[0]["TrueName"].ToString() != "")
                {
                    model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NickName"] != null && ds.Tables[0].Rows[0]["NickName"].ToString() != "")
                {
                    model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EmployeeID"] != null && ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentID"] != null && ds.Tables[0].Rows[0]["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Activity"] != null && ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UserType"] != null && ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Style"] != null && ds.Tables[0].Rows[0]["Style"].ToString() != "")
                {
                    model.Style = int.Parse(ds.Tables[0].Rows[0]["Style"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iCreator"] != null && ds.Tables[0].Rows[0]["User_iCreator"].ToString() != "")
                {
                    model.User_iCreator = int.Parse(ds.Tables[0].Rows[0]["User_iCreator"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateCreate"] != null && ds.Tables[0].Rows[0]["User_dateCreate"].ToString() != "")
                {
                    model.User_dateCreate = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateCreate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateValid"] != null && ds.Tables[0].Rows[0]["User_dateValid"].ToString() != "")
                {
                    model.User_dateValid = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateExpire"] != null && ds.Tables[0].Rows[0]["User_dateExpire"].ToString() != "")
                {
                    model.User_dateExpire = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateExpire"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApprover"] != null && ds.Tables[0].Rows[0]["User_iApprover"].ToString() != "")
                {
                    model.User_iApprover = int.Parse(ds.Tables[0].Rows[0]["User_iApprover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_dateApprove"] != null && ds.Tables[0].Rows[0]["User_dateApprove"].ToString() != "")
                {
                    model.User_dateApprove = DateTime.Parse(ds.Tables[0].Rows[0]["User_dateApprove"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_iApproveState"] != null && ds.Tables[0].Rows[0]["User_iApproveState"].ToString() != "")
                {
                    model.User_iApproveState = int.Parse(ds.Tables[0].Rows[0]["User_iApproveState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["User_cLang"] != null && ds.Tables[0].Rows[0]["User_cLang"].ToString() != "")
                {
                    model.User_cLang = ds.Tables[0].Rows[0]["User_cLang"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetUserCount(StatisticMode mode, DateTime startDate, DateTime endDate)
        {

            int subLength = 8;
            string method;
            switch (mode)
            {
                case StatisticMode.Year:
                    subLength = 4;
                    method = "GET_GeneratedYear";
                    break;
                case StatisticMode.Month:
                    subLength = 6;
                    method = "GET_GeneratedMonth";
                    break;
                case StatisticMode.Day:
                    subLength = 8;
                    method = "GET_GeneratedDay";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(
           @"
--用户统计走势图
SELECT  A.GeneratedDate AS GeneratedDate
        ,UserID as Users
FROM    ( SELECT    *
          FROM      {0}(?StartDate, ?EndDate)
        ) A
        LEFT JOIN ( SELECT  CONVERT(varchar({1}) , U.User_dateCreate, 112 ) GeneratedDate
                         ,count(UserID) UserID
                    FROM    Accounts_Users U ", method, subLength);

            strSql.AppendFormat(@" 
                          where U.User_dateCreate BETWEEN ?StartDate AND ?EndDate 
                    GROUP BY CONVERT(varchar({0}) , U.User_dateCreate, 112 )
                  ) B 
ON CONVERT(varchar({0}) , A.GeneratedDate, 112 ) = CONVERT(varchar({0}) , B.GeneratedDate, 112 ) 
", subLength);
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?StartDate", SqlDbType.DateTime),
                new MySqlParameter("?EndDate", SqlDbType.DateTime)
            };
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;

            return DbHelperMySQL.Query(strSql.ToString(), parameters);

        }


        /// <summary>
        ///根据用户ID判断昵称是否已被其他用户使用
        /// </summary>
        public bool ExistsUserName(int userid, string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Users");
            strSql.Append(" where UserID<>?UserID AND UserName=?UserName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserName", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = userid;
            parameters[1].Value = username;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 批量绑定业务员
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="salesId"></param>
        /// <returns></returns>
        public bool UpdateSales(string userIds, int salesId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update   Accounts_Users set EmployeeID= " + salesId);
            strSql.Append(" where UserID in (" + userIds + ")  ");
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
        /// 用户注册统计--日期
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataSet GetDayRegCount(DateTime startDate, DateTime endDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select CONVERT(varchar(20),User_dateCreate,111) D,COUNT(*) UserCount from Accounts_Users ");
            strSql.AppendFormat(" where User_dateCreate BETWEEN '{0}' AND '{1}'", startDate, endDate);
            strSql.AppendFormat(" group by CONVERT(varchar(20),User_dateCreate,111)");
            return DbHelperMySQL.Query(strSql.ToString());
        }


        public DataSet GetDayRegCount(DateTime startDate, DateTime endDate, StatisticMode mode)
        {
            throw new NotImplementedException();
        }

        public DataSet GetCustList(int userId, int IsAct = -1, string KeyWord = "",string startDate="")
        {
            throw new NotImplementedException();
        }



        public bool Exists(int EmployeeID, int UserID)
        {
            throw new NotImplementedException();
        }

        public DataSet SalesRegisters(DateTime startDay, DateTime endDay)
        {
            throw new NotImplementedException();
        }

        public int GetSalesRegs(int SalesId, string startDay, string endDay)
        {
            throw new NotImplementedException();
        }

        public DataSet GetSalesRegList(int SalesId, string startDate, string endDate, int dateType = 0)
        {
            throw new NotImplementedException();
        }


        public DataSet GetShopByRegion(int regionId,int supplierId)
        {
            throw new NotImplementedException();
        }

        public YSWL.MALL.Model.Members.Users GetInviteUser(int userId)
        {
            throw new NotImplementedException();
        }

        #region 获取SAAS子账号用户信息
        public YSWL.MALL.ViewModel.SAAS.UserInfo GetSAUserInfo(string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        public UserInfo GetSAUserInfo(string userName, string passWord, int userType = 1)
        {
            throw new NotImplementedException();
        }

        int IUsers.GetMaxId()
        {
            throw new NotImplementedException();
        }

        bool IUsers.Exists(int UserID)
        {
            throw new NotImplementedException();
        }

        int IUsers.Add(Model.Members.Users model)
        {
            throw new NotImplementedException();
        }

        bool IUsers.Update(Model.Members.Users model)
        {
            throw new NotImplementedException();
        }

        bool IUsers.Delete(int UserID)
        {
            throw new NotImplementedException();
        }

        bool IUsers.DeleteList(string UserIDlist)
        {
            throw new NotImplementedException();
        }

        Model.Members.Users IUsers.GetModel(int UserID)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetList(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetList(int Top, string strWhere, string filedOrder)
        {
            throw new NotImplementedException();
        }

        int IUsers.GetRecordCount(string strWhere)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }

        bool IUsers.DeleteByDepartmentID(int DepartmentID)
        {
            throw new NotImplementedException();
        }

        bool IUsers.DeleteListByDepartmentID(string DepartmentIDlist)
        {
            throw new NotImplementedException();
        }

        bool IUsers.ExistByPhone(string Phone)
        {
            throw new NotImplementedException();
        }

        bool IUsers.ExistsByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        bool IUsers.ExistsNickName(string nickname)
        {
            throw new NotImplementedException();
        }

        bool IUsers.ExistsNickName(int userid, string nickname)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetList(string type, string keyWord)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetListEX(string keyWord)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetListEXByType(string type, string keyWord)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetSearchList(string type, string StrWhere)
        {
            throw new NotImplementedException();
        }

        bool IUsers.UpdateFansAndFellowCount()
        {
            throw new NotImplementedException();
        }

        int IUsers.GetUserIdByNickName(string NickName)
        {
            throw new NotImplementedException();
        }

        string IUsers.GetUserName(int userId)
        {
            throw new NotImplementedException();
        }

        int IUsers.GetUserIdByDepartmentID(string DepartmentID)
        {
            throw new NotImplementedException();
        }

        bool IUsers.UpdateActiveStatus(string Ids, int ActiveType)
        {
            throw new NotImplementedException();
        }

        int IUsers.GetDefaultUserId()
        {
            throw new NotImplementedException();
        }

        string IUsers.GetNickName(int userId)
        {
            throw new NotImplementedException();
        }

        bool IUsers.DeleteEx(int userId)
        {
            throw new NotImplementedException();
        }

        Model.Members.Users IUsers.GetModel(string userName)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetUserCount(StatisticMode mode, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        bool IUsers.ExistsUserName(int userid, string username)
        {
            throw new NotImplementedException();
        }

        bool IUsers.UpdateSales(string userIds, int salesId)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetDayRegCount(DateTime startDate, DateTime endDate, StatisticMode mode)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetCustList(int userId, int IsAct, string KeyWord, string startDate)
        {
            throw new NotImplementedException();
        }

        bool IUsers.Exists(int EmployeeID, int UserID)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.SalesRegisters(DateTime startDay, DateTime endDay)
        {
            throw new NotImplementedException();
        }

        int IUsers.GetSalesRegs(int SalesId, string startDay, string endDay)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetSalesRegList(int SalesId, string startDay, string endDay, int dateType)
        {
            throw new NotImplementedException();
        }

        DataSet IUsers.GetShopByRegion(int regionId, int supplierId)
        {
            throw new NotImplementedException();
        }

        Model.Members.Users IUsers.GetInviteUser(int userId)
        {
            throw new NotImplementedException();
        }

        UserInfo IUsers.GetSAUserInfo(string userName, string passWord, int userType, long enterpriseId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}