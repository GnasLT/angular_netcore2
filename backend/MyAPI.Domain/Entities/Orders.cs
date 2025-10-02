using System;
using System.Collections.Generic;

namespace MyAPI.Domain.Entities;

public partial class Orders
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Users? User { get; set; }


    public Orders() { }

    public Orders(int id, DateTime time, int userid, ICollection <OrderItem> orderitems)
    {
        Id = id;
        UserId = userid;
        CreatedAt = time;
        this.OrderItems = orderitems;
    }

   
    // public void AddItem(int productid, int quanlity)
    // {
    //     if (quanlity <= 0)
    //         throw new ArgumentException("Quantity must be greater than 0.");
    //     OrderItems.Add(new OrderItem(productid, quanlity));
    // }

    public void AddItem(OrderItem items)
    {
        if (items.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0.");
        OrderItems.Add(items);
    }

    public void RemoveItem(int productid)
    {
        var item = OrderItems.FirstOrDefault(u => u.ProductId == productid);
        if (item != null)
        {
            OrderItems.Remove(item);
        }
    }
}
