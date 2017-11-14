using System;

namespace ServiceCenter.BL.Interfaces
{
    public interface IUserIdentityService
    {
        Guid? GetCurrentUserId();
    }
}
