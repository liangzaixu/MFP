using System.Threading.Tasks;
using System.Web;
using MFP.Service.Identity;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using MFP.Model.Identity;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Principal;
    using Microsoft.AspNet.Identity;

namespace MFP.MvcExtension
{
    public class BaseController : Controller
    {
        private readonly UserService _userSer;
        private UserViewModel _onlineUser;

        public BaseController() : base()
        {

        }

        public BaseController(UserService userService) : this()
        {
            _userSer = userService;
        }

        public UserService UserSer
        {
            get
            {
                return _userSer ?? HttpContext.GetOwinContext().Get<UserService>();
            }
        }

        protected UserViewModel OnlineUser
        {
            get
            {
                if (_onlineUser != null)
                {
                    return _onlineUser;
                }

                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    _onlineUser = HttpContext.Session["userinfo_" + HttpContext.User.Identity.GetUserId().ToLower()] as UserViewModel;
                }

                if (_onlineUser == null)
                {
                    _onlineUser = new UserViewModel();
                }
                return _onlineUser;
            }
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
           if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string key = "userinfo_"+ filterContext.HttpContext.User.Identity.GetUserId().ToLower();
                object obj = filterContext.HttpContext.Session[key];
                
                if (obj == null)
                {
                    _onlineUser = UserSer.GetUser(User);
                    filterContext.HttpContext.Session[key] = _onlineUser;
                }
            }
            base.OnAuthentication(filterContext);
        }
    }
}
