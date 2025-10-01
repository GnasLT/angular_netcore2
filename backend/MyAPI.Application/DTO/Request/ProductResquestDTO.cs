
using MyAPI.Domain.Entities;

namespace MyAPI.Application.DTO.Request
{
    public class ProductRequestDTO
    {
        public DateTime OrderDate { get; set; }

        public IEnumerable<ProductItems> Items { get; set; }

    }

}