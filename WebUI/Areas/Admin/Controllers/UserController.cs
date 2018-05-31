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
        private UsersService userService = new UsersService();
        // GET: Admin/User
        public ActionResult Index()
        {
            userService.DoSomething();
            return View();
        }

        public ActionResult Index1()
        {
            userService.DoSomething1();
            return View();
        }

        public ActionResult Index2()
        {
            userService.DoSomething2();
            return View();
        }
    }
}