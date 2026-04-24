using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Models
{
    public class Loan
    {
        public int LoanId { get; set; }//Primary Key
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [Range(1,1000000)]
        public decimal Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
