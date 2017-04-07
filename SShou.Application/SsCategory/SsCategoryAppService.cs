using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.SsCategory.Dto;
using Abp.AutoMapper;

namespace SShou.SsCategory
{
    public class SsCategoryAppService : ISsCategoryAppService
    {
        private readonly IRepository.ISsCategoryRepository _ssCategoryRepository;
        public SsCategoryAppService(IRepository.ISsCategoryRepository ssCategoryRepository)
        {
            this._ssCategoryRepository = ssCategoryRepository;
        }

        public List<CategoryOutputDto> GetAllCategory()
        {
            var rstList = _ssCategoryRepository.GetAllCategory();
            return rstList.MapTo<List<Dto.CategoryOutputDto>>();
        }
    }
}
