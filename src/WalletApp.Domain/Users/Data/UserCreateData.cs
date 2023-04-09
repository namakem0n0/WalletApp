namespace WalletApp.Domain.Users.Data
{
    public record UserCreateData(
        string Name,
        string Email,
        string Password,
        bool DueIsPayed,
        int CardId);
}
