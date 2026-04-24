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
        public async Task<Loan> CreateLoanAsync(Loan loan)
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
        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _context.Loans
                .FirstOrDefaultAsync(l => l.LoanId == id);
        }
        //Business rule delete by LoanId(primary key) as a customer can have > 1 loanId
        public async Task<bool> DeleteLoanAsync(int loanId)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan == null)
                return false;
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateAmountAsync(int loanId, UpdateLoanAmountDto dto)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan == null)
                return false;
            if(dto.Amount.HasValue)
            {
                if (dto.Amount <= 0)
                    throw new ArgumentException("Amount must be greater than 0");
                loan.Amount = dto.Amount.Value;
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
