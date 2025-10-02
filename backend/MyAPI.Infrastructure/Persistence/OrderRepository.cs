using MyAPI.Domain.Entities;
using MyAPI.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace MyAPI.Infrastructure.Persistence;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Orders>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }
    public async Task<Orders> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }
    public async Task AddAsync(Orders orders)
    {
        await _context.Orders.AddAsync(orders);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Orders orders)
    {
        _context.Orders.Update(orders);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var orders = await _context.Orders.FindAsync(id);
        if (orders != null)
        {
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> Count()
    {
        return _context.Orders.Count();
    }
}
