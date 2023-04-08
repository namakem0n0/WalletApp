namespace WalletApp.Domain.Users.Data
{
    public record UserCreateData(
        string Name,
        string Email,
        string Password,
        long DailyPoints,
        bool DueIsPayed,
        int CardId);
}
