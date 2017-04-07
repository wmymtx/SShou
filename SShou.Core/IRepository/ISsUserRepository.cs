using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface ISsUserRepository
    {
        List<Entitys.SS_User> GetAllUser();

        List<Entitys.SS_User> GetUserByPage(int pageIdex, int pageSize,int status);

        int GetTotal(int status);

        int CreateSsUser(Entitys.SS_User user);

        Entitys.SS_User GetUserDetail(int userId);

        int UpdateStatus(int userId, int status);
    }
}
