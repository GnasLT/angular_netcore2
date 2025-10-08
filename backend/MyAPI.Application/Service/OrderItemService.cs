using MyAPI.Application.Abstraction;
using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;
using MyAPI.Domain.Entities;
using MyAPI.Domain.Repository;


namespace MyAPI.Application.Service;
public class OrderItemService : IOrderItemService
{

    public async Task<Result<OrderResponseDTO>> AddItem(OrderItemDTO productRequest)
    {


        return await Result<OrderResponseDTO>.FailureResult("adding failure");
    }

    public async Task<Result<OrderResponseDTO>> UpdateItem(OrderItemDTO productRequest)
    {

        return await Result<OrderResponseDTO>.FailureResult("adding failure");
    }

    public async Task<Result<OrderResponseDTO>> DeleteItem(int productId)
    {

        return await Result<OrderResponseDTO>.FailureResult("adding failure");
    }


}