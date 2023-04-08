using WalletApp.Domain.Transactions.Models;

namespace WalletApp.Domain.Transactions.Common
{
    public interface IMoneyTransactionRepository
    {
        Task<IReadOnlyCollection<MoneyTransaction>> GetAllTransactions(int id);
        Task<IReadOnlyCollection<MoneyTransaction>> GetLastTenTransactions(int userId);
        Task<MoneyTransaction> GetById(int id);
        void Add(MoneyTransaction transaction);
    }
}
