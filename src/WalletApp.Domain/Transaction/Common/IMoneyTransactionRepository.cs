using WalletApp.Domain.Transaction.Models;

namespace WalletApp.Domain.Transaction.Common
{
    public interface IMoneyTransactionRepository
    {
        Task<IReadOnlyCollection<MoneyTransaction>> GetAllTransactions();
        Task<MoneyTransaction> GetById(int id);
        void Add(MoneyTransaction transaction);
        Task<MoneyTransaction> Update(MoneyTransaction transaction);
        Task Delete(int id);
    }
}
