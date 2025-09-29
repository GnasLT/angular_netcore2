namespace MyAPI.Domain.Entities;

public class Users
{
    public Guid Id { get; set; }
    public string PasswordHash { get; set; } = default!;
    public string? FullName { get; set; }
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }
    public string Role { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    // Navigation
    public ICollection<Sessions> Sessions { get; set; } = new List<Sessions>();
    public ICollection<Orders> CustomerOrders { get; set; } = new List<Orders>();
    public ICollection<Orders> StaffOrders { get; set; } = new List<Orders>();
}