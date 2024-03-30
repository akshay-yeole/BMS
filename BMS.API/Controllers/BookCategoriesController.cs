using BMS.Domain.Contracts;
using BMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace BMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ControllerBase
    {
        private readonly IBookCateoryService _bookCateoryService;

        public BookCategoriesController(IBookCateoryService bookCateoryService)
        {
            _bookCateoryService = bookCateoryService;
        }
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<BookCategory>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBookCategoriesAsync()
        {
            var result = await _bookCateoryService.GetAllBookCategoriesAsync();
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
