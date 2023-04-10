using WalletApp.Domain.Common;
using WalletApp.Domain.Exceptions;
using WalletApp.Domain.Transactions.Models;

namespace WalletApp.Domain.Transactions.Validators
{
    public class MoneyTransactionValidator
    {
        public static void ValidateTransaction(MoneyTransaction transaction, IUnitOfWork _unitOfWork)
        {
            if (string.IsNullOrWhiteSpace(transaction.Name))
                throw new ValidationException("Name should not be empty");

            if (string.IsNullOrWhiteSpace(transaction.Description))
                throw new ValidationException("Description should not be empty");

            var user = _unitOfWork.Users.GetById(transaction.UserId);
            if (user == null)
                throw new NotFoundException("There is no such user");

            var validType = Enum.IsDefined(typeof(TransactionType), transaction.Type);
            if (!validType)
                throw new ValidationException("Transaction type is not valid");
        }
    }
}
