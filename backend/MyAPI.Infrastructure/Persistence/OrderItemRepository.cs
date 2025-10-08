
using MyAPI.Domain.Entities;
using MyAPI.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace MyAPI.Infrastructure.Persistence;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly AppDbContext _context;


    public OrderItemRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<OrderItem>> GetAllAsync(int orderid)
    {
        return await _context.OrderItems.Where(x => x.OrderId == orderid).ToListAsync();
    }
    public async Task<OrderItem> GetByIdAsync(int productid, int orderid)
    {
        return await _context.OrderItems.FindAsync(productid,orderid);
    }
}