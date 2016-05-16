using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab2_TicTacToe.Startup))]
namespace Lab2_TicTacToe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
