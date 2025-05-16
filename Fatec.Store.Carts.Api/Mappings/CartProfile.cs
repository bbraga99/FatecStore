using AutoMapper;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Models.DTO.CreateCart;
using Fatec.Store.Carts.Api.Models.DTO.GetCartByUserId;

namespace Fatec.Store.Carts.Api.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            #region CreateCart
            CreateMap<CreateCartRequest, Cart>(MemberList.None);

            CreateMap<CartProductItem, Product>(MemberList.None);

            #endregion CreateCart

            #region GetCartByUserId

            CreateMap<Cart, GetCartByUserIdResponse>(MemberList.None);

            CreateMap<Product, GetCartByUserIdProductResponse>(MemberList.None);

            #endregion GetCartByUserId
        }
    }
}