using MyAPI.Domain.Entities;

namespace MyAPI.Application.DTO.Request;

public class UserRequest
{
    public int Id { get; set; }
    public string Role { get; set; }
}