using AutoMapper;
using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using BMS.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace BMS.Core.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public Book GetBookByName(string bookName)
        {
            return _context.Books.FirstOrDefault(x => x.BookName == bookName);
        }

        public async Task<Book> AddBookAsync(BookDto bookDto)
        {
            var isBookExists = GetBookByName(bookDto.BookName);

            if (isBookExists != null)
                return null;
            var book = _mapper.Map<Book>(bookDto);
            book.BookCode = Guid.NewGuid();
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBookAsync(BookDto bookDto, Guid bookCode)
        {

            var isBookExists = await _context.Books.FindAsync(bookCode);
            if (isBookExists == null)
                throw new Exception();
            _mapper.Map(bookDto, isBookExists);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Guid bookCode)
        {
            var isBookExists = await _context.Books.FindAsync(bookCode);
            if (isBookExists == null)
                throw new Exception();
            _context.Books.Remove(isBookExists);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookDto>> GetBooksByCatgoryIdAsync(Guid categoryId)
        {
            var books = await _context.Books.Where(x=>x.Categoryid == categoryId).ToListAsync();
            if (books == null)
                throw new Exception();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
