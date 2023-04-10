namespace WalletApp.API.Users.Requests
{
    public record CreateUserRequest(
        string Name,
        string Email,
        string Password,
        bool DueIsPayed);
}
