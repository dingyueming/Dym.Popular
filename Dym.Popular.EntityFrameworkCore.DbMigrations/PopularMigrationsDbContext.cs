using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See PopularDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class PopularMigrationsDbContext : AbpDbContext<PopularMigrationsDbContext>
    {
        public PopularMigrationsDbContext(DbContextOptions<PopularMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside the ConfigurePopular method */

            builder.ConfigurePopular();
        }
    }
}