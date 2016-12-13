using System.Linq;
using SShou.EntityFramework;
using SShou.MultiTenancy;

namespace SShou.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly SShouDbContext _context;

        public DefaultTenantCreator(SShouDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
