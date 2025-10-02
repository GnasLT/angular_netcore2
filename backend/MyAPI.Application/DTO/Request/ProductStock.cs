using MyAPI.Domain.Entities;

namespace MyAPI.Application.DTO.Request;

public class ProductStock
{
    public int Id { get; set; }
    public int Stock { get; set; }
}

public class ProductPrice
{
    public int Id { get; set; }
    public int Price { get; set; }
}