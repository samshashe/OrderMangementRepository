
namespace OrderManagement.WebApi.Controllers
{
    using AutoMapper;
    using Microsoft.Ajax.Utilities;
    using OrderManagement.DataAccess;
    using OrderManagement.Entities;
    using OrderManagement.WebApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;

    public class OrderController : ApiController
    {
        private IOrderManagementEntities orderManagementContext;

        public OrderController(IOrderManagementEntities orderManagementContext)
        {
            this.orderManagementContext = orderManagementContext;
        }

        /// <summary>
        /// Entity Framework Get
        /// api/order/1
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderViewModel> Get(int pageNumber = 0, int pageSize = 5, string sortOrder = "asc", string sortField = "CustomerId")
        {
            var orders = orderManagementContext.Orders.Include(b => b.Customer);

            if (sortOrder.Equals("asc", StringComparison.InvariantCultureIgnoreCase))
                orders = orders.OrderBy(order => sortField);
            else
                orders = orders.OrderByDescending(order => sortField);

            orders = orders.Skip(pageSize * pageNumber).Take(pageSize);
            
            return orders.ToList().Select(order => Mapper.Map<OrderViewModel>(order));
        }
    }
}
