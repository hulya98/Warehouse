using Warehouse.Core.Enums;

namespace Warehouse.Core.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public Customer Customer { get; set; }

        public Order(Customer customer)
        {
            Customer = customer;
        }

        public Product Product { get; set; }
    }
}
