using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web;
using YSWL.Accounts.Bus;
using YSWL.MALL.BLL.Shop.Coupon;
using YSWL.MALL.BLL.SysManage;
using YSWL.Common;
using YSWL.MALL.Model.Members;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Members;
using YSWL.MALL.Model.Shop.Order;
using YSWL.MALL.ViewModel.Member;
using YSWL.TaoBao.Domain;
using User = YSWL.Accounts.Bus.User;
#pragma warning disable 612

namespace YSWL.MALL.BLL.Members
{
    /// <summary>
    /// Users
    /// </summary>
    public partial class Users
    {
        private readonly IUsers dal = DAMembers.CreateUsers();
        public Users()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.Users model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Members.Users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {

            return dal.Delete(UserID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(UserIDlist,0) );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Members.Users GetModel(int UserID)
        {

            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Members.Users GetModelByCache(int UserID)
        {

            string CacheKey = "UsersModel-" + UserID;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Members.Users)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Members.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Members.Users> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Members.Users> modelList = new List<YSWL.MALL.Model.Members.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Members.Users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new YSWL.MALL.Model.Members.Users();
                    if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[n]["UserName"].ToString();
                    }
                    if (dt.Rows[n]["NickName"] != null && dt.Rows[n]["NickName"].ToString() != "")
                    {
                        model.NickName = dt.Rows[n]["NickName"].ToString();
                    }
                    if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                    {
                        model.Password = (byte[])dt.Rows[n]["Password"];
                    }
                    if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                    {
                        model.TrueName = dt.Rows[n]["TrueName"].ToString();
                    }
                    if (dt.Rows[n]["Sex"] != null && dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = dt.Rows[n]["Sex"].ToString();
                    }
                    if (dt.Rows[n]["Phone"] != null && dt.Rows[n]["Phone"].ToString() != "")
                    {
                        model.Phone = dt.Rows[n]["Phone"].ToString();
                    }
                    if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[n]["Email"].ToString();
                    }
                    if (dt.Rows[n]["EmployeeID"] != null && dt.Rows[n]["EmployeeID"].ToString() != "")
                    {
                        model.EmployeeID = int.Parse(dt.Rows[n]["EmployeeID"].ToString());
                    }
                    if (dt.Rows[n]["DepartmentID"] != null && dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentID = dt.Rows[n]["DepartmentID"].ToString();
                    }
                    if (dt.Rows[n]["Activity"] != null && dt.Rows[n]["Activity"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Activity"].ToString() == "1") || (dt.Rows[n]["Activity"].ToString().ToLower() == "true"))
                        {
                            model.Activity = true;
                        }
                        else
                        {
                            model.Activity = false;
                        }
                    }
                    if (dt.Rows[n]["UserType"] != null && dt.Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = dt.Rows[n]["UserType"].ToString();
                    }
                    if (dt.Rows[n]["Style"] != null && dt.Rows[n]["Style"].ToString() != "")
                    {
                        model.Style = int.Parse(dt.Rows[n]["Style"].ToString());
                    }
                    if (dt.Rows[n]["User_iCreator"] != null && dt.Rows[n]["User_iCreator"].ToString() != "")
                    {
                        model.User_iCreator = int.Parse(dt.Rows[n]["User_iCreator"].ToString());
                    }
                    if (dt.Rows[n]["User_dateCreate"] != null && dt.Rows[n]["User_dateCreate"].ToString() != "")
                    {
                        model.User_dateCreate = DateTime.Parse(dt.Rows[n]["User_dateCreate"].ToString());
                    }
                    if (dt.Rows[n]["User_dateValid"] != null && dt.Rows[n]["User_dateValid"].ToString() != "")
                    {
                        model.User_dateValid = DateTime.Parse(dt.Rows[n]["User_dateValid"].ToString());
                    }
                    if (dt.Rows[n]["User_dateExpire"] != null && dt.Rows[n]["User_dateExpire"].ToString() != "")
                    {
                        model.User_dateExpire = DateTime.Parse(dt.Rows[n]["User_dateExpire"].ToString());
                    }
                    if (dt.Rows[n]["User_iApprover"] != null && dt.Rows[n]["User_iApprover"].ToString() != "")
                    {
                        model.User_iApprover = int.Parse(dt.Rows[n]["User_iApprover"].ToString());
                    }
                    if (dt.Rows[n]["User_dateApprove"] != null && dt.Rows[n]["User_dateApprove"].ToString() != "")
                    {
                        model.User_dateApprove = DateTime.Parse(dt.Rows[n]["User_dateApprove"].ToString());
                    }
                    if (dt.Rows[n]["User_iApproveState"] != null && dt.Rows[n]["User_iApproveState"].ToString() != "")
                    {
                        model.User_iApproveState = int.Parse(dt.Rows[n]["User_iApproveState"].ToString());
                    }
                    if (dt.Rows[n]["User_cLang"] != null && dt.Rows[n]["User_cLang"].ToString() != "")
                    {
                        model.User_cLang = dt.Rows[n]["User_cLang"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method

        #region MethodEx
        /// <summary>
        /// 根据DepartmentID删除一条数据
        /// </summary>
        public bool DeleteByDepartmentID(int DepartmentID)
        {
            return dal.DeleteByDepartmentID(DepartmentID);
        }
        /// <summary>
        /// 根据DepartmentID批量删除数据
        /// </summary>
        public bool DeleteListByDepartmentID(string DepartmentIDlist)
        {
            return dal.DeleteListByDepartmentID(DepartmentIDlist);
        }

        public bool ExistByPhone(string Phone)
        {
            return dal.ExistByPhone(Phone);
        }

        /// <summary>
        /// 根据邮箱判断是否存在该记录
        /// </summary>
        public bool ExistsByEmail(string UserEmail)
        {
            return dal.ExistsByEmail(UserEmail);
        }

        /// <summary>
        ///根据用户输入的昵称是否存在
        /// </summary>
        public bool ExistsNickName(string nickname)
        {
            return dal.ExistsNickName(nickname);
        }

          /// <summary>
        ///根据用户ID判断昵称是否已被其他用户使用
        /// </summary>
        public bool ExistsNickName(int userid,string nickname)
        {
            return dal.ExistsNickName(userid,nickname);
        }
        #endregion

        public DataSet GetList(string type, string keyWord)
        {
            return dal.GetList(type, keyWord);
        }


        /// <summary>
        /// 根据DepartmentID批量删除数据
        /// </summary>
        public bool DeleteEx(int  userId)
        {
            return dal.DeleteEx(userId);
        }

        /// <summary>
        /// 获取用户信息和用户附件信息（普通用户）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public DataSet GetListEX(string keyWord)
        {
            return dal.GetListEX(keyWord);
        }
        public DataSet GetListEXByType(string type, string keyWord = "")
        {
            return dal.GetListEXByType(type, keyWord);
        }
        public DataSet GetSearchList(string type, string StrWhere = "")
        {
            return dal.GetSearchList(type, StrWhere);
        }

        public List<YSWL.MALL.Model.Members.Users> GetSearchListEx(string type, string StrWhere = "")
        {
            DataSet ds= dal.GetSearchList(type, StrWhere);
            return DataTableToList(ds.Tables[0]);
        }



        public bool UpdateFansAndFellowCount()
        {
            return dal.UpdateFansAndFellowCount();
        }

        public int GetUserIdByNickName(string NickName)
        {
            return dal.GetUserIdByNickName(NickName);
        }

        public string GetUserName(int userId)
        {
            return dal.GetUserName(userId);
        }
        public int  GetUserIdByDepartmentID(string DepartmentID)
        {
            return dal.GetUserIdByDepartmentID(DepartmentID);
        }
      
        public bool UpdateActiveStatus(string Ids, int ActiveType)
        {
            return dal.UpdateActiveStatus(Ids, ActiveType);
        }

        public int GetDefaultUserId()
        {
            return dal.GetDefaultUserId();
        }
        public string GetNickName(int userId)
        {
            return dal.GetNickName(userId);
        }


        public YSWL.MALL.Model.Members.Users GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

        public DataSet GetUserCount(StatisticMode mode, DateTime startDate, DateTime endDate)
        {
            return dal.GetUserCount(mode, startDate, endDate);
        }


        #region  查询业务员的客户信息
        public int GetCustCount(int userId)
        {
            return GetRecordCount(" UserType='UU' and  EmployeeID=" + userId);
        }
        //本月注册客户数
        public int GetCustCount(int userId,DateTime startTime,DateTime endTime)
        {
            return GetRecordCount (String.Format(" UserType='UU' and    EmployeeID={0} and  User_dateCreate >= '{1}' and  User_dateCreate <= '{2}' ",userId, startTime, endTime));
        }

        public DataSet GetCustList(int userId)
        {
            return GetList(" UserType='UU' and  EmployeeID=" + userId);
        }

        public List<YSWL.MALL.Model.Members.Users> GetCustList(int userId, int IsAct = -1, string KeyWord = "", string startDate = "")
        {
            if (String.IsNullOrWhiteSpace(startDate))
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
            }
            DataSet ds = dal.GetCustList(userId, IsAct, KeyWord);
            return DataTableToList(ds.Tables[0]);
        }
   
        #endregion 

        //查询业务员的
        public DataSet GetSalesList( )
        {
            return GetList(" UserType='SS' and Activity=1 ");
        }

       public bool ExistsUserName(int userid, string username)
        {
            return dal.ExistsUserName(userid, username);
        }
        /// <summary>
        /// 批量绑定业务员
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="salesId"></param>
        /// <returns></returns>
       public bool UpdateSales(string userIds, int salesId)
       {
           return dal.UpdateSales(userIds, salesId);
       }
        /// <summary>
        /// 用户注册统计--日期
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
       public DataSet GetDayRegCount(DateTime startDate, DateTime endDate, StatisticMode mode = StatisticMode.Day)
       {
           return dal.GetDayRegCount(startDate, endDate, mode);
       }
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       /// <param name="EmployeeID"></param>
       /// <param name="UserID"></param>
       /// <returns></returns>
       public bool Exists(int EmployeeID, int UserID)
       {
           return dal.Exists(EmployeeID, UserID);
       }

       #region 业务员新增注册数
       public  List<YSWL.MALL.ViewModel.Order.CustCount> SalesRegisters(DateTime startDay,
                                                                                   DateTime endDay)
       {
           DataSet ds = dal.SalesRegisters(startDay, endDay);
           int rowsCount = ds.Tables[0].Rows.Count;
           List<YSWL.MALL.ViewModel.Order.CustCount> orderCountList = new List<ViewModel.Order.CustCount>();
           if (rowsCount > 0)
           {
               var dt = ds.Tables[0];
               YSWL.MALL.ViewModel.Order.CustCount model = null;
               for (int n = 0; n < rowsCount; n++)
               {
                   model = new YSWL.MALL.ViewModel.Order.CustCount();
                   if (dt.Rows[n]["EmployeeID"] != null && dt.Rows[n]["EmployeeID"].ToString() != "")
                   {
                       model.SalesId = Int32.Parse(dt.Rows[n]["EmployeeID"].ToString());
                   }
                   if (dt.Rows[n]["Count"] != null && dt.Rows[n]["Count"].ToString() != "")
                   {
                       model.Count = Common.Globals.SafeInt(dt.Rows[n]["Count"], 0);
                   }
                   orderCountList.Add(model);
               }
               return orderCountList;
           }
           return null;
       }
        /// <summary>
        /// 获取业务员注册数
        /// </summary>
        /// <param name="SalesId"></param>
        /// <param name="startDay"></param>
        /// <param name="endDay"></param>
        /// <returns></returns>
       public int GetSalesRegs(int SalesId,string startDay,string endDay )
       {
           return dal.GetSalesRegs(SalesId,startDay, endDay);
       }

        public List<YSWL.MALL.ViewModel.Order.DayCount> GetSalesRegList(int SalesId, string startDay, string endDay, int dateType = 0)
        {
            DataSet ds = dal.GetSalesRegList(SalesId, startDay, endDay, dateType);
            int rowsCount = ds.Tables[0].Rows.Count;
            List<YSWL.MALL.ViewModel.Order.DayCount> dayCountList = new List<ViewModel.Order.DayCount>();
            if (rowsCount > 0)
            {
                var dt = ds.Tables[0];
                YSWL.MALL.ViewModel.Order.DayCount model = null;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new YSWL.MALL.ViewModel.Order.DayCount();
                    if (dt.Rows[n]["D"] != null && dt.Rows[n]["D"].ToString() != "")
                    {
                        model.DateStr = dt.Rows[n]["D"].ToString();
                    }
                    if (dt.Rows[n]["UserCount"] != null && dt.Rows[n]["UserCount"].ToString() != "")
                    {
                        model.Count = Common.Globals.SafeInt(dt.Rows[n]["UserCount"], 0);
                    }
                    dayCountList.Add(model);
                }
                return dayCountList;
            }
            return null;
        }



        public List<YSWL.MALL.ViewModel.Member.UserPosition> GetUserPositionList(int regionId, int supplierId)
        {
            DataSet ds = dal.GetShopByRegion(regionId,supplierId);
            List<YSWL.MALL.ViewModel.Member.UserPosition> userPositions=new List<UserPosition>();
            YSWL.MALL.ViewModel.Member.UserPosition userPosition;
            YSWL.MALL.Model.Members.Users model;
            if (!DataSetTools.DataSetIsNull(ds))
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int n=0;n<dt.Rows.Count;n++)
                    {
                        userPosition = new UserPosition();
                        model=new Model.Members.Users();
                        //if (dt.Rows[n]["UserID"] != null && dt.Rows[n]["UserID"].ToString() != "")
                        //{
                        //    model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                        //}
                        if (dt.Rows[n]["UserName"] != null && dt.Rows[n]["UserName"].ToString() != "")
                        {
                            model.UserName = dt.Rows[n]["UserName"].ToString();
                        }
                        if (dt.Rows[n]["NickName"] != null && dt.Rows[n]["NickName"].ToString() != "")
                        {
                            model.NickName = dt.Rows[n]["NickName"].ToString();
                        }
                        //if (dt.Rows[n]["Password"] != null && dt.Rows[n]["Password"].ToString() != "")
                        //{
                        //    model.Password = (byte[])dt.Rows[n]["Password"];
                        //}
                        //if (dt.Rows[n]["TrueName"] != null && dt.Rows[n]["TrueName"].ToString() != "")
                        //{
                        //    model.TrueName = dt.Rows[n]["TrueName"].ToString();
                        //}
                        //if (dt.Rows[n]["Sex"] != null && dt.Rows[n]["Sex"].ToString() != "")
                        //{
                        //    model.Sex = dt.Rows[n]["Sex"].ToString();
                        //}
                        if (dt.Rows[n]["Phone"] != null && dt.Rows[n]["Phone"].ToString() != "")
                        {
                            model.Phone = dt.Rows[n]["Phone"].ToString();
                        }
                        //if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                        //{
                        //    model.Email = dt.Rows[n]["Email"].ToString();
                        //}
                        //if (dt.Rows[n]["EmployeeID"] != null && dt.Rows[n]["EmployeeID"].ToString() != "")
                        //{
                        //    model.EmployeeID = int.Parse(dt.Rows[n]["EmployeeID"].ToString());
                        //}
                        //if (dt.Rows[n]["DepartmentID"] != null && dt.Rows[n]["DepartmentID"].ToString() != "")
                        //{
                        //    model.DepartmentID = dt.Rows[n]["DepartmentID"].ToString();
                        //}
                        //if (dt.Rows[n]["Activity"] != null && dt.Rows[n]["Activity"].ToString() != "")
                        //{
                        //    if ((dt.Rows[n]["Activity"].ToString() == "1") || (dt.Rows[n]["Activity"].ToString().ToLower() == "true"))
                        //    {
                        //        model.Activity = true;
                        //    }
                        //    else
                        //    {
                        //        model.Activity = false;
                        //    }
                        //}
                        //if (dt.Rows[n]["UserType"] != null && dt.Rows[n]["UserType"].ToString() != "")
                        //{
                        //    model.UserType = dt.Rows[n]["UserType"].ToString();
                        //}
                        //if (dt.Rows[n]["Style"] != null && dt.Rows[n]["Style"].ToString() != "")
                        //{
                        //    model.Style = int.Parse(dt.Rows[n]["Style"].ToString());
                        //}
                        //if (dt.Rows[n]["User_iCreator"] != null && dt.Rows[n]["User_iCreator"].ToString() != "")
                        //{
                        //    model.User_iCreator = int.Parse(dt.Rows[n]["User_iCreator"].ToString());
                        //}
                        //if (dt.Rows[n]["User_dateCreate"] != null && dt.Rows[n]["User_dateCreate"].ToString() != "")
                        //{
                        //    model.User_dateCreate = DateTime.Parse(dt.Rows[n]["User_dateCreate"].ToString());
                        //}
                        //if (dt.Rows[n]["User_dateValid"] != null && dt.Rows[n]["User_dateValid"].ToString() != "")
                        //{
                        //    model.User_dateValid = DateTime.Parse(dt.Rows[n]["User_dateValid"].ToString());
                        //}
                        //if (dt.Rows[n]["User_dateExpire"] != null && dt.Rows[n]["User_dateExpire"].ToString() != "")
                        //{
                        //    model.User_dateExpire = DateTime.Parse(dt.Rows[n]["User_dateExpire"].ToString());
                        //}
                        //if (dt.Rows[n]["User_iApprover"] != null && dt.Rows[n]["User_iApprover"].ToString() != "")
                        //{
                        //    model.User_iApprover = int.Parse(dt.Rows[n]["User_iApprover"].ToString());
                        //}
                        //if (dt.Rows[n]["User_dateApprove"] != null && dt.Rows[n]["User_dateApprove"].ToString() != "")
                        //{
                        //    model.User_dateApprove = DateTime.Parse(dt.Rows[n]["User_dateApprove"].ToString());
                        //}
                        //if (dt.Rows[n]["User_iApproveState"] != null && dt.Rows[n]["User_iApproveState"].ToString() != "")
                        //{
                        //    model.User_iApproveState = int.Parse(dt.Rows[n]["User_iApproveState"].ToString());
                        //}
                        //if (dt.Rows[n]["User_cLang"] != null && dt.Rows[n]["User_cLang"].ToString() != "")
                        //{
                        //    model.User_cLang = dt.Rows[n]["User_cLang"].ToString();
                        //}
                        userPosition.UserModel = model;
                        //以下是额外附加属性
                        if (dt.Rows[n]["Latitude"] != null && dt.Rows[n]["Latitude"].ToString() != "")
                        {
                            userPosition.Latitude = decimal.Parse(dt.Rows[n]["Latitude"].ToString());
                        }
                        if (dt.Rows[n]["Longitude"] != null && dt.Rows[n]["Longitude"].ToString() != "")
                        {
                            userPosition.Longitude = decimal.Parse(dt.Rows[n]["Longitude"].ToString());
                        }
                        if (dt.Rows[n]["RegionId"] != null && dt.Rows[n]["RegionId"].ToString() != "")
                        {
                            userPosition.RegionId = int.Parse(dt.Rows[n]["RegionId"].ToString());
                        }
                        if (dt.Rows[n]["ShopPhoto"] != null && dt.Rows[n]["ShopPhoto"].ToString() != "")
                        {
                            userPosition.ShopPhoto = dt.Rows[n]["ShopPhoto"].ToString();
                        }
                        userPositions.Add(userPosition);
                    }
                    return userPositions;
                }
            }
            return null;
        }

        public DataSet GetUserPositionDs(int regionId, int supplierId)
        {
            return dal.GetShopByRegion(regionId, supplierId);
        }
       #endregion

        #region 获取用户列表

        public List<YSWL.MALL.Model.Members.Users> GetPageList(string usertype, string q, int startIndex, int endIndex)
        {
             StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" UserType='{0}'  ", usertype);
            if (!String.IsNullOrWhiteSpace(q))
            {
                strWhere.AppendFormat(" and ( UserName like '%{0}%'   or  NickName like '%{0}%'  ) ", Common.InjectionFilter.SqlFilter(q));
            }
             DataSet ds = dal.GetListByPage(strWhere.ToString(), " UserId desc ", startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }

        public List<YSWL.MALL.Model.Members.Users> GetPageListByEmail(string usertype, string q, int startIndex, int endIndex)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" UserType='{0}'  ", usertype);
            if (!String.IsNullOrWhiteSpace(q))
            {
                strWhere.AppendFormat(" and  Email like '%{0}%'  ", Common.InjectionFilter.SqlFilter(q));
            }
            DataSet ds = dal.GetListByPage(strWhere.ToString(), " UserId desc ", startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }

        public List<YSWL.MALL.Model.Members.Users> GetPageListByPhone(string usertype, string q, int startIndex, int endIndex)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" UserType='{0}'  ", usertype);
            if (!String.IsNullOrWhiteSpace(q))
            {
                strWhere.AppendFormat(" and  Phone like '%{0}%'  ", Common.InjectionFilter.SqlFilter(q));
            }
            DataSet ds = dal.GetListByPage(strWhere.ToString(), " UserId desc ", startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }


        public int GetTotalCount(string usertype, string q)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" UserType='{0}'  ", usertype);
            if (!String.IsNullOrWhiteSpace(q))
            {
                strWhere.AppendFormat(" and  ( UserName like '%{0}%'   or  NickName like '%{0}%'  ) ", Common.InjectionFilter.SqlFilter(q));
            }
            return GetRecordCount(strWhere.ToString());
        }

        /// <summary>
        /// 获取邀请的用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public YSWL.MALL.Model.Members.Users GetInviteUser(int userId)
        {
            return dal.GetInviteUser(userId);
        }
        /// <summary>
        /// 获取邀请用户的UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public  int GetInviteUserId(int userId)
        {
            YSWL.MALL.Model.Members.Users userModel = GetInviteUser(userId);
            return userModel == null ? 0 : userModel.UserID;
        }

        /// <summary>
        /// 注册赠送优惠券
        /// </summary>
        /// <param name="userInfo"></param>
        public  static void RegForCoupon(User userInfo)
        {
            //是否开启注册赠送优惠券
            bool isOpenForCoupon =
                YSWL.MALL.BLL.SysManage.ConfigSystem.GetBoolValueByCache("Shop_Register_OpenForCoupon");
            if (!isOpenForCoupon)
            {
                return;
            }
            CouponRule rule = new CouponRule();
            string ruleIds = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("Shop_Register_CouponRuleId");
            if (string.IsNullOrWhiteSpace(ruleIds)) return;

            YSWL.MALL.Model.SysManage.UserLog userLog = new YSWL.MALL.Model.SysManage.UserLog();
            userLog.UserName = userInfo.UserName;
            if (HttpContext.Current != null)
            {
                userLog.Url = HttpContext.Current.Request.Url.AbsoluteUri;
                userLog.UserIP = HttpContext.Current.Request.UserHostAddress;
            }
            string[] ruleIdArray = ruleIds.Split(new[] { ",", "，", "|" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ruleId in ruleIdArray)
            {
                int id = YSWL.Common.Globals.SafeInt(ruleId, 0);
                if (id == 0)
                {
                    continue;
                }
                Model.Shop.Coupon.CouponRule couponRuleModel = rule.GetModel(id);
                //判断优惠券规则是否可用
                if (couponRuleModel == null || couponRuleModel.Status != 1)
                {
                    continue;
                }
                if (couponRuleModel.Type == 2)
                {
                    couponRuleModel.StartDate = DateTime.Now.AddDays(couponRuleModel.DeferDay);
                    if (couponRuleModel.AvaType == 1 && couponRuleModel.StartDate.Month == DateTime.Now.Month)
                    {
                        couponRuleModel.StartDate = YSWL.Common.Globals.SafeDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM-01"), DateTime.Now);
                    }
                }
                YSWL.MALL.BLL.Shop.Coupon.CouponInfo couponInfo = new CouponInfo();
                //默认使用活动优惠券功能，注册用户即生成优惠券并分配
                bool result = couponInfo.GenActCoupon(couponRuleModel, userInfo.UserID,"",0,1);
                if (!result)
                {
                    userLog.OPInfo = string.Format("用户注册送优惠券失败,CouponRuleId：{0}", id);
                    YSWL.MALL.BLL.SysManage.UserLog.LogUserAdd(userLog);
                }
            }
        }


        public bool WeChatRegister(YSWL.WeChat.Model.Core.User userModel)
        {
               YSWL.Accounts.Bus.User userBusManage = new YSWL.Accounts.Bus.User();
            YSWL.WeChat.BLL.Core.User wUserBll = new WeChat.BLL.Core.User();
            YSWL.MALL.BLL.Members.UserInvite inviteBll = new YSWL.MALL.BLL.Members.UserInvite();
            //如果存在该用户名，先直接绑定，然后登录
            //直接登录
            if (userBusManage.HasUserByUserName(userModel.UserName))
            {
                YSWL.Accounts.Bus.User user = new YSWL.Accounts.Bus.User(userModel.UserName);
                if (user == null || user.UserID <= 0)
                {
                    return false;
                }
                userModel.UserId = user.UserID;
                if (!wUserBll.UpdateUser(userModel))
                {
                    return false;
                }
                #region 建立关联关系

                inviteBll.AddInvite(userModel.OpenId, userModel.UserName, user.UserID,user.UserName, user.NickName);
                #endregion

                return true;
            }

          
            User newUser = new User();
            //    int nextUserId = GetMaxId() + 1;
            newUser.UserName = userModel.UserName;// "wx" + nextUserId + new Random().Next(10, 99);
            newUser.NickName = string.IsNullOrWhiteSpace(userModel.NickName) ? userModel.UserName : userModel.NickName; //昵称名称相同
            newUser.Password = AccountsPrincipal.EncryptPassword(newUser.UserName);
            newUser.Email = "";
            newUser.Activity = true;
            newUser.UserType = "UU";
            newUser.Style = 1;
            newUser.Sex = userModel.Sex == 1 ? "1" : "0";
            newUser.User_dateCreate = DateTime.Now;
            newUser.User_cLang = "zh-CN";
            int userid = newUser.Create();
            if (userid == -100)
            {
                return false;
            }

            //添加用户扩展表数据
            BLL.Members.UsersExp ue = new BLL.Members.UsersExp();
            ue.UserID = userid;
            ue.BirthdayVisible = 0;
            ue.BirthdayIndexVisible = false;
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
            if (!ue.Add(ue))
            {
                Delete(userid);
                ue.Delete(userid);
                return false;
            }

            //绑定当前系统用户
            userModel.UserId = userid;
            if (!wUserBll.UpdateUser(userModel))
            {
                return false;
            }

            #region 建立关联关系

            inviteBll.AddInvite(userModel.OpenId, userModel.UserName, newUser.UserID, newUser.UserName,newUser.NickName);
            #endregion

            return true;
        }

        #endregion


        #region 获取SAAS用户信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="userType">SAAS用户类型：1 普通用户  2 管理员用户 3：业务员</param>
        /// <returns></returns>
        public YSWL.MALL.ViewModel.SAAS.UserInfo GetSAUserInfo(string userName, string passWord,int userType=1,long enterpriseId=0)
        {
            return dal.GetSAUserInfo(userName, passWord, userType, enterpriseId);
        }
       
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        ///  <param name="userType"></param>
        /// <param name="userId"></param>
        /// <param name="kw"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataSet GetListByPage(string kw, int startIndex, int endIndex, out int toalCount)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" UserType='UU' and  Activity=1");
            if (!String.IsNullOrWhiteSpace(kw))
            {
                strWhere.AppendFormat(" and  UserName like '%{0}%'  ", InjectionFilter.SqlFilter(kw));
            }
            toalCount = GetRecordCount(strWhere.ToString());
            if (toalCount == 0)
                return null;
            return dal.GetListByPage(strWhere.ToString(), " UserId desc ", startIndex, endIndex);
        }

        /// <summary>
        /// 获取业务员下的客户列表
        /// </summary>
        /// <param name="usertype"></param>
        /// <param name="q"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<YSWL.MALL.Model.Members.Users> GetPageList(int salesUserId,int status, string q, int startIndex, int endIndex)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" UserType='UU' and EmployeeID={0} ", salesUserId);
            if (!String.IsNullOrWhiteSpace(q))
            {
                strWhere.AppendFormat(" and ( UserName like '%{0}%'   or  TrueName  like '%{0}%'  ) ", Common.InjectionFilter.SqlFilter(q));
            }
            if (status == 1) {
                strWhere.Append(" and Activity=1 ");
            } else if (status ==0) {
                strWhere.Append(" and Activity=0 ");
            }
            DataSet ds = dal.GetListByPage(strWhere.ToString(), " UserId desc ", startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }



        /// <summary>
        /// 获取业务员下的客户列表
        /// </summary>
        /// <param name="salesUserId"></param>
        /// <param name="status"></param>
        /// <param name="kw1">客户名称或联系电话 </param>
        /// <param name="kw2">联系人姓名或手机号</param>
        /// <param name="kw3">账号</param>
        /// <param name="qq"></param>
        /// <param name="email"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="isActiveCust">是活跃客户</param>
        /// <returns></returns>
        public List<YSWL.MALL.Model.Members.Users> GetPageList(int salesUserId, int status, DateTime?  startDate, string kw1, string kw2, string kw3, string qq, string email,int startIndex, int endIndex,bool isActiveCust)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat(" UserType='UU'");
            if (salesUserId!=-1)
            {
                strWhere.AppendFormat("and EmployeeID={0}", salesUserId);
            }
            if (!String.IsNullOrWhiteSpace(kw1))
            {
                strWhere.AppendFormat(" and ( Phone  like '%{0}%'    or  TrueName  like '%{0}%'  ) ", Common.InjectionFilter.SqlFilter(kw1));
            }
            if (isActiveCust)
            {
                //是活跃客户
                strWhere.AppendFormat("  and exists (select  BuyerID  FROM  OMS_Orders O  where   OrderStatus <> -1 AND OrderType = 1   and   ReferID = '{0}' AND CreatedDate >= '{1}' and  T.UserId = O.BuyerID ) ", salesUserId, startDate.Value.Date);
            } else if (startDate.HasValue)
            {
                    strWhere.AppendFormat(" and  User_dateCreate>='{0}' ", startDate.Value.Date);
            }
           
            
            if (!String.IsNullOrWhiteSpace(kw2))
            {
                strWhere.AppendFormat(" and EXISTS   ( SELECT *  FROM  Shop_ShippingAddress WHERE ( ShipName LIKE '%{0}%' or CelPhone  LIKE '%{0}%' ) AND UserId=T.UserId) ", Common.InjectionFilter.SqlFilter(kw2));
            }
            if (!String.IsNullOrWhiteSpace(kw3))
            {
                strWhere.AppendFormat(" and UserName like '%{0}%'  ", Common.InjectionFilter.SqlFilter(kw3));
            }
            if (!String.IsNullOrWhiteSpace(email))
            {
                strWhere.AppendFormat(" and Email like '%{0}%'  ", Common.InjectionFilter.SqlFilter(email));
            }
            if (!String.IsNullOrWhiteSpace(qq))
            {
                strWhere.AppendFormat(" and EXISTS   ( SELECT *  FROM  Accounts_UsersExp WHERE  qq LIKE '%{0}%'  AND UserId=T.UserId) ", Common.InjectionFilter.SqlFilter(qq));
            }
            if (status == 1)
            {
                strWhere.Append(" and Activity=1 ");
            }
            else if (status == 0)
            {
                strWhere.Append(" and Activity=0 ");
            }
            DataSet ds = dal.GetListByPage(strWhere.ToString(), " UserId desc ", startIndex, endIndex);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 设置业务员信息
        /// </summary>
        /// <param name="salesId"></param>
        /// <param name="idlist"></param>
        /// <returns></returns>
        public bool SetSalesInfo(int salesId, string idlist)
        {
          //设置业务员之前，先补全UsersExp中的数据
            var idarry = idlist.Split(',');
            foreach (var idstr in idarry)
            {
                int userId = Common.Globals.SafeInt(idstr, 0);
                YSWL.MALL.BLL.Members.UsersExp usersExpBll = new YSWL.MALL.BLL.Members.UsersExp();
                YSWL.MALL.Model.Members.UsersExpModel model = null;
                if (!usersExpBll.Exists(userId))
                {
                    model=new UsersExpModel();
                    model.UserID = userId;
                    model.BirthdayVisible = 0;
                    model.BirthdayIndexVisible = false;
                    model.ConstellationVisible = 0;
                    model.ConstellationIndexVisible = false;
                    model.NativePlaceVisible = 0;
                    model.NativePlaceIndexVisible = false;
                    model.RegionId = 0;
                    model.AddressVisible = 0;
                    model.AddressIndexVisible = false;
                    model.BodilyFormVisible = 0;
                    model.BodilyFormIndexVisible = false;
                    model.BloodTypeVisible = 0;
                    model.BloodTypeIndexVisible = false;
                    model.MarriagedVisible = 0;
                    model.MarriagedIndexVisible = false;
                    model.PersonalStatusVisible = 0;
                    model.PersonalStatusIndexVisible = false;
                    model.LastAccessIP = "";
                    model.LastAccessTime = DateTime.Now;
                    model.LastLoginTime = DateTime.Now;
                    model.LastPostTime = DateTime.Now;
                    //注册来源
                    model.SourceType = (int)YSWL.MALL.Model.Members.Enum.SourceType.SAAS;
                    usersExpBll.Add(model);
                }
            }

            return dal.SetSalesInfo(salesId, idlist);
        }

        /// <summary>
        /// 获取缓存客户数
        /// </summary>
        /// <returns></returns>
        public static int GetCacheCusts()
        {
            YSWL.Common.DataCacheCore coreBll = new DataCacheCore(new CacheOption
            {
                CacheType = CacheType.Redis,
                CancelProductKey = true
            });
            YSWL.MALL.BLL.Members.Users userBll = new Users();
            string CacheKey = "SAAS_EnterpriseCusts_" + Common.CallContextHelper.GetClearTag();
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = userBll.GetRecordCount("UserType='UU'");//获取客户数
                    if (objModel != null)
                    {
                        int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("ModelCache");
                        coreBll.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return Common.Globals.SafeInt(objModel, 0);
        }

        /// <summary>
        /// 获取缓存客户数
        /// </summary>
        /// <returns></returns>
        public static int GetCacheSales()
        {
            YSWL.Common.DataCacheCore coreBll = new DataCacheCore(new CacheOption
            {
                CacheType = CacheType.Redis,
                CancelProductKey = true
            });
            YSWL.MALL.BLL.Members.Users userBll = new Users();
            string CacheKey = "SAAS_EnterpriseSales_" + Common.CallContextHelper.GetClearTag();
            object objModel = coreBll.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = userBll.GetRecordCount("UserType='SS'");//获取员工数
                    if (objModel != null)
                    {
                        int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("ModelCache");
                        coreBll.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return Common.Globals.SafeInt(objModel, 0);
        }

        #endregion
        }
}

