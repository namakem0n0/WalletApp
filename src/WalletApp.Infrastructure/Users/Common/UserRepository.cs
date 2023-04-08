using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.Users.Common;
using WalletApp.Domain.Users.Models;
using WalletApp.Persistence.Context;

namespace WalletApp.Infrastructure.Users.Common
{
    public class UserRepository : IUserRepository
    {
        private readonly WalletAppDbContext _context;

        public UserRepository(WalletAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Include(u => u.MoneyTransactions).AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }
    }
}
