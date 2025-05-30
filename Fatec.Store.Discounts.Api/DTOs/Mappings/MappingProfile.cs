﻿using AutoMapper;
using Fatec.Store.Discounts.Api.Models;

namespace Fatec.Store.Discounts.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CouponReponseDTO, Coupon>().ReverseMap();
        CreateMap<CouponRequestDTO, Coupon>().ReverseMap();
        CreateMap<CouponRequestPatchDTO, Coupon>().ReverseMap();  
    }


}
