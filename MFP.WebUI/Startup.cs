using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MFP.WebUI.Startup))]
namespace MFP.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
