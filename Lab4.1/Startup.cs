using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab4._1.Startup))]
namespace Lab4._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
