using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MFP.WebUI.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.UserId = User.Identity.GetUserId();
            ViewBag.UserName = User.Identity.GetUserName();
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }


        public JsonResult TestAjaxSleep()
        {
            Thread.Sleep(5000);
            return Json(DateTime.Now.ToString("mm:ss"),JsonRequestBehavior.AllowGet);
        }
    }
}