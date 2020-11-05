﻿using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.Entities.PopularSys;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

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

        #region PopularSys
        public DbSet<UserEntity> User { get; set; }

        public DbSet<RoleEntity> Role { get; set; }

        #endregion

        #region Mis
        /// <summary>
        /// 车辆
        /// </summary>
        public DbSet<VehicleEntity> Vehicles { get; set; }
        /// <summary>
        /// 驾驶员
        /// </summary>
        public DbSet<DriverEntity> Drivers { get; set; }
        /// <summary>
        /// 单位（基地）
        /// </summary>
        public DbSet<UnitEntity> Units { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        public DbSet<DictTypeEntity> DictTypes { get; set; }
        /// <summary>
        /// 字典
        /// </summary>
        public DbSet<DictEntity> Dicts { get; set; }
        /// <summary>
        /// 油料费用
        /// </summary>
        public DbSet<OilCostEntity> OilCosts { get; set; }
        #endregion


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
