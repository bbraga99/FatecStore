using System.ComponentModel.DataAnnotations;

namespace Fatec.Store.Discounts.Api.DTOs;

public class CouponReponseDTO
{
    public int CouponID { get; set; }
    
    [Required]
    public string? CouponCode { get; set; }
    public bool Active { get; set; }
    public int Quantity { get; set; }
    
    [Required]
    public double Discount { get; set; }
}
