using WalletApp.Domain.Common;
using WalletApp.Domain.Transaction.Common;
using WalletApp.Domain.Users.Common;
using WalletApp.Domain.Users.Models;
using WalletApp.Infrastructure.MoneyTransactions.Common;
using WalletApp.Persistence.Context;

namespace WalletApp.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletAppDbContext _context;

        public IMoneyTransactionRepository Transactions { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(WalletAppDbContext context)
        {
            _context = context;
            Transactions = new MoneyTransactionRepository(_context);
            Users = new User
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
