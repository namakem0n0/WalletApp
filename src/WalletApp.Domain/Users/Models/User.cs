using WalletApp.Domain.Cards.Models;
using WalletApp.Domain.Common;
using WalletApp.Domain.Transactions.Models;

namespace WalletApp.Domain.Users.Models
{
    public class User : Entity, IAggregateRoot
    {
        public int Id { get; init; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public long DailyPoints { get; private set; }
        public int CardId { get; private set; }

        public Card Card { get; private set; }
        public List<MoneyTransaction> MoneyTransactions { get; private set; }
    }
}
