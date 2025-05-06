namespace LojaFatec.CartApi.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }
    public string? ImageURL { get; set; }
    public string CategoryName { get; set; }
}
