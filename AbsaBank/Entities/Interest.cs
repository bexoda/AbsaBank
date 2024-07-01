using Microsoft.EntityFrameworkCore;

namespace AbsaBank.Entities
{
    public class Interest
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
