
namespace OrderManagement.WebApi.Models
{
    using System;

    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        // public decimal TotalPrice { get; set; }
    }
}