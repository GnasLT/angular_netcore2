using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;


namespace MyAPI.Application.Abstraction;

public interface IAuthenService
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);
    Task<bool> ValidateSessionAsync(Guid sessionId);
}