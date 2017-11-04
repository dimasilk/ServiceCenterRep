using System;
using System.Threading.Tasks;
using ServiceCenter.Auth.Models;

namespace ServiceCenter.BL.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserById(Guid userId);       
        void DeleteUser(ApplicationUser user);
        void UpdateUser(ApplicationUser user);
        Guid? AddUser(ApplicationUser user, string password);
        bool Login(string userName, string password);
        Task<ApplicationUser> GetUserByLogin(string login);

    }
}
