using MyAPI.Domain.Entities;

namespace MyAPI.Domain.Repository;

public interface IOrderRepository
{
    public Task<IEnumerable<Orders>> GetAllAsync();
    public Task<Orders> GetByIdAsync(int id);
    public Task AddAsync(Orders orders);
    public Task UpdateAsync(Orders orders);
    public Task DeleteAsync(int id);

    Task<int> Count();
}