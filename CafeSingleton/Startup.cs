using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CafeSingleton.Startup))]
namespace CafeSingleton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
