using MyAPI.Domain.Entities;

namespace MyAPI.Domain.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Products>> GetAllAsync();
        public Task<Products> GetByIdAsync(int id);
        public Task AddAsync(Products product);
        public Task UpdateAsync(Products product);
        public Task DeleteAsync(int id);
    }
}