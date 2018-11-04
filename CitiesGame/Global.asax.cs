using CitiesGame.Models.DI;
using CitiesGame.Models.Entities;
using CitiesGame.Models.Interfaces;
using CitiesGame.Models.Repositories.ADO;
using CitiesGame.Models.Repositories.EF;
using CitiesGame.Models.Repositories.IO;
using System.Web.Mvc;
using System.Web.Routing;

namespace CitiesGame
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            CustomDependencyResolver.Bind<IRepository<City>, IoRepository>();
            DependencyResolver.SetResolver(new CustomDependencyResolver());
        }
    }
}
