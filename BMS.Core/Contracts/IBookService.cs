using BMS.Domain.Models;

namespace BMS.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
