using Microsoft.Owin;
using Owin;
[assembly: OwinStartupAttribute(typeof(OptingZ.Startup))]
namespace OptingZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}