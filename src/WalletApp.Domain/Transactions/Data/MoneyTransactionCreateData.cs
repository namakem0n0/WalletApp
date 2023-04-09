using WalletApp.Domain.Transactions.Models;

namespace WalletApp.Domain.Transactions.Data
{
    public record MoneyTransactionCreateData(
        string Name, 
        string Description,
        decimal Amount,
        int UserId,
        TransactionType Type,
        DateTime Date,
        bool IsPending);
}
