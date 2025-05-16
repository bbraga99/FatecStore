using Fatec.Store.Carts.Api.Models.CreateCart;

namespace Fatec.Store.Carts.Api.Domain.Interfaces.Services
{
    public interface ICartsService
    {
        Task CreateCartAsync(CreateCartRequest cartRequest);
    }
}
