using Dym.Popular.Domain.Entities.Blogs;
using Dym.Popular.Domain.Entities.PopularSys;
using Dym.Popular.Domain.Entities.Mis;
using Dym.Popular.Domain.Shared;
using Dym.Popular.Domain.Shared.Blogs;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;

namespace Dym.Popular.EntityFrameworkCore
{
    public static class PopularDbContextModelCreatingExtensions
    {
        public static void ConfigurePopular(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */
            #region blog
            builder.Entity<Post>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + BlogDbConsts.DbTableName.Posts);
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(200).IsRequired();
                b.Property(x => x.Author).HasMaxLength(10);
                b.Property(x => x.Url).HasMaxLength(100).IsRequired();
                b.Property(x => x.Html).HasColumnType("longtext").IsRequired();
                b.Property(x => x.Markdown).HasColumnType("longtext").IsRequired();
                b.Property(x => x.CategoryId).HasColumnType("int");
                b.Property(x => x.CreationTime).HasColumnType("datetime");
            });

            builder.Entity<Category>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + BlogDbConsts.DbTableName.Categories);
                b.HasKey(x => x.Id);
                b.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<Tag>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + BlogDbConsts.DbTableName.Tags);
                b.HasKey(x => x.Id);
                b.Property(x => x.TagName).HasMaxLength(50).IsRequired();
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<PostTag>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + BlogDbConsts.DbTableName.PostTags);
                b.HasKey(x => x.Id);
                b.Property(x => x.PostId).HasColumnType("int").IsRequired();
                b.Property(x => x.TagId).HasColumnType("int").IsRequired();
            });
            builder.Entity<FriendLink>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + BlogDbConsts.DbTableName.Friendlinks);
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(20).IsRequired();
                b.Property(x => x.LinkUrl).HasMaxLength(100).IsRequired();
            });
            #endregion

            #region PopularSys

            //用户表
            builder.Entity<UserEntity>(b =>
            {
                b.ToTable(PopularConsts.DbTablePrefix + PopularDbConsts.User);
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
                b.ToTable(PopularConsts.DbTablePrefix + PopularDbConsts.Role);
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
                b.Property(x => x.License).HasMaxLength(20).IsRequired();
                b.Property(x => x.Color).HasMaxLength(10);
                b.Property(x => x.EngineNo).HasMaxLength(50);
                b.Property(x => x.Vin).HasMaxLength(50);
                b.Property(x => x.VehicleType).HasColumnType("int");
                b.Property(x => x.Price).HasColumnType("decimal");
                b.Property(x => x.PurchaseDate).HasColumnType("datetime");
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
                b.Property(x => x.Birthday).HasColumnType("datetime");
                b.Property(x => x.IdNo).HasMaxLength(18).IsRequired();
                b.Property(x => x.Height).HasColumnType("int");
                b.Property(x => x.Weight).HasColumnType("int");
                b.Property(x => x.FileNo).HasMaxLength(12).IsRequired();
                b.Property(x => x.Class).HasColumnType("int");
                b.Property(x => x.FirstIssueDate).HasColumnType("datetime");
                b.Property(x => x.Remark).HasColumnType("longtext");
                b.Property(x => x.Creator).HasColumnType("int");
                b.Property(x => x.CreateTime).HasColumnType("datetime");
            });
            #endregion
        }
    }
}