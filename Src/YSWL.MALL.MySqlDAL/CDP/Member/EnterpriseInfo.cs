/**  版本信息模板在安装目录下，可自行修改。
* enterpriseinfo.cs
*
* 功 能： N/A
* 类 名： enterpriseinfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/16 14:12:48   N/A    初版
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
using YSWL.IDAL.ERP.Enterprise;
using MySql.Data.MySqlClient;

using YSWL.DBUtility;
using System.Data.SqlClient;//Please add references
namespace YSWL.MySqlDAL.ERP.Enterprise
{
    /// <summary>
    /// 数据访问类:enterpriseinfo
    /// </summary>
    public partial class EnterpriseInfo : IEnterpriseInfo
    {
        public EnterpriseInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from enterpriseinfo");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.Model.ERP.Enterprise.EnterpriseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into enterpriseinfo(");
            strSql.Append("active,address,bankAccount,bankName,blAccount,blApproval,blCredit,blProxy,blSale,blStock,businessLicenseAlterdate,businessLicenseExpirydate,businessLicenseNo,businessLicenseScope,code,contactPerson,createTime,dutyNo,fax,grade,helpCode,lastVer,licenceExpirydate,mobile,name,payable,phone,postCode,powerOfAttorneyAlterdate,powerOfAttorneyExpirydate,qq,rate,receivable,region,remarks,saleCredit,saleCreditDayCount,salesman,stockCredit,stockCreditDayCount,kokura_id,prePayBalance,preReceiveBalance,region_id,lat,lng,blOther,businessScope,sal_Ent_Type_id,businessScopeDes,businessScopes,settlementType,position_id,salesman_id)");
            strSql.Append(" values (");
            strSql.Append("?active,?address,?bankAccount,?bankName,?blAccount,?blApproval,?blCredit,?blProxy,?blSale,?blStock,?businessLicenseAlterdate,?businessLicenseExpirydate,?businessLicenseNo,?businessLicenseScope,?code,?contactPerson,?createTime,?dutyNo,?fax,?grade,?helpCode,?lastVer,?licenceExpirydate,?mobile,?name,?payable,?phone,?postCode,?powerOfAttorneyAlterdate,?powerOfAttorneyExpirydate,?qq,?rate,?receivable,?region,?remarks,?saleCredit,?saleCreditDayCount,?salesman,?stockCredit,?stockCreditDayCount,?kokura_id,?prePayBalance,?preReceiveBalance,?region_id,?lat,?lng,?blOther,?businessScope,?sal_Ent_Type_id,?businessScopeDes,?businessScopes,?settlementType,?position_id,?salesman_id)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?address", MySqlDbType.VarChar,80),
					new MySqlParameter("?bankAccount", MySqlDbType.VarChar,60),
					new MySqlParameter("?bankName", MySqlDbType.VarChar,80),
					new MySqlParameter("?blAccount", MySqlDbType.Bit),
					new MySqlParameter("?blApproval", MySqlDbType.Bit),
					new MySqlParameter("?blCredit", MySqlDbType.Bit),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?blSale", MySqlDbType.Bit),
					new MySqlParameter("?blStock", MySqlDbType.Bit),
					new MySqlParameter("?businessLicenseAlterdate", MySqlDbType.DateTime),
					new MySqlParameter("?businessLicenseExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?businessLicenseNo", MySqlDbType.VarChar,60),
					new MySqlParameter("?businessLicenseScope", MySqlDbType.VarChar,200),
					new MySqlParameter("?code", MySqlDbType.VarChar,60),
					new MySqlParameter("?contactPerson", MySqlDbType.VarChar,30),
					new MySqlParameter("?createTime", MySqlDbType.DateTime),
					new MySqlParameter("?dutyNo", MySqlDbType.VarChar,60),
					new MySqlParameter("?fax", MySqlDbType.VarChar,30),
					new MySqlParameter("?grade", MySqlDbType.Int32,11),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?lastVer", MySqlDbType.DateTime),
					new MySqlParameter("?licenceExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,30),
					new MySqlParameter("?name", MySqlDbType.VarChar,80),
					new MySqlParameter("?payable", MySqlDbType.Double),
					new MySqlParameter("?phone", MySqlDbType.VarChar,60),
					new MySqlParameter("?postCode", MySqlDbType.VarChar,6),
					new MySqlParameter("?powerOfAttorneyAlterdate", MySqlDbType.DateTime),
					new MySqlParameter("?powerOfAttorneyExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?qq", MySqlDbType.VarChar,30),
					new MySqlParameter("?rate", MySqlDbType.Double),
					new MySqlParameter("?receivable", MySqlDbType.Double),
					new MySqlParameter("?region", MySqlDbType.VarChar,60),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					new MySqlParameter("?saleCredit", MySqlDbType.Double),
					new MySqlParameter("?saleCreditDayCount", MySqlDbType.Int32,11),
					new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					new MySqlParameter("?stockCredit", MySqlDbType.Double),
					new MySqlParameter("?stockCreditDayCount", MySqlDbType.Int32,11),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?prePayBalance", MySqlDbType.Double),
					new MySqlParameter("?preReceiveBalance", MySqlDbType.Double),
					new MySqlParameter("?region_id", MySqlDbType.Int64,20),
					new MySqlParameter("?lat", MySqlDbType.Double),
					new MySqlParameter("?lng", MySqlDbType.Double),
					new MySqlParameter("?blOther", MySqlDbType.Bit),
					new MySqlParameter("?businessScope", MySqlDbType.VarChar,150),
					new MySqlParameter("?sal_Ent_Type_id", MySqlDbType.Int64,20),
					new MySqlParameter("?businessScopeDes", MySqlDbType.VarChar,1000),
					new MySqlParameter("?businessScopes", MySqlDbType.VarChar,300),
					new MySqlParameter("?settlementType", MySqlDbType.Int32,11),
					new MySqlParameter("?position_id", MySqlDbType.Int64,20),
					new MySqlParameter("?salesman_id", MySqlDbType.Int64,20)};
            parameters[0].Value = model.active;
            parameters[1].Value = model.address;
            parameters[2].Value = model.bankAccount;
            parameters[3].Value = model.bankName;
            parameters[4].Value = model.blAccount;
            parameters[5].Value = model.blApproval;
            parameters[6].Value = model.blCredit;
            parameters[7].Value = model.blProxy;
            parameters[8].Value = model.blSale;
            parameters[9].Value = model.blStock;
            parameters[10].Value = model.businessLicenseAlterdate;
            parameters[11].Value = model.businessLicenseExpirydate;
            parameters[12].Value = model.businessLicenseNo;
            parameters[13].Value = model.businessLicenseScope;
            parameters[14].Value = model.code;
            parameters[15].Value = model.contactPerson;
            parameters[16].Value = model.createTime;
            parameters[17].Value = model.dutyNo;
            parameters[18].Value = model.fax;
            parameters[19].Value = model.grade;
            parameters[20].Value = model.helpCode;
            parameters[21].Value = model.lastVer;
            parameters[22].Value = model.licenceExpirydate;
            parameters[23].Value = model.mobile;
            parameters[24].Value = model.name;
            parameters[25].Value = model.payable;
            parameters[26].Value = model.phone;
            parameters[27].Value = model.postCode;
            parameters[28].Value = model.powerOfAttorneyAlterdate;
            parameters[29].Value = model.powerOfAttorneyExpirydate;
            parameters[30].Value = model.qq;
            parameters[31].Value = model.rate;
            parameters[32].Value = model.receivable;
            parameters[33].Value = model.region;
            parameters[34].Value = model.remarks;
            parameters[35].Value = model.saleCredit;
            parameters[36].Value = model.saleCreditDayCount;
            parameters[37].Value = model.salesman;
            parameters[38].Value = model.stockCredit;
            parameters[39].Value = model.stockCreditDayCount;
            parameters[40].Value = model.kokura_id;
            parameters[41].Value = model.prePayBalance;
            parameters[42].Value = model.preReceiveBalance;
            parameters[43].Value = model.region_id;
            parameters[44].Value = model.lat;
            parameters[45].Value = model.lng;
            parameters[46].Value = model.blOther;
            parameters[47].Value = model.businessScope;
            parameters[48].Value = model.sal_Ent_Type_id;
            parameters[49].Value = model.businessScopeDes;
            parameters[50].Value = model.businessScopes;
            parameters[51].Value = model.settlementType;
            parameters[52].Value = model.position_id;
            parameters[53].Value = model.salesman_id;

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
        public bool Update(YSWL.Model.ERP.Enterprise.EnterpriseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update enterpriseinfo set ");
            strSql.Append("active=?active,");
            strSql.Append("address=?address,");
            strSql.Append("bankAccount=?bankAccount,");
            strSql.Append("bankName=?bankName,");
            strSql.Append("blAccount=?blAccount,");
            strSql.Append("blApproval=?blApproval,");
            strSql.Append("blCredit=?blCredit,");
            strSql.Append("blProxy=?blProxy,");
            strSql.Append("blSale=?blSale,");
            strSql.Append("blStock=?blStock,");
            strSql.Append("businessLicenseAlterdate=?businessLicenseAlterdate,");
            strSql.Append("businessLicenseExpirydate=?businessLicenseExpirydate,");
            strSql.Append("businessLicenseNo=?businessLicenseNo,");
            strSql.Append("businessLicenseScope=?businessLicenseScope,");
            strSql.Append("code=?code,");
            strSql.Append("contactPerson=?contactPerson,");
            strSql.Append("createTime=?createTime,");
            strSql.Append("dutyNo=?dutyNo,");
            strSql.Append("fax=?fax,");
            strSql.Append("grade=?grade,");
            strSql.Append("helpCode=?helpCode,");
            strSql.Append("lastVer=?lastVer,");
            strSql.Append("licenceExpirydate=?licenceExpirydate,");
            strSql.Append("mobile=?mobile,");
            strSql.Append("name=?name,");
            strSql.Append("payable=?payable,");
            strSql.Append("phone=?phone,");
            strSql.Append("postCode=?postCode,");
            strSql.Append("powerOfAttorneyAlterdate=?powerOfAttorneyAlterdate,");
            strSql.Append("powerOfAttorneyExpirydate=?powerOfAttorneyExpirydate,");
            strSql.Append("qq=?qq,");
            strSql.Append("rate=?rate,");
            strSql.Append("receivable=?receivable,");
            strSql.Append("region=?region,");
            strSql.Append("remarks=?remarks,");
            strSql.Append("saleCredit=?saleCredit,");
            strSql.Append("saleCreditDayCount=?saleCreditDayCount,");
            strSql.Append("salesman=?salesman,");
            strSql.Append("stockCredit=?stockCredit,");
            strSql.Append("stockCreditDayCount=?stockCreditDayCount,");
            strSql.Append("kokura_id=?kokura_id,");
            strSql.Append("prePayBalance=?prePayBalance,");
            strSql.Append("preReceiveBalance=?preReceiveBalance,");
            strSql.Append("region_id=?region_id,");
            strSql.Append("lat=?lat,");
            strSql.Append("lng=?lng,");
            strSql.Append("blOther=?blOther,");
            strSql.Append("businessScope=?businessScope,");
            strSql.Append("sal_Ent_Type_id=?sal_Ent_Type_id,");
            strSql.Append("businessScopeDes=?businessScopeDes,");
            strSql.Append("businessScopes=?businessScopes,");
            strSql.Append("settlementType=?settlementType,");
            strSql.Append("position_id=?position_id,");
            strSql.Append("salesman_id=?salesman_id");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?address", MySqlDbType.VarChar,80),
					new MySqlParameter("?bankAccount", MySqlDbType.VarChar,60),
					new MySqlParameter("?bankName", MySqlDbType.VarChar,80),
					new MySqlParameter("?blAccount", MySqlDbType.Bit),
					new MySqlParameter("?blApproval", MySqlDbType.Bit),
					new MySqlParameter("?blCredit", MySqlDbType.Bit),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?blSale", MySqlDbType.Bit),
					new MySqlParameter("?blStock", MySqlDbType.Bit),
					new MySqlParameter("?businessLicenseAlterdate", MySqlDbType.DateTime),
					new MySqlParameter("?businessLicenseExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?businessLicenseNo", MySqlDbType.VarChar,60),
					new MySqlParameter("?businessLicenseScope", MySqlDbType.VarChar,200),
					new MySqlParameter("?code", MySqlDbType.VarChar,60),
					new MySqlParameter("?contactPerson", MySqlDbType.VarChar,30),
					new MySqlParameter("?createTime", MySqlDbType.DateTime),
					new MySqlParameter("?dutyNo", MySqlDbType.VarChar,60),
					new MySqlParameter("?fax", MySqlDbType.VarChar,30),
					new MySqlParameter("?grade", MySqlDbType.Int32,11),
					new MySqlParameter("?helpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?lastVer", MySqlDbType.DateTime),
					new MySqlParameter("?licenceExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,30),
					new MySqlParameter("?name", MySqlDbType.VarChar,80),
					new MySqlParameter("?payable", MySqlDbType.Double),
					new MySqlParameter("?phone", MySqlDbType.VarChar,60),
					new MySqlParameter("?postCode", MySqlDbType.VarChar,6),
					new MySqlParameter("?powerOfAttorneyAlterdate", MySqlDbType.DateTime),
					new MySqlParameter("?powerOfAttorneyExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?qq", MySqlDbType.VarChar,30),
					new MySqlParameter("?rate", MySqlDbType.Double),
					new MySqlParameter("?receivable", MySqlDbType.Double),
					new MySqlParameter("?region", MySqlDbType.VarChar,60),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					new MySqlParameter("?saleCredit", MySqlDbType.Double),
					new MySqlParameter("?saleCreditDayCount", MySqlDbType.Int32,11),
					new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					new MySqlParameter("?stockCredit", MySqlDbType.Double),
					new MySqlParameter("?stockCreditDayCount", MySqlDbType.Int32,11),
					new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					new MySqlParameter("?prePayBalance", MySqlDbType.Double),
					new MySqlParameter("?preReceiveBalance", MySqlDbType.Double),
					new MySqlParameter("?region_id", MySqlDbType.Int64,20),
					new MySqlParameter("?lat", MySqlDbType.Double),
					new MySqlParameter("?lng", MySqlDbType.Double),
					new MySqlParameter("?blOther", MySqlDbType.Bit),
					new MySqlParameter("?businessScope", MySqlDbType.VarChar,150),
					new MySqlParameter("?sal_Ent_Type_id", MySqlDbType.Int64,20),
					new MySqlParameter("?businessScopeDes", MySqlDbType.VarChar,1000),
					new MySqlParameter("?businessScopes", MySqlDbType.VarChar,300),
					new MySqlParameter("?settlementType", MySqlDbType.Int32,11),
					new MySqlParameter("?position_id", MySqlDbType.Int64,20),
					new MySqlParameter("?salesman_id", MySqlDbType.Int64,20),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
            parameters[0].Value = model.active;
            parameters[1].Value = model.address;
            parameters[2].Value = model.bankAccount;
            parameters[3].Value = model.bankName;
            parameters[4].Value = model.blAccount;
            parameters[5].Value = model.blApproval;
            parameters[6].Value = model.blCredit;
            parameters[7].Value = model.blProxy;
            parameters[8].Value = model.blSale;
            parameters[9].Value = model.blStock;
            parameters[10].Value = model.businessLicenseAlterdate;
            parameters[11].Value = model.businessLicenseExpirydate;
            parameters[12].Value = model.businessLicenseNo;
            parameters[13].Value = model.businessLicenseScope;
            parameters[14].Value = model.code;
            parameters[15].Value = model.contactPerson;
            parameters[16].Value = model.createTime;
            parameters[17].Value = model.dutyNo;
            parameters[18].Value = model.fax;
            parameters[19].Value = model.grade;
            parameters[20].Value = model.helpCode;
            parameters[21].Value = model.lastVer;
            parameters[22].Value = model.licenceExpirydate;
            parameters[23].Value = model.mobile;
            parameters[24].Value = model.name;
            parameters[25].Value = model.payable;
            parameters[26].Value = model.phone;
            parameters[27].Value = model.postCode;
            parameters[28].Value = model.powerOfAttorneyAlterdate;
            parameters[29].Value = model.powerOfAttorneyExpirydate;
            parameters[30].Value = model.qq;
            parameters[31].Value = model.rate;
            parameters[32].Value = model.receivable;
            parameters[33].Value = model.region;
            parameters[34].Value = model.remarks;
            parameters[35].Value = model.saleCredit;
            parameters[36].Value = model.saleCreditDayCount;
            parameters[37].Value = model.salesman;
            parameters[38].Value = model.stockCredit;
            parameters[39].Value = model.stockCreditDayCount;
            parameters[40].Value = model.kokura_id;
            parameters[41].Value = model.prePayBalance;
            parameters[42].Value = model.preReceiveBalance;
            parameters[43].Value = model.region_id;
            parameters[44].Value = model.lat;
            parameters[45].Value = model.lng;
            parameters[46].Value = model.blOther;
            parameters[47].Value = model.businessScope;
            parameters[48].Value = model.sal_Ent_Type_id;
            parameters[49].Value = model.businessScopeDes;
            parameters[50].Value = model.businessScopes;
            parameters[51].Value = model.settlementType;
            parameters[52].Value = model.position_id;
            parameters[53].Value = model.salesman_id;
            parameters[54].Value = model.id;

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
        public bool Delete(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from enterpriseinfo ");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from enterpriseinfo ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public YSWL.Model.ERP.Enterprise.EnterpriseInfo GetModel(long id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,active,address,bankAccount,bankName,blAccount,blApproval,blCredit,blProxy,blSale,blStock,businessLicenseAlterdate,businessLicenseExpirydate,businessLicenseNo,businessLicenseScope,code,contactPerson,createTime,dutyNo,fax,grade,helpCode,lastVer,licenceExpirydate,mobile,name,payable,phone,postCode,powerOfAttorneyAlterdate,powerOfAttorneyExpirydate,qq,rate,receivable,region,remarks,saleCredit,saleCreditDayCount,salesman,stockCredit,stockCreditDayCount,kokura_id,prePayBalance,preReceiveBalance,region_id,lat,lng,blOther,businessScope,sal_Ent_Type_id,businessScopeDes,businessScopes,settlementType,position_id,salesman_id from enterpriseinfo ");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int64)
			};
            parameters[0].Value = id;

            YSWL.Model.ERP.Enterprise.EnterpriseInfo model = new YSWL.Model.ERP.Enterprise.EnterpriseInfo();
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
        public YSWL.Model.ERP.Enterprise.EnterpriseInfo DataRowToModel(DataRow row)
        {
            YSWL.Model.ERP.Enterprise.EnterpriseInfo model = new YSWL.Model.ERP.Enterprise.EnterpriseInfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = long.Parse(row["id"].ToString());
                }
                if (row["active"] != null && row["active"].ToString() != "")
                {
                    if ((row["active"].ToString() == "1") || (row["active"].ToString().ToLower() == "true"))
                    {
                        model.active = true;
                    }
                    else
                    {
                        model.active = false;
                    }
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["bankAccount"] != null)
                {
                    model.bankAccount = row["bankAccount"].ToString();
                }
                if (row["bankName"] != null)
                {
                    model.bankName = row["bankName"].ToString();
                }
                if (row["blAccount"] != null && row["blAccount"].ToString() != "")
                {
                    if ((row["blAccount"].ToString() == "1") || (row["blAccount"].ToString().ToLower() == "true"))
                    {
                        model.blAccount = true;
                    }
                    else
                    {
                        model.blAccount = false;
                    }
                }
                if (row["blApproval"] != null && row["blApproval"].ToString() != "")
                {
                    if ((row["blApproval"].ToString() == "1") || (row["blApproval"].ToString().ToLower() == "true"))
                    {
                        model.blApproval = true;
                    }
                    else
                    {
                        model.blApproval = false;
                    }
                }
                if (row["blCredit"] != null && row["blCredit"].ToString() != "")
                {
                    if ((row["blCredit"].ToString() == "1") || (row["blCredit"].ToString().ToLower() == "true"))
                    {
                        model.blCredit = true;
                    }
                    else
                    {
                        model.blCredit = false;
                    }
                }
                if (row["blProxy"] != null && row["blProxy"].ToString() != "")
                {
                    if ((row["blProxy"].ToString() == "1") || (row["blProxy"].ToString().ToLower() == "true"))
                    {
                        model.blProxy = true;
                    }
                    else
                    {
                        model.blProxy = false;
                    }
                }
                if (row["blSale"] != null && row["blSale"].ToString() != "")
                {
                    if ((row["blSale"].ToString() == "1") || (row["blSale"].ToString().ToLower() == "true"))
                    {
                        model.blSale = true;
                    }
                    else
                    {
                        model.blSale = false;
                    }
                }
                if (row["blStock"] != null && row["blStock"].ToString() != "")
                {
                    if ((row["blStock"].ToString() == "1") || (row["blStock"].ToString().ToLower() == "true"))
                    {
                        model.blStock = true;
                    }
                    else
                    {
                        model.blStock = false;
                    }
                }
                if (row["businessLicenseAlterdate"] != null && row["businessLicenseAlterdate"].ToString() != "")
                {
                    model.businessLicenseAlterdate = DateTime.Parse(row["businessLicenseAlterdate"].ToString());
                }
                if (row["businessLicenseExpirydate"] != null && row["businessLicenseExpirydate"].ToString() != "")
                {
                    model.businessLicenseExpirydate = DateTime.Parse(row["businessLicenseExpirydate"].ToString());
                }
                if (row["businessLicenseNo"] != null)
                {
                    model.businessLicenseNo = row["businessLicenseNo"].ToString();
                }
                if (row["businessLicenseScope"] != null)
                {
                    model.businessLicenseScope = row["businessLicenseScope"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["contactPerson"] != null)
                {
                    model.contactPerson = row["contactPerson"].ToString();
                }
                if (row["createTime"] != null && row["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(row["createTime"].ToString());
                }
                if (row["dutyNo"] != null)
                {
                    model.dutyNo = row["dutyNo"].ToString();
                }
                if (row["fax"] != null)
                {
                    model.fax = row["fax"].ToString();
                }
                if (row["grade"] != null && row["grade"].ToString() != "")
                {
                    model.grade = int.Parse(row["grade"].ToString());
                }
                if (row["helpCode"] != null)
                {
                    model.helpCode = row["helpCode"].ToString();
                }
                if (row["lastVer"] != null && row["lastVer"].ToString() != "")
                {
                    model.lastVer = DateTime.Parse(row["lastVer"].ToString());
                }
                if (row["licenceExpirydate"] != null && row["licenceExpirydate"].ToString() != "")
                {
                    model.licenceExpirydate = DateTime.Parse(row["licenceExpirydate"].ToString());
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                //model.payable=row["payable"].ToString();
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["postCode"] != null)
                {
                    model.postCode = row["postCode"].ToString();
                }
                if (row["powerOfAttorneyAlterdate"] != null && row["powerOfAttorneyAlterdate"].ToString() != "")
                {
                    model.powerOfAttorneyAlterdate = DateTime.Parse(row["powerOfAttorneyAlterdate"].ToString());
                }
                if (row["powerOfAttorneyExpirydate"] != null && row["powerOfAttorneyExpirydate"].ToString() != "")
                {
                    model.powerOfAttorneyExpirydate = DateTime.Parse(row["powerOfAttorneyExpirydate"].ToString());
                }
                if (row["qq"] != null)
                {
                    model.qq = row["qq"].ToString();
                }
                //model.rate=row["rate"].ToString();
                //model.receivable=row["receivable"].ToString();
                if (row["region"] != null)
                {
                    model.region = row["region"].ToString();
                }
                if (row["remarks"] != null)
                {
                    model.remarks = row["remarks"].ToString();
                }
                //model.saleCredit=row["saleCredit"].ToString();
                if (row["saleCreditDayCount"] != null && row["saleCreditDayCount"].ToString() != "")
                {
                    model.saleCreditDayCount = int.Parse(row["saleCreditDayCount"].ToString());
                }
                if (row["salesman"] != null)
                {
                    model.salesman = row["salesman"].ToString();
                }
                //model.stockCredit=row["stockCredit"].ToString();
                if (row["stockCreditDayCount"] != null && row["stockCreditDayCount"].ToString() != "")
                {
                    model.stockCreditDayCount = int.Parse(row["stockCreditDayCount"].ToString());
                }
                if (row["kokura_id"] != null && row["kokura_id"].ToString() != "")
                {
                    model.kokura_id = long.Parse(row["kokura_id"].ToString());
                }
                //model.prePayBalance=row["prePayBalance"].ToString();
                //model.preReceiveBalance=row["preReceiveBalance"].ToString();
                if (row["region_id"] != null && row["region_id"].ToString() != "")
                {
                    model.region_id = long.Parse(row["region_id"].ToString());
                }
                //model.lat=row["lat"].ToString();
                //model.lng=row["lng"].ToString();
                if (row["blOther"] != null && row["blOther"].ToString() != "")
                {
                    if ((row["blOther"].ToString() == "1") || (row["blOther"].ToString().ToLower() == "true"))
                    {
                        model.blOther = true;
                    }
                    else
                    {
                        model.blOther = false;
                    }
                }
                if (row["businessScope"] != null)
                {
                    model.businessScope = row["businessScope"].ToString();
                }
                if (row["sal_Ent_Type_id"] != null && row["sal_Ent_Type_id"].ToString() != "")
                {
                    model.sal_Ent_Type_id = long.Parse(row["sal_Ent_Type_id"].ToString());
                }
                if (row["businessScopeDes"] != null)
                {
                    model.businessScopeDes = row["businessScopeDes"].ToString();
                }
                if (row["businessScopes"] != null)
                {
                    model.businessScopes = row["businessScopes"].ToString();
                }
                if (row["settlementType"] != null && row["settlementType"].ToString() != "")
                {
                    model.settlementType = int.Parse(row["settlementType"].ToString());
                }
                if (row["position_id"] != null && row["position_id"].ToString() != "")
                {
                    model.position_id = long.Parse(row["position_id"].ToString());
                }
                if (row["salesman_id"] != null && row["salesman_id"].ToString() != "")
                {
                    model.salesman_id = long.Parse(row["salesman_id"].ToString());
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
            strSql.Append("select id,active,address,bankAccount,bankName,blAccount,blApproval,blCredit,blProxy,blSale,blStock,businessLicenseAlterdate,businessLicenseExpirydate,businessLicenseNo,businessLicenseScope,code,contactPerson,createTime,dutyNo,fax,grade,helpCode,lastVer,licenceExpirydate,mobile,name,payable,phone,postCode,powerOfAttorneyAlterdate,powerOfAttorneyExpirydate,qq,rate,receivable,region,remarks,saleCredit,saleCreditDayCount,salesman,stockCredit,stockCreditDayCount,kokura_id,prePayBalance,preReceiveBalance,region_id,lat,lng,blOther,businessScope,sal_Ent_Type_id,businessScopeDes,businessScopes,settlementType,position_id,salesman_id ");
            strSql.Append(" FROM enterpriseinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM enterpriseinfo ");
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
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from enterpriseinfo T ");
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
            parameters[0].Value = "enterpriseinfo";
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
        /// 增加一条商城的同步数据
        /// </summary>
        public bool AddEnterprise(YSWL.Model.ERP.Enterprise.EnterpriseInfo model)
        {
            using (MySqlConnection connection = DbHelperMySQL.GetConnection)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string str1 = "update docmaxbh set ordinal=ordinal+1 where typeCode='ENT'";
                        DbHelperMySQL.GetSingle4Trans(new CommandInfo(str1, null), transaction);
                        string str2 = "select ordinal from docmaxbh where typeCode='ENT'";
                        object objCode = DbHelperMySQL.GetSingle4Trans(new CommandInfo(str2, null), transaction);
                        if (objCode == null)
                        {
                            return false;
                        }
                        long code = Common.Globals.SafeLong(objCode.ToString(), 0);
                        if (code <= 0)
                        {
                            return false;
                        }
                        string strCode = "BJ" + code.ToString().PadLeft(11, '0');//BJ01010312470

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into enterpriseinfo(");
                        strSql.Append("active,address,bankAccount,bankName,blAccount,blApproval,blCredit,blProxy,blSale,blStock,businessLicenseNo,businessLicenseScope,code,contactPerson,createTime,dutyNo,fax,lastVer,mobile,name,payable,phone,receivable,remarks,salesman,preReceiveBalance,blOther,businessScopeDes,businessScopes,settlementType,kokura_id)");
                        strSql.Append(" values (");
                        strSql.Append("?active,?address,?bankAccount,?bankName,?blAccount,?blApproval,?blCredit,?blProxy,?blSale,?blStock,?businessLicenseNo,?businessLicenseScope,?code,?contactPerson,?createTime,?dutyNo,?fax,?lastVer,?mobile,?name,?payable,?phone,?receivable,?remarks,?salesman,?preReceiveBalance,?blOther,?businessScopeDes,?businessScopes,?settlementType,51)");
                        MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?address", MySqlDbType.VarChar,80),
					new MySqlParameter("?bankAccount", MySqlDbType.VarChar,60),
					new MySqlParameter("?bankName", MySqlDbType.VarChar,80),
					new MySqlParameter("?blAccount", MySqlDbType.Bit),
					new MySqlParameter("?blApproval", MySqlDbType.Bit),
					new MySqlParameter("?blCredit", MySqlDbType.Bit),
					new MySqlParameter("?blProxy", MySqlDbType.Bit),
					new MySqlParameter("?blSale", MySqlDbType.Bit),
					new MySqlParameter("?blStock", MySqlDbType.Bit),
					//new MySqlParameter("?businessLicenseAlterdate", MySqlDbType.DateTime),
					//new MySqlParameter("?businessLicenseExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?businessLicenseNo", MySqlDbType.VarChar,60),
					new MySqlParameter("?businessLicenseScope", MySqlDbType.VarChar,200),
					new MySqlParameter("?code", MySqlDbType.VarChar,60),
					new MySqlParameter("?contactPerson", MySqlDbType.VarChar,30),
					new MySqlParameter("?createTime", MySqlDbType.DateTime),
					new MySqlParameter("?dutyNo", MySqlDbType.VarChar,60),
					new MySqlParameter("?fax", MySqlDbType.VarChar,30),
					//new MySqlParameter("?grade", MySqlDbType.Int32,11),
					//new MySqlParameter("?helpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?lastVer", MySqlDbType.DateTime),
					//new MySqlParameter("?licenceExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,30),
					new MySqlParameter("?name", MySqlDbType.VarChar,80),
					new MySqlParameter("?payable", MySqlDbType.Double),
					new MySqlParameter("?phone", MySqlDbType.VarChar,60),
					//new MySqlParameter("?postCode", MySqlDbType.VarChar,6),
					//new MySqlParameter("?powerOfAttorneyAlterdate", MySqlDbType.DateTime),
					//new MySqlParameter("?powerOfAttorneyExpirydate", MySqlDbType.DateTime),
					//new MySqlParameter("?qq", MySqlDbType.VarChar,30),
					//new MySqlParameter("?rate", MySqlDbType.Double),
					new MySqlParameter("?receivable", MySqlDbType.Double),
					//new MySqlParameter("?region", MySqlDbType.VarChar,60),
					new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					//new MySqlParameter("?saleCredit", MySqlDbType.Double),
					//new MySqlParameter("?saleCreditDayCount", MySqlDbType.Int32,11),
					new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					//new MySqlParameter("?stockCredit", MySqlDbType.Double),
					//new MySqlParameter("?stockCreditDayCount", MySqlDbType.Int32,11),
					//new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					//new MySqlParameter("?prePayBalance", MySqlDbType.Double),
					new MySqlParameter("?preReceiveBalance", MySqlDbType.Double),
					//new MySqlParameter("?region_id", MySqlDbType.Int64,20),
					//new MySqlParameter("?lat", MySqlDbType.Double),
					//new MySqlParameter("?lng", MySqlDbType.Double),
					new MySqlParameter("?blOther", MySqlDbType.Bit),
					//new MySqlParameter("?businessScope", MySqlDbType.VarChar,150),
					//new MySqlParameter("?sal_Ent_Type_id", MySqlDbType.Int64,20),
					new MySqlParameter("?businessScopeDes", MySqlDbType.VarChar,1000),
					new MySqlParameter("?businessScopes", MySqlDbType.VarChar,300),
					new MySqlParameter("?settlementType", MySqlDbType.Int32,11)
                    //new MySqlParameter("?position_id", MySqlDbType.Int64,20),
					//new MySqlParameter("?salesman_id", MySqlDbType.Int64,20)
                                          };
                        parameters[0].Value = model.active;
                        parameters[1].Value = model.address;
                        parameters[2].Value = model.bankAccount;
                        parameters[3].Value = model.bankName;
                        parameters[4].Value = model.blAccount;
                        parameters[5].Value = model.blApproval;
                        parameters[6].Value = model.blCredit;
                        parameters[7].Value = model.blProxy;
                        parameters[8].Value = model.blSale;
                        parameters[9].Value = model.blStock;
                        //parameters[10].Value = model.businessLicenseAlterdate;
                        //parameters[11].Value = model.businessLicenseExpirydate;
                        parameters[10].Value = model.businessLicenseNo;
                        parameters[11].Value = model.businessLicenseScope;
                        parameters[12].Value = strCode;//01010312470
                        parameters[13].Value = model.contactPerson;
                        parameters[14].Value = model.createTime;
                        parameters[15].Value = model.dutyNo;
                        parameters[16].Value = model.fax;
                        //parameters[19].Value = model.grade;
                        //parameters[17].Value = model.helpCode;
                        parameters[17].Value = model.lastVer;
                        //parameters[22].Value = model.licenceExpirydate;
                        parameters[18].Value = model.mobile;
                        parameters[19].Value = model.name;
                        parameters[20].Value = model.payable;
                        parameters[21].Value = model.phone;
                        //parameters[27].Value = model.postCode;
                        //parameters[28].Value = model.powerOfAttorneyAlterdate;
                        //parameters[29].Value = model.powerOfAttorneyExpirydate;
                        //parameters[23].Value = model.qq;
                        //parameters[31].Value = model.rate;
                        parameters[22].Value = model.receivable;
                        //parameters[33].Value = model.region;
                        parameters[23].Value = model.remarks;
                        //parameters[35].Value = model.saleCredit;
                        //parameters[36].Value = model.saleCreditDayCount;
                        parameters[24].Value = model.salesman;
                        //parameters[38].Value = model.stockCredit;
                        //parameters[39].Value = model.stockCreditDayCount;
                        //parameters[40].Value = model.kokura_id;
                        //parameters[41].Value = model.prePayBalance;
                        parameters[25].Value = model.preReceiveBalance;
                        //parameters[28].Value = model.region_id;
                        //parameters[44].Value = model.lat;
                        //parameters[45].Value = model.lng;
                        parameters[26].Value = model.blOther;
                        //parameters[47].Value = model.businessScope;
                        //parameters[48].Value = model.sal_Ent_Type_id;
                        parameters[27].Value = model.businessScopeDes;
                        parameters[28].Value = model.businessScopes;
                        parameters[29].Value = model.settlementType;
                        //parameters[33].Value = model.position_id;
                        //parameters[53].Value = model.salesman_id;
                        CommandInfo cmdinfo = new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
                        DbHelperMySQL.GetSingle4Trans(cmdinfo, transaction);
                        transaction.Commit();
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();

                        throw;
                    }
                }
            }
            return true;

        }

        /// <summary>
        /// 更新一条商城的同步数据
        /// </summary>
        /// <param name="enterModel"></param>
        /// <returns></returns>
        public bool UpdateEnterprise(YSWL.Model.ERP.Enterprise.EnterpriseInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update enterpriseinfo set ");
            strSql.Append("active=?active,");
            strSql.Append("address=?address,");
            //strSql.Append("bankAccount=?bankAccount,");
            //strSql.Append("bankName=?bankName,");
            //strSql.Append("blAccount=?blAccount,");
            //strSql.Append("blApproval=?blApproval,");
            //strSql.Append("blCredit=?blCredit,");
            //strSql.Append("blProxy=?blProxy,");
            //strSql.Append("blSale=?blSale,");
            //strSql.Append("blStock=?blStock,");
            //strSql.Append("businessLicenseAlterdate=?businessLicenseAlterdate,");
            //strSql.Append("businessLicenseExpirydate=?businessLicenseExpirydate,");
            //strSql.Append("businessLicenseNo=?businessLicenseNo,");
            //strSql.Append("businessLicenseScope=?businessLicenseScope,");
            //strSql.Append("code=?code,");
            strSql.Append("contactPerson=?contactPerson,");
            //strSql.Append("createTime=?createTime,");
            //strSql.Append("dutyNo=?dutyNo,");
            strSql.Append("fax=?fax,");
            //strSql.Append("grade=?grade,");
            //strSql.Append("helpCode=?helpCode,");
            strSql.Append("lastVer=?lastVer,");
            //strSql.Append("licenceExpirydate=?licenceExpirydate,");
            strSql.Append("mobile=?mobile,");
            strSql.Append("name=?name,");
            //strSql.Append("payable=?payable,");
            strSql.Append("phone=?phone");//"注意结尾‘,’"
            //strSql.Append("postCode=?postCode,");
            //strSql.Append("powerOfAttorneyAlterdate=?powerOfAttorneyAlterdate,");
            //strSql.Append("powerOfAttorneyExpirydate=?powerOfAttorneyExpirydate,");
            //strSql.Append("qq=?qq,");
            //strSql.Append("rate=?rate,");
            //strSql.Append("receivable=?receivable,");
            //strSql.Append("region=?region,");
            //strSql.Append("remarks=?remarks,");
            //strSql.Append("saleCredit=?saleCredit,");
            //strSql.Append("saleCreditDayCount=?saleCreditDayCount,");
            //strSql.Append("salesman=?salesman,");
            //strSql.Append("stockCredit=?stockCredit,");
            //strSql.Append("stockCreditDayCount=?stockCreditDayCount,");
            //strSql.Append("kokura_id=?kokura_id,");
            //strSql.Append("prePayBalance=?prePayBalance,");
            //strSql.Append("preReceiveBalance=?preReceiveBalance,");
            //strSql.Append("region_id=?region_id,");
            //strSql.Append("lat=?lat,");
            //strSql.Append("lng=?lng,");
            //strSql.Append("blOther=?blOther,");
            //strSql.Append("businessScope=?businessScope,");
            //strSql.Append("sal_Ent_Type_id=?sal_Ent_Type_id,");
            //strSql.Append("businessScopeDes=?businessScopeDes,");
            //strSql.Append("businessScopes=?businessScopes,");
            //strSql.Append("settlementType=?settlementType,");
            //strSql.Append("position_id=?position_id,");
            //strSql.Append("salesman_id=?salesman_id");
            strSql.Append(" where id=?id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?active", MySqlDbType.Bit),
					new MySqlParameter("?address", MySqlDbType.VarChar,80),
                    //new MySqlParameter("?bankAccount", MySqlDbType.VarChar,60),
                    //new MySqlParameter("?bankName", MySqlDbType.VarChar,80),
                    //new MySqlParameter("?blAccount", MySqlDbType.Bit),
                    //new MySqlParameter("?blApproval", MySqlDbType.Bit),
                    //new MySqlParameter("?blCredit", MySqlDbType.Bit),
                    //new MySqlParameter("?blProxy", MySqlDbType.Bit),
                    //new MySqlParameter("?blSale", MySqlDbType.Bit),
                    //new MySqlParameter("?blStock", MySqlDbType.Bit),
					//new MySqlParameter("?businessLicenseAlterdate", MySqlDbType.DateTime),
					//new MySqlParameter("?businessLicenseExpirydate", MySqlDbType.DateTime),
                    //new MySqlParameter("?businessLicenseNo", MySqlDbType.VarChar,60),
                    //new MySqlParameter("?businessLicenseScope", MySqlDbType.VarChar,200),
                    //new MySqlParameter("?code", MySqlDbType.VarChar,60),
					new MySqlParameter("?contactPerson", MySqlDbType.VarChar,30),
                    //new MySqlParameter("?createTime", MySqlDbType.DateTime),
                    //new MySqlParameter("?dutyNo", MySqlDbType.VarChar,60),
                    new MySqlParameter("?fax", MySqlDbType.VarChar,30),
					//new MySqlParameter("?grade", MySqlDbType.Int32,11),
					//new MySqlParameter("?helpCode", MySqlDbType.VarChar,80),
					new MySqlParameter("?lastVer", MySqlDbType.DateTime),
					//new MySqlParameter("?licenceExpirydate", MySqlDbType.DateTime),
					new MySqlParameter("?mobile", MySqlDbType.VarChar,30),
					new MySqlParameter("?name", MySqlDbType.VarChar,80),
					//new MySqlParameter("?payable", MySqlDbType.Double),
					new MySqlParameter("?phone", MySqlDbType.VarChar,60),
					//new MySqlParameter("?postCode", MySqlDbType.VarChar,6),
					//new MySqlParameter("?powerOfAttorneyAlterdate", MySqlDbType.DateTime),
					//new MySqlParameter("?powerOfAttorneyExpirydate", MySqlDbType.DateTime),
					//new MySqlParameter("?qq", MySqlDbType.VarChar,30),
					//new MySqlParameter("?rate", MySqlDbType.Double),
					//new MySqlParameter("?receivable", MySqlDbType.Double),
					//new MySqlParameter("?region", MySqlDbType.VarChar,60),
					//new MySqlParameter("?remarks", MySqlDbType.VarChar,100),
					//new MySqlParameter("?saleCredit", MySqlDbType.Double),
					//new MySqlParameter("?saleCreditDayCount", MySqlDbType.Int32,11),
					//new MySqlParameter("?salesman", MySqlDbType.VarChar,30),
					//new MySqlParameter("?stockCredit", MySqlDbType.Double),
					//new MySqlParameter("?stockCreditDayCount", MySqlDbType.Int32,11),
					//new MySqlParameter("?kokura_id", MySqlDbType.Int64,20),
					//new MySqlParameter("?prePayBalance", MySqlDbType.Double),
					//new MySqlParameter("?preReceiveBalance", MySqlDbType.Double),
					//new MySqlParameter("?region_id", MySqlDbType.Int64,20),
					//new MySqlParameter("?lat", MySqlDbType.Double),
					//new MySqlParameter("?lng", MySqlDbType.Double),
					//new MySqlParameter("?blOther", MySqlDbType.Bit),
					//new MySqlParameter("?businessScope", MySqlDbType.VarChar,150),
					//new MySqlParameter("?sal_Ent_Type_id", MySqlDbType.Int64,20),
                    //new MySqlParameter("?businessScopeDes", MySqlDbType.VarChar,1000),
                    //new MySqlParameter("?businessScopes", MySqlDbType.VarChar,300),
                    //new MySqlParameter("?settlementType", MySqlDbType.Int32,11),
                    //new MySqlParameter("?position_id", MySqlDbType.Int64,20),
					//new MySqlParameter("?salesman_id", MySqlDbType.Int64,20)
					new MySqlParameter("?id", MySqlDbType.Int64,20)

                                          };
            parameters[0].Value = model.active;
            parameters[1].Value = model.address;
            //parameters[2].Value = model.bankAccount;
            //parameters[3].Value = model.bankName;
            //parameters[4].Value = model.blAccount;
            //parameters[5].Value = model.blApproval;
            //parameters[6].Value = model.blCredit;
            //parameters[7].Value = model.blProxy;
            //parameters[8].Value = model.blSale;
            //parameters[9].Value = model.blStock;
            //parameters[10].Value = model.businessLicenseAlterdate;
            //parameters[11].Value = model.businessLicenseExpirydate;
            //parameters[10].Value = model.businessLicenseNo;
            //parameters[11].Value = model.businessLicenseScope;
            //parameters[12].Value = model.code;
            parameters[2].Value = model.contactPerson;
            //parameters[14].Value = model.createTime;
            //parameters[15].Value = model.dutyNo;
            parameters[3].Value = model.fax;
            //parameters[19].Value = model.grade;
            //parameters[17].Value = model.helpCode;
            parameters[4].Value = model.lastVer;
            //parameters[22].Value = model.licenceExpirydate;
            parameters[5].Value = model.mobile;
            parameters[6].Value = model.name;
            //parameters[21].Value = model.payable;
            parameters[7].Value = model.phone;
            //parameters[27].Value = model.postCode;
            //parameters[28].Value = model.powerOfAttorneyAlterdate;
            //parameters[29].Value = model.powerOfAttorneyExpirydate;
            //parameters[23].Value = model.qq;
            //parameters[31].Value = model.rate;
            //parameters[24].Value = model.receivable;
            //parameters[33].Value = model.region;
            //parameters[25].Value = model.remarks;
            //parameters[35].Value = model.saleCredit;
            //parameters[36].Value = model.saleCreditDayCount;
            //parameters[26].Value = model.salesman;
            //parameters[38].Value = model.stockCredit;
            //parameters[39].Value = model.stockCreditDayCount;
            //parameters[40].Value = model.kokura_id;
            //parameters[41].Value = model.prePayBalance;
            //parameters[27].Value = model.preReceiveBalance;
            //parameters[28].Value = model.region_id;
            //parameters[44].Value = model.lat;
            //parameters[45].Value = model.lng;
            //parameters[29].Value = model.blOther;
            //parameters[47].Value = model.businessScope;
            //parameters[48].Value = model.sal_Ent_Type_id;
            //parameters[30].Value = model.businessScopeDes;
            //parameters[31].Value = model.businessScopes;
            //parameters[32].Value = model.settlementType;
            //parameters[33].Value = model.position_id;
            //parameters[53].Value = model.salesman_id;
            parameters[8].Value = model.id;

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
        /// 删除对应CDP的用户关联（fax字段）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fax">对应商城的多个userId，用','隔开</param>
        /// <returns></returns>
        public bool DelCDPEnterLink(long id, string fax)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update enterpriseinfo set ");
            strSql.Append("fax=?fax");
            strSql.Append(" where id=?id");

            MySqlParameter[] parameters = {
					new MySqlParameter("?fax", MySqlDbType.VarChar,30),
					new MySqlParameter("?id", MySqlDbType.Int64,20)};
            parameters[0].Value = fax;
            parameters[1].Value = id;
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

