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
        public virtual string Prcd_Name { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public virtual string Prcd_ImgPath { get; set; }

        [Column(TypeName = "varchar"), MaxLength(10)]
        public virtual string Unit { get; set; }

        public virtual int Type { get; set; }

        public virtual int Sort { get; set; }
    }
}
