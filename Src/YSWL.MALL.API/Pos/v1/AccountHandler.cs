using System;
using System.Runtime.Remoting.Contexts;
using System.Web;
using YSWL.Accounts.Bus;
using YSWL.Components;
using YSWL.Components.Handlers.API;
using YSWL.Json;
using YSWL.Json.RPC;
using YSWL.MALL.BLL.SysManage;
using YSWL.MALL.Model.Members;

namespace YSWL.MALL.API.Pos.v1
{
    public partial class PosHandler
    {
       
        #region 用户登录

        [JsonRpcMethod("Login", Idempotent = false)]
        [JsonRpcHelp("用户登录")] 
        public JsonObject Login(string UserName, string Password, string enterprisestr)
        {
            if (string.IsNullOrWhiteSpace(UserName))
                return new Result(ResultStatus.Failed,
                    Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));

            try
            {
                string enterpriseName = "";
                if (MvcApplication.IsAutoConn)
                {
                    long enterpriseId=0;
                    if (!string.IsNullOrEmpty(enterprisestr))
                    {
                        enterpriseId = Common.DEncrypt.DEncrypt.ConvertToNumber(enterprisestr);
                    }
                    //获取企业ID
                    YSWL.MALL.BLL.Members.Users userBll = new YSWL.MALL.BLL.Members.Users();
                    YSWL.MALL.ViewModel.SAAS.UserInfo SAUserInfo = userBll.GetSAUserInfo(UserName, Password,2,enterpriseId);
                    if (SAUserInfo == null)
                    {
                        return new Result(ResultStatus.Failed, Result.FormatFailed("40", "登录失败，请确认用户名或密码是否正确。"));
                    }
                    YSWL.Common.CallContextHelper.SetAutoTag(SAUserInfo.EnterpriseId);
                    enterpriseName = SAUserInfo.EnterpriseName;
                }
                AccountsPrincipal userPrincipal = AccountsPrincipal.ValidateLogin(UserName, Password);
                //登录失败，请确认用户名或密码是否正确。
                if (userPrincipal == null)
                {
                    LogHelp.AddUserLog(UserName, (string) "", (string) "登录失败!", (HttpRequest) Request);
                    return new Result(ResultStatus.Failed, Result.FormatFailed("40", "登录失败，请确认用户名或密码是否正确。"));
                }
                User currentUser = new YSWL.Accounts.Bus.User(userPrincipal);
                //您非业务员用户，您没有权限使用接口系统！
                if (currentUser.UserType != "AA"&&!currentUser.UserType.StartsWith("Y"))
                {
                    return new Result(ResultStatus.Failed,
                        Result.FormatFailed(HandlerBase.ERROR_CODE_UNAUTHORIZED, HandlerBase.ERROR_MSG_UNAUTHORIZED));
                }
                Context.User = userPrincipal;
                //密码错误！
                if (((SiteIdentity)User.Identity).TestPassword(Password) == 0)
                {
                    YSWL.MALL.BLL.SysManage.LogHelp.AddUserLog(UserName, (string) "", (string) "密码错误！", (HttpRequest) Request);
                    return new Result(ResultStatus.Failed, Result.FormatFailed("42", "密码错误！"));
                }
                //对不起，该帐号已被冻结，请联系管理员！
                if (!currentUser.Activity)
                {
                    return new Result(ResultStatus.Failed, Result.FormatFailed("44", "对不起，该帐号已被冻结，请联系管理员！"));
                }
                //登录成功
                LogHelp.AddUserLog(currentUser.UserName, currentUser.UserType, (string) "登录成功", (HttpRequest) Request);
                return new Result(ResultStatus.Success, GetUserInfo4Json(currentUser, enterpriseName));
            }
            catch (Exception ex)
            {
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(string.Format(HandlerBase.ERROR_MSG_LOG, Request.Headers[HandlerBase.REQUEST_HEADER_METHOD], ex.Message),
                    ex.StackTrace, (HttpRequest) Request);
                return new Result(ResultStatus.Error, ex);
            }
        }

        #endregion

