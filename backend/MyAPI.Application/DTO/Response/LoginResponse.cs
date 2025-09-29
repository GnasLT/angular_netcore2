namespace MyAPI.Application.DTO.Response;
public class LoginResponse
{
    public Guid SessionId { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
}