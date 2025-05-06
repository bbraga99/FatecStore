using AutoMapper;
using Fatec.Store.Product.Api.DTOs;
using Fatec.Store.Product.Api.DTOs.Mappings;
using LojaFatec.ProductApi.Models;

namespace LojaFatec.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryResponseDTO>().ReverseMap();

        CreateMap<Category, CategoryRequestDTO>().ReverseMap();  

        CreateMap<Product, ProductResponseDTO>().ReverseMap();

        CreateMap<Product, ProductRequestDTO>().ReverseMap();

        CreateMap<Product, UpdateStockRequestDTO>().ReverseMap();

        CreateMap<Product, ProductQuantityDTO>().ReverseMap();  
    } 
}
