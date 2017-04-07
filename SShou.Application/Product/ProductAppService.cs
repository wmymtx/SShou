using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;
using Abp.Domain.Repositories;
using Abp.AutoMapper;

namespace SShou.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IRepository.IProductRepository _prodRepository;

        public ProductAppService(IRepository.IProductRepository _iProdRepository)
        {
            this._prodRepository = _iProdRepository;
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <returns></returns>
        public IList<Dto.ProductListDto> GetProduct(int type)
        {
            return this._prodRepository.GetProduct(type).MapTo<IList<Dto.ProductListDto>>();
        }

        public IList<Dto.ProductListDto> GetProductById(string ids)
        {
            return this._prodRepository.GetProductById(ids).MapTo<IList<Dto.ProductListDto>>();
        }
    }
}
