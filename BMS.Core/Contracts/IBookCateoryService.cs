using BMS.Domain.Dto;

namespace BMS.Domain.Contracts
{
    public interface IBookCateoryService
    {
        Task<IEnumerable<BookCategoryDto>> GetAllBookCategoriesAsync();
        Task<BookCategoryDto> AddBookCategoryAsync(BookCategoryDto bookCategoryDto);
        Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto);
        Task DeleteBookCategoryAsync(Guid categoryId);
    }
}
