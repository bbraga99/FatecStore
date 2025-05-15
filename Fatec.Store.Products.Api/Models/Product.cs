﻿namespace Fatec.Store.Products.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }
    public string? ImageURL { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}
