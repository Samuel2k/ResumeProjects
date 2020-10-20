using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealership.UI.Startup))]
namespace CarDealership.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
