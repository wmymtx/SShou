using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface ISsCategoryRepository: IRepository<Entitys.SsCategory>
    {
        List<Entitys.SsCategory> GetAllCategory();
    }
}
