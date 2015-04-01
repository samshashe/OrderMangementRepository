
namespace OrderManagement.DataAccess
{
    using OrderManagement.Entities;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;

    public class OrderRepository : IOrderRepository
    {
        private string connectionString;


        public OrderRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["OrderManagementConnectionString"].ConnectionString;
        }

        public int AddOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var query =
                    @"INSERT INTO [Order](CustomerId, OrderDate) VALUES({0}, '{1}');
                    SELECT SCOPE_IDENTITY() AS OrderId;";

                query = string.Format(query, order.CustomerId, order.OrderDate);

                using (var command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    var orderId = command.ExecuteScalar();

                    return Convert.ToInt32(orderId);
                }
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var query =
                    @"SELECT
	                    CustomerId,
	                    Name,
	                    Address
                    FROM
	                    Customer WITH (NOLOCK)";

                using (var command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var customers = new List<Customer>();

                        while (reader.Read())
                        {
                            customers.Add(new Customer()
                            {
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                Name = Convert.ToString(reader["Name"]),
                                Address = Convert.ToString(reader["Address"]),
                            });
                        }

                        return customers;
                    }
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var query =
                    @"SELECT
	                    OrderId,
	                    CustomerId,
	                    OrderDate
                    FROM
	                    [Order] WITH (NOLOCK)";

                using (var command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var orders = new List<Order>();

                        while (reader.Read())
                        {
                            orders.Add(new Order()
                            {
                                OrderId = Convert.ToInt32(reader["OrderId"]),
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                OrderDate = Convert.ToDateTime(reader["OrderDate"])
                            });
                        }

                        return orders;
                    }
                }
            }
        }

        public IEnumerable<OrderItem> GetOrderItems(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                var query =
                    @"SELECT
	                    OrderId,
	                    ProductId,
	                    Quantity
                    FROM
	                    OrderItem
                    WHERE
                        OrderId = {0} WITH (NOLOCK)";

                query = string.Format(query, orderId);

                using (var command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var orderItems = new List<OrderItem>();

                        while (reader.Read())
                        {
                            orderItems.Add(new OrderItem()
                            {
                                OrderId = Convert.ToInt32(reader["OrderId"]),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                            });
                        }

                        return orderItems;
                    }
                }
            }
        }
    }
}
