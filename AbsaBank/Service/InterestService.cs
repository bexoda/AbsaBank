using AbsaBank.Data;
using AbsaBank.Entities;
using Microsoft.EntityFrameworkCore;


public class InterestService : IInterestService
{
    private readonly SavingsDbContext _context;

    public InterestService(SavingsDbContext context)
    {
        _context = context;
    }

    public async Task CalculateDailyInterestAsync()
    {
        var accounts = await _context.Accounts.ToListAsync();
        var today = DateTime.UtcNow.Date;

        foreach (var account in accounts)
        {
            var dailyInterest = account.Balance * (account.InterestRate / 365);
            var interestEntry = new Interest
            {
                AccountId = account.Id,
                Amount = dailyInterest,
                Date = today
            };

            account.Balance += dailyInterest;
            _context.Interests.Add(interestEntry);
        }

        await _context.SaveChangesAsync();
    }
}