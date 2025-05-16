namespace Fatec.Store.Carts.Api.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string CouponCode { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public void CalculateTotalAmount() => TotalAmount = Products?.Sum(product => product.Price) ?? decimal.Zero;
    }
}
