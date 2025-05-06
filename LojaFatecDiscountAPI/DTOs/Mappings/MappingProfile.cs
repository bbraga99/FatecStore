using AutoMapper;
using Fatec.Store.Discount.Api.Models;

namespace Fatec.Store.Discount.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CouponReponseDTO, Coupon>().ReverseMap();
        CreateMap<CouponRequestDTO, Coupon>().ReverseMap();
        CreateMap<CouponRequestPatchDTO, Coupon>().ReverseMap();  
    }


}
