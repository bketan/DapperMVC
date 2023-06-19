using DapperMVC.Data.Models.Domain;

namespace DapperMVC.Data.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}