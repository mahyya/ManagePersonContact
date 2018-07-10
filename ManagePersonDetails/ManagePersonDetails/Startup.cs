using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagePersonDetails.Startup))]
namespace ManagePersonDetails
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
