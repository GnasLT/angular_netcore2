using MyAPI.Application.Abstraction;
using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;
using MyAPI.Domain.Entities;
using MyAPI.Domain.Repository;

namespace MyAPI.Application.Service;

public class AdminService : IAdminService
{
    IUserRepository _userRepository;

    public AdminService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<object>> ChangeRole(UserRequest request)
    {
        Users user = await _userRepository.GetByIdAsync(request.Id);
        if (user != null)
        {
            user.Role = request.Role;
            _userRepository.UpdateAsync(user);
            return await Result<object>.SuccessResult(null, "Role is changed");
        }
        return await Result<object>.FailureResult("Can't find user");
    }

    public async Task<Result<object>> Register(UserRegister request)
    {
        var check = await _userRepository.GetByEmailAsync(request.Email);
        if (check == null)
        {
            int id = await _userRepository.Count() + 1;
            Users newuser = new Users(id, request.Email, request.PasswordHash, request.FullName, DateTime.UtcNow);
            await _userRepository.AddAsync(newuser);

            return await Result<object>.SuccessResult(null, "User added");
        }
            
        return await Result<object>.FailureResult("Can't create user");
    }
}
