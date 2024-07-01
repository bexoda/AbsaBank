using AbsaBank.Data;
using AbsaBank.Entities;
using AbsaBank.Interface;


public class TransactionService : ITransactionService
{
    private readonly SavingsDbContext _context;

    public TransactionService(SavingsDbContext context)
    {
        _context = context;
    }

    public async Task<Transaction> DepositAsync(Guid accountId, decimal amount)
    {
        var account = await _context.Accounts.FindAsync(accountId);
        if (account == null)
            throw new ArgumentException("Account not found");

        account.Balance += amount;
        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            Type = TransactionType.Deposit,
            Timestamp = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return transaction;
    }

    public async Task<Transaction> WithdrawAsync(Guid accountId, decimal amount)
    {
        var account = await _context.Accounts.FindAsync(accountId);
        if (account == null)
            throw new ArgumentException("Account not found");

        if (account.Balance < amount)
            throw new InvalidOperationException("Insufficient funds");

        account.Balance -= amount;
        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            Type = TransactionType.Withdrawal,
            Timestamp = DateTime.UtcNow
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return transaction;
    }
}