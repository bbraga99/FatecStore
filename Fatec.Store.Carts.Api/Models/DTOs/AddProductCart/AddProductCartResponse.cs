using Fatec.Store.Carts.Api.Domain.Entities;

namespace Fatec.Store.Carts.Api.Models.DTOs.AddProductCart
{
    public class AddProductCartResponse(int cartAmountItens)
    {
        public int CartAmountItens { get; set; } = cartAmountItens;
    }
}
