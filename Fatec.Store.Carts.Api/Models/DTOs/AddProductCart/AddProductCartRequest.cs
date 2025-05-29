namespace Fatec.Store.Carts.Api.Models.DTOs.AddProductCart
{
    public class AddProductCartRequest
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }
    }
}
