using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fatec.Store.Cart.Api.Models.ServiceClientModel;

public class GetProductResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
    public int Stock { get; set; }
    public string? ImageURL { get; set; }
}
