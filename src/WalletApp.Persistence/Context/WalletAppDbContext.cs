using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.Cards.Models;
using WalletApp.Domain.Transactions.Models;
using WalletApp.Domain.Users.Models;

namespace WalletApp.Persistence.Context
{
    public class WalletAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MoneyTransaction> MoneyTransactions { get; set; }
        public DbSet<Card> Cards { get; set; }

        public WalletAppDbContext(DbContextOptions<WalletAppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalletAppDbContext).Assembly);
        }
    }
}
