using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Product.Dto
{
    [AutoMap(typeof(Entitys.Product))]
    public class ProductListDto
    {
        public int Id { get; set; }

        public string Prcd_Name { get; set; }

        public string Prcd_ImgPath { get; set; }
    }
}
