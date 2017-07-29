using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
   public interface IMapRangeRepository: IRepository<Entitys.MapRange>
    {
        List<Entitys.MapRange> getAllRange();
    }
}
