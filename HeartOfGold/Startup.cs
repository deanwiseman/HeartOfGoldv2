using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeartOfGold.Startup))]
namespace HeartOfGold
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
