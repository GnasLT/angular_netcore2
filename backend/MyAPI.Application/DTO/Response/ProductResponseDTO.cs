
using MyAPI.Application.DTO.Request;
using MyAPI.Domain.Entities;

namespace MyAPI.Application.DTO.Response;

public class ProductReponseDTO
{
    public DateTime OrderDate { get; set; }

    public List<ProductItemsResponseDTO> Items { get; set; } = new List<ProductItemsResponseDTO>();

}

public class ProductItemsResponseDTO
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int Categories{ get; set; }
}
