namespace MyAPI.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string PasswordHash { get; set; } = default!;
    public string? FullName { get; set; }
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }
    public string RoleName { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    // Navigation
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
    public ICollection<Order> CustomerOrders { get; set; } = new List<Order>();
    public ICollection<Order> StaffOrders { get; set; } = new List<Order>();
}