using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.Domain.Transaction.Common;
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
