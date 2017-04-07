using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Users.Dto
{
    [AutoMap(typeof(Entitys.AbpUser))]
    public class UserLoginOutputDto
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
}
