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

        public async Task<IReadOnlyCollection<MoneyTransaction>> GetAllTransactions(int userId)
        {
            var transactions = await _context.MoneyTransactions
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return transactions.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<MoneyTransaction>> GetLastTenTransactions(int userId)
        {
            var transactions = await _context.MoneyTransactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .Take(10)
                .ToListAsync();
            return transactions.AsReadOnly();
        }

        public async Task<MoneyTransaction> GetById(int id)
        {
            return await _context.MoneyTransactions.FindAsync(id);
        }

        public void Delete(MoneyTransaction transaction)
        {
            if (_context.MoneyTransactions.Find(transaction.Id) == null)
                throw new ArgumentNullException("Transaction do not exist");
            _context.MoneyTransactions.Remove(transaction);
        }

        public void Add(MoneyTransaction transaction)
        {
            _context.MoneyTransactions.Add(transaction);
        }
    }
}
