using AutoMapper;
using Fatec.Store.Products.Api.Models;

namespace Fatec.Store.Products.Api.DTOs.Mappings;

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
