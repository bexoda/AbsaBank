using AbsaBank.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbsaBank.Data
{
    public class SavingsDbContext : DbContext
    {
        public SavingsDbContext(DbContextOptions<SavingsDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Interest> Interests { get; set; }
    }
}
