using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YSWL.Common;
using YSWL.SAAS.BLL;
using YSWL.MALL.WebApi.Common;
using YSWL.MALL.WebApi.Models;

namespace YSWL.MALL.WebApi.Controllers
{
    [RoutePrefix("v1.0")]
    public class AdvertisePositionController : ApiControllerBase
    {
        private readonly BLL.Settings.AdvertisePosition _advBll = new BLL.Settings.AdvertisePosition();
        private readonly BLL.Settings.Advertisement _advertisementBll = new BLL.Settings.Advertisement();
        private readonly string _host = "http://" + HttpContext.Current.Request.Url.Host;
        private static readonly DataCacheCore DataCache = new DataCacheCore(new CacheOption
        {
            CacheType = SAASInfo.GetSystemBoolValue("RedisCacheUse") ? CacheType.Redis : CacheType.IIS,
            ReadWriteHosts = SAASInfo.GetSystemValue("RedisCacheReadWriteHosts"),
            ReadOnlyHosts = SAASInfo.GetSystemValue("RedisCacheReadOnlyHosts"),
            CancelProductKey = true,
            DefaultDb = 1
        });
        /// <summary>
        /// 获取广告位列表
        /// </summary>
        /// <param name="advName"></param>
        /// <param name="page"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("advertise/list")]
        public ResponseResult AdvertiseList(string advName = null, int? page = 1,
            int pageNum = 30)
        {
            if (!string.IsNullOrEmpty(advName))
            {
                advName = YSWL.Common.InjectionFilter.SqlFilter(advName);
            }
            List<Model.Settings.AdvertisePosition> advList = _advBll.GetListByPageApp(advName, page, pageNum);
            return advList.Any()?SuccessResult(advList.Select(t => new { Id = t.AdvPositionId, Name = t.AdvPositionName }))
                :SuccessResult(new string[] {});
        }

        /// <summary>
        /// 获取广告位详情
        /// </summary>
        /// <param name="advId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("advertise/detail")]
        public ResponseResult AdvertiseDetail(int advId = 0)
        {
            if (advId < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            Model.Settings.AdvertisePosition postion = _advBll.GetModel(advId);
            if (postion == null)
            {
                return FailResult(ResponseCode.NotFound, "请求的数据不存在");
            }
            List<Model.Settings.Advertisement> advertisementList = _advertisementBll.GetModelList($" AdvPositionId={advId} and ContentType=1");
            ViewModel.AdvertisePositionVm vm = new ViewModel.AdvertisePositionVm
            {
                Id = postion.AdvPositionId,
                Name = postion.AdvPositionName,
                IsOne = postion.IsOne,
                Advertisement = advertisementList?.Select(t => new ViewModel.AdvertisementVm
                {
                    Id = t.AdvertisementId,
                    Url = t.NavigateUrl,
                    Image = _host + t.FileUrl
                }).ToList()
            };
            return SuccessResult(vm);
        }

        /// <summary>
        /// 编辑广告位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("advertise/edit")]
        public ResponseResult AdvertiseUpdate(ViewModel.AdvertisePositionVm model)
        {
            if (model.Id < 1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            //上传图片处理
            foreach (ViewModel.AdvertisementVm advertisementVm in model.Advertisement)
            {
                if (!string.IsNullOrEmpty(advertisementVm.ImageName) && !string.IsNullOrEmpty(advertisementVm.Image))
                {
                    string extension = Path.GetExtension(advertisementVm.ImageName);
                    string pathFormat = "/Upload/AD/{0}/";
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + extension;
                    string path = string.Format(pathFormat + "{1}", EnterpiseId, fileName);
                    FileHelper.SavaFile(Server.MapPath(string.Format(pathFormat, EnterpiseId)), fileName, advertisementVm.Image);
                    advertisementVm.Image = path;
                }
            }
            bool isSuccess = _advBll.UpdateAdvPostion(model);
            if (isSuccess)
            {
                int aid = YSWL.MALL.BLL.SysManage.ConfigSystem.GetIntValueByCache("Shop_App_Index_AdId");
                aid = aid > 0 ? aid : 59;//如果参数表没有设置广告位 
                DataCache.DeleteCache("Shop_App_Index_AdId");
                DataCache.DeleteCache("GetListByAidCache-" + aid);
                return SuccessResult("编辑成功");
            }
            return FailResult(ResponseCode.BadGateway, "编辑失败");
        }
    }
}