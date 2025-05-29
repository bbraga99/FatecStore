namespace Fatec.Store.Discounts.Api.DTOs;

public class CouponRequestDTO
{
    public string? CouponCode { get; set; }
    public int Quantity { get; set; }
    public double? Discount { get; set; }
}
