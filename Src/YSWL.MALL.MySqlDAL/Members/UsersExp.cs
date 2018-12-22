using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using YSWL.MALL.Model.Members;
using YSWL.MALL.Model.Shop.Shipping;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 用户扩展类
    /// </summary>
    public partial class UsersExp : IUsersExp
    {
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("UserID", "Accounts_UsersExp");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UsersExp");
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)			};
            parameters[0].Value = UserID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.Members.UsersExpModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UsersExp(");
            strSql.Append("UserID,Gravatar,Singature,TelPhone,QQ,MSN,HomePage,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,RegionId,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Balance,Points,TopicCount,ReplyTopicCount,FavTopicCount,PvCount,FansCount,FellowCount,AblumsCount,FavouritesCount,FavoritedCount,ShareCount,ProductsCount,PersonalDomain,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Remark,IsUserDPI,PayAccount,UserCardCode,UserCardType,SourceType,SalesId)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?Gravatar,?Singature,?TelPhone,?QQ,?MSN,?HomePage,?Birthday,?BirthdayVisible,?BirthdayIndexVisible,?Constellation,?ConstellationVisible,?ConstellationIndexVisible,?NativePlace,?NativePlaceVisible,?NativePlaceIndexVisible,?RegionId,?Address,?AddressVisible,?AddressIndexVisible,?BodilyForm,?BodilyFormVisible,?BodilyFormIndexVisible,?BloodType,?BloodTypeVisible,?BloodTypeIndexVisible,?Marriaged,?MarriagedVisible,?MarriagedIndexVisible,?PersonalStatus,?PersonalStatusVisible,?PersonalStatusIndexVisible,?Grade,?Balance,?Points,?TopicCount,?ReplyTopicCount,?FavTopicCount,?PvCount,?FansCount,?FellowCount,?AblumsCount,?FavouritesCount,?FavoritedCount,?ShareCount,?ProductsCount,?PersonalDomain,?LastAccessTime,?LastAccessIP,?LastPostTime,?LastLoginTime,?Remark,?IsUserDPI,?PayAccount,?UserCardCode,?UserCardType,?SourceType,?SalesId)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?Gravatar", MySqlDbType.VarChar,200),
					new MySqlParameter("?Singature", MySqlDbType.VarChar,200),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,50),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,50),
					new MySqlParameter("?HomePage", MySqlDbType.VarChar,50),
					new MySqlParameter("?Birthday", MySqlDbType.DateTime),
					new MySqlParameter("?BirthdayVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BirthdayIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Constellation", MySqlDbType.VarChar,50),
					new MySqlParameter("?ConstellationVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?ConstellationIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?NativePlace", MySqlDbType.VarChar,300),
					new MySqlParameter("?NativePlaceVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?NativePlaceIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,300),
					new MySqlParameter("?AddressVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?AddressIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?BodilyForm", MySqlDbType.VarChar,10),
					new MySqlParameter("?BodilyFormVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BodilyFormIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?BloodType", MySqlDbType.VarChar,10),
					new MySqlParameter("?BloodTypeVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BloodTypeIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Marriaged", MySqlDbType.VarChar,10),
					new MySqlParameter("?MarriagedVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?MarriagedIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?PersonalStatus", MySqlDbType.VarChar,10),
					new MySqlParameter("?PersonalStatusVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?PersonalStatusIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Grade", MySqlDbType.Int32,4),
					new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyTopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavTopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?PvCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FansCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FellowCount", MySqlDbType.Int32,4),
					new MySqlParameter("?AblumsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavouritesCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavoritedCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ShareCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?PersonalDomain", MySqlDbType.VarChar,50),
					new MySqlParameter("?LastAccessTime", MySqlDbType.DateTime),
					new MySqlParameter("?LastAccessIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?LastPostTime", MySqlDbType.DateTime),
					new MySqlParameter("?LastLoginTime", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?IsUserDPI", MySqlDbType.Bit,1),
					new MySqlParameter("?PayAccount", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserCardCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserCardType", MySqlDbType.Int16,2),
					new MySqlParameter("?SourceType", MySqlDbType.Int32,4),
					new MySqlParameter("?SalesId", MySqlDbType.Int32,4)};
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
            parameters[54].Value = model.UserCardCode;
            parameters[55].Value = model.UserCardType;
            parameters[56].Value = model.SourceType;
            parameters[57].Value = model.SalesId;

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
        public bool Update(YSWL.MALL.Model.Members.UsersExpModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersExp set ");
            strSql.Append("Gravatar=?Gravatar,");
            strSql.Append("Singature=?Singature,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("QQ=?QQ,");
            strSql.Append("MSN=?MSN,");
            strSql.Append("HomePage=?HomePage,");
            strSql.Append("Birthday=?Birthday,");
            strSql.Append("BirthdayVisible=?BirthdayVisible,");
            strSql.Append("BirthdayIndexVisible=?BirthdayIndexVisible,");
            strSql.Append("Constellation=?Constellation,");
            strSql.Append("ConstellationVisible=?ConstellationVisible,");
            strSql.Append("ConstellationIndexVisible=?ConstellationIndexVisible,");
            strSql.Append("NativePlace=?NativePlace,");
            strSql.Append("NativePlaceVisible=?NativePlaceVisible,");
            strSql.Append("NativePlaceIndexVisible=?NativePlaceIndexVisible,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("Address=?Address,");
            strSql.Append("AddressVisible=?AddressVisible,");
            strSql.Append("AddressIndexVisible=?AddressIndexVisible,");
            strSql.Append("BodilyForm=?BodilyForm,");
            strSql.Append("BodilyFormVisible=?BodilyFormVisible,");
            strSql.Append("BodilyFormIndexVisible=?BodilyFormIndexVisible,");
            strSql.Append("BloodType=?BloodType,");
            strSql.Append("BloodTypeVisible=?BloodTypeVisible,");
            strSql.Append("BloodTypeIndexVisible=?BloodTypeIndexVisible,");
            strSql.Append("Marriaged=?Marriaged,");
            strSql.Append("MarriagedVisible=?MarriagedVisible,");
            strSql.Append("MarriagedIndexVisible=?MarriagedIndexVisible,");
            strSql.Append("PersonalStatus=?PersonalStatus,");
            strSql.Append("PersonalStatusVisible=?PersonalStatusVisible,");
            strSql.Append("PersonalStatusIndexVisible=?PersonalStatusIndexVisible,");
            strSql.Append("Grade=?Grade,");
            strSql.Append("Balance=?Balance,");
            strSql.Append("Points=?Points,");
            strSql.Append("TopicCount=?TopicCount,");
            strSql.Append("ReplyTopicCount=?ReplyTopicCount,");
            strSql.Append("FavTopicCount=?FavTopicCount,");
            strSql.Append("PvCount=?PvCount,");
            strSql.Append("FansCount=?FansCount,");
            strSql.Append("FellowCount=?FellowCount,");
            strSql.Append("AblumsCount=?AblumsCount,");
            strSql.Append("FavouritesCount=?FavouritesCount,");
            strSql.Append("FavoritedCount=?FavoritedCount,");
            strSql.Append("ShareCount=?ShareCount,");
            strSql.Append("ProductsCount=?ProductsCount,");
            strSql.Append("PersonalDomain=?PersonalDomain,");
            strSql.Append("LastAccessTime=?LastAccessTime,");
            strSql.Append("LastAccessIP=?LastAccessIP,");
            strSql.Append("LastPostTime=?LastPostTime,");
            strSql.Append("LastLoginTime=?LastLoginTime,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("IsUserDPI=?IsUserDPI,");
            strSql.Append("PayAccount=?PayAccount,");
            strSql.Append("UserCardCode=?UserCardCode,");
            strSql.Append("UserCardType=?UserCardType,");
            strSql.Append("SourceType=?SourceType,");
            strSql.Append("SalesId=?SalesId");
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Gravatar", MySqlDbType.VarChar,200),
					new MySqlParameter("?Singature", MySqlDbType.VarChar,200),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,50),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,50),
					new MySqlParameter("?HomePage", MySqlDbType.VarChar,50),
					new MySqlParameter("?Birthday", MySqlDbType.DateTime),
					new MySqlParameter("?BirthdayVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BirthdayIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Constellation", MySqlDbType.VarChar,50),
					new MySqlParameter("?ConstellationVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?ConstellationIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?NativePlace", MySqlDbType.VarChar,300),
					new MySqlParameter("?NativePlaceVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?NativePlaceIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,300),
					new MySqlParameter("?AddressVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?AddressIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?BodilyForm", MySqlDbType.VarChar,10),
					new MySqlParameter("?BodilyFormVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BodilyFormIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?BloodType", MySqlDbType.VarChar,10),
					new MySqlParameter("?BloodTypeVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BloodTypeIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Marriaged", MySqlDbType.VarChar,10),
					new MySqlParameter("?MarriagedVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?MarriagedIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?PersonalStatus", MySqlDbType.VarChar,10),
					new MySqlParameter("?PersonalStatusVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?PersonalStatusIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Grade", MySqlDbType.Int32,4),
					new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyTopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavTopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?PvCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FansCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FellowCount", MySqlDbType.Int32,4),
					new MySqlParameter("?AblumsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavouritesCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavoritedCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ShareCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?PersonalDomain", MySqlDbType.VarChar,50),
					new MySqlParameter("?LastAccessTime", MySqlDbType.DateTime),
					new MySqlParameter("?LastAccessIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?LastPostTime", MySqlDbType.DateTime),
					new MySqlParameter("?LastLoginTime", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?IsUserDPI", MySqlDbType.Bit,1),
					new MySqlParameter("?PayAccount", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserCardCode", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserCardType", MySqlDbType.Int16,2),
					new MySqlParameter("?SourceType", MySqlDbType.Int32,4),
					new MySqlParameter("?SalesId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Gravatar;
            parameters[1].Value = model.Singature;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.QQ;
            parameters[4].Value = model.MSN;
            parameters[5].Value = model.HomePage;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.BirthdayVisible;
            parameters[8].Value = model.BirthdayIndexVisible;
            parameters[9].Value = model.Constellation;
            parameters[10].Value = model.ConstellationVisible;
            parameters[11].Value = model.ConstellationIndexVisible;
            parameters[12].Value = model.NativePlace;
            parameters[13].Value = model.NativePlaceVisible;
            parameters[14].Value = model.NativePlaceIndexVisible;
            parameters[15].Value = model.RegionId;
            parameters[16].Value = model.Address;
            parameters[17].Value = model.AddressVisible;
            parameters[18].Value = model.AddressIndexVisible;
            parameters[19].Value = model.BodilyForm;
            parameters[20].Value = model.BodilyFormVisible;
            parameters[21].Value = model.BodilyFormIndexVisible;
            parameters[22].Value = model.BloodType;
            parameters[23].Value = model.BloodTypeVisible;
            parameters[24].Value = model.BloodTypeIndexVisible;
            parameters[25].Value = model.Marriaged;
            parameters[26].Value = model.MarriagedVisible;
            parameters[27].Value = model.MarriagedIndexVisible;
            parameters[28].Value = model.PersonalStatus;
            parameters[29].Value = model.PersonalStatusVisible;
            parameters[30].Value = model.PersonalStatusIndexVisible;
            parameters[31].Value = model.Grade;
            parameters[32].Value = model.Balance;
            parameters[33].Value = model.Points;
            parameters[34].Value = model.TopicCount;
            parameters[35].Value = model.ReplyTopicCount;
            parameters[36].Value = model.FavTopicCount;
            parameters[37].Value = model.PvCount;
            parameters[38].Value = model.FansCount;
            parameters[39].Value = model.FellowCount;
            parameters[40].Value = model.AblumsCount;
            parameters[41].Value = model.FavouritesCount;
            parameters[42].Value = model.FavoritedCount;
            parameters[43].Value = model.ShareCount;
            parameters[44].Value = model.ProductsCount;
            parameters[45].Value = model.PersonalDomain;
            parameters[46].Value = model.LastAccessTime;
            parameters[47].Value = model.LastAccessIP;
            parameters[48].Value = model.LastPostTime;
            parameters[49].Value = model.LastLoginTime;
            parameters[50].Value = model.Remark;
            parameters[51].Value = model.IsUserDPI;
            parameters[52].Value = model.PayAccount;
            parameters[53].Value = model.UserCardCode;
            parameters[54].Value = model.UserCardType;
            parameters[55].Value = model.SourceType;
            parameters[56].Value = model.SalesId;
            parameters[57].Value = model.UserID;

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
            strSql.Append("delete from Accounts_UsersExp ");
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
            strSql.Append("delete from Accounts_UsersExp ");
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
        public YSWL.MALL.Model.Members.UsersExpModel GetModel(int UserID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  UserID,Gravatar,Singature,TelPhone,QQ,MSN,HomePage,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,RegionId,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Balance,Points,TopicCount,ReplyTopicCount,FavTopicCount,PvCount,FansCount,FellowCount,AblumsCount,FavouritesCount,FavoritedCount,ShareCount,ProductsCount,PersonalDomain,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Remark,IsUserDPI,PayAccount,UserCardCode,UserCardType,SourceType,SalesId from Accounts_UsersExp ");
            strSql.Append(" where UserID=?UserID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)			};
            parameters[0].Value = UserID;

            YSWL.MALL.Model.Members.UsersExpModel model = new YSWL.MALL.Model.Members.UsersExpModel();
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
        public YSWL.MALL.Model.Members.UsersExpModel DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.UsersExpModel model = new YSWL.MALL.Model.Members.UsersExpModel();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["Gravatar"] != null)
                {
                    model.Gravatar = row["Gravatar"].ToString();
                }
                if (row["Singature"] != null)
                {
                    model.Singature = row["Singature"].ToString();
                }
                if (row["TelPhone"] != null)
                {
                    model.TelPhone = row["TelPhone"].ToString();
                }
                if (row["QQ"] != null)
                {
                    model.QQ = row["QQ"].ToString();
                }
                if (row["MSN"] != null)
                {
                    model.MSN = row["MSN"].ToString();
                }
                if (row["HomePage"] != null)
                {
                    model.HomePage = row["HomePage"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["BirthdayVisible"] != null && row["BirthdayVisible"].ToString() != "")
                {
                    model.BirthdayVisible = int.Parse(row["BirthdayVisible"].ToString());
                }
                if (row["BirthdayIndexVisible"] != null && row["BirthdayIndexVisible"].ToString() != "")
                {
                    if ((row["BirthdayIndexVisible"].ToString() == "1") || (row["BirthdayIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.BirthdayIndexVisible = true;
                    }
                    else
                    {
                        model.BirthdayIndexVisible = false;
                    }
                }
                if (row["Constellation"] != null)
                {
                    model.Constellation = row["Constellation"].ToString();
                }
                if (row["ConstellationVisible"] != null && row["ConstellationVisible"].ToString() != "")
                {
                    model.ConstellationVisible = int.Parse(row["ConstellationVisible"].ToString());
                }
                if (row["ConstellationIndexVisible"] != null && row["ConstellationIndexVisible"].ToString() != "")
                {
                    if ((row["ConstellationIndexVisible"].ToString() == "1") || (row["ConstellationIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.ConstellationIndexVisible = true;
                    }
                    else
                    {
                        model.ConstellationIndexVisible = false;
                    }
                }
                if (row["NativePlace"] != null)
                {
                    model.NativePlace = row["NativePlace"].ToString();
                }
                if (row["NativePlaceVisible"] != null && row["NativePlaceVisible"].ToString() != "")
                {
                    model.NativePlaceVisible = int.Parse(row["NativePlaceVisible"].ToString());
                }
                if (row["NativePlaceIndexVisible"] != null && row["NativePlaceIndexVisible"].ToString() != "")
                {
                    if ((row["NativePlaceIndexVisible"].ToString() == "1") || (row["NativePlaceIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.NativePlaceIndexVisible = true;
                    }
                    else
                    {
                        model.NativePlaceIndexVisible = false;
                    }
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["AddressVisible"] != null && row["AddressVisible"].ToString() != "")
                {
                    model.AddressVisible = int.Parse(row["AddressVisible"].ToString());
                }
                if (row["AddressIndexVisible"] != null && row["AddressIndexVisible"].ToString() != "")
                {
                    if ((row["AddressIndexVisible"].ToString() == "1") || (row["AddressIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.AddressIndexVisible = true;
                    }
                    else
                    {
                        model.AddressIndexVisible = false;
                    }
                }
                if (row["BodilyForm"] != null)
                {
                    model.BodilyForm = row["BodilyForm"].ToString();
                }
                if (row["BodilyFormVisible"] != null && row["BodilyFormVisible"].ToString() != "")
                {
                    model.BodilyFormVisible = int.Parse(row["BodilyFormVisible"].ToString());
                }
                if (row["BodilyFormIndexVisible"] != null && row["BodilyFormIndexVisible"].ToString() != "")
                {
                    if ((row["BodilyFormIndexVisible"].ToString() == "1") || (row["BodilyFormIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.BodilyFormIndexVisible = true;
                    }
                    else
                    {
                        model.BodilyFormIndexVisible = false;
                    }
                }
                if (row["BloodType"] != null)
                {
                    model.BloodType = row["BloodType"].ToString();
                }
                if (row["BloodTypeVisible"] != null && row["BloodTypeVisible"].ToString() != "")
                {
                    model.BloodTypeVisible = int.Parse(row["BloodTypeVisible"].ToString());
                }
                if (row["BloodTypeIndexVisible"] != null && row["BloodTypeIndexVisible"].ToString() != "")
                {
                    if ((row["BloodTypeIndexVisible"].ToString() == "1") || (row["BloodTypeIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.BloodTypeIndexVisible = true;
                    }
                    else
                    {
                        model.BloodTypeIndexVisible = false;
                    }
                }
                if (row["Marriaged"] != null)
                {
                    model.Marriaged = row["Marriaged"].ToString();
                }
                if (row["MarriagedVisible"] != null && row["MarriagedVisible"].ToString() != "")
                {
                    model.MarriagedVisible = int.Parse(row["MarriagedVisible"].ToString());
                }
                if (row["MarriagedIndexVisible"] != null && row["MarriagedIndexVisible"].ToString() != "")
                {
                    if ((row["MarriagedIndexVisible"].ToString() == "1") || (row["MarriagedIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.MarriagedIndexVisible = true;
                    }
                    else
                    {
                        model.MarriagedIndexVisible = false;
                    }
                }
                if (row["PersonalStatus"] != null)
                {
                    model.PersonalStatus = row["PersonalStatus"].ToString();
                }
                if (row["PersonalStatusVisible"] != null && row["PersonalStatusVisible"].ToString() != "")
                {
                    model.PersonalStatusVisible = int.Parse(row["PersonalStatusVisible"].ToString());
                }
                if (row["PersonalStatusIndexVisible"] != null && row["PersonalStatusIndexVisible"].ToString() != "")
                {
                    if ((row["PersonalStatusIndexVisible"].ToString() == "1") || (row["PersonalStatusIndexVisible"].ToString().ToLower() == "true"))
                    {
                        model.PersonalStatusIndexVisible = true;
                    }
                    else
                    {
                        model.PersonalStatusIndexVisible = false;
                    }
                }
                if (row["Grade"] != null && row["Grade"].ToString() != "")
                {
                    model.Grade = int.Parse(row["Grade"].ToString());
                }
                if (row["Balance"] != null && row["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(row["Balance"].ToString());
                }
                if (row["Points"] != null && row["Points"].ToString() != "")
                {
                    model.Points = int.Parse(row["Points"].ToString());
                }
                if (row["TopicCount"] != null && row["TopicCount"].ToString() != "")
                {
                    model.TopicCount = int.Parse(row["TopicCount"].ToString());
                }
                if (row["ReplyTopicCount"] != null && row["ReplyTopicCount"].ToString() != "")
                {
                    model.ReplyTopicCount = int.Parse(row["ReplyTopicCount"].ToString());
                }
                if (row["FavTopicCount"] != null && row["FavTopicCount"].ToString() != "")
                {
                    model.FavTopicCount = int.Parse(row["FavTopicCount"].ToString());
                }
                if (row["PvCount"] != null && row["PvCount"].ToString() != "")
                {
                    model.PvCount = int.Parse(row["PvCount"].ToString());
                }
                if (row["FansCount"] != null && row["FansCount"].ToString() != "")
                {
                    model.FansCount = int.Parse(row["FansCount"].ToString());
                }
                if (row["FellowCount"] != null && row["FellowCount"].ToString() != "")
                {
                    model.FellowCount = int.Parse(row["FellowCount"].ToString());
                }
                if (row["AblumsCount"] != null && row["AblumsCount"].ToString() != "")
                {
                    model.AblumsCount = int.Parse(row["AblumsCount"].ToString());
                }
                if (row["FavouritesCount"] != null && row["FavouritesCount"].ToString() != "")
                {
                    model.FavouritesCount = int.Parse(row["FavouritesCount"].ToString());
                }
                if (row["FavoritedCount"] != null && row["FavoritedCount"].ToString() != "")
                {
                    model.FavoritedCount = int.Parse(row["FavoritedCount"].ToString());
                }
                if (row["ShareCount"] != null && row["ShareCount"].ToString() != "")
                {
                    model.ShareCount = int.Parse(row["ShareCount"].ToString());
                }
                if (row["ProductsCount"] != null && row["ProductsCount"].ToString() != "")
                {
                    model.ProductsCount = int.Parse(row["ProductsCount"].ToString());
                }
                if (row["PersonalDomain"] != null)
                {
                    model.PersonalDomain = row["PersonalDomain"].ToString();
                }
                if (row["LastAccessTime"] != null && row["LastAccessTime"].ToString() != "")
                {
                    model.LastAccessTime = DateTime.Parse(row["LastAccessTime"].ToString());
                }
                if (row["LastAccessIP"] != null)
                {
                    model.LastAccessIP = row["LastAccessIP"].ToString();
                }
                if (row["LastPostTime"] != null && row["LastPostTime"].ToString() != "")
                {
                    model.LastPostTime = DateTime.Parse(row["LastPostTime"].ToString());
                }
                if (row["LastLoginTime"] != null && row["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(row["LastLoginTime"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["IsUserDPI"] != null && row["IsUserDPI"].ToString() != "")
                {
                    if ((row["IsUserDPI"].ToString() == "1") || (row["IsUserDPI"].ToString().ToLower() == "true"))
                    {
                        model.IsUserDPI = true;
                    }
                    else
                    {
                        model.IsUserDPI = false;
                    }
                }
                if (row["PayAccount"] != null)
                {
                    model.PayAccount = row["PayAccount"].ToString();
                }
                if (row["UserCardCode"] != null)
                {
                    model.UserCardCode = row["UserCardCode"].ToString();
                }
                if (row["UserCardType"] != null && row["UserCardType"].ToString() != "")
                {
                    model.UserCardType = int.Parse(row["UserCardType"].ToString());
                }
                if (row["SourceType"] != null && row["SourceType"].ToString() != "")
                {
                    model.SourceType = int.Parse(row["SourceType"].ToString());
                }
                if (row["SalesId"] != null && row["SalesId"].ToString() != "")
                {
                    model.SalesId = int.Parse(row["SalesId"].ToString());
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
            strSql.Append("select UserID,Gravatar,Singature,TelPhone,QQ,MSN,HomePage,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,RegionId,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Balance,Points,TopicCount,ReplyTopicCount,FavTopicCount,PvCount,FansCount,FellowCount,AblumsCount,FavouritesCount,FavoritedCount,ShareCount,ProductsCount,PersonalDomain,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Remark,IsUserDPI,PayAccount,UserCardCode,UserCardType,SourceType,SalesId ");
            strSql.Append(" FROM Accounts_UsersExp ");
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

            strSql.Append(" UserID,Gravatar,Singature,TelPhone,QQ,MSN,HomePage,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,RegionId,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Balance,Points,TopicCount,ReplyTopicCount,FavTopicCount,PvCount,FansCount,FellowCount,AblumsCount,FavouritesCount,FavoritedCount,ShareCount,ProductsCount,PersonalDomain,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Remark,IsUserDPI,PayAccount,UserCardCode,UserCardType,SourceType,SalesId ");
            strSql.Append(" FROM Accounts_UsersExp ");
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
            strSql.Append("select count(1) FROM Accounts_UsersExp ");
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
            strSql.Append("SELECT T.*  from Accounts_UsersExp T ");
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
            parameters[0].Value = "Accounts_UsersExp";
            parameters[1].Value = "UserID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region 扩展方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(int userID)
        {
            int rowsAffected = 0;
            MySqlParameter[] param = {
                                   new MySqlParameter("?UserID",MySqlDbType.Int32)
                                   };
            param[0].Value = userID;
            DbHelperMySQL.RunProcedure("sp_Accounts_CreateUserExp", param, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            } return false;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetUserList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(" * ");
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

        public bool UpdateFavouritesCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_UsersExp SET ");
            strSql.Append("FavouritesCount=( select COUNT(1) from SNS_UserFavourite where CreatedUserID=Accounts_UsersExp.UserID)");
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

        public bool UpdateProductCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_UsersExp SET ");
            strSql.Append("ProductsCount=(select COUNT(1) from SNS_Products where CreateUserID=Accounts_UsersExp.UserID)");
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

        public bool UpdateShareCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_UsersExp SET ");
            strSql.Append("ShareCount=ProductsCount+(select COUNT(1) from SNS_Photos where CreatedUserID=Accounts_UsersExp.UserID)");
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

        public bool UpdateAblumsCount()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_UsersExp SET ");
            strSql.Append("AblumsCount=(select COUNT(1) from SNS_UserAlbums where CreatedUserID=Accounts_UsersExp.UserID)");
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

        public int GetUserCountByKeyWord(string NickName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM  Accounts_Users au inner JOIN Accounts_UsersExp uea ON au.UserID=uea.UserID  ");
            if (!string.IsNullOrEmpty(NickName))
            {
                strSql.Append("AND NickName LIKE '%" + Common.InjectionFilter.SqlFilter(NickName) + "%'");
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
        public DataSet GetUserListByKeyWord(string NickName, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.*  FROM (SELECT uea.*,au.NickName FROM Accounts_Users au inner JOIN Accounts_UsersExp uea ON au.UserID=uea.UserID  ");
            if (!string.IsNullOrEmpty(NickName))
            {
                strSql.Append(" AND NickName LIKE ?NickName");
            }
            strSql.Append(" ) T ");

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" ORDER BY T." + orderby);
            }
            else
            {
                strSql.Append(" ORDER BY T.UserID desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);

            MySqlParameter[] parameters = {
                    new MySqlParameter("?NickName", MySqlDbType.VarChar)};
            parameters[0].Value = "%" + NickName + "%";
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否通过实名认证
        /// </summary>
        public bool UpdateIsDPI(string userIds, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE UE SET IsUserDPI={0} FROM Accounts_UsersExp UE, ", status);
            strSql.AppendFormat("(SELECT UserID FROM Accounts_UsersApprove WHERE ApproveID IN ({0}))AP ", userIds);
            strSql.Append("WHERE UE.UserID=AP.UserID ");

            return DbHelperMySQL.ExecuteSql(strSql.ToString()) > 0;
        }

        public bool UpdatePhoneAndPay(int userId, string account, string phone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Accounts_UsersExp set ");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("PayAccount=?PayAccount");
            strSql.Append(" where UserID=?UserID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?PayAccount", MySqlDbType.VarChar,200),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = phone;
            parameters[1].Value = account;
            parameters[2].Value = userId;

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

        public int GetUserRankId(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1)AS Count,SourceType  FROM  Accounts_UsersExp ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = UserId;
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
        /// 获取用户余额
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public decimal GetUserBalance(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  Balance FROM Accounts_UsersExp WHERE UserId=?UserId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = UserId;
            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }
        /// <summary>
        /// 获得指定用户ID的全部下属用户
        /// </summary>
        public DataSet GetAllEmpByUserId(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"
WITH    CTEGetChild
          AS ( SELECT   *
               FROM     Accounts_Users
               WHERE    EmployeeID = {0}
               UNION ALL
               ( SELECT a.*
                 FROM   Accounts_Users AS a
                        INNER JOIN CTEGetChild AS b ON a.EmployeeID = b.UserID
               )
             )
    SELECT  *
    FROM    CTEGetChild ORDER BY EmployeeID, UserID
", userId);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据 (用户表和邀请表)事物执行
        /// </summary>
        /// <param name="model"></param>
        /// <param name="inviteID">邀请者UserID</param>
        /// <param name="inviteNick">邀请者昵称</param>
        /// <param name="pointScore">影响积分</param>
        /// <param name="rankScore">影响成长值</param>
        /// <returns></returns>
        public bool AddEx(Model.Members.UsersExpModel model, int inviteID, string inviteNick, int pointScore, int rankScore)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Accounts_UsersExp(");
            strSql.Append("UserID,Gravatar,Singature,TelPhone,QQ,MSN,HomePage,Birthday,BirthdayVisible,BirthdayIndexVisible,Constellation,ConstellationVisible,ConstellationIndexVisible,NativePlace,NativePlaceVisible,NativePlaceIndexVisible,RegionId,Address,AddressVisible,AddressIndexVisible,BodilyForm,BodilyFormVisible,BodilyFormIndexVisible,BloodType,BloodTypeVisible,BloodTypeIndexVisible,Marriaged,MarriagedVisible,MarriagedIndexVisible,PersonalStatus,PersonalStatusVisible,PersonalStatusIndexVisible,Grade,Balance,Points,TopicCount,ReplyTopicCount,FavTopicCount,PvCount,FansCount,FellowCount,AblumsCount,FavouritesCount,FavoritedCount,ShareCount,ProductsCount,PersonalDomain,LastAccessTime,LastAccessIP,LastPostTime,LastLoginTime,Remark,IsUserDPI,PayAccount)");
            strSql.Append(" values (");
            strSql.Append("?UserID,?Gravatar,?Singature,?TelPhone,?QQ,?MSN,?HomePage,?Birthday,?BirthdayVisible,?BirthdayIndexVisible,?Constellation,?ConstellationVisible,?ConstellationIndexVisible,?NativePlace,?NativePlaceVisible,?NativePlaceIndexVisible,?RegionId,?Address,?AddressVisible,?AddressIndexVisible,?BodilyForm,?BodilyFormVisible,?BodilyFormIndexVisible,?BloodType,?BloodTypeVisible,?BloodTypeIndexVisible,?Marriaged,?MarriagedVisible,?MarriagedIndexVisible,?PersonalStatus,?PersonalStatusVisible,?PersonalStatusIndexVisible,?Grade,?Balance,?Points,?TopicCount,?ReplyTopicCount,?FavTopicCount,?PvCount,?FansCount,?FellowCount,?AblumsCount,?FavouritesCount,?FavoritedCount,?ShareCount,?ProductsCount,?PersonalDomain,?LastAccessTime,?LastAccessIP,?LastPostTime,?LastLoginTime,?Remark,?IsUserDPI,?PayAccount)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?Gravatar", MySqlDbType.VarChar,200),
					new MySqlParameter("?Singature", MySqlDbType.VarChar,200),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,20),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,30),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,30),
					new MySqlParameter("?HomePage", MySqlDbType.VarChar,50),
					new MySqlParameter("?Birthday", MySqlDbType.DateTime),
					new MySqlParameter("?BirthdayVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BirthdayIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Constellation", MySqlDbType.VarChar,10),
					new MySqlParameter("?ConstellationVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?ConstellationIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?NativePlace", MySqlDbType.VarChar,300),
					new MySqlParameter("?NativePlaceVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?NativePlaceIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?Address", MySqlDbType.VarChar,300),
					new MySqlParameter("?AddressVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?AddressIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?BodilyForm", MySqlDbType.VarChar,10),
					new MySqlParameter("?BodilyFormVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BodilyFormIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?BloodType", MySqlDbType.VarChar,10),
					new MySqlParameter("?BloodTypeVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?BloodTypeIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Marriaged", MySqlDbType.VarChar,10),
					new MySqlParameter("?MarriagedVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?MarriagedIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?PersonalStatus", MySqlDbType.VarChar,10),
					new MySqlParameter("?PersonalStatusVisible", MySqlDbType.Int16,2),
					new MySqlParameter("?PersonalStatusIndexVisible", MySqlDbType.Bit,1),
					new MySqlParameter("?Grade", MySqlDbType.Int32,4),
					new MySqlParameter("?Balance", MySqlDbType.Decimal,8),
					new MySqlParameter("?Points", MySqlDbType.Int32,4),
					new MySqlParameter("?TopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyTopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavTopicCount", MySqlDbType.Int32,4),
					new MySqlParameter("?PvCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FansCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FellowCount", MySqlDbType.Int32,4),
					new MySqlParameter("?AblumsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavouritesCount", MySqlDbType.Int32,4),
					new MySqlParameter("?FavoritedCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ShareCount", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductsCount", MySqlDbType.Int32,4),
					new MySqlParameter("?PersonalDomain", MySqlDbType.VarChar,50),
					new MySqlParameter("?LastAccessTime", MySqlDbType.DateTime),
					new MySqlParameter("?LastAccessIP", MySqlDbType.VarChar,50),
					new MySqlParameter("?LastPostTime", MySqlDbType.DateTime),
					new MySqlParameter("?LastLoginTime", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar),
					new MySqlParameter("?IsUserDPI", MySqlDbType.Bit,1),
					new MySqlParameter("?PayAccount", MySqlDbType.VarChar,200)};
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
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into Accounts_UserInvite(");
            strSql2.Append("UserId,UserNick,InviteUserId,InviteNick,IsRebate,IsNew,CreatedDate,RebateDesc)");
            strSql2.Append(" values (");
            strSql2.Append("?UserId,?UserNick,?InviteUserId,?InviteNick,?IsRebate,?IsNew,?CreatedDate,?RebateDesc)");
            strSql2.Append(";select @@IDENTITY");
            MySqlParameter[] parameters2 = {
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserNick", MySqlDbType.VarChar,200),
					new MySqlParameter("?InviteUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?InviteNick", MySqlDbType.VarChar,200),
					new MySqlParameter("?IsRebate", MySqlDbType.Bit,1),
					new MySqlParameter("?IsNew", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?RebateDesc", MySqlDbType.VarChar,200)};
            parameters2[0].Value = model.UserID;
            parameters2[1].Value = model.NickName;
            parameters2[2].Value = inviteID;
            parameters2[3].Value = inviteNick;
            parameters2[4].Value = true;
            parameters2[5].Value = true;
            parameters2[6].Value = DateTime.Now;
            parameters2[7].Value = string.Format("邀请用户+{0}积分,{1}成长值", pointScore, rankScore);
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rows = DbHelperMySQL.ExecuteSqlTran(sqllist);
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
        /// 更新客户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCustom(Model.Members.UsersExpModel model)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            #region 更新动作
            StringBuilder strSql = new StringBuilder();
            //更新自己的分享数据和商品数量
            strSql.Append("update Accounts_Users set ");
            strSql.Append("UserName=?UserName,");
            strSql.Append("Password=?Password,");
            strSql.Append("TrueName=?TrueName,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("Email=?Email,");
            strSql.Append("EmployeeID=?EmployeeID");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Password", MySqlDbType.Binary,20),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
                    new MySqlParameter("?EmployeeID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.EmployeeID;
            parameters[6].Value = model.UserID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //更新用户扩展信息
            StringBuilder strSql8 = new StringBuilder();
            strSql8.Append("Update Accounts_UsersExp set  Address=?Address  , RegionId=?RegionId,PersonalStatusIndexVisible=?PersonalStatusIndexVisible   ");
            strSql8.Append("  where  UserID=?UserID");
            MySqlParameter[] parameters8 = {
                                             	new MySqlParameter("?Address", MySqlDbType.VarChar,300),
                                                new MySqlParameter("?RegionId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
                     new MySqlParameter("?PersonalStatusIndexVisible",MySqlDbType.Bit,1)
                                         };
            parameters8[0].Value = model.Address;
            parameters8[1].Value = model.RegionId;
            parameters8[2].Value = model.UserID;
            parameters8[3].Value = model.PersonalStatusIndexVisible;
            cmd = new CommandInfo(strSql8.ToString(), parameters8);
            sqllist.Add(cmd);

            #endregion 更新动作

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 更新业务员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSales(Model.Members.UsersExpModel model)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            #region 更新动作
            StringBuilder strSql = new StringBuilder();
            //更新自己的分享数据和商品数量
            strSql.Append("update Accounts_Users set ");
            strSql.Append("UserName=?UserName,");
            strSql.Append("Password=?Password,");
            strSql.Append("TrueName=?TrueName,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("Email=?Email,");
            strSql.Append("EmployeeID=?EmployeeID");
            strSql.Append(" where UserID=?UserID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Password", MySqlDbType.Binary,20),
					new MySqlParameter("?TrueName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
                    new MySqlParameter("?EmployeeID", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.TrueName;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.EmployeeID;
            parameters[6].Value = model.UserID;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //更新用户扩展信息
            StringBuilder strSql8 = new StringBuilder();
            strSql8.Append("Update Accounts_UsersExp set  SalesId=?SalesId ");
            strSql8.Append("  where  UserID=?UserID");
            MySqlParameter[] parameters8 = {
                                             	new MySqlParameter("?SalesId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)
                                         };
            parameters8[0].Value = model.SalesId;
            parameters8[1].Value = model.UserID;
            cmd = new CommandInfo(strSql8.ToString(), parameters8);
            sqllist.Add(cmd);

            #endregion 更新动作

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否有该业务员
        /// </summary>
        /// <param name="SaleId"></param>
        /// <returns></returns>
        public bool HasSales(int SaleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_UsersExp");
            strSql.Append(" where SalesId=?SalesId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SalesId", MySqlDbType.Int32,4)			};
            parameters[0].Value = SaleId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据业务员编号 （原ERP 系统中的编号）
        /// </summary>
        /// <param name="SaleId"></param>
        /// <returns></returns>
        public YSWL.MALL.Model.Members.UsersExpModel GetSalesModel(int SaleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from Accounts_UsersExp ");
            strSql.Append(" where SalesId=?SalesId LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?SalesId", MySqlDbType.Int32,4)			};
            parameters[0].Value = SaleId;

            YSWL.MALL.Model.Members.UsersExpModel model = new YSWL.MALL.Model.Members.UsersExpModel();
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
        /// 用户注册来源统计
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet SourceCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1)AS Count,SourceType FROM  Accounts_Users U INNER JOIN   Accounts_UsersExp Ue ON U.UserID=Ue.UserID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("  GROUP BY SourceType ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public bool AddEx(UsersExpModel model, ShippingAddress addressModel)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQQ(int userId, string qq)
        {
            throw new NotImplementedException();
        }
        #endregion 扩展方法
    }
}