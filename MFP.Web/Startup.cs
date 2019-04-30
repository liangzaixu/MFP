using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MFP.Web.Startup))]
namespace MFP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
