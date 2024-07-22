namespace Ordering.Domain.Entities
{
    public class CartItem : DomainEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public Guid CartId { get; set; }
    }
}
