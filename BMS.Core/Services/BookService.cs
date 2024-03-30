using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using BMS.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BMS.Core.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBookAsync(BookDto bookDto)
        {
            var isBookExists = await GetBookByNameAsync(bookDto.BookName);

            if (isBookExists != null)
            {
                return null;
            }
            Book book = new Book {
                Author = bookDto.Author,
                BookCode = Guid.NewGuid(),
                BookName = bookDto.BookName,
                Categoryid = bookDto.Categoryid,
                CopiesAvailable = bookDto.CopiesAvailable
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> DeleteBookAsync(Guid bookId)
        {
            var isBookExists = await GetBookByIdAsync(bookId);

            if (isBookExists == null)
            {
                return null;
            }

            _context.Books.Remove(isBookExists);
            await _context.SaveChangesAsync();
            return isBookExists;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public async Task<Book> GetBookByNameAsync(string bookName)
        {
            return await _context.Books.FirstOrDefaultAsync(c => c.BookName == bookName);
        }

        public async Task<Book> UpdateBookAsync(BookDto bookDto)
        {

            var isBookExists = await GetBookByIdAsync(bookDto.BookCode);

            if (isBookExists == null)
            {
                return null;
            }

            isBookExists.BookName = bookDto.BookName;
            isBookExists.Author = bookDto.Author;
            isBookExists.Categoryid = bookDto.Categoryid;
            isBookExists.CopiesAvailable = bookDto.CopiesAvailable;

            _context.Books.Update(isBookExists);
            await _context.SaveChangesAsync();
            return isBookExists;
        }
    }
}
