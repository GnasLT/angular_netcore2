using MyAPI.Application.Abstraction;
using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;
using MyAPI.Domain.Entities;
using MyAPI.Domain.Repository;

namespace MyAPI.Application.Service;


public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ISessionRepository _sessionRepository;

    public OrderService(IOrderRepository orderRepository,
    IProductRepository productRepository,
    ISessionRepository sessionRepository)

    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _sessionRepository = sessionRepository;
    }


    public async Task<Result<OrderResponseDTO>> CreateOrder(OrderRequestDTO orderdto, Guid sessionid)
    {
        var session = await _sessionRepository.GetByIdAsync(sessionid);
        var orderItems = orderdto.Items
            .Select(i => new OrderItem(i.ProductId, i.Quantity))
            .ToList();
        int id = await _orderRepository.Count();
        var order = new Orders(id, orderdto.OrderDate, session.UserId, orderItems);

        foreach (var item in orderItems)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            if (product == null)
                return await Result<OrderResponseDTO>.FailureResult($"Product {item.ProductId} not found");
            if (product.Stock < item.Quantity)
                return await Result<OrderResponseDTO>.FailureResult($"Not enough stock for product {product.Name}");

            product.DecreaseStock(item.Quantity);
            await _productRepository.UpdateAsync(product);
        }
        await _orderRepository.AddAsync(order);

        var response = new OrderResponseDTO
        {
            OrderId = order.Id,
            OrderDate = order.CreatedAt,
            CustomerId = order.UserId,
            Items = order.OrderItems.Select(i => new OrderItemResponseDTO
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };
        return await Result<OrderResponseDTO>.SuccessResult(response, "Order created successfully");
    }

    public async Task<Result<OrderResponseDTO>> UpdateOrder(OrderIDRequest orderdto)
    {
        var order = await _orderRepository.GetByIdAsync(orderdto.id);
        if (order != null)
        {
            foreach (var item in orderdto.Items)
            {
                order.AddItem(new OrderItem(item.ProductId, item.Quantity));
            }
            await _orderRepository.UpdateAsync(order);
            return await Result<OrderResponseDTO>.SuccessResult(null, "Updated");
        }

        return await Result<OrderResponseDTO>.FailureResult("Can't find order");
    }

    public async Task<Result<OrderResponseDTO>> DeleteOrder(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order != null)
        {
            await _orderRepository.DeleteAsync(id);
            return await Result<OrderResponseDTO>.SuccessResult(null, "Deleted");
        }
        return await Result<OrderResponseDTO>.FailureResult("Can't find order");
    }
    
     public async Task<IEnumerable<Orders>> GetAllOrder()
    {
        return await _orderRepository.GetAllAsync();
    }
}