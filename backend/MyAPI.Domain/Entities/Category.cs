
namespace MyAPI.Domain.Entities;
public class Category
{
    public int id { get; set; }

    public string name { get; set; } = string.Empty;

   
    public ICollection<Products> Products { get; set; } = new List<Products>();
}