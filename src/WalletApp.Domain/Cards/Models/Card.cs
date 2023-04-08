using WalletApp.Domain.Common;

namespace WalletApp.Domain.Cards.Models
{
    public class Card : Entity, IAggregateRoot
    {
        public int Id { get; init; }
        public string Number { get; private set; }
        public decimal Balance { get; private set; }
        public decimal Available { get; private set; }
    }
}