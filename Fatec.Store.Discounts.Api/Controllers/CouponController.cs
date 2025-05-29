using Fatec.Store.Discounts.Api.DTOs;
using Fatec.Store.Discounts.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fatec.Store.Discounts.Api.Controllers;

[Route("api/coupons")]
[ApiController]
public class CouponController : ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CouponReponseDTO>>> GetAll()
    {
        var coupons = await _couponService.GetAllCoupons();   

        return Ok(coupons);
    }

    [HttpGet("{couponCode}", Name = "GetCoupon")]
    public async Task<ActionResult<CouponReponseDTO>> GetByCouponCode(string couponCode)
    {
        var coupon = await _couponService.GetCoupon(couponCode);

        return Ok(coupon);
    }

    [HttpPost]
    public async Task<ActionResult<CouponReponseDTO>> Create([FromBody] CouponRequestDTO couponRequestDTO)
    {
        var newCoupon = await _couponService.CreateCoupon(couponRequestDTO);

        return new CreatedAtRouteResult(
                        "GetCoupon", new {couponCode = newCoupon.CouponCode}, newCoupon);
    }

    [HttpPatch]
    public async Task<ActionResult<CouponReponseDTO>> UseCoupon(CouponRequestPatchDTO couponCode)
    {
        try
        {
            var usedCupom = await _couponService.UseCoupon(couponCode);

            return Ok(usedCupom);
        }
        catch(Exception e)
        {
            return e.Message switch
            {
                "CoupounNotFound" => (ActionResult<CouponReponseDTO>)BadRequest("Cupom não encontrado"),
                "AlreadyUsed" => (ActionResult<CouponReponseDTO>)BadRequest("Cupom já usado"),
                "CouponInactive" => (ActionResult<CouponReponseDTO>)BadRequest("Cupom inativo"),
                _ => (ActionResult<CouponReponseDTO>)StatusCode(500),
            };
        }
    }

    [HttpPatch("{couponCode}/disable")]
    public async Task<ActionResult<CouponReponseDTO>> Disable(string couponCode)
    {
        var coupon = await _couponService.ActiveOrInactiveCoupon(couponCode);

        return Ok(coupon);
    }
}
