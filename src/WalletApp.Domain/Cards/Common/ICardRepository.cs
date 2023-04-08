﻿using WalletApp.Domain.Cards.Models;
using WalletApp.Domain.Users.Models;

namespace WalletApp.Domain.Cards.Common
{
    public interface ICardRepository
    {
        Task<IReadOnlyCollection<Card>> GetAllCards();
        Task<Card> GetById(int id);
        void Add(Card card);
    }
}
