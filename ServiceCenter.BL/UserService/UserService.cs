using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ServiceCenter.Auth.Models;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.BL.UserService
{
    public class UserService : IUserService
    {
        public UserService(UserManager<ApplicationUser, Guid> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _context = dbContext;
        }
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser, Guid> _userManager;
        public async Task<ApplicationUser> GetUserById(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }


        public async void DeleteUser(ApplicationUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _userManager.Update(user);
        }

        public Guid? AddUser(ApplicationUser user, string password)
        {
            var res = _userManager.Create(user, password);
            if (res.Succeeded) return user.Id;
            return null;
        }

        public bool Login(string userName, string password)
        {
            var user = GetUserByLogin(userName);
            return user.Result.PasswordHash == password;
        }

        public async Task<ApplicationUser> GetUserByLogin(string login)
        {
            return await _userManager.FindByNameAsync(login);
        }
    }
}
