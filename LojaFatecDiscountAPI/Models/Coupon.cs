namespace Fatec.Store.Discount.Api.Models;

public class Coupon
{
    public int CouponID { get; set; }
    public string CouponCode { get; set; }
    public bool Active { get; set; } = true;
    public int Quantity { get; set; }
    
    public double Discount { get; set; }
}
