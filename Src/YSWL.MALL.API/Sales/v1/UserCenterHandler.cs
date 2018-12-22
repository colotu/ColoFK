using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using YSWL.Accounts.Bus;
using YSWL.MALL.BLL.Members;
using YSWL.MALL.BLL.Shop.Supplier;
using YSWL.Components.Handlers.API;
using YSWL.Json;
using YSWL.Json.RPC;
using YSWL.MALL.Model.Ms;
using System.Linq;
using YSWL.MALL.ViewModel.Order;
using YSWL.Components;

namespace YSWL.MALL.API.Sales.v1
{
    public partial class SalesHandler
    {
        private BLL.Members.Users userManage = new BLL.Members.Users();
        private BLL.Members.UsersExp userExpManage = new BLL.Members.UsersExp();
        YSWL.Accounts.Bus.User BLLUser = new User();
        #region 代用户注册
        [JsonRpcMethod("RepRegister", Idempotent = false)]
        [JsonRpcHelp("代用户注册")]
        public JsonObject RepRegister(int userId, string userName, string pwd, string trueName, string name, string phone, string celPhone, string qq, string email, int regionId, string address, string latitude, string longitude)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(celPhone) || string.IsNullOrWhiteSpace(pwd)) return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_ARGUMENT, ERROR_MSG_ARGUMENT));
            YSWL.MALL.Model.Members.Users currentUser = userManage.GetModel(userId);
            //您非业务员用户，您没有权限使用接口系统！
            if (currentUser.UserType != "SS" && !currentUser.UserType.StartsWith("Y"))
            {
                return new Result(ResultStatus.Failed,
                    Result.FormatFailed(ERROR_CODE_UNAUTHORIZED, ERROR_MSG_UNAUTHORIZED));
            }
            if (BLLUser.HasUserByUserName(userName))
            {
                return new Result(ResultStatus.Failed,
                    Result.FormatFailed("101", "用户名已存在"));
            }
            User newUser = new User();
            newUser.UserName = userName.Trim();
            newUser.NickName = trueName; //昵称名称相同
            newUser.Password = AccountsPrincipal.EncryptPassword(pwd);
            newUser.Phone = phone;
            newUser.TrueName = trueName;
            newUser.Activity = true;
            newUser.UserType = "UU";
            newUser.Style = 1;
            newUser.User_dateCreate = DateTime.Now;
            newUser.User_cLang = "zh-CN";
            //获取业务员ID
            newUser.EmployeeID = userId;
            newUser.Email = email;
            try
            {
                long enterpriseId = Common.Globals.SafeLong(YSWL.Common.CallContextHelper.GetAutoTag(), 0);
                int custUserId;
                if (MvcApplication.IsAutoConn)//判断处理是否需要同步SAAS账号
                {
                  
                    if (!YSWL.SAAS.BLL.SAASInfo.IsCanAddCust(enterpriseId))
                    {
                        return new Result(ResultStatus.Failed,
                 Result.FormatFailed("103", "您的客户数已经达到上限，请联系客服进行充值"));
                    }
                    custUserId = newUser.Create2SAAS(enterpriseId);
                }
                else
                {
                    custUserId = newUser.Create();
                }
                if (custUserId == -100)
                {
                    //用户已存在
                    return new Result(ResultStatus.Failed, Result.FormatFailed("101", "用户已存在!"));
                }
                else
                {
                    #region  清空客户缓存
                    YSWL.SAAS.BLL.SAASInfo.ClearCacheCusts(enterpriseId);
                    #endregion
                    //添加用户扩展表数据
                    BLL.Members.UsersExp ue = new BLL.Members.UsersExp();
                    ue.UserID = custUserId;
                    ue.BirthdayVisible = 0;
                    ue.BirthdayIndexVisible = false;
                    ue.ConstellationVisible = 0;
                    ue.ConstellationIndexVisible = false;
                    ue.NativePlaceVisible = 0;
                    ue.NativePlaceIndexVisible = false;
                    ue.RegionId = regionId;
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
                    ue.Address = address;
                    ue.QQ = qq;
                    //注册来源
                    ue.SourceType = (int)YSWL.MALL.Model.Members.Enum.SourceType.SalesMan;

                    ////绑定业务员ID
                    //if (newUser.EmployeeID > 0)
                    //{
                    //    YSWL.MALL.Model.Members.UsersExpModel usersExp = userExpManage.GetUsersExpModel(userId);
                    //    ue.SalesId = usersExp == null ? 0 : usersExp.SalesId;
                    //}
                    if (!ue.Add(ue))
                    {
                        userManage.Delete(custUserId);
                        userExpManage.Delete(custUserId);
                        return new Result(ResultStatus.Failed, "创建用户扩展数据失败");
                    }

                    #region 添加收货地址
                    YSWL.MALL.Model.Shop.Shipping.ShippingAddress shipModel = new YSWL.MALL.Model.Shop.Shipping.ShippingAddress();
                    shipModel.UserId = custUserId;
                    shipModel.Address = address;
                    shipModel.EmailAddress = newUser.Email;
                    shipModel.CelPhone = celPhone;
                    shipModel.ShipName = name;
                    shipModel.RegionId = regionId;
                    shipModel.IsDefault = true;
                    //坐标地址
                    if (!String.IsNullOrWhiteSpace(latitude))
                    {
                        shipModel.Latitude = Common.Globals.SafeDecimal(latitude, 0);
                    }
                    if (!String.IsNullOrWhiteSpace(longitude))
                    {
                        shipModel.Longitude = Common.Globals.SafeDecimal(longitude, 0);
                    }
                    _addressManage.Add(shipModel);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(string.Format(ERROR_MSG_LOG, Request.Headers[REQUEST_HEADER_METHOD], ex.Message), ex.StackTrace, Request);
                return new Result(ResultStatus.Error, ex);
            }
            return new Result(ResultStatus.Success, newUser.UserID);
        }

        //[JsonRpcMethod("UpdateMapInfo", Idempotent = false)]
        //[JsonRpcHelp("更新地图信息")]
        //public JsonObject UpdateMapInfo(int UserId, string Latitude, string Longitude, string address)
        //{
        //    YSWL.MALL.Model.Members.Users userModel = userManage.GetModel(UserId);
        //    if (userModel == null)
        //    {
        //        return new Result(ResultStatus.Failed, "该用户不存在");
        //    }
        //    YSWL.MALL.Model.Shop.Shipping.ShippingAddress model = _addressManage.GetModelByUserId(UserId);
        //    if (model == null || model.ShippingId <= 0)
        //    {
        //        return new Result(ResultStatus.Failed, "该用户暂无收货地址");
        //    }
        //    decimal latitude = Common.Globals.SafeDecimal(Latitude, 0);
        //    decimal longitude = Common.Globals.SafeDecimal(Longitude, 0);
        //    if (_addressManage.UpdateMapInfo(UserId, latitude, longitude, address))
        //    {
        //        return new Result(ResultStatus.Success, UserId);
        //    }
        //    return new Result(ResultStatus.Failed, "更新坐标地理位置失败！");
        //}
        #endregion

        #region 搜索用户

        [JsonRpcMethod("GetCustList", Idempotent = false)]
        [JsonRpcHelp("搜索用户")]
        public JsonObject GetCustList(int userId, string keyWord, int? page = 1, int pageNum = 30)
        {
            if (pageNum == 0)
            {
                pageNum = 10;
            }
            if (String.IsNullOrEmpty(page.ToString()))
            {
                page = 1;
            }
            //重置页面索引
            page = page.HasValue && page.Value > 1 ? page.Value : 1;
            //计算分页起始索引
            int startIndex = page.Value > 1 ? (page.Value - 1) * pageNum + 1 : 0;
            //计算分页结束索引
            int endIndex = page.Value > 1 ? startIndex + pageNum - 1 : pageNum;
            List<YSWL.MALL.Model.Members.Users> list = userManage.GetPageList(userId, 1, keyWord, startIndex, endIndex);//userBll.GetSearchListEx("UU", strWhere.ToString());
            JsonArray result = new JsonArray();
            JsonObject baseJson = null;
            foreach (var item in list)
            {
                baseJson = new JsonObject();
                baseJson.Put("userId", item.UserID);
                baseJson.Put("userName", item.UserName);
                baseJson.Put("nickName", item.NickName);
                baseJson.Put("trueName", item.TrueName);
                result.Add(baseJson);
            }
            return new Result(ResultStatus.Success, result);
        }
        #endregion

        #region 获取客户
        [JsonRpcMethod("GetCustomList", Idempotent = false)]
        [JsonRpcHelp("我的客户")]
        public JsonObject GetCustomList(int userId,string kw1 = "",string kw2="",string kw3 = "",string qq = "", string email="", string startdate="", int status = -1, int? page = 1, int pageNum = 30,bool isActiveCust=false)
        {
            //kw1  客户名称或联系电话    
            //kw2 联系人姓名或手机号
            //kw3 账号  
            if (pageNum == 0)
            {
                pageNum = 10;
            }
            if (String.IsNullOrEmpty(page.ToString()))
            {
                page = 1;
            }
            //重置页面索引
            page = page.HasValue && page.Value > 1 ? page.Value : 1;
            //计算分页起始索引
            int startIndex = page.Value > 1 ? (page.Value - 1) * pageNum + 1 : 0;
            //计算分页结束索引
            int endIndex = page.Value > 1 ? startIndex + pageNum - 1 : pageNum;
            DateTime? sdate = null;
            if (!String.IsNullOrWhiteSpace(startdate)) {
                sdate = Common.Globals.SafeDateTime(startdate, null);
            }
            List<YSWL.MALL.Model.Members.Users> userList = userManage.GetPageList(userId, status, sdate, kw1, kw2,kw3,qq,email, startIndex, endIndex, isActiveCust);// userManage.GetCustList(userId, IsAct, keyword);
            JsonArray result = new JsonArray();
            JsonObject baseJson = null;
            Model.Shop.Shipping.ShippingAddress shipAddressModel;
            if (userList != null)
            {
                DateTime now = DateTime.Now;
                DateTime mouth = new DateTime(now.Year, now.Month, 1);
                foreach (var item in userList)
                {
                    baseJson = new JsonObject();
                    baseJson.Put("userId", item.UserID);
                    baseJson.Put("userName", item.UserName);
                    baseJson.Put("nickName", item.NickName);
                    baseJson.Put("trueName", item.TrueName);
                    baseJson.Put("createdDate", item.User_dateCreate.HasValue ? item.User_dateCreate.Value.ToString("yyyy-MM-dd HH:mm:ss") : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    #region 收货地址
                    shipAddressModel = _addressManage.GetModelByUserId(item.UserID);
                    if (shipAddressModel == null) { shipAddressModel = new Model.Shop.Shipping.ShippingAddress(); }
                    baseJson.Put("regionId", shipAddressModel.RegionId);
                    baseJson.Put("regionFullName", shipAddressModel.RegionFullName);
                    baseJson.Put("address", shipAddressModel.Address);
                    baseJson.Put("latitude", shipAddressModel.Latitude);//纬度
                    baseJson.Put("longitude", shipAddressModel.Longitude);//经度
                    #endregion
                    baseJson.Put("todayOrderCount", _orderManage.GetRecordCount(string.Format("  BuyerID={0} AND  OrderStatus!=-1 and OrderType=1 and CreatedDate>='{1}'  ", item.UserID, now.Date)));//今日订单数  排除取消订单
                    baseJson.Put("monthOrderCount", _orderManage.GetRecordCount(string.Format("  BuyerID={0} AND  OrderStatus!=-1 and OrderType=1 and CreatedDate>='{1}' ", item.UserID, mouth.Date)));//本月订单数  排除取消订单
                    result.Add(baseJson);
                }
            }
            return new Result(ResultStatus.Success, result);
        }
        #endregion

        #region  获取地区地址
        [JsonRpcMethod("GetRegionList", Idempotent = false)]
        [JsonRpcHelp("地址列表")]
        public JsonObject GetRegionList(int regionId = 0)
        {
            List<YSWL.MALL.Model.Ms.Regions> AllRegionList = regionsBLL.GetModelList("");
            List<YSWL.MALL.Model.Ms.Regions> ProvinceList = AllRegionList.Where(c => c.Depth == 1).ToList();
            if (regionId > 0)
            {
                ProvinceList = ProvinceList.Where(c => c.RegionId == regionId).ToList();
            }
            if (ProvinceList == null)
            {
                return new Result(ResultStatus.Success, null);
            }
            JsonArray result = new JsonArray();
            JsonObject baseJson;
            foreach (Regions item in ProvinceList)
            {
                baseJson = new JsonObject();
                baseJson.Put("id", item.RegionId);
                baseJson.Put("name", item.RegionName);
                baseJson.Put("depth", item.Depth);
                baseJson.Put("childlist", GetDataByParentId(item.RegionId, AllRegionList));
                result.Add(baseJson);
            }
            return new Result(ResultStatus.Success, result);
        }

        private JsonArray GetDataByParentId(int ParentId, List<YSWL.MALL.Model.Ms.Regions> AllRegionList)
        {
            JsonObject currjson;
            JsonArray array = new JsonArray();
            List<YSWL.MALL.Model.Ms.Regions> list = AllRegionList.Where(c => c.ParentId == ParentId).ToList();
            if (list != null && list.Count > 0)
            {
                foreach (Regions item in list)
                {
                    currjson = new JsonObject();
                    currjson.Put("id", item.RegionId);
                    currjson.Put("name", item.RegionName);
                    currjson.Put("parentid", item.ParentId);
                    currjson.Put("depth", item.Depth);
                    currjson.Put("childlist", GetDataByParentId(item.RegionId, AllRegionList));
                    array.Add(currjson);
                }
            }
            return array;
        }

        #endregion

        #region 获取地区地址名称
        [JsonRpcMethod("GetRegionName", Idempotent = false)]
        [JsonRpcHelp("地区地址名称")]
        public JsonObject GetRegionName(int regionId = 0)
        {
            string name = regionsBLL.GetFullNameById4Cache(regionId);
            return new Result(ResultStatus.Success, name);
        }
        #endregion


        #region 获取客户资料
        [JsonRpcMethod("GetCustomInfo", Idempotent = false)]
        [JsonRpcHelp("获取客户资料")]
        public JsonObject GetCustomInfo(int UserId, int CustUserId)
        {
            if (!userManage.Exists(UserId, CustUserId))//不是当前用户的客户
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_ARGUMENT, ERROR_MSG_ARGUMENT));
            }
            YSWL.MALL.Model.Shop.Shipping.ShippingAddress shipAddressModel = _addressManage.GetModelByUserId(CustUserId);
            YSWL.MALL.Model.Members.UsersExpModel user = userExpManage.GetUsersModel(CustUserId);
            if (user == null)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_NODATA, ERROR_MSG_NODATA));
            }
            JsonObject json = new JsonObject();
            json.Put("userId", user.UserID);
            json.Put("userName", user.UserName);
            json.Put("trueName", user.TrueName);
            json.Put("phone", user.Phone);
            json.Put("email", user.Email);
            json.Put("qq", user.QQ);
            if (shipAddressModel == null)
            {
                shipAddressModel = new Model.Shop.Shipping.ShippingAddress();
            }
            json.Put("name", shipAddressModel.ShipName);
            json.Put("celPhone", shipAddressModel.CelPhone);
            json.Put("regionId", shipAddressModel.RegionId);
            json.Put("regionFullName", shipAddressModel.RegionFullName);
            json.Put("address", shipAddressModel.Address);
            json.Put("latitude", shipAddressModel.Latitude);
            json.Put("longitude", shipAddressModel.Longitude);
            return new Result(ResultStatus.Success, json);
        }
        #endregion

        #region 修改客户资料
        [JsonRpcMethod("UpdateCustInfo", Idempotent = false)]
        [JsonRpcHelp("修改客户资料")]
        public JsonObject UpdateCustInfo(int userId, int custUserId, string trueName, string name, string phone, string celPhone, string qq, string email, int regionId, string address, string latitude, string longitude)
        {
            User currentUser = new YSWL.Accounts.Bus.User(userId);
            if (currentUser == null)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_NODATA, ERROR_MSG_NODATA));
            }
            if (!userManage.Exists(userId, custUserId))//不是当前用户的客户
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_ARGUMENT, ERROR_MSG_ARGUMENT));
            }
            JsonObject json = new JsonObject();
            Model.Members.UsersExpModel model = userExpManage.GetUsersModel(custUserId);
            if (model == null)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_NODATA, ERROR_MSG_NODATA));
            }
            //model.RegionId = regionId;
            //model.Address = address;
            model.QQ = qq;
            User custUser = new YSWL.Accounts.Bus.User(custUserId);
            custUser.Email = email;
            custUser.Phone = phone;
            custUser.TrueName = trueName;

            #region 更新收货地址
            YSWL.MALL.Model.Shop.Shipping.ShippingAddress shipModel = _addressManage.GetModelByUserId(custUserId);
            if (shipModel == null)
            {
                shipModel = new Model.Shop.Shipping.ShippingAddress();
            }
            shipModel.UserId = custUserId;
            shipModel.Address = address;
            shipModel.EmailAddress = email;
            shipModel.CelPhone = celPhone;
            shipModel.ShipName = name;
            shipModel.RegionId = regionId;
            if (!String.IsNullOrWhiteSpace(latitude))
            {
                shipModel.Latitude = Common.Globals.SafeDecimal(latitude, 0);
            }
            if (!String.IsNullOrWhiteSpace(longitude))
            {
                shipModel.Longitude = Common.Globals.SafeDecimal(longitude, 0);
            }
            #endregion
            if (custUser.Update() && userExpManage.Update(model) && _addressManage.UpdateEx(shipModel))
            {
                YSWL.Common.DataCache.DeleteCache("UsersExpModel-" + custUserId);
                YSWL.MALL.BLL.SysManage.LogHelp.AddUserLog(currentUser.UserName, currentUser.UserType, string.Format(" 【{1}】编辑了客户：【{0}】的资料  APP", custUser.UserName, currentUser.UserName));
                return new Result(ResultStatus.Success, custUserId);
            }
            else
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed("101", "更新失败!"));
            }
        }
        #endregion


        #region 客户业绩信息
        //[JsonRpcMethod("GetSalesInfo", Idempotent = false)]
        //[JsonRpcHelp("客户业绩信息")]
        //public JsonObject GetSalesInfo(int UserId)
        //{
        //    YSWL.MALL.BLL.Members.Users userBll = new Users();
        //    string startDay = DateTime.Now.ToString("yyyy-MM-dd");
        //    string endDay = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        //    string startMonth = DateTime.Now.ToString("yyyy-MM") + "-1";
        //    //日注册数
        //    int dayRegs = userBll.GetSalesRegs(UserId, startDay, endDay);
        //    //月注册数
        //    int monthRegs = userBll.GetSalesRegs(UserId, startMonth, endDay);
        //    //日业绩
        //    YSWL.MALL.ViewModel.Order.SalesCount daySales = YSWL.MALL.BLL.Shop.Order.OrderManage.GetSalesCount(UserId,
        //                                                                                                       startDay,
        //                                                                                                       endDay);

        //    //月业绩
        //    YSWL.MALL.ViewModel.Order.SalesCount monthSales = YSWL.MALL.BLL.Shop.Order.OrderManage.GetSalesCount(UserId,
        //                                                                                                       startMonth,
        //                                                                                                       endDay);
        //    JsonObject json = new JsonObject();
        //    json.Put("dayRegs", dayRegs);
        //    json.Put("monthRegs", monthRegs);
        //    json.Put("dayCount", daySales == null ? 0 : daySales.Count);
        //    json.Put("dayAmount", daySales == null ? 0 : daySales.Amount);
        //    json.Put("monthCount", monthSales == null ? 0 : monthSales.Count);
        //    json.Put("monthAmount", monthSales == null ? 0 : monthSales.Amount);
        //    return new Result(ResultStatus.Success, json);
        //}
        #endregion

        #region 注册数列表

        //[JsonRpcMethod("GetSalesRegList", Idempotent = false)]
        //[JsonRpcHelp("注册数列表")]
        //public JsonObject GetSalesRegList(int UserId, string startDate, string endDate)
        //{
        //    List<YSWL.MALL.ViewModel.Order.DayCount> countList = userManage.GetSalesRegList(UserId, startDate, endDate);
        //    JsonArray result = new JsonArray();
        //    JsonObject baseJson = null;
        //    if (countList != null)
        //    {
        //        foreach (var item in countList)
        //        {
        //            baseJson = new JsonObject();
        //            baseJson.Put("dateStr", item.DateStr);
        //            baseJson.Put("count", item.Count);
        //            result.Add(baseJson);
        //        }
        //    }

        //    return new Result(ResultStatus.Success, result);
        //}

        //[JsonRpcMethod("GetMonthRegList", Idempotent = false)]
        //[JsonRpcHelp("月注册数列表")]
        //public JsonObject GetMonthRegList(int UserId, string startDate, string endDate)
        //{
        //    List<YSWL.MALL.ViewModel.Order.DayCount> countList = userManage.GetSalesRegList(UserId, startDate, endDate, 1);
        //    JsonArray result = new JsonArray();
        //    JsonObject baseJson = null;
        //    if (countList != null)
        //    {
        //        countList = countList.OrderByDescending(c => c.DateStr).ToList();
        //        foreach (var item in countList)
        //        {
        //            baseJson = new JsonObject();
        //            baseJson.Put("dateStr", item.DateStr);
        //            baseJson.Put("count", item.Count);
        //            result.Add(baseJson);
        //        }
        //    }
        //    return new Result(ResultStatus.Success, result);
        //}

        #endregion

        #region 订单信息列表

        //[JsonRpcMethod("GetOrderSales", Idempotent = false)]
        //[JsonRpcHelp("订单信息列表")]
        //public JsonObject GetOrderSales(int UserId, string startDate, string endDate)
        //{

        //    List<YSWL.MALL.ViewModel.Order.DayCount> countList = YSWL.MALL.BLL.Shop.Order.OrderManage.GetOrderSales(UserId,
        //                                                                                                       startDate,
        //                                                                                                       endDate);
        //    JsonArray result = new JsonArray();
        //    JsonObject baseJson = null;
        //    if (countList != null)
        //    {
        //        foreach (var item in countList)
        //        {
        //            baseJson = new JsonObject();
        //            baseJson.Put("dateStr", item.DateStr);
        //            baseJson.Put("count", item.Count);
        //            baseJson.Put("amount", item.Amount);
        //            result.Add(baseJson);
        //        }
        //    }
        //    return new Result(ResultStatus.Success, result);
        //}

        //[JsonRpcMethod("GetMonthSales", Idempotent = false)]
        //[JsonRpcHelp("月订单信息列表")]
        //public JsonObject GetMonthSales(int UserId, string startDate, string endDate)
        //{

        //    List<YSWL.MALL.ViewModel.Order.DayCount> countList = YSWL.MALL.BLL.Shop.Order.OrderManage.GetOrderSales(UserId, startDate, endDate, 1);
        //    JsonArray result = new JsonArray();
        //    JsonObject baseJson = null;
        //    if (countList != null)
        //    {
        //        countList = countList.OrderByDescending(c => c.DateStr).ToList();
        //        foreach (var item in countList)
        //        {
        //            baseJson = new JsonObject();
        //            baseJson.Put("dateStr", item.DateStr);
        //            baseJson.Put("count", item.Count);
        //            baseJson.Put("amount", item.Amount);
        //            result.Add(baseJson);
        //        }
        //    }

        //    return new Result(ResultStatus.Success, result);
        //}
        #endregion


        BLL.Members.SiteMessage bllSM = new BLL.Members.SiteMessage();

        #region 系统消息
        [JsonRpcMethod("GetSysInfo", Idempotent = false)]
        [JsonRpcHelp("系统消息")]
        public JsonObject GetSysInfo(int userId, int? page = 1, int pageNum = 30)
        {
            if (pageNum == 0)
            {
                pageNum = 10;
            }
            if (String.IsNullOrEmpty(page.ToString()))
            {
                page = 1;
            }
            //重置页面索引
            page = page.HasValue && page.Value > 1 ? page.Value : 1;
            //计算分页起始索引
            int startIndex = page.Value > 1 ? (page.Value - 1) * pageNum + 1 : 0;
            //计算分页结束索引
            int endIndex = page.Value > 1 ? startIndex + pageNum - 1 : pageNum;

            YSWL.MALL.Model.Members.UsersExpModel user = userExpManage.GetUsersModel(userId);
            if (user == null)
            {
                return new Result(ResultStatus.Failed, Result.FormatFailed(ERROR_CODE_NODATA, ERROR_MSG_NODATA));
            }
            JsonArray result = new JsonArray();

            List<YSWL.MALL.Model.Members.SiteMessage> list = bllSM.GetAllSystemMsgListByPage(userId, -1, "", startIndex, endIndex);
            foreach (YSWL.MALL.Model.Members.SiteMessage item in list)
            {
                JsonObject json = new JsonObject();
                json.Put("id", item.ID);
                json.Put("title",item.Title);
                json.Put("content", item.Content);
                json.Put("isRead", item.ReceiverIsRead);
                json.Put("sendTime", item.SendTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                result.Add(json);
            }
            return new Result(ResultStatus.Success, result);
        }
        [JsonRpcMethod("UpdateSysInfo", Idempotent = false)]
        [JsonRpcHelp("更新消息状态")]
        public JsonObject UpdateSysInfo(int id)
        {
            if (id>0)
            {
                if (bllSM.SetReceiveMsgAlreadyRead(id) > 0)
                {
                    return new Result(ResultStatus.Success, "");
                }
                else {
                    return new Result(ResultStatus.Failed, "Failed");
                }
            }
            return new Result(ResultStatus.Failed, "IDISNULL");
        }
    #endregion


}
}
