

using MyAPI.Domain.Entities;

namespace MyAPI.Application.DTO.Request
{
    public class ProductItems
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }

    
}