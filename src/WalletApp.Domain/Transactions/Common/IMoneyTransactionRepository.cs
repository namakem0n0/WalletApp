using WalletApp.Domain.Transactions.Models;

namespace WalletApp.Domain.Transactions.Common
{
    public interface IMoneyTransactionRepository
    {
        Task<IReadOnlyCollection<MoneyTransaction>> GetAllTransactions();
        Task<MoneyTransaction> GetById(int id);
        void Add(MoneyTransaction transaction);
    }
}
