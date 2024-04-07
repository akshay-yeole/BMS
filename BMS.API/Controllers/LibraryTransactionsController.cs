﻿using BMS.Core.Contracts;
using BMS.Domain.Dto;
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

        [HttpPost]
        [ProducesResponseType(typeof(LibraryTransactionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddBookCategoryAsync(LibraryTransactionDto libraryTransactionDto)
        {
            var result = await _transactionService.AddLibraryTransaction(libraryTransactionDto);
            if (result == null)
                return Conflict();
            return Ok(result);
        }
    }
}