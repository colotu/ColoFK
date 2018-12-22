using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YSWL.Accounts.Bus;
using YSWL.MALL.BLL.Shop.Commission;
using YSWL.MALL.BLL.Shop.Order;
using YSWL.Common;
using YSWL.Components.Setting;
using YSWL.Json;
using YSWL.MALL.Model.Shop;
using YSWL.MALL.Model.Shop.Order;
using YSWL.MALL.Web.Components.Setting.Shop;
using Webdiyer.WebControls.Mvc;
using YSWL.MALL.BLL.Members;

namespace YSWL.MALL.Web.Areas.MShop.Controllers
{
    public partial class UserCenterController :  MShopControllerBaseUser
    {
        //
        // GET: /Mobile/UserCenter/
        private BLL.Members.PointsDetail detailBll = new BLL.Members.PointsDetail();
        private BLL.Members.RankDetail rankdetailBll = new BLL.Members.RankDetail();
        private BLL.Members.SiteMessage bllSM = new BLL.Members.SiteMessage();
        private BLL.Members.UsersExp userEXBll = new BLL.Members.UsersExp();
        private readonly BLL.Shop.Gift.ExchangeDetail exchangeBll = new BLL.Shop.Gift.ExchangeDetail();
        private readonly BLL.Shop.Coupon.CouponInfo infoBll = new BLL.Shop.Coupon.CouponInfo();
        private YSWL.MALL.BLL.Shop.Order.OrderAction actionBll = new BLL.Shop.Order.OrderAction();
        private readonly BLL.Pay.BalanceDetails balanDetaBll = new BLL.Pay.BalanceDetails();
        private readonly YSWL.MALL.BLL.Shop.Coupon.CouponRule ruleBll = new YSWL.MALL.BLL.Shop.Coupon.CouponRule();
        private YSWL.MALL.BLL.Members.UserCard cardBll = new BLL.Members.UserCard();
        private YSWL.MALL.BLL.Shop.Products.SKUInfo skuBll = new YSWL.MALL.BLL.Shop.Products.SKUInfo();
        BLL.Shop.Products.ProductInfo prodBll = new BLL.Shop.Products.ProductInfo();
        private readonly BLL.Shop.Commission.CommissionDetail comdetailBll = new BLL.Shop.Commission.CommissionDetail();
        private BLL.Members.UserInvite inviteBll = new BLL.Members.UserInvite();
        private readonly BLL.Shop.Supplier.SupplierInfo suppinfoBll = new BLL.Shop.Supplier.SupplierInfo();
        public ActionResult Index()
        {
            YSWL.MALL.Model.Members.UsersExpModel usersModel = userEXBll.GetUsersModel(CurrentUser.UserID);
            if (usersModel != null)
            {
                BLL.Members.UserRank userRankBll = new UserRank();

                //是否开启会员等级
               bool IsEnable = BLL.SysManage.ConfigSystem.GetBoolValueByCache("RankScoreEnable");
                if (IsEnable)
                {
                    usersModel.UserRank = userRankBll.GetRankInfo(usersModel.Grade.HasValue ? usersModel.Grade.Value : 0);
                }
                //会员等级
                ViewBag.RankScoreIsEnable = IsEnable;
               
                YSWL.MALL.BLL.Shop.Order.Orders orderBll = new Orders();
                ViewBag.Unpay = orderBll.GetUnPaidCounts(CurrentUser.UserID);//待付款
                ViewBag.UnShip = orderBll.GetUnShippingCountsByUserId(CurrentUser.UserID);//待发货订单数
                ViewBag.Unconsigneed = orderBll.GetUnReceiptByUserId(CurrentUser.UserID);//待收货订单数
                ViewBag.NoReadCount = bllSM.GetNoReadCount(currentUser.UserID);//获取未读消息数
                ViewBag.Exchanges = infoBll.GetRecordCount(String.Format(" UserID={0} and Status={1} and EndDate > '{2}'", currentUser.UserID, 1, System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
                #region 邀请信息
                BLL.Members.UserInvite userInviteBll = new BLL.Members.UserInvite();
                usersModel.UserInvite = userInviteBll.GetModelEx(CurrentUser.UserID);
                #endregion

                #region SEO 优化设置
                IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
                ViewBag.Title = "个人中心";//+ pageSetting.Title;
                ViewBag.Keywords = pageSetting.Keywords;
                ViewBag.Description = pageSetting.Description;
                #endregion
                
                Model.Shop.Supplier.SupplierInfo model = suppinfoBll.GetModel(Globals.SafeInt(CurrentUser.DepartmentID, -1));
                if (model != null)
                {
                    //商家状态
                    ViewBag.SuppStatus = model.Status;
                }
                return View(usersModel);
            }
            return Redirect(ViewBag.BasePath+"l/a");
        } 

        #region 用户个人资料

        public ActionResult Personal()
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "个人资料";// + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            Model.Members.UsersExpModel model = userEXBll.GetUsersModel(CurrentUser.UserID);
            if (null != model)
            {
                return View(model);
            }
            return Redirect(ViewBag.BasePath+"a/l");
           // return RedirectToAction("Login", "Account", new { id = 1, viewname = "url" });//去登录
        }
        #endregion 用户个人资料

        #region 用户密码

        public ActionResult ChangePassword()
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "修改密码"; //+ pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            return View();
        }

        #endregion 用户密码

        #region 检查用户原密码

        /// <summary>
        ///检查用户原密码
        /// </summary>
        [HttpPost]
        public void CheckPassword(FormCollection collection)
        {
                JsonObject json = new JsonObject();
                string password = collection["Password"];
                if (!string.IsNullOrWhiteSpace(password))
                {
                    SiteIdentity SID = new SiteIdentity(CurrentUser.UserName);
                    if (SID.TestPassword(password.Trim()) == 0)
                    {
                        json.Accumulate("STATUS", "ERROR");
                    }
                    else
                    {
                        json.Accumulate("STATUS", "OK");
                    }
                }
                else
                {
                    json.Accumulate("STATUS", "UNDEFINED");
                }
                Response.Write(json.ToString());
        }

        #endregion 检查用户原密码

        #region 更新用户密码

        /// <summary>
        /// 更新用户密码
        /// </summary>
        [HttpPost]
        public void UpdateUserPassword(FormCollection collection)
        {
                JsonObject json = new JsonObject();
                string newpassword = collection["NewPassword"];
                string confirmpassword = collection["ConfirmPassword"];
                if (!string.IsNullOrWhiteSpace(newpassword) && !string.IsNullOrWhiteSpace(confirmpassword))
                {
                    if (newpassword.Trim() != confirmpassword.Trim())
                    {
                        json.Accumulate("STATUS", "FAIL");
                    }
                    else
                    {
                        currentUser.Password = AccountsPrincipal.EncryptPassword(newpassword);
                        if (currentUser.Update())
                        {
                            json.Accumulate("STATUS", "UPDATESUCC");
                        }
                        else
                        {
                            json.Accumulate("STATUS", "UPDATEFAIL");
                        }
                    }
                }
                else
                {
                    json.Accumulate("STATUS", "UNDEFINED");
                }
                Response.Write(json.ToString());
        }

