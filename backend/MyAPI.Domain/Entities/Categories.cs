namespace MyAPI.Domain.Entities;


public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = default!;

    // Navigation
    public ICollection<Product> Products { get; set; } = new List<Product>();
}