using EcommerceSite.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Products
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public decimal Price { get; set; }
}
