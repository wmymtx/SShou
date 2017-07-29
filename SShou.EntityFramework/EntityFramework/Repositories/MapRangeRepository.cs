using Abp.EntityFramework;
using SShou.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;

namespace SShou.EntityFramework.Repositories
{
   public class MapRangeRepository : SShouRepositoryBase<Entitys.MapRange>, IMapRangeRepository
    {
        public MapRangeRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        public List<MapRange> getAllRange()
        {
            return GetAllList();
        }
    }
}
