using AutoMapper;
using BMS.Domain.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using BMS.Sql.Context;
using Microsoft.EntityFrameworkCore;

namespace BMS.Domain.Services
{
    public class BookCategoryService : IBookCateoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookCategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookCategoryDto>> GetAllBookCategoriesAsync()
        {
            var bookCategories = await _context.BookCategories.ToListAsync();
            return _mapper.Map<IEnumerable<BookCategoryDto>>(bookCategories);
        }

        public BookCategory GetBookCategoryByName(string categoryName)
        {
            return _context.BookCategories.FirstOrDefault(x => x.CategoryName == categoryName);
        }

        public async Task<BookCategoryDto> AddBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            var isBookCategoryExists = GetBookCategoryByName(bookCategoryDto.CategoryName);
            if (isBookCategoryExists != null)
                throw new Exception("Product not found");
            var bookCategory = _mapper.Map<BookCategory>(bookCategoryDto);
            bookCategory.CategoryId = Guid.NewGuid();
            await _context.BookCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookCategoryDto>(bookCategory);
        }

        public async Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto, Guid categoryId)
        {
            var isBookCategoryExists = await _context.BookCategories.FindAsync(categoryId);
            if (isBookCategoryExists == null)
                throw new Exception("Product not found");
            _mapper.Map(bookCategoryDto, isBookCategoryExists);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookCategoryAsync(Guid categoryId)
        {
            var isBookCategoryExists = await _context.BookCategories.FindAsync(categoryId);
            if (isBookCategoryExists == null)
                throw new Exception("Product not found");
            _context.BookCategories.Remove(isBookCategoryExists);
            await _context.SaveChangesAsync();
        }
    }
}
