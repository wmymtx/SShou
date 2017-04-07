using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Product
{
    public interface IProductAppService: IApplicationService
    {
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <returns></returns>
        IList<Dto.ProductListDto> GetProduct(int type);

        /// <summary>
        /// 根据产品Id获取产品列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IList<Dto.ProductListDto> GetProductById(string ids);
    }
}
