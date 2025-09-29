namespace MyAPI.Domain.Entities;

public class Sessions
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string? UserAgent { get; set; }
    
    // Navigation
    public Users User { get; set; } = default!;
}