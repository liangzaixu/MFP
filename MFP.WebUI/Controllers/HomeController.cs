using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MFP.WebUI.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult TestAjaxSleep()
        {
            Thread.Sleep(5000);
            return Json(DateTime.Now.ToString("mm:ss"),JsonRequestBehavior.AllowGet);
        }
    }
}