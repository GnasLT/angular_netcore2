using MyAPI.Domain.Entities;

namespace MyAPI.Domain.Repository;

public interface IUserRepository
{
    Task<IEnumerable<Users>> GetAllAsync();
    Task<Users?> GetByIdAsync(int id);
    Task<Users?> GetByEmailAsync(string email);
    Task AddAsync(Users user);
    Task UpdateAsync(Users user);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}