using Microsoft.EntityFrameworkCore;

namespace AbsaBank.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public TransactionType Type { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
