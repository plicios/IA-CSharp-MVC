using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IA_lab6.Startup))]
namespace IA_lab6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
