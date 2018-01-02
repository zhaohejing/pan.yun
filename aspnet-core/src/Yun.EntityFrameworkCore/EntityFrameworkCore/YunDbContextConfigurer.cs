using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Yun.EntityFrameworkCore
{
    public static class YunDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<YunDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<YunDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
