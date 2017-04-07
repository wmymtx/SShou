using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.UserPoints.Dto;
using Abp.Domain.Uow;

namespace SShou.UserPoints
{
    public class UserPointAppService : IUserPointAppService
    {
        private readonly IRepository.IPointsLogRepository pointsLogRepository;
        private readonly IRepository.IUserDynamicInfoRepository userDynamicInfoRepository;
        private readonly IRepository.IUserLoginLogRepository userLoginLogRepository;

        public UserPointAppService(IRepository.IPointsLogRepository _pointsLogRepository, IRepository.IUserDynamicInfoRepository _userDynamicInfoRepository, IRepository.IUserLoginLogRepository _userLoginLogRepository)
        {
            this.pointsLogRepository = _pointsLogRepository;
            this.userDynamicInfoRepository = _userDynamicInfoRepository;
            this.userLoginLogRepository = _userLoginLogRepository;
        }

        [UnitOfWork]
        public int AddPointsScore(UserPointsInputDto pointDto)
        {
            Entitys.UserLoginLog userLog = new Entitys.UserLoginLog();
            userLog.LoginTime = DateTime.Now;
            userLog.LoginAddr = pointDto.Ip;
            userLog.UserId = pointDto.UserId;
            this.userLoginLogRepository.CreareLoginLog(userLog);

            //Entitys.PointsLog log = new Entitys.PointsLog();
            //log.Score = pointDto.Score;
            //log.UserId = pointDto.UserId;
            //log.AddTime = DateTime.Now.ToString("yyyyMMdd");

            //if (this.pointsLogRepository.CreatePointsLog(log) > 0)
            //{
            //    Entitys.UserDynamicInfo dyInfo = new Entitys.UserDynamicInfo();
            //    dyInfo.TotalScore = pointDto.Score;
            //    dyInfo.UserId = pointDto.UserId;

            //    this.userDynamicInfoRepository.UpdatePointsScore(dyInfo);
            //    return 1;
            //}
            return 0;
        }

        public int GetPointScore(int userId)
        {
            return userDynamicInfoRepository.GetPointsScore(userId);
        }

        [UnitOfWork]
        public int SignPoints(UserPointsInputDto pointDto)
        {
            Entitys.PointsLog log = new Entitys.PointsLog();
            log.Score = pointDto.Score;
            log.UserId = pointDto.UserId;
            log.AddTime = DateTime.Now.ToString("yyyyMMdd");

            if (this.pointsLogRepository.CreatePointsLog(log) > 0)
            {
                Entitys.UserDynamicInfo dyInfo = new Entitys.UserDynamicInfo();
                dyInfo.TotalScore = pointDto.Score;
                dyInfo.UserId = pointDto.UserId;

                this.userDynamicInfoRepository.UpdatePointsScore(dyInfo);
                return 1;
            }
            return 0;
        }

        public List<UserPointsOutputDto> GetPointsLog(int userId)
        {
            throw new NotImplementedException();
        }

        public int IsSign(int userId)
        {
            return pointsLogRepository.IsSign(userId);
        }
    }
}
