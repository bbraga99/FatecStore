namespace Fatec.Store.Products.Api.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; } 
}
