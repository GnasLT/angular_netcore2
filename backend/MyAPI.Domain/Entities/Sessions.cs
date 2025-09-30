using System;
using System.Collections.Generic;

namespace MyAPI.Domain.Entities;

public partial class Sessions
{
    public Guid Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool? IsActive { get; set; }

    public string? ipaddress { get; set; }

    public string? useragent { get; set; }

    public virtual Users? User { get; set; }
}
