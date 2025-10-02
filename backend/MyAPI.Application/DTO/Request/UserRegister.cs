using MyAPI.Domain.Entities;

namespace MyAPI.Application.DTO.Request;

public class UserRegister
{
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FullName { get; set; }
}