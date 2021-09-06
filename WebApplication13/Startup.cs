using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SweetsShop.Startup))]
namespace SweetsShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
