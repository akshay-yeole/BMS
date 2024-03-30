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

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<BookCategory>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddBookCategoryAsync(BookCategory bookCategory) {
            var result = await _bookCateoryService.AddBookCategoryAsync(bookCategory);

            if (result == null)
            {
                return Conflict();
            }

           return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<BookCategory>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBookCategoryAsync(BookCategory bookCategory)
        {
            var result = await _bookCateoryService.UpdateBookCategoryAsync(bookCategory);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("")]
        [ProducesResponseType(typeof(IEnumerable<BookCategory>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBookCategoryAsync(Guid categoryId)
        {
            var result = await _bookCateoryService.DeleteBookCategoryAsync(categoryId);
            
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
