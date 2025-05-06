namespace LojaFatec.CartApi.DTOs;

public class ProductResponseDTO
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string? Description { get; set; } = string.Empty;
    public int Stock { get; set; }
    public string? ImageURL { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;    
}
