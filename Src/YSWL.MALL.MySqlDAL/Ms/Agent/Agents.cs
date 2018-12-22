/**
* Agents.cs
*
* 功 能： N/A
* 类 名： Agents
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/11/28 18:17:12   Ben    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Ms.Agent;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Ms.Agent
{
    /// <summary>
    /// 数据访问类:Agents
    /// </summary>
    public partial class Agents : IAgents
    {
        public Agents()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("AgentId", "Ms_Agents");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AgentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Agents");
            strSql.Append(" where AgentId=?AgentId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AgentId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = AgentId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.Agent.AgentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_Agents(");
            strSql.Append("Name,StoreName,StoreStatus,CategoryId,Rank,UserId,UserName,TelPhone,CellPhone,ContactMail,Introduction,RegisteredCapital,RegionId,Address,Contact,EstablishedDate,EstablishedCity,LOGO,Fax,PostCode,HomePage,ArtiPerson,CompanyType,BusinessLicense,TaxNumber,AccountBank,AccountInfo,ServicePhone,QQ,MSN,Status,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,ExpirationDate,Balance,IsUserApprove,IsAgenApprove,Recomend,Sequence,ThemeName,ParentId,Remark)");
            strSql.Append(" values (");
            strSql.Append("?Name,?StoreName,?StoreStatus,?CategoryId,?Rank,?UserId,?UserName,?TelPhone,?CellPhone,?ContactMail,?Introduction,?RegisteredCapital,?RegionId,?Address,?Contact,?EstablishedDate,?EstablishedCity,?LOGO,?Fax,?PostCode,?HomePage,?ArtiPerson,?CompanyType,?BusinessLicense,?TaxNumber,?AccountBank,?AccountInfo,?ServicePhone,?QQ,?MSN,?Status,?CreatedDate,?CreatedUserId,?UpdatedDate,?UpdatedUserId,?ExpirationDate,?Balance,?IsUserApprove,?IsAgenApprove,?Recomend,?Sequence,?ThemeName,?ParentId,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Name", MySqlDbType.VarChar,100),
                    new MySqlParameter("?StoreName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?StoreStatus", MySqlDbType.Int16,2),
                    new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Rank", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CellPhone", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ContactMail", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Introduction", MySqlDbType.VarChar,-1),
                    new MySqlParameter("?RegisteredCapital", MySqlDbType.Int32,4),
                    new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Address", MySqlDbType.VarChar,500),
                    new MySqlParameter("?Contact", MySqlDbType.VarChar,50),
                    new MySqlParameter("?EstablishedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?EstablishedCity", MySqlDbType.Int32,4),
                    new MySqlParameter("?LOGO", MySqlDbType.VarChar,300),
                    new MySqlParameter("?Fax", MySqlDbType.VarChar,30),
                    new MySqlParameter("?PostCode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?HomePage", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ArtiPerson", MySqlDbType.VarChar,50),
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
                    new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?UpdatedUserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ExpirationDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?IsUserApprove", MySqlDbType.Bit,1),
                    new MySqlParameter("?IsAgenApprove", MySqlDbType.Bit,1),
                    new MySqlParameter("?Recomend", MySqlDbType.Int16,2),
                    new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?ThemeName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,1000)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.StoreName;
            parameters[2].Value = model.StoreStatus;
            parameters[3].Value = model.CategoryId;
            parameters[4].Value = model.Rank;
            parameters[5].Value = model.UserId;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.TelPhone;
            parameters[8].Value = model.CellPhone;
            parameters[9].Value = model.ContactMail;
            parameters[10].Value = model.Introduction;
            parameters[11].Value = model.RegisteredCapital;
            parameters[12].Value = model.RegionId;
            parameters[13].Value = model.Address;
            parameters[14].Value = model.Contact;
            parameters[15].Value = model.EstablishedDate;
            parameters[16].Value = model.EstablishedCity;
            parameters[17].Value = model.LOGO;
            parameters[18].Value = model.Fax;
            parameters[19].Value = model.PostCode;
            parameters[20].Value = model.HomePage;
            parameters[21].Value = model.ArtiPerson;
            parameters[22].Value = model.CompanyType;
            parameters[23].Value = model.BusinessLicense;
            parameters[24].Value = model.TaxNumber;
            parameters[25].Value = model.AccountBank;
            parameters[26].Value = model.AccountInfo;
            parameters[27].Value = model.ServicePhone;
            parameters[28].Value = model.QQ;
            parameters[29].Value = model.MSN;
            parameters[30].Value = model.Status;
            parameters[31].Value = model.CreatedDate;
            parameters[32].Value = model.CreatedUserId;
            parameters[33].Value = model.UpdatedDate;
            parameters[34].Value = model.UpdatedUserId;
            parameters[35].Value = model.ExpirationDate;
            parameters[36].Value = model.Balance;
            parameters[37].Value = model.IsUserApprove;
            parameters[38].Value = model.IsAgenApprove;
            parameters[39].Value = model.Recomend;
            parameters[40].Value = model.Sequence;
            parameters[41].Value = model.ThemeName;
            parameters[42].Value = model.ParentId;
            parameters[43].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.Ms.Agent.AgentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_Agents set ");
            strSql.Append("Name=?Name,");
            strSql.Append("StoreName=?StoreName,");
            strSql.Append("StoreStatus=?StoreStatus,");
            strSql.Append("CategoryId=?CategoryId,");
            strSql.Append("Rank=?Rank,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("CellPhone=?CellPhone,");
            strSql.Append("ContactMail=?ContactMail,");
            strSql.Append("Introduction=?Introduction,");
            strSql.Append("RegisteredCapital=?RegisteredCapital,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("Address=?Address,");
            strSql.Append("Contact=?Contact,");
            strSql.Append("EstablishedDate=?EstablishedDate,");
            strSql.Append("EstablishedCity=?EstablishedCity,");
            strSql.Append("LOGO=?LOGO,");
            strSql.Append("Fax=?Fax,");
            strSql.Append("PostCode=?PostCode,");
            strSql.Append("HomePage=?HomePage,");
            strSql.Append("ArtiPerson=?ArtiPerson,");
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
            strSql.Append("CreatedUserId=?CreatedUserId,");
            strSql.Append("UpdatedDate=?UpdatedDate,");
            strSql.Append("UpdatedUserId=?UpdatedUserId,");
            strSql.Append("ExpirationDate=?ExpirationDate,");
            strSql.Append("Balance=?Balance,");
            strSql.Append("IsUserApprove=?IsUserApprove,");
            strSql.Append("IsAgenApprove=?IsAgenApprove,");
            strSql.Append("Recomend=?Recomend,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("ThemeName=?ThemeName,");
            strSql.Append("ParentId=?ParentId,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where AgentId=?AgentId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Name", MySqlDbType.VarChar,100),
                    new MySqlParameter("?StoreName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?StoreStatus", MySqlDbType.Int16,2),
                    new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Rank", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CellPhone", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ContactMail", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Introduction", MySqlDbType.VarChar,-1),
                    new MySqlParameter("?RegisteredCapital", MySqlDbType.Int32,4),
                    new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Address", MySqlDbType.VarChar,500),
                    new MySqlParameter("?Contact", MySqlDbType.VarChar,50),
                    new MySqlParameter("?EstablishedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?EstablishedCity", MySqlDbType.Int32,4),
                    new MySqlParameter("?LOGO", MySqlDbType.VarChar,300),
                    new MySqlParameter("?Fax", MySqlDbType.VarChar,30),
                    new MySqlParameter("?PostCode", MySqlDbType.VarChar,10),
                    new MySqlParameter("?HomePage", MySqlDbType.VarChar,50),
                    new MySqlParameter("?ArtiPerson", MySqlDbType.VarChar,50),
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
                    new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?UpdatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?UpdatedUserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?ExpirationDate", MySqlDbType.DateTime),
                    new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
                    new MySqlParameter("?IsUserApprove", MySqlDbType.Bit,1),
                    new MySqlParameter("?IsAgenApprove", MySqlDbType.Bit,1),
                    new MySqlParameter("?Recomend", MySqlDbType.Int16,2),
                    new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?ThemeName", MySqlDbType.VarChar,100),
                    new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,1000),
                    new MySqlParameter("?AgentId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.StoreName;
            parameters[2].Value = model.StoreStatus;
            parameters[3].Value = model.CategoryId;
            parameters[4].Value = model.Rank;
            parameters[5].Value = model.UserId;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.TelPhone;
            parameters[8].Value = model.CellPhone;
            parameters[9].Value = model.ContactMail;
            parameters[10].Value = model.Introduction;
            parameters[11].Value = model.RegisteredCapital;
            parameters[12].Value = model.RegionId;
            parameters[13].Value = model.Address;
            parameters[14].Value = model.Contact;
            parameters[15].Value = model.EstablishedDate;
            parameters[16].Value = model.EstablishedCity;
            parameters[17].Value = model.LOGO;
            parameters[18].Value = model.Fax;
            parameters[19].Value = model.PostCode;
            parameters[20].Value = model.HomePage;
            parameters[21].Value = model.ArtiPerson;
            parameters[22].Value = model.CompanyType;
            parameters[23].Value = model.BusinessLicense;
            parameters[24].Value = model.TaxNumber;
            parameters[25].Value = model.AccountBank;
            parameters[26].Value = model.AccountInfo;
            parameters[27].Value = model.ServicePhone;
            parameters[28].Value = model.QQ;
            parameters[29].Value = model.MSN;
            parameters[30].Value = model.Status;
            parameters[31].Value = model.CreatedDate;
            parameters[32].Value = model.CreatedUserId;
            parameters[33].Value = model.UpdatedDate;
            parameters[34].Value = model.UpdatedUserId;
            parameters[35].Value = model.ExpirationDate;
            parameters[36].Value = model.Balance;
            parameters[37].Value = model.IsUserApprove;
            parameters[38].Value = model.IsAgenApprove;
            parameters[39].Value = model.Recomend;
            parameters[40].Value = model.Sequence;
            parameters[41].Value = model.ThemeName;
            parameters[42].Value = model.ParentId;
            parameters[43].Value = model.Remark;
            parameters[44].Value = model.AgentId;

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
        public bool Delete(int AgentId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Agents ");
            strSql.Append(" where AgentId=?AgentId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AgentId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = AgentId;

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
        public bool DeleteList(string AgentIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Agents ");
            strSql.Append(" where AgentId in (" + AgentIdlist + ")  ");
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
        public YSWL.MALL.Model.Ms.Agent.AgentInfo GetModel(int AgentId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  AgentId,Name,StoreName,StoreStatus,CategoryId,Rank,UserId,UserName,TelPhone,CellPhone,ContactMail,Introduction,RegisteredCapital,RegionId,Address,Contact,EstablishedDate,EstablishedCity,LOGO,Fax,PostCode,HomePage,ArtiPerson,CompanyType,BusinessLicense,TaxNumber,AccountBank,AccountInfo,ServicePhone,QQ,MSN,Status,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,ExpirationDate,Balance,IsUserApprove,IsAgenApprove,Recomend,Sequence,ThemeName,ParentId,Remark from Ms_Agents ");
            strSql.Append(" where AgentId=?AgentId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AgentId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = AgentId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Ms.Agent.AgentInfo model = new YSWL.MALL.Model.Ms.Agent.AgentInfo();
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
        public YSWL.MALL.Model.Ms.Agent.AgentInfo DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Ms.Agent.AgentInfo model = new YSWL.MALL.Model.Ms.Agent.AgentInfo();
            if (row != null)
            {
                if (row["AgentId"] != null && row["AgentId"].ToString() != "")
                {
                    model.AgentId = int.Parse(row["AgentId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["StoreName"] != null)
                {
                    model.StoreName = row["StoreName"].ToString();
                }
                if (row["StoreStatus"] != null && row["StoreStatus"].ToString() != "")
                {
                    model.StoreStatus = int.Parse(row["StoreStatus"].ToString());
                }
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(row["CategoryId"].ToString());
                }
                if (row["Rank"] != null && row["Rank"].ToString() != "")
                {
                    model.Rank = int.Parse(row["Rank"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["TelPhone"] != null)
                {
                    model.TelPhone = row["TelPhone"].ToString();
                }
                if (row["CellPhone"] != null)
                {
                    model.CellPhone = row["CellPhone"].ToString();
                }
                if (row["ContactMail"] != null)
                {
                    model.ContactMail = row["ContactMail"].ToString();
                }
                if (row["Introduction"] != null)
                {
                    model.Introduction = row["Introduction"].ToString();
                }
                if (row["RegisteredCapital"] != null && row["RegisteredCapital"].ToString() != "")
                {
                    model.RegisteredCapital = int.Parse(row["RegisteredCapital"].ToString());
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Contact"] != null)
                {
                    model.Contact = row["Contact"].ToString();
                }
                if (row["EstablishedDate"] != null && row["EstablishedDate"].ToString() != "")
                {
                    model.EstablishedDate = DateTime.Parse(row["EstablishedDate"].ToString());
                }
                if (row["EstablishedCity"] != null && row["EstablishedCity"].ToString() != "")
                {
                    model.EstablishedCity = int.Parse(row["EstablishedCity"].ToString());
                }
                if (row["LOGO"] != null)
                {
                    model.LOGO = row["LOGO"].ToString();
                }
                if (row["Fax"] != null)
                {
                    model.Fax = row["Fax"].ToString();
                }
                if (row["PostCode"] != null)
                {
                    model.PostCode = row["PostCode"].ToString();
                }
                if (row["HomePage"] != null)
                {
                    model.HomePage = row["HomePage"].ToString();
                }
                if (row["ArtiPerson"] != null)
                {
                    model.ArtiPerson = row["ArtiPerson"].ToString();
                }
                if (row["CompanyType"] != null && row["CompanyType"].ToString() != "")
                {
                    model.CompanyType = int.Parse(row["CompanyType"].ToString());
                }
                if (row["BusinessLicense"] != null)
                {
                    model.BusinessLicense = row["BusinessLicense"].ToString();
                }
                if (row["TaxNumber"] != null)
                {
                    model.TaxNumber = row["TaxNumber"].ToString();
                }
                if (row["AccountBank"] != null)
                {
                    model.AccountBank = row["AccountBank"].ToString();
                }
                if (row["AccountInfo"] != null)
                {
                    model.AccountInfo = row["AccountInfo"].ToString();
                }
                if (row["ServicePhone"] != null)
                {
                    model.ServicePhone = row["ServicePhone"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["MSN"] != null)
                {
                    model.MSN = row["MSN"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["CreatedUserId"] != null && row["CreatedUserId"].ToString() != "")
                {
                    model.CreatedUserId = int.Parse(row["CreatedUserId"].ToString());
                }
                if (row["UpdatedDate"] != null && row["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(row["UpdatedDate"].ToString());
                }
                if (row["UpdatedUserId"] != null && row["UpdatedUserId"].ToString() != "")
                {
                    model.UpdatedUserId = int.Parse(row["UpdatedUserId"].ToString());
                }
                if (row["ExpirationDate"] != null && row["ExpirationDate"].ToString() != "")
                {
                    model.ExpirationDate = DateTime.Parse(row["ExpirationDate"].ToString());
                }
                if (row["Balance"] != null && row["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(row["Balance"].ToString());
                }
                if (row["IsUserApprove"] != null && row["IsUserApprove"].ToString() != "")
                {
                    if ((row["IsUserApprove"].ToString() == "1") || (row["IsUserApprove"].ToString().ToLower() == "true"))
                    {
                        model.IsUserApprove = true;
                    }
                    else
                    {
                        model.IsUserApprove = false;
                    }
                }
                if (row["IsAgenApprove"] != null && row["IsAgenApprove"].ToString() != "")
                {
                    if ((row["IsAgenApprove"].ToString() == "1") || (row["IsAgenApprove"].ToString().ToLower() == "true"))
                    {
                        model.IsAgenApprove = true;
                    }
                    else
                    {
                        model.IsAgenApprove = false;
                    }
                }
                if (row["Recomend"] != null && row["Recomend"].ToString() != "")
                {
                    model.Recomend = int.Parse(row["Recomend"].ToString());
                }
                if (row["Sequence"] != null && row["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(row["Sequence"].ToString());
                }
                if (row["ThemeName"] != null)
                {
                    model.ThemeName = row["ThemeName"].ToString();
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select AgentId,Name,StoreName,StoreStatus,CategoryId,Rank,UserId,UserName,TelPhone,CellPhone,ContactMail,Introduction,RegisteredCapital,RegionId,Address,Contact,EstablishedDate,EstablishedCity,LOGO,Fax,PostCode,HomePage,ArtiPerson,CompanyType,BusinessLicense,TaxNumber,AccountBank,AccountInfo,ServicePhone,QQ,MSN,Status,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,ExpirationDate,Balance,IsUserApprove,IsAgenApprove,Recomend,Sequence,ThemeName,ParentId,Remark ");
            strSql.Append(" FROM Ms_Agents ");
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
            
            strSql.Append(" AgentId,Name,StoreName,StoreStatus,CategoryId,Rank,UserId,UserName,TelPhone,CellPhone,ContactMail,Introduction,RegisteredCapital,RegionId,Address,Contact,EstablishedDate,EstablishedCity,LOGO,Fax,PostCode,HomePage,ArtiPerson,CompanyType,BusinessLicense,TaxNumber,AccountBank,AccountInfo,ServicePhone,QQ,MSN,Status,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,ExpirationDate,Balance,IsUserApprove,IsAgenApprove,Recomend,Sequence,ThemeName,ParentId,Remark ");
            strSql.Append(" FROM Ms_Agents ");
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
            strSql.Append("select count(1) FROM Ms_Agents ");
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
            strSql.Append("SELECT T.* from Ms_Agents T ");
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
                strSql.Append("order by T.AgentId desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Ms.Agent.AgentInfo GetModelByUserId(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Ms_Agents ");
            strSql.Append(" where UserId=?UserId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?UserId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = UserId;
            strSql.Append(" LIMIT 1 ");
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }
        /// <summary>
        /// 店铺名称是否已存在
        /// </summary>
        public bool ExistsShopName(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Agents");
            strSql.Append(" where StoreName=?StoreName");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?StoreName", MySqlDbType.VarChar,100)
            };
            parameters[0].Value = Name;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 店铺名称是否已存在
        /// </summary>
        public bool ExistsShopName(string Name, int AgentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Agents");
            strSql.Append(" where StoreName=?StoreName AND AgentID<>?AgentID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?StoreName", MySqlDbType.VarChar,100),
                     new MySqlParameter("?AgentID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = Name;
            parameters[1].Value = AgentID;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 批量处理状态
        /// </summary>
        /// <param name="IDlist"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_Agents set " + strWhere);
            strSql.Append(" where AgentID in(" + IDlist + ")  ");
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

//        public DataSet GetStatisticsSupply(int supplierId)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.AppendFormat(
//                @"
//--剩余总量/额
//SELECT 1 AS [Type], SUM(S.Stock) ToalQuantity
//      , SUM(S.SalePrice * S.Stock) ToalPrice
//FROM    Shop_SKUs S
//WHERE   EXISTS ( SELECT *, P.MarketPrice
//                 FROM   Shop_Products P
//                 WHERE  S.ProductId = P.ProductId
//                        AND P.SupplierId = {0} )
//UNION ALL      
//--已售量/额         
//SELECT  2 AS [Type], SUM(I.Quantity) ToalQuantity
//      , SUM(I.SellPrice * I.Quantity) ToalPrice
//FROM    Shop_OrderItems I, Shop_Orders O
//WHERE I.OrderId = O.OrderId AND O.SupplierId = {0} AND O.OrderStatus = 2 AND O.OrderType = 1
//", supplierId);
//            return DbHelperMySQL.Query(strSql.ToString());
//        }

//        public DataSet GetStatisticsSales(int supplierId, int year)
//        {

//            StringBuilder strSql = new StringBuilder();
//            strSql.Append(
//                @"
//--销量/业绩走势图
//SELECT  A.[Month] AS Mon
//      , CASE WHEN B.ToalQuantity IS NULL THEN 0
//             ELSE B.ToalQuantity
//        END AS ToalQuantity
//      , CASE WHEN B.ToalPrice IS NULL THEN 0.00
//             ELSE B.ToalPrice
//        END AS ToalPrice
//FROM    ( SELECT    *
//          FROM      GET_GeneratedMonthEx()
//        ) A
//        LEFT JOIN ( SELECT  MONTH(O.CreatedDate) Mon
//                          , SUM(I.Quantity) ToalQuantity
//                          , SUM(I.SellPrice) ToalPrice
//                    FROM    Shop_OrderItems I
//                          , Shop_Orders O
//                    WHERE   I.OrderId = O.OrderId ");
//            if (supplierId > 0)
//            {
//                strSql.AppendFormat("  AND O.SupplierId = {0}", supplierId);
//            }
//            strSql.AppendFormat(@" AND O.OrderStatus = 2 AND O.OrderType = 1
//                            AND YEAR(O.CreatedDate) = '{0}'
//                    GROUP BY MONTH(O.CreatedDate)
//                  ) B ON A.[Month] = B.Mon 
//", year);
//            return DbHelperMySQL.Query(strSql.ToString());
//        }
        /// <summary>
        /// 关闭店铺 
        /// </summary>
        public bool CloseShop(int AgentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_Agents set ");
            strSql.Append("StoreStatus=2");
            strSql.Append(" where SupplierId=?SupplierId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AgentID", MySqlDbType.Int32,4)};
            parameters[0].Value = AgentID;
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
        /// 根据店铺名称得到店铺model
        /// </summary>
        /// <param name="StoreName"></param>
        /// <returns></returns>
        public YSWL.MALL.Model.Ms.Agent.AgentInfo GetModelByShopName(string StoreName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Ms_Agents ");
            strSql.Append(" where StoreName=?StoreName and Status=1");
            strSql.Append(" LIMIT 1 ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?StoreName", MySqlDbType.VarChar,100)
            };
            parameters[0].Value = StoreName;
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
        /// 代理商名称是否已存在
        /// </summary>
        public bool Exists(string name, int id = 0)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Agents");
            strSql.Append(" where Name=?Name ");
            if (id > 0)
            {
                strSql.AppendFormat(" AND AgentId<>{0}", id);
            }
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Name", MySqlDbType.VarChar,100)
            };
            parameters[0].Value = name;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

