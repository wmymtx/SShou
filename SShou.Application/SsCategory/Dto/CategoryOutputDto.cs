using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.SsCategory.Dto
{
    [AutoMap(typeof(Entitys.SsCategory))]
    public class CategoryOutputDto
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}
