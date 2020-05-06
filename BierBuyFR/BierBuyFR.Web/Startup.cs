using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BierBuyFR.Web.Startup))]
namespace BierBuyFR.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
