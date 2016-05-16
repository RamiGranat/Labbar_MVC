using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab2_TwentyOne.Startup))]
namespace Lab2_TwentyOne
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
