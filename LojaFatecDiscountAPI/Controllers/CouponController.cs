using Fatec.Store.Discount.Api.DTOs;
using Fatec.Store.Discount.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fatec.Store.Discount.Api.Controllers;

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
        var usedCupom = await _couponService.UseCoupon(couponCode);

        return Ok(usedCupom);
    }

    [HttpDelete]
    public async Task<ActionResult<CouponReponseDTO>> Disable(string couponCode)
    {
        var coupon = await _couponService.DisableCoupon(couponCode);

        return Ok(coupon);
    }
}
