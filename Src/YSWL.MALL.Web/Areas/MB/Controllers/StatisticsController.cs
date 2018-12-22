using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace YSWL.MALL.Web.Areas.MB.Controllers
{
    public class StatisticsController : MBControllerBase
    {
        // GET: MB/Statistics
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexDaily(string viewName= "IndexDaily") {
            return View(viewName);
        }
    }
}