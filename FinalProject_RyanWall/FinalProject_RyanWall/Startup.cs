using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalProject_RyanWall.Startup))]
namespace FinalProject_RyanWall
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
