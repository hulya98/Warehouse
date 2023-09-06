namespace Warehouse.Core.Domain.Entities
{
    public class ProductCustomer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
