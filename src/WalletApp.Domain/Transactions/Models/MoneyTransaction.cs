using WalletApp.Domain.Clock;
using WalletApp.Domain.Common;
using WalletApp.Domain.Transactions.Data;
using WalletApp.Domain.Users.Models;

namespace WalletApp.Domain.Transactions.Models
{
    public class MoneyTransaction : Entity, IAggregateRoot
    {
        private MoneyTransaction () {}

        private MoneyTransaction(string name, string description, decimal amount, int userId, TransactionType type, bool isPending)
        {
            Name = name;
            Description = description;
            Amount = amount;
            UserId = userId;
            IsPending = isPending;
            Type = type;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public int UserId { get; private set; }
        public bool IsPending { get; private set; }
        public TransactionType Type { get; private set; }

        public DateTime Date => SystemClock.Now;

        public User AuthorizedUser { get; private set; }

        public static MoneyTransaction Create(MoneyTransactionCreateData data)
        {
            var moneyTransaction = new MoneyTransaction(
                data.Name,
                data.Description,
                data.Amount,
                data.UserId,
                data.Type,
                data.Date,
                data.IsPending);
            return moneyTransaction;
        }

        public string FormatDate(User authorizedUser)
        {
            var dateToFormat = Date;
            var prefix = string.Empty;

            if (authorizedUser != null && authorizedUser.Id != UserId)
            {
                prefix = $"{authorizedUser.Name} - ";
            }
            else if (SystemClock.Now - Date <= TimeSpan.FromDays(7))
            {
                prefix = $"{Date.DayOfWeek} - ";
            }

            return $"{prefix}{dateToFormat:d}";
        }

        public string FormatPending()
        {
            if (IsPending)
            {
                return $"Pending - {Description}";
            }
            else
            {
                return Description;
            }
        }
    }
}
