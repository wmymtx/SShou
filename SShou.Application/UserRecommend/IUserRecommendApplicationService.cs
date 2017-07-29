using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.UserRecommend
{
    public interface IUserRecommendApplicationService : IApplicationService
    {
        void AddUserRecommend(Dto.UserRecommendInputDto input);
    }
}
