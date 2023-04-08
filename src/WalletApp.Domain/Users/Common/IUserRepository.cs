using WalletApp.Domain.Transactions.Models;
using WalletApp.Domain.Users.Models;

namespace WalletApp.Domain.Users.Common
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<User>> GetAllUsers();
        Task<User> GetById(int id);
        void Add(User user);
    }
}
