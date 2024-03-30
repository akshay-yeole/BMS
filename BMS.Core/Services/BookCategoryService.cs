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
    }
}
