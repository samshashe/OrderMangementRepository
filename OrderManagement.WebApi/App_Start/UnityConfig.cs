using Microsoft.Practices.Unity;
using OrderManagement.DataAccess;
using System.Web.Http;
using Unity.WebApi;

namespace OrderManagement.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IOrderManagementEntities, OrderManagementEntities>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}