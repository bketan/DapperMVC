using DapperMVC.Data.DataAccess;
using DapperMVC.Data.Models.Domain;
using System.Linq.Expressions;

namespace DapperMVC.Data.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ISqlDataAccess _db;
    public ProductRepository(ISqlDataAccess db)
    { 
        _db = db; 
    }

    public async Task<bool> AddAsync(Product product)
    {
        try
        {
            await _db.SaveData("sp_create_product", new { product.ProductName, product.ProductDesc, product.Price, product.Qty });
            return true;
        }
            
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        try
        {
            await _db.SaveData("sp_update_product", product);
            return true;
        }

        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            await _db.SaveData("sp_delete_product", new { ProductID= id});
            return true;
        }

        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        IEnumerable<Product> result = await _db.GetData<Product, dynamic > ("sp_get_product", new { ProductID = id });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _db.GetData<Product, dynamic>("sp_get_products", new {});
    }

}

