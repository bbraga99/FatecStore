using System.ComponentModel.DataAnnotations;

namespace LojaFatec.ProductApi.DTOs;

public class CategoryRequestDTO
{
    [Required(ErrorMessage = "The name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
}
