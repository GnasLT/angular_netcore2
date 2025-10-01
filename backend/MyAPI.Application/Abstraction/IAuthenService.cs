using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;


namespace MyAPI.Application.Abstraction;

public interface IAuthenService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request, string ipAddress, string userAgent);
    Task<LoginResponse> ValidateSessionAsync(Guid sessionId, string ip, string agent);
    Task<Result<object?>> LogoutAsync(Guid sessionId);
}