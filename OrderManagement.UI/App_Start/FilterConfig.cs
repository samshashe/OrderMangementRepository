using OrderManagement.UI.Filters;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // filters.Add(new HandleErrorAttribute());
            filters.Add(new OrderManagementHandleErrorAttribute());
        }
    }
}
