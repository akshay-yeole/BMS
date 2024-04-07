using BMS.Core.Contracts;
using BMS.Core.Services;
using BMS.Domain.Dto;
using BMS.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryTransactionsController : ControllerBase
    {
        private readonly ILibraryTransactionService _transactionService;

        public LibraryTransactionsController(ILibraryTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LibraryTransactionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTransactionsAsync()
        {
            var result = await _transactionService.GetAllTransactionsAsync();
            if (result == null)
                return Conflict();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LibraryTransactionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTransactionAsync(LibraryTransactionDto libraryTransactionDto)
        {
            var result = await _transactionService.AddLibraryTransaction(libraryTransactionDto);
            if (result == null)
                return Conflict();
            return Ok(result);
        }

        [HttpPut("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTransactionAsync(LibraryTransactionDto libraryTransactionDto, Guid transactionId)
        {
            await _transactionService.UpdateTransactionAsync(libraryTransactionDto, transactionId);
            return Ok();
        }

        [HttpDelete("{transactionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTransactionAsync(Guid transactionId)
        {
            await _transactionService.DeleteTransactionAsync(transactionId);
            return Ok();
        }
    }
}
