using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCCBakery.Startup))]
namespace SCCBakery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
