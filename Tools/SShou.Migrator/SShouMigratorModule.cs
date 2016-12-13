using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using SShou.EntityFramework;

namespace SShou.Migrator
{
    [DependsOn(typeof(SShouDataModule))]
    public class SShouMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<SShouDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}