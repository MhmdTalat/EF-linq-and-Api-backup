// لو APPContext موجود هناك
using Api_part.Model; // لو Category و Product موجودين هناك

 
 
namespace Api_part.Iservice
{

    public interface ICategoryService
    {
        Task<List<Category>> GetAll();
        Task<Category?> GetById(int id);
        Task<Category> Add(Category category);
        Task<Category?> Update(int id, Category category);
        Task<bool> Delete(int id);
    }
}