using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFace.Startup))]
namespace WebFace
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
