
using BMS.Domain.Dto;

namespace BMS.Core.Contracts
{
    public interface ILibraryTransactionService
    {
        Task<LibraryTransactionDto> AddLibraryTransaction(LibraryTransactionDto libraryTransactionDto);
    }
}
