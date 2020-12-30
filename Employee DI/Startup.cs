using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Employee_DI.Startup))]
namespace Employee_DI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
