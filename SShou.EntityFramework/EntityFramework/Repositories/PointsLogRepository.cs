using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;

namespace SShou.EntityFramework.Repositories
{
    public class PointsLogRepository : SShouRepositoryBase<Entitys.PointsLog>, IRepository.IPointsLogRepository
    {
        public PointsLogRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        public int CreatePointsLog(PointsLog log)
        {
            var query = GetAll();
            string nowDate = DateTime.Now.ToString("yyyyMMdd");
            var isExists = query.Where(o => o.UserId == log.UserId && o.AddTime == nowDate).FirstOrDefault();
            if (isExists == null)
                return InsertAndGetId(log);
            else
                return 0;
        }

        public List<PointsLog> GetPointsLog(int userId)
        {
            var query = GetAll();
            var rstList = query.Where(o => o.UserId == userId).ToList();
            return rstList;
        }

        public int IsSign(int userId)
        {
            var query = GetAll();
            string date = DateTime.Now.ToString("yyyyMMdd");
            var rstList = query.Where(o => o.UserId == userId && o.AddTime == date).ToList();
            return rstList == null ? 0 : rstList.Count;
        }
    }
}
