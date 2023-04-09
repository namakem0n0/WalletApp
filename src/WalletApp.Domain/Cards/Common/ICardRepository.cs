using WalletApp.Domain.Cards.Models;

namespace WalletApp.Domain.Cards.Common
{
    public interface ICardRepository
    {
        Task<IReadOnlyCollection<Card>> GetAllCards();
        Task<Card> GetById(int id);
        //Task<Card> Update(Card card);
        void Add(Card card);
    }
}
