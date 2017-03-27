using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BranchManager.Startup))]
namespace BranchManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
