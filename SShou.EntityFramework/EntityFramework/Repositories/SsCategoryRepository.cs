using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.EntityFramework.Repositories
{
    public class SsCategoryRepository : SShouRepositoryBase<Entitys.SsCategory>, IRepository.ISsCategoryRepository
    {
        public SsCategoryRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        public List<Entitys.SsCategory> GetAllCategory()
        {
            return GetAll().ToList();
        }
    }
}
