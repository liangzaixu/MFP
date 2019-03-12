using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using MFP.Model.Identity;
using MFP.MvcExtension;
using MFP.Service.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MFP.WebUI.Controllers
{
    //[SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class HomeController : BaseController
    {
        public HomeController()
        {

        }

        public HomeController(UserService userSer):base()
        {

        }

        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UserId = OnlineUser.AccountId;
                ViewBag.UserName = OnlineUser.UserName;
                ViewBag.Email = OnlineUser.Email;
            }
            return View();
        }


        public JsonResult TestAjaxSleep()
        {
            Thread.Sleep(5000);
            return Json(DateTime.Now.ToString("mm:ss"),JsonRequestBehavior.AllowGet);
        }
    }
}