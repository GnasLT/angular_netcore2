using MyAPI.Domain.Entities;

namespace MyAPI.Domain.Repository;

public interface ISessionRepository
{
    Task<Sessions> CreateSessionAsync(Guid userId, string? ipAddress = null, string? userAgent = null);
    Task<Sessions?> GetByIdAsync(Guid sessionId);
    Task<bool> ValidateSessionAsync(Guid sessionId);
    Task DeleteSessionAsync(Guid sessionId);
}