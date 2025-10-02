

namespace MyAPI.Application.DTO.Request
{
    public class OrderRequestDTO
    {
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItemDTO> Items { get; set; }
    }

    public class OrderItemDTO
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public OrderItemDTO() { }

        public OrderItemDTO(int productid, int quantity)
        {
            ProductId = productid;
            Quantity = quantity;
        }
    }
}