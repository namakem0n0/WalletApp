using WalletApp.API.Users.Requests;
using WalletApp.Domain.Users.Data;

namespace WalletApp.API.Users.Mappers
{
    internal static class CrateUserMapper
    {
        public static UserCreateData AsData(this CreateUserRequest request) =>
            new(request.Name,
                request.Email,
                request.Password,
                request.DueIsPayed,
                request.CardId);
    }
}
