using System;
using System.ServiceModel;
using ServiceCenter.BL.Interfaces;

namespace ServiceCenter.BL.UserService
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUserService _userService;
        public UserIdentityService(IUserService userService)
        {
            _userService = userService;
        }

        public Guid? GetCurrentUserId()
        {
            var a = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            var res = _userService.GetUserByLogin(a);
            return res.Result.Id;
        }
    }
}
