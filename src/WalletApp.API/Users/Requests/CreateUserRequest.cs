namespace WalletApp.API.Users.Requests
{
    public record CreateUserRequest(
        string Name,
        string Email,
        string Password,
        long DailyPoints,
        bool DueIsPayed,
        int CardId);
}
