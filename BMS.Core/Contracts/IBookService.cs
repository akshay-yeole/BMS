using BMS.Core.Common;
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Contracts
{
    public interface IBookService
    {
        Task<Result<IEnumerable<BookDto>>> GetAllBooksAsync();
        Book GetBookByName(string bookName);
        Task<Result<bool>> AddBookAsync(BookDto bookDto);
        Task<Result<bool>> UpdateBookAsync(BookDto bookDto, Guid bookCode);
        Task<Result<bool>> DeleteBookAsync(Guid bookCode);
        Task<Result<IEnumerable<BookDto>>> GetBooksByCatgoryIdAsync(Guid categoryId);
    }
}
