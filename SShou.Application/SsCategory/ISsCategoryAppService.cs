using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.SsCategory
{
    public interface ISsCategoryAppService:IApplicationService
    {
        List<Dto.CategoryOutputDto> GetAllCategory();
    }
}
