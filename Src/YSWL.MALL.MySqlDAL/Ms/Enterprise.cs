using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Ms;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Ms
{
    /// <summary>
    /// 数据访问类:Enterprise
    /// </summary>
    public partial class Enterprise : IEnterprise
    {
        public Enterprise()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("EnterpriseID", "Ms_Enterprise");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EnterpriseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Enterprise");
            strSql.Append(" where EnterpriseID=?EnterpriseID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?EnterpriseID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = EnterpriseID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 企业名称是否已存在
        /// </summary>
        public bool Exists(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Enterprise");
            strSql.Append(" where Name=?Name");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarString,100)
			};
            parameters[0].Value = Name;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 企业名称是否已存在
        /// </summary>
        public bool Exists(string Name, int EnterpriseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Enterprise");
            strSql.Append(" where Name=?Name AND EnterpriseID<>?EnterpriseID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarString,100),
                    new MySqlParameter("?EnterpriseID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = Name;
            parameters[1].Value = EnterpriseID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.Enterprise model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT intO Ms_Enterprise(");
            strSql.Append("Name,Introduction,RegisteredCapital,TelPhone,CellPhone,ContactMail,RegionID,Address,Remark,Contact,UserName,EstablishedDate,EstablishedCity,LOGO,Fax,PostCode,HomePage,ArtiPerson,EnteRank,EnteClassID,CompanyType,BusinessLicense,TaxNumber,AccountBank,AccountInfo,ServicePhone,QQ,MSN,Status,CreatedDate,CreatedUserID,UpdatedDate,UpdatedUserID,Balance,AgentID)");
            strSql.Append(" VALUES (");
            strSql.Append("?Name,?Introduction,?RegisteredCapital,?TelPhone,?CellPhone,?ContactMail,?RegionID,?Address,?Remark,?Contact,?UserName,?EstablishedDate,?EstablishedCity,?LOGO,?Fax,?PostCode,?HomePage,?ArtiPerson,?EnteRank,?EnteClassID,?CompanyType,?BusinessLicense,?TaxNumber,?AccountBank,?AccountInfo,?ServicePhone,?QQ,?MSN,?Status,?CreatedDate,?CreatedUserID,?UpdatedDate,?UpdatedUserID,?Balance,?AgentID)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarString,100),
					new MySqlParameter("?Introduction", MySqlDbType.VarString),
					new MySqlParameter("?RegisteredCapital",  MySqlDbType.Int32,4),
					new MySqlParameter("?TelPhone", MySqlDbType.VarString,50),
					new MySqlParameter("?CellPhone", MySqlDbType.VarString,50),
					new MySqlParameter("?ContactMail", MySqlDbType.VarString,50),
					new MySqlParameter("?RegionID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarString,500),
					new MySqlParameter("?Remark", MySqlDbType.VarString,1000),
					new MySqlParameter("?Contact", MySqlDbType.VarString,50),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,30),
					new MySqlParameter("?EstablishedDate", MySqlDbType.DateTime),
					new MySqlParameter("?EstablishedCity",  MySqlDbType.Int32,4),
					new MySqlParameter("?LOGO", MySqlDbType.VarChar,300),
					new MySqlParameter("?Fax", MySqlDbType.VarChar,30),
					new MySqlParameter("?PostCode", MySqlDbType.VarChar,10),
					new MySqlParameter("?HomePage", MySqlDbType.VarChar,50),
					new MySqlParameter("?ArtiPerson", MySqlDbType.VarChar,50),
					new MySqlParameter("?EnteRank",  MySqlDbType.Int32,4),
					new MySqlParameter("?EnteClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CompanyType", MySqlDbType.Int16,2),
					new MySqlParameter("?BusinessLicense", MySqlDbType.VarChar,300),
					new MySqlParameter("?TaxNumber", MySqlDbType.VarChar,300),
					new MySqlParameter("?AccountBank", MySqlDbType.VarChar,300),
					new MySqlParameter("?AccountInfo", MySqlDbType.VarChar,300),
					new MySqlParameter("?ServicePhone", MySqlDbType.VarChar,300),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,30),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,30),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
					new MySqlParameter("?AgentID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Introduction;
            parameters[2].Value = model.RegisteredCapital;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.CellPhone;
            parameters[5].Value = model.ContactMail;
            parameters[6].Value = model.RegionID;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Contact;
            parameters[10].Value = model.UserName;
            parameters[11].Value = model.EstablishedDate;
            parameters[12].Value = model.EstablishedCity;
            parameters[13].Value = model.LOGO;
            parameters[14].Value = model.Fax;
            parameters[15].Value = model.PostCode;
            parameters[16].Value = model.HomePage;
            parameters[17].Value = model.ArtiPerson;
            parameters[18].Value = model.EnteRank;
            parameters[19].Value = model.EnteClassID;
            parameters[20].Value = model.CompanyType;
            parameters[21].Value = model.BusinessLicense;
            parameters[22].Value = model.TaxNumber;
            parameters[23].Value = model.AccountBank;
            parameters[24].Value = model.AccountInfo;
            parameters[25].Value = model.ServicePhone;
            parameters[26].Value = model.QQ;
            parameters[27].Value = model.MSN;
            parameters[28].Value = model.Status;
            parameters[29].Value = model.CreatedDate;
            parameters[30].Value = model.CreatedUserID;
            parameters[31].Value = model.UpdatedDate;
            parameters[32].Value = model.UpdatedUserID;
            parameters[33].Value = model.Balance;
            parameters[34].Value = model.AgentID;

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
        public bool Update(YSWL.MALL.Model.Ms.Enterprise model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Ms_Enterprise SET ");
            strSql.Append("Name=?Name,");
            strSql.Append("Introduction=?Introduction,");
            strSql.Append("RegisteredCapital=?RegisteredCapital,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("CellPhone=?CellPhone,");
            strSql.Append("ContactMail=?ContactMail,");
            strSql.Append("RegionID=?RegionID,");
            strSql.Append("Address=?Address,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("Contact=?Contact,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("EstablishedDate=?EstablishedDate,");
            strSql.Append("EstablishedCity=?EstablishedCity,");
            strSql.Append("LOGO=?LOGO,");
            strSql.Append("Fax=?Fax,");
            strSql.Append("PostCode=?PostCode,");
            strSql.Append("HomePage=?HomePage,");
            strSql.Append("ArtiPerson=?ArtiPerson,");
            strSql.Append("EnteRank=?EnteRank,");
            strSql.Append("EnteClassID=?EnteClassID,");
            strSql.Append("CompanyType=?CompanyType,");
            strSql.Append("BusinessLicense=?BusinessLicense,");
            strSql.Append("TaxNumber=?TaxNumber,");
            strSql.Append("AccountBank=?AccountBank,");
            strSql.Append("AccountInfo=?AccountInfo,");
            strSql.Append("ServicePhone=?ServicePhone,");
            strSql.Append("QQ=?QQ,");
            strSql.Append("MSN=?MSN,");
            strSql.Append("Status=?Status,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("CreatedUserID=?CreatedUserID,");
            strSql.Append("UpdatedDate=?UpdatedDate,");
            strSql.Append("UpdatedUserID=?UpdatedUserID,");
            strSql.Append("Balance=?Balance,");
            strSql.Append("AgentID=?AgentID");
            strSql.Append(" WHERE EnterpriseID=?EnterpriseID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarString,100),
					new MySqlParameter("?Introduction", MySqlDbType.VarString),
					new MySqlParameter("?RegisteredCapital",  MySqlDbType.Int32,4),
					new MySqlParameter("?TelPhone", MySqlDbType.VarString,50),
					new MySqlParameter("?CellPhone", MySqlDbType.VarString,50),
					new MySqlParameter("?ContactMail", MySqlDbType.VarString,50),
					new MySqlParameter("?RegionID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarString,500),
					new MySqlParameter("?Remark", MySqlDbType.VarString,1000),
					new MySqlParameter("?Contact", MySqlDbType.VarString,50),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,30),
					new MySqlParameter("?EstablishedDate", MySqlDbType.DateTime),
					new MySqlParameter("?EstablishedCity",  MySqlDbType.Int32,4),
					new MySqlParameter("?LOGO", MySqlDbType.VarChar,300),
					new MySqlParameter("?Fax", MySqlDbType.VarChar,30),
					new MySqlParameter("?PostCode", MySqlDbType.VarChar,10),
					new MySqlParameter("?HomePage", MySqlDbType.VarChar,50),
					new MySqlParameter("?ArtiPerson", MySqlDbType.VarChar,50),
					new MySqlParameter("?EnteRank",  MySqlDbType.Int32,4),
					new MySqlParameter("?EnteClassID",  MySqlDbType.Int32,4),
					new MySqlParameter("?CompanyType", MySqlDbType.Int16,2),
					new MySqlParameter("?BusinessLicense", MySqlDbType.VarChar,300),
					new MySqlParameter("?TaxNumber", MySqlDbType.VarChar,300),
					new MySqlParameter("?AccountBank", MySqlDbType.VarChar,300),
					new MySqlParameter("?AccountInfo", MySqlDbType.VarChar,300),
					new MySqlParameter("?ServicePhone", MySqlDbType.VarChar,300),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,30),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,30),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?CreatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?UpdatedUserID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
					new MySqlParameter("?AgentID",  MySqlDbType.Int32,4),
					new MySqlParameter("?EnterpriseID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Introduction;
            parameters[2].Value = model.RegisteredCapital;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.CellPhone;
            parameters[5].Value = model.ContactMail;
            parameters[6].Value = model.RegionID;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.Contact;
            parameters[10].Value = model.UserName;
            parameters[11].Value = model.EstablishedDate;
            parameters[12].Value = model.EstablishedCity;
            parameters[13].Value = model.LOGO;
            parameters[14].Value = model.Fax;
            parameters[15].Value = model.PostCode;
            parameters[16].Value = model.HomePage;
            parameters[17].Value = model.ArtiPerson;
            parameters[18].Value = model.EnteRank;
            parameters[19].Value = model.EnteClassID;
            parameters[20].Value = model.CompanyType;
            parameters[21].Value = model.BusinessLicense;
            parameters[22].Value = model.TaxNumber;
            parameters[23].Value = model.AccountBank;
            parameters[24].Value = model.AccountInfo;
            parameters[25].Value = model.ServicePhone;
            parameters[26].Value = model.QQ;
            parameters[27].Value = model.MSN;
            parameters[28].Value = model.Status;
            parameters[29].Value = model.CreatedDate;
            parameters[30].Value = model.CreatedUserID;
            parameters[31].Value = model.UpdatedDate;
            parameters[32].Value = model.UpdatedUserID;
            parameters[33].Value = model.Balance;
            parameters[34].Value = model.AgentID;
            parameters[35].Value = model.EnterpriseID;

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
        public bool Delete(int EnterpriseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Enterprise ");
            strSql.Append(" where EnterpriseID=?EnterpriseID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?EnterpriseID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = EnterpriseID;

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
        public bool DeleteList(string EnterpriseIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Enterprise ");
            strSql.Append(" where EnterpriseID in (" + EnterpriseIDlist + ")  ");
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
        public YSWL.MALL.Model.Ms.Enterprise GetModel(int EnterpriseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MsEn.*,AU.UserName AS CreatedUserName,AUser.UserName AS UpdatedUserName FROM Ms_Enterprise MsEn  ");
            strSql.Append(" LEFT JOIN Accounts_Users AU ON MsEn.CreatedUserID=AU.UserID ");
            strSql.Append(" LEFT JOIN Accounts_Users AUser ON MsEn.UpdatedUserID=AUser.UserID ");
            strSql.Append(" where EnterpriseID=?EnterpriseID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?EnterpriseID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = EnterpriseID;

            YSWL.MALL.Model.Ms.Enterprise model = new YSWL.MALL.Model.Ms.Enterprise();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EnterpriseID"] != null && ds.Tables[0].Rows[0]["EnterpriseID"].ToString() != "")
                {
                    model.EnterpriseID = int.Parse(ds.Tables[0].Rows[0]["EnterpriseID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Introduction"] != null && ds.Tables[0].Rows[0]["Introduction"].ToString() != "")
                {
                    model.Introduction = ds.Tables[0].Rows[0]["Introduction"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RegisteredCapital"] != null && ds.Tables[0].Rows[0]["RegisteredCapital"].ToString() != "")
                {
                    model.RegisteredCapital = int.Parse(ds.Tables[0].Rows[0]["RegisteredCapital"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CellPhone"] != null && ds.Tables[0].Rows[0]["CellPhone"].ToString() != "")
                {
                    model.CellPhone = ds.Tables[0].Rows[0]["CellPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContactMail"] != null && ds.Tables[0].Rows[0]["ContactMail"].ToString() != "")
                {
                    model.ContactMail = ds.Tables[0].Rows[0]["ContactMail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RegionID"] != null && ds.Tables[0].Rows[0]["RegionID"].ToString() != "")
                {
                    model.RegionID = int.Parse(ds.Tables[0].Rows[0]["RegionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Contact"] != null && ds.Tables[0].Rows[0]["Contact"].ToString() != "")
                {
                    model.Contact = ds.Tables[0].Rows[0]["Contact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EstablishedDate"] != null && ds.Tables[0].Rows[0]["EstablishedDate"].ToString() != "")
                {
                    model.EstablishedDate = DateTime.Parse(ds.Tables[0].Rows[0]["EstablishedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EstablishedCity"] != null && ds.Tables[0].Rows[0]["EstablishedCity"].ToString() != "")
                {
                    model.EstablishedCity = int.Parse(ds.Tables[0].Rows[0]["EstablishedCity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LOGO"] != null && ds.Tables[0].Rows[0]["LOGO"].ToString() != "")
                {
                    model.LOGO = ds.Tables[0].Rows[0]["LOGO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Fax"] != null && ds.Tables[0].Rows[0]["Fax"].ToString() != "")
                {
                    model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PostCode"] != null && ds.Tables[0].Rows[0]["PostCode"].ToString() != "")
                {
                    model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HomePage"] != null && ds.Tables[0].Rows[0]["HomePage"].ToString() != "")
                {
                    model.HomePage = ds.Tables[0].Rows[0]["HomePage"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ArtiPerson"] != null && ds.Tables[0].Rows[0]["ArtiPerson"].ToString() != "")
                {
                    model.ArtiPerson = ds.Tables[0].Rows[0]["ArtiPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EnteRank"] != null && ds.Tables[0].Rows[0]["EnteRank"].ToString() != "")
                {
                    model.EnteRank = int.Parse(ds.Tables[0].Rows[0]["EnteRank"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EnteClassID"] != null && ds.Tables[0].Rows[0]["EnteClassID"].ToString() != "")
                {
                    model.EnteClassID = int.Parse(ds.Tables[0].Rows[0]["EnteClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CompanyType"] != null && ds.Tables[0].Rows[0]["CompanyType"].ToString() != "")
                {
                    model.CompanyType = int.Parse(ds.Tables[0].Rows[0]["CompanyType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BusinessLicense"] != null && ds.Tables[0].Rows[0]["BusinessLicense"].ToString() != "")
                {
                    model.BusinessLicense = ds.Tables[0].Rows[0]["BusinessLicense"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TaxNumber"] != null && ds.Tables[0].Rows[0]["TaxNumber"].ToString() != "")
                {
                    model.TaxNumber = ds.Tables[0].Rows[0]["TaxNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AccountBank"] != null && ds.Tables[0].Rows[0]["AccountBank"].ToString() != "")
                {
                    model.AccountBank = ds.Tables[0].Rows[0]["AccountBank"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AccountInfo"] != null && ds.Tables[0].Rows[0]["AccountInfo"].ToString() != "")
                {
                    model.AccountInfo = ds.Tables[0].Rows[0]["AccountInfo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ServicePhone"] != null && ds.Tables[0].Rows[0]["ServicePhone"].ToString() != "")
                {
                    model.ServicePhone = ds.Tables[0].Rows[0]["ServicePhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QQ"] != null && ds.Tables[0].Rows[0]["QQ"].ToString() != "")
                {
                    model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MSN"] != null && ds.Tables[0].Rows[0]["MSN"].ToString() != "")
                {
                    model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserID"] != null && ds.Tables[0].Rows[0]["CreatedUserID"].ToString() != "")
                {
                    model.CreatedUserID = int.Parse(ds.Tables[0].Rows[0]["CreatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedDate"] != null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedUserID"] != null && ds.Tables[0].Rows[0]["UpdatedUserID"].ToString() != "")
                {
                    model.UpdatedUserID = int.Parse(ds.Tables[0].Rows[0]["UpdatedUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentID"] != null && ds.Tables[0].Rows[0]["AgentID"].ToString() != "")
                {
                    model.AgentID = int.Parse(ds.Tables[0].Rows[0]["AgentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedUserName"] != null && ds.Tables[0].Rows[0]["CreatedUserName"].ToString() != "")
                {
                    model.CreatedUserName = ds.Tables[0].Rows[0]["CreatedUserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdatedUserName"] != null && ds.Tables[0].Rows[0]["UpdatedUserName"].ToString() != "")
                {
                    model.UpdatedUserName = ds.Tables[0].Rows[0]["UpdatedUserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Balance"] != null && ds.Tables[0].Rows[0]["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(ds.Tables[0].Rows[0]["Balance"].ToString());
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
            strSql.Append("select EnterpriseID,Name,Introduction,RegisteredCapital,TelPhone,CellPhone,ContactMail,RegionID,Address,Remark,Contact,UserName,EstablishedDate,EstablishedCity,LOGO,Fax,PostCode,HomePage,ArtiPerson,EnteRank,EnteClassID,CompanyType,BusinessLicense,TaxNumber,AccountBank,AccountInfo,ServicePhone,QQ,MSN,Status,CreatedDate,CreatedUserID,UpdatedDate,UpdatedUserID,AgentID ");
            strSql.Append(" FROM Ms_Enterprise ");
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
            strSql.Append(" EnterpriseID,Name,Introduction,RegisteredCapital,TelPhone,CellPhone,ContactMail,RegionID,Address,Remark,Contact,UserName,EstablishedDate,EstablishedCity,LOGO,Fax,PostCode,HomePage,ArtiPerson,EnteRank,EnteClassID,CompanyType,BusinessLicense,TaxNumber,AccountBank,AccountInfo,ServicePhone,QQ,MSN,Status,CreatedDate,CreatedUserID,UpdatedDate,UpdatedUserID,AgentID ");
            strSql.Append(" FROM Ms_Enterprise ");
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
            strSql.Append("select count(1) FROM Ms_Enterprise ");
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
            //    strSql.Append(" order by T.EnterpriseID desc");
            //}
            //strSql.Append(")AS Row, T.*  from Ms_Enterprise T ");
            //if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*  from Ms_Enterprise T ");
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
                strSql.Append(" order by T.EnterpriseID desc");
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
            parameters[0].Value = "Ms_Enterprise";
            parameters[1].Value = "EnterpriseID";
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
        /// 批量处理状态
        /// </summary>
        /// <param name="IDlist"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_Enterprise set " + strWhere);
            strSql.Append(" where EnterpriseID in(" + IDlist + ")  ");
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

        #endregion MethodEx
    }
}