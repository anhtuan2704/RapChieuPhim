using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLRCP.Startup))]
namespace QLRCP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
