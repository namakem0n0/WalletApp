using WalletApp.Domain.Common;
using WalletApp.Domain.Users.Models;

namespace WalletApp.Domain.Transaction.Models
{
    public class MoneyTransaction : Entity, IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public int UserId { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime Date { get; private set; }
        public bool IsPending { get; private set; }

        public User AuthorizedUser { get; private set; }
    }
}
