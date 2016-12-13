using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Entitys
{
    public class Product : Entity
    {
        [StringLength(30)]
        public string Prcd_Name { get; set; }

        [StringLength(50)]
        public string Prcd_ImgPath { get; set; }
    }
}
