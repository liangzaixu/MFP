using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MFP.Model.BGSystem;
using MFP.Service.BGSystem;


namespace MFP.WebUI.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService = new UserService();

        public ActionResult Index(int pageIndex=0)
        {
            //List<UserDTO> users = _userService.GetUserToPage(10, pageIndex);
            //ViewBag.PageIndex = pageIndex.ToString();

            return View();
        }

        [HttpPost]
        public bool DeleteUser(string userID)
        {
            if (!Request.IsAjaxRequest())
            {
                return false;
            }

            UserService userService = new UserService();
            return userService.DeleteUser(userID);
        }

        public ActionResult EditUser(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return HttpNotFound();
            }
            userID = Uri.UnescapeDataString(userID);
            return PartialView(_userService.GetUserDetail(userID));
        }

        [HttpPost]
        public bool EditUser(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                return false;
            }
            if (!Request.IsAjaxRequest())
            {
                return false;
            }

            UserService userService = new UserService();
            return userService.EditUser(user,false);
        }

        public ActionResult AddUser()
        {
            return PartialView();
        }

        [HttpPost]
        public bool AddUser(UserDTO user)
        {
            if (!Request.IsAjaxRequest())
            {
                return false;
            }

            UserService userService = new UserService();
            return userService.AddUser(user);
        }
    }
}