using Microsoft.EntityFrameworkCore; // لـ DbContext و EF functionality
using Api_part.Data; // لو APPContext موجود هناك
using Api_part.Model; // لو Category و Product موجودين هناك
namespace Api_part.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}