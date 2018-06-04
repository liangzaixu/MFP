using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll;

namespace WebUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private DemoService userService = new DemoService();
        // GET: Admin/User
        public ActionResult Index()
        {
            //userService.DoSomething();

            return View();
        }

    }
}