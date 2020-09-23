using Dym.Popular.Domain.Entities.Blogs;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace Dym.Popular.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See PopularMigrationsDbContext for migrations.
     */
    [ConnectionStringName("MySql")]
    public class PopularDbContext : AbpDbContext<PopularDbContext>
    {
        //public DbSet<AppUser> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<FriendLink> FriendLinks { get; set; }


        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside PopularDbContextModelCreatingExtensions.ConfigurePopular
         */

        public PopularDbContext(DbContextOptions<PopularDbContext> options)
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
