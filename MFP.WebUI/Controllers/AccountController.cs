using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MFP.Model.Identity;
using MFP.Service.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;

namespace MFP.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        public AccountController(SignInService signInService, UserService userService)
        {
            this._signInService = signInService;
            this._userService = userService;
        }

        private SignInService _signInService;
        private UserService _userService;


        public SignInService SignInService
        {
            get
            {
                return _signInService?? HttpContext.GetOwinContext().Get<SignInService>();
            }

            set
            {
                _signInService = value;
            }
        }

        public UserService UserService
        {
            get
            {
                return _userService;
            }

            set
            {
                _userService = value;
            }
        }

        // GET: Account
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // 这不会计入到为执行帐户锁定而统计的登录失败次数中
            // 若要在多次输入错误密码的情况下触发帐户锁定，请更改为 shouldLockout: true
            var result = await SignInService.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "无效的登录尝试。");
                    return View(model);
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignUp(string returnUrl)
        {
            return View();
        }

        public ActionResult SendCode()
        {
            return null;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}