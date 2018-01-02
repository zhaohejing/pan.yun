using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Yun.Authorization.Roles;
using Yun.Authorization.Users;
using Yun.MultiTenancy;

namespace Yun.EntityFrameworkCore
{
    public class YunDbContext : AbpZeroDbContext<Tenant, Role, User, YunDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public YunDbContext(DbContextOptions<YunDbContext> options)
            : base(options)
        {
        }
    }
}
