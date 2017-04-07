using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;

namespace SShou.EntityFramework.Repositories
{
    public class UserDynamicInfoRepository : SShouRepositoryBase<Entitys.UserDynamicInfo>, IRepository.IUserDynamicInfoRepository
    {
        public UserDynamicInfoRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        public int AddPointsScore(UserDynamicInfo dyInfo)
        {
            return InsertAndGetId(dyInfo);
        }

        public int UpdatePointsScore(UserDynamicInfo dyInfo)
        {
            var query = GetAll();
            var dyItem = query.Where(o => o.UserId == dyInfo.UserId).FirstOrDefault();
            if (dyItem == null)
            {
                return InsertAndGetId(dyInfo);
            }
            else
            {
                dyItem.TotalScore = dyItem.TotalScore + dyInfo.TotalScore;
                Update(dyItem);
                return 1;
            }
        }

        public int GetPointsScore(int userId)
        {
            var query = GetAll();
            var dyItem = query.Where(o => o.UserId == userId).FirstOrDefault();
            if (dyItem == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(dyItem.TotalScore);
            }
        }
    }
}
