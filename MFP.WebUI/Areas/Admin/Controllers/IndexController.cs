﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFP.WebUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Index
        public ActionResult Index()
        {

            return View();
        }

        //[HttpPost]
        //public JsonResult GetMenu()
        //{
        //    return Json();
        //}
    }
}