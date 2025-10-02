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

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ISessionRepository sessionRepository)
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
}