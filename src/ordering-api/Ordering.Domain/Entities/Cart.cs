using Ordering.Domain.Exception;

namespace Ordering.Domain.Entities
{
    public class Cart: DomainEntity
    {
        public Guid CustomerId { get; set; }
        public List<CartItem> Items { get; set; } = [];

        public Cart()
        {
        }

        public Cart(Guid id, Guid customerId, List<CartItem> items)
        {
            Id = id;
            CustomerId = customerId;
            if (!items.Any()) throw new CoreBusinessException("Invalid number of units");
            Items = items;
        }
    }
}
