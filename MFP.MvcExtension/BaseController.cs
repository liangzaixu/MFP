using System.Threading.Tasks;
using System.Web;
using MFP.Service.Identity;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using MFP.Model.Identity;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;

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
                return _onlineUser;
            }
        }

        protected override  void  OnAuthentication(AuthenticationContext filterContext)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                _onlineUser =  UserSer.GetUser(User);
            }
            base.OnAuthentication(filterContext);

        }
    }
}
