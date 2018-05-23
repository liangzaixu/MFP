using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Admin/Personal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Security()
        {
            return View();
        }
    }
}