using Abp.EntityFramework;
using SShou.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.EntityFramework.Repositories
{
    public class UserRepository : SShouRepositoryBase<Entitys.AbpUser>, IUserRepository
    {
        public UserRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }
        public Entitys.AbpUser LoginIn(Entitys.AbpUser user)
        {
            var query = GetAll();
            var user_Item = query.Where(o => o.UserName == user.UserName).FirstOrDefault();
            return user_Item;
        }
    }
}
