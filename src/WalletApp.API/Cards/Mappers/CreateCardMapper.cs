using WalletApp.API.Cards.Requests;
using WalletApp.Domain.Cards.Data;

namespace WalletApp.API.Cards.Mappers
{
    public static class CreateCardMapper
    {
        public static CardCreateData AsData(this CreateCardRequest request) =>
            new(request.Number,
                request.Balance);
    }
}
