using BMS.Domain.Contracts;
using BMS.Domain.Models;
using BMS.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace BMS.Domain.Services
{
    public class BookCategoryService : IBookCateoryService
    {
        private readonly AppDbContext _context;

        public BookCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync()
        {
            return await _context.BookCategories.ToListAsync();
        }

        public async Task<BookCategory> GetCategoryByCategoryNameAsync(string categoryName)
        {
            return await _context.BookCategories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        }

        public async Task<BookCategory> AddlBookCategoryAsync(BookCategory bookCategory)
        {
            var existingCategory = await GetCategoryByCategoryNameAsync(bookCategory.CategoryName);

            if (existingCategory != null)
            {
                return null;
            }
            bookCategory.CategoryId = Guid.NewGuid();
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();

            return bookCategory;
        }
    }
}
