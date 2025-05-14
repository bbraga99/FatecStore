using Fatec.Store.Cart.Api.Models.ServiceClientModel;

namespace Fatec.Store.Cart.Api.ServicesClient;

public interface IProcutServiceClient
{
    public Task<GetProductResponse> GetProduct(int id);
}
