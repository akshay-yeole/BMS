using AutoMapper;
using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using BMS.Sql.Context;

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
            libraryTransactionDto.Id = Guid.NewGuid();
            await _context.LibraryTransactions.AddAsync(_mapper.Map<LibraryTransaction>(libraryTransactionDto));
            await _context.SaveChangesAsync();
            return libraryTransactionDto;
        }
    }
}
