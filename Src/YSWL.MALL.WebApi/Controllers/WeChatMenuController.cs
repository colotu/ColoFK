using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YSWL.MALL.WebApi.Common;
using YSWL.MALL.WebApi.Models;
using YSWL.Web;

namespace YSWL.MALL.WebApi.Controllers
{
    [RoutePrefix("v1.0")]
    public class WeChatMenuController : ApiControllerBase
    {
        private readonly YSWL.WeChat.BLL.Core.Menu _menuBll = new YSWL.WeChat.BLL.Core.Menu();

        /// <summary>
        /// 获取微信菜单
        /// </summary>
        /// <returns></returns>
        [Route("wechat/menulist")]
        [HttpGet]
        public ResponseResult MenuList()
        {
            string openId = YSWL.WeChat.BLL.Core.Config.GetValueByCache("WeChat_OpenId", -1, "AA");
            List<YSWL.WeChat.Model.Core.Menu> menuList = _menuBll.GetMenuList(openId);

            List<ViewModel.WeChat.MenuListVm> menuListVm = menuList.Select(t => new ViewModel.WeChat.MenuListVm
            {
                CreateDate = t.CreateDate,
                HasChildren = t.HasChildren,
                MenuId = t.MenuId,
                MenuKey = t.MenuKey,
                MenuUrl = t.MenuUrl,
                Name = t.Name,
                ParentId = t.ParentId,
                Remark = t.Remark,
                Sequence = t.Sequence,
                Status = t.Status,
                Type = t.Type
            }).ToList();
            //对商品数据进行排序

            List<ViewModel.WeChat.MenuListVm> rootList = menuListVm.Where(c => c.ParentId == 0).OrderBy(c => c.Sequence).ToList();
            List<ViewModel.WeChat.MenuListVm> orderList = new List<ViewModel.WeChat.MenuListVm>();
            foreach (var item in rootList)
            {
                if (item.HasChildren)
                {
                    item.Children = MenuOrder(item.MenuId, menuListVm);
                }
                orderList.Add(item);
            }
            return SuccessResult(orderList);
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [Route("wechat/menudetail")]
        [HttpGet]
        public ResponseResult MenuDetail(int menuId = 0)
        {
            YSWL.WeChat.Model.Core.Menu menuModel = _menuBll.GetModel(menuId);
            return SuccessResult(menuModel);
        }

        /// <summary>
        /// 添加微信菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("wechat/menuadd")]
        [HttpPost]
        public ResponseResult MenuAdd(ViewModel.WeChat.AddMenuVm model)
        {
            YSWL.WeChat.Model.Core.Menu menuModel = new YSWL.WeChat.Model.Core.Menu();
            string openId = YSWL.WeChat.BLL.Core.Config.GetValueByCache("WeChat_OpenId", -1, "AA");
            int parentId = model.ParentId;

            int actionId = model.ActionId;
            string name = model.Name;
            int categoryId = 0;
            string remark = model.Url;
            if (string.IsNullOrWhiteSpace(name))
            {
                return FailResult(ResponseCode.ParamError, "请输入菜单名称");
            }
            //判断是否超出了限制
            int count = _menuBll.GetRecordCount("ParentId=" + parentId);
            if (parentId == 0)
            {
                if (count >= 3)
                {
                    return FailResult(ResponseCode.ParamError, "一级菜单请不要超过三个");
                }
                if (name.Length > 4)
                {
                    return FailResult(ResponseCode.ParamError, "一级菜单名称请不要超过4个汉字");
                }
            }
            else
            {
                if (count >= 5)
                {
                    return FailResult(ResponseCode.ParamError, "二级菜单请不要超过5个");
                }
                if (name.Length > 7)
                {
                    return FailResult(ResponseCode.ParamError, "二级菜单名称请不要超过7个汉字");
                }

            }
            //组装新增实体
            GetMenu(menuModel, actionId, parentId, categoryId, openId, name, remark);
            return _menuBll.AddEx(menuModel) ? SuccessResult("新增成功") : FailResult(ResponseCode.BadGateway, "新增失败");
        }

        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <returns></returns>
        [Route("wechat/menuedit")]
        [HttpPost]
        public ResponseResult MenuUpdate(ViewModel.WeChat.AddMenuVm model)
        {
            YSWL.WeChat.Model.Core.Menu menuModel = _menuBll.GetModel(model.Id);
            int actionId = model.ActionId;
            int categoryId = 0;
            string remark = model.Url;
            string name = model.Name;

            if (string.IsNullOrWhiteSpace(name))
            {
                return FailResult(ResponseCode.ParamError, "请输入菜单名称");
            }
            //获取修改实体
            GetMenu(menuModel, actionId, model.Sequence, categoryId, name, remark);
            return _menuBll.Update(menuModel) ? SuccessResult("编辑成功") : FailResult(ResponseCode.BadGateway, "编辑失败");
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [Route("wechat/meundelete")]
        [HttpGet]
        public ResponseResult MenuDelete(int menuId = 0)
        {
            _menuBll.DeleteEx(menuId);
            return SuccessResult("删除成功");
        }

        /// <summary>
        /// 生成菜单
        /// </summary>
        /// <returns></returns>
        [Route("wechat/menusave")]
        [HttpGet]
        public ResponseResult MenuSave()
        {
            string userType = "AA";
            string openId = YSWL.WeChat.BLL.Core.Config.GetValueByCache("WeChat_OpenId", -1, userType);
            //先授权 
            string appId = YSWL.WeChat.BLL.Core.Config.GetValueByCache("WeChat_AppId", -1, userType);
            string appSecret = YSWL.WeChat.BLL.Core.Config.GetValueByCache("WeChat_AppSercet", -1, userType);
            bool isAuto = YSWL.Common.Globals.SafeBool(YSWL.WeChat.BLL.Core.Config.GetValueByCache("WeChat_AutoLogin", -1, userType), false);
            string token = PostMsgHelper.GetToken(appId, appSecret);
            if (string.IsNullOrWhiteSpace(token))
            {
                return FailResult(ResponseCode.BadGateway, "获取微信授权失败！请检查您的微信API设置和对应的权限");
            }
            bool isSuccess = PostMsgHelper.CreateMenu(token, openId, isAuto);
            return isSuccess ? SuccessResult("创建菜单成功") : FailResult(ResponseCode.ExecuteError, "创建菜单成功");
        }

        #region 私有方法
        /// <summary>
        /// 递归查找菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="menuList"></param>
        /// <returns></returns>
        private List<ViewModel.WeChat.MenuListVm> MenuOrder(int menuId, List<ViewModel.WeChat.MenuListVm> menuList)
        {
            List<ViewModel.WeChat.MenuListVm> orderList = new List<ViewModel.WeChat.MenuListVm>();
            List<ViewModel.WeChat.MenuListVm> list = menuList.Where(c => c.ParentId == menuId).OrderBy(c => c.Sequence).ToList();
            foreach (var item in list)
            {
                if (item.HasChildren)
                {
                    item.Children = MenuOrder(item.MenuId, menuList);
                }
                orderList.Add(item);
            }
            return orderList;
        }
        /// <summary>
        /// 构建菜单实体
        /// </summary>
        private void GetMenu(YSWL.WeChat.Model.Core.Menu menuModel, int actionId, int parentId, int categoryId, string openId, string name, string remark)
        {
            menuModel.MenuKey = actionId.ToString();
            menuModel.MenuUrl = "";
            menuModel.Type = "view";
            if (actionId <= 0)
            {
                switch (actionId)
                {

                    case -16:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MBShop) + "u/Orders";
                        break;
                    case -15:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MBShop) + "u";
                        break;
                    case -14:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MBShop);
                        break;
                    //快递查询
                    case -13:
                        string expressUrl = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_Core_ExpressUrl");
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(expressUrl) ? "http://m.kuaidi100.com/index_all.html" : expressUrl;
                        break;
                    //周公解梦
                    case -12:
                        string jiemengUrl = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_Core_JieMeng");
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(jiemengUrl) ? "http://jiemengmobi.duapp.com/" : jiemengUrl;
                        break;
                    //天气查询
                    case -11:
                        string weather = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_Core_WeatherUrl");
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(weather) ? "http://mobile.weather.com.cn/" : weather;
                        break;
                    case -10:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "Admin/CouponEx";
                        break;
                    case -9:
                        int articleId = 0;
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "Article/Detail/" + articleId;
                        break;
                    case -8:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "WeChat/Apply";
                        break;
                    case -7:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "UserCenter/signpoint";
                        break;
                    case -6:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "WeChat/usercard";
                        break;
                    case -5:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) + "u/Orders";
                        break;
                    case -4:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) + "p/" + categoryId;
                        break;
                    case -3:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) + "u";
                        break;
                    case -2:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MPage);
                        break;
                    case -1:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop);
                        break;
                    case 0:
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(remark) ? YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) : remark;
                        break;
                    default:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop);
                        break;
                }
            }
            // 走Action里面的逻辑
            else
            {
                menuModel.Type = "click";
                menuModel.MenuKey = "Action_" + actionId;
                menuModel.Remark = "";
                if (actionId == 1)
                {
                    menuModel.Remark = "";
                    menuModel.MenuKey = "Action_" + actionId + "_" + 0;
                }
            }

            menuModel.ParentId = parentId;
            menuModel.Name = name;
            //是否启用
            menuModel.Status = 1;
            menuModel.CreateDate = DateTime.Now;
            menuModel.HasChildren = false;
            menuModel.Sequence = _menuBll.GetSequence(openId) + 1;
            menuModel.OpenId = openId;
        }
        /// <summary>
        /// 构建菜单实体
        /// </summary>
        private void GetMenu(YSWL.WeChat.Model.Core.Menu menuModel, int actionId, int sequence, int categoryId, string name, string remark)
        {
            menuModel.Name = name;
            menuModel.MenuKey = actionId.ToString();
            menuModel.MenuUrl = "";
            menuModel.Type = "view";
            if (actionId <= 0)
            {
                switch (actionId)
                {
                    case -16:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MBShop) + "u/Orders";
                        break;
                    case -15:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MBShop) + "u";
                        break;
                    case -14:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MBShop);
                        break;
                    //快递查询
                    case -13:
                        string expressUrl = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_Core_ExpressUrl");
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(expressUrl) ? "http://m.kuaidi100.com/index_all.html" : expressUrl;
                        break;
                    //周公解梦
                    case -12:
                        string jiemengUrl = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_Core_JieMeng");
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(jiemengUrl) ? "http://jiemengmobi.duapp.com/" : jiemengUrl;
                        break;
                    //天气查询
                    case -11:
                        string weather = YSWL.MALL.BLL.SysManage.ConfigSystem.GetValueByCache("WeChat_Core_WeatherUrl");
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(weather) ? "http://mobile.weather.com.cn/" : weather;
                        break;
                    case -10:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "Admin/CouponEx";
                        break;
                    case -9:
                        int articleId = 0;
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "Article/Detail/" + articleId;
                        break;
                    case -8:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "WeChat/Apply";
                        break;
                    case -7:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "UserCenter/signpoint";
                        break;
                    case -6:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.COM) + "WeChat/usercard";
                        break;
                    case -5:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) + "u/Orders";
                        break;
                    case -4:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) + "p/" + categoryId;
                        break;
                    case -3:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) + "u";
                        break;
                    case -2:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MPage);
                        break;
                    case -1:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop);
                        break;
                    case 0:
                        menuModel.MenuUrl = String.IsNullOrWhiteSpace(remark) ? YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop) : remark;
                        break;
                    default:
                        menuModel.MenuUrl = YSWL.Components.MvcApplication.GetCurrentRoutePath(AreaRoute.MShop);
                        break;
                }
            }
            // 走Action里面的逻辑
            else
            {
                menuModel.Type = "click";
                menuModel.MenuKey = "Action_" + actionId;
                menuModel.Remark = "";
                if (actionId == 1)
                {
                    menuModel.Remark = "0";
                    menuModel.MenuKey = "Action_" + actionId + "_" + 0;
                }
            }
            menuModel.Status = 1;
            menuModel.Remark = "";
            menuModel.Sequence = sequence;
        }
        #endregion

    }
}