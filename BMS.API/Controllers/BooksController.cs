using BMS.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooksAsync() { 
            var books = await _bookService.GetAllBooksAsync();
            
            if (!books.Any())
            {
                return NotFound();
            }

            return Ok(books);
        }
    }
}
