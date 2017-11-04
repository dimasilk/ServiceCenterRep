using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ServiceCenter.Auth.Models;

namespace ServiceCenter.BL.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserById(Guid userId);       
        void DeleteUser(ApplicationUser user);
        void UpdateUser(ApplicationUser user);
        Guid? AddUser(ApplicationUser user, string password);
    }
}
