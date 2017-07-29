using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Entitys
{
   public class MapRange:Entity
    {
        [Column(TypeName = "varchar"), MaxLength(30)]
        public virtual string RangeName { get; set; }
        [Column(TypeName = "varchar"), MaxLength(1000)]
        public virtual string Lat_Lng { get; set; }

    }
}
