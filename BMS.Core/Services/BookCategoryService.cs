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

        public async Task<BookCategory> AddBookCategoryAsync(BookCategory bookCategory)
        {
            var isBookCategoryExists = await GetCategoryByCategoryNameAsync(bookCategory.CategoryName);

            if (isBookCategoryExists != null)
            {
                return null;
            }
            bookCategory.CategoryId = Guid.NewGuid();
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();

            return bookCategory;
        }

        public async Task<BookCategory> GetCategoryByCategoryByIdAsync(Guid categoryId)
        {
            return await _context.BookCategories.FindAsync(categoryId);
        }

        public async Task<BookCategory> UpdateBookCategoryAsync(BookCategory bookCategory)
        {
            var isBookCategoryExists = await GetCategoryByCategoryByIdAsync(bookCategory.CategoryId);
            
            if (isBookCategoryExists == null)
            {
                return null;
            }

            isBookCategoryExists.CategoryName = bookCategory.CategoryName;

            _context.Update(isBookCategoryExists);
            await _context.SaveChangesAsync();
            return isBookCategoryExists;
        }
    }
}
