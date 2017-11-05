using System.IdentityModel.Selectors;

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