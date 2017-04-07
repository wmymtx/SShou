using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IUserDynamicInfoRepository : IRepository<Entitys.UserDynamicInfo>
    {
        int AddPointsScore(Entitys.UserDynamicInfo dyInfo);

        int UpdatePointsScore(Entitys.UserDynamicInfo dyInfo);

        int GetPointsScore(int userId);
    }
}
