using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace ServiceCenter.WcfService.Credentials
{
    public class PasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            //if (userName != password)
            //{
            //    throw new SecurityTokenValidationException();
            //}
        }
    }
}