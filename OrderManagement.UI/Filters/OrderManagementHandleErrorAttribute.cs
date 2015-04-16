using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.UI.Filters
{
    public class OrderManagementHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            // TODO - log exception.
            HandleCustom(filterContext);
            HandleDefault(filterContext);
            
        }

        [Conditional("DEBUG")]
        private void HandleDefault(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        [Conditional("RELEASE")]
        private void HandleCustom(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            // TODO - then forward the request to an ErrorPage.
        }
    }
}