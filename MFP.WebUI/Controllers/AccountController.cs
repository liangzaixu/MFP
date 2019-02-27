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


        public SignInService SigninSer
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

        public UserService UserSer
        {
            get
            {
                return _userService ?? HttpContext.GetOwinContext().Get<UserService>();
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
        public ActionResult SignIn(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(LoginViewModel model,string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // 这不会计入到为执行帐户锁定而统计的登录失败次数中
            // 若要在多次输入错误密码的情况下触发帐户锁定，请更改为 shouldLockout: true
             var result = await SigninSer.PasswordSignInAsync(model.AccountId, model.Password, model.RememberMe, shouldLockout: false);
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
        }

        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task< ActionResult> SignUp(RegisterViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityResult result = await UserSer.CreateAsync(model);
            if (result.Succeeded)
            {
                var  signResult = await SigninSer.PasswordSignInAsync(model.UserId, model.Password,true,false);
                switch (signResult)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl);
                    default:
                        ModelState.AddModelError("", "无效的登录尝试。");
                        return View(model);
                }
            }
            return View(model);
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