using BMS.Core.Common;
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Domain.Contracts
{
    public interface IBookCateoryService
    {
        Task<IEnumerable<BookCategoryDto>> GetAllBookCategoriesAsync();
        BookCategory GetBookCategoryByName(string categoryName);
        Task<Result<bool>> AddBookCategoryAsync(BookCategoryDto bookCategoryDto);
        Task<Result<bool>> UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto, Guid categoryId);
        Task<Result<bool>> DeleteBookCategoryAsync(Guid categoryId);

        Task<Result<BookCategoryDto>> GetCategoryById(Guid categoryId);
    }
}
