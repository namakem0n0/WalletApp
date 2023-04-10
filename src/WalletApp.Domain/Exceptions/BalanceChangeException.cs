namespace WalletApp.Domain.Exceptions
{
    public class BalanceChangeException : DomainException
    {
        public BalanceChangeException(string message) : base(message) { }
    }
}
