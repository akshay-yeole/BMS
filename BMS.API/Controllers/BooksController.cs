using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();
            return GetResult(books);
        }

        [HttpGet("books-by-category-id/{categoryId}")]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBooksAsync(Guid categoryId)
        {
            var books = await _bookService.GetBooksByCatgoryIdAsync(categoryId);
            return GetResult(books);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddBookyAsync(BookDto bookDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState); 
            var result = await _bookService.AddBookAsync(bookDto);
            return GetResult(result);
        }

        [HttpPut("{bookCode}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBookCategoryAsync(BookDto bookDto, Guid bookCode)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _bookService.UpdateBookAsync(bookDto, bookCode);
            return GetResult(result);
        }

        [HttpDelete("{bookCode}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBookCategoryAsync(Guid bookCode)
        {
            var result = await _bookService.DeleteBookAsync(bookCode);
            return GetResult(result);
        }

        [HttpGet("{bookCode}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBookByBookCodeAsync(Guid bookCode)
        {
            var result = await _bookService.GetBookByBookCode(bookCode);
            return GetResult(result);
        }
    }
}
