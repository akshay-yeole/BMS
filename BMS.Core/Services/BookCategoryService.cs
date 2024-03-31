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

        public BookCategory GetCategoryByCategoryById(Guid categoryId)
        {
            return _context.BookCategories.Find(categoryId);
        }

        public BookCategory GetCategoryByCategoryName(string categoryName)
        {
            return _context.BookCategories.FirstOrDefault(c => c.CategoryName == categoryName);
        }

        public async Task<BookCategory> AddBookCategoryAsync(BookCategory bookCategory)
        {
            var isBookCategoryExists = GetCategoryByCategoryName(bookCategory.CategoryName);
            if (isBookCategoryExists != null)
                return null;
            bookCategory.CategoryId = Guid.NewGuid();
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
            return bookCategory;
        }

        public async Task<BookCategory> UpdateBookCategoryAsync(BookCategory bookCategory)
        {
            var isBookCategoryExists = GetCategoryByCategoryById(bookCategory.CategoryId);
            if (isBookCategoryExists == null)
                return null;
            isBookCategoryExists.CategoryName = bookCategory.CategoryName;
            _context.BookCategories.Update(isBookCategoryExists);
            await _context.SaveChangesAsync();
            return isBookCategoryExists;
        }

        public async Task<BookCategory> DeleteBookCategoryAsync(Guid categoryId)
        {
            var isBookCategoryExists = GetCategoryByCategoryById(categoryId);
            if (isBookCategoryExists == null)
                return null;
            _context.BookCategories.Remove(isBookCategoryExists);
            await _context.SaveChangesAsync();
            return isBookCategoryExists;
        }
    }
}