        #endregion 更新用户密码

        #region 更新用户信息

        /// <summary>
        /// 更新用户信息
        /// </summary>
        [HttpPost]
        [ValidateInput(false)]
        public void UpdateUserInfo(FormCollection collection)
        {
            JsonObject json = new JsonObject();
            Model.Members.UsersExpModel model = userEXBll.GetUsersModel(CurrentUser.UserID);
            model.TelPhone = collection["TelPhone"];
            string birthday = collection["Birthday"];
            if (!string.IsNullOrWhiteSpace(birthday) && PageValidate.IsDateTime(birthday))
            {
                model.Birthday = Globals.SafeDateTime(birthday, DateTime.Now);
            }
            else
            {
                model.Birthday = null;
            }
            model.LastLoginTime = DateTime.Now;
            model.Constellation = collection["Constellation"]; //星座
            model.PersonalStatus = collection["PersonalStatus"]; //职业
            model.Singature = collection["Singature"];
            model.RegionId = Common.Globals.SafeInt(collection["Address"],0);
            User currentUser = new YSWL.Accounts.Bus.User(CurrentUser.UserID);
            currentUser.Sex = collection["Sex"];
            currentUser.Email = collection["Email"];
            currentUser.NickName = collection["NickName"];
            currentUser.Phone = collection["Phone"];
            if (currentUser.Update(MvcApplication.IsAutoConn) && userEXBll.UpdateEx(model))
            {
                json.Accumulate("STATUS", "SUCC");
            }
            else
            {
                json.Accumulate("STATUS", "FAIL");
            }
            Response.Write(json.ToString());
    }

        #endregion 更新用户信息

        #region 检查用户输入的昵称是否被其他用户使用

        /// <summary>
        ///检查用户输入的昵称是否被其他用户使用
        /// </summary>
        [HttpPost]
        public void CheckNickName(FormCollection collection)
        {
            JsonObject json = new JsonObject();
            if (HttpContext.User.Identity.IsAuthenticated && CurrentUser != null && CurrentUser.UserType != "AA")
            {
                string nickname = collection["NickName"];
                if (!string.IsNullOrWhiteSpace(nickname))
                {
                    BLL.Members.Users bll = new BLL.Members.Users();
                    if (bll.ExistsNickName(CurrentUser.UserID, nickname))
                    {
                        json.Accumulate("STATUS", "EXISTS");
                    }
                    else
                    {
                        json.Accumulate("STATUS", "OK");
                    }
                }
                else
                {
                    json.Accumulate("STATUS", "NOTNULL");
                }
                Response.Write(json.ToString());
            }
            else
            {
                json.Accumulate("STATUS", "NOTNULL");
                Response.Write(json.ToString());
            }
        }

        #endregion 检查用户输入的昵称是否被其他用户使用

        #region 检查用户输入的昵称是否存在

        /// <summary>
        ///检查用户输入的昵称是否存在
        /// </summary>
        [HttpPost]
        public void ExistsNickName(FormCollection collection)
        {
            if (!HttpContext.User.Identity.IsAuthenticated || CurrentUser == null)
            {
                RedirectToAction(ViewBag.BasePath + "Account/Login");//去登录
            }
            else
            {
                JsonObject json = new JsonObject();
                string nickname = collection["NickName"];
                if (!string.IsNullOrWhiteSpace(nickname))
                {
                    BLL.Members.Users bll = new BLL.Members.Users();
                    if (bll.ExistsNickName(nickname))
                    {
                        json.Accumulate("STATUS", "EXISTS");
                    }
                    else
                    {
                        json.Accumulate("STATUS", "NOTEXISTS");
                    }
                }
                else
                {
                    json.Accumulate("STATUS", "NOTNULL");
                }
                Response.Write(json.ToString());
            }
        }

        #endregion 检查用户输入的昵称是否存在

        #region 积分明细

        public ActionResult PointsDetail(int pageIndex = 1)
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "积分明细";// + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            //首页用户数据
            YSWL.MALL.Model.Members.UsersExpModel userEXModel = userEXBll.GetUsersModel(CurrentUser.UserID);
            if (userEXModel != null)
            {
                ViewBag.UserInfo = userEXModel.Points.HasValue ? userEXModel.Points : 0 ;
                ViewBag.NickName = userEXModel.NickName;
            }
            int _pageSize = 8;

            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * _pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex * _pageSize;
            int toalCount = 0;

            //获取总条数
            toalCount = detailBll.GetRecordCount(" UserID=" + CurrentUser.UserID);
            if (toalCount < 1)
            {
                return View();//NO DATA
            }
            List<YSWL.MALL.Model.Members.PointsDetail> detailList = detailBll.GetListByPageEX("UserID=" + CurrentUser.UserID, "", startIndex, endIndex);
            if (detailList != null && detailList.Count > 0)
            {
                foreach (var item in detailList)
                {
                    item.RuleName = GetRuleName(item.RuleId);
                }
            }
            PagedList<YSWL.MALL.Model.Members.PointsDetail> lists = new PagedList<YSWL.MALL.Model.Members.PointsDetail>(detailList, pageIndex, _pageSize, toalCount);
            return View(lists);
        }

        public string GetRuleName(int RuleId)
        {
          
            YSWL.MALL.BLL.Members.PointsRule ruleBll = new BLL.Members.PointsRule();
            return ruleBll.GetRuleName(RuleId);
        }

        #endregion 积分明细

        #region 会员卡
        public ActionResult UserCard(int pageIndex = 1,string viewName="UserCard")
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "会员卡";// + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            //首页用户数据
            YSWL.MALL.Model.Members.UsersExpModel userEXModel = userEXBll.GetUsersModel(CurrentUser.UserID);
            if (userEXModel != null)
            {
                ViewBag.UserInfo = userEXModel;
                YSWL.MALL.Model.Members.UserCard cardModel= cardBll.GetModel(userEXModel.UserCardCode);
                ViewBag.Status = cardModel == null ? -1 : cardModel.Status;
            }
           
            int _pageSize = 8;
            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * _pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex * _pageSize;
            int toalCount = 0;

