using WalletApp.Domain.Cards.Models;
using WalletApp.Domain.Common;
using WalletApp.Domain.Transactions.Models;

namespace WalletApp.Domain.Users.Models
{
    public class User : Entity, IAggregateRoot
    {
        private User() { }

        private User(string name, string email, string password, long dailyPoints, bool dueIsPayed, int cardId)
        {
            Name = name;
            Email = email;
            Password = password;
            DailyPoints = dailyPoints;
            DueIsPayed = dueIsPayed;
            CardId = cardId;
        }

        public int Id { get; init; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public long DailyPoints { get; private set; }
        public bool DueIsPayed {get; private set; }
        public int CardId { get; private set; }

        public Card Card { get; private set; }
        public List<MoneyTransaction> MoneyTransactions { get; private set; }

        public static User Create(UserCreateData data)
    }
}
