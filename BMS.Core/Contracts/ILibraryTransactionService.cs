
using BMS.Domain.Dto;

namespace BMS.Core.Contracts
{
    public interface ILibraryTransactionService
    {
        Task<IEnumerable<LibraryTransactionDto>> GetAllTransactionsAsync();
        Task<LibraryTransactionDto> AddLibraryTransaction(LibraryTransactionDto libraryTransactionDto);
        Task UpdateTransactionAsync(LibraryTransactionDto transactionDto, Guid transactionId);
        Task DeleteTransactionAsync(Guid transactionId);
        Task<LibraryTransactionDto> GetLibraryTransactionById(Guid transactionId);
    }
}
