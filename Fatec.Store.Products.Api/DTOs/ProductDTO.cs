﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Fatec.Store.Products.Api.Models;

namespace Fatec.Store.Products.Api.DTOs;

public class ProductResponseDTO
{
    public int Id { get; set; }

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

    [JsonIgnore]
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}
