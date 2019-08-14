using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inventario.Startup))]
namespace Inventario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
