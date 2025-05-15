using System.ComponentModel.DataAnnotations;

namespace Fatec.Store.Carts.Api.DTOs;

public class CartHeaderResponseDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "UserId is Required")]
    public string UserID { get; set; } = string.Empty;
    public string CouponCode { get; set; } = string.Empty;
}
