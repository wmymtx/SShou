using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;

namespace SShou.EntityFramework.Repositories
{
    public class UserLoginLogRepository : SShouRepositoryBase<Entitys.UserLoginLog>, IRepository.IUserLoginLogRepository
    {
        public UserLoginLogRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        public int CreareLoginLog(UserLoginLog log)
        {
            return InsertAndGetId(log);
        }

        public List<UserLoginLog> GetUserLoginLog(int userId)
        {
            var query = GetAll();
            var rstList = query.Where(o => o.UserId == userId).ToList();
            return rstList;
        }
    }
}
