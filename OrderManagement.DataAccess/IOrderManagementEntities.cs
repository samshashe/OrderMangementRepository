using System.Data.Entity;

namespace OrderManagement.DataAccess
{
    public interface IOrderManagementEntities
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Product> Products { get; set; }
    }
}
