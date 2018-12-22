using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSWL.Common;
using YSWL.Common.DEncrypt;
using YSWL.SAAS.IDAL;

namespace YSWL.SAAS.SQLServerDAL
{
    public class SAASInfo : ISAASInfo
    {


        #region 获取登录用户信息

        public DataSet GetSAASUserInfo(string userName, byte[] encPassword, int userType = 1,
            long enterpriseId = 0)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(
                    " select * from  SA_UserInfo where LoginName=@LoginName and Passworld=@Passworld and UserType=@UserType and State=1   ");
                if (enterpriseId > 0)
                {
                    strSql.Append(" and EnterpriseId=@EnterpriseId ");
                }
                DataSet ds = SAASDBHelper.Query(strSql.ToString(), new SqlParameter[]
                {
                    new SqlParameter("@LoginName", userName),
                    new SqlParameter("@Passworld", encPassword),
                    new SqlParameter("@UserType", userType),
                    new SqlParameter("@EnterpriseId", enterpriseId)
                });
                if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count > 1)
                {
                    return null;
                }
                else
                {
                    enterpriseId = Common.Globals.SafeLong(ds.Tables[0].Rows[0]["EnterpriseId"], 0);
                    int userId = Common.Globals.SafeInt(ds.Tables[0].Rows[0]["UserId"], 0);
                    Common.CallContextHelper.SetAutoTag(enterpriseId);
                    if (userType == 1 || userType == 3) //客户账号，不区分应用类型
                    {
                        return ds;
                    }
                    var applicationId = PubConstant.GetApplicationId();
                    if (applicationId <= 0)
                    {
                        return null;
                    }
                    //需要判断应用是否已经过期
                    if (IsExistsUserLink(userId, applicationId))
                    {
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }
                return ds;

            }
            catch (Exception ex)
            {
                YSWL.Log.LogHelper.AddErrorLog(ex.Message, ex.StackTrace);
                return null;
            }

        }

        #endregion

        #region   添加SAAS用户

        public bool CreateSAASUser(string userName, byte[] encPassword, string trueName, string phone,
            long enterpriseId, int userType = 1, string applicationids = "", bool isCover = false)
        {
            //如果存在
            if (!isCover && IsExistsUser(userName) > 0)
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(PubConstant.BaseConnection))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    object result;
                    try
                    {
                        if (isCover)//如果需要覆盖，先删除数据，然后再添加数据
                        {
                            Log.LogHelper.AddTextLog("删除用户信息", "userName:" + userName);
                            SAASDBHelper.GetSingle4Trans(DeleteUser(userName, enterpriseId), transaction);
                        }
                        result =
                            SAASDBHelper.GetSingle4Trans(
                                GenSAASUser(userName, encPassword, trueName, phone, enterpriseId, userType), transaction);

                        int userId = Common.Globals.SafeInt(result, -1);
                        if (String.IsNullOrWhiteSpace(applicationids))
                        {
                            applicationids = PubConstant.GetApplicationId().ToString();
                        }

                        SAASDBHelper.ExecuteSqlTran4Indentity(GenUserLink(userId, enterpriseId, applicationids),
                            transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public CommandInfo GenSAASUser(string userName, byte[] encPassword, string trueName, string phone,
            long enterpriseId, int usertype = 1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_UserInfo(");
            strSql.Append(
                "LoginName,Passworld,RealName,Moblie,State,UserType,ParentId,EnterpriseName,CreateTime,ModeifyTime,CreateBy,ModifyBy,AdministratorLevel,UserNumber,EnterpriseId,Email,FromTargetType)");
            strSql.Append(" values (");
            strSql.Append(
                "@LoginName,@Passworld,@RealName,@Moblie,@State,@UserType,@ParentId,@EnterpriseName,@CreateTime,@ModeifyTime,@CreateBy,@ModifyBy,@AdministratorLevel,@UserNumber,@EnterpriseId,@Email,@FromTargetType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LoginName", SqlDbType.NVarChar, 50),
                new SqlParameter("@Passworld", SqlDbType.Binary, 20),
                new SqlParameter("@RealName", SqlDbType.NVarChar, 80),
                new SqlParameter("@Moblie", SqlDbType.NVarChar, 20),
                new SqlParameter("@State", SqlDbType.SmallInt, 2),
                new SqlParameter("@UserType", SqlDbType.SmallInt, 2),
                new SqlParameter("@ParentId", SqlDbType.BigInt, 8),
                new SqlParameter("@EnterpriseName", SqlDbType.NVarChar, 120),
                new SqlParameter("@CreateTime", SqlDbType.DateTime),
                new SqlParameter("@ModeifyTime", SqlDbType.DateTime),
                new SqlParameter("@CreateBy", SqlDbType.NVarChar, 50),
                new SqlParameter("@ModifyBy", SqlDbType.NVarChar, 50),
                new SqlParameter("@AdministratorLevel", SqlDbType.SmallInt, 2),
                new SqlParameter("@UserNumber", SqlDbType.NVarChar, 50),
                new SqlParameter("@EnterpriseId", SqlDbType.BigInt, 8),
                new SqlParameter("@Email", SqlDbType.NVarChar, 50),
                new SqlParameter("@FromTargetType", SqlDbType.SmallInt, 2)
            };
            parameters[0].Value = userName;
            parameters[1].Value = encPassword;
            parameters[2].Value = trueName;
            parameters[3].Value = phone;
            parameters[4].Value = 1;
            parameters[5].Value = usertype;
            parameters[6].Value = 0;
            parameters[7].Value = "";
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = DateTime.Now;
            parameters[10].Value = trueName;
            parameters[11].Value = trueName;
            parameters[12].Value = 0;
            parameters[13].Value = "";
            parameters[14].Value = enterpriseId;
            parameters[15].Value = "";
            parameters[16].Value = 2;

            return new CommandInfo(strSql.ToString(), parameters);
        }


        public List<CommandInfo> GenUserLink(int userId, long enterpriseId, string applicationIds)
        {
            List<CommandInfo> commandInfos = new List<CommandInfo>();
            var appArry = applicationIds.Split('|');
            foreach (var item in appArry)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into SA_AccountLinkSystem(");
                strSql.Append("UserId,EnterpriseTag,EnterpriseId,ApplicationId,Url,ApplicationName)");
                strSql.Append(" select  ");
                strSql.Append(
                    "@UserId,@EnterpriseTag,@EnterpriseId,@ApplicationId,UrlAddress,ApplicationName from   SA_EnterpriseBuyJurisdiction where EnterpriseId=@EnterpriseId and ApplicationId=@ApplicationId ");

                SqlParameter[] parameters =
                {
                new SqlParameter("@UserId", SqlDbType.BigInt, 8),
                new SqlParameter("@EnterpriseTag", SqlDbType.NVarChar, 70),
                new SqlParameter("@EnterpriseId", SqlDbType.BigInt, 8),
                new SqlParameter("@ApplicationId", SqlDbType.Int, 4)
            };
                parameters[0].Value = userId;
                parameters[1].Value = Common.DEncrypt.DEncrypt.GetEncryptionStr(enterpriseId);
                parameters[2].Value = enterpriseId;
                parameters[3].Value = Common.Globals.SafeInt(item, 0);
                commandInfos.Add(new CommandInfo(strSql.ToString(), parameters));
            }
            return commandInfos;
        }

        public CommandInfo DeleteUser(string userName, long enterpriseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM  SA_UserInfo WHERE LoginName=@LoginName ");

            SqlParameter[] parameters =
             {
                new SqlParameter("@LoginName", SqlDbType.NVarChar, 200),
                new SqlParameter("@EnterpriseId", SqlDbType.BigInt, 8)
            };
            parameters[0].Value = userName;
            parameters[1].Value = enterpriseId;
            return new CommandInfo(strSql.ToString(), parameters);
        }

        #endregion

        #region  SAAS 用户是否存在

        public int IsExistsUser(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId  from SA_UserInfo");
            strSql.Append(" where LoginName=@LoginName");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LoginName", SqlDbType.NVarChar, 50)
            };
            parameters[0].Value = userName;

            object obj = SAASDBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Common.Globals.SafeInt(obj, 0);
            }
        }

        public bool IsExistsUserLink(int userId, int applicationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(1)  from SA_AccountLinkSystem");
            strSql.Append(" where UserId=@UserId and ApplicationId=@ApplicationId");
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserId", SqlDbType.Int, 4),
                new SqlParameter("@ApplicationId", SqlDbType.Int, 4)
            };
            parameters[0].Value = userId;
            parameters[1].Value = applicationId;
            return SAASDBHelper.Exists(strSql.ToString(), parameters);
        }

        #endregion

        #region  修改密码同步至SAAS系统

        public bool SetPassword(string userName, byte[] encPassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_UserInfo set ");
            strSql.Append("Passworld=@Passworld ");
            strSql.Append(" where LoginName=@userName");
            SqlParameter[] parameters =
            {
                new SqlParameter("@Passworld", SqlDbType.Binary, 20),
                new SqlParameter("@userName", SqlDbType.NVarChar, 50)
            };
            parameters[0].Value = encPassword;
            parameters[1].Value = userName;
            int rows = SAASDBHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 更新用户信息

        /// <summary>
        /// 更新SAAS用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="trueName"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool UpdateUser(string userName, byte[] encPassword, string trueName, string phone,
            long enterpriseId, bool activity)
        {
            //如果存在
            if (IsExistsUser(userName) == 0)
            {
                return CreateSAASUser(userName, encPassword, trueName, phone, enterpriseId);
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SA_UserInfo set ");
                strSql.Append("RealName=@RealName, ");
                strSql.Append("Moblie=@Moblie ,");
                strSql.Append("State=@State  ");
                strSql.Append(" where LoginName=@userName");
                SqlParameter[] parameters =
                {
                    new SqlParameter("@RealName", SqlDbType.NVarChar, 200),
                    new SqlParameter("@Moblie", SqlDbType.NVarChar, 20),
                     new SqlParameter("@State", SqlDbType.SmallInt, 4),
                    new SqlParameter("@userName", SqlDbType.NVarChar, 50)
                };
                parameters[0].Value = trueName;
                parameters[1].Value = phone;
                parameters[2].Value = activity ? 1 : 3;
                parameters[3].Value = userName;
                int rows = SAASDBHelper.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region 应用是否开通



        public bool AppIsOpen(string tag, int enterpeiseId)
        {
            int applicationId = PubConstant.GetApplicationId(tag);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(1)  from SA_EnterpriseBuyJurisdiction");
            strSql.Append(" where EnterpriseId=@EnterpriseId and ApplicationId=@ApplicationId and (IsTrial=1 or (IsTrial=0 and   EndTime>@EndTime))");
            SqlParameter[] parameters =
            {
                new SqlParameter("@EnterpriseId", SqlDbType.Int, 4),
                new SqlParameter("@ApplicationId", SqlDbType.Int, 4),
                new SqlParameter("@EndTime", SqlDbType.DateTime)
            };
            parameters[0].Value = enterpeiseId;
            parameters[1].Value = applicationId;
            parameters[2].Value = DateTime.Now;

            object obj = SAASDBHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return Common.Globals.SafeInt(obj, 0) > 0;
            }
        }

        #endregion

        #region 获取SaaS参数

        public string GetSystemValue(string Keyname)
        {
            return GetSystemValueEx(Keyname);
        }

        public static string GetSystemValueEx(string Keyname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Value from SA_Config_System ");
            strSql.Append(" where Keyname=@Keyname ");
            SqlParameter[] parameters =
            {
                new SqlParameter("@Keyname", SqlDbType.NVarChar)
            };
            parameters[0].Value = Keyname;
            object obj = SAASDBHelper.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
        #endregion

        #region   获取SAAS企业列表（正常企业）

        public DataSet GetSAASEnterprises()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select * from  FROM Ms_Enterprise where  Status=1  ");
                DataSet ds = SAASDBHelper.Query(strSql.ToString());
                if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count > 1)
                {
                    return null;
                }
                return ds;
            }
            catch (Exception ex)
            {
                YSWL.Log.LogHelper.AddErrorLog(ex.Message, ex.StackTrace);
                return null;
            }

        }


        public int GetSAASEntIdByDomain(string domain)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select top 1 EnterpriseID FROM Ms_Enterprise where CustomDomain=@CustomDomain AND  Status=1");
            SqlParameter[] parameters =
            {
                        new SqlParameter("@CustomDomain", SqlDbType.NVarChar)
                    };
            parameters[0].Value = domain;
            object obj = SAASDBHelper.GetSingle(strSql.ToString(), parameters);
            return Globals.SafeInt(obj, -1);
        }

        #endregion

        #region  应用限制访问相关方法





        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public int GetUserCounts(int usertype, long enterpriseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(1)  from SA_UserInfo");
            strSql.Append(" where EnterpriseId=@EnterpriseId and UserType=@UserType");
            SqlParameter[] parameters =
            {
                new SqlParameter("@EnterpriseId", SqlDbType.Int, 8),
                new SqlParameter("@UserType", SqlDbType.Int, 4)
            };
            parameters[0].Value = enterpriseId;
            parameters[1].Value = usertype;
            object obj = SAASDBHelper.GetSingle(strSql.ToString(), parameters);

            return Common.Globals.SafeInt(obj, 0);
        }


        public DateTime GetEndTime(int applicationId, long enterpriseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EndTime  from SA_EnterpriseBuyJurisdiction");
            strSql.Append(" where EnterpriseId=@EnterpriseId and ApplicationId=@ApplicationId  and IsTrial=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@EnterpriseId", SqlDbType.Int,4),
                    new SqlParameter("@ApplicationId", SqlDbType.Int,4)
            };
            parameters[0].Value = enterpriseId;
            parameters[1].Value = applicationId;

            object objModel = SAASDBHelper.GetSingle(strSql.ToString(), parameters);

            return Common.Globals.SafeDateTime(objModel, DateTime.Now);
        }

        /// <summary>
        /// 应用是否购买
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public bool IsBuy(int applicationId, long enterpriseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(1)  from SA_EnterpriseBuyJurisdiction");
            strSql.Append(" where EnterpriseId=@EnterpriseId and ApplicationId=@ApplicationId  and IsTrial=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@EnterpriseId", SqlDbType.Int,4),
                    new SqlParameter("@ApplicationId", SqlDbType.Int,4)
            };
            parameters[0].Value = enterpriseId;
            parameters[1].Value = applicationId;
            object obj = SAASDBHelper.GetSingle(strSql.ToString(), parameters);
            return Common.Globals.SafeInt(obj, 0) > 0;
        }





        public string GetSysValue(string key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Value from SA_Config_System ");
            strSql.Append(" where Keyname=@Keyname ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Keyname", SqlDbType.NVarChar)};
            parameters[0].Value = key;

            object obj = SAASDBHelper.GetSingle(strSql.ToString(), parameters);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        #endregion


        public string GetBusinnessConStr(string applicationTag)
        {
            return GetBusinnessConStrEx(applicationTag);
        }

        /// <summary>
        /// 获取企业的数据库配置信息
        /// </summary>
        /// <returns></returns>
        public static string GetBusinnessConStrEx(string applicationTag)
        {
            YSWL.Common.DataCacheCore coreBll = new DataCacheCore(new CacheOption
            {
                CacheType = Common.Globals.SafeBool(GetSystemValueEx("RedisCacheUse"), false) ? CacheType.Redis : CacheType.IIS,
                CancelProductKey = true,
                CancelEnterpriseKey = true,
                DefaultDb = 0,
                ReadWriteHosts = GetSystemValueEx("RedisCacheReadWriteHosts"),
                ReadOnlyHosts = GetSystemValueEx("RedisCacheReadOnlyHosts"),
            });
            applicationTag = applicationTag.ToUpper();
            string CacheKey = "SAAS_ConnectionString_" + applicationTag + "_" + Common.CallContextHelper.GetAutoTag();
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null || String.IsNullOrWhiteSpace(objModel.ToString()))
            {
                try
                {
                    DataSet ds = SAASDBHelper.Query(
                            "select * from  SA_EnterpriseDBConfig  where EnterpriseId=@EnterpriseId  and [State]=1 and ApplicationTag=@ApplicationTag",
                            new SqlParameter[]
                            {
                                new SqlParameter("@EnterpriseId", Common.CallContextHelper.GetAutoTag()),
                                new SqlParameter("@ApplicationTag", applicationTag)
                            });
                    if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count > 1)
                    {
                        return null;
                    }
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        objModel = "server=" + item["RemoteDB_IP"] + ";database=" + item["DBName"] + ";uid=" +
                                   item["UserInstance"] + ";pwd=" + item["Passworld"];
                        break;
                    }
                    if (objModel != null && !String.IsNullOrWhiteSpace(objModel.ToString()))
                    {
                        coreBll.SetCache(CacheKey, objModel, DateTime.MaxValue, TimeSpan.Zero);
                    }
                }
                catch (Exception ex)
                {
                    Log.LogHelper.AddErrorLog("获取连接地址失败：" + ex.Message, "详细错误为：" + ex.StackTrace);
                    throw ex;
                }
            }
            return Common.Globals.SafeString(objModel, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool IsDBExists()
        {
            string CacheKey = "YSWL_IsDBExists_ConnectionString";
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    string ConnectionString = PubConstant.GetConnectionStr();//GetBusinnessConStr(GetSystemFlag());
                    SqlConnection connection = new SqlConnection(ConnectionString);
                    connection.Open();
                    connection.Close();
                    objModel = true;
                }
                catch (Exception exception)
                {
                    return false;
                }
                if (objModel != null)
                {
                    int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("ModelCache");
                    YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                }
            }
            return Common.Globals.SafeBool(objModel, false);
        }

        /// <summary>
        /// 获取企业开通的应用ID集合
        /// </summary>
        /// <param name="enterpriseId"></param>
        /// <returns></returns>
        public DataSet GetOpenApps(long enterpriseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ApplicationId  ");
            strSql.Append(" FROM SA_EnterpriseBuyJurisdiction ");
            strSql.AppendFormat(" where State=1 and  EnterpriseId={0}", enterpriseId);
            return SAASDBHelper.Query(strSql.ToString());
        }
    }
}
