using System;
using System.Collections.Generic;

namespace MyAPI.Domain.Entities;

public partial class Orders
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Users? User { get; set; }
}
