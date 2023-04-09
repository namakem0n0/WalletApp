using Microsoft.AspNetCore.Mvc;
using WalletApp.API.Constants;
using WalletApp.API.MoneyTransactions.Mappers;
using WalletApp.API.MoneyTransactions.Requests;
using WalletApp.API.Users.Mappers;
using WalletApp.API.Users.Requests;
using WalletApp.Domain.Common;
using WalletApp.Domain.Transactions.Models;
using WalletApp.Domain.Users.Models;
using WalletApp.Persistence.Context;

namespace WalletApp.API.Controllers
{
    [Route(Routes.Users)]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly WalletAppDbContext _context;

        public UserContoller(IUnitOfWork unitOfWork, WalletAppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IReadOnlyCollection<User>> GetUsers()
        {
            return await _unitOfWork.Users.GetAllUsers();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int userId)
        {
            var asset = await _unitOfWork.Users.GetById(userId);
            return Ok(asset);
        }

        [HttpPost]
        public async Task<int> CreateUser(CreateUserRequest request)
        {
            var data = request.AsData();
            var newUser = Domain.Users.Models.User.Create(data);

            _unitOfWork.Users.Add(newUser);
            await _unitOfWork.Complete();

            return newUser.Id;
        }

        [HttpGet("transactions")]
        public async Task<IReadOnlyCollection<MoneyTransaction>> GetAllUserTransactions(int userId)
        {
            return await _unitOfWork.MoneyTransactions.GetAllTransactions(userId);
        }

        [HttpGet("lastTenTransactions")]
        public async Task<IReadOnlyCollection<MoneyTransaction>> GetLastTenUserTransactions(int userId)
        {
            return await _unitOfWork.MoneyTransactions.GetLastTenTransactions(userId);
        }

        [HttpGet]
        public async Task<MoneyTransaction> GetTransactionById(int transactionId)
        {
            return await _unitOfWork.MoneyTransactions.GetById(transactionId);
        }

        [HttpPost("createTransaction")]
        public async Task<int> CreateTransaction(CreateMoneyTransactionRequest request)
        {
            var data = request.AsData();
            var newTransaction = MoneyTransaction.Create(data);
            var user = await _unitOfWork.Users.GetById(newTransaction.UserId);

            if(newTransaction.Type == TransactionType.Payment)
                user.ChangeBalance(newTransaction.Amount);
            if(newTransaction.Type == TransactionType.Credit)
                user.ChangeBalance(newTransaction.Amount * (-1));

            _unitOfWork.MoneyTransactions.Add(newTransaction);
            await _unitOfWork.Complete();

            return newTransaction.Id;
        }

        [HttpDelete]
        public async Task<int> RemoveTransaction(DeleteMoneyTransactionRequest request)
        {
            var transactionToDelete = await _unitOfWork.MoneyTransactions.GetById(request.transactionId);

            if (transactionToDelete == null)
                return -1;

            var user = await _unitOfWork.Users.GetById(transactionToDelete.UserId);

            if (transactionToDelete.Type == TransactionType.Payment)
                user.ChangeBalance(transactionToDelete.Amount * (-1));
            if (transactionToDelete.Type == TransactionType.Credit)
                user.ChangeBalance(transactionToDelete.Amount);

            _unitOfWork.MoneyTransactions.Delete(transactionToDelete);
            await _unitOfWork.Complete();

            return transactionToDelete.Id;
        }
    }
}
