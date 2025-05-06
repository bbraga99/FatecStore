using AutoMapper;
using Fatec.Store.Product.Api.DTOs.Mappings;
using LojaFatec.ProductApi.DTOs;
using LojaFatec.ProductApi.Models;
using LojaFatec.ProductApi.Repositories;

namespace LojaFatec.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponseDTO>>(productsEntity);
        }

        public async Task<ProductResponseDTO> GetById(int id)
        {
            var productEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductResponseDTO>(productEntity);
        }
        public async Task<ProductResponseDTO> AddProduct(ProductRequestDTO productRequestDTO)
        {
            var productEntity = _mapper.Map<Product>(productRequestDTO);

            if (productEntity == null) throw new Exception("Product not found");

            await _productRepository.Create(productEntity);

            return _mapper.Map<ProductResponseDTO>(productEntity);
        }

        public async Task UpdateProduct(ProductResponseDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);

            await _productRepository.Update(productEntity);
        }

        public async Task UpdateQuantity(UpdateStockRequestDTO updateStockRequestDTO)
        {
            foreach (var item in updateStockRequestDTO.Products)
            {
                var product = await _productRepository.GetById(item.Id);

                if (product is null) throw new Exception("Product not found");

                if (product.Stock < item.Quantity) throw new Exception("Insufficient stock");

                product.Stock -= item.Quantity;

                await _productRepository.Update(product);
            }
        }

        public async Task RemoveProduct(int id)
        {
            var productEntity = _productRepository.GetById(id).Result;
            await _productRepository.Delete(productEntity.Id);
        }
    }
}
