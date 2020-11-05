﻿// <auto-generated />
using System;
using Dym.Popular.EntityFrameworkCore.DbMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

namespace Dym.Popular.EntityFrameworkCore.DbMigrations.Migrations
{
    [DbContext(typeof(PopularMigrationsDbContext))]
    partial class PopularMigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.DictEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DictTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("DictTypeId");

                    b.ToTable("App_Mis_Dict");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.DictTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("App_Mis_DictType");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.DriverEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstIssueDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Hiredate")
                        .HasColumnType("datetime");

                    b.Property<string>("IdNo")
                        .IsRequired()
                        .HasColumnType("varchar(18) CHARACTER SET utf8mb4")
                        .HasMaxLength(18);

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int>("Sex")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UnitId");

                    b.ToTable("App_Mis_Driver");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.OilCostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<string>("CardNo")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<double>("Expend")
                        .HasColumnType("double");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<int>("OilTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RefuelingTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OilTypeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("App_Mis_OilCost");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.UnitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<string>("InteriorCode")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("Liaison")
                        .HasColumnType("varchar(18) CHARACTER SET utf8mb4")
                        .HasMaxLength(18);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Position")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(18) CHARACTER SET utf8mb4")
                        .HasMaxLength(18);

                    b.Property<int>("VehicleCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("App_Mis_Unit");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.VehicleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ActivationTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(null);

                    b.Property<string>("Color")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<string>("Displacement")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("EngineNo")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("InteriorCode")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("IsDelete")
                        .HasColumnType("int");

                    b.Property<string>("License")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Purpose")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.Property<string>("Vin")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("InteriorCode")
                        .IsUnique();

                    b.HasIndex("License")
                        .IsUnique();

                    b.HasIndex("UnitId");

                    b.ToTable("App_Mis_Vehicle");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.PopularSys.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("App_Popular_Role");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.PopularSys.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Creator")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("RealName")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Remark")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(11) CHARACTER SET utf8mb4")
                        .HasMaxLength(11);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("App_Popular_User");
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.DictEntity", b =>
                {
                    b.HasOne("Dym.Popular.Domain.Entities.Mis.DictTypeEntity", null)
                        .WithMany("Dicts")
                        .HasForeignKey("DictTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.DriverEntity", b =>
                {
                    b.HasOne("Dym.Popular.Domain.Entities.Mis.DictEntity", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dym.Popular.Domain.Entities.Mis.DictEntity", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dym.Popular.Domain.Entities.Mis.UnitEntity", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.OilCostEntity", b =>
                {
                    b.HasOne("Dym.Popular.Domain.Entities.Mis.DictEntity", "OilType")
                        .WithMany()
                        .HasForeignKey("OilTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dym.Popular.Domain.Entities.Mis.VehicleEntity", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dym.Popular.Domain.Entities.Mis.VehicleEntity", b =>
                {
                    b.HasOne("Dym.Popular.Domain.Entities.Mis.UnitEntity", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
