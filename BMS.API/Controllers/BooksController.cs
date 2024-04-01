using AutoMapper;
using BMS.Core.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();
            if (!books.Any())
                return NotFound();
            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddBookCategoryAsync(BookDto bookDto)
        {
            var result = await _bookService.AddBookAsync(bookDto);
            if (result == null)
                return Conflict();
            return Ok(result);
        }

        [HttpPut("{bookCode}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBookCategoryAsync(BookDto bookDto, Guid bookCode)
        {
             await _bookService.UpdateBookAsync(bookDto, bookCode);
            return Ok();
        }

        [HttpDelete("{bookCode}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBookCategoryAsync(Guid bookCode)
        {
            await _bookService.DeleteBookAsync(bookCode);
            return Ok();
        }
    }
}
