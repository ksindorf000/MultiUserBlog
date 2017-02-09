using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blogit.Startup))]
namespace Blogit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
