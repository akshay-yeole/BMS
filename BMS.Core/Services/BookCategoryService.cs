using AutoMapper;
using BMS.Core.Common;
using BMS.Domain.Constants;
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

        public async Task<Result<bool>> AddBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            var isBookCategoryExists = GetBookCategoryByName(bookCategoryDto.CategoryName);
            if (isBookCategoryExists != null)
            {
                string errMessage = string.Format(ErrorMessages.BookCategoryExist, bookCategoryDto);
                return Result.Fail<bool>(errMessage, StatusCodes.BadRequestError);
            }
            await _context.BookCategories.AddAsync(_mapper.Map<BookCategory>(bookCategoryDto));
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto, Guid categoryId)
        {
            var isBookCategoryExists = await _context.BookCategories.FindAsync(categoryId);
            if (isBookCategoryExists == null)
                return Result.Fail<bool>(ErrorMessages.BookCategoryNotFound, StatusCodes.NotFoundError);
            _mapper.Map(bookCategoryDto, isBookCategoryExists);
            await _context.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> DeleteBookCategoryAsync(Guid categoryId)
        {
            var isBookCategoryExists = await _context.BookCategories.FindAsync(categoryId);
            if (isBookCategoryExists == null)
                return Result.Fail<bool>(ErrorMessages.BookCategoryNotFound, StatusCodes.NotFoundError);
            _context.BookCategories.Remove(isBookCategoryExists);
            await _context.SaveChangesAsync();
            return Result.Ok(true,StatusCodes.NoContentSuccessCode);
        }

        public async Task<Result<BookCategoryDto>> GetCategoryById(Guid categoryId)
        {
            var categoryDetails = await _context.BookCategories.FindAsync(categoryId);
            if(categoryDetails == null)
                return Result.Fail<BookCategoryDto>(ErrorMessages.BookCategoryNotFound, StatusCodes.NotFoundError);
            return Result.Ok(_mapper.Map<BookCategoryDto>(categoryDetails)); 
        }
    }
}
