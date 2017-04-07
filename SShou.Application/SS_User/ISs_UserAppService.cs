using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.SS_User
{
    public interface ISs_UserAppService : IApplicationService
    {
        List<Dto.SS_UserOutput> GetAllUser();

        List<Dto.SS_UserOutput> GetUserByPage(int pageIdex, int pageSize, int status);

        int CreateUser(Dto.SS_UserInputDto input);

        int GetTotal(int status);

        Dto.SS_UserDetailOutputDto GetUserDetail(int userId);

        int UpdateStatus(int userId, int status);
    }
}
