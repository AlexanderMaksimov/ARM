using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaseForTheAges.Startup))]
namespace BaseForTheAges
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
