using AppBlocks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppBlocks.DbContext.Configuration
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        private const string TableName = "items";
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            builder.HasIndex(x => x.ParentId)
                .HasName("NDX_ParentId");

            builder.Property(x => x.ParentId)
                .HasColumnName("ParentId")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            builder.Property(x => x.OwnerId)
                .HasColumnName("OwnerId")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");



            builder.Property(x => x.CreatorId)
                .HasColumnName("CreatorId")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            builder.Property(x => x.Created)
                .HasColumnName("Created")
                .HasColumnType("datetime");


            builder.Property(x => x.EditorId)
                .HasColumnName("EditorId")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(256)");

            builder.Property(x => x.Edited)
                .HasColumnName("Edited")
                .HasColumnType("datetime");

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(2000)");

            builder.Property(x => x.Data)
                .HasColumnName("data")
                .HasMaxLength(256)
                .HasColumnType("nvarchar(MAX)");

            //builder.HasOne(x => x.OwnerId)
            //    .WithMany(t => t.Id)
            //    .HasForeignKey(dt => dt.Id);

            //builder.HasOne(d => d.TypeId)
            //    .WithMany(t => t.Items)
            //    .HasForeignKey(dt => dt.TypeId);
        }
    }
}