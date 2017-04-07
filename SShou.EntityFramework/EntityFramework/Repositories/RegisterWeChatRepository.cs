using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;

namespace SShou.EntityFramework.Repositories
{
    public class RegisterWeChatRepository : SShouRepositoryBase<Entitys.WeUser>, IRepository.IRegisterWeChatRepository
    {
        public RegisterWeChatRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        public Entitys.WeUser CreateUser(WeUser user)
        {
            try
            {
                return Insert(user);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public WeUser GetWeUser(string openId)
        {
            var query = GetAll();
            var queryUser = query.Where(o => o.OpenId == openId).FirstOrDefault();
            return queryUser;
        }

        public Entitys.WeUser GetWeUserByUserId(int userId)
        {
            var query = GetAll();
            var queryUser = query.Where(o => o.Id == userId).FirstOrDefault();
            return queryUser;
        }

        public Entitys.WeUser IsInit(int userId)
        {
            var query = GetAll();
            var queryUser = query.Where(o => o.Id == userId).FirstOrDefault();
            return queryUser;
        }

        public Entitys.WeUser UpdateUser(Entitys.WeUser user)
        {
            return Update(user);
        }

        public bool IsHasInvitCode(int code)
        {
            var query = GetAll();
            var hasRow = query.Where(o => o.Invit_Code == code).FirstOrDefault();
            if (null != hasRow)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsHasRecommendCode(int code)
        {
            var query = GetAll();
            var hasRow = query.Where(o => o.Recommend_Code == code).FirstOrDefault();
            if (null != hasRow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
