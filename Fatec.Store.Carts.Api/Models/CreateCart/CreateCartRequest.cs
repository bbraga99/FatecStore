namespace Fatec.Store.Carts.Api.Models.CreateCart
{
    public class CreateCartRequest
    {
        public int UserId { get; set; }

        public string CouponCode { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public IEnumerable<CartProductItem> Products { get; set; }
    }
}
