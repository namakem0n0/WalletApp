using Microsoft.AspNetCore.Mvc;
using WalletApp.API.Constants;
using WalletApp.Domain.Common;
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
    }
}
