using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InstaCore.Data
{
    public class MigrationContextFactory : IDbContextFactory<QuantContext>
    {
        public QuantContext Create(DbContextFactoryOptions options)
        {
            return new QuantContext(new DbContextOptions<QuantContext>());
        }
    }
}
