using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComedyClub.Startup))]
namespace ComedyClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
