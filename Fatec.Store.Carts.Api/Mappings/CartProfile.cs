using AutoMapper;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Models.DTOs.CreateCart;
using Fatec.Store.Carts.Api.Models.DTOs.GetCartByUserId;

namespace Fatec.Store.Carts.Api.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            #region CreateCart
            CreateMap<CreateCartRequest, Cart>(MemberList.None)
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => new List<Product>()));

            CreateMap<CartProductItem, Product>(MemberList.None);

            #endregion CreateCart

            #region GetCartByUserId

            CreateMap<Cart, GetCartByUserIdResponse>(MemberList.None);

            CreateMap<Product, GetCartByUserIdProductResponse>(MemberList.None);

            #endregion GetCartByUserId
        }
    }
}