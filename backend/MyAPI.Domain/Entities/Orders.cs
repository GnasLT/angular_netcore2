namespace MyAPI.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public Guid UserId { get; set; }   // Customer
    public Guid? StaffId { get; set; } // Staff xử lý
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";

    // Navigation
    public User Customer { get; set; } = default!;
    public User? Staff { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
