using AutoMapper;
using Fatec.Store.Carts.Api.DTOs.Request.CreateCart;
using Fatec.Store.Carts.Api.Models;

namespace Fatec.Store.Carts.Api.DTOs.Mappings
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartRequestDTO, Cart>();
        }
    }
}
