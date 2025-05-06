using LojaFatec.ProductApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaFatec.ProductApi.DTOs;

public class ProductRequestDTO
{
    [Required(ErrorMessage = "The name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required(ErrorMessage = "The price is required")]
    public double Price { get; set; }

    [Required(ErrorMessage = "The name is required")]
    [MinLength(5)]
    [MaxLength(255)]
    public string? Description { get; set; }
    public int Stock { get; set; }
    public string? ImageURL { get; set; }
    public int CategoryId { get; set; }
}
