using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(Guid bookId);
        Task<Book> GetBookByNameAsync(string bookName);
        Task<Book> AddBookAsync(BookDto bookDto);
        Task<Book> UpdateBookAsync(BookDto bookDto);
        Task<Book> DeleteBookAsync(Guid bookId);
    }
}