        #region 用户名是否存在
        [JsonRpcMethod("HasUserByUserName", Idempotent = true)]
        [JsonRpcHelp("用户名是否存在")]
        public JsonObject HasUserByUserName(string UserName)
        {
            if (string.IsNullOrWhiteSpace(UserName)) return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));     
            return Result.HasResult(BLLUser.HasUserByUserName(UserName));
        }
        #endregion

        #region 昵称是否存在
        [JsonRpcMethod("HasUserByNickName", Idempotent = true)]
        [JsonRpcHelp("昵称是否存在")]
        public JsonObject HasUserByNickName(string NickName)
        {
            if (string.IsNullOrWhiteSpace(NickName)) return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            YSWL.Accounts.Bus.User BLLUser = new User();
            return Result.HasResult(BLLUser.HasUserByNickName(NickName));
        }
        #endregion

        #region 获取个人信息
        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns>用户信息</returns>
        [JsonRpcMethod("GetUserInfo", Idempotent = false)]
        [JsonRpcHelp("获取个人信息")]
        public JsonObject GetUserInfo(int UserId)
        {
            //超级管理员信息保护 过滤UserId=1用户
            if (UserId < 2) return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            try
            {
                //TODO: 用户不存在 未对应
                return new Result(ResultStatus.Success,
                    GetUserInfo4Json(new User(UserId),""));
            }
            catch (Exception ex)
            {
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(string.Format(HandlerBase.ERROR_MSG_LOG, Request.Headers[HandlerBase.REQUEST_HEADER_METHOD], ex.Message), ex.StackTrace, (HttpRequest) Request);
                return new Result(ResultStatus.Error, ex);
            }
        }

        private JsonObject GetUserInfo4Json(User userInfo,string enterpriseName)
        {
            YSWL.MALL.BLL.Members.UsersExp BLL = new YSWL.MALL.BLL.Members.UsersExp();
            UsersExpModel user = BLL.GetUsersModel(userInfo.UserID);
            if (userInfo == null || string.IsNullOrWhiteSpace(userInfo.UserType) ) return null;
            JsonObject json = new JsonObject();
            json.Put("userId", user.UserID);
            json.Put("userName", user.UserName);
            json.Put("trueName", user.TrueName);
            json.Put("phone", user.Phone);
            json.Put("nickName", user.NickName);
            json.Put("email", user.Email);
            json.Put("qq", user.QQ);
            json.Put("level", user.UserType);
            //json.Put("departmentID", userInfo.DepartmentID);
            json.Put("isOpenMultiDepot", YSWL.MALL.BLL.Shop.Service.CommonHelper.OpenMultiDepot());
            #region  企业字符串
            string enterpriseStr = "";
            string enterpriseId = "";
            if (MvcApplication.IsAutoConn)
            {
                enterpriseStr = YSWL.Common.CallContextHelper.GetDEncrypTag();
                enterpriseId = YSWL.Common.CallContextHelper.GetClearTag();
            }
            json.Put("enterpriseStr", enterpriseStr);
            json.Put("enterpriseId", enterpriseId);
            json.Put("enterpriseName", enterpriseName);
            #endregion 
            return json;
        }
        #endregion

        #region 更新个人信息
        [JsonRpcMethod("UpdateUserInfo", Idempotent = false)]
        [JsonRpcHelp("更新个人信息")]
        public JsonObject UpdateUserInfo(int userId,
            string phone, string email, string trueName,string qq)
        {
            if (userId < 2) return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            try
            {
                YSWL.Accounts.Bus.User user = new User(userId);
                //NO DATA
                if (string.IsNullOrWhiteSpace(user.UserType)) return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_NODATA, HandlerBase.ERROR_MSG_NODATA));
                //user.TrueName = TrueName;
                //if (Sex.HasValue) user.Sex = Sex.ToString();
                user.Email = email;
                user.Phone = phone;
                user.TrueName = trueName;

                userExpManage.UpdateQQ(userId, qq);
                return new Result(user.Update(MvcApplication.IsAutoConn));
            }
            catch (Exception ex)
            {
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(string.Format(HandlerBase.ERROR_MSG_LOG, Request.Headers[HandlerBase.REQUEST_HEADER_METHOD], ex.Message), ex.StackTrace, (HttpRequest) Request);
                return new Result(ResultStatus.Error, ex);
            }
        }
        #endregion

        #region 修改密码
        [JsonRpcMethod("UpdatePwd", Idempotent = false)]
        [JsonRpcHelp("更新密码")]
        public JsonObject UpdatePwd(int userId, string password, string newPassword)
        {
            if (userId < 2) return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
            try
            {
                YSWL.Accounts.Bus.User user = new User(userId);
                //NO DATA
                if (string.IsNullOrWhiteSpace(user.UserType)) return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_NODATA, HandlerBase.ERROR_MSG_NODATA));
                //修改密码
                if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(newPassword))
                {
                    return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_ARGUMENT, HandlerBase.ERROR_MSG_ARGUMENT));
                }
                //验证旧密码
                SiteIdentity siteIdentity = new SiteIdentity(userId);
                if (siteIdentity.TestPassword(password) == 0)
                {
                    return new Result(ResultStatus.Failed, Result.FormatFailed("101", "当前密码不正确, 更新个人信息失败!"));
                }
                //非普通用户禁用接口
                if (user.UserType != "SS" && !user.UserType.StartsWith("Y"))
                {
                    return new Result(ResultStatus.Failed, Result.FormatFailed(HandlerBase.ERROR_CODE_UNAUTHORIZED, HandlerBase.ERROR_MSG_UNAUTHORIZED));
                }
                //  user.Password = AccountsPrincipal.EncryptPassword(newPassword);

                return new Result(user.SetPassword(user.UserName, newPassword, MvcApplication.IsAutoConn));
            }
            catch (Exception ex)
            {
                YSWL.MALL.BLL.SysManage.LogHelp.AddErrorLog(string.Format(HandlerBase.ERROR_MSG_LOG, Request.Headers[HandlerBase.REQUEST_HEADER_METHOD], ex.Message), ex.StackTrace, (HttpRequest) Request);
                return new Result(ResultStatus.Error, ex);
            }
        }
        #endregion 

        
    }
}
