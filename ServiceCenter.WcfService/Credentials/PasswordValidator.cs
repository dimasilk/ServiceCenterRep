using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.ServiceLocation;
using ServiceCenter.Auth.Models;

namespace ServiceCenter.WcfService.Credentials
{
    public class PasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            var um = ServiceLocator.Current.GetInstance<UserManager<ApplicationUser, Guid>>();

            if (um == null) throw new SecurityTokenValidationException();
            var user = um.FindByName(userName);
            if (user == null) throw new SecurityTokenValidationException();
            if (!um.CheckPassword(user, password)) throw new SecurityTokenValidationException();

        }
    }
}