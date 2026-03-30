
using Api_part.Model; // لو Category و Product موجودين
 
 

namespace Api_part.Iservice
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product?> Update(int id, Product product);
        Task<bool> Delete(int id);
    }
}