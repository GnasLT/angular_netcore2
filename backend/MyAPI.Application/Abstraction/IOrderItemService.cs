using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;

namespace MyAPI.Application.Abstraction;
public interface IOrderItemService
{

    public Task<Result<OrderResponseDTO>> AddItem(OrderItemDTO orderItemDTO);

    public Task<Result<OrderResponseDTO>> UpdateItem(OrderItemDTO orderItemDTO);

    public Task<Result<OrderResponseDTO>> DeleteItem(int productId);

}