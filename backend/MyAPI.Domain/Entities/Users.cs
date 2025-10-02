using System;
using System.Collections.Generic;

namespace MyAPI.Domain.Entities;

public partial class Users
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FullName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Role { get; set; } = "customer";


    public Users()
    {
        
    }
    public Users(int id, string email, string password, string fullname, DateTime time)
    {
        Id = id;
        Email = email;
        PasswordHash = password;
        FullName = fullname;
        Role = default;
        CreatedAt = time;
        Username = fullname;
    }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();

    public virtual ICollection<Sessions> Sessions { get; set; } = new List<Sessions>();
}
