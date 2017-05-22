using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingList.Startup))]
namespace ShoppingList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
