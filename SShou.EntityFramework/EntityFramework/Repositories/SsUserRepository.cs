using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;

namespace SShou.EntityFramework.Repositories
{
    public class SsUserRepository : SShouRepositoryBase<Entitys.SS_User>, IRepository.ISsUserRepository
    {
        public SsUserRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        public List<SS_User> GetAllUser()
        {
            var query = GetAll().Where(o=>o.Status==1);
            return query.ToList();
        }

        public List<Entitys.SS_User> GetUserByPage(int pageIndex, int pageSize, int status)
        {
            var query = GetAll();
            var lst = query.Where(o => o.Status == status).OrderByDescending(o => o.JoinTime).Skip(pageSize * pageIndex).Take(pageSize);
            return lst.ToList();
        }

        public int GetTotal(int status)
        {
            return Count(o => o.Status == status);
        }

        public int CreateSsUser(Entitys.SS_User user)
        {
            var query = GetAll();
            var item = query.Where(o => o.OpenId == user.OpenId).FirstOrDefault();
            if (item == null)
            {
                user.JoinTime = DateTime.Now;
                Insert(user);
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Entitys.SS_User GetUserDetail(int userId)
        {
            return Get(userId);
        }

        public int UpdateStatus(int userId, int status)
        {
            var item = Get(userId);
            if (item != null)
            {
                item.Status = status;
                Update(item);
                return 1;
            }
            return 0;
        }
    }
}
