using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.UI.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        [OrderManagement.UI.Filters.OrderManagementHandleError]
        public ActionResult Index()
        {
            //throw new Exception("foo");
            return View();
        }
	}
}