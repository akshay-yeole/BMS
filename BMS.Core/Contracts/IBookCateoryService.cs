using BMS.Domain.Models;

namespace BMS.Domain.Contracts
{
    public interface IBookCateoryService
    {
        Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync();
        Task<BookCategory> GetCategoryByCategoryNameAsync(string categoryName);
        Task<BookCategory> AddlBookCategoryAsync(BookCategory bookCategory);
    }
}
