using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFP.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}