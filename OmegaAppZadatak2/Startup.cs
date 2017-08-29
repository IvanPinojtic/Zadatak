using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OmegaAppZadatak2.Startup))]
namespace OmegaAppZadatak2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
