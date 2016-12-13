using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace SShou.EntityFramework.Repositories
{
    public abstract class SShouRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SShouDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SShouRepositoryBase(IDbContextProvider<SShouDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SShouRepositoryBase<TEntity> : SShouRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SShouRepositoryBase(IDbContextProvider<SShouDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
