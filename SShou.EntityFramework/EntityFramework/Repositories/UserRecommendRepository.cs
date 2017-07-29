using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;
using SShou.Entitys;

namespace SShou.EntityFramework.Repositories
{
    public class UserRecommendRepository : SShouRepositoryBase<Entitys.UserRecommend>, IRepository.IUserRecommendRepository
    {
        public UserRecommendRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public int AddRecommend(UserRecommend eneity)
        {
            var query = GetAll();
            var item = query.Where(o => o.Recommended == eneity.Recommended).FirstOrDefault();
            if (item == null)
            {
                eneity.JoinTime = DateTime.Now;
                return InsertAndGetId(eneity);
            }
            return 0;
        }
    }
}
