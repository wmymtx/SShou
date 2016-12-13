using System.Threading.Tasks;
using Abp.Application.Services;
using SShou.Roles.Dto;

namespace SShou.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
