using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IProductRepository : IRepository<Entitys.Product>
    {
        IList<Entitys.Product> GetProduct(int type);

        IList<Entitys.Product> GetProductById(string ids);

    }
}
