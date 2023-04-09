namespace WalletApp.API.Cards.Requests
{
    public record CreateCardRequest(
        string Number,
        decimal Balance,
        decimal Available);
}
