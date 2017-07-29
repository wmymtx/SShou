using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.UserRecommend.Dto
{
    [AutoMap(typeof(Entitys.UserRecommend))]
    public class UserRecommendInputDto
    {
        public string Recommender { get; set; }

        public string Recommended { get; set; }

        public int RecommenderId { get; set; }

        public int Score { get; set; }
    }
}
