using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(intranetMVC.Startup))]
namespace intranetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
