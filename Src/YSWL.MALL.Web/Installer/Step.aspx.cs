/**
* Step.cs
*
* 功 能： [N/A]
* 类 名： Step
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/7/23 16:55:26  Administrator    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using YSWL.Accounts.Bus;
using YSWL.MALL.Model.Members;


namespace YSWL.Web.Installer
{
    public partial class Step : Page
    {
        protected void btnDownConfig_Click(object sender, EventArgs e)
        {
            System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
            configuration.ConnectionStrings.ConnectionStrings.Clear();
            ConnectionStringSettings settings = new ConnectionStringSettings("YSWLSqlServer", this.ConnectionString, "System.Data.SqlClient");
            configuration.ConnectionStrings.ConnectionStrings.Add(settings);
            configuration.ConnectionStrings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            XmlDocument document = new XmlDocument();
            document.LoadXml(configuration.ConnectionStrings.SectionInformation.GetRawXml());
            XmlNode node = document.SelectSingleNode("//connectionStrings");
            node.ChildNodes[0].Attributes["name"].Value = "YSWLSqlServer";
            node.ChildNodes[0].Attributes["connectionString"].Value = this.ConnectionString;
            node.ChildNodes[0].Attributes["providerName"].Value = "System.Data.SqlClient";
            XmlNode encryptConnectionStringNode = configuration.ConnectionStrings.SectionInformation.ProtectionProvider.Encrypt(node);
            base.Response.Clear();
            base.Response.ClearHeaders();
            base.Response.Buffer = false;
            base.Response.ContentEncoding = Encoding.UTF8;
            base.Response.ContentType = "application/octet-stream";
            base.Response.AppendHeader("Content-Disposition", "attachment;filename=Web.config");
            base.Response.BinaryWrite(this.InitStream(encryptConnectionStringNode));
            base.Response.Flush();
            base.Response.End();
        }
        /// <summary>
        /// 创建数据库(需要比较大的权限，是否这部分让用户手动创建数据库)
        /// </summary>
        /// <returns></returns>
        private bool CreateDatabase(out string message)
        {

            message = "";
            return true;
        }


        private string CreateKey(int len)
        {
            byte[] data = new byte[len];
            new RNGCryptoServiceProvider().GetBytes(data);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(string.Format("{0:X2}", data[i]));
            }
            return builder.ToString();
        }

        private const string IMAGEOK = "/Installer/images/ok.gif";

        #region 创建站点数据信息

        private bool CreateSite(out string message)
        {
            message = String.Empty;
            string host = base.Request.Url.Host;
            if (UpdateConfigFile(out message))
            {
                string errorMsg = String.Empty;
                if (!CreateUser(out errorMsg))
                {
                    message = errorMsg;
                    return false;
                }
                else
                {
                    this.UpdateSiteDescription(host, YSWL.Common.Globals.HtmlEncode(this.txtSiteName.Text.Trim()),
                                               YSWL.Common.Globals.HtmlEncode(this.txtDesciption.Text.Trim()));
                    message = "";
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        private bool CreateUser(out string errorMsg)
        {
            try
            {
                errorMsg = "";
                YSWL.MALL.Model.Members.Users user = new MALL.Model.Members.Users();
                user.Activity = true;
                user.DepartmentID = "";
                user.EmployeeID =0;
                user.Email = this.txtEmail.Text.Trim();
                user.UserName = user.NickName = this.txtUserName.Text.Trim();
                user.Password = AccountsPrincipal.EncryptPassword(this.txtPassword.Text);
                user.UserType = "AA";
                user.Style = 1;
                user.User_dateCreate = DateTime.Now;
                if (!AddUser(user))
                {
                    errorMsg = "创建管理员帐号失败";
                    return false;
                }
                MALL.BLL.Members.UsersExp ue = new MALL.BLL.Members.UsersExp();
                ue.UserID = 1;
                ue.BirthdayVisible = 0;
                ue.BirthdayIndexVisible = false;
                ue.Gravatar = "/"+YSWL.Components.MvcApplication.UploadFolder+"/User/Gravatar/1";
                ue.ConstellationVisible = 0;
                ue.ConstellationIndexVisible = false;
                ue.NativePlaceVisible = 0;
                ue.NativePlaceIndexVisible = false;
                ue.RegionId = 0;
                ue.AddressVisible = 0;
                ue.AddressIndexVisible = false;
                ue.BodilyFormVisible = 0;
                ue.BodilyFormIndexVisible = false;
                ue.BloodTypeVisible = 0;
                ue.BloodTypeIndexVisible = false;
                ue.MarriagedVisible = 0;
                ue.MarriagedIndexVisible = false;
                ue.PersonalStatusVisible = 0;
                ue.PersonalStatusIndexVisible = false;
                ue.LastAccessIP = "";
                ue.LastAccessTime = DateTime.Now;
                ue.LastLoginTime = DateTime.Now;
                ue.LastPostTime = DateTime.Now;

                if (!AddUserExp(ue))
                {
                    errorMsg = "创建管理员帐号扩展数据添加失败";
                    return false;
                }
                if (!AddUserRoles(1, 1))
                {
                    errorMsg = "创建管理员角色数据失败";
                    return false;
                }
                AddGroup();
                return true;
            }
            catch (Exception exception)
            {
                errorMsg = exception.Message;
                return false;
            }
        }

        //修改网站描述
        private void UpdateSiteDescription(string siteUrl, string siteName, string siteDescription)
        {
            UpdateSiteInfo("WebName", siteName, 1, "站点信息");
            UpdateSiteInfo("BaseHost", siteUrl, 1, "站点域名");
            UpdateSiteInfo("Description", siteDescription, 1, "站点描述");
        }

        #region MSSQL 方法
        private bool UpdateSiteInfo(string key, string value, int type = 1, string Desc = "")
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Config_System set ");
            strSql.Append("Value=@Value,KeyType=@KeyType,Description=@Description ");
            strSql.Append(" where Keyname=@Keyname ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Keyname", SqlDbType.VarChar,50),
                    new SqlParameter("@Value", SqlDbType.VarChar),
                         new SqlParameter("@KeyType", SqlDbType.Int),
                    new SqlParameter("@Description", SqlDbType.VarChar,200)};
            parameters[0].Value = key;
            parameters[1].Value = value;
            parameters[2].Value = type;
            parameters[3].Value = Desc;

            command.CommandText = strSql.ToString();
            command.Parameters.AddRange(parameters);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddUser(YSWL.MALL.Model.Members.Users model)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_Users(");
            strSql.Append("UserName,Password,NickName,Email,EmployeeID,DepartmentID,Activity,UserType,Style,User_dateCreate)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@NickName,@Email,@EmployeeID,@DepartmentID,@Activity,@UserType,@Style,@User_dateCreate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.Binary,20),
                    new SqlParameter("@NickName", SqlDbType.VarChar,50),
                    new SqlParameter("@Email", SqlDbType.VarChar,100),
                    new SqlParameter("@EmployeeID", SqlDbType.Int,4),
                    new SqlParameter("@DepartmentID", SqlDbType.VarChar,15),
                    new SqlParameter("@Activity", SqlDbType.Bit,1),
                    new SqlParameter("@UserType", SqlDbType.Char,2),
                    new SqlParameter("@Style", SqlDbType.Int,4),
                    new SqlParameter("@User_dateCreate", SqlDbType.DateTime)
                };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.EmployeeID;
            parameters[5].Value = model.DepartmentID;
            parameters[6].Value = model.Activity;
            parameters[7].Value = model.UserType;
            parameters[8].Value = model.Style;
            parameters[9].Value = model.User_dateCreate;

            command.CommandText = strSql.ToString();

            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput ||
                    parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                command.Parameters.Add(parameter);
            }

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddUserExp(YSWL.MALL.Model.Members.UsersExpModel model)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UsersExp(");
            strSql.Append("UserID,Gravatar,Singature,TelPhone,QQ,MSN,HomePage,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,RegionId,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Balance,Points,TopicCount,ReplyTopicCount,FavTopicCount,PvCount,FansCount,FellowCount,AblumsCount,FavouritesCount,FavoritedCount,ShareCount,ProductsCount,PersonalDomain,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Remark,IsUserDPI,PayAccount)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@Gravatar,@Singature,@TelPhone,@QQ,@MSN,@HomePage,@Birthday,@BirthdayVisible,@BirthdayIndexVisible,@Constellation,@ConstellationVisible,@ConstellationIndexVisible,@NativePlace,@NativePlaceVisible,@NativePlaceIndexVisible,@RegionId,@Address,@AddressVisible,@AddressIndexVisible,@BodilyForm,@BodilyFormVisible,@BodilyFormIndexVisible,@BloodType,@BloodTypeVisible,@BloodTypeIndexVisible,@Marriaged,@MarriagedVisible,@MarriagedIndexVisible,@PersonalStatus,@PersonalStatusVisible,@PersonalStatusIndexVisible,@Grade,@Balance,@Points,@TopicCount,@ReplyTopicCount,@FavTopicCount,@PvCount,@FansCount,@FellowCount,@AblumsCount,@FavouritesCount,@FavoritedCount,@ShareCount,@ProductsCount,@PersonalDomain,@LastAccessTime,@LastAccessIP,@LastPostTime,@LastLoginTime,@Remark,@IsUserDPI,@PayAccount)");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@Gravatar", SqlDbType.VarChar,200),
                    new SqlParameter("@Singature", SqlDbType.NVarChar,200),
                    new SqlParameter("@TelPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@QQ", SqlDbType.VarChar,30),
                    new SqlParameter("@MSN", SqlDbType.VarChar,30),
                    new SqlParameter("@HomePage", SqlDbType.VarChar,50),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@BirthdayVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@BirthdayIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@Constellation", SqlDbType.VarChar,10),
                    new SqlParameter("@ConstellationVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@ConstellationIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@NativePlace", SqlDbType.NVarChar,300),
                    new SqlParameter("@NativePlaceVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@NativePlaceIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@RegionId", SqlDbType.Int,4),
                    new SqlParameter("@Address", SqlDbType.NVarChar,300),
                    new SqlParameter("@AddressVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@AddressIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@BodilyForm", SqlDbType.NVarChar,10),
                    new SqlParameter("@BodilyFormVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@BodilyFormIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@BloodType", SqlDbType.NVarChar,10),
                    new SqlParameter("@BloodTypeVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@BloodTypeIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@Marriaged", SqlDbType.NVarChar,10),
                    new SqlParameter("@MarriagedVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@MarriagedIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@PersonalStatus", SqlDbType.NVarChar,10),
                    new SqlParameter("@PersonalStatusVisible", SqlDbType.SmallInt,2),
                    new SqlParameter("@PersonalStatusIndexVisible", SqlDbType.Bit,1),
                    new SqlParameter("@Grade", SqlDbType.Int,4),
                    new SqlParameter("@Balance", SqlDbType.Money,8),
                    new SqlParameter("@Points", SqlDbType.Int,4),
                    new SqlParameter("@TopicCount", SqlDbType.Int,4),
                    new SqlParameter("@ReplyTopicCount", SqlDbType.Int,4),
                    new SqlParameter("@FavTopicCount", SqlDbType.Int,4),
                    new SqlParameter("@PvCount", SqlDbType.Int,4),
                    new SqlParameter("@FansCount", SqlDbType.Int,4),
                    new SqlParameter("@FellowCount", SqlDbType.Int,4),
                    new SqlParameter("@AblumsCount", SqlDbType.Int,4),
                    new SqlParameter("@FavouritesCount", SqlDbType.Int,4),
                    new SqlParameter("@FavoritedCount", SqlDbType.Int,4),
                    new SqlParameter("@ShareCount", SqlDbType.Int,4),
                    new SqlParameter("@ProductsCount", SqlDbType.Int,4),
                    new SqlParameter("@PersonalDomain", SqlDbType.NVarChar,50),
                    new SqlParameter("@LastAccessTime", SqlDbType.DateTime),
                    new SqlParameter("@LastAccessIP", SqlDbType.VarChar,50),
                    new SqlParameter("@LastPostTime", SqlDbType.DateTime),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
                    new SqlParameter("@Remark", SqlDbType.VarChar),
                    new SqlParameter("@IsUserDPI", SqlDbType.Bit,1),
                    new SqlParameter("@PayAccount", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Gravatar;
            parameters[2].Value = model.Singature;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.QQ;
            parameters[5].Value = model.MSN;
            parameters[6].Value = model.HomePage;
            parameters[7].Value = model.Birthday;
            parameters[8].Value = model.BirthdayVisible;
            parameters[9].Value = model.BirthdayIndexVisible;
            parameters[10].Value = model.Constellation;
            parameters[11].Value = model.ConstellationVisible;
            parameters[12].Value = model.ConstellationIndexVisible;
            parameters[13].Value = model.NativePlace;
            parameters[14].Value = model.NativePlaceVisible;
            parameters[15].Value = model.NativePlaceIndexVisible;
            parameters[16].Value = model.RegionId;
            parameters[17].Value = model.Address;
            parameters[18].Value = model.AddressVisible;
            parameters[19].Value = model.AddressIndexVisible;
            parameters[20].Value = model.BodilyForm;
            parameters[21].Value = model.BodilyFormVisible;
            parameters[22].Value = model.BodilyFormIndexVisible;
            parameters[23].Value = model.BloodType;
            parameters[24].Value = model.BloodTypeVisible;
            parameters[25].Value = model.BloodTypeIndexVisible;
            parameters[26].Value = model.Marriaged;
            parameters[27].Value = model.MarriagedVisible;
            parameters[28].Value = model.MarriagedIndexVisible;
            parameters[29].Value = model.PersonalStatus;
            parameters[30].Value = model.PersonalStatusVisible;
            parameters[31].Value = model.PersonalStatusIndexVisible;
            parameters[32].Value = model.Grade;
            parameters[33].Value = model.Balance;
            parameters[34].Value = model.Points;
            parameters[35].Value = model.TopicCount;
            parameters[36].Value = model.ReplyTopicCount;
            parameters[37].Value = model.FavTopicCount;
            parameters[38].Value = model.PvCount;
            parameters[39].Value = model.FansCount;
            parameters[40].Value = model.FellowCount;
            parameters[41].Value = model.AblumsCount;
            parameters[42].Value = model.FavouritesCount;
            parameters[43].Value = model.FavoritedCount;
            parameters[44].Value = model.ShareCount;
            parameters[45].Value = model.ProductsCount;
            parameters[46].Value = model.PersonalDomain;
            parameters[47].Value = model.LastAccessTime;
            parameters[48].Value = model.LastAccessIP;
            parameters[49].Value = model.LastPostTime;
            parameters[50].Value = model.LastLoginTime;
            parameters[51].Value = model.Remark;
            parameters[52].Value = model.IsUserDPI;
            parameters[53].Value = model.PayAccount;

            command.CommandText = strSql.ToString();

            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput ||
                    parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                command.Parameters.Add(parameter);
            }

            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddUserRoles(int userId, int roleId)
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UserRoles(");
            strSql.Append("UserID,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@RoleID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)
                };
            parameters[0].Value = userId;
            parameters[1].Value = roleId;

            command.CommandText = strSql.ToString();
            command.Parameters.AddRange(parameters);
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddGroup()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT [SNS_Groups] (  [GroupName], [GroupDescription], [GroupUserCount], [CreatedUserId], [CreatedNickName], [CreatedDate], [GroupLogo], [GroupLogoThumb], [GroupBackground], [ApplyGroupReason], [IsRecommand], [TopicCount], [TopicReplyCount], [Status], [Sequence], [Privacy], [Tags]) VALUES ( N'微社区', N'微社区', 1, 1, N'', CAST(0x0000A3990100E500 AS DateTime), N'/UploadFolder/Images/ContentImgFile/4e3d0754750446ed98f0f032a38c0b01.png', N'/UploadFolder/Images/ContentImgFile/4e3d0754750446ed98f0f032a38c0b01.png', N'', N'', 1, 0, 0, 1, 1, 1, N'') ");
            command.CommandText = strSql.ToString();
            connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #endregion

        #region 执行数据脚本方法
        //private bool CreateDatabaseSchema(out string message)
        //{
        //    string path = base.Request.MapPath("SqlScripts/Schema.sql");
        //    if (!File.Exists(path))
        //    {
        //        message = "";
        //        return false;
        //    }
        //    return this.ExecuteScriptFile(path, out message);
        //}

        private bool CreateDemo(out string message)
        {
            string path = base.Request.MapPath("SqlScripts/SiteDemo.Sql");
            if (!File.Exists(path))
            {
                message = "";
                return false;
            }
            return this.ExecuteScriptFile(path, out message);
        }

        private bool CreateInitData(out string message)
        {
            string path = base.Request.MapPath("SqlScripts/SiteInitData.Sql");
            if (!File.Exists(path))
            {
                message = "初始化数据文件不存在！";
                return false;
            }
            return this.ExecuteScriptFile(path, out message);
        }

        private bool ExecuteScriptFile(string pathToScriptFile, out string message)
        {
            bool flag;
            try
            {
                string applicationPath = YSWL.Common.Globals.ApplicationPath;
                using (StreamReader reader = new StreamReader(pathToScriptFile))
                {
                    SqlConnection connection = new SqlConnection(this.ConnectionString);
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 60;
                    connection.Open();
                    while (!reader.EndOfStream)
                    {
                        string str = NextSqlFromStream(reader);
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            command.CommandText = str.Replace("$VirsualPath$", applicationPath);
                            command.ExecuteNonQuery();
                        }
                    }
                    reader.Close();
                    connection.Close();
                    message = "";
                    flag = true;

                }
            }
            catch (SqlException exception)
            {
                message = exception.Message;
                flag = false;
            }
            return flag;
        }

        private static string NextSqlFromStream(StreamReader reader)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                string strA = reader.ReadLine().Trim();
                while (!reader.EndOfStream && (string.Compare(strA, "GO", true, CultureInfo.InvariantCulture) != 0))
                {
                    builder.Append(strA + Environment.NewLine);
                    strA = reader.ReadLine();
                }
                if (string.Compare(strA, "GO", true, CultureInfo.InvariantCulture) != 0)
                {
                    builder.Append(strA + Environment.NewLine);
                }
                return builder.ToString();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private RijndaelManaged GetCryptographer()
        {
            RijndaelManaged managed = new RijndaelManaged();
            managed.KeySize = 0x80;
            managed.GenerateIV();
            managed.GenerateKey();
            return managed;
        }

        private byte[] InitStream(XmlNode encryptConnectionStringNode)
        {
            string filename = base.Request.MapPath(YSWL.Common.Globals.ApplicationPath + "/web.config");
            XmlDocument document = new XmlDocument();
            document.PreserveWhitespace = true;
            document.Load(filename);
            XmlNode node = document.SelectSingleNode("configuration/connectionStrings");
            XmlNode node2 = document.SelectSingleNode("configuration/appSettings");
            node.RemoveAll();
            XmlAttribute attribute = document.CreateAttribute("configProtectionProvider");
            attribute.Value = "DataProtectionConfigurationProvider";
            node.Attributes.Append(attribute);
            XmlNode newChild = document.CreateElement("EncryptedData");
            newChild.InnerText = encryptConnectionStringNode.InnerText;
            newChild.InnerXml = encryptConnectionStringNode.InnerXml;
            node.AppendChild(newChild);
            XmlNode oldChild = node2.SelectSingleNode("add[@key='Installer']");
            node2.RemoveChild(oldChild);
            XmlNode node5 = node2.SelectSingleNode("add[@key='Key']");
            XmlNode node6 = node2.SelectSingleNode("add[@key='IV']");
            using (RijndaelManaged managed = this.GetCryptographer())
            {
                node5.Attributes["value"].Value = Convert.ToBase64String(managed.Key);
                node6.Attributes["value"].Value = Convert.ToBase64String(managed.IV);
            }
            XmlNode node7 = document.SelectSingleNode("//machineKey");
            node7.Attributes["validationKey"].Value = this.CreateKey(20);
            node7.Attributes["decryptionKey"].Value = this.CreateKey(0x18);
            return Encoding.UTF8.GetBytes(document.OuterXml);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                if (YSWL.Components.MvcApplication.IsInstall)
                {
                    Response.Redirect("/", true);
                    return;
                }
                if (!(Session["Install"] != null && Session["Install"].ToString() == "Checked"))
                {
                    Response.Redirect("/Installer/Check.aspx");
                }
            }
        }

        private void ShowMessage(Label lblMessage, string message)
        {
            lblMessage.Text = message;
            lblMessage.Visible = true;
        }
        //测试数据库连接
        private bool TestConnection(out string message)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectionString);
                connection.Open();
                connection.Close();
                message = null;
                return true;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return false;
            }
        }

        #region 更新Config连接字符串
        private bool UpdateConfigFile(out string message)
        {
            message = "";
            try
            {
                System.Configuration.Configuration configuration =
                    WebConfigurationManager.OpenWebConfiguration(base.Request.ApplicationPath);
                if (YSWL.Components.MvcApplication.ProductInfoFull.ToLower().Contains("mall"))
                {
                    configuration.ConnectionStrings.ConnectionStrings["YSWLSqlServer"].ConnectionString =
                        this.ConnectionString;
                }
                configuration.AppSettings.Settings["ConnectionString"].Value = this.ConnectionString;
                configuration.AppSettings.Settings["Installer"].Value = "True";
                YSWL.Components.MvcApplication.IsInstall = true; //完成安装
                configuration.Save();
                ConfigurationManager.RefreshSection("AppSettings");
                //更新连接字符串
                YSWL.MALL.BLL.SysManage.ConfigSystem.UpdateConnectionString(this.ConnectionString);
                return true;
            }
            catch (NullReferenceException)
            {
                message = "web.config文件更新失败! 请还原web.config文件为安装包内的原版重试!";
                return false;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
        #endregion

        private bool ValidateAdministrator(out string message)
        {
            message = string.Empty;
            bool flag = true;
            if (string.IsNullOrWhiteSpace(this.txtUserName.Text.Trim()))
            {
                message = "用户名不能为空<br/>";
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
            {
                message = message + "邮箱不能为空 <br/>";
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text.Trim()))
            {
                message = message + "密码不能为空 <br/>";
                flag = false;
            }
            if (this.txtPassword.Text != this.txtPasswordCompare.Text)
            {
                message = message + "确认密码不匹配 <br/>";
                flag = false;
            }
            return flag;
        }

        private bool ValidateConnectionString(out string message)
        {
            message = string.Empty;
            bool flag = true;
            if (string.IsNullOrWhiteSpace(this.txtdbServer.Text.Trim()))
            {
                flag = false;
                message = "数据库服务器不能为空 <br/>";
            }
            if (string.IsNullOrWhiteSpace(this.txtdbName.Text.Trim()))
            {
                flag = false;
                message = message + "数据库名不能为空 <br/>";
            }
            if (string.IsNullOrWhiteSpace(this.txtdbLogin.Text.Trim()))
            {
                flag = false;
                message = message + "数据库用户名不能为空<br/>";
            }
            if (string.IsNullOrWhiteSpace(this.txtdbPassWord.Text.Trim()))
            {
                flag = false;
                message = message + "数据库登录密码不能为空 <br/>";
            }
            return flag;
        }

        protected void wizardInstaller_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            this.Page.Response.Redirect(base.ResolveUrl("~/"), true);
        }

        protected void wizardInstaller_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            string message;
            //第二步 创建数据库等相关信息
            if (e.CurrentStepIndex == 0)
            {
                if (!this.ValidateConnectionString(out message))
                {
                    this.ShowMessage(this.lblErrMessage, message);
                    e.Cancel = true;
                    return;
                }
                this.litPassword.Text = this.txtdbPassWord.Text;
                if (!this.TestConnection(out message))
                {
                    this.ShowMessage(this.lblErrMessage, message);
                    e.Cancel = true;
                    return;
                }

                HdImg.ImageUrl = "/Installer/images/i10.jpg";
            }
            //第三步 初始化用户信息
            if (e.CurrentStepIndex == 1)
            {
                if (!this.ValidateAdministrator(out message))
                {
                    this.ShowMessage(this.litSetpErrorMessage, message);
                    e.Cancel = true;
                    return;
                }
                //初始化DB
                if (!this.CreateInitData(out message))
                {
                    this.ShowMessage(this.litSetpErrorMessage, message);
                    e.Cancel = true;
                    return;
                }
                //创建管理员帐号
                if (!this.CreateSite(out message))
                {
                    this.ShowMessage(this.litSetpErrorMessage, message);
                    e.Cancel = true;
                    return;
                }
                //初始化demo数据
                else if (this.chkSample.Checked && File.Exists(Server.MapPath("/Installer/SqlScripts/SiteDemo.Sql")) && !this.CreateDemo(out message))
                {
                    this.ShowMessage(this.litSetpErrorMessage, message);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    //跳转之前先生成图片采集的工具
                   // YSWL.BLL.CMS.GenerateHtml.GenImageJs(YSWL.Components.MvcApplication.GetCurrentRoutePath(YSWL.Web.AreaRoute.SNS));

                    #region  初始化远程清理缓存地址
                    string clearurl = "http://" + Common.Globals.DomainFullName + "/ClearCache.aspx";
                    MALL.BLL.SysManage.ConfigSystem.Modify("Remote_ClearCache_Url", clearurl, "远程清理缓存URL地址");
                    #endregion 

                    //Session["Install"] = "Complete";
                    Response.Redirect("Complete.aspx?type=complete");
                }
            }
        }

        private string ConnectionString
        {
            get
            {
                string str = this.txtdbServer.Text.Trim();
                string str2 = this.txtdbPort.Text.Trim();
                if (str2 == "1433")
                {
                    str2 = null;
                }
                string str3 = this.txtdbName.Text.Trim();
                string str4 = this.txtdbLogin.Text.Trim();
                string text = this.litPassword.Text;
                return string.Format(CultureInfo.InvariantCulture, "server={0};uid={1};pwd={2};database={3}", new object[] { string.IsNullOrWhiteSpace(str2) ? str : (str + "," + str2), str4, text, str3 });
            }
        }
    }
}