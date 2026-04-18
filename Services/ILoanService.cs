using LoanAPI.Models;

namespace LoanAPI.Services
{
    public interface ILoanService
    {        
        Task<List<Loan>> GetAllAsync();
        Task<List<Loan>> GetCustomerByIdAsync(int customerId);
        Task<Loan> ApplyLoanAsync(Loan loan);
    }
}
