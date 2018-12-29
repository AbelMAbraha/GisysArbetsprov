using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GisysArbetsprov.Startup))]
namespace GisysArbetsprov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
