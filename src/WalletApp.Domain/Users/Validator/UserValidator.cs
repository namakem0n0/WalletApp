using System.Text.RegularExpressions;
using WalletApp.Domain.Exceptions;
using WalletApp.Domain.Users.Models;

namespace WalletApp.Domain.Users.Validator
{
    public class UserValidator
    {
        public static void ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ValidationException("Name should not be empty");

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(user.Email);
            if (!match.Success)
                throw new ValidationException("Email is not valid");

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ValidationException("Password should not be empty");
        }
    }
}
