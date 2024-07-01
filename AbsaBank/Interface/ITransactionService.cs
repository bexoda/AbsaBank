using AbsaBank.Entities;

namespace AbsaBank.Interface
{
    public interface ITransactionService
    {
        Task<Transaction> DepositAsync(int accountId, decimal amount);
        Task<Transaction> WithdrawAsync(int accountId, decimal amount);
    }

}
