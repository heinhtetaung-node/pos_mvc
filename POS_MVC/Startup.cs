using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(POS_MVC.Startup))]
namespace POS_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
