using WalletApp.Domain.Transactions.Common;
using WalletApp.Domain.Users.Common;

namespace WalletApp.Domain.Common
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IMoneyTransactionRepository MoneyTransactions { get; }

        Task Complete();
    }
}
