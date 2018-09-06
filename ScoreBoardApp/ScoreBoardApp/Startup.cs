using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScoreBoardApp.Startup))]
namespace ScoreBoardApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
