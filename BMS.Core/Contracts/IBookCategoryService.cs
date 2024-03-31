using BMS.Domain.Models;

namespace BMS.Domain.Contracts
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync();
        BookCategory GetCategoryByCategoryById(Guid categoryId);
        BookCategory GetCategoryByCategoryName(string categoryName);
        Task<BookCategory> AddBookCategoryAsync(BookCategory bookCategory);
        Task<BookCategory> UpdateBookCategoryAsync(BookCategory bookCategory);
        Task<BookCategory> DeleteBookCategoryAsync(Guid categoryId);
    }
}
