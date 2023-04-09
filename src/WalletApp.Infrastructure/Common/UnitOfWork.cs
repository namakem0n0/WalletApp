using WalletApp.Domain.Cards.Common;
using WalletApp.Domain.Common;
using WalletApp.Domain.Transactions.Common;
using WalletApp.Domain.Users.Common;
using WalletApp.Infrastructure.Cards.Common;
using WalletApp.Infrastructure.MoneyTransactions.Common;
using WalletApp.Infrastructure.Users.Common;
using WalletApp.Persistence.Context;

namespace WalletApp.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WalletAppDbContext _context;

        public IUserRepository Users { get; private set; }
        public IMoneyTransactionRepository MoneyTransactions { get; private set; }
        public ICardRepository Cards { get; private set; }

        public UnitOfWork(WalletAppDbContext context)
        {
            _context = context;
            MoneyTransactions = new MoneyTransactionRepository(_context);
            Users = new UserRepository(_context);
            Cards = new CardRepository(_context);
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
