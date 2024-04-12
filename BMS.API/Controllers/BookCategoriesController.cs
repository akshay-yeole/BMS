using BMS.Domain.Contracts;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace BMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : BaseController
    {
        private readonly IBookCateoryService _bookCateoryService;

        public BookCategoriesController(IBookCateoryService bookCateoryService)
        {
            _bookCateoryService = bookCateoryService;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<BookCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBookCategoriesAsync()
        {
            var result = await _bookCateoryService.GetAllBookCategoriesAsync();
            return Ok(result);
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookCateoryService.AddBookCategoryAsync(bookCategoryDto);
            if (result.IsSuccess)
                return Created(string.Empty,null);
            return GetResult(result);
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto, Guid categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookCateoryService.UpdateBookCategoryAsync(bookCategoryDto, categoryId);
            return GetResult(result); 
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBookCategoryAsync(Guid categoryId)
        {
            var result = await _bookCateoryService.DeleteBookCategoryAsync(categoryId);
            return GetResult(result);
        }
    }
}
