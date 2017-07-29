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
    public class UserRecommend : Entity<int>
    {
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Recommender { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Recommended { get; set; }

        public int RecommenderId { get; set; }

        public DateTime? JoinTime { get; set; }
    }
}
