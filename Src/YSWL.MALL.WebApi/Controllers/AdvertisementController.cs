using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YSWL.MALL.WebApi.Models;

namespace YSWL.MALL.WebApi.Controllers
{
    [RoutePrefix("v1.0")]
    public class AdvertisementController : ApiControllerBase
    {
        private readonly YSWL.MALL.BLL.Settings.Advertisement _advertisementBll = new YSWL.MALL.BLL.Settings.Advertisement();

        /// <summary>
        /// 获取广告位列表
        /// </summary>
        /// <param name="adPositionId"></param>
        /// <param name="page"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("advertisement/list")]
        public ResponseResult AdvertisementList(int adPositionId=0, int? page = 1,
            int pageNum = 30)
        {
            if (adPositionId<1)
            {
                return FailResult(ResponseCode.ParamError);
            }
            List<YSWL.MALL.Model.Settings.Advertisement> advertisementList = _advertisementBll.GetListByPageApp(adPositionId,page, pageNum);
            return SuccessResult(advertisementList);
        }
    }
}