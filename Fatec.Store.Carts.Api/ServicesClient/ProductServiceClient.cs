using Fatec.Store.Carts.Api.Models.ServiceClientModel;

namespace Fatec.Store.Carts.Api.ServicesClient
{
    public class ProductServiceClient : IProcutServiceClient
    {
        private readonly HttpClient _httpClient;

        private readonly string _ProductUrl;

        public ProductServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _ProductUrl = "http://localhost:5288/api/Products";
        }
        public async Task<GetProductResponse> GetProduct(int id)
        {
            var response = await _httpClient.GetAsync($"{_ProductUrl}/{id}");
            var content = await response.Content.ReadFromJsonAsync<GetProductResponse>();

            return content;
        }
    }
}
