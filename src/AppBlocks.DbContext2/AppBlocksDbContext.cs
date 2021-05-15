using AppBlocks.DbContext;
using AppBlocks.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace AppBlocks
{
    public partial class AppBlocksDbContext : IdentityDbContext
    {
        public AppBlocksDbContext(DbContextOptions<AppBlocksDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = Config.Factory.GetConfig();
                optionsBuilder.UseSqlServer(
                    configuration.GetConnectionString(typeof(AppBlocksDbContext).Namespace)
                    //$"Server=.\\;Database={typeof(AppBlocksDbContext).Namespace};Trusted_Connection=True;MultipleActiveResultSets=true;Application Name=AppBlocks.Web.Dev"
                    , builder =>
                 builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatorId).HasMaxLength(255);
                entity.Property(e => e.Data);
                entity.Property(e => e.Description).HasMaxLength(2000);

                //entity.Ignore(c => c.FullPath);

                entity.Property(e => e.FullPath).IsRequired(false)
                    .HasComputedColumnSql("dbo.ufGetFullPath(Id)");

                entity.Property(e => e.Name).HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.OwnerId).HasMaxLength(255);

                entity.Property(e => e.ParentId).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.TypeId).HasMaxLength(255);

                entity.Property(e => e.Edited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditorId).HasMaxLength(255);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => (List<Item>)p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Items_Parent");

                //entity.HasOne(d => d.Type)
                //    .WithMany(p => p.InverseType)
                //    .HasForeignKey(d => d.TypeId)
                //    .HasConstraintName("FK_Items_Type");

                entity.HasOne(m => m.Creator).WithMany(i => i.CreatedBy).HasForeignKey(i => i.CreatorId).IsRequired(false);
                //entity.HasOne(m => m.Editor).WithMany(i => i.EditedBy).HasForeignKey(i => i.EditorId).IsRequired(false);
                entity.HasOne(m => m.Type).WithMany(i => i.TypeOf).HasForeignKey(i => i.TypeId).IsRequired(false);
                entity.HasOne(m => m.Owner).WithMany(i => i.OwnedBy).HasForeignKey(i => i.OwnerId).IsRequired(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}