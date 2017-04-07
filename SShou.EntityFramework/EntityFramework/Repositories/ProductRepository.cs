using SShou.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;
using Abp.EntityFramework;

namespace SShou.EntityFramework.Repositories
{
    public class ProductRepository : SShouRepositoryBase<Entitys.Product>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }

        /// <summary>
        /// 获取回收类型
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetProduct(int type)
        {
            return GetAll().Where(o => o.Type == type).OrderBy(o=>o.Sort).ToList();
        }

        public IList<Entitys.Product> GetProductById(string ids)
        {
            var query = GetAll();
            string[] param = ids.Split(',');

            return query.Where(o => param.Contains(o.Id.ToString())).ToList();
        }
    }
}
