using MyAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Repository;
namespace MyAPI.Infrastructure.Persistence;

public class SessionRepository : ISessionRepository
{
     private readonly AppDbContext _context;  

    public SessionRepository(AppDbContext context){
        _context = context;
    } 

    public async Task<Sessions> CreateSessionAsync(Guid userId, string? ipAddress = null, string? userAgent = null)
    {
        var session = new Sessions
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddMinutes(20), 
            IpAddress = ipAddress,
            UserAgent = userAgent
        };

        await _context.Sessions.AddAsync(session);
        await _context.SaveChangesAsync();

        return session;
    }

    public async Task<Sessions?> GetByIdAsync(Guid sessionId)
    {
        return await _context.Sessions
            .Include(s => s.User) 
            .FirstOrDefaultAsync(s => s.Id == sessionId);
    }

    public async Task<bool> ValidateSessionAsync(Guid sessionId)
    {
        var session = await _context.Sessions.FindAsync(sessionId);
        if (session == null) return false;

        return session.ExpiresAt > DateTime.UtcNow;
    }

       public async Task DeleteSessionAsync(Guid sessionId)
    {
        var session = await _context.Sessions.FindAsync(sessionId);
        if (session != null)
        {
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }   
    }
}