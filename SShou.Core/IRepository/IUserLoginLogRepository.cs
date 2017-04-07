using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IUserLoginLogRepository:IRepository<Entitys.UserLoginLog>
    {
        int CreareLoginLog(Entitys.UserLoginLog log);

        List<Entitys.UserLoginLog> GetUserLoginLog(int userId);
    }
}
