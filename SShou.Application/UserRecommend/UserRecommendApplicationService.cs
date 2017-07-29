using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.UserRecommend.Dto;
using Abp.AutoMapper;
using Abp.Domain.Uow;

namespace SShou.UserRecommend
{
    public class UserRecommendApplicationService : IUserRecommendApplicationService
    {
        readonly IRepository.IUserRecommendRepository _userRecommendReposity;
        private readonly IRepository.IPointsLogRepository _pointsLogRepository;
        private readonly IRepository.IUserDynamicInfoRepository _userDynamicInfoRepository;

        public UserRecommendApplicationService(IRepository.IUserRecommendRepository userRecommendReposity,
            IRepository.IPointsLogRepository pointsLogRepository,
            IRepository.IUserDynamicInfoRepository userDynamicInfoRepository)
        {
            this._userRecommendReposity = userRecommendReposity;
            this._pointsLogRepository = pointsLogRepository;
            this._userDynamicInfoRepository = userDynamicInfoRepository;
        }

        [UnitOfWork]
        public void AddUserRecommend(UserRecommendInputDto input)
        {
            int id = this._userRecommendReposity.AddRecommend(input.MapTo<Entitys.UserRecommend>());
            if (id >= 1)
            {
                Entitys.PointsLog pointLog = new Entitys.PointsLog();
                pointLog.FK_ID = id.ToString();
                pointLog.UserId = input.RecommenderId;
                pointLog.SourceType = 1;
                pointLog.Score = input.Score;
                this._pointsLogRepository.InvitAddPoints(pointLog);
                Entitys.UserDynamicInfo dyInfo = new Entitys.UserDynamicInfo();
                dyInfo.TotalScore = input.Score;
                dyInfo.UserId = input.RecommenderId;
                this._userDynamicInfoRepository.UpdatePointsScore(dyInfo);
            }
        }
    }
}
