using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;


namespace MyAPI.Application.Abstraction;

public interface IAdminService
{
    public Task<Result<object>> ChangeRole(UserRequest user);
    public Task<Result<object>> Register(UserRegister user);
}