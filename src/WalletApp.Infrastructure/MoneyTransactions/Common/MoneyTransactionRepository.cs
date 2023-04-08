using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.Transactions.Common;
using WalletApp.Domain.Transactions.Models;
using WalletApp.Persistence.Context;

namespace WalletApp.Infrastructure.MoneyTransactions.Common
{
    public class MoneyTransactionRepository : IMoneyTransactionRepository
    {
        private readonly WalletAppDbContext _context;

        public MoneyTransactionRepository(WalletAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<MoneyTransaction>> GetAllTransactions()
        {
            return await _context.MoneyTransactions.ToListAsync();
        }

        public async Task<MoneyTransaction> GetById(int id)
        {
            return await _context.MoneyTransactions.FindAsync(id);
        }

        public void Add(MoneyTransaction transaction)
        {
            _context.MoneyTransactions.Add(transaction);
        }
    }
}
