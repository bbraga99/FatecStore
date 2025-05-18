using AutoMapper;
using Fatec.Store.Carts.Api.Domain.Entities;
using Fatec.Store.Carts.Api.Models.DTOs.AddProductCart;

namespace Fatec.Store.Carts.Api.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductCartRequest, Product>(MemberList.None);
        }
    }
}
