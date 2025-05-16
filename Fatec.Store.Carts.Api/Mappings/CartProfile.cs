using AutoMapper;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Models.CreateCart;

namespace Fatec.Store.Carts.Api.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CreateCartRequest, Cart>(MemberList.None)
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => new List<Product>()));

            CreateMap<CartProductItem, Product>(MemberList.None);
        }
    }
}