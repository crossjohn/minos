using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HpAer.Startup))]
namespace HpAer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
