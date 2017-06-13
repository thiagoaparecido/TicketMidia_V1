using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketMidia.Startup))]
namespace TicketMidia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
