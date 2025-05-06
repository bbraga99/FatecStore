using Fatec.Store.Product.Api.DTOs.Mappings;
using LojaFatec.ProductApi.DTOs;
using LojaFatec.ProductApi.Models;

namespace LojaFatec.ProductApi.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDTO>> GetProducts();
    Task<ProductResponseDTO> GetById(int id);
    Task<ProductResponseDTO> AddProduct(ProductRequestDTO productRequestDTO);
    Task UpdateProduct(ProductResponseDTO productDTO);
    Task UpdateQuantity(UpdateStockRequestDTO updateStockRequestDTO);
    Task RemoveProduct(int id);
}
