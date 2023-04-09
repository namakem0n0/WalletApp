using WalletApp.Domain.Cards.Data;
using WalletApp.Domain.Common;

namespace WalletApp.Domain.Cards.Models
{
    public class Card : Entity, IAggregateRoot
    {
        private Card() { }

        private Card(string number, decimal balance)
        {
            Number = number;
            Balance = balance;
        }

        private const decimal Limit = 1500m;
        public int Id { get; init; }
        public string Number { get; private set; }
        public decimal Balance { get; private set; }
        public decimal Available => Limit - Balance;



        public static Card Create(CardCreateData data)
        {
            var card = new Card(
                data.Number,
                data.Balance);
            return card;
        }

        public void ChangeBalance(decimal amount)
        {
            if (Balance + amount > Limit)
            {
                throw new InvalidOperationException("Cannot exceed maximum balance.");
            }
            if (Balance + amount < 0M)
            {
                throw new InvalidOperationException("Balance cannot be negative.");
            }
            Balance += amount;
        }

    }
}