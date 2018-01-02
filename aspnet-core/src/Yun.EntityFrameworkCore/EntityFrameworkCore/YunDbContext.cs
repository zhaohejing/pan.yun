using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Yun.Authorization.Roles;
using Yun.Authorization.Users;
using Yun.MultiTenancy;
using Yun.Shares;

namespace Yun.EntityFrameworkCore
{
    public class YunDbContext : AbpZeroDbContext<Tenant, Role, User, YunDbContext>
    {
        /* 定义 实体idbset 仓储 */
        /// <summary>
        /// 分享
        /// </summary>
        public virtual DbSet<Share> Shares { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }
        public YunDbContext(DbContextOptions<YunDbContext> options)
            : base(options)
        {
        }
    }
}
