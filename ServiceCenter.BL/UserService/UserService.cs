using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
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
        public Task<ApplicationUser> GetUserById(Guid userId)
        {
            return _userManager.FindByIdAsync(userId);
        }


        public void DeleteUser(ApplicationUser user)
        {
            _userManager.DeleteAsync(user);
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

        public Task<ApplicationUser> GetUserByLogin(string login)
        {
            return _userManager.FindByNameAsync(login);
        }
    }
}
