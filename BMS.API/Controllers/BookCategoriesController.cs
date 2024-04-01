using AutoMapper;
using BMS.Domain.Contracts;
using BMS.Domain.Dto;
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
        private readonly IMapper _mapper;

        public BookCategoriesController(IBookCateoryService bookCateoryService, IMapper mapper)
        {
            _bookCateoryService = bookCateoryService;
            _mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<BookCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBookCategoriesAsync()
        {
            var result = await _bookCateoryService.GetAllBookCategoriesAsync();
            if (result == null || !result.Any())
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            var result = await _bookCateoryService.AddBookCategoryAsync(bookCategoryDto);
            if (result == null)
                return Conflict();
            return Ok(result);
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(typeof(BookCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto, Guid categoryId)
        {
            await _bookCateoryService.UpdateBookCategoryAsync(bookCategoryDto, categoryId);
            return Ok();
        }

        [HttpDelete("")]
        [ProducesResponseType(typeof(BookCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBookCategoryAsync(Guid categoryId)
        {
            await _bookCateoryService.DeleteBookCategoryAsync(categoryId);
            return Ok();
        }
    }
}
