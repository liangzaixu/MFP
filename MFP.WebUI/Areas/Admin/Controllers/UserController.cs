using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MFP.Service.BGSystem;
using MFP.CommonModel;
using MFP.Model.Identity;
using MFP.MvcExtension;
using MFP.WebUI.Properties;

namespace MFP.WebUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private UserService _userService = new UserService();

        #region 查询
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUser(int pageIndex,int pageSize,string keyWord="")
        {

            return Json(_userService.GetUserToPage(pageIndex, pageSize, keyWord),JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 添加
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            bool result;
            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    return Json(new AjaxResult(400,"参数不合法"));
                }
                result = _userService.AddUser(model);
                int status = result ? 200 : 500;
                return Json(new AjaxResult(status));
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            result=_userService.AddUser(model);
            NormalInfo info = new NormalInfo();
            if (result)
            {
                info.Title = "操作成功";
                info.Msg = "您已成功添加了一名管理员。";
                info.Countdown = 5;
                info.Destination = "刚才的添加页面。";
                info.RedirectUrl = Url.Action("Add", "User", new {Area = "Admin"});
            }
            else
            {
                info.Title = "操作失败";
                info.Msg = "添加管理员失败。";
                info.Countdown = 5;
                info.Destination = "刚才的添加页面。";
                info.RedirectUrl = Url.Action("Add", "User", new { Area = "Admin" });
            }

            return View(Resources.Url_NormalInfoView, info);
        }
        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return Json(new AjaxResult(400,"userID参数不能为空。") );
            }

            if (_userService.DeleteUser(userID))
            {
                return Json(new AjaxResult(200));
            }
            else
            {
                return Json(new AjaxResult(500,"删除管理员操作出现异常"));
            }
        }
        #endregion

        #region 编辑
        public ActionResult Edit(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return View(Resources.Url_ErrorView,new ErrorInfo()
                {
                    Title="参数不能为空",
                    Msg="程序未能获取到有效的userID参数"
                });
            }

            UserViewModel model= _userService.GetUserDetail(userID);
            if (model == null)
            {
                return View(Resources.Url_ErrorView, new ErrorInfo()
                {
                    Title = "用户不存在",
                    Msg = $"程序未能查找到ID为{userID}的用户"
                });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            bool result;
            bool doEditPassword = false;

            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    return Json(new AjaxResult(400, "参数不合法"));
                }
                result = _userService.EditUser(model, doEditPassword);
                int status = result ? 200 : 500;
                return Json(new AjaxResult(status));
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            result = _userService.EditUser(model, doEditPassword);
            NormalInfo info = new NormalInfo();
            if (result)
            {
                info.Title = "操作成功";
                info.Msg = "您成功修改了管理员资料。";
                info.Countdown = 5;
                info.Destination = "刚才的编辑页面。";
                info.RedirectUrl = Url.Action("Edit", "User", new { Area = "Admin",UserID= model.Id });
            }
            else
            {
                info.Title = "操作失败";
                info.Msg = "修改管理员资料失败。";
                info.Countdown = 5;
                info.Destination = "刚才的编辑页面。";
                info.RedirectUrl = Url.Action("Edit", "User", new { Area = "Admin", UserID = model.Id });
            }

            return View(Resources.Url_NormalInfoView, info);
        }
        #endregion

    }
}