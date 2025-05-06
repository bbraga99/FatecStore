namespace Fatec.Store.Discount.Api.DTOs;

public class CouponRequestDTO
{
    public string? CouponCode { get; set; }
    public int Quantity { get; set; }
    public double? Discount { get; set; }
}
