using Fatec.Store.Products.Api.DTOs;
using Fatec.Store.Products.Api.DTOs.Mappings;

namespace Fatec.Store.Products.Api.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDTO>> GetProducts();
    Task<ProductResponseDTO> GetById(int id);
    Task<ProductResponseDTO> AddProduct(ProductRequestDTO productRequestDTO);
    Task UpdateProduct(ProductResponseDTO productDTO);
    Task UpdateQuantity(UpdateStockRequestDTO updateStockRequestDTO);
    Task RemoveProduct(int id);
}
