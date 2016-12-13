using Abp.Authorization;
using SShou.Authorization.Roles;
using SShou.MultiTenancy;
using SShou.Users;

namespace SShou.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
