using Microsoft.EntityFrameworkCore;
using LoanAPI.Models;

namespace LoanAPI.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
    }
}
