using Microsoft.AspNetCore.Mvc;
using LoanAPI.Data;
using LoanAPI.Models;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Services;

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
        public  async Task<IActionResult> GetAll()
        {            
            var loans = await _loanService.GetAllAsync();
            return Ok(loans);
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var loans = await _loanService.GetCustomerByIdAsync(customerId);

            if (!loans.Any())
                return NotFound($"No loan found for customer {customerId}");
            return Ok(loans);
        }
        [HttpPost("apply")]
        public async Task<IActionResult> Apply([FromBody] Loan loan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loanService.ApplyLoanAsync(loan);
            return Ok(result);            
        }
        

    }
}
