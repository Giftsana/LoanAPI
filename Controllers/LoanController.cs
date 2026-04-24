using LoanAPI.Data;
using LoanAPI.Models;
using LoanAPI.Services;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LoanAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }
                
        [HttpGet]
        public async Task<IActionResult> GetCustomerById([FromQuery] int? customerId)
        {
            if (customerId.HasValue)
            {
                var loans = await _loanService.GetCustomerByIdAsync(customerId.Value);

                if (loans == null || !loans.Any())
                    return NotFound($"No loan found for customer {customerId}");

                return Ok(loans);
            }

            var allloans = await _loanService.GetAllAsync();
            return Ok(allloans);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _loanService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Loan loan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loanService.CreateLoanAsync(loan);
            return CreatedAtAction(nameof(GetById), new { id = result.LoanId }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _loanService.DeleteLoanAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent(); //status code 204
        }
        [HttpPatch("{id}/amount")]
        public async Task<IActionResult> UpdateAmount(int id, [FromBody] UpdateLoanAmountDto dto)
        {
            if (dto == null || !dto.Amount.HasValue)
                return BadRequest("Amount is required");
            try
            {
                var updated = await _loanService.UpdateAmountAsync(id, dto);
                if (!updated)
                    return NotFound();
                return NoContent();//status code 204
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

