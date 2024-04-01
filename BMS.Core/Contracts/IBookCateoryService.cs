using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Domain.Contracts
{
    public interface IBookCateoryService
    {
        Task<IEnumerable<BookCategoryDto>> GetAllBookCategoriesAsync();
        BookCategory GetBookCategoryByName(string categoryName);
        Task<BookCategoryDto> AddBookCategoryAsync(BookCategoryDto bookCategoryDto);
        Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto, Guid categoryId);
        Task DeleteBookCategoryAsync(Guid categoryId);
    }
}
