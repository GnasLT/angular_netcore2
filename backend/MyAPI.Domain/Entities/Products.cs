namespace MyAPI.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = default!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int? CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    // Navigation
    public Category? Category { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}