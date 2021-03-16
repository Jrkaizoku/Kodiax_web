using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kodimax_web.Startup))]
namespace Kodimax_web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
