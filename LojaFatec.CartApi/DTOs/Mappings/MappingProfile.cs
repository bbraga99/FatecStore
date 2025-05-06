using AutoMapper;
using Fatec.Store.Cart.Api.DTOs;
using Fatec.Store.Cart.Api.DTOs.Mappings;
using LojaFatec.CartApi.Models;

namespace LojaFatec.CartApi.DTOs.Mappings;

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
