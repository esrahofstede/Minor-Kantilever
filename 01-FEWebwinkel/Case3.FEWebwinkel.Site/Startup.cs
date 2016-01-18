using Microsoft.Owin;
using Owin;
using System.Diagnostics.CodeAnalysis;

[assembly: OwinStartupAttribute(typeof(Case3.FEWebwinkel.Site.Startup))]
namespace Case3.FEWebwinkel.Site
{
    [ExcludeFromCodeCoverage]
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
