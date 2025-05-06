using System.ComponentModel.DataAnnotations;

namespace LojaFatec.CartApi.DTOs;

public class CartHeaderResponseDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "UserId is Required")]
    public string UserID { get; set; } = string.Empty;
    public string CouponCode { get; set; } = string.Empty;
}
