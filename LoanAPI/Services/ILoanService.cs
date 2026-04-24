using LoanAPI.Models;

namespace LoanAPI.Services
{
    public interface ILoanService
    {        
        Task<List<Loan>> GetAllAsync();
        Task<List<Loan>> GetCustomerByIdAsync(int customerId);
        Task<Loan> CreateLoanAsync(Loan loan);
        Task<Loan> GetByIdAsync(int id);
        Task<bool> DeleteLoanAsync(int customerId);
        Task<bool> UpdateAmountAsync(int loanId, UpdateLoanAmountDto dto);
    }
}
