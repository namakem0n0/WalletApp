using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.Cards.Common;
using WalletApp.Domain.Cards.Models;
using WalletApp.Persistence.Context;

namespace WalletApp.Infrastructure.Cards.Common
{
    public class CardRepository : ICardRepository
    {
        private readonly WalletAppDbContext _context;

        public CardRepository(WalletAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Card>> GetAllCards()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> GetById(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public void Add(Card card)
        {
            _context.Cards.Add(card);
        }
    }
}
