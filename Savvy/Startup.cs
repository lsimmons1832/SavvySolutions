using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Savvy.Startup))]
namespace Savvy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
