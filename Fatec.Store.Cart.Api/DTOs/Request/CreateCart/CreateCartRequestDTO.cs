namespace Fatec.Store.Carts.Api.DTOs.Request.CreateCart
{
    public class CreateCartRequestDTO
    {
        public CartHeaderRequestDTO CartHeader { get; set; }

        public IEnumerable<CartItemRequestDTO> CartItens { get; set; }
    }

    public class CartHeaderRequestDTO
    {
        public int UserId { get; set; }

        public string CouponCode { get; set; }
    }

    public class CartItemRequestDTO
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
