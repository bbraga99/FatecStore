using AutoMapper;
using Fatec.Store.Carts.Api.Models;

namespace Fatec.Store.Carts.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cart, CartResponseDTO>().ReverseMap();

        CreateMap<CartHeader, CartHeaderResponseDTO>().ReverseMap();

        CreateMap<CartItem, CartItemResponseDTO>().ReverseMap();    

        CreateMap<Product, ProductResponseDTO>().ReverseMap();

        CreateMap<Cart, CartRequestDTO>().ReverseMap();

        CreateMap<CartItem, CartItemRequestDTO>().ReverseMap(); 

        CreateMap<Product, ProductRequestDTO>().ReverseMap();   
    }
    
}
