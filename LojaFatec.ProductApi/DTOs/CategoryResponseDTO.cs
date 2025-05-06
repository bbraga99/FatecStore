using System.ComponentModel.DataAnnotations;
using LojaFatec.ProductApi.Models;

namespace LojaFatec.ProductApi.DTOs;

public class CategoryResponseDTO
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "The name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
