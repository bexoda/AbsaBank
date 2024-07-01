using Microsoft.EntityFrameworkCore;

namespace AbsaBank.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Precision(18, 2)]
        public decimal Balance { get; set; }
        [Precision(5, 4)]
        public decimal InterestRate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
