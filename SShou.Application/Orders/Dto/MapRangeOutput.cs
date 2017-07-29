using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Orders.Dto
{
    [AutoMap(typeof(Entitys.MapRange))]
    public class MapRangeOutput
    {
        public  List<double> Lat { get; set; }

        public List<double> Lng { get; set; }
    }
}
