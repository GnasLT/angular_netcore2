using System;
using System.Collections.Generic;

namespace MyAPI.Domain.Entities;

public partial class Products
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int categoryid { get; set; }

    public Category? category { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public Products(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public bool IncreaseStock(int amount)
    {
        if (amount < 0)
        {
            return false;
        }
        Stock += amount;
        return true;
    }
      public bool DecreaseStock(int amount)
    {
        if (amount < 0) return false;
        if (amount > Stock) return false;
        Stock -= amount;
        return true;
    }

     public void UpdateProduct(string name, decimal price, int stock)
    {
        Name = name ?? throw new InvalidOperationException("Name cannot be null");
        Price = price;
        Stock = stock;
    }
}
