using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;



namespace MyAPI.Application.Abstraction;

public interface IOrderService
{
    public Task<Result<OrderResponseDTO>> CreateOrder(OrderRequestDTO orderdto, Guid sessionid);
}