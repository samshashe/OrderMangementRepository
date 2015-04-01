
namespace OrderManagement.DataAccess
{
    using System.Collections.Generic;
    using OrderManagement.Entities;

    public interface IOrderRepository
    {
        int AddOrder(Order order);

        IEnumerable<Customer> GetCustomers();

        IEnumerable<Order> GetOrders();

        IEnumerable<OrderItem> GetOrderItems(int orderId);
    }
}
