using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IPointsLogRepository : IRepository<Entitys.PointsLog>
    {
        int CreatePointsLog(Entitys.PointsLog log);

        List<Entitys.PointsLog> GetPointsLog(int userId);

        int IsSign(int userId);

        void InvitAddPoints(Entitys.PointsLog entity);
    }
}
