using BMS.Domain.Models;

namespace BMS.Domain.Contracts
{
    public interface IBookCateoryService
    {
        Task<IEnumerable<BookCategory>> GetAllBookCategoriesAsync(); 
    }
}
