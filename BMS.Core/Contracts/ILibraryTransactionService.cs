
using BMS.Domain.Dto;
using BMS.Domain.Models;

namespace BMS.Core.Contracts
{
    public interface ILibraryTransactionService
    {
        Task<IEnumerable<LibraryTransactionDto>> GetAllTransactionsAsync();
        Task<LibraryTransactionDto> AddLibraryTransaction(LibraryTransactionDto libraryTransactionDto);
    }
}
