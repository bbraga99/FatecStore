namespace Fatec.Store.Discount.Api.Models;
public class UserCoupon
{
    public int Id { get; set; }
    public string? UserID { get; set; }
    public string? CouponCode { get; set; }
    public DateTime UsedAt { get; set; }
}
