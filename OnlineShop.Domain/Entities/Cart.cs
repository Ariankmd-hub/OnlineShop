using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
