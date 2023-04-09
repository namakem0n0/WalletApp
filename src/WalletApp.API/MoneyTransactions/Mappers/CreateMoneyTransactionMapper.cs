using WalletApp.API.MoneyTransactions.Requests;
using WalletApp.Domain.Transactions.Data;

namespace WalletApp.API.MoneyTransactions.Mappers
{
    public static class CreateMoneyTransactionMapper
    {
        public static MoneyTransactionCreateData AsData(this CreateMoneyTransactionRequest request) =>
        new(request.Name,
            request.Description,
            request.Amount,
            request.UserId,
            request.Type,
            request.Date,
            request.IsPending);
    }
}
