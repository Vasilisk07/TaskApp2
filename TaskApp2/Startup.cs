using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskApp2.Startup))]
namespace TaskApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