            //获取总条数
            toalCount = balanDetaBll.GetRecordCount(" UserId =" + CurrentUser.UserID);//获取总条数 
            if (toalCount < 1)
            {
                return PartialView(viewName);//NO DATA
            }
            List<YSWL.MALL.Model.Pay.BalanceDetails> list = balanDetaBll.GetListByPage(" UserId = " + CurrentUser.UserID, startIndex, endIndex);
            PagedList<YSWL.MALL.Model.Pay.BalanceDetails> lists = new PagedList<YSWL.MALL.Model.Pay.BalanceDetails>(list, pageIndex, _pageSize, toalCount);
            return View(lists);
        }

        [HttpPost]
        public ActionResult GetUserCard()
        {
           
            if (cardBll.AddCard(currentUser.UserID))
            {
                return Content("True");
            }
            return Content("False");
        }

        #endregion 

        #region 积分兑换明细
        /// <summary>
        /// 积分兑换明细
        /// </summary>
        /// <param name="p">pageIndex</param>
        /// <returns></returns>
        public ActionResult Exchanges(int p = 1)
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "积分兑换明细" + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            //首页用户数据
            YSWL.MALL.Model.Members.UsersExpModel userEXModel = userEXBll.GetUsersModel(CurrentUser.UserID);
            if (userEXModel != null)
            {
                ViewBag.UserInfo = userEXModel;
            }
            int _pageSize = 15;

            //计算分页起始索引
            int startIndex = p > 1 ? (p - 1) * _pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = p * _pageSize;
            int toalCount = 0;

            //获取总条数
            toalCount = exchangeBll.GetRecordCount(" UserID=" + CurrentUser.UserID);
            if (toalCount < 1)
            {
                return View();//NO DATA
            }
            List<YSWL.MALL.Model.Shop.Gift.ExchangeDetail> detailList = exchangeBll.GetListByPageEX("UserID=" + CurrentUser.UserID, " CreatedDate desc", startIndex, endIndex);

            PagedList<YSWL.MALL.Model.Shop.Gift.ExchangeDetail> lists = new PagedList<YSWL.MALL.Model.Shop.Gift.ExchangeDetail>(detailList, p, _pageSize, toalCount);
            return View(lists);
        }


        public PartialViewResult CouponRule(int top = 4, string viewName = "_CouponRule")
        {
            string strWhere = string.Format(" Type=1 and Status=1 and EndDate > '{0}'", System.DateTime.Now);

            List<YSWL.MALL.Model.Shop.Coupon.CouponRule> ruleList = ruleBll.GetModelList(strWhere);
            return PartialView(viewName, ruleList);
        }
        [HttpPost]
        public ActionResult AjaxExchange(int RuleId)
        {
            YSWL.MALL.Model.Shop.Coupon.CouponRule ruleModel = ruleBll.GetModel(RuleId);
            YSWL.MALL.Model.Members.UsersExpModel userEXModel = userEXBll.GetUsersModel(CurrentUser.UserID);
            if (ruleModel == null)
            {
                return Content("False");
            }
            if (ruleModel.NeedPoint > userEXModel.Points)
            {
                return Content("NoPoints");
            }
            if (ruleBll.GenCoupon(ruleModel, currentUser.UserID))
            {
                return Content("True");
            }
            return Content("False");
        }

        #endregion 积分兑换明细

        #region 我的优惠券

        public ActionResult MyCoupon(int p = 1)
        {
            int status = Common.Globals.SafeInt(Request.Params["s"], 1);

            int _pageSize = 15;

            //计算分页起始索引
            int startIndex = p > 1 ? (p - 1) * _pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = p * _pageSize;
            int toalCount = 0;

            //获取总条数
            toalCount = infoBll.GetRecordCount(String.Format(" UserID={0} and Status={1}", currentUser.UserID, status));
            if (toalCount < 1)
            {
                return View();//NO DATA
            }
            List<YSWL.MALL.Model.Shop.Coupon.CouponInfo> infoList = infoBll.GetListByPageEX(String.Format(" UserID={0} and Status={1}", currentUser.UserID, status), " GenerateTime desc", startIndex, endIndex);
            YSWL.MALL.BLL.Shop.Coupon.CouponClass classBll = new YSWL.MALL.BLL.Shop.Coupon.CouponClass();
            foreach (var Info in infoList)
            {
                YSWL.MALL.Model.Shop.Coupon.CouponClass classModel = classBll.GetModelByCache(Info.ClassId);
                Info.ClassName = classModel == null ? "" : classModel.Name;
            }
            PagedList<YSWL.MALL.Model.Shop.Coupon.CouponInfo> lists = new PagedList<YSWL.MALL.Model.Shop.Coupon.CouponInfo>(infoList, p, _pageSize, toalCount);
            return View(lists);
        }


        #endregion 

        #region 发站内信

        /// <summary>
        /// 发站内信
        /// </summary>
        /// <returns></returns>
        public ActionResult SendMessage()
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "发信息";//+ pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            ViewBag.Name = Request.Params["name"];
            return View("SendMessage");
        }

        #endregion 发站内信

        #region 发送站内信息

        /// <summary>
        /// 发送站内信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void SendMsg(FormCollection collection)
        {

            JsonObject json = new JsonObject();
            string nickname = Common.InjectionFilter.Filter(collection["NickName"]);
            string title = Common.InjectionFilter.Filter(collection["Title"]);
            string content = Common.InjectionFilter.Filter(collection["Content"]);
            if (string.IsNullOrWhiteSpace(nickname))
            {
                json.Accumulate("STATUS", "NICKNAMENULL");
            }
            else if (string.IsNullOrWhiteSpace(title))
            {
                json.Accumulate("STATUS", "TITLENULL");
            }
            else if (string.IsNullOrWhiteSpace(content))
            {
                json.Accumulate("STATUS", "CONTENTNULL");
            }
            else
            {
                BLL.Members.Users bll = new BLL.Members.Users();
                if (bll.ExistsNickName(nickname))
                {
                    int ReceiverID = bll.GetUserIdByNickName(nickname);
                    YSWL.MALL.Model.Members.SiteMessage modeSiteMessage = new YSWL.MALL.Model.Members.SiteMessage();
                    modeSiteMessage.Title = title;
                    modeSiteMessage.Content = content;
                    modeSiteMessage.SenderID = CurrentUser.UserID;
                    modeSiteMessage.ReaderIsDel = false;
                    modeSiteMessage.ReceiverIsRead = false;
                    modeSiteMessage.SenderIsDel = false;
                    modeSiteMessage.ReceiverID = ReceiverID;
                    modeSiteMessage.SendTime = DateTime.Now;
                    if (bllSM.Add(modeSiteMessage) > 0)
                    {
                        json.Accumulate("STATUS", "SUCC");
                    }
                    else
                    {
                        json.Accumulate("STATUS", "FAIL");
                    }
                }
                else
                {
                    json.Accumulate("STATUS", "NICKNAMENOTEXISTS");
                }
            }
            Response.Write(json.ToString());
        }

        #endregion 发送站内信息

        #region 回复站内信息

        /// <summary>
        /// 回复站内信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void ReplyMsg(int ReceiverID, string Title, string Content)
        {
            JsonObject json = new JsonObject();
            YSWL.MALL.Model.Members.SiteMessage modeSiteMessage = new YSWL.MALL.Model.Members.SiteMessage();
            modeSiteMessage.Title = Title;
            modeSiteMessage.Content = Content;
            modeSiteMessage.SenderID = CurrentUser.UserID;
            modeSiteMessage.ReaderIsDel = false;
            modeSiteMessage.ReceiverIsRead = false;
            modeSiteMessage.SenderIsDel = false;
            modeSiteMessage.ReceiverID = ReceiverID;
            modeSiteMessage.SendTime = DateTime.Now;
            if (bllSM.Add(modeSiteMessage) > 0)
                json.Accumulate("STATUS", "SUCC");
            else
                json.Accumulate("STATUS", "FAIL");
            Response.Write(json.ToString());
        }

        #endregion 回复站内信息

        #region 删除站内信息

        /// <summary>
        /// 删除收到的站内信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void DelReceiveMsg(int MsgID)
        {
            JsonObject json = new JsonObject();
            if (bllSM.SetReceiveMsgToDelById(MsgID, currentUser.UserID) > 0)
                json.Accumulate("STATUS", "SUCC");
            else
                json.Accumulate("STATUS", "FAIL");
            Response.Write(json.ToString());
        }

        #endregion 删除站内信息

        #region 读取站内信息
        /// <summary>
        /// 读取站内信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ReadMsg(int? MsgID)
        {
            if (MsgID.HasValue)
            {
                Model.Members.SiteMessage siteModel = bllSM.GetModelByCache(MsgID.Value);
                if (siteModel != null &&
                    ((siteModel.ReceiverID.HasValue && siteModel.ReceiverID.Value == currentUser.UserID) ||
                     (siteModel.SenderID.HasValue && siteModel.SenderID.Value == currentUser.UserID)))
                {
                    if (siteModel.SenderID == -1)
                        siteModel.SenderUserName = "管理员";//senderid为-1 的消息是管理员所发
                    else
                    {
                        Model.Members.UsersExpModel userexpmodel = null;
                        if (siteModel.SenderID.HasValue)
                            userexpmodel = userEXBll.GetUsersExpModelByCache(siteModel.SenderID.Value);//得到发送者的昵称
                        if (userexpmodel != null)
                            siteModel.SenderUserName = userexpmodel.NickName;
                    }
                  


                    if (siteModel.ReceiverIsRead == false)
                        bllSM.SetReceiveMsgAlreadyRead(siteModel.ID);//如果是消息状态是未读的，则改变消息状态
                    return View(siteModel);
                }
            }
            return RedirectToAction("Inbox","UserCenter");
        }
        #endregion 读取站内信息

        #region 收件箱

        /// <summary>
        /// 收件箱
        /// </summary>
        /// <returns></returns>
        public ActionResult Inbox(int page=1)
        {
            ViewBag.PageIndex = page;
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "收件箱";//+ pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            return View();
        }

        /// <summary>
        /// 收件箱
        /// </summary>
        /// <returns></returns>
        public PartialViewResult InboxList(int? page, string viewName = "_InboxList")
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "发件箱";// + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            page = page.HasValue && page.Value > 1 ? page.Value : 1;
            ViewBag.inboxpage = page;
            int pagesize = 10;
            PagedList<YSWL.MALL.Model.Members.SiteMessage> list = bllSM.GetAllReceiveMsgListByMvcPage(CurrentUser.UserID, pagesize, page.Value);
            //foreach (YSWL.MALL.Model.Members.SiteMessage item in list)
            //{
            //    if (item.ReceiverIsRead == false)
            //    {
            //        bllSM.SetReceiveMsgAlreadyRead(item.ID);
            //    }
            //}
            if (Request.IsAjaxRequest())
                return PartialView(viewName, list);
            return PartialView(viewName, list);
        }

        #endregion 收件箱

        #region 发件箱

        /// <summary>
        /// 发件箱
        /// </summary>
        /// <returns></returns>
        public ActionResult Outbox(int? page)
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "发件箱" + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            page = page.HasValue && page.Value > 1 ? page.Value : 1;
            int pagesize = 8;
            PagedList<YSWL.MALL.Model.Members.SiteMessage> list = bllSM.GetAllSendMsgListByMvcPage(CurrentUser.UserID, pagesize, page.Value);
            if (Request.IsAjaxRequest())
                return PartialView("_OutboxList", list);
            return View("OutBox", list);
        }

        #endregion 签到
   
        
        #region 用户签到
        public ActionResult SignPoint(int pageIndex = 1)
        {
            ViewBag.CanSign = Common.Globals.SafeBool(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("PointEnable"), true); ;
            PointsRule ruleBll = new PointsRule();
            Model.Members.PointsRule ruleModel = ruleBll.GetModel(10, CurrentUser.UserID);
            if (ruleModel == null)
            {
                ViewBag.CanSign = false;
            }
            if (detailBll.isLimit(ruleModel, CurrentUser.UserID))
            {
                ViewBag.CanSign = false;
            }
           
            //首页用户数据
            YSWL.MALL.Model.Members.UsersExpModel userEXModel = userEXBll.GetUsersModel(CurrentUser.UserID);
            if (userEXModel != null)
            {
                ViewBag.Points = userEXModel.Points.HasValue ? userEXModel.Points : 0;
                ViewBag.NickName = userEXModel.NickName;
            }
            int _pageSize = 8;
            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * _pageSize + 1 : 1;
            //计算分页结束索引
            int endIndex = pageIndex * _pageSize;
            int toalCount = 0;
            //获取总条数
            toalCount = detailBll.GetSignCount(CurrentUser.UserID);
            if (toalCount < 1)
            {
                return View();//NO DATA
            }
            List<YSWL.MALL.Model.Members.PointsDetail> detailList = detailBll.GetSignListByPage(CurrentUser.UserID, "", startIndex, endIndex);
            if (detailList != null && detailList.Count > 0)
            {
                foreach (var item in detailList)
                {
                    item.RuleName = GetRuleName(item.RuleId);
                }
            }
            PagedList<YSWL.MALL.Model.Members.PointsDetail> lists = new PagedList<YSWL.MALL.Model.Members.PointsDetail>(detailList, pageIndex, _pageSize, toalCount);
            return View(lists);
        }

        public ActionResult AjaxSign()
        {
            bool isEnable = Common.Globals.SafeBool(YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("PointEnable"), true);
            string isEnableRankScore = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("RankScoreEnable");
            if (!isEnable && isEnableRankScore != "true")
            {
                return Content("Enable");
            }
            PointsRule ruleBll = new PointsRule();
            RankRule rankruleBll = new RankRule();
            Model.Members.PointsRule ruleModel = ruleBll.GetModel(10, CurrentUser.UserID);
            Model.Members.RankRule rankruleModel = rankruleBll.GetModel(10, CurrentUser.UserID);
            if (ruleModel == null && rankruleModel==null)
            {
                return Content("NoRule");
            }
            if (detailBll.isLimit(ruleModel, CurrentUser.UserID) && rankdetailBll.isLimit(rankruleModel,CurrentUser.UserID))
            {
                return Content("Limit");
            }
            int points = detailBll.AddPoints(10, CurrentUser.UserID, "签到加积分");
            int rankScore = RankDetail.AddScore(10, CurrentUser.UserID, "签到");
            return Content(string.Format("{0}|{1}",points,rankScore));
        }
        #endregion 

        #region 订单列表
        public ActionResult Orders(string viewName = "Orders",string type="all")
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "我的订单-订单明细";// + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            ViewBag.orderType = type;
            #endregion
            return View(viewName);
        }
        public PartialViewResult OrderList(int pageIndex = 1,int pageSize=8, int state = 0, string viewName = "_OrderList")
        {
            #region RouteDataParam

            ViewBag.DataParam = String.Format("{0}state:'{1}'{2}", "{",state, "}");
            #endregion
            ViewBag.PageSize = pageSize;

            YSWL.MALL.BLL.Shop.Order.Orders orderBll = new Orders();
            YSWL.MALL.BLL.Shop.Order.OrderItems itemBll = new YSWL.MALL.BLL.Shop.Order.OrderItems();


            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex * pageSize;
            int toalCount = 0;

            string where = " BuyerID=" + CurrentUser.UserID +
#if true //方案二 统一提取主订单, 然后加载子订单信息 在View中根据订单支付状态和是否有子单对应展示
                //主订单
                           " AND OrderType=1";
#else   //方案一 提取数据时 过滤主/子单数据 View中无需对应 [由于不够灵活此方案作废]
                           //主订单 无子订单
                           " AND ((OrderType = 1 AND HasChildren = 0) " +
                           //子订单 已支付 或 货到付款/银行转账 子订单
                           "OR (OrderType = 2 AND (PaymentStatus > 1 OR (PaymentGateway='cod' OR PaymentGateway='bank')) ) " +
                           //主订单 有子订单 未支付的主订单 非 货到付款/银行转账 子订单
                           "OR (OrderType = 1 AND HasChildren = 1 AND PaymentStatus < 2 AND PaymentGateway<>'cod' AND PaymentGateway<>'bank'))";
#endif


            //获取订单类型
            switch (state)
            {
                //未付款
                case 1:
                    where += " AND PaymentStatus = 0 and OrderStatus<> -1 AND PaymentGateway<> 'cod' AND PaymentGateway<> 'bank'";
                    break;
                //未发货
                case 2:
                    where += " AND  ShippingStatus<2 AND OrderStatus!=-1  and ( ( PaymentStatus=2 and PaymentGateway<>'cod' ) or ( PaymentStatus=0 and PaymentGateway='cod') ) ";
                    break;
                //待收货 
                case 3:
                    where += " AND ShippingStatus=2 and OrderStatus=1 ";
                    break;
              
                //已完成
                case 4:
                    where += " AND OrderStatus=2 ";
                    break;
                default:
                    where += "";
                    break;
            }
            //获取总条数
            toalCount = orderBll.GetRecordCount(where);
            if (toalCount < 1)
            {
                return PartialView(viewName);//NO DATA
            }
            List<OrderInfo> orderList = orderBll.GetListByPageEX(where, "", startIndex, endIndex);
            if (orderList != null && orderList.Count > 0)
            {
                foreach (OrderInfo item in orderList)
                {
                    //有子订单 已支付 或 货到付款/银行转账 子订单 - 加载子单
                    if (item.HasChildren && (item.PaymentStatus > 1 || (item.PaymentGateway == "cod" || item.PaymentGateway == "bank")))
                    {
                        item.SubOrders = orderBll.GetModelList(" ParentOrderId=" + item.OrderId);
                        item.SubOrders.ForEach(
                            info => info.OrderItems = itemBll.GetModelList(" OrderId=" + info.OrderId));
                    }
                    else
                    {
                        item.OrderItems = itemBll.GetModelList(" OrderId=" + item.OrderId);
                    }
                }
            }
            PagedList<YSWL.MALL.Model.Shop.Order.OrderInfo> lists = new PagedList<YSWL.MALL.Model.Shop.Order.OrderInfo>(orderList, pageIndex, pageSize, toalCount);
            if (Request.IsAjaxRequest())
                return PartialView(viewName, lists);
            return PartialView(viewName, lists);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="sps">shippingStatus</param>
        /// <param name="pas">paymentStatus</param>
        /// <param name="viewName"></param>
        /// <returns></returns>
     public PartialViewResult GetListFromType(int pageIndex = 1,int sps=-1,int pas=-1, string viewName = "_OrderList")
     {
         YSWL.MALL.BLL.Shop.Order.Orders orderBll = new Orders();
         YSWL.MALL.BLL.Shop.Order.OrderItems itemBll = new YSWL.MALL.BLL.Shop.Order.OrderItems();

         int _pageSize = 8;

         //计算分页起始索引
         int startIndex = pageIndex > 1 ? (pageIndex - 1) * _pageSize + 1 : 1;

         //计算分页结束索引
         int endIndex = pageIndex * _pageSize;
         int toalCount = 0;

         string where = " BuyerID=" + CurrentUser.UserID +
#if true //方案二 统一提取主订单, 然后加载子订单信息 在View中根据订单支付状态和是否有子单对应展示
             //主订单
                        " AND OrderType=1";
#else   //方案一 提取数据时 过滤主/子单数据 View中无需对应 [由于不够灵活此方案作废]
                           //主订单 无子订单
                           " AND ((OrderType = 1 AND HasChildren = 0) " +
                           //子订单 已支付 或 货到付款/银行转账 子订单
                           "OR (OrderType = 2 AND (PaymentStatus > 1 OR (PaymentGateway='cod' OR PaymentGateway='bank')) ) " +
                           //主订单 有子订单 未支付的主订单 非 货到付款/银行转账 子订单
                           "OR (OrderType = 1 AND HasChildren = 1 AND PaymentStatus < 2 AND PaymentGateway<>'cod' AND PaymentGateway<>'bank'))";
#endif
         //未支付
         // PaymentStatus < 2 AND PaymentGateway<>'cod' AND PaymentGateway<>'bank'
         if (sps>-1)//
         {
             where += " And ShippingStatus=" + sps;
         }
        if (pas > -1)//支付状态暂时都取未支付的
        {
            where += " And  PaymentStatus < 2 AND PaymentGateway<>'cod' AND PaymentGateway<>'bank' And OrderStatus<>-1 ";
        }
            
         
         //获取总条数
         toalCount = orderBll.GetRecordCount(where);
         if (toalCount < 1)
         {
             return PartialView(viewName);//NO DATA
         }
         List<OrderInfo> orderList = orderBll.GetListByPageEX(where, "", startIndex, endIndex);
         if (orderList != null && orderList.Count > 0)
         {
             foreach (OrderInfo item in orderList)
             {
                 //有子订单 已支付 或 货到付款/银行转账 子订单 - 加载子单
                 if (item.HasChildren && (item.PaymentStatus > 1 || (item.PaymentGateway == "cod" || item.PaymentGateway == "bank")))
                 {
                     item.SubOrders = orderBll.GetModelList(" ParentOrderId=" + item.OrderId);
                     item.SubOrders.ForEach(
                         info => info.OrderItems = itemBll.GetModelList(" OrderId=" + info.OrderId));
                 }
                 else
                 {
                     item.OrderItems = itemBll.GetModelList(" OrderId=" + item.OrderId);
                 }
             }
         }
         PagedList<YSWL.MALL.Model.Shop.Order.OrderInfo> lists = new PagedList<YSWL.MALL.Model.Shop.Order.OrderInfo>(orderList, pageIndex, _pageSize, toalCount);
         if (Request.IsAjaxRequest())
             return PartialView(viewName, lists);
         return PartialView(viewName, lists);
     }

        #region 辅助方法

        public static string GetOrderType(string paymentGateway, int orderStatus, int paymentStatus, int shippingStatus)
        {
            string str = "";
            YSWL.MALL.BLL.Shop.Order.Orders orderBll = new Orders();
            EnumHelper.OrderMainStatus orderType = orderBll.GetOrderType(paymentGateway,
                                    orderStatus,
                                    paymentStatus,
                                    shippingStatus);
            switch (orderType)
            {
                //  订单组合状态 1 等待付款   | 2 等待处理 | 3 取消订单 | 4 订单锁定 | 5 等待付款确认 | 6 正在处理 |7 配货中  |8 已发货 |9  已完成
                case EnumHelper.OrderMainStatus.Paying:
                    str = "等待付款";
                    break;
                case EnumHelper.OrderMainStatus.PreHandle:
                    str = "等待处理";
                    break;
                case EnumHelper.OrderMainStatus.Cancel:
                    str = "取消订单";
                    break;
                case EnumHelper.OrderMainStatus.Locking:
                    str = "订单锁定";
                    break;
                case EnumHelper.OrderMainStatus.PreConfirm:
                    str = "等待付款确认";
                    break;
                case EnumHelper.OrderMainStatus.Handling:
                    str = "正在处理";
                    break;
                case EnumHelper.OrderMainStatus.Shipping:
                    str = "配货中";
                    break;
                case EnumHelper.OrderMainStatus.Shiped:
                    str = "已发货";
                    break;
                case EnumHelper.OrderMainStatus.Complete:
                    str = "已完成";
                    break;
                default:
                    str = "未知状态";
                    break;
            }
            return str;
        }
        public static EnumHelper.OrderMainStatus GetOrderMainStatus(string paymentGateway, int orderStatus, int paymentStatus, int shippingStatus)
        {
            Orders orderBll = new Orders();
            return orderBll.GetOrderType(paymentGateway,
                                    orderStatus,
                                    paymentStatus,
                                    shippingStatus);
        }
        #endregion
        #region Ajax方法
        [HttpPost]
        public ActionResult CancelOrder(FormCollection Fm)
        {
            YSWL.MALL.BLL.Shop.Order.Orders orderBll = new Orders();
            long orderId = Common.Globals.SafeLong(Fm["OrderId"], 0);
            YSWL.MALL.Model.Shop.Order.OrderInfo orderInfo = orderBll.GetModelInfo(orderId);
            if (orderInfo == null || orderInfo.BuyerID != currentUser.UserID)
                return Content("False");

            if (YSWL.MALL.BLL.Shop.Order.OrderManage.CancelOrder(orderInfo, currentUser))
                return Content("True");
            return Content("False");
        }
        [HttpPost]//完成订单
        public ActionResult CompleteOrder(FormCollection Fm)
        {
            Orders orderBll = new Orders();
            long orderId = Globals.SafeLong(Fm["OrderId"], 0);
            OrderInfo orderInfo = orderBll.GetModelInfo(orderId);
            if (orderInfo == null || orderInfo.BuyerID != CurrentUser.UserID)
                return Content("False");
            if (BLL.Shop.Order.OrderManage.CompleteOrder(orderInfo, CurrentUser))
            {
                return Content("True");
            }
            return Content("False");
        }
        #endregion
        #endregion

        #region 收藏列表
        public ActionResult MyFavor(string viewName = "MyFavor")
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "我的收藏";//+ pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            return View(viewName);
        }

        public PartialViewResult FavorList(int pageIndex = 1, int pageSize = 4, string viewName = "_FavorList")
        {
            YSWL.MALL.BLL.Shop.Favorite favoBll = new BLL.Shop.Favorite();
            StringBuilder strBuilder = new StringBuilder();
            // strBuilder.AppendFormat(" UserId ={0}  and  SaleStatus in ( {1},{2} ) ", CurrentUser.UserID, (int )ProductSaleStatus.InStock, (int )ProductSaleStatus.OnSale);
            strBuilder.AppendFormat(" favo.UserId ={0} and favo.Type= {1} ", CurrentUser.UserID, (int)FavoriteEnums.Product);

           

            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex * pageSize;
            int toalCount = favoBll.GetRecordCount(" UserId =" + CurrentUser.UserID + " and Type=" + (int)FavoriteEnums.Product);//获取总条数
            ViewBag.PageSize = pageSize;
            if (toalCount < 1)
            {
                return PartialView(viewName);//NO DATA
            }
            List<YSWL.MALL.ViewModel.Shop.FavoProdModel> favoList = favoBll.GetFavoriteProductListByPage(strBuilder.ToString(), startIndex, endIndex);
            PagedList<YSWL.MALL.ViewModel.Shop.FavoProdModel> lists = new PagedList<YSWL.MALL.ViewModel.Shop.FavoProdModel>(favoList, pageIndex, pageSize, toalCount);
            
            if (Request.IsAjaxRequest())
                return PartialView(viewName, lists);
            return PartialView(viewName, lists);
        }
        /// <summary>
        /// 移除收藏项
        /// </summary>
        /// <param name="Fm"></param>
        /// <returns></returns>
        public ActionResult RemoveFavorItem(FormCollection Fm)
        {
            if (!String.IsNullOrWhiteSpace(Fm["ItemId"]))
            {
                string itemId = Fm["ItemId"];
                YSWL.MALL.BLL.Shop.Favorite favoBll = new BLL.Shop.Favorite();
                int favoriteId = Common.Globals.SafeInt(itemId, 0);
                YSWL.MALL.Model.Shop.Favorite  model=favoBll.GetModel(favoriteId);
                if (model == null)
                {
                    return Content("No");
                }
                if (favoBll.DeleteEx(model))
                {
                    return Content("Ok");
                }             
            }
            return Content("No");
        }
        #endregion

        #region Ajax方法
        /// <summary>
        /// 加入收藏
        /// </summary>
        /// <param name="Fm"></param>
        /// <returns></returns>
        public ActionResult AjaxAddFav(FormCollection Fm)
        {
            if (!String.IsNullOrWhiteSpace(Fm["ProductId"]))
            {
                int productId = Common.Globals.SafeInt(Fm["ProductId"], 0);
                YSWL.MALL.BLL.Shop.Favorite favBll = new BLL.Shop.Favorite();
                //是否已经收藏
                if (favBll.Exists(productId, currentUser.UserID, 1))
                {
                    return Content("Rep");
                }
                YSWL.MALL.Model.Shop.Favorite favMode = new YSWL.MALL.Model.Shop.Favorite();
                favMode.CreatedDate = DateTime.Now;
                favMode.TargetId = productId;
                favMode.Type = (int)YSWL.MALL.Model.Shop.FavoriteEnums.Product;
                favMode.UserId = currentUser.UserID;
                return favBll.Add(favMode) > 0 ? Content("True") : Content("False");
            }
            return Content("False");
        }
        /// <summary>
        /// 添加咨询
        /// </summary>
        /// <param name="Fm"></param>
        /// <returns></returns>
        public ActionResult AjaxAddConsult(FormCollection Fm)
        {
            if (!String.IsNullOrWhiteSpace(Fm["ProductId"]))
            {
                int productId = Common.Globals.SafeInt(Fm["ProductId"], 0);
                string content = Common.InjectionFilter.SqlFilter(Fm["Content"]);
                YSWL.MALL.BLL.Shop.Products.ProductConsults consultBll = new YSWL.MALL.BLL.Shop.Products.ProductConsults();
                YSWL.MALL.Model.Shop.Products.ProductConsults consultMode = new YSWL.MALL.Model.Shop.Products.ProductConsults();
                consultMode.CreatedDate = DateTime.Now;
                consultMode.TypeId = 0;
                consultMode.Status = 0;
                consultMode.UserId = currentUser.UserID;
                consultMode.UserName = currentUser.NickName;
                consultMode.UserEmail = currentUser.Email;
                consultMode.IsReply = false;
                consultMode.Recomend = 0;
                consultMode.ProductId = productId;
                consultMode.ConsultationText = content;
                return consultBll.Add(consultMode) > 0 ? Content("True") : Content("False");
            }
            return Content("False");
        }


        /// <summary>
        /// 预定
        /// </summary>
        /// <param name="Fm"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjaxAddPre(FormCollection Fm)
        {
            int productId = Common.Globals.SafeInt(Fm["ProductId"], 0);
            string sku = Fm["SKU"];
            int count = Common.Globals.SafeInt(Fm["Count"], 0);
            YSWL.MALL.BLL.Shop.PrePro.PreOrder preBll = new BLL.Shop.PrePro.PreOrder();
            YSWL.MALL.Model.Shop.PrePro.PreOrder preModel =null;
            if (count <= 0 || (productId <= 0 && String.IsNullOrWhiteSpace(sku)))
            {
                return Content("False");
            }
            Model.Shop.Products.SKUInfo skuInfo = null;
            if (!String.IsNullOrWhiteSpace(sku))
            {
                skuInfo = skuBll.GetModelBySKU(sku);
            }
            else
            {
                YSWL.MALL.ViewModel.Shop.ProductSKUModel prouctsku = skuBll.GetProductSKUInfoByProductId(productId);
                if (prouctsku == null || prouctsku.ListSKUInfos == null || prouctsku.ListSKUInfos.Count <= 0)
                {
                    return Content("NOSKU");
                }
                skuInfo = prouctsku.ListSKUInfos[0];
            }
            //NOSKU
            if (skuInfo == null)
            {
                return Content("NOSKU");
            }
            Model.Shop.Products.ProductInfo prodModel = prodBll.GetModelByCache(skuInfo.ProductId);
            if (prodModel == null)
            {
                return Content("ProdModelNull");
            }

            #region  检测限购数
            int quantity = 0;//已购数
            int restCount = prodBll.GetRestrictionCount(productId);//限购数
            preModel = preBll.GetModel(CurrentUser.UserID, skuInfo.SKU, 1);
            if (preModel != null && preModel.PreOrderId > 0)
            {
                quantity = preModel.Count;
            }
            if (restCount > 0 && (quantity + count) > restCount)
            {
                return Content("GreaRestCount");
            }
            #endregion

            if (preModel != null && preModel.PreOrderId > 0)
            {
                preModel.Count = count;
                return preBll.Update(preModel.PreOrderId, count, prodModel.DeliveryTip) ? Content("True") : Content("False");
            }
            else
            {
                preModel = new Model.Shop.PrePro.PreOrder();
                preModel.CreatedDate = DateTime.Now;
                preModel.ProductId = productId;
                preModel.ProductName = prodModel.ProductName;
                preModel.UserId = currentUser.UserID;
                preModel.Count = count;
                preModel.DeliveryTip = prodModel.DeliveryTip;
                preModel.Phone = currentUser.Phone;
                preModel.SKU = skuInfo.SKU;
                preModel.Status = 1;
                preModel.UserName = currentUser.UserName;
                return preBll.Add(preModel) > 0 ? Content("True") : Content("False");
            }
        }

        #endregion


        #region 预定列表
        public ActionResult PreOrders(string viewName = "PreOrders")
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "我的预定";// + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            return View(viewName);
        }
        public PartialViewResult PreList(int pageIndex = 1, string viewName = "_PreList")
        {
            YSWL.MALL.BLL.Shop.PrePro.PreOrder preBll = new BLL.Shop.PrePro.PreOrder();
            int _pageSize = 8;
            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * _pageSize + 1 : 1;
            //计算分页结束索引
            int endIndex = pageIndex * _pageSize;
           
            //获取总条数
            int toalCount=0;
            List<YSWL.MALL.Model.Shop.PrePro.PreOrder> list = preBll.GetModelList(CurrentUser.UserID, startIndex, endIndex, out toalCount);
            if (toalCount < 1)
            {
                return PartialView(viewName);//NO DATA
            }
            PagedList<YSWL.MALL.Model.Shop.PrePro.PreOrder> lists = new PagedList<YSWL.MALL.Model.Shop.PrePro.PreOrder>(list, pageIndex, _pageSize, toalCount);
            if (Request.IsAjaxRequest())
                return PartialView(viewName, lists);
            return PartialView(viewName, lists);
        }
        #endregion

        #region 我的佣金
        public ActionResult MyPromo(int pageIndex = 1, int pageSize = 10,string viewName = "MyPromo", string ajaxViewName = "_PromoListMore")
        {
            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * pageSize + 1 : 1;
            //计算分页结束索引
            int endIndex = pageIndex * pageSize;
            //获取总条数
           int toalCount = comdetailBll.GetRecordCount(" UserId=" + CurrentUser.UserID);
            ViewBag.AllFee = comdetailBll.GetUserFees(currentUser.UserID);
            ViewBag.PageSize = pageSize;
            if (toalCount < 1)
            {
                //检测Ajax请求, 进行无刷新分页
                if (Request.IsAjaxRequest())
                    return PartialView(ajaxViewName);
                return View(viewName);//NO DATA
            }
            List<YSWL.MALL.Model.Shop.Commission.CommissionDetail> detailList = comdetailBll.GetListByPageEx("UserID=" + CurrentUser.UserID, "TradeDate Desc ", startIndex, endIndex);
            PagedList<YSWL.MALL.Model.Shop.Commission.CommissionDetail> lists = new PagedList<YSWL.MALL.Model.Shop.Commission.CommissionDetail>(detailList, pageIndex, pageSize, toalCount);
            string baseCode = "{0}&" + currentUser.UserID;
            foreach (var item in lists)
            {
                item.PromoCode = YSWL.Common.UrlOper.Base64Encrypt(String.Format(baseCode, item.ProductId));
            }
            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return PartialView(ajaxViewName,lists);
            return View(viewName, lists);
        }
        #endregion

        #region 推广商品
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">cid</param>
        /// <param name="n">name</param>
        /// <param name="p"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public ActionResult CommissionPro(int c=0,string n="", int p = 1, int pageSize = 10,  string viewName = "CommissionPro", string ajaxViewName = "_CommissionProList")
        {   
            //获取商品一级分类
           YSWL.MALL.BLL.Shop.Products.CategoryInfo categoryBll = new YSWL.MALL.BLL.Shop.Products.CategoryInfo();
           ViewBag.CategoryList = categoryBll.GetCategorysByDepth(1);

            YSWL.MALL.BLL.Shop.Commission.CommissionPro comProBll = new CommissionPro();
            //计算分页起始索引
            int startIndex = p > 1 ? (p - 1) * pageSize + 1 : 1;
            //计算分页结束索引
            int endIndex = p * pageSize;
            int toalCount = comProBll.GetComProCount(c,n);//获取总条数 
            ViewBag.PageSize = pageSize;
            #region DataParam
            ViewBag.DataParam = String.Format("{0}n:'{1}',c:'{2}'{3}", "{", n, c, "}");
            #endregion
            if (toalCount < 1)
            { 
                //检测Ajax请求, 进行无刷新分页
                if (Request.IsAjaxRequest())
                    return PartialView(ajaxViewName);
                return PartialView(viewName);//NO DATA
            }
         
            List<YSWL.MALL.ViewModel.Shop.ProComModel> promoList = comProBll.GetComProByPage(c,n,startIndex, endIndex);
            if (promoList==null)
            {
                //检测Ajax请求, 进行无刷新分页
                if (Request.IsAjaxRequest())
                    return PartialView(ajaxViewName);
                return PartialView(viewName);//NO DATA
            }
            string baseCode = "{0}&" + currentUser.UserID;
            foreach (var item in promoList)
            {
                item.PromoCode = YSWL.Common.UrlOper.Base64Encrypt(String.Format(baseCode, item.ProductId));
            }
            PagedList<YSWL.MALL.ViewModel.Shop.ProComModel> lists = new PagedList<YSWL.MALL.ViewModel.Shop.ProComModel>(promoList, p, pageSize, toalCount);
            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return PartialView(ajaxViewName, lists);

            return PartialView(viewName, lists);
        }
        #endregion

        #region 展示二维码

        public ActionResult MyQRCode(string viewName = "MyQRCode")
        {
            string QRPath = Server.MapPath("/"+MvcApplication.UploadFolder+"/QRcode/"+"QR_" + CurrentUser.UserID + ".jpg");
            
            ViewBag.IsExist = System.IO.File.Exists(QRPath);
            ViewBag.UserId = CurrentUser.UserID;
         
            return View(viewName);

        }

        #endregion

        #region   我的盟友
        /// <summary>
        ///  我的盟友
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public ActionResult MyAlly(int pageIndex = 1, int pageSize = 10, string viewName = "MyAlly", string ajaxViewName = "_AllyListMore")
        {
            #region SEO 优化设置
            IPageSetting pageSetting = PageSetting.GetPageSetting("Home", Model.SysManage.ApplicationKeyType.Shop);
            ViewBag.Title = "我的盟友" + pageSetting.Title;
            ViewBag.Keywords = pageSetting.Keywords;
            ViewBag.Description = pageSetting.Description;
            #endregion
            ViewBag.PageSize = pageSize;
            //计算分页起始索引
            int startIndex = pageIndex > 1 ? (pageIndex - 1) * pageSize + 1 : 1;

            //计算分页结束索引
            int endIndex = pageIndex * pageSize;
            int toalCount = inviteBll.GetRecordCount(" InviteUserId=" + CurrentUser.UserID);//获取总条数 
            if (toalCount < 1)
            {  
                //检测Ajax请求, 进行无刷新分页
                if (Request.IsAjaxRequest())
                    return PartialView(ajaxViewName);
                return PartialView(viewName);//NO DATA
            }
            List<Model.Members.UserInvite> lists = inviteBll.GetListByPage(" InviteUserId=" + CurrentUser.UserID, startIndex, endIndex);
            PagedList<Model.Members.UserInvite> pagelist = new PagedList<Model.Members.UserInvite>(lists, pageIndex, pageSize, toalCount);
            //检测Ajax请求, 进行无刷新分页
            if (Request.IsAjaxRequest())
                return View(ajaxViewName, pagelist);
            return View(viewName, pagelist);
        }
        #endregion

        public ActionResult GoPc()
        {
            ViewBag.EnterpriseTag = Common.CallContextHelper.GetDEncrypTag();
            return View();
        }
    }
}
