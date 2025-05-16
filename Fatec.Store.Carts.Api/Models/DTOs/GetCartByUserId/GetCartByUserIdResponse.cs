namespace Fatec.Store.Carts.Api.Models.DTO.GetCartByUserId
{
    public class GetCartByUserIdResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string CouponCode { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public IEnumerable<GetCartByUserIdProductResponse> Products { get; set; }
    }

    public class GetCartByUserIdProductResponse
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
