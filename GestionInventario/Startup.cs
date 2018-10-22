using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionInventario.Startup))]
namespace GestionInventario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
