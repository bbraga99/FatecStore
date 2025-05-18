namespace Fatec.Store.Carts.Api.Models.DTOs.CreateCart
{
    public class CartProductItem
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
