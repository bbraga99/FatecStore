namespace Fatec.Store.Carts.Api.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}