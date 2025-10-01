

namespace MyAPI.Application.DTO.Response
{
    public class OrderResponseDTO 
    {
        public DateTime OrderDate { get; set; }

        public List<OrderItemResponseDTO> Items { get; set; }
    }

    public class OrderItemResponseDTO
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}