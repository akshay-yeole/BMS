using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<Book> AddBookAsync(BookDto bookDto);
        Task UpdateBookAsync(BookDto bookDto, Guid bookCode);
        Task DeleteBookAsync(Guid bookCode);
    }
}
