using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraphMapper.Startup))]
namespace GraphMapper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
