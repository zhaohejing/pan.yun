using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Yun.Configuration;
using Yun.Web;

namespace Yun.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class YunDbContextFactory : IDesignTimeDbContextFactory<YunDbContext>
    {
        public YunDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<YunDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            YunDbContextConfigurer.Configure(builder, configuration.GetConnectionString(YunConsts.ConnectionStringName));

            return new YunDbContext(builder.Options);
        }
    }
}
