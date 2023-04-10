using WalletApp.Domain.Clock;
using WalletApp.Domain.Common;
using WalletApp.Domain.DailyPoints;
using WalletApp.Domain.Exceptions;
using WalletApp.Domain.Transactions.Models;
using WalletApp.Domain.Users.Data;
using WalletApp.Domain.Users.Validator;

namespace WalletApp.Domain.Users.Models
{
    public class User : Entity, IAggregateRoot
    {
        private User() { }

        private User(string name, string email, string password, bool dueIsPayed)
        {
            Name = name;
            Email = email;
            Password = password;
            DueIsPayed = dueIsPayed;
        }

        private const decimal Limit = 1500m;

        public int Id { get; init; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; }
        public bool DueIsPayed {get; private set; }

        public decimal Available => Limit - Balance;
        public long DailyPoints => DailyPointsCalculator.CalculatePoints(SystemClock.Now);

        public List<MoneyTransaction> MoneyTransactions { get; private set; }

        public static User Create(UserCreateData data)
        {
            var user = new User(
                data.Name,
                data.Email,
                data.Password,
                data.DueIsPayed);
            user.GetRandomBalance();

            UserValidator.ValidateUser(user);
            return user;
        }

        private void GetRandomBalance()
        {
            Random random = new Random();
            Balance = (decimal)random.NextDouble() * Limit;
        }

        public void ChangeBalance(decimal amount)
        {
            if (Balance + amount > Limit)
            {
                throw new BalanceChangeException("Cannot exceed maximum balance.");
            }
            if (Balance + amount < 0M)
            {
                throw new BalanceChangeException("Balance cannot be negative.");
            }
            Balance += amount;
        }
    }
}
