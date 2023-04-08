using WalletApp.Domain.Common;
using WalletApp.Domain.Transaction.Models;
namespace WalletApp.Domain.Users.Models
{
    public class User : Entity, IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; }
        public long DailyPoints { get; private set; }

        public List<MoneyTransaction> MoneyTransactions { get; private set; }
    }
}
