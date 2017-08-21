using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Selectcomp.WEB.Startup))]
namespace Selectcomp.WEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
