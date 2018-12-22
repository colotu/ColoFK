﻿using System.Web.Mvc;

namespace YSWL.MALL.Web.Areas.BShop.Controllers
{
    public class DownloadController : BShopControllerBase
    {
        public ActionResult Android()
        {
            string path = Common.ConfigHelper.GetConfigString("FilePath_Android");
            if (string.IsNullOrWhiteSpace(path))
            {
                path = "~/Download/YSWLShop.apk";
            }
            path = Server.MapPath(path);
            string name = System.IO.Path.GetFileName(path);
            return File(path, "application/vnd.android.package-archive", Url.Encode(name));
        }
    }
}
