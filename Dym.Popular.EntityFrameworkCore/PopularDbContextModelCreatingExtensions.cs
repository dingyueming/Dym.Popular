﻿using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.Entities.PopularSys;
using Dym.Popular.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Dym.Popular.EntityFrameworkCore
{
    public static class PopularDbContextModelCreatingExtensions
    {
        public static void ConfigurePopular(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            #region PopularSys

            //用户表
            builder.Entity<UserEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + SysDbConsts.User);
                b.HasKey(x => x.Id);
                b.Property(x => x.UserName).HasMaxLength(20).IsRequired();
                b.Property(x => x.Password).HasMaxLength(100).IsRequired();
                b.Property(x => x.RealName).HasMaxLength(20);
                b.Property(x => x.Telephone).HasMaxLength(11);
                b.Property(x => x.Address).HasMaxLength(100);
                b.Property(x => x.Email).HasMaxLength(100);
                b.Property(x => x.Status).HasColumnType("int");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
                b.Property(x => x.Remark).HasColumnType("longtext");
            });
            //角色表
            builder.Entity<RoleEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + SysDbConsts.Role);
                b.HasKey(x => x.Id);
                b.Property(x => x.RoleName).HasMaxLength(20).IsRequired();
                b.Property(x => x.RoleDescription).HasMaxLength(100);
                b.Property(x => x.Status).HasColumnType("int");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
                b.Property(x => x.Remark).HasColumnType("longtext");
            });

            #endregion

            #region Mis
            //车辆表
            builder.Entity<VehicleEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.Vehicle);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.License).IsUnique();
                b.HasIndex(x => x.InteriorCode).IsUnique();
                b.Property(x => x.UnitId).HasColumnType("int");
                b.Property(x => x.Purpose).HasColumnType("int");
                b.Property(x => x.Color).HasMaxLength(10);
                b.Property(x => x.EngineNo).HasMaxLength(50);
                b.Property(x => x.Vin).HasMaxLength(50);
                b.Property(x => x.VehicleType).HasColumnType("int");
                b.Property(x => x.Displacement).HasMaxLength(10);
                b.Property(x => x.Price).HasColumnType("decimal");
                b.Property(x => x.PurchaseDate).HasColumnType("datetime");
                b.Property(x => x.ActivationTime).HasColumnType("datetime").HasDefaultValue();
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            //驾驶员表
            builder.Entity<DriverEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.Driver);
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(20).IsRequired();
                b.Property(x => x.Sex).HasMaxLength(10).IsRequired();
                b.Property(x => x.IdNo).HasMaxLength(18).IsRequired();
                b.Property(x => x.StatusId).HasColumnType("int");
                b.Property(x => x.Hiredate).HasColumnType("datetime");
                b.Property(x => x.UnitId).HasColumnType("int");
                b.Property(x => x.ClassId).HasColumnType("int");
                b.Property(x => x.FirstIssueDate).HasColumnType("datetime");
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            //单位表
            builder.Entity<UnitEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.Unit);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.Name).IsUnique();
                b.Property(x => x.InteriorCode).HasMaxLength(20).IsRequired();
                b.Property(x => x.Address).HasMaxLength(500);
                b.Property(x => x.Liaison).HasMaxLength(18);
                b.Property(x => x.Telephone).HasMaxLength(18);
                b.Property(x => x.VehicleCount).HasColumnType("int");
                b.Property(x => x.Position).HasMaxLength(30);
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            //字典类型表
            builder.Entity<DictTypeEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.DictType);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.Name).IsUnique();
                b.HasMany(x => x.Dicts).WithOne().HasForeignKey("DictTypeId");
            });
            //字典表
            builder.Entity<DictEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.Dict);
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired();
            });
            //油料费用表
            builder.Entity<OilCostEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.OilCost);
                b.HasKey(x => x.Id);
                b.Property(x => x.Balance).HasColumnType("double");
                b.Property(x => x.CardNo).HasMaxLength(20).IsRequired();
                b.Property(x => x.Expend).HasColumnType("double");
                b.Property(x => x.OilTypeId).HasColumnType("int");
                b.Property(x => x.VehicleId).HasColumnType("int");
                b.Property(x => x.RefuelingTime).HasColumnType("datetime");
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            //车辆里程表
            builder.Entity<VehicleMileageEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.VehicleMileage);
                b.HasKey(x => x.Id);
                b.Property(x => x.FileName).HasMaxLength(20).IsRequired();
                b.Property(x => x.Mileage).HasColumnType("int");
                b.Property(x => x.VehicleId).HasColumnType("int");
                b.Property(x => x.RecordDate).HasColumnType("datetime");
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            //维修保养表
            builder.Entity<MaintenanceEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.Maintenance);
                b.HasKey(x => x.Id);
                b.Property(x => x.CostTypeId).HasMaxLength(20).IsRequired();
                b.Property(x => x.Expend).HasColumnType("double");
                b.Property(x => x.Address);
                b.Property(x => x.VehicleId).HasColumnType("int");
                b.Property(x => x.RecordTime).HasColumnType("datetime");
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            //违章表
            builder.Entity<ViolationEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.Violation);
                b.HasKey(x => x.Id);
                b.Property(x => x.VehicleId).HasColumnType("int");
                b.Property(x => x.TookDate).HasColumnType("datetime");
                b.Property(x => x.Fine).HasColumnType("double");
                b.Property(x => x.Indemnity).HasColumnType("double");
                b.Property(x => x.MaintenanceCost).HasColumnType("double");
                b.Property(x => x.IsOutDanger).HasColumnType("int");
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            //保险表
            builder.Entity<InsuranceEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + MisDbConsts.Insurance);
                b.HasKey(x => x.Id);
                b.Property(x => x.VehicleId).HasColumnType("int");
                b.Property(x => x.StartDate).HasColumnType("datetime");
                b.Property(x => x.EndDate).HasColumnType("datetime");
                b.Property(x => x.Expend).HasColumnType("double");
                b.Property(x => x.InsureName);
                b.Property(x => x.InsureType);
                b.Property(x => x.InsureNote).HasColumnType("longtext");
                b.Property(x => x.InsureCompany);
                b.Property(x => x.IsDelete).HasColumnType("int");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            #endregion
        }
    }
}