using LoanAPI.Data;
using LoanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.Services
{
    public class LoanService : ILoanService
    {
        private readonly LoanDbContext _context;
        public LoanService(LoanDbContext context)
        {
            _context = context;   
        }
        public async Task<Loan> ApplyLoanAsync(Loan loan)
        {
            loan.CreatedDate = DateTime.UtcNow;

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return loan;
        }
        public async Task<List<Loan>> GetAllAsync()
        {            
            return await _context.Loans.ToListAsync();
        }
        public async Task<List<Loan>> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Loans
                .Where(l => l.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
