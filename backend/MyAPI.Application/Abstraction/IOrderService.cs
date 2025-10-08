using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;
using MyAPI.Domain.Entities;



namespace MyAPI.Application.Abstraction;

public interface IOrderService
{
    public Task<Result<OrderResponseDTO>> CreateOrder(OrderRequestDTO orderdto, Guid sessionid);
    public Task<Result<OrderResponseDTO>> UpdateOrder(OrderIDRequest order);
    public Task<Result<OrderResponseDTO>> DeleteOrder(int id);
    public Task<IEnumerable<Orders>> GetAllOrder();
}