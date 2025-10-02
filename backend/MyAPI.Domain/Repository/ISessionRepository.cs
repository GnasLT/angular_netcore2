using MyAPI.Domain.Entities;

namespace MyAPI.Domain.Repository;

public interface ISessionRepository
{
    Task<Sessions> CreateSessionAsync(int userId, string? ipAddress = null, string? userAgent = null);
    Task<Sessions?> GetByIdAsync(Guid sessionId);
    Task<Sessions?> GetByUserIdAsync(int userid);
    Task<bool> ValidateSessionAsync(Guid sessionId);
    Task DeleteSessionAsync(Guid sessionId);
    Task ExtendTime(Guid sessionId);

}