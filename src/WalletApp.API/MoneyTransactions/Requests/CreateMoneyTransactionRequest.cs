using WalletApp.Domain.Transactions.Models;

namespace WalletApp.API.MoneyTransactions.Requests
{
    public record CreateMoneyTransactionRequest(
        string Name,
        string Description,
        decimal Amount,
        int UserId,
        TransactionType Type,
        bool IsPending);
}
