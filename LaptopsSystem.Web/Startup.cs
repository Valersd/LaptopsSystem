using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaptopsSystem.Web.Startup))]
namespace LaptopsSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
