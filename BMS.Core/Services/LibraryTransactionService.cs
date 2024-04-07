using AutoMapper;
using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using BMS.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace BMS.Core.Services
{
    public class LibraryTransactionService : ILibraryTransactionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LibraryTransactionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LibraryTransactionDto> AddLibraryTransaction(LibraryTransactionDto libraryTransactionDto)
        {
            var transaction = _mapper.Map<LibraryTransaction>(libraryTransactionDto);
            await _context.LibraryTransactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return libraryTransactionDto;
        }

        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            var isTransactionExists = await _context.LibraryTransactions.Where(x => x.Id == transactionId).FirstOrDefaultAsync();
            if (isTransactionExists == null)
                throw new Exception();
            _context.LibraryTransactions.Remove(isTransactionExists);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LibraryTransactionDto>> GetAllTransactionsAsync()
        {
            var trasactions = await _context.LibraryTransactions.ToListAsync();
            return _mapper.Map<IEnumerable<LibraryTransactionDto>>(trasactions);
        }

        public async Task UpdateTransactionAsync(LibraryTransactionDto transactionDto, Guid transactionId)
        {
            var isTransactionExists = await _context.LibraryTransactions.Where(x=>x.Id == transactionId).FirstOrDefaultAsync();
            if (isTransactionExists == null)
                throw new Exception();
            _mapper.Map(transactionDto, isTransactionExists);
            await _context.SaveChangesAsync();
        }
    }
}
