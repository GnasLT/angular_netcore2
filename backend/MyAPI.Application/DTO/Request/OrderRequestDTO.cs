

namespace MyAPI.Application.DTO.Request
{
    public class OrderRequestDTO
    {
        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderItemDTO> Items { get; set; }
    }

    public class OrderItemDTO
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}