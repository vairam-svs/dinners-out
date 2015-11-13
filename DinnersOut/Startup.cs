using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DinnersOut.Startup))]
namespace DinnersOut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
