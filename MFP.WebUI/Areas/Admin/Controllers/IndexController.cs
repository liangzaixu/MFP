using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MFP.Service.BGSystem;
using MFP.Model.BGSystem;
using System.Collections;

namespace MFP.WebUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private MenuService _menuService;

        public HomeController()
        {
            _menuService = new MenuService();
        }

        // GET: Admin/Index
        public ActionResult Index()
        {
            List<HeaderMenuDTO> menu = _menuService.GetMenus("admin");
            return View(menu);
        }

        //[HttpPost]
        //public JsonResult GetMenu()
        //{
        //    return Json();
        //}
    }
}