using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InstaCore.Data
{
    public class AppDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            return new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }
    }
}
