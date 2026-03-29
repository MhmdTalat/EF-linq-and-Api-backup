using Microsoft.EntityFrameworkCore; // لـ DbContext و EF functionality
using Api_part.Data; // لو APPContext موجود هناك
using Api_part.Model; // لو Category و Product موجودين هناك
using Api_part.Iservice;
 


namespace Api_part.Service
{
    public class ProductService : IProductService
    {
        private readonly APPContext _context;

        public ProductService(APPContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> Update(int id, Product product)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return null;

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}