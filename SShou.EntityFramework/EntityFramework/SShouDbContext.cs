using System.Data.Common;
using Abp.Zero.EntityFramework;
using SShou.Authorization.Roles;
using SShou.MultiTenancy;
using SShou.Users;
using System.Data.Entity;

namespace SShou.EntityFramework
{
    public class SShouDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<Entitys.Product> Product { get; set; }
        public IDbSet<Entitys.Orders> Orders { get; set; }
        public IDbSet<Entitys.OrderItems> OrderItems { get; set; }
        public IDbSet<Entitys.SS_User> SS_User { get; set; }
        public IDbSet<Entitys.WeUser> WeUser { get; set; }
        /// <summary>
        /// 积分日志
        /// </summary>
        public IDbSet<Entitys.PointsLog> PointsLog { get; set; }

        /// <summary>
        /// 上门地址管理
        /// </summary>
        public IDbSet<Entitys.UserAddress> UserAddress { get; set; }

        /// <summary>
        /// 用户登录日志
        /// </summary>
        public IDbSet<Entitys.UserLoginLog> UserLoginLog { get; set; }

        public IDbSet<Entitys.UserDynamicInfo> UserDynamicInfo { get; set; }

        public IDbSet<Entitys.SsCategory> SsCategory { get; set; }

        /// <summary>
        /// 订单评论
        /// </summary>
        public IDbSet<Entitys.OrderComment> OrderComment { get; set; }

        public IDbSet<Entitys.AbpUser> AbpUser { get; set; }

        public IDbSet<Entitys.MapRange> MapRange { get; set; }


        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SShouDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SShouDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SShouDbContext since ABP automatically handles it.
         */
        public SShouDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SShouDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
