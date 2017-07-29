using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IUserRecommendRepository : IRepository<Entitys.UserRecommend>
    {
        int AddRecommend(Entitys.UserRecommend eneity);
    }
}
