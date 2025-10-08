using MyAPI.Domain.Entities;

namespace MyAPI.Domain.Repository;

public interface IOrderItemRepository
{
    public Task<IEnumerable<OrderItem>> GetAllAsync(int orderid);
    public Task<OrderItem> GetByIdAsync(int productid,int orderid);
}