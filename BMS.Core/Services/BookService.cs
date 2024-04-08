using AutoMapper;
using BMS.Core.Common;
using BMS.Core.Contracts;
using BMS.Domain.Constants;
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

        public async Task<Result<IEnumerable<BookDto>>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            var allBooks = _mapper.Map<IEnumerable<BookDto>>(books);
            return Result.Ok(allBooks);
        }

        public Result<Book> GetBookByName(string bookName)
        {
            var book = _context.Books.FirstOrDefault(x => x.BookName == bookName);
            if (book == null)
                return Result.Fail<Book>(ErrorMessages.BookNotFound, StatusCodes.NotFoundError);
            return Result.Ok(book);
        }

        public async Task<Result<bool>> AddBookAsync(BookDto bookDto)
        {
            var isBookExists = GetBookByName(bookDto.BookName);
            if (isBookExists.Value != null)
                return Result.Fail<bool>(ErrorMessages.BookAlreadyExist, StatusCodes.BadRequestError);
            
            var book = _mapper.Map<Book>(bookDto);
            book.BookCode = Guid.NewGuid();
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> UpdateBookAsync(BookDto bookDto, Guid bookCode)
        {

            var isBookExists = await _context.Books.FindAsync(bookCode);
            if (isBookExists == null)
                return Result.Fail<bool>(ErrorMessages.BookNotFound, StatusCodes.NotFoundError);
            _mapper.Map(bookDto, isBookExists);
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> DeleteBookAsync(Guid bookCode)
        {
            var isBookExists = await _context.Books.FindAsync(bookCode);
            if (isBookExists == null)
                return Result.Fail<bool>(ErrorMessages.BookNotFound, StatusCodes.NotFoundError);
            _context.Books.Remove(isBookExists);
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<IEnumerable<BookDto>>> GetBooksByCatgoryIdAsync(Guid categoryId)
        {
            var books = await _context.Books.Where(x=>x.Categoryid == categoryId).ToListAsync();
            if (books == null)
                return Result.Fail<IEnumerable<BookDto>>(ErrorMessages.BookNotFound, StatusCodes.NotFoundError);
            var allBooks = _mapper.Map<IEnumerable<BookDto>>(books);
            return Result.Ok(allBooks);
        }
    }
}
