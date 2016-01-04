using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Case3.FEWebwinkel.Site.Startup))]
namespace Case3.FEWebwinkel.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
