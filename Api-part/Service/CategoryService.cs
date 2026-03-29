using Microsoft.EntityFrameworkCore; // لـ DbContext و EF functionality
using Api_part.Data; // لو APPContext موجود هناك
using Api_part.Model; // لو Category و Product موجودين هناك
using Api_part.Iservice;
 

namespace Api_part.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly APPContext _context;

        public CategoryService(APPContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> Add(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> Update(int id, Category category)
        {
            var existing = await _context.Categories.FindAsync(id);
            if (existing == null) return null;

            existing.Name = category.Name;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}