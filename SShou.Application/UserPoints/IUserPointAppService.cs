using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.UserPoints
{
    public interface IUserPointAppService : IApplicationService
    {
        int AddPointsScore(Dto.UserPointsInputDto pointDto);

        List<Dto.UserPointsOutputDto> GetPointsLog(int userId);

        int SignPoints(Dto.UserPointsInputDto pointDto);

        int IsSign(int userId);

        int GetPointScore(int userId);
    }
}
