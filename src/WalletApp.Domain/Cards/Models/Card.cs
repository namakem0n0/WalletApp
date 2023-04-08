using WalletApp.Domain.Common;

namespace WalletApp.Domain.Cards.Models
{
    public class Card : Entity, IAggregateRoot
    {
        public int Id { get; init; }
        public decimal Balance { get; set; }
        public int UserId { get; private set; }
    }
}
