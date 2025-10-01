using System;
using System.Collections.Generic;

namespace MyAPI.Domain.Entities;

public partial class Products
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public Products(int id, string name, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

     public void UpdateProduct(string name, decimal price, int stock)
    {
        Name = name ?? throw new InvalidOperationException("Name cannot be null");
        Price = price;
        Stock = stock;
    }
}
