using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IUserRepository
    {

        Entitys.AbpUser LoginIn(Entitys.AbpUser user);
    }
}
