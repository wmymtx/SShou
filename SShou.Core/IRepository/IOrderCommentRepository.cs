using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IOrderCommentRepository : IRepository<Entitys.OrderComment>
    {
        void AddComment(Entitys.OrderComment comment);

        Entitys.OrderComment GetComment(string orderId);

        void UpdateComment(Entitys.OrderComment comment);
    }
}
