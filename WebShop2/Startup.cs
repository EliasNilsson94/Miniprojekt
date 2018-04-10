using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebShop2.Startup))]
namespace WebShop2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
