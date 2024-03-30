using BMS.Domain.Models;

namespace BMS.Domain.Contracts
{
    public interface IBookCateoryService
    {
        Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync();
        Task<BookCategory> GetCategoryByCategoryByIdAsync(Guid categoryId);
        Task<BookCategory> GetCategoryByCategoryNameAsync(string categoryName);
        Task<BookCategory> AddBookCategoryAsync(BookCategory bookCategory);
        Task<BookCategory> UpdateBookCategoryAsync(BookCategory bookCategory);
        Task<BookCategory> DeleteBookCategoryAsync(Guid categoryId);
    }
}
