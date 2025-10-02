

namespace MyAPI.Application.DTO.Response
{
    public class OrderResponseDTO 
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderItemResponseDTO> Items { get; set; } = new List<OrderItemResponseDTO>();

    }

    public class OrderItemResponseDTO
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}