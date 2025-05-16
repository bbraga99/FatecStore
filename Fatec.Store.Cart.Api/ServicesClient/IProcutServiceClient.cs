using Fatec.Store.Carts.Api.Models.ServiceClientModel;

namespace Fatec.Store.Carts.Api.ServicesClient;

public interface IProcutServiceClient
{
    public Task<GetProductResponse> GetProduct(int id);
}
