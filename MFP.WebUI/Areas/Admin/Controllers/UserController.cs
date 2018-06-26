using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MFP.Service.BGSystem;
using MFP.CommonModel;
using MFP.Model.BGSystem;

namespace MFP.WebUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService = new UserService();
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUser(int pageIndex,int pageSize,string keyWord="")
        {
            return Json(_userService.GetUserToPage(pageIndex, pageSize, keyWord),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Delete()
        {
            return Json(null);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Edit(UserDTO user)
        {
            return Json(null);
        }

    }
}