using Abp.Domain.Entities;
using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Entitys
{
    public class Product : Entity
    {
        [Column(TypeName = "nvarchar"), MaxLength(16)]
        public string Prcd_Name { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Prcd_ImgPath { get; set; }
    }
}
